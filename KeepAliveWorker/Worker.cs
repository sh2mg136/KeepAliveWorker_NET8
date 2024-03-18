using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using System.Text;
using System.Net.Http;
using System.Net;

namespace KeepAliveWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ServiceConfig _options;

        public Worker(ILogger<Worker> logger, ServiceConfig cfg)
        {
            _logger = logger;
            _options = cfg;
            _logger.LogInformation("Worker has been created: {time}", DateTimeOffset.Now);
        }

        bool CanRun => _options != null && _options.Items != null && _options.Items.Any();
        int ShortTimeout
        {
            get
            {
                if (_options == null || _options.ShortTimeOut < 10)
                    return 10000;

                return 1000 * _options.ShortTimeOut;
            }
        }

        int LongTimeout
        {
            get
            {
                if (_options == null || _options.LongTimeOut < 60)
                    return 60000;
                if (_options == null || _options.LongTimeOut > 600)
                    return 600000;

                return 1000 * _options.LongTimeOut;
            }
        }

        int ItemsTotalAmount => (_options == null || _options.Items == null) ? 0 : _options.Items.Count();

        int ItemsEnabledAmount => (_options == null || _options.Items == null) ? 0 : _options.Items.Where(x => x.Enabled).Count();

        bool ShowDebugInfo => _options == null || _options.ShowDebugInfo;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            LogInfo("Worker has been started");

            StringBuilder sb = new StringBuilder(Environment.NewLine);
            sb.AppendLine($"ShortTimeout: {ShortTimeout}");
            sb.AppendLine($"LongTimeout: {LongTimeout}");
            sb.AppendLine($"Total amount of items: {ItemsTotalAmount}");
            sb.AppendLine($"Enabled items amount: {ItemsEnabledAmount}");

            LogInfo(sb.ToString());

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (CanRun)
                {
                    if (ShowDebugInfo)
                        LogInfo("Worker running at");

                    foreach (var item in _options.Items.Where(x => x.Enabled))
                    {
                        if (item.CanRun)
                        {
                            LogInfo($"Run task: {item.Name}");

                            item.LastRunTime = DateTime.Now;

                            try
                            {
                                var result = CheckServiceWithPostRequest(item.Name, item.Url);

                                if (result.Done)
                                {
                                    LogInfo($"[{item.Name}] SUCCESS: {item.Url}. [{result.ResponseString}]{Environment.NewLine}");
                                }
                                else
                                {
                                    LogInfo($"[{item.Name}] FAILED: {item.Url}{Environment.NewLine}");
                                }
                            }
                            catch (Exception ex)
                            {
                                LogInfo($"[{item.Name}] FAILED: {item.Url}. {ex.Message}{Environment.NewLine}");
                            }
                        }
                    }

                    await Task.Delay(ShortTimeout, stoppingToken);
                }
                else
                {
                    LogInfo("Incorrect config or something went wrong :( Tasks are disabled.");
                    await Task.Delay(LongTimeout, stoppingToken);
                }
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                LogInfo("Worker stooped at");
                NLog.LogManager.Shutdown();
            }
            catch { }
            return base.StopAsync(cancellationToken);
        }

        void LogInfo(string msg)
        {
            if (_logger == null)
                return;

            _logger.LogInformation($"{msg}");
        }

        void LogError(Exception ex, string msg)
        {
            if (_logger == null)
                return;

            _logger.LogError(ex, $"{msg}");
        }

        internal CheckResult CheckServiceWithPostRequest(string name, string url)
        {
            CheckResult result = new CheckResult();

            var postData = @"=WTF?";

            HttpStatusCode sc = HttpStatusCode.NoContent;

            if (string.IsNullOrWhiteSpace(url))
            {
                result.ResponseString = $"[{name}] URL not defined.";
                return result;
            }

            string respString = string.Empty;

            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");

                var msg = client.PostAsync(url, content);

                sc = msg.Result.StatusCode;

                var resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var responseContent = resp.Content;
                    respString = responseContent.ReadAsStringAsync().Result;
                    result.Done = true;
                }
            }

            if (respString != null && respString.Length > 90)
            {
                respString = respString.Substring(0, 90);
            }

            result.ResponseString = respString;

            return result;
        }
    }

    class CheckResult
    {
        public bool Done { get; set; }
        public string ResponseString { get; set; }
    }
}
