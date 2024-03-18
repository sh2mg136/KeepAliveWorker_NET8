**KeepAliveWBackgroundWorker**
*.NET Core 5*


Пример конфигурации задач:

```

  "ServiceConfig": {
    "ShortTimeOut": 20,
    "LongTimeOut": 90,
    "ShowDebugInfo": false,
    "Items": [
      {
        "Enabled": true,
        "Name": "Name-1",
        "Url": "http://localhost:5053",
        "Interval": 180
      },
      {
        "Enabled": true,
        "Name": "Name-2",
        "Url": "http://localhost:5555",
        "Interval": 90
      }
    ]
  }

'''

ShortTimeOut            Стандартный интервал проверки состояния задач (в секундах)
LongTimeOut             Длинный интервал на случай ошибки (в секундах)
ShowDebugInfo           Писать доп. инфо в лог
Items
    Item
        Enabled         Флаг вкл/выключения побудки для данного URL
        Name            Просто наименование для лога
        Url             URL по кот. будет отправлен POST
        Interval        Как часто посылать POST в секундах



**Установка сервиса**
>>> sc  create  KeepAliveWorker  binpath=c:\projects\KeepAliveWorker5.0\KeepAliveWorker.exe  start= auto|demand|disabled|delayed-auto


**Запуск|остановка**
>>> sc  \\localhost  start|stop  KeepAliveWorker

**Инфо**
>>> sc  \\localhost  query KeepAliveWorker


**Удаление службы**
>>> SC DELETE KeepAliveWorker


** Задание среды**

Development из VS задается конфигом launchSettings.json
Для Staging задаем системную переменную среды set DOTNET_ENVIRONMENT=Staging
Production задается автоматом, либо через системную переменную set DOTNET_ENVIRONMENT=Production


--------------------------------------------------------------------------------------------------------------------

2024-03-14      UPGRADE TO CORE 8



Starting upgrade of selected nodes for KeepAliveWorker.csproj...
Traits
	{Name=UA, Version=0.5.585.50603}
	UAExtensibleOperations
	OutputTypeExe
	C#
	AppDesigner
	PreserveFormatting
	CSharp
	EditAndContinue
	LanguageService
	OpenProjectFile
	CPS
	SharedImports
	ProjectConfigurationsDeclaredDimensions
	UseProjectEvaluationCache
	HandlesOwnReload
	.NET
	Microsoft.VisualStudio.ProjectSystem.RetailRuntime
	RunningInVisualStudio
	HostSetActiveProjectConfiguration
	AllTargetOutputGroups
	DeclaredSourceItems
	IntegratedConsoleDebugging
	Managed
	PersistDesignTimeDataOutOfProject
	VisualStudioWellKnownOutputGroups
	RelativePathDerivedDefaultNamespace
	SupportAvailableItemName
	NoGeneralDependentFileIcon
	ProjectReferences
	AppServicePublish
	UserSourceItems
	LocalUserSecrets
	CrossPlatformExecutable
	DynamicFileNesting
	WebNestingDefaults
	FolderPublish
	NetSdkOCIImageBuild
	UseFileGlobs
	SharedProjectReferences
	ProjectPropertyInterception
	DynamicDependentFile
	GenerateDocumentationFile
	PackageReferences
	WinRTReferences
	DynamicFileNestingEnabled
	SingleFileGenerators
	DataSourceWindow
	DotNetCoreWorker
	ProjectImportsTree
	OutputGroups
	LaunchProfiles
	DependenciesTree
	AssemblyReferences
	DisableBuiltInDebuggerServices
	ClassDesigner
	COMReferences
	Publish
	ConfigurableFileNesting
	ProjectPropertiesEditor
	Pack
	SupportHierarchyContextSvc
	SdkStyleProject
	net5.0
	{TargetFramework=.NETCoreApp, 5.0}
	VS
	Inplace
	FinalizeProjectDependenciesChanges
	WaitForRestore
	{Operation=framework}
Properties
	Controller = Microsoft.UpgradeAssistant.VS.Slices.Operations.Controllers.Common.ProjectFrameworkInplaceController
	OperationDefinition = Microsoft.UpgradeAssistant.Operations.OperationDefinition
	Traits = Microsoft.UpgradeAssistant.Traits.TraitsSet
	UpgradeFromProject = KeepAliveWorker
	ProjectKind = DotNetCoreApp
	ProjectFilePath = F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj
	Flow = Microsoft.UpgradeAssistant.VS.UI.Controls.Flow.FlowViewModel
	TargetFramework = .NET, 8.0
	MissingComponentDescription = .NET 8.0 SDK is not found on the machine. To be able to upgrade your project please follow link below and install required SDK.
	Slice = KeepAliveWorker.csproj
	SelectedNodes = System.Linq.Enumerable+WhereSelectEnumerableIterator`2[Microsoft.UpgradeAssistant.SliceTree,Microsoft.UpgradeAssistant.SliceNode]
	CorrelationIdKey = b87eb351-15c5-4792-9bfa-4a596767927f
	Nodes = System.Linq.OrderedEnumerable`2[Microsoft.UpgradeAssistant.SliceNode,System.Int32]
project KeepAliveWorker.csproj...
	Microsoft.UpgradeAssistant.VS.Slices.Transformers.UnloadProjectTransformer
	info: Unloading project 'KeepAliveWorker (F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj)'...
	info: Done
	Microsoft.UpgradeAssistant.Msbuild.Transformers.InplaceDuplicatePackageReferenceTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.TargetFrameworkTransformer
	info: Setting property 'TargetFramework' to 'net8.0' for project 'KeepAliveWorker (F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj)'.
	info: Done
Succeeded
reference.package Microsoft.Extensions.Hosting 5.0.0...
	Microsoft.UpgradeAssistant.Transformers.DefaultPackageMapTransformer
	info: Removing package 'Microsoft.Extensions.Hosting' from project 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Adding package Microsoft.Extensions.Hosting 8.0.0 to project F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj.
	info: Done
	Microsoft.UpgradeAssistant.Transformers.InplacePackageReferenceTransformer
	info: Done
Succeeded
reference.package Microsoft.Extensions.Hosting.WindowsServices 5.0.1...
	Microsoft.UpgradeAssistant.Transformers.DefaultPackageMapTransformer
	info: Removing package 'Microsoft.Extensions.Hosting.WindowsServices' from project 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Adding package Microsoft.Extensions.Hosting.WindowsServices 8.0.0 to project F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj.
	info: Done
	Microsoft.UpgradeAssistant.Transformers.InplacePackageReferenceTransformer
	info: Done
Succeeded
reference.package NLog 4.5.11...
	Microsoft.UpgradeAssistant.Transformers.DefaultPackageMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.InplacePackageReferenceTransformer
	info: Done
Skipped
reference.package NLog.GelfTarget 4.4.1...
	Microsoft.UpgradeAssistant.Transformers.DefaultPackageMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.InplacePackageReferenceTransformer
Could not find 'NLog.GelfTarget' (net8.0 / ) in
	- https://api.nuget.org/v3/index.json
	- C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\
	- F:\documents\__nuget
	warning: Package 'NLog.GelfTarget' does not support target framework(s) 'net8.0' for project 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Removing package 'NLog.GelfTarget' from project 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Done
Succeeded
reference.package NLog.Web.AspNetCore 4.8.0...
	Microsoft.UpgradeAssistant.Transformers.DefaultPackageMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.InplacePackageReferenceTransformer
	info: Done
Skipped
dependencies.finalizer Finalize project dependencies...
	Microsoft.UpgradeAssistant.Msbuild.Transformers.ProjectDependenciesFinalizerTransformer
	info: Upgrading dependencies in project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Removing package reference 'Microsoft.Extensions.Hosting' from project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Removing package reference 'Microsoft.Extensions.Hosting.WindowsServices' from project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Removing package reference 'NLog.GelfTarget' from project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Adding package reference 'Microsoft.Extensions.Hosting' to project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Adding package reference 'Microsoft.Extensions.Hosting.WindowsServices' to project file 'F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj'.
	info: Done
	Microsoft.UpgradeAssistant.VS.Slices.Transformers.ReloadProjectTransformer
	info: Reloading project 'KeepAliveWorker (F:\projects\KeepAliveWorker_Core5\KeepAliveWorker\KeepAliveWorker.csproj)'...
	info: Done
	Microsoft.UpgradeAssistant.VS.Slices.Transformers.WaitForRestoreTransformer
	info: Waiting for restore...
	info: Done
Succeeded
file.gitignore .gitignore...
Skipped
file.json appsettings.Development.json...
Skipped
file.json appsettings.json...
Skipped
file.json appsettings.Production.json...
Skipped
file.json appsettings.Stage.json...
Skipped
file.json appsettings.Test1.json...
Skipped
file.config nlog.config...
Skipped
file.cs Program.cs...
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultAttributeTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultMemberMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapUsingsTransformer
	info: Done
Succeeded
file.md readme.md...
Skipped
file.cs ServiceConfig.cs...
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultAttributeTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultMemberMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapUsingsTransformer
	info: Done
Succeeded
file.cs Worker.cs...
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultAttributeTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultMemberMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapTransformer
	info: Done
	Microsoft.UpgradeAssistant.Transformers.Code.CSharp.DefaultTypeMapUsingsTransformer
	info: Done
Succeeded
file.json launchSettings.json...
Skipped
file.pubxml FolderProfile.pubxml...
Skipped
Complete: 8 succeeded, 0 failed, 12 skipped.


