---
title: Logging providers in .NET
description: Learn how the logging provider API is used in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
---

# Logging providers in .NET

Logging providers persist logs, except for the `Console` provider, which only displays logs as standard output. For example, the Azure Application Insights provider stores logs in Azure Application Insights. Multiple providers can be enabled.

The default .NET Worker app templates:

- Use the [Generic Host](generic-host.md).
- Call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>, which adds the following logging providers:
  - [Console](#console)
  - [Debug](#debug)
  - [EventSource](#event-source)
  - [EventLog](#windows-eventlog) (Windows only)

:::code language="csharp" source="snippets/configuration/console/Program.cs" highlight="17":::

The preceding code shows the `Program` class created with the .NET Worker app templates. The next several sections provide samples based on the .NET Worker app templates, which use the Generic Host.

To override the default set of logging providers added by `Host.CreateDefaultBuilder`, call `ClearProviders` and add the logging providers you want. For example, the following code:

- Calls <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> to remove all the <xref:Microsoft.Extensions.Logging.ILoggerProvider> instances from the builder.
- Adds the [Console](#console) logging provider.

```csharp
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        });
```

For additional providers, see:

- [Built-in logging providers](#built-in-logging-providers).
- [Third-party logging providers](#third-party-logging-providers).

## Configure a service that depends on ILogger

To configure a service that depends on `ILogger<T>`, use constructor injection or provide a factory method. The factory method approach is recommended only if there is no other option. For example, consider a service that needs an `ILogger<T>` instance provided by DI:

```csharp
.ConfigureServices(services =>
    services.AddSingleton<IExampleService>(container =>
        new DefaultExampleService
        {
            Logger = container.GetRequiredService<ILogger<IExampleService>>()
        }));
```

The preceding code is a [Func<IServiceProvider, IExampleService>](/dotnet/api/system.func-2) that runs the first time the DI container needs to construct an instance of `IExampleService`. You can access any of the registered services in this way.

## Built-in logging providers

Microsoft Extensions include the following logging providers as part of the runtime libraries:

- [Console](#console)
- [Debug](#debug)
- [EventSource](#event-source)
- [EventLog](#windows-eventlog)

The following logging providers are shipped by Microsoft, but not as part of the runtime libraries. They must be installed as additional NuGet packages.

- [AzureAppServicesFile and AzureAppServicesBlob](#azure-app-service)
- [ApplicationInsights](#azure-application-insights)

### Console

The `Console` provider logs output to the console.

### Debug

The `Debug` provider writes log output by using the <xref:System.Diagnostics.Debug?displayProperty=fullName> class, specifically through the <xref:System.Diagnostics.Debug.WriteLine%2A?displayProperty=nameWithType> method. The <xref:Microsoft.Extensions.Logging.Debug.DebugLoggerProvider> creates <xref:Microsoft.Extensions.Logging.Debug.DebugLogger> instances, which are implementations of the `ILogger` interface.

On Linux, the `Debug` provider log location is distribution-dependent and may be one of the following:

- */var/log/message*
- */var/log/syslog*

### Event Source

The `EventSource` provider writes to a cross-platform event source with the name `Microsoft-Extensions-Logging`. On Windows, the provider uses [ETW](/windows/win32/etw/event-tracing-portal).

#### dotnet trace tooling

The [dotnet-trace](../diagnostics/dotnet-trace.md) tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process. The tool collects <xref:Microsoft.Extensions.Logging.EventSource> provider data using a <xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource>.

See [dotnet-trace](../diagnostics/dotnet-trace.md) for installation instructions. For a diagnostic tutorial using `dotnet-trace`, see [Debug high CPU usage in .NET Core](../diagnostics/debug-highcpu.md).

### Windows EventLog

The `EventLog` provider sends log output to the Windows Event Log. Unlike the other providers, the `EventLog` provider does ***not*** inherit the default non-provider settings. If `EventLog` log settings aren't specified, they default to `LogLevel.Warning`.

To log events lower than <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>, explicitly set the log level. The following example sets the Event Log default log level to <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>:

```json
"Logging": {
  "EventLog": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

[AddEventLog overloads](xref:Microsoft.Extensions.Logging.EventLoggerFactoryExtensions) can pass in <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings>. If `null` or not specified, the following default settings are used:

- `LogName`: "Application"
- `SourceName`: ".NET Runtime"
- `MachineName`: The local machine name is used.

The following code changes the `SourceName` from the default value of `".NET Runtime"` to `CustomLogs`:

```csharp
public class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        // Application code should start here.

        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
                logging.AddEventLog(configuration =>
                    configuration.SourceName = "CustomLogs"));
}
```

### Azure App Service

The [Microsoft.Extensions.Logging.AzureAppServices](https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices) provider package writes logs to text files in an Azure App Service app's file system and to [blob storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet#what-is-blob-storage) in an Azure Storage account.

The provider package isn't included in the runtime libraries. To use the provider, add the provider package to the project.

To configure provider settings, use <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureFileLoggerOptions> and <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureBlobLoggerOptions>, as shown in the following example:

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        // Application code should start here.

        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
                logging.AddAzureWebAppDiagnostics())
            .ConfigureServices(services =>
                services.Configure<AzureFileLoggerOptions>(options =>
                {
                    options.FileName = "azure-diagnostics-";
                    options.FileSizeLimit = 50 * 1024;
                    options.RetainedFileCountLimit = 5;
                })
                .Configure<AzureBlobLoggerOptions>(options =>
                {
                    options.BlobName = "log.txt";
                }));
}
```

When deployed to Azure App Service, the app uses the settings in the [App Service logs](/azure/app-service/web-sites-enable-diagnostic-log/#enable-application-logging-windows) section of the **App Service** page of the Azure portal. When the following settings are updated, the changes take effect immediately without requiring a restart or redeployment of the app.

- **Application Logging (Filesystem)**
- **Application Logging (Blob)**

The default location for log files is in the *D:\\home\\LogFiles\\Application* folder, and the default file name is *diagnostics-yyyymmdd.txt*. The default file size limit is 10 MB, and the default maximum number of files retained is 2. The default blob name is *{app-name}{timestamp}/yyyy/mm/dd/hh/{guid}-applicationLog.txt*.

This provider only logs when the project runs in the Azure environment.

#### Azure log streaming

Azure log streaming supports viewing log activity in real-time from:

- The app server
- The web server
- Failed request tracing

To configure Azure log streaming:

- Navigate to the **App Service logs** page from the app's portal page.
- Set **Application Logging (Filesystem)** to **On**.
- Choose the log **Level**. This setting only applies to Azure log streaming.

Navigate to the **Log Stream** page to view logs. The logged messages are logged with the `ILogger` interface.

### Azure Application Insights

The [Microsoft.Extensions.Logging.ApplicationInsights](https://www.nuget.org/packages/Microsoft.Extensions.Logging.ApplicationInsights) provider package writes logs to [Azure Application Insights](/azure/azure-monitor/app/cloudservices). Application Insights is a service that monitors a web app and provides tools for querying and analyzing the telemetry data. If you use this provider, you can query and analyze your logs by using the Application Insights tools.

For more information, see the following resources:

- [Application Insights overview](/azure/application-insights/app-insights-overview)
- [ApplicationInsightsLoggerProvider for .NET Core ILogger logs](/azure/azure-monitor/app/ilogger) - Start here if you want to implement the logging provider without the rest of Application Insights telemetry.
- [Application Insights logging adapters](/azure/azure-monitor/app/asp-net-trace-logs).
- [Install, configure, and initialize the Application Insights SDK](/learn/modules/instrument-web-app-code-with-application-insights) - Interactive tutorial on the Microsoft Learn site.

## Logging provider design considerations

If you plan to develop your own implementation of the <xref:Microsoft.Extensions.Logging.ILoggerProvider> interface and corresponding custom implementation of <xref:Microsoft.Extensions.Logging.ILogger>, consider the following points:

- The <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> method is synchronous.
- The lifetime of log state and objects should *not* be assumed.

An implementation of `ILoggerProvider` will create an `ILogger` via its <xref:Microsoft.Extensions.Logging.ILoggerProvider.CreateLogger%2A?displayProperty=nameWithType> method. If your implementation strives to queue logging messages in a non-blocking manner, the messages should first be materialized or the object state that's used to materialize a log entry should be serialized. Doing so avoids potential exceptions from disposed objects.

For more information, see [Implement a custom logging provider in .NET](custom-logging-provider.md).

## Third-party logging providers

Here are some third-party logging frameworks that work with various .NET workloads:

- [elmah.io](https://elmah.io) ([GitHub repo](https://github.com/elmahio/Elmah.Io.Extensions.Logging))
- [Gelf](https://docs.graylog.org/en/2.3/pages/gelf.html) ([GitHub repo](https://github.com/mattwcole/gelf-extensions-logging))
- [JSNLog](http://jsnlog.com) ([GitHub repo](https://github.com/mperdeck/jsnlog))
- [KissLog.net](https://kisslog.net) ([GitHub repo](https://github.com/catalingavan/KissLog-net))
- [Log4Net](https://logging.apache.org/log4net) ([GitHub repo](https://github.com/apache/logging-log4net))
- [NLog](https://nlog-project.org) ([GitHub repo](https://github.com/NLog/NLog.Extensions.Logging))
- [NReco.Logging](https://github.com/nreco/logging/blob/master/README.md) ([GitHub repo](https://github.com/nreco/logging))
- [Sentry](https://sentry.io/welcome) ([GitHub repo](https://github.com/getsentry/sentry-dotnet))
- [Serilog](https://serilog.net) ([GitHub repo](https://github.com/serilog/serilog-sinks-console))
- [Stackdriver](https://cloud.google.com/dotnet/docs/stackdriver#logging) ([GitHub repo](https://github.com/googleapis/google-cloud-dotnet))

Some third-party frameworks can perform [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

Using a third-party framework is similar to using one of the built-in providers:

1. Add a NuGet package to your project.
1. Call an `ILoggerFactory` or `ILoggingBuilder` extension method provided by the logging framework.

For more information, see each provider's documentation. Third-party logging providers aren't supported by Microsoft.

## See also

- [Logging in .NET](logging.md).
- [Implement a custom logging provider in .NET](custom-logging-provider.md).
- [High-performance logging in .NET](high-performance-logging.md).
