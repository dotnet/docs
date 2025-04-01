---
title: Microsoft.Testing.Platform services overview
description: Learn about the Microsoft.Testing.Platform available services.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 07/11/2024
---

# Microsoft.Testing.Platform Services

The testing platform offers valuable services to both the testing framework and extension points. These services cater to common needs such as accessing the configuration, parsing and retrieving command-line arguments, obtaining the logging factory, and accessing the logging system, among others. `IServiceProvider` implements the _service locator pattern_ for the testing platform.

The `IServiceProvider` is derived directly from the base class library.

```csharp
namespace System
{
    public interface IServiceProvider
    {
        object? GetService(Type serviceType);
    }
}
```

The testing platform offers handy extension methods to access well-known service objects. All these methods are housed in a static class within the `Microsoft.Testing.Platform.Services` namespace.

```csharp
public static class ServiceProviderExtensions
{
    public static TService GetRequiredService<TService>(
        this IServiceProvider provider)

    public static TService? GetService<TService>(
        this IServiceProvider provider)

    public static IMessageBus GetMessageBus(
        this IServiceProvider serviceProvider)

    public static IConfiguration GetConfiguration(
        this IServiceProvider serviceProvider)

    public static ICommandLineOptions GetCommandLineOptions(
        this IServiceProvider serviceProvider)

    public static ILoggerFactory GetLoggerFactory(
        this IServiceProvider serviceProvider)

    public static IOutputDevice GetOutputDevice(
        this IServiceProvider serviceProvider)

    // ... and more
}
```

Most of the registration factories exposed by extension points provide access to the `IServiceProvider`: For example, when [registering the testing framework](./microsoft-testing-platform-architecture-extensions.md#register-a-testing-framework), the `IServiceProvider` is passed as a parameter to the factory method.

```csharp
ITestApplicationBuilder RegisterTestFramework(
    Func<IServiceProvider, ITestFrameworkCapabilities> capabilitiesFactory,
    Func<ITestFrameworkCapabilities, IServiceProvider, ITestFramework> adapterFactory);
```

In the preceding code, both the `capabilitiesFactory` and the `adapterFactory` supply the `IServiceProvider` as a parameter.

## The `IConfiguration` service

The `IConfiguration` interface can be retrieved using the [`IServiceProvider`](#microsofttestingplatform-services) and provides access to the configuration settings for the testing framework and any extension points. By default, these configurations are loaded from:

* Environment variables
* A JSON file named `[assemblyName].testingplatformconfig.json` located near the entry point assembly.

**The order of precedence is maintained, which means that if a configuration is found in the environment variables, the JSON file will not be processed.**

The interface is a straightforward key-value pair of strings:

```csharp
public interface IConfiguration
{
    string? this[string key] { get; }
}
```

### JSON configuration file

The JSON file follows a hierarchical structure. To access child properties, you need to use the `:` separator. For example, consider a configuration for a potential testing framework like:

```json
{
  "CustomTestingFramework": {
    "DisableParallelism": true
  }
}
```

The code snippet would look something like this:

```csharp
IServiceProvider serviceProvider = null; // Get the service provider...

var configuration = serviceProvider.GetConfiguration();

if (bool.TryParse(configuration["CustomTestingFramework:DisableParallelism"], out var value) && value is true)
{
    // ...
}
```

In the case of an array, such as:

```json
{
  "CustomTestingFramework": {
    "Engine": [
      "ThreadPool",
      "CustomThread"
    ]
  }
}
```

The syntax to access to the fist element ("ThreadPool") is:

```csharp
IServiceProvider serviceProvider = null; // Get the service provider...

var configuration = serviceProvider.GetConfiguration();

var fistElement = configuration["CustomTestingFramework:Engine:0"];
```

### Environment variables

The `:` separator doesn't work with environment variable hierarchical keys on all platforms. `__`, the double underscore, is:

* Supported by all platforms. For example, the `:` separator is not supported by [Bash](https://linuxhint.com/bash-environment-variables/), but `__` is.
* Automatically replaced by a `:`

For instance, the environment variable can be set as follows (This example is applicable for Windows):

```bash
setx CustomTestingFramework__DisableParallelism=True
```

You can choose not to use the environment variable configuration source when creating the `ITestApplicationBuilder`:

```csharp
var options = new TestApplicationOptions();

options.Configuration.ConfigurationSources.RegisterEnvironmentVariablesConfigurationSource = false;

var builder = await TestApplication.CreateBuilderAsync(args, options);
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
