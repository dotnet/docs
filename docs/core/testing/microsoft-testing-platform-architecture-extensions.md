---
title: Build extensions for Microsoft.Testing.Platform (MTP)
description: Learn how to create in-process and out-of-process extensions for Microsoft.Testing.Platform (MTP).
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 07/17/2026
ai-usage: ai-assisted
---

# Build extensions for Microsoft.Testing.Platform (MTP)

This article covers the extensibility points for MTP beyond the test framework itself. For test framework creation, see [Build a test framework](./microsoft-testing-platform-architecture-test-framework.md).

For the full extension point summary and in-process/out-of-process concepts, see [Create custom extensions](./microsoft-testing-platform-architecture.md).

## Extensibility points

The testing platform provides additional extensibility points that allow you to customize the behavior of the platform and the test framework. These extensibility points are optional and can be used to enhance the testing experience.

> [!TIP]
> Each extension shown in this article includes a manual registration snippet (for example, `builder.TestHost.AddDataConsumer(...)`). If you're shipping your extension as a NuGet package, you can let consumers skip the manual call by exposing a `TestingPlatformBuilderHook` and a small MSBuild props file. The auto-generated entry point will then invoke your hook automatically. For details, see [Auto-register your extension with `TestingPlatformBuilderHook`](#auto-register-your-extension-with-testingplatformbuilderhook).

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

As observed, the `ICommandLineOptionsProvider` extends the [`IExtension`](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface) interface. Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

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

The `ITestSessionLifetimeHandler` is an *in-process* extension that enables the execution of code *before* and *after* the test session.

To register a custom `ITestSessionLifetimeHandler`, utilize the following API:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHost.AddTestSessionLifetimeHandle(
    static serviceProvider => new CustomTestSessionLifetimeHandler());
```

The factory utilizes the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to gain access to the suite of services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestSessionLifetimeHandler` interface includes the following methods:

```csharp
public interface ITestSessionLifetimeHandler : ITestHostExtension
{
    Task OnTestSessionStartingAsync(ITestSessionContext testSessionContext);

    Task OnTestSessionFinishingAsync(ITestSessionContext testSessionContext);
}

public interface ITestSessionContext
{
    SessionUid SessionUid { get; }

    CancellationToken CancellationToken { get; }
}

public readonly struct SessionUid(string value)
{
    public string Value { get; } = value;
}

public interface ITestHostExtension : IExtension
{
}
```

> [!IMPORTANT]
> In MTP 2.0.0, both methods changed to take a single `ITestSessionContext` parameter that exposes the `SessionUid` and the `CancellationToken`. In MTP 1.x, each method took a separate `SessionUid` and `CancellationToken` argument. For more information, see [Migrate from Microsoft.Testing.Platform (MTP) v1 to v2](microsoft-testing-platform-migration-from-v1-to-v2.md#api-signature-changes).

The `ITestSessionLifetimeHandler` is a type of `ITestHostExtension`, which serves as a base for all *test host* extensions. Like all other extension points, it also inherits from [IExtension](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

Consider the following details for this API:

`OnTestSessionStartingAsync`: This method is invoked prior to the commencement of the test session and receives the `ITestSessionContext`, whose `SessionUid` provides an opaque identifier for the current test session.

`OnTestSessionFinishingAsync`: This method is invoked after the completion of the test session, ensuring that the [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) has finished executing all tests and has reported all relevant data to the platform. Typically, in this method, the extension employs the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to transmit custom assets or data to the shared platform bus. This method can also signal to any custom *out-of-process* extension that the test session has concluded.

Finally, the `ITestSessionContext` exposes a `CancellationToken` which the extension is expected to honor.

If your extension requires intensive initialization and you need to use the async/await pattern, you can refer to the [`Async extension initialization and cleanup`](#asynchronous-initialization-and-cleanup-of-extensions). If you need to *share state* between extension points, you can refer to the [`CompositeExtensionFactory<T>`](#the-compositeextensionfactoryt) section.

### The `ITestApplicationLifecycleCallbacks` extensions

> [!IMPORTANT]
> `ITestApplicationLifecycleCallbacks` was removed in MTP 2.0.0. Use `ITestHostApplicationLifetime` instead. For more information, see [Migrate from Microsoft.Testing.Platform (MTP) v1 to v2](microsoft-testing-platform-migration-from-v1-to-v2.md#removed-obsolete-types).

The `ITestHostApplicationLifetime` interface lets an *in-process* extension run code at the start and end of the *test host*.

To register a custom `ITestHostApplicationLifetime`, use the following API:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// ...

builder.TestHost.AddTestHostApplicationLifetime(
    static serviceProvider
    => new CustomTestHostApplicationLifetime());
```

The factory uses the [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to access the services offered by the testing platform.

> [!IMPORTANT]
> The sequence of registration is significant, as the APIs are called in the order they were registered.

The `ITestHostApplicationLifetime` interface includes the following methods:

```csharp
public interface ITestHostApplicationLifetime : ITestHostExtension
{
    Task BeforeRunAsync(CancellationToken cancellationToken);

    Task AfterRunAsync(
        int exitCode,
        CancellationToken cancellationToken);
}

public interface ITestHostExtension : IExtension
{
}
```

The `ITestHostApplicationLifetime` interface extends `ITestHostExtension`, which serves as a base for all *test host* extensions. Like all other extension points, it also inherits from [IExtension](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

`BeforeRunAsync`: This method serves as the initial point of contact for the *test host* and is the first opportunity for an *in-process* extension to execute a feature. It's typically used to establish a connection with any corresponding *out-of-process* extensions if a feature is designed to operate across both environments.

*For example, the built-in hang dump feature is composed of both *in-process* and *out-of-process* extensions, and this method is used to exchange information with the *out-of-process* component of the extension.*

`AfterRunAsync`: This method is the final call before exiting the [`int ITestApplication.RunAsync()`](./microsoft-testing-platform-architecture.md) and it provides the [`exit code`](./microsoft-testing-platform-troubleshooting.md#exit-codes). It should be used solely for cleanup tasks and to notify any corresponding *out-of-process* extension that the *test host* is about to terminate.

Finally, both APIs take a `CancellationToken` which the extension is expected to honor.

### The `IDataConsumer` extensions

The `IDataConsumer` is an *in-process* extension capable of subscribing to and receiving `IData` information that is published to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) by the [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) and its extensions.

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
public interface IDataConsumer : IExtension
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

> [!IMPORTANT]
> In MTP 2.0.0, `IDataConsumer` moved to the `Microsoft.Testing.Platform.Extensions` namespace and now extends [`IExtension`](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface) directly. In MTP 1.x, it extended `ITestHostExtension`. You still register it with `builder.TestHost.AddDataConsumer(...)`. For more information, see [Migrate from Microsoft.Testing.Platform (MTP) v1 to v2](microsoft-testing-platform-migration-from-v1-to-v2.md#api-signature-changes).

The `IDataConsumer` inherits from [IExtension](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

`DataTypesConsumed`: This property returns a list of `Type` that this extension plans to consume. It corresponds to `IDataProducer.DataTypesProduced`. Notably, an `IDataConsumer` can subscribe to multiple types originating from different `IDataProducer` instances without any issues.

`ConsumeAsync`: This method is triggered whenever data of a type to which the current consumer is subscribed is published to the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service). It receives the `IDataProducer` to provide details about the data payload's producer, as well as the `IData` payload itself. As you can see, `IData` is a generic placeholder interface that contains general informative data. The ability to publish different types of `IData` implies that the consumer needs to *switch* on the type itself to cast it to the correct type and access the specific information.

A sample implementation of a consumer that wants to elaborate the [`TestNodeUpdateMessage`](./microsoft-testing-platform-architecture-test-framework.md#the-testnodeupdatemessage-data) produced by a [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) could be:

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
> Process the payload directly within the `ConsumeAsync` method. A regular `IDataConsumer` consumes data asynchronously: the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) queues each published payload and processes it on a background loop, so `IMessageBus.PublishAsync` doesn't block the producer, and there's no guarantee about when `ConsumeAsync` runs relative to the producer continuing its work. The platform serializes delivery so that only one payload is processed at a time per consumer, which eliminates the need for complex synchronization within a single consumer.

<!-- avoid "No space in block quote" block quotes follow each other -->

> [!NOTE]
> For scenarios that need a guarantee that consumption happens before the producer proceeds (for example, before a test starts running), MTP 2.3.0 introduced the experimental `IBlockingDataConsumer` marker interface (requires the `TPEXP` diagnostic to be suppressed). A consumer that also implements `IBlockingDataConsumer` is invoked *inline* by the message bus: calls are serialized, `PublishAsync` blocks until `ConsumeAsync` completes, and any exception thrown by `ConsumeAsync` propagates back to the producer that published the data. The message bus skips delivering a producer's data back to that same producer (same UID), so publishing under your own UID is safe. However, a blocking consumer must not, from within `ConsumeAsync`, publish data that is routed back to itself under a *different* producer UID, because that reentrancy would deadlock.

<!-- avoid "No space in block quote" block quotes follow each other -->

> [!WARNING]
> When using `IDataConsumer` in conjunction with [ITestSessionLifetimeHandler](#the-itestsessionlifetimehandler-extensions) within a [composite extension point](#the-compositeextensionfactoryt), **it's crucial to disregard any data received post the execution of [ITestSessionLifetimeHandler.OnTestSessionFinishingAsync](#the-itestsessionlifetimehandler-extensions)**. The `OnTestSessionFinishingAsync` is the final opportunity to process accumulated data and transmit new information to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service), hence, any data consumed beyond this point will not be *utilizable* by the extension.

If your extension requires intensive initialization and you need to use the async/await pattern, you can refer to the [`Async extension initialization and cleanup`](#asynchronous-initialization-and-cleanup-of-extensions). If you need to *share state* between extension points, you can refer to the [`CompositeExtensionFactory<T>`](#the-compositeextensionfactoryt) section.

### Message bus file artifacts

A custom `IData` payload has no automatic UI or command-line output. The platform only surfaces data for which a matching consumer is registered, so if you publish your own `IData` type and nothing consumes it, nothing is printed or forwarded. To make files that your extension produces visible to users and tooling, publish one of the built-in file artifact messages, which the built-in *terminal* and *dotnet test* consumers already recognize.

For run-level or session-level files, publish a `FileArtifact` or a `SessionFileArtifact`. Both were introduced in MTP 1.0.0 and live in the `Microsoft.Testing.Platform.Extensions.Messages` namespace:

- `FileArtifact` is unscoped. Use it for a file that isn't tied to a specific test session.
- `SessionFileArtifact` is scoped to a run/session through its `SessionUid`. Use it for artifacts produced for the run as a whole, such as coverage results, reports, dumps, or recorded videos.

The built-in terminal and `dotnet test` consumers pick up both types and print or forward the file paths, so the files become discoverable in the console output and across the `dotnet test` pipe. Because consumers control the ultimate presentation, keep each file on disk and available for as long as it might be consumed or forwarded; don't delete it inside the same `PublishAsync` call.

The artifact object itself carries no producer identity. The message bus supplies the originating `IDataProducer` to each consumer through the `dataProducer` argument of `IDataConsumer.ConsumeAsync`, so consumers learn who produced a file from that argument, not from the artifact. The message bus also doesn't take ownership of, move, or delete the referenced file: the producer owns the file's lifetime, and consumers only receive, read, or forward its path.

> [!NOTE]
> Third-party `IDataConsumer` registration is public only on `builder.TestHost` (the *in-process* test host). There's no public `builder.TestHostControllers.AddDataConsumer` API for *out-of-process* consumers. The first-party report extensions that display artifacts use internal platform integration that custom extensions can't rely on. To surface files from your own extension, publish the built-in artifact messages described here and let the built-in consumers present them.

A producer that publishes a session artifact must implement `IDataProducer` and list the exact runtime message types it publishes in `DataTypesProduced`. The following example publishes a coverage report when the session finishes:

```csharp
internal sealed class CoverageReportProducer(IMessageBus messageBus)
    : IDataProducer, ITestSessionLifetimeHandler
{
    public string Uid => nameof(CoverageReportProducer);
    public string Version => "1.0.0";
    public string DisplayName => "Coverage report producer";
    public string Description => "Publishes the coverage report as a session artifact.";

    // List the exact runtime message types this producer publishes.
    public Type[] DataTypesProduced => new[] { typeof(SessionFileArtifact) };

    public Task<bool> IsEnabledAsync() => Task.FromResult(true);

    public Task OnTestSessionStartingAsync(ITestSessionContext context)
        => Task.CompletedTask;

    public Task OnTestSessionFinishingAsync(ITestSessionContext context)
    {
        var report = new FileInfo("coverage.cobertura.xml");
        return messageBus.PublishAsync(
            this,
            new SessionFileArtifact(
                context.SessionUid,
                report,
                "Code coverage",
                "Cobertura coverage report for the run."));
    }
}
```

To attach a file to a *specific test* so that the terminal, `dotnet test`, and IDEs associate and display it with that test, don't publish a stand-alone file artifact. Instead, add one or more `FileArtifactProperty` entries to the `TestNode` that your [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) reports through a [`TestNodeUpdateMessage`](./microsoft-testing-platform-architecture-test-framework.md#the-testnodeupdatemessage-data). `FileArtifactProperty` was introduced in MTP 1.7.0:

```csharp
var testNode = new TestNode
{
    Uid = testUid,
    DisplayName = testDisplayName,
    Properties = new PropertyBag(
        PassedTestNodeStateProperty.CachedInstance,
        new FileArtifactProperty(
            new FileInfo("screenshot.png"),
            "Failure screenshot",
            "Screenshot captured while the test ran.")),
};

await messageBus.PublishAsync(
    dataProducer,
    new TestNodeUpdateMessage(sessionUid, testNode));
```

> [!IMPORTANT]
> `TestNodeFileArtifact` is obsolete and was removed in MTP 2.0.0. Use `FileArtifactProperty` on the `TestNode` to attach test-level files. For more information, see [Migrate from Microsoft.Testing.Platform (MTP) v1 to v2](microsoft-testing-platform-migration-from-v1-to-v2.md#removed-obsolete-types).

> [!NOTE]
> MTP 2.4.0 (unreleased as of July 2026) adds an experimental `kind` constructor overload and `Kind` property to `FileArtifact` and `SessionFileArtifact` (requires the `TPEXP` diagnostic to be suppressed). `Kind` is a producer-asserted, reverse-DNS identifier of the artifact *format* (for example, `microsoft.testing.trx`, `microsoft.testing.junit`, `microsoft.testing.ctrf`, or `microsoft.testing.html`) that post-processing can use to group artifacts of the same format for consolidation. Leave it `null` or omit it when the producer doesn't declare a known kind. At this time, `Kind` is only a metadata contract; don't assume broad merge orchestration beyond that.
>
> ```csharp
> #pragma warning disable TPEXP // Experimental API.
> new SessionFileArtifact(
>     context.SessionUid,
>     trxFile,
>     "TRX report",
>     "Test results in TRX format.",
>     kind: "microsoft.testing.trx");
> #pragma warning restore TPEXP
> ```

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

The `ITestHostEnvironmentVariableProvider` is a type of `ITestHostControllersExtension`, which serves as a base for all *test host controller* extensions. Like all other extension points, it also inherits from [IExtension](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

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

The `ITestHostProcessLifetimeHandler` is a type of `ITestHostControllersExtension`, which serves as a base for all *test host controller* extensions. Like all other extension points, it also inherits from [IExtension](./microsoft-testing-platform-architecture-test-framework.md#the-iextension-interface). Therefore, like any other extension, you can choose to enable or disable it using the `IExtension.IsEnabledAsync` API.

Consider the following details for this API:

`BeforeTestHostProcessStartAsync`: This method is invoked prior to the testing platform initiating the test hosts.

`OnTestHostProcessStartedAsync`: This method is invoked immediately after the test host starts. This method offers an object that implements the `ITestHostProcessInformation` interface, which provides key details about the test host process result.
> [!IMPORTANT]
> The invocation of this method does not halt the test host's execution. If you need to pause it, you should register an [*in-process*](./microsoft-testing-platform-architecture.md#in-process-vs-out-of-process-extensions) extension such as [`ITestHostApplicationLifetime`](#the-itestapplicationlifecyclecallbacks-extensions) and synchronize it with the *out-of-process* extension.

`OnTestHostProcessExitedAsync`: This method is invoked when the test suite execution is complete. This method supplies an object that adheres to the `ITestHostProcessInformation` interface, which conveys crucial details about the outcome of the test host process.

The `ITestHostProcessInformation` interface provides the following details:

* `PID`: The process ID of the test host.
* `ExitCode`: The exit code of the process. This value is only available within the `OnTestHostProcessExitedAsync` method. Attempting to access it within the `OnTestHostProcessStartedAsync` method will result in an exception.
* `HasExitedGracefully`: A boolean value indicating whether the test host has crashed. If true, it signifies that the test host did not exit gracefully.

## Auto-register your extension with `TestingPlatformBuilderHook`

Every preceding extension section shows a *manual* registration call (for example, `builder.TestHost.AddDataConsumer(...)`). Asking consumers to edit their `Main` method is a poor onboarding experience. The [`Microsoft.Testing.Platform.MSBuild`](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) package solves this by generating a `SelfRegisteredExtensions.AddSelfRegisteredExtensions(builder, args)` method that runs from the autogenerated entry point. To plug your extension into that generated method, ship two artifacts in your NuGet package:

- A public static `TestingPlatformBuilderHook` class with an `AddExtensions` method that registers your extension.
- An MSBuild props file that declares a `<TestingPlatformBuilderHook>` item pointing at that class.

When a consumer installs your package, the MSBuild integration picks up the item and generates the call into your hook, and your extension is registered with no code changes on the consumer side.

> [!NOTE]
> Auto-registration only works when the consumer has `Microsoft.Testing.Platform.MSBuild` in their project (it's included transitively by MSTest, NUnit, and xUnit runners) and hasn't opted out by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`. Consumers who disable the autogenerated entry point still need to call your manual registration API from their `Main` method.

### Create the hook class

Add a `public static class TestingPlatformBuilderHook` in your extension assembly with an `AddExtensions(ITestApplicationBuilder, string[])` method that performs the same registration users would otherwise call manually:

```csharp
using Microsoft.Testing.Platform.Builder;

namespace Contoso.MyExtension;

public static class TestingPlatformBuilderHook
{
    public static void AddExtensions(ITestApplicationBuilder testApplicationBuilder, string[] arguments)
        => testApplicationBuilder.AddMyExtension();
}
```

The class name doesn't have to be `TestingPlatformBuilderHook` — the MSBuild item points at it by full type name — but using that name keeps your code consistent with the in-box extensions like `Microsoft.Testing.Extensions.Retry` and `Microsoft.Testing.Extensions.HotReload`.

The method must:

* Be `public static`.
* Have a first parameter of type `Microsoft.Testing.Platform.Builder.ITestApplicationBuilder`.
* Have a second parameter of type `string[]` (the command-line arguments passed to the test host). You can ignore it if your extension doesn't need it.
* Return `void`.

### Declare the MSBuild item

Ship a props file under `buildMultiTargeting/<PackageId>.props` inside your NuGet package. Declare a `<TestingPlatformBuilderHook>` item that points the MSBuild task at your hook class:

```xml
<Project>
  <ItemGroup>
    <TestingPlatformBuilderHook Include="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">
      <DisplayName>Contoso.MyExtension</DisplayName>
      <TypeFullName>Contoso.MyExtension.TestingPlatformBuilderHook</TypeFullName>
    </TestingPlatformBuilderHook>
  </ItemGroup>
</Project>
```

The metadata is as follows:

* `Include`: A GUID that uniquely identifies your hook. See [The `Include` GUID is a random identifier](#the-include-guid-is-a-random-identifier).
* `DisplayName`: The friendly name shown in MSBuild diagnostic messages when the entry point is generated. Use your package or extension name.
* `TypeFullName`: The fully qualified name of the `TestingPlatformBuilderHook` class you created previously. The MSBuild task uses this to emit `global::Contoso.MyExtension.TestingPlatformBuilderHook.AddExtensions(builder, args);` into the generated entry point.

### The `Include` GUID is a random identifier

The GUID in the `Include` attribute is **not** the same as your extension's [`IExtension.Uid`](./microsoft-testing-platform-architecture.md#the-iextension-interface). It's a registration identifier used by the MSBuild task to deduplicate hooks across NuGet references and (in a few well-known cases) to order them.

When you author a new extension, generate a brand new GUID and hard-code it in your props file. Some ways to generate one:

* PowerShell: `[guid]::NewGuid()`
* Visual Studio: **Tools** > **Create GUID**
* `uuidgen` on Linux and macOS

> [!IMPORTANT]
> Never copy a GUID from another extension's props file (whether shipped by Microsoft or by a third party). Two extensions that share the same `Include` value are treated as duplicates: only one hook is invoked, so your extension silently fails to register.

> [!NOTE]
> Once you ship a GUID, treat it as permanent. Changing it in a later release is harmless on its own, but reusing the *old* value for a different hook in a future package version can confuse consumers who have both versions in their dependency graph during an upgrade.

### Verify the hook is wired up

After installing your package in a test project that uses `Microsoft.Testing.Platform.MSBuild`, build the project and inspect the generated `SelfRegisteredExtensions.g.cs` file under `obj/<Configuration>/<TargetFramework>/`. You should see a call into your hook, for example:

```csharp
public static void AddSelfRegisteredExtensions(this global::Microsoft.Testing.Platform.Builder.ITestApplicationBuilder builder, string[] args)
{
    global::Contoso.MyExtension.TestingPlatformBuilderHook.AddExtensions(builder, args);
}
```

If the call is missing, double-check that the props file is packaged under `buildMultiTargeting/` (not `build/`) inside the `.nupkg`, that `DisplayName` and `TypeFullName` metadata are present, and that the consumer hasn't set `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

## Extensions execution order

The testing platform consists of a [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) and any number of extensions that can operate [*in-process*](./microsoft-testing-platform-architecture.md#in-process-vs-out-of-process-extensions) or [*out-of-process*](./microsoft-testing-platform-architecture.md#in-process-vs-out-of-process-extensions). This document outlines the **sequence of calls** to all potential extensibility points to provide clarity on when a feature is anticipated to be invoked:

1. [ITestHostEnvironmentVariableProvider.UpdateAsync](#the-itesthostenvironmentvariableprovider-extensions) : Out-of-process
1. [ITestHostEnvironmentVariableProvider.ValidateTestHostEnvironmentVariablesAsync](#the-itesthostenvironmentvariableprovider-extensions) : Out-of-process
1. [ITestHostProcessLifetimeHandler.BeforeTestHostProcessStartAsync](#the-itesthostprocesslifetimehandler-extensions) : Out-of-process
1. Test host process start
1. [ITestHostProcessLifetimeHandler.OnTestHostProcessStartedAsync](#the-itesthostprocesslifetimehandler-extensions) : Out-of-process, this event can intertwine the actions of *in-process* extensions, depending on race conditions.
1. [ITestHostApplicationLifetime.BeforeRunAsync](#the-itestapplicationlifecyclecallbacks-extensions): In-process
1. [ITestSessionLifetimeHandler.OnTestSessionStartingAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. [ITestFramework.CreateTestSessionAsync](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension): In-process
1. [ITestFramework.ExecuteRequestAsync](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension): In-process, this method can be called one or more times. At this point, the testing framework will transmit information to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) that can be utilized by the [IDataConsumer](#the-idataconsumer-extensions).
1. [ITestFramework.CloseTestSessionAsync](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension): In-process
1. [ITestSessionLifetimeHandler.OnTestSessionFinishingAsync](#the-itestsessionlifetimehandler-extensions): In-process
1. [ITestHostApplicationLifetime.AfterRunAsync](#the-itestapplicationlifecyclecallbacks-extensions): In-process
1. In-process cleanup, involves calling dispose and [IAsyncCleanableExtension](#asynchronous-initialization-and-cleanup-of-extensions) on all extension points.
1. [ITestHostProcessLifetimeHandler.OnTestHostProcessExitedAsync](#the-itesthostprocesslifetimehandler-extensions) : Out-of-process
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

As outlined in the [extensions](#extensibility-points) section, the testing platform enables you to implement interfaces to incorporate custom extensions both in and out of process.

Each interface addresses a particular feature, and according to .NET design, you implement this interface in a specific object. You can register the extension itself using the specific registration API `AddXXX` from the `TestHost` or `TestHostController` object from the `ITestApplicationBuilder` as detailed in the corresponding sections.

However, if you need to *share state* between two extensions, the fact that you can implement and register different objects implementing different interfaces makes sharing a challenging task. Without any assistance, you would need a way to pass one extension to the other to share information, which complicates the design.

Hence, the testing platform provides a sophisticated method to implement multiple extension points using the same type, making data sharing a straightforward task. All you need to do is utilize the `CompositeExtensionFactory<T>`, which can then be registered using the same API as you would for a single interface implementation.

For instance, consider a type that implements both `ITestSessionLifetimeHandler` and `IDataConsumer`. This is a common scenario because you often want to gather information from the [testing framework](./microsoft-testing-platform-architecture-test-framework.md#test-framework-extension) and then, when the testing session concludes, you'll dispatch your artifact using the [`IMessageBus`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) within the `ITestSessionLifetimeHandler.OnTestSessionFinishingAsync`.

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

> [!NOTE]
> `IDataConsumer` is an *in-process* extension, so custom consumers are registered only through `builder.TestHost` (including via `CompositeExtensionFactory<T>`). There's no public API to register an `IDataConsumer` on `builder.TestHostControllers`.
