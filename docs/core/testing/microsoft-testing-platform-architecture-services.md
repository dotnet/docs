---
title: Microsoft.Testing.Platform services reference
description: Comprehensive reference for services provided by Microsoft.Testing.Platform, including configuration, logging, message bus, and more.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 11/27/2025
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform services reference

Microsoft.Testing.Platform provides services to test frameworks and extensions through dependency injection. Services handle common needs like configuration, logging, command-line parsing, and inter-component communication.

All services are accessed through `IServiceProvider`, which implements the service locator pattern.

## Access services

Services are provided to your components through factory methods:

```csharp
// In test framework registration
builder.RegisterTestFramework(
    serviceProvider =>
    {
        // Access services here
        var config = serviceProvider.GetConfiguration();
        var logger = serviceProvider.GetLoggerFactory().CreateLogger("MyFramework");
        
        return new MyTestFrameworkCapabilities();
    },
    (capabilities, serviceProvider) =>
    {
        // Or access services here
        return new MyTestFramework(capabilities, serviceProvider);
    });

// In extension registration
builder.TestHost.AddDataConsumer(
    serviceProvider =>
    {
        // Access services in extension factory
        var messageBus = serviceProvider.GetMessageBus();
        var commandLine = serviceProvider.GetCommandLineOptions();
        
        return new MyDataConsumer(messageBus, commandLine);
    });
```

## Service locator APIs

The base `IServiceProvider` interface from .NET BCL:

```csharp
public interface IServiceProvider
{
    object? GetService(Type serviceType);
}
```

Platform extension methods for typed access:

```csharp
public static class ServiceProviderExtensions
{
    // Generic service access
    public static TService GetRequiredService<TService>(this IServiceProvider provider);
    public static TService? GetService<TService>(this IServiceProvider provider);
    
    // Platform-specific services
    public static IMessageBus GetMessageBus(this IServiceProvider provider);
    public static IConfiguration GetConfiguration(this IServiceProvider provider);
    public static ICommandLineOptions GetCommandLineOptions(this IServiceProvider provider);
    public static ILoggerFactory GetLoggerFactory(this IServiceProvider provider);
    public static IOutputDevice GetOutputDevice(this IServiceProvider provider);
    public static IPlatformInformation GetPlatformInformation(this IServiceProvider provider);
}
```

## IConfiguration service

Provides access to configuration settings from JSON files and environment variables.

### Interface

```csharp
public interface IConfiguration
{
    string? this[string key] { get; }
}
```

### Configuration sources

Configuration is loaded in order of precedence (first match wins):

1. **Environment variables** (highest priority)
2. **JSON configuration file**: `[assemblyname].testingplatformconfig.json`

### Access configuration

```csharp
public class MyTestFramework : ITestFramework
{
    private readonly IConfiguration _config;
    
    public MyTestFramework(IServiceProvider serviceProvider)
    {
        _config = serviceProvider.GetConfiguration();
        
        // Read settings
        var timeout = _config["MyFramework:DefaultTimeout"];
        var parallelism = _config["MyFramework:MaxParallelism"];
    }
}
```

### JSON configuration format

Configuration files use hierarchical JSON. Access nested properties with `:` separator:

**File**: `MyTests.testingplatformconfig.json`

```json
{
  "MyTestFramework": {
    "DefaultTimeout": "30s",
    "MaxParallelism": 4,
    "Retry": {
      "Enabled": true,
      "MaxAttempts": 3
    }
  }
}
```

**Access in code**:

```csharp
var timeout = _config["MyTestFramework:DefaultTimeout"];           // "30s"
var parallelism = _config["MyTestFramework:MaxParallelism"];       // "4"
var retryEnabled = _config["MyTestFramework:Retry:Enabled"];       // "true"
var maxAttempts = _config["MyTestFramework:Retry:MaxAttempts"];    // "3"
```

### Array configuration

Arrays use zero-based indices:

```json
{
  "MyFramework": {
    "IncludedCategories": [
      "Unit",
      "Integration",
      "E2E"
    ]
  }
}
```

```csharp
var first = _config["MyFramework:IncludedCategories:0"];   // "Unit"
var second = _config["MyFramework:IncludedCategories:1"];  // "Integration"
```

### Environment variable configuration

Use double underscore `__` instead of `:` for hierarchical keys:

**Windows**:

```cmd
setx MyFramework__DefaultTimeout=60s
setx MyFramework__MaxParallelism=8
```

**Linux/macOS**:

```bash
export MyFramework__DefaultTimeout=60s
export MyFramework__MaxParallelism=8
```

> [!NOTE]
> Double underscore (`__`) is supported on all platforms. Single colon (`:`) doesn't work in environment variable names on some systems.

### Disable environment variable configuration

```csharp
var options = new TestApplicationOptions
{
    Configuration =
    {
        ConfigurationSources =
        {
            RegisterEnvironmentVariablesConfigurationSource = false
        }
    }
};

var builder = await TestApplication.CreateBuilderAsync(args, options);
```

### Best practices

**DO**:

- Use hierarchical naming for settings
- Prefix settings with your framework/extension name
- Document expected configuration keys
- Provide defaults for all settings
- Parse and validate configuration early

**Example**:

```csharp
private readonly TimeSpan _timeout;
private readonly int _maxParallelism;

public MyTestFramework(IServiceProvider serviceProvider)
{
    var config = serviceProvider.GetConfiguration();
    
    // Parse with defaults
    _timeout = TimeSpan.TryParse(
        config["MyFramework:DefaultTimeout"], 
        out var t) ? t : TimeSpan.FromSeconds(30);
    
    _maxParallelism = int.TryParse(
        config["MyFramework:MaxParallelism"], 
        out var p) && p > 0 ? p : Environment.ProcessorCount;
}
```

## The `ICommandLineOptions` service

The `ICommandLineOptions` service is utilized to fetch details regarding the command-line options that the platform has parsed. The APIs available include:

```csharp
public interface ICommandLineOptions
{
    bool IsOptionSet(string optionName);

    bool TryGetOptionArgumentList(
        string optionName, 
        out string[]? arguments);
}
```

The `ICommandLineOptions` can be obtained through certain APIs, such as the [ICommandLineOptionsProvider](./microsoft-testing-platform-architecture-extensions.md#the-icommandlineoptionsprovider-extensions), or you can retrieve an instance of it from the [IServiceProvider](#microsofttestingplatform-services) via the extension method `serviceProvider.GetCommandLineOptions()`.

`ICommandLineOptions.IsOptionSet(string optionName)`: This method allows you to verify whether a specific option has been specified. When specifying the `optionName`, omit the `--` prefix. For example, if the user inputs `--myOption`, you should simply pass `myOption`.

`ICommandLineOptions.TryGetOptionArgumentList(string optionName, out string[]? arguments)`: This method enables you to check whether a specific option has been set and, if so, retrieve the corresponding value or values (if the arity is more than one). Similar to the previous case, the `optionName` should be provided without the `--` prefix.

### The `ILoggerFactory` service

The testing platform comes with an integrated logging system that generates a log file. You can view the logging options by running the `--help` command.
The options you can choose from include:

```dotnetcli
--diagnostic                             Enable the diagnostic logging. The default log level is 'Trace'. The file will be written in the output directory with the name log_[MMddHHssfff].diag
--diagnostic-filelogger-synchronouswrite Force the built-in file logger to write the log synchronously. Useful for scenario where you don't want to lose any log (i.e. in case of crash). Note that this is slowing down the test execution.
--diagnostic-output-directory            Output directory of the diagnostic logging, if not specified the file will be generated inside the default 'TestResults' directory.
--diagnostic-output-fileprefix           Prefix for the log file name that will replace '[log]_.'
--diagnostic-verbosity                   Define the level of the verbosity for the --diagnostic. The available values are 'Trace', 'Debug', 'Information', 'Warning', 'Error', and 'Critical'
```

From a coding standpoint, to log information, you need to obtain the `ILoggerFactory` from the [`IServiceProvider`](#microsofttestingplatform-services).
The `ILoggerFactory` API is as follows:

```csharp
public interface ILoggerFactory
{
    ILogger CreateLogger(string categoryName);
}

public static class LoggerFactoryExtensions
{
    public static ILogger<TCategoryName> CreateLogger<TCategoryName>(this ILoggerFactory factory);
}
```

The logger factory allows you to create an `ILogger` object using the `CreateLogger` API. There's also a convenient API that accepts a generic argument, which will be used as the category name.

```csharp
public interface ILogger
{
    Task LogAsync<TState>(
        LogLevel logLevel, 
        TState state, 
        Exception? exception, 
        Func<TState, Exception?, string> formatter);

    void Log<TState>(
        LogLevel logLevel,
        TState state, 
        Exception? exception, 
        Func<TState, Exception?, string> formatter);

    bool IsEnabled(LogLevel logLevel);
}

public interface ILogger<out TCategoryName> : ILogger
{
}

public static class LoggingExtensions
{
    public static Task LogCriticalAsync(this ILogger logger, string message);
    public static Task LogDebugAsync(this ILogger logger, string message);
    public static Task LogErrorAsync(this ILogger logger, Exception ex);
    public static Task LogErrorAsync(this ILogger logger, string message, Exception ex);
    public static Task LogErrorAsync(this ILogger logger, string message);
    public static Task LogInformationAsync(this ILogger logger, string message);
    public static Task LogTraceAsync(this ILogger logger, string message);
    public static Task LogWarningAsync(this ILogger logger, string message);
    public static void LogCritical(this ILogger logger, string message);
    public static void LogDebug(this ILogger logger, string message);
    public static void LogError(this ILogger logger, Exception ex);
    public static void LogError(this ILogger logger, string message, Exception ex);
    public static void LogError(this ILogger logger, string message);
    public static void LogInformation(this ILogger logger, string message);
    public static void LogTrace(this ILogger logger, string message);
    public static void LogWarning(this ILogger logger, string message);
}
```

The `ILogger` object, which is created by the `ILoggerFactory`, offers APIs for logging information at various levels. These logging levels include:

```csharp
public enum LogLevel
{
    Trace,
    Debug,
    Information,
    Warning,
    Error,
    Critical,
    None,
}
```

Here's an example of how you might use the logging API:

```csharp
...
IServiceProvider provider = null; // Get the service provider...

var factory = provider.GetLoggerFactory();

var logger = factory.CreateLogger<TestingFramework>();

// ...

if (logger.IsEnabled(LogLevel.Information))
{
    await logger.LogInformationAsync(
        $"Executing request of type '{context.Request}'");
}

// ...
```

Keep in mind that to prevent unnecessary allocation, you should check if the level is *enabled* using the `ILogger.IsEnabled(LogLevel)` API.

## The `IMessageBus` service

The message bus service is the central mechanism that facilitates information exchange between the test framework and its extensions.

The message bus of the testing platform employs the _publish-subscribe pattern_.

The overarching structure of the shared bus is as follows:

:::image type="content" source="./media/message-bus.png" lightbox="./media/message-bus.png" alt-text="A picture representing the interactions of the various extensions with the message bus.":::

As illustrated in the diagram, which includes an extensions and a test framework, there are two potential actions: pushing information to the bus or consuming information from the bus.

The `IMessageBus` satisfied the *pushing action* to the bus and the API is:

```csharp
public interface IMessageBus
{
    Task PublishAsync(
        IDataProducer dataProducer, 
        IData data);
}

public interface IDataProducer : IExtension
{
    Type[] DataTypesProduced { get; }
}

public interface IData
{
    string DisplayName { get; }
    string? Description { get; }
}
```

Consider the following details about the parameters:

* `IDataProducer`: The `IDataProducer` communicates to the message bus the `Type` of information it can supply and establishes ownership through inheritance from the base interface [IExtension](./microsoft-testing-platform-architecture-extensions.md#the-iextension-interface). This implies that you can't indiscriminately push data to the message bus; you must declare the data type produced in advance. If you push unexpected data, an exception will be triggered.

* `IData`: This interface serves as a placeholder where you only need to provide descriptive details such as the name and a description. The interface doesn't reveal much about the data's nature, which is intentional. It implies that the test framework and extensions can push any type of data to the bus, and this data can be consumed by any registered extension or the test framework itself.

This approach facilitates the evolution of the information exchange process, preventing breaking changes when an extension is unfamiliar with new data. **It allows different versions of extensions and the test framework to operate in harmony, based on their mutual understanding**.

The opposite end of the bus is referred to as a [consumer](./microsoft-testing-platform-architecture-extensions.md#the-idataconsumer-extensions), which is subscribed to a specific type of data and can thus consume it.

> [!IMPORTANT]
> Always use *await* the call to `PublishAsync`. If you don't, the `IData` might not be processed correctly by the testing platform and extensions, which could lead to subtle bugs. It's only after you've returned from the *await* that you can be assured that the `IData` has been queued for processing on the message bus. Regardless of the extension point you're working on, ensure that you've awaited all `PublishAsync` calls before exiting the extension. For example, if you're implementing the [`testing framework`](./microsoft-testing-platform-architecture-extensions.md#create-a-testing-framework), you should not call `Complete` on the [requests](./microsoft-testing-platform-architecture-extensions.md#handling-requests) until you've awaited all `PublishAsync` calls for that specific request.

## The `IOutputDevice` service

The testing platform encapsulates the idea of an *output device*, allowing the testing framework and extensions to *present* information by transmitting any kind of data to the currently utilized display system.

The most traditional example of an *output device* is the console output.

> [!NOTE]
> While the testing platform is engineered to support custom *output devices*, currently, this extension point is not available.

To transmit data to the *output device*, you must obtain the `IOutputDevice` from the [`IServiceProvider`](#microsofttestingplatform-services).

The API consists of:

```csharp
public interface IOutputDevice
{
    Task DisplayAsync(
        IOutputDeviceDataProducer producer, 
        IOutputDeviceData data);
}

public interface IOutputDeviceDataProducer : IExtension
{
}

public interface IOutputDeviceData
{
}
```

The `IOutputDeviceDataProducer` extends the [`IExtension`](./microsoft-testing-platform-architecture-extensions.md#the-iextension-interface) and provides information about the sender to the *output device*.

The `IOutputDeviceData` serves as a placeholder interface. The concept behind `IOutputDevice` is to accommodate more intricate information than just colored text. For instance, it could be a complex object that can be graphically represented.

The testing platform, by default, offers a traditional colored text model for the `IOutputDeviceData` object:

```csharp
public class TextOutputDeviceData : IOutputDeviceData
{
    public TextOutputDeviceData(string text)
    public string Text { get; }
}

public sealed class FormattedTextOutputDeviceData : TextOutputDeviceData
{
    public FormattedTextOutputDeviceData(string text)
    public IColor? ForegroundColor { get; init; }
    public IColor? BackgroundColor { get; init; }
}

public sealed class SystemConsoleColor : IColor
{
    public ConsoleColor ConsoleColor { get; init; }
}
```

Here's an example of how you might use the colored text with the *active* output device:

```csharp
IServiceProvider provider = null; // Get the service provider...

var outputDevice = provider.GetOutputDevice();

await outputDevice.DisplayAsync(
    this, 
    new FormattedTextOutputDeviceData($"TestingFramework version '{Version}' running tests with parallelism of {_dopValue}")
    {
        ForegroundColor = new SystemConsoleColor
        {
            ConsoleColor = ConsoleColor.Green
        }
    });
```

Beyond the standard use of colored text, the main advantage of `IOutputDevice` and `IOutputDeviceData` is that the *output device* is entirely independent and unknown to the user. This allows for the development of complex user interfaces. For example, it's entirely feasible to implement a *real-time* web application that displays the progress of tests.

## The `IPlatformInformation` service

Provides information about the platform such as: name, version, commit hash and build date.
