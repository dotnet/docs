---
title: Build extensions for Microsoft.Testing.Platform
description: Learn how to create in-process and out-of-process extensions for Microsoft.Testing.Platform.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Build extensions

This article covers the extensibility points for Microsoft.Testing.Platform beyond the test framework itself. For test framework creation, see [Build a test framework](./microsoft-testing-platform-architecture-test-framework.md).

For the full extension point summary and in-process/out-of-process concepts, see [Create custom extensions](./microsoft-testing-platform-architecture.md).

## Other extensibility points

The testing platform provides additional extensibility points that allow you to customize the behavior of the platform and the test framework. These extensibility points are optional and can be used to enhance the testing experience.

### The `ICommandLineOptionsProvider` extensions

> [!NOTE]
> When extending this API, the custom extension will exists both in and out of the test host process.

As discussed in the [architecture](./microsoft-testing-platform-architecture.md) section, the initial step involves creating the `ITestApplicationBuilder` to register the testing framework and extensions with it.

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
```

The `CreateBuilderAsync` method accepts an array of strings (`string[]`) named `args`. These arguments can be used to pass command-line options to all components of the testing platform (including built-in components, testing frameworks, and extensions), allowing for customization of their behavior.

Typically, the arguments passed are those received in the standard `Main(string[] args)` method. However, if the hosting environment differs, any list of arguments can be supplied.

Arguments **must be prefixed** with a double dash `--`. For example, `--filter`.

If a component such as a testing framework or an extension point wishes to offer custom command-line options, it can do so by implementing the `ICommandLineOptionsProvider` interface. This implementation can then be registered with the `ITestApplicationBuilder` via the registration factory of the `CommandLine` property, as shown:

```csharp
builder.CommandLine.AddProvider(
    static () => new CustomCommandLineOptions());
```

In the example provided, `CustomCommandLineOptions` is an implementation of the `ICommandLineOptionsProvider` interface, This interface comprises the following members and data types:

```csharp
public interface ICommandLineOptionsProvider : IExtension
{
    IReadOnlyCollection<CommandLineOption> GetCommandLineOptions();

    Task<ValidationResult> ValidateOptionArgumentsAsync(
        CommandLineOption commandOption,
        string[] arguments);

    Task<ValidationResult> ValidateCommandLineOptionsAsync(
        ICommandLineOptions commandLineOptions);
}

public sealed class CommandLineOption
{
    public string Name { get; }
    public string Description { get; }
    public ArgumentArity Arity { get; }
    public bool IsHidden { get; }

    // ...
}

public interface ICommandLineOptions
{
    bool IsOptionSet(string optionName);

    bool TryGetOptionArgumentList(
        string optionName,
        out string[]? arguments);
}
```

As observed, the `ICommandLineOptionsProvider` extends the [`IExtension`](#the-iextension-interface) interface. Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

The order of execution of the `ICommandLineOptionsProvider` is:

<!-- https://mermaid.live/edit#pako:eNq9U1FLAzEM_iuhTxts-wH3MBgqIiiKii-ecKXNZrFNZ9oOxth_N9vdoXjigwP71Cb5viRfmp0y0aKqVML3gmTw3OkV61ATyHnElB2tYO11XkYO0_n86iyGoMleO8LbdXaR0h3HjbPIFVxiHrpH45bsF-RUiL_nqoAxF6YE-RXBu5QhLqEZkDR_K_VJe2d17hwLXpWAlNMibcmMBkAwraV9TSBllmTPL6B74Bg2HSPgBnkLsQX2ASdqoKHpKhbMPabicwOOrDP6iEjFGEwJIsNSO18YZ6fpMoxppfkB3IvzxTSGC0pSxHF2RgwyPvld28MItfefskkPUMilSLP_V0hNVEAO2llZgN0hf62k4IC1quRqNb_Vqqa9xOmS44P0r6rMBSeqrA8idcvSG9G6HPmmXajjXu0_ABqpPds -->
:::image type="content" source="./media/icommandlineoptionsprovider-sequence-diagram.png" lightbox="./media/icommandlineoptionsprovider-sequence-diagram.png" alt-text="A diagram representing the order of execution of the 'ICommandLineOptionsProvider' interface.":::

Let's examine the apis and their mean:

`ICommandLineOptionsProvider.GetCommandLineOptions()`: This method is utilized to retrieve all the options offered by the component. Each `CommandLineOption` requires the following properties to be specified:

`string name`: This is the option's name, presented without a dash. For example, *filter* would be used as `--filter` by users.

`string description`: This is a description of the option. It will be displayed when users pass `--help` as an argument to the application builder.

`ArgumentArity arity`: The arity of an option is the number of values that can be passed if that option or command is specified. Current available arities are:

* `Zero`: Represents an argument arity of zero.
* `ZeroOrOne`: Represents an argument arity of zero or one.
* `ZeroOrMore`: Represents an argument arity of zero or more.
* `OneOrMore`: Represents an argument arity of one or more.
* `ExactlyOne`: Represents an argument arity of exactly one.

For examples, refer to the [System.CommandLine arity table](../../standard/commandline/syntax.md#argument-arity).

`bool isHidden`: This property signifies that the option is available for use but will not be displayed in the description when `--help` is invoked.

`ICommandLineOptionsProvider.ValidateOptionArgumentsAsync`: This method is employed to *validate* the argument provided by the user.

For instance, if you have a parameter named `--dop` that represents the degree of parallelism for our custom testing framework, a user might input `--dop 0`. In this scenario, the value `0` would be invalid because it is expected to have a degree of parallelism of `1` or more. By using `ValidateOptionArgumentsAsync`, you can perform upfront validation and return an error message if necessary.

A possible implementation for the sample above could be:

```csharp
public Task<ValidationResult> ValidateOptionArgumentsAsync(
    CommandLineOption commandOption,
    string[] arguments)
{
    if (commandOption.Name == "dop")
    {
        if (!int.TryParse(arguments[0], out int dopValue) || dopValue <= 0)
        {
            return ValidationResult.InvalidTask("--dop must be a positive integer");
        }
    }

    return ValidationResult.ValidTask;
}
```

`ICommandLineOptionsProvider.ValidateCommandLineOptionsAsync`: This method is called as last one and allows to do global coherency check.

For example, let's say our testing framework has the capability to generate a test result report and save it to a file. This feature is accessed using the `--generatereport` option, and the filename is specified with `--reportfilename myfile.rep`. In this scenario, if a user only provides the `--generatereport` option without specifying a filename, the validation should fail because the report cannot be generated without a filename.
A possible implementation for the sample above could be:

```csharp
public Task<ValidationResult> ValidateCommandLineOptionsAsync(ICommandLineOptions commandLineOptions)
{
    bool generateReportEnabled = commandLineOptions.IsOptionSet(GenerateReportOption);
    bool reportFileName = commandLineOptions.TryGetOptionArgumentList(ReportFilenameOption, out string[]? _);

    return (generateReportEnabled || reportFileName) && !(generateReportEnabled && reportFileName)
        ? ValidationResult.InvalidTask("Both `--generatereport` and `--reportfilename` need to be provided simultaneously.")
        : ValidationResult.ValidTask;
}
```

Please note that the `ValidateCommandLineOptionsAsync` method provides the [`ICommandLineOptions`](./microsoft-testing-platform-architecture-services.md#the-icommandlineoptions-service) service, which is used to fetch the argument information parsed by the platform itself.

### The `ITestSessionLifetimeHandler` extensions

The `ITestSessionLifeTimeHandler` is an *in-process* extension that enables the execution of code *before* and *after* the test session.

To register a custom `ITestSessionLifeTimeHandler`, utilize the following API:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHost.AddTestSessionLifetimeHandle(
    static serviceProvider => new CustomTestSessionLifeTimeHandler());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestSessionLifeTimeHandler` interface includes the following methods:

```csharp
public interface ITestSessionLifetimeHandler : ITestHostExtension
{
    Task OnTestSessionStartingAsync(
        SessionUid sessionUid,
        CancellationToken cancellationToken);

    Task OnTestSessionFinishingAsync(
        SessionUid sessionUid,
        CancellationToken cancellationToken);
}

public readonly struct SessionUid(string value)
{
    public string Value { get; } = value;
}

public interface ITestHostExtension : IExtension
{
}
```

The `ITestSessionLifetimeHandler` is a type of `ITestHostExtension`, which serves as a base for all *test host* extensions. Like all other extension points, it also inherits from [IExtension](#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

Consider the following details for this API:

`OnTestSessionStartingAsync`: This method is invoked prior to the commencement of the test session and receives the `SessionUid` object, which provides an opaque identifier for the current test session.

`OnTestSessionFinishingAsync`: This method is invoked after the completion of the test session, ensuring that the [testing framework](#test-framework-extension) has finished executing all tests and has reported all relevant data to the platform. Typically, in this method, the extension employs the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to transmit custom assets or data to the shared platform bus. This method can also signal to any custom *out-of-process* extension that the test session has concluded.

Finally, both APIs take a `CancellationToken` which the extension is expected to honor.

If your extension requires intensive initialization and you need to use the async/await pattern, you can refer to the [`Async extension initialization and cleanup`](#asynchronous-initialization-and-cleanup-of-extensions). If you need to *share state* between extension points, you can refer to the [`CompositeExtensionFactory<T>`](#the-compositeextensionfactoryt) section.

### The `ITestApplicationLifecycleCallbacks` extensions

The `ITestApplicationLifecycleCallbacks` is an *in-process* extension that enables the execution of code before everything, it's like to have access to the first line of the hypothetical *main* of the *test host*.

To register a custom `ITestApplicationLifecycleCallbacks`, utilize the following api:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHost.AddTestApplicationLifecycleCallbacks(
    static serviceProvider
    => new CustomTestApplicationLifecycleCallbacks());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestApplicationLifecycleCallbacks` interface includes the following methods:

```csharp
public interface ITestApplicationLifecycleCallbacks : ITestHostExtension
{
    Task BeforeRunAsync(CancellationToken cancellationToken);

    Task AfterRunAsync(
        int exitCode,
        CancellationToken cancellation);
}

public interface ITestHostExtension : IExtension
{
}
```

The `ITestApplicationLifecycleCallbacks` is a type of `ITestHostExtension`, which serves as a base for all *test host* extensions. Like all other extension points, it also inherits from [IExtension](#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

`BeforeRunAsync`: This method serves as the initial point of contact for the *test host* and is the first opportunity for an *in-process* extension to execute a feature. It's typically used to establish a connection with any corresponding *out-of-process* extensions if a feature is designed to operate across both environments.

*For example, the built-in hang dump feature is composed of both *in-process* and *out-of-process* extensions, and this method is used to exchange information with the *out-of-process* component of the extension.*

`AfterRunAsync`: This method is the final call before exiting the [`int ITestApplication.RunAsync()`](./microsoft-testing-platform-architecture.md) and it provides the [`exit code`](./microsoft-testing-platform-troubleshooting.md#exit-codes). It should be used solely for cleanup tasks and to notify any corresponding *out-of-process* extension that the *test host* is about to terminate.

Finally, both APIs take a `CancellationToken` which the extension is expected to honor.

### The `IDataConsumer` extensions

The `IDataConsumer` is an *in-process* extension capable of subscribing to and receiving `IData` information that is pushed to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) by the [testing framework](#test-framework-extension) and its extensions.

*This extension point is crucial as it enables developers to gather and process all the information generated during a test session.*

To register a custom `IDataConsumer`, utilize the following api:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHost.AddDataConsumer(
    static serviceProvider => new CustomDataConsumer());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `IDataConsumer` interface includes the following methods:

```csharp
public interface IDataConsumer : ITestHostExtension
{
    Type[] DataTypesConsumed { get; }

    Task ConsumeAsync(
        IDataProducer dataProducer,
        IData value,
        CancellationToken cancellationToken);
}

public interface IData
{
    string DisplayName { get; }
    string? Description { get; }
}
```

The `IDataConsumer` is a type of `ITestHostExtension`, which serves as a base for all *test host* extensions. Like all other extension points, it also inherits from [IExtension](#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

`DataTypesConsumed`: This property returns a list of `Type` that this extension plans to consume. It corresponds to `IDataProducer.DataTypesProduced`. Notably, an `IDataConsumer` can subscribe to multiple types originating from different `IDataProducer` instances without any issues.

`ConsumeAsync`: This method is triggered whenever data of a type to which the current consumer is subscribed is pushed onto the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service). It receives the `IDataProducer` to provide details about the data payload's producer, as well as the `IData` payload itself. As you can see, `IData` is a generic placeholder interface that contains general informative data. The ability to push different types of `IData` implies that the consumer needs to *switch* on the type itself to cast it to the correct type and access the specific information.

A sample implementation of a consumer that wants to elaborate the [`TestNodeUpdateMessage`](#the-testnodeupdatemessage-data) produced by a [testing framework](#test-framework-extension) could be:

```csharp
internal class CustomDataConsumer : IDataConsumer, IOutputDeviceDataProducer
{
    public Type[] DataTypesConsumed => new[] { typeof(TestNodeUpdateMessage) };
    ...
    public Task ConsumeAsync(
        IDataProducer dataProducer,
        IData value,
        CancellationToken cancellationToken)
    {
        var testNodeUpdateMessage = (TestNodeUpdateMessage)value;

        switch (testNodeUpdateMessage.TestNode.Properties.Single<TestNodeStateProperty>())
        {
            case InProgressTestNodeStateProperty _:
                {
                    ...
                    break;
                }
            case PassedTestNodeStateProperty _:
                {
                    ...
                    break;
                }
            case FailedTestNodeStateProperty failedTestNodeStateProperty:
                {
                    ...
                    break;
                }
            case SkippedTestNodeStateProperty _:
                {
                    ...
                    break;
                }
            ...
        }

        return Task.CompletedTask;
    }
...
}
```

Finally, the API takes a `CancellationToken` which the extension is expected to honor.

> [!IMPORTANT]
> It's crucial to process the payload directly within the `ConsumeAsync` method. The [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) can manage both synchronous and asynchronous processing, coordinating the execution with the [testing framework](#test-framework-extension). Although the consumption process is entirely asynchronous and doesn't block the [IMessageBus.Push](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) at the time of writing, this is an implementation detail that may change in the future due to future requirements. However, the platform ensures that this method is always called once, eliminating the need for complex synchronization, as well as managing the scalability of the consumers.

<!-- avoid "No space in block quote" block quotes follow each other -->

> [!WARNING]
> When using `IDataConsumer` in conjunction with [ITestHostProcessLifetimeHandler](#the-itestsessionlifetimehandler-extensions) within a [composite extension point](#the-compositeextensionfactoryt), **it's crucial to disregard any data received post the execution of [ITestSessionLifetimeHandler.OnTestSessionFinishingAsync](#the-itestsessionlifetimehandler-extensions)**. The `OnTestSessionFinishingAsync` is the final opportunity to process accumulated data and transmit new information to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service), hence, any data consumed beyond this point will not be *utilizable* by the extension.

If your extension requires intensive initialization and you need to use the async/await pattern, you can refer to the [`Async extension initialization and cleanup`](#asynchronous-initialization-and-cleanup-of-extensions). If you need to *share state* between extension points, you can refer to the [`CompositeExtensionFactory<T>`](#the-compositeextensionfactoryt) section.

### The `ITestHostEnvironmentVariableProvider` extensions

The `ITestHostEnvironmentVariableProvider` is an *out-of-process* extension that enables you to establish custom environment variables for the test host. Utilizing this extension point ensures that the testing platform will initiate a new host with the appropriate environment variables, as detailed in the [architecture](./microsoft-testing-platform-architecture.md) section.

To register a custom `ITestHostEnvironmentVariableProvider`, utilize the following API:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHostControllers.AddEnvironmentVariableProvider(
    static serviceProvider => new CustomEnvironmentVariableForTestHost());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestHostEnvironmentVariableProvider` interface includes the following methods and types:

```csharp
public interface ITestHostEnvironmentVariableProvider : ITestHostControllersExtension, IExtension
{
    Task UpdateAsync(IEnvironmentVariables environmentVariables);

    Task<ValidationResult> ValidateTestHostEnvironmentVariablesAsync(
        IReadOnlyEnvironmentVariables environmentVariables);
}

public interface IEnvironmentVariables : IReadOnlyEnvironmentVariables
{
    void SetVariable(EnvironmentVariable environmentVariable);
    void RemoveVariable(string variable);
}

public interface IReadOnlyEnvironmentVariables
{
    bool TryGetVariable(
        string variable,
        [NotNullWhen(true)] out OwnedEnvironmentVariable? environmentVariable);
}

public sealed class OwnedEnvironmentVariable : EnvironmentVariable
{
    public IExtension Owner { get; }

    public OwnedEnvironmentVariable(
        IExtension owner,
        string variable,
        string? value,
        bool isSecret,
        bool isLocked);
}

public class EnvironmentVariable
{
    public string Variable { get; }
    public string? Value { get; }
    public bool IsSecret { get; }
    public bool IsLocked { get; }
}
```

The `ITestHostEnvironmentVariableProvider` is a type of `ITestHostControllersExtension`, which serves as a base for all *test host controller* extensions. Like all other extension points, it also inherits from [IExtension](#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

Consider the details for this API:

`UpdateAsync`: This update API provides an instance of the `IEnvironmentVariables` object, from which you can call the `SetVariable` or `RemoveVariable` methods. When using `SetVariable`, you must pass an object of type `EnvironmentVariable`, which requires the following specifications:

* `Variable`: The name of the environment variable.
* `Value`: The value of the environment variable.
* `IsSecret`: This indicates whether the environment variable contains sensitive information that should not be logged or accessible via the `TryGetVariable`.
* `IsLocked`: This determines whether other `ITestHostEnvironmentVariableProvider` extensions can modify this value.

`ValidateTestHostEnvironmentVariablesAsync`: This method is invoked after all the `UpdateAsync` methods of the registered `ITestHostEnvironmentVariableProvider` instances have been called. It allows you to *verify* the correct setup of the environment variables. It takes an object that implements `IReadOnlyEnvironmentVariables`, which provides the `TryGetVariable` method to fetch specific environment variable information with the `OwnedEnvironmentVariable` object type. After validation, you return a `ValidationResult` containing any failure reasons.

> [!NOTE]
> The testing platform, by default, implements and registers the `SystemEnvironmentVariableProvider`. This provider loads all the *current* environment variables. As the first registered provider, it executes first, granting access to the default environment variables for all other `ITestHostEnvironmentVariableProvider` user extensions.

If your extension requires intensive initialization and you need to use the async/await pattern, you can refer to the [`Async extension initialization and cleanup`](#asynchronous-initialization-and-cleanup-of-extensions). If you need to *share state* between extension points, you can refer to the [`CompositeExtensionFactory<T>`](#the-compositeextensionfactoryt) section.

### The `ITestHostProcessLifetimeHandler` extensions

The `ITestHostProcessLifetimeHandler` is an *out-of-process* extension that allows you to observe the test host process from an external standpoint. This ensures that your extension remains unaffected by potential crashes or hangs that could be induced by the code under test. Utilizing this extension point will prompt the testing platform to initiate a new host, as detailed in the [architecture](./microsoft-testing-platform-architecture.md) section.

To register a custom `ITestHostProcessLifetimeHandler`, utilize the following API:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHostControllers.AddProcessLifetimeHandler(
    static serviceProvider => new CustomMonitorTestHost());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestHostProcessLifetimeHandler` interface includes the following methods:

```csharp
public interface ITestHostProcessLifetimeHandler : ITestHostControllersExtension
{
    Task BeforeTestHostProcessStartAsync(CancellationToken cancellationToken);

    Task OnTestHostProcessStartedAsync(
        ITestHostProcessInformation testHostProcessInformation,
        CancellationToken cancellation);

    Task OnTestHostProcessExitedAsync(
        ITestHostProcessInformation testHostProcessInformation,
        CancellationToken cancellation);
}

public interface ITestHostProcessInformation
{
    int PID { get; }
    int ExitCode { get; }
    bool HasExitedGracefully { get; }
}
```

The `ITestHostProcessLifetimeHandler` is a type of `ITestHostControllersExtension`, which serves as a base for all *test host controller* extensions. Like all other extension points, it also inherits from [IExtension](#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

Consider the following details for this API:

`BeforeTestHostProcessStartAsync`: This method is invoked prior to the testing platform initiating the test hosts.

`OnTestHostProcessStartedAsync`: This method is invoked immediately after the test host starts. This method offers an object that implements the `ITestHostProcessInformation` interface, which provides key details about the test host process result.
> [!IMPORTANT]
> The invocation of this method does not halt the test host's execution. If you need to pause it, you should register an [*in-process*](#microsofttestingplatform-extensibility) extension such as [`ITestApplicationLifecycleCallbacks`](#the-itestapplicationlifecyclecallbacks-extensions) and synchronize it with the *out-of-process* extension.

`OnTestHostProcessExitedAsync`: This method is invoked when the test suite execution is complete. This method supplies an object that adheres to the `ITestHostProcessInformation` interface, which conveys crucial details about the outcome of the test host process.

The `ITestHostProcessInformation` interface provides the following details:

* `PID`: The process ID of the test host.
* `ExitCode`: The exit code of the process. This value is only available within the `OnTestHostProcessExitedAsync` method. Attempting to access it within the `OnTestHostProcessStartedAsync` method will result in an exception.
* `HasExitedGracefully`: A boolean value indicating whether the test host has crashed. If true, it signifies that the test host did not exit gracefully.

## Extensions execution order

The testing platform consists of a [testing framework](#test-framework-extension) and any number of extensions that can operate [*in-process*](#microsofttestingplatform-extensibility) or [*out-of-process*](#microsofttestingplatform-extensibility). This document outlines the **sequence of calls** to all potential extensibility points to provide clarity on when a feature is anticipated to be invoked:

1. [ITestHostEnvironmentVariableProvider.UpdateAsync](#the-itesthostenvironmentvariableprovider-extensions) : Out-of-process
1. [ITestHostEnvironmentVariableProvider.ValidateTestHostEnvironmentVariablesAsync](#the-itesthostenvironmentvariableprovider-extensions) : Out-of-process
1. [ITestHostProcessLifetimeHandler.BeforeTestHostProcessStartAsync](#the-itestsessionlifetimehandler-extensions) : Out-of-process
1. Test host process start
1. [ITestHostProcessLifetimeHandler.OnTestHostProcessStartedAsync](#the-itestsessionlifetimehandler-extensions) : Out-of-process, this event can intertwine the actions of *in-process* extensions, depending on race conditions.
1. [ITestApplicationLifecycleCallbacks.BeforeRunAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. [ITestSessionLifetimeHandler.OnTestSessionStartingAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. [ITestFramework.CreateTestSessionAsync](#test-framework-extension): In-process
1. [ITestFramework.ExecuteRequestAsync](#test-framework-extension): In-process, this method can be called one or more times. At this point, the testing framework will transmit information to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) that can be utilized by the [IDataConsumer](#the-idataconsumer-extensions).
1. [ITestFramework.CloseTestSessionAsync](#test-framework-extension): In-process
1. [ITestSessionLifetimeHandler.OnTestSessionFinishingAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. [ITestApplicationLifecycleCallbacks.AfterRunAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. In-process cleanup, involves calling dispose and [IAsyncCleanableExtension](#asynchronous-initialization-and-cleanup-of-extensions) on all extension points.
1. [ITestHostProcessLifetimeHandler.OnTestHostProcessExitedAsync](#the-itestsessionlifetimehandler-extensions) : Out-of-process
1. Out-of-process cleanup, involves calling dispose and [IAsyncCleanableExtension](#asynchronous-initialization-and-cleanup-of-extensions) on all extension points.

## Extensions helpers

The testing platform provides a set of helper classes and interfaces to simplify the implementation of extensions. These helpers are designed to streamline the development process and ensure that the extension adheres to the platform's standards.

### Asynchronous initialization and cleanup of extensions

The creation of the testing framework and extensions through factories adheres to the standard .NET object creation mechanism, which uses synchronous constructors. If an extension requires intensive initialization (such as accessing the file system or network), it cannot employ the *async/await* pattern in the constructor because constructors return void, not `Task`.

Therefore, the testing platform provides a method to initialize an extension using the async/await pattern through a simple interface. For symmetry, it also offers an async interface for cleanup that extensions can implement seamlessly.

```csharp
public interface IAsyncInitializableExtension
{
    Task InitializeAsync();
}

public interface IAsyncCleanableExtension
{
    Task CleanupAsync();
}
```

`IAsyncInitializableExtension.InitializeAsync`: This method is assured to be invoked following the creation factory.

`IAsyncCleanableExtension.CleanupAsync`: This method is assured to be invoked *at least one time* during the termination of the testing session, prior to the default `DisposeAsync` or `Dispose`.

> [!IMPORTANT]
> Similar to the standard `Dispose` method, `CleanupAsync` may be invoked multiple times. If an object's `CleanupAsync` method is called more than once, the object must ignore all calls after the first one. The object must not throw an exception if its `CleanupAsync` method is called multiple times.
> [!NOTE]
> By default, the testing platform will call `DisposeAsync` if it's available, or `Dispose` if it's implemented. It's important to note that the testing platform will not call both dispose methods but will prioritize the async one if implemented.

### The CompositeExtensionFactory<T\>

As outlined in the [extensions](#microsofttestingplatform-extensibility) section, the testing platform enables you to implement interfaces to incorporate custom extensions both in and out of process.

Each interface addresses a particular feature, and according to .NET design, you implement this interface in a specific object. You can register the extension itself using the specific registration API `AddXXX` from the `TestHost` or `TestHostController` object from the `ITestApplicationBuilder` as detailed in the corresponding sections.

However, if you need to *share state* between two extensions, the fact that you can implement and register different objects implementing different interfaces makes sharing a challenging task. Without any assistance, you would need a way to pass one extension to the other to share information, which complicates the design.

Hence, the testing platform provides a sophisticated method to implement multiple extension points using the same type, making data sharing a straightforward task. All you need to do is utilize the `CompositeExtensionFactory<T>`, which can then be registered using the same API as you would for a single interface implementation.

For instance, consider a type that implements both `ITestSessionLifetimeHandler` and `IDataConsumer`. This is a common scenario because you often want to gather information from the [testing framework](#test-framework-extension) and then, when the testing session concludes, you'll dispatch your artifact using the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) within the `ITestSessionLifetimeHandler.OnTestSessionFinishingAsync`.

What you should do is to normally implement the interfaces:

```csharp
internal class CustomExtension : ITestSessionLifetimeHandler, IDataConsumer, ...
{
   ...
}
```

Once you've created the `CompositeExtensionFactory<CustomExtension>` for your type, you can register it with both the `IDataConsumer` and `ITestSessionLifetimeHandler` APIs, which offer an overload for the `CompositeExtensionFactory<T>`:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

var factory = new CompositeExtensionFactory<CustomExtension>(serviceProvider => new CustomExtension());

builder.TestHost.AddTestSessionLifetimeHandle(factory);
builder.TestHost.AddDataConsumer(factory);
```

The factory constructor employs the [IServiceProvider](./microsoft-testing-platform-architecture-services.md) to access the services provided by the testing platform.

The testing platform will be responsible for managing the lifecycle of the composite extension.

It's important to note that due to the testing platform's support for both *in-process* and *out-of-process* extensions, you can't combine any extension point arbitrarily. The creation and utilization of extensions are contingent on the host type, meaning you can only group *in-process* (TestHost) and *out-of-process* (TestHostController) extensions together.

The following combinations are possible:

* For `ITestApplicationBuilder.TestHost`, you can combine `IDataConsumer` and `ITestSessionLifetimeHandler`.
* For `ITestApplicationBuilder.TestHostControllers`, you can combine `ITestHostEnvironmentVariableProvider` and `ITestHostProcessLifetimeHandler`.
