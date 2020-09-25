---
title: Logging providers in .NET
description: Learn how the Logging provider API is used in .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 09/25/2020
---

# Logging providers in .NET

Logging providers persist logs, except for the `Console` provider, which only displays logs as standard output. For example, the Azure Application Insights provider stores logs in Azure Application Insights. Multiple providers can be enabled.

The default .NET Worker app templates:

- Use the [Generic Host](generic-host.md).
- Call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>, which adds the following logging providers:
  - [Console](#console)
  - [Debug](#debug)
  - [EventSource](#event-source)
  - [EventLog](#windows-eventlog): Windows only

:::code language="csharp" source="snippets/configuration/console/Program.cs" highlight="12":::

The preceding code shows the `Program` class created with the .NET Worker app templates. The next several sections provide samples based on the .NET Worker app templates, which use the Generic Host.

To override the default set of logging providers added by `Host.CreateDefaultBuilder`, call `ClearProviders` and add the required logging providers. For example, the following code:

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

Microsoft Extensions include the following logging providers as part of the shared framework:

- [Console](#console)
- [Debug](#debug)
- [EventSource](#event-source)
- [EventLog](#windows-eventlog)

The following logging providers are shipped by Microsoft, but not as part of the shared framework. They must be installed as additional NuGet.

- [AzureAppServicesFile and AzureAppServicesBlob](#azure-app-service)
- [ApplicationInsights](#azure-application-insights)

### Console

The `Console` provider logs output to the console. For more information on viewing `Console` logs in development, see [Logging output from dotnet run and Visual Studio](logging.md#logging-output-from-dotnet-run-and-visual-studio).

### Debug

The `Debug` provider writes log output by using the [System.Diagnostics.Debug](/dotnet/api/system.diagnostics.debug) class. Calls to `System.Diagnostics.Debug.WriteLine` write to the `Debug` provider.

On Linux, the `Debug` provider log location is distribution-dependent and may be one of the following:

- */var/log/message*
- */var/log/syslog*

### Event Source

The `EventSource` provider writes to a cross-platform event source with the name `Microsoft-Extensions-Logging`. On Windows, the provider uses [ETW](/windows/win32/etw/event-tracing-portal).

#### dotnet trace tooling

The [dotnet-trace](../diagnostics/dotnet-trace.md) tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process. The tool collects <xref:Microsoft.Extensions.Logging.EventSource> provider data using a <xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource>.

See [dotnet-trace](../diagnostics/dotnet-trace.md) for installation instructions.

Use the dotnet trace tooling to collect a trace from an app:

1. Run the app with the `dotnet run` command.
1. Determine the process identifier (PID) of the .NET Core app:
   - On Windows, use one of the following approaches:
     - Task Manager (Ctrl+Alt+Del)
     - [tasklist command](/windows-server/administration/windows-commands/tasklist)
     - [Get-Process PowerShell command](/powershell/module/microsoft.powershell.management/get-process)
   - On Linux, use the [pidof command](https://refspecs.linuxfoundation.org/LSB_5.0.0/LSB-Core-generic/LSB-Core-generic/pidof.html).

   Find the PID for the process that has the same name as the app's assembly.

1. Execute the `dotnet trace` command.

   General command syntax:

   ```dotnetcli
   dotnet trace collect -p {PID}
       --providers Microsoft-Extensions-Logging:{Keyword}:{Provider Level}
           :FilterSpecs=\"
               {Logger Category 1}:{Category Level 1};
               {Logger Category 2}:{Category Level 2};
               ...
               {Logger Category N}:{Category Level N}\"
   ```

   When using a PowerShell command shell, enclose the `--providers` value in single quotes (`'`):

   ```dotnetcli
   dotnet trace collect -p {PID}
       --providers 'Microsoft-Extensions-Logging:{Keyword}:{Provider Level}
           :FilterSpecs=\"
               {Logger Category 1}:{Category Level 1};
               {Logger Category 2}:{Category Level 2};
               ...
               {Logger Category N}:{Category Level N}\"'
   ```

   On non-Windows platforms, add the `-f speedscope` option to change the format of the output trace file to `speedscope`.

   The following table defines the Keyword:

   | Keyword | Description                                                                                                                  |
   |---------|------------------------------------------------------------------------------------------------------------------------------|
   | 1       | Log meta events about the `LoggingEventSource`. Doesn't log events from `ILogger`.                                           |
   | 2       | Turns on the `Message` event when `ILogger.Log()` is called. Provides information in a programmatic (not formatted) way.     |
   | 4       | Turns on the `FormatMessage` event when `ILogger.Log()` is called. Provides the formatted string version of the information. |
   | 8       | Turns on the `MessageJson` event when `ILogger.Log()` is called. Provides a JSON representation of the arguments.            |

   The following table lists the provider levels:

   | Provider Level | Description     |
   |----------------|-----------------|
   | 0              | `LogAlways`     |
   | 1              | `Critical`      |
   | 2              | `Error`         |
   | 3              | `Warning`       |
   | 4              | `Informational` |
   | 5              | `Verbose`       |

   The parsing for a category level can be either a string or a number:

   | Category named value | Numeric value |
   |----------------------|---------------|
   | `Trace`              | 0             |
   | `Debug`              | 1             |
   | `Information`        | 2             |
   | `Warning`            | 3             |
   | `Error`              | 4             |
   | `Critical`           | 5             |

   The provider level and category level:

   - Are in reverse order.
   - The string constants aren't all identical.

   If no  are specified, then the `EventSourceLogger` implementation attempts to convert the provider level to a category level and applies it to all categories.

   | Provider Level     | Category Level   |
   |--------------------|------------------|
   | `Verbose`(5)       | `Debug`(1)       |
   | `Informational`(4) | `Information`(2) |
   | `Warning`(3)       | `Warning`(3)     |
   | `Error`(2)         | `Error`(4)       |
   | `Critical`(1)      | `Critical`(5)    |

   If `FilterSpecs` are provided, any category that is included in the list uses the category level encoded there, all other categories are filtered out.

   The following examples assume:

   - An app is running and calling `logger.LogDebug("12345")`.
   - The process ID (PID) has been set via `set PID=12345`, where `12345` is the actual PID.

   Consider the following command:

   ```dotnetcli
   dotnet trace collect -p %PID% --providers Microsoft-Extensions-Logging:4:5
   ```

   The preceding command:

   - Captures debug messages.
   - Doesn't apply a `FilterSpecs`.
   - Specifies level 5, which maps category Debug.

   Consider the following command:

   ```dotnetcli
   dotnet trace collect -p %PID%
   --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:5\"
   ```

   The preceding command:

   - Doesn't capture debug messages because the category level 5 is `Critical`.
   - Provides a `FilterSpecs`.

   The following command captures debug messages because category level 1 specifies `Debug`.

   ```dotnetcli
   dotnet trace collect -p %PID%
   --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:1\"
   ```

   The following command captures debug messages because category specifies `Debug`.

   ```dotnetcli
   dotnet trace collect -p %PID%
   --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:Debug\"
   ```

   `FilterSpecs` entries for `{Logger Category}` and `{Category Level}` represent additional log filtering conditions. Separate `FilterSpecs` entries with the `;` semicolon character.

   Example using a Windows command shell:

   ```dotnetcli
   dotnet trace collect -p %PID%
   --providers Microsoft-Extensions-Logging:4:2:FilterSpecs=\"Microsoft.Extensions.Hosting*:4\"
   ```

   The preceding command activates:

   - The Event Source logger to produce formatted strings (`4`) for errors (`2`).
   - `Microsoft.Extensions.Hosting` logging at the `Informational` logging level (`4`).

1. Stop the dotnet trace tooling by pressing the <kbd>Enter</kbd> key or <kbd>Ctrl</kbd>+<kbd>C</kbd>.

   The trace is saved with the name *trace.nettrace* in the folder where the `dotnet trace` command is executed.

1. Open the trace with PerfView. Open the *trace.nettrace* file and explore the trace events.

If the app doesn't build the host with `CreateDefaultBuilder`, add the Event Source provider to the app's logging configuration.

For more information, see:

- [Trace for performance analysis utility (dotnet-trace)](../diagnostics/dotnet-trace.md)
- [LoggingEventSource class](xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource) (.NET API Browser)
- <xref:System.Diagnostics.Tracing.EventLevel>

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

The following code changes the `SourceName` from the default value of `".NET Runtime"` to `MyLogs`:

```csharp
public class Program
{
    public static Task Main(string[] args) =>
        CreateHostBuilder(args).Build().RunAsync();

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
                logging.AddEventLog(configuration =>
                    configuration.SourceName = "CustomLogs"));
}
```

### Azure App Service

The [Microsoft.Extensions.Logging.AzureAppServices](https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices) provider package writes logs to text files in an Azure App Service app's file system and to [blob storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet#what-is-blob-storage) in an Azure Storage account.

The provider package isn't included in the shared framework. To use the provider, add the provider package to the project.

To configure provider settings, use <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureFileLoggerOptions> and <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureBlobLoggerOptions>, as shown in the following example:

```csharp
class Program
{
    static Task Main(string[] args) =>
        CreateHostBuilder(args).Build().RunAsync();

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

Azure log streaming supports viewing log activity in real time from:

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

## Third-party logging providers

Third-party logging frameworks that work with various .NET workloads:

- [elmah.io](https://elmah.io) ([GitHub repo](https://github.com/elmahio/Elmah.Io.Extensions.Logging))
- [Gelf](https://docs.graylog.org/en/2.3/pages/gelf.html) ([GitHub repo](https://github.com/mattwcole/gelf-extensions-logging))
- [JSNLog](https://jsnlog.com) ([GitHub repo](https://github.com/mperdeck/jsnlog))
- [KissLog.net](https://kisslog.net) ([GitHub repo](https://github.com/catalingavan/KissLog-net))
- [Log4Net](https://logging.apache.org/log4net) ([GitHub repo](https://github.com/apache/logging-log4net))
- [Loggr](https://loggr.net) ([GitHub repo](https://github.com/imobile3/Loggr.Extensions.Logging))
- [NLog](https://nlog-project.org) ([GitHub repo](https://github.com/NLog/NLog.Extensions.Logging))
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
