using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace KeepAliveWorker
{
    [Serializable]
    public class ServiceConfig
    {
        public ServiceConfig()
        {
            Items = new List<ServiceItem>();
        }

        public int ShortTimeOut { get; set; } = 10;

        public int LongTimeOut { get; set; } = 90;

        public bool ShowDebugInfo { get; set; }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public virtual List<ServiceItem> Items { get; set; }
    }

    [Serializable]
    public class ServiceItem
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement("Enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        [XmlElement("Url")]
        public string Url { get; set; }

        /// <summary>
        /// Периодичность опроса в секундах
        /// </summary>
        [XmlElement("Timeout")]
        public int Interval { get; set; }

        /// <summary>
        /// Время последнего запуска
        /// </summary>
        [XmlElement("LastRunTime")]
        public DateTime LastRunTime { get; set; }

        [XmlIgnore]
        public bool CanRun
        {
            get
            {
                var seconds = (DateTime.Now - this.LastRunTime).TotalSeconds;
                return seconds > Interval;
            }
        }
    }
}