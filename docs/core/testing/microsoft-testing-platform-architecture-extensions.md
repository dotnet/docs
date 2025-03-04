---
title: Microsoft.Testing.Platform extensions architecture overview
description: Learn about how to extend Microsoft.Testing.Platform.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 07/11/2024
---

# Microsoft.Testing.Platform extensibility

The testing platform consists of a [testing framework](#test-framework-extension) and any number of [extensions](#other-extensibility-points) that can operate *in-process* or *out-of-process*.

As outlined in the [architecture](./microsoft-testing-platform-architecture.md) section, the testing platform is designed to accommodate a variety of scenarios and extensibility points. The primary and essential extension is undoubtedly the [testing framework](#test-framework-extension) that your tests will utilize. Failing to register this results in startup error. **The [testing framework](#test-framework-extension) is the sole mandatory extension required to execute a testing session.**

To support scenarios such as generating test reports, code coverage, retrying failed tests, and other potential features, you need to provide a mechanism that allows other extensions to work in conjunction with the [testing framework](#test-framework-extension) to deliver these features not inherently provided by the [testing framework](#test-framework-extension) itself.

In essence, the [testing framework](#test-framework-extension) is the primary extension that supplies information about each test that makes up the test suite. It reports whether a specific test has succeeded, failed, skipped, and can provide additional information about each test, such as a human-readable name (referred to as the display name), the source file, and the line where our test begins, among other things.

The extensibility point enables the utilization of information provided by the [testing framework](#test-framework-extension) to generate new artifacts or to enhance existing ones with additional features. A commonly used extension is the TRX report generator, which subscribes to the [TestNodeUpdateMessage](#the-testnodeupdatemessage-data) and generates an XML report file from it.

As discussed in the [architecture](./microsoft-testing-platform-architecture.md), there are certain extension points that *cannot* operate within the same process as the [testing framework](#test-framework-extension). The reasons typically include:

* The need to modify the *environment variables* of the *test host*. Acting within the test host process itself is *too late*.
* The requirement to *monitor* the process from the outside because the *test host*, where tests and user code run, might have some *user code bugs* that render the process itself *unstable*, leading to potential *hangs* or *crashes*. In such cases, the extension would crash or hang along with the *test host* process.

Due to these reasons, the extension points are categorized into two types:

1. *In-process extensions*: These extensions operate within the same process as the [testing framework](#test-framework-extension).

    You can register *in-process extensions* via the `ITestApplicationBuilder.TestHost` property:

    ```csharp
    // ...
    var builder = await TestApplication.CreateBuilderAsync(args);
    builder.TestHost.AddXXX(...);
    // ...
    ```

1. *Out-of-process extensions*: These extensions function in a separate process, allowing them to monitor the test host without being influenced by the test host itself.

    You can register *out-of-process extensions* via the `ITestApplicationBuilder.TestHostControllers`.

    ```csharp
    var builder = await TestApplication.CreateBuilderAsync(args);
    builder.TestHostControllers.AddXXX(...);
    ```

    Lastly, some extensions are designed to function in both scenarios. These common extensions behave identically in both *hosts*. You can register these extensions either through the *TestHost* and *TestHostController* interfaces or directly at the `ITestApplicationBuilder` level. An example of such an extension is the [ICommandLineOptionsProvider](#the-icommandlineoptionsprovider-extensions).

## The `IExtension` interface

The `IExtension` interface serves as the foundational interface for all extensibility points within the testing platform. It's primarily used to obtain descriptive information about the extension and, most importantly, to enable or disable the extension itself.

Consider the following `IExtension` interface:

```csharp
public interface IExtension
{
    string Uid { get; }
    string Version { get; }
    string DisplayName { get; }
    string Description { get; }
    Task<bool> IsEnabledAsync();
}
```

* `Uid`: Represents the unique identifier for the extension. It's crucial to choose a unique value for this string to avoid conflicts with other extensions.

* `Version`: Represents the version of the interface. Requires [**semantic versioning**](https://semver.org/).

* `DisplayName`: A user-friendly name representation that will appear in logs and when you request information using the `--info` command line option.

* `Description`: The description of the extension, that appears when you request information using the `--info` command line option.

* `IsEnabledAsync()`: This method is invoked by the testing platform when the extension is being instantiated. If the method returns `false`, the extension will be excluded. This method typically makes decisions based on the [configuration file](./microsoft-testing-platform-architecture-services.md#the-iconfiguration-service) or some [custom command line options](./microsoft-testing-platform-architecture-services.md#the-icommandlineoptions-service). Users often specify `--customExtensionOption` in the command line to opt into the extension itself.

## Test framework extension

The test framework is the primary extension that provides the testing platform with the ability to discover and execute tests. The test framework is responsible for communicating the results of the tests back to the testing platform. The test framework is the only mandatory extension required to execute a testing session.

### Register a testing framework

This section explains how to register the test framework with the testing platform. You register only one testing framework per test application builder using the `TestApplication.RegisterTestFramework` API as shown in [the testing platform architecture](./microsoft-testing-platform-architecture.md) documentation.

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

As detailed in the [requests section](#handling-requests), the testing platform identifies specific properties added to the `TestNodeUpdateMessage` to determine the status of a `TestNode` (e.g., successful, failed, skipped, etc.). This allows the runtime to accurately display a list of failed tests with their corresponding information in the console, and to set the appropriate exit code for the test process.

In this segment, we'll elucidate the various well-known `IProperty` options and their respective implications.

If you're looking for a comprehensive list of well-known properties, you can find it [here](https://github.com/microsoft/testfx/blob/main/src/Platform/Microsoft.Testing.Platform/Messages/TestNodeProperties.cs). If you notice that a property description is missing, please don't hesitate to file an issue.

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

`AfterRunAsync`: This method is the final call before exiting the [`int ITestApplication.RunAsync()`](./microsoft-testing-platform-architecture.md) and it provides the [`exit code`](./microsoft-testing-platform-exit-codes.md). It should be used solely for cleanup tasks and to notify any corresponding *out-of-process* extension that the *test host* is about to terminate.

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
