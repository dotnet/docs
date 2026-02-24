---
title: Build a test framework for Microsoft.Testing.Platform
description: Learn how to create a custom test framework for Microsoft.Testing.Platform, including registration, lifecycle, and test node reporting.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Build a test framework

This article explains how to create a custom test framework for Microsoft.Testing.Platform. The test framework is the only mandatory extension. It discovers and runs tests, and reports results back to the platform.

For the full extension point summary and in-process/out-of-process concepts, see [Create custom extensions](./microsoft-testing-platform-architecture.md).

If you're migrating an existing VSTest-based test framework to Microsoft.Testing.Platform, use the [VSTest Bridge](./microsoft-testing-platform-extensions-vstest-bridge.md) extension to simplify the transition.

## Test framework extension

The test framework is the primary extension that provides the testing platform with the ability to discover and execute tests. The test framework is responsible for communicating the results of the tests back to the testing platform. The test framework is the only mandatory extension required to execute a testing session.

### Register a testing framework

This section explains how to register the test framework with the testing platform. You register only one testing framework per test application builder using the `TestApplication.RegisterTestFramework` API as shown in [Microsoft.Testing.Platform architecture](./microsoft-testing-platform-architecture.md) documentation.

The registration API is defined as follows:

```csharp
ITestApplicationBuilder RegisterTestFramework(
    Func<IServiceProvider, ITestFrameworkCapabilities> capabilitiesFactory,
    Func<ITestFrameworkCapabilities, IServiceProvider, ITestFramework> adapterFactory);
```

The `RegisterTestFramework` API expects two factories:

1. `Func<IServiceProvider, ITestFrameworkCapabilities>`: This is a delegate that accepts an object implementing the [`IServiceProvider`](./microsoft-testing-platform-architecture-services.md) interface and returns an object implementing the [`ITestFrameworkCapabilities`](./microsoft-testing-platform-architecture-capabilities.md) interface. The [`IServiceProvider`](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) provides access to platform services such as configurations, loggers, and command line arguments.

    The [`ITestFrameworkCapabilities`](./microsoft-testing-platform-architecture-capabilities.md) interface is used to announce the capabilities supported by the testing framework to the platform and extensions. It allows the platform and extensions to interact correctly by implementing and supporting specific behaviors. For a better understanding of the [concept of capabilities](./microsoft-testing-platform-architecture-capabilities.md), refer to the respective section.

1. `Func<ITestFrameworkCapabilities, IServiceProvider, ITestFramework>`: This is a delegate that takes in an [ITestFrameworkCapabilities](./microsoft-testing-platform-architecture-capabilities.md) object, which is the instance returned by the `Func<IServiceProvider, ITestFrameworkCapabilities>`, and an [IServiceProvider](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) to provide access to platform services once more. The expected return object is one that implements the [ITestFramework](#test-framework-extension) interface. The `ITestFramework` serves as the execution engine that discovers and runs tests, and then communicates the results back to the testing platform.

The need for the platform to separate the creation of the [`ITestFrameworkCapabilities`](./microsoft-testing-platform-architecture-capabilities.md) and the creation of the [ITestFramework](#test-framework-extension) is an optimization to avoid creating the test framework if the supported capabilities are not sufficient to execute the current testing session.

Consider the following user code example, which demonstrates a test framework registration that returns an empty capability set:

```csharp
internal class TestingFrameworkCapabilities : ITestFrameworkCapabilities
{
    public IReadOnlyCollection<ITestFrameworkCapability> Capabilities => [];
}

internal class TestingFramework : ITestFramework
{
   public TestingFramework(ITestFrameworkCapabilities capabilities, IServiceProvider serviceProvider)
   {
       // ...
   }
   // Omitted for brevity...
}

public static class TestingFrameworkExtensions
{
    public static void AddTestingFramework(this ITestApplicationBuilder builder)
    {
        builder.RegisterTestFramework(
            _ => new TestingFrameworkCapabilities(),
            (capabilities, serviceProvider) => new TestingFramework(capabilities, serviceProvider));
    }
}

// ...
```

Now, consider the corresponding entry point of this example with the registration code:

```csharp
var testApplicationBuilder = await TestApplication.CreateBuilderAsync(args);
// Register the testing framework
testApplicationBuilder.AddTestingFramework();
using var testApplication = await testApplicationBuilder.BuildAsync();
return await testApplication.RunAsync();
```

> [!NOTE]
> Returning empty [ITestFrameworkCapabilities](./microsoft-testing-platform-architecture-capabilities.md) shouldn't prevent the execution of the test session. All test frameworks should be capable of discovering and running tests. The impact should be limited to extensions that may opt-out if the test framework lacks a certain feature.

### Create a testing framework

The `Microsoft.Testing.Platform.Extensions.TestFramework.ITestFramework` is implemented by extensions that provide a test framework:

```csharp
public interface ITestFramework : IExtension
{
    Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context);
    Task ExecuteRequestAsync(ExecuteRequestContext context);
    Task<CloseTestSessionResult> CloseTestSessionAsync(CloseTestSessionContext context);
}
```

The `ITestFramework` interface inherits from the [IExtension](#the-iextension-interface) interface, which is an interface that all extension points inherit from. `IExtension` is used to retrieve the name and description of the extension. The `IExtension` also provides a way to dynamically enable or disable the extension in setup, through `Task<bool> IsEnabledAsync()`. Please make sure that you return `true` from this method if you have no special needs.

#### The `CreateTestSessionAsync` method

The `CreateTestSessionAsync` method is called at the start of the test session and is used to initialize the test framework. The API accepts a `CloseTestSessionContext` object and returns a `CloseTestSessionResult`.

```csharp
public sealed class CreateTestSessionContext : TestSessionContext
{
    public SessionUid SessionUid { get; }
    public ClientInfo Client { get; }
    public CancellationToken CancellationToken { get; }
}

public readonly struct SessionUid
{
    public string Value { get; }
}

public sealed class ClientInfo
{
    public string Id { get; }
    public string Version { get; }
}
```

The `SessionUid` serves as the unique identifier for the current test session, providing a logical connection to the session's results.
The `ClientInfo` provides details about the entity invoking the test framework. This information can be utilized by the test framework to modify its behavior. For example, as of the time this document was written, a console execution would report a client name such as "testingplatform-console".
The `CancellationToken` is used to halt the execution of `CreateTestSessionAsync`.

The return object is a `CloseTestSessionResult`:

```csharp
public sealed class CreateTestSessionResult
{
    public string? WarningMessage { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
}
```

The `IsSuccess` property is used to indicate whether the session creation was successful. When it returns `false`, the test execution is halted.

#### The `CloseTestSessionAsync` method

The `CloseTestSessionAsync` method is juxtaposed to the `CreateTestSessionAsync` in functionality, with the only difference being the object names. For more information, see the `CreateTestSessionAsync` section.

#### The `ExecuteRequestAsync` method

The `ExecuteRequestAsync` method accepts an object of type `ExecuteRequestContext`. This object, as suggested by its name, holds the specifics about the action that the test framework is expected to perform.
The `ExecuteRequestContext` definition is:

```csharp
public sealed class ExecuteRequestContext
{
    public IRequest Request { get; }
    public IMessageBus MessageBus { get; }
    public CancellationToken CancellationToken { get; }
    public void Complete();
}
```

`IRequest`: This is the base interface for any type of request. You should think about the test framework as an **in-process stateful server** where the lifecycle is:

<!-- https://mermaid.live/edit#pako:eNrNlE9rwkAQxb_KshcT0ED1loPQ2go9CEV7DJRtMsbF7G66O0sV8bt30tiD0UAUhe7xMfPbt3_m7XhqMuAxd_DlQafwLEVuhUo0o_UODqXOWVkIXBqrBuPxa6VNqQK-jV3HTGSiRLBTkaKx2yBkS2sU680hl470o-peTT1GDAja3CdmnfefWBAIlbgA56TRj26r0-BEnhiNsMGwu4UTxBycL7Czs5cNpB5hXl2sw9rWsXbw9PEQ3gE6PH9UQs7oOCKHJ-9i9uY_C-lWNYgez1jW4vEOFke3tTi6KW34L2hRFLV0tjwT_VujygIQgvCiztHVncPTzi6DWxh3Zm4b6hVj2yDUU8v7XIFVQmaUdbuKlnBcgYKEU9jwTNh1whO9pzrh0SzIC4_ReuhzX2aUA4dc_BMhk5R3szo7fyN0_wNX3-gh -->
:::image type="content" source="./media/test-framework-sequence-diagram.png" lightbox="./media/test-framework-sequence-diagram.png" alt-text="A sequence diagram representing the lifecycle of the test framework.":::

The preceding diagram illustrates that the testing platform issues three requests after creating the test framework instance. The test framework processes these requests and utilizes the `IMessageBus` service, which is included in the request itself, to deliver the result for each specific request. Once a particular request has been handled, the test framework invokes the `Complete()` method on it, indicating to the testing platform that the request has been fulfilled.
The testing platform monitors all dispatched requests. Once all requests have been fulfilled, it invokes `CloseTestSessionAsync` and disposes of the instance (if `IDisposable/IAsyncDisposable` is implemented).
It's evident that the requests and their completions can overlap, enabling concurrent and asynchronous execution of requests.

> [!NOTE]
> Currently, the testing platform does not send overlapping requests and waits for the completion of a request >> before sending the next one. However, this behavior may change in the future. The support for concurrent requests will be determined through the [capabilities](./microsoft-testing-platform-architecture-capabilities.md) system.

The `IRequest` implementation specifies the precise request that needs to be fulfilled. The test framework identifies the type of request and handles it accordingly. If the request type is unrecognized, an exception should be raised.

You can find details about the available requests in the [IRequest](#handling-requests) section.

`IMessageBus`: This service, linked with the request, allows the test framework to *asynchronously* to publish information about the ongoing request to the testing platform.
The message bus serves as the central hub for the platform, facilitating asynchronous communication among all platform components and extensions.
For a comprehensive list of information that can be published to the testing platform, refer to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) section.

`CancellationToken`: This token is utilized to interrupt the processing of a particular request.

`Complete()`: As depicted in the previous sequence, the `Complete` method notifies the platform that the request has been successfully processed and all relevant information has been transmitted to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service).

> [!WARNING]
> Neglecting to invoke `Complete()` on the request will result in the test application becoming unresponsive.

To customize your test framework according to your requirements or those of your users, you can use a personalized section inside the [configuration](./microsoft-testing-platform-architecture-services.md#the-iconfiguration-service) file or with custom [command line options](#the-icommandlineoptionsprovider-extensions).

### Handling requests

The subsequent section provides a detailed description of the various requests that a test framework may receive and process.

Before proceeding to the next section, it's crucial to thoroughly comprehend the concept of the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service), which is the essential service for conveying test execution information to the testing platform.

#### TestSessionContext

The `TestSessionContext` is a shared property across all requests, providing information about the ongoing test session:

```csharp
public class TestSessionContext
{
    public SessionUid SessionUid { get; }
    public ClientInfo Client { get; }
}

public readonly struct SessionUid(string value)
{
    public string Value { get; }
}

public sealed class ClientInfo
{
    public string Id { get; }
    public string Version { get; }
}
```

The `TestSessionContext` consists of the `SessionUid`, a unique identifier for the ongoing test session that aids in logging and correlating test session data. It also includes the `ClientInfo` type, which provides details about the *initiator* of the test session. The test framework may choose different routes or publish varying information based on the identity of the test session's *initiator*.

#### DiscoverTestExecutionRequest

```csharp
public class DiscoverTestExecutionRequest
{
    // Detailed in the custom section below
    public TestSessionContext Session { get; }

    // This is experimental and intended for future use, please disregard for now.
    public ITestExecutionFilter Filter { get; }
}
```

The `DiscoverTestExecutionRequest` instructs the test framework **to discover** the tests and communicate this information thought to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service).

As outlined in the previous section, the property for a discovered test is `DiscoveredTestNodeStateProperty`. Here is a generic code snippet for reference:

```csharp
var testNode = new TestNode
{
    Uid = GenerateUniqueStableId(),
    DisplayName = GetDisplayName(),
    Properties = new PropertyBag(
        DiscoveredTestNodeStateProperty.CachedInstance),
};

await context.MessageBus.PublishAsync(
    this,
    new TestNodeUpdateMessage(
        discoverTestExecutionRequest.Session.SessionUid,
        testNode));

// ...
```

#### RunTestExecutionRequest

```csharp
public class RunTestExecutionRequest
{
    // Detailed in the custom section below
    public TestSessionContext Session { get; }

    // This is experimental and intended for future use, please disregard for now.
    public ITestExecutionFilter Filter { get; }
}
```

The `RunTestExecutionRequest` instructs the test framework **to execute** the tests and communicate this information thought to the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service).

Here is a generic code snippet for reference:

```csharp
var skippedTestNode = new TestNode()
{
    Uid = GenerateUniqueStableId(),
    DisplayName = GetDisplayName(),
    Properties = new PropertyBag(
        SkippedTestNodeStateProperty.CachedInstance),
};

await context.MessageBus.PublishAsync(
    this,
    new TestNodeUpdateMessage(
        runTestExecutionRequest.Session.SessionUid,
        skippedTestNode));

// ...

var successfulTestNode = new TestNode()
{
    Uid = GenerateUniqueStableId(),
    DisplayName = GetDisplayName(),
    Properties = new PropertyBag(
        PassedTestNodeStateProperty.CachedInstance),
};

await context.MessageBus.PublishAsync(
    this,
    new TestNodeUpdateMessage(
        runTestExecutionRequest.Session.SessionUid,
        successfulTestNode));

// ...

var assertionFailedTestNode = new TestNode()
{
    Uid = GenerateUniqueStableId(),
    DisplayName = GetDisplayName(),
    Properties = new PropertyBag(
        new FailedTestNodeStateProperty(assertionException)),
};

await context.MessageBus.PublishAsync(
    this,
    new TestNodeUpdateMessage(
        runTestExecutionRequest.Session.SessionUid,
        assertionFailedTestNode));

// ...

var failedTestNode = new TestNode()
{
    Uid = GenerateUniqueStableId(),
    DisplayName = GetDisplayName(),
    Properties = new PropertyBag(
        new ErrorTestNodeStateProperty(ex.InnerException!)),
};

await context.MessageBus.PublishAsync(
    this,
    new TestNodeUpdateMessage(
        runTestExecutionRequest.Session.SessionUid,
        failedTestNode));
```

### The `TestNodeUpdateMessage` data

As mentioned in the [IMessageBus](./microsoft-testing-platform-architecture-services.md#the-imessagebus-service) section, before utilizing the message bus, you must specify the type of data you intend to supply. The testing platform has defined a well-known type, `TestNodeUpdateMessage`, to represent the concept of a *test update information*.

This part of the document will explain how to utilize this payload data. Let's examine the surface:

```csharp
public sealed class TestNodeUpdateMessage(
    SessionUid sessionUid,
    TestNode testNode,
    TestNodeUid? parentTestNodeUid = null)
{
    public TestNode TestNode { get; }
    public TestNodeUid? ParentTestNodeUid { get; }
}

public class TestNode
{
    public required TestNodeUid Uid { get; init; }
    public required string DisplayName { get; init; }
    public PropertyBag Properties { get; init; } = new();
}

public sealed class TestNodeUid(string value)

public sealed partial class PropertyBag
{
    public PropertyBag();
    public PropertyBag(params IProperty[] properties);
    public PropertyBag(IEnumerable<IProperty> properties);
    public int Count { get; }
    public void Add(IProperty property);
    public bool Any<TProperty>();
    public TProperty? SingleOrDefault<TProperty>();
    public TProperty Single<TProperty>();
    public TProperty[] OfType<TProperty>();
    public IEnumerable<IProperty> AsEnumerable();
    public IEnumerator<IProperty> GetEnumerator();
    ...
}

public interface IProperty
{
}
```

* `TestNodeUpdateMessage`: The `TestNodeUpdateMessage` consists of two properties: a `TestNode` and a `ParentTestNodeUid`. The `ParentTestNodeUid` indicates that a test may have a parent test, introducing the concept of a **test tree** where `TestNode`s can be arranged in relation to each other. This structure allows for future enhancements and features based on the *tree* relationship between the nodes. If your test framework doesn't require a test tree structure, you can opt not to use it and simply set it to null, resulting in a straightforward flat list of `TestNode`s.

* `TestNode`: The `TestNode` is composed of three properties, one of which is the `Uid` of type `TestNodeUid`. This `Uid` serves as the **UNIQUE STABLE ID** for the node. The term **UNIQUE STABLE ID** implies that the same `TestNode` should maintain an **IDENTICAL** `Uid` across different runs and operating systems. The `TestNodeUid` is an **arbitrary opaque string** that the testing platform accepts as is.

> [!IMPORTANT]
> The stability and uniqueness of the ID are crucial in the testing domain. They enable the precise targeting of a single test for execution and allow the ID to serve as a persistent identifier for a test, facilitating powerful extensions and features.

The second property is `DisplayName`, which is the human-friendly name for the test. For example, this name is displayed when you execute the `--list-tests` command line.

The third attribute is `Properties`, which is a `PropertyBag` type. As demonstrated in the code, this is a specialized property bag that holds generic properties about the `TestNodeUpdateMessage`. This implies that you can append any property to the node that implements the placeholder interface `IProperty`.

***The testing platform identifies specific properties added to a `TestNode.Properties` to determine whether a test has passed, failed, or been skipped.***

You can find the current list of available properties with the relative description in the section [TestNodeUpdateMessage.TestNode](#the-testnodeupdatemessage-data).

The `PropertyBag` type is typically accessible in every `IData` and is utilized to store miscellaneous properties that can be queried by the platform and extensions. This mechanism allows us to enhance the platform with new information without introducing breaking changes. If a component recognizes the property, it can query it; otherwise, it will disregard it.

Finally this section makes clear that you test framework implementation needs to implement the `IDataProducer` that produces `TestNodeUpdateMessage`s like in the sample below:

```csharp
internal sealed class TestingFramework
    : ITestFramework, IDataProducer
{
   // ...

   public Type[] DataTypesProduced =>
   [
       typeof(TestNodeUpdateMessage)
   ];

   // ...
}
```

If your test adapter requires the publication of *files* during execution, you can find the recognized properties in this source file: <https://github.com/microsoft/testfx/blob/main/src/Platform/Microsoft.Testing.Platform/Messages/FileArtifacts.cs>. As you can see, you can provide file assets in a general manner or associate them with a specific `TestNode`. Remember, if you intend to push a `SessionFileArtifact`, you must declare it to the platform in advance, as shown below:

```csharp
internal sealed class TestingFramework
    : ITestFramework, IDataProducer
{
   // ...

   public Type[] DataTypesProduced =>
   [
       typeof(TestNodeUpdateMessage),
       typeof(SessionFileArtifact)
   ];

   // ...
}
```

#### Well-known properties

As detailed in the [requests section](#handling-requests), the testing platform identifies specific properties added to the `TestNodeUpdateMessage` to determine the status of a `TestNode` (for example, successful, failed, skipped, etc.). This allows the runtime to accurately display a list of failed tests with their corresponding information in the console, and to set the appropriate exit code for the test process.

In this segment, we'll elucidate the various well-known `IProperty` options and their respective implications.

For a comprehensive list of well-known properties, see [TestNodeProperties.cs](https://github.com/microsoft/testfx/blob/main/src/Platform/Microsoft.Testing.Platform/Messages/TestNodeProperties.cs). If you notice that a property description is missing, please file an issue.

These properties can be divided in the following categories:

1. [*Generic information*](#generic-information): Properties that can be included in any kind of request.
1. [*Discovery information*](#discovery-information): Properties that are supplied during a `DiscoverTestExecutionRequest` discovery request.
1. [*Execution information*](#execution-information): Properties that are supplied during a test execution request `RunTestExecutionRequest`.

Certain properties are **required**, while others are optional. The mandatory properties are required to provide basic testing functionality, such as reporting failed tests and indicating whether the entire test session was successful or not.

Optional properties, on the other hand, enhance the testing experience by providing additional information. They are particularly useful in IDE scenarios (like VS, VSCode, etc.), console runs, or when supporting specific extensions that require more detailed information to function correctly. However, these optional properties do not affect the execution of the tests.

> [!NOTE]
> Extensions are tasked with alerting and managing exceptions when they require specific information to operate correctly. If an extension lacks the necessary information, it should not cause the test execution to fail, but rather, it should simply opt-out.

##### Generic information

```csharp
public record KeyValuePairStringProperty(
    string Key,
    string Value)
        : IProperty;
```

The `KeyValuePairStringProperty` stands for a general key/value pair data.

```csharp
public record struct LinePosition(
    int Line,
    int Column);

public record struct LinePositionSpan(
    LinePosition Start,
    LinePosition End);

public abstract record FileLocationProperty(
    string FilePath,
    LinePositionSpan LineSpan)
        : IProperty;

public sealed record TestFileLocationProperty(
    string FilePath,
    LinePositionSpan LineSpan)
        : FileLocationProperty(FilePath, LineSpan);
```

`TestFileLocationProperty` is used to pinpoint the location of the test within the source file. This is particularly useful when the initiator is an IDE like Visual Studio or Visual Studio Code.

```csharp
public sealed record TestMethodIdentifierProperty(
    string AssemblyFullName,
    string Namespace,
    string TypeName,
    string MethodName,
    string[] ParameterTypeFullNames,
    string ReturnTypeFullName)
```

`TestMethodIdentifierProperty` is a unique identifier for a test method, adhering to the ECMA-335 standard.

> [!NOTE]
> The data needed to create this property can be conveniently obtained using the .NET reflection feature, using types from the `System.Reflection` namespace.

```csharp
public sealed record TestMetadataProperty(
    string Key,
    string Value)
```

`TestMetadataProperty` is utilized to convey the characteristics or *traits* of a `TestNode`.

##### Discovery information

```csharp
public sealed record DiscoveredTestNodeStateProperty(
    string? Explanation = null)
{
    public static DiscoveredTestNodeStateProperty CachedInstance { get; }
}
```

The `DiscoveredTestNodeStateProperty` indicates that this TestNode has been discovered. It is utilized when a `DiscoverTestExecutionRequest` is sent to the test framework.
Take note of the handy cached value offered by the `CachedInstance` property.
This property is **required**.

##### Execution information

```csharp
public sealed record InProgressTestNodeStateProperty(
    string? Explanation = null)
{
    public static InProgressTestNodeStateProperty CachedInstance { get; }
}
```

The `InProgressTestNodeStateProperty` informs the testing platform that the `TestNode` has been scheduled for execution and is currently in progress.
Take note of the handy cached value offered by the `CachedInstance` property.

```csharp
public readonly record struct TimingInfo(
    DateTimeOffset StartTime,
    DateTimeOffset EndTime,
    TimeSpan Duration);

public sealed record StepTimingInfo(
    string Id,
    string Description,
    TimingInfo Timing);

public sealed record TimingProperty : IProperty
{
    public TimingProperty(TimingInfo globalTiming)
        : this(globalTiming, [])
    {
    }

    public TimingProperty(
        TimingInfo globalTiming,
        StepTimingInfo[] stepTimings)
    {
        GlobalTiming = globalTiming;
        StepTimings = stepTimings;
    }

    public TimingInfo GlobalTiming { get; }

    public StepTimingInfo[] StepTimings { get; }
}
```

The `TimingProperty` is utilized to relay timing details about the `TestNode` execution. It also allows for the timing of individual execution steps via `StepTimingInfo`. This is particularly useful when your test concept is divided into multiple phases such as initialization, execution, and cleanup.

***One and only one*** of the following properties is **required** per `TestNode` and communicates the result of the `TestNode` to the testing platform.

```csharp
public sealed record PassedTestNodeStateProperty(
    string? Explanation = null)
        : TestNodeStateProperty(Explanation)
{
    public static PassedTestNodeStateProperty CachedInstance
        { get; } = new PassedTestNodeStateProperty();
}
```

`PassedTestNodeStateProperty` informs the testing platform that this `TestNode` is passed.
Take note of the handy cached value offered by the `CachedInstance` property.

```csharp
public sealed record SkippedTestNodeStateProperty(
    string? Explanation = null)
        : TestNodeStateProperty(Explanation)
{
    public static SkippedTestNodeStateProperty CachedInstance
        { get; } =  new SkippedTestNodeStateProperty();
}
```

`SkippedTestNodeStateProperty` informs the testing platform that this `TestNode` was skipped.
Take note of the handy cached value offered by the `CachedInstance` property.

```csharp
public sealed record FailedTestNodeStateProperty : TestNodeStateProperty
{
    public FailedTestNodeStateProperty()
        : base(default(string))
    {
    }

    public FailedTestNodeStateProperty(string explanation)
        : base(explanation)
    {
    }

    public FailedTestNodeStateProperty(
        Exception exception,
        string? explanation = null)
        : base(explanation ?? exception.Message)
    {
        Exception = exception;
    }

    public Exception? Exception { get; }
}
```

`FailedTestNodeStateProperty` informs the testing platform that this `TestNode` is failed after an assertion.

```csharp
public sealed record ErrorTestNodeStateProperty : TestNodeStateProperty
{
    public ErrorTestNodeStateProperty()
        : base(default(string))
    {
    }

    public ErrorTestNodeStateProperty(string explanation)
        : base(explanation)
    {
    }

    public ErrorTestNodeStateProperty(
        Exception exception,
        string? explanation = null)
            : base(explanation ?? exception.Message)
    {
        Exception = exception;
    }

    public Exception? Exception { get; }
}
```

`ErrorTestNodeStateProperty` informs the testing platform that this `TestNode` has failed. This type of failure is different from the `FailedTestNodeStateProperty`, which is used for assertion failures. For example, you can report issues like test initialization errors with `ErrorTestNodeStateProperty`.

```csharp
public sealed record TimeoutTestNodeStateProperty : TestNodeStateProperty
{
    public TimeoutTestNodeStateProperty()
        : base(default(string))
    {
    }

    public TimeoutTestNodeStateProperty(string explanation)
        : base(explanation)
    {
    }

    public TimeoutTestNodeStateProperty(
        Exception exception,
        string? explanation = null)
            : base(explanation ?? exception.Message)
    {
        Exception = exception;
    }

    public Exception? Exception { get; }

    public TimeSpan? Timeout { get; init; }
}
```

`TimeoutTestNodeStateProperty` informs the testing platform that this `TestNode` is failed for a timeout reason. You can report the timeout using the `Timeout` property.

```csharp
public sealed record CancelledTestNodeStateProperty : TestNodeStateProperty
{
    public CancelledTestNodeStateProperty()
        : base(default(string))
    {
    }

    public CancelledTestNodeStateProperty(string explanation)
        : base(explanation)
    {
    }

    public CancelledTestNodeStateProperty(
        Exception exception,
        string? explanation = null)
        : base(explanation ?? exception.Message)
    {
        Exception = exception;
    }

    public Exception? Exception { get; }
}
```

`CancelledTestNodeStateProperty` informs the testing platform that this `TestNode` has failed due to cancellation.



