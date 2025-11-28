---
title: Build a test framework for Microsoft.Testing.Platform
description: Learn how to create a custom test framework that integrates with Microsoft.Testing.Platform to discover and execute tests.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 11/27/2025
ai-usage: ai-assisted
---

# Build a test framework for Microsoft.Testing.Platform

A test framework is the core component that provides Microsoft.Testing.Platform with the ability to discover and execute tests. The test framework is responsible for:

- Finding tests in your code
- Running those tests
- Reporting results back to the platform

The test framework is the only **mandatory** component required to execute a testing session. This article explains how to build a custom test framework that integrates with the platform.

> [!NOTE]
> Complete working examples are available in the [Microsoft Test Framework repository](https://github.com/microsoft/testfx/tree/main/samples/public/TestingPlatformExamples).

## Test framework responsibilities

Your test framework acts as an **in-process stateful server** with a well-defined lifecycle:

:::image type="content" source="./media/test-framework-sequence-diagram.png" lightbox="./media/test-framework-sequence-diagram.png" alt-text="Sequence diagram showing test framework lifecycle from creation through disposal.":::

The lifecycle consists of:

1. **Creation**: Platform instantiates your test framework
2. **Session start**: Framework initializes for the test session
3. **Request processing**: Framework handles one or more requests (discovery, execution)
4. **Session close**: Framework finalizes the test session
5. **Disposal**: Framework cleans up resources

## Register a test framework

Register your test framework with the platform using the `RegisterTestFramework` API:

```csharp
public static async Task<int> Main(string[] args)
{
    ITestApplicationBuilder builder = await TestApplication.CreateBuilderAsync(args);
    
    builder.RegisterTestFramework(
        serviceProvider => new TestingFrameworkCapabilities(),
        (capabilities, serviceProvider) => new TestingFramework(capabilities, serviceProvider));
    
    using ITestApplication app = await builder.BuildAsync();
    return await app.RunAsync();
}
```

The `RegisterTestFramework` API requires two factory methods:

### Capabilities factory

```csharp
Func<IServiceProvider, ITestFrameworkCapabilities>
```

This factory creates an object that describes your test framework's capabilities. The platform uses capabilities to:

- Determine if your framework supports required features
- Enable extensions to adapt based on available features
- Avoid creating the framework if capabilities are insufficient

Example:

```csharp
internal class TestingFrameworkCapabilities : ITestFrameworkCapabilities
{
    public IReadOnlyCollection<ITestFrameworkCapability> Capabilities => 
    [
        // Add capabilities your framework supports
    ];
}
```

For more information about capabilities, see [Capabilities system](microsoft-testing-platform-architecture-capabilities.md).

### Test framework factory

```csharp
Func<ITestFrameworkCapabilities, IServiceProvider, ITestFramework>
```

This factory creates your test framework implementation. It receives:

- The `ITestFrameworkCapabilities` instance from the first factory
- An `IServiceProvider` for accessing platform services

Example:

```csharp
internal class TestingFramework : ITestFramework
{
    public TestingFramework(
        ITestFrameworkCapabilities capabilities, 
        IServiceProvider serviceProvider)
    {
        // Store dependencies
        // Access services like IConfiguration, IMessageBus, ILoggerFactory
    }
    
    // Implement ITestFramework methods...
}
```

## Implement the ITestFramework interface

The `ITestFramework` interface defines the contract for test frameworks:

```csharp
public interface ITestFramework : IExtension
{
    Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context);
    Task ExecuteRequestAsync(ExecuteRequestContext context);
    Task<CloseTestSessionResult> CloseTestSessionAsync(CloseTestSessionContext context);
}
```

Your test framework must also implement the base `IExtension` interface:

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

### Implement IExtension

Provide descriptive information about your framework:

```csharp
public string Uid => "MyTestFramework";
public string Version => "1.0.0";
public string DisplayName => "My Test Framework";
public string Description => "A custom test framework for my tests";

public Task<bool> IsEnabledAsync()
{
    // Return true to enable the framework
    // You can check configuration or command-line options here
    return Task.FromResult(true);
}
```

### Implement CreateTestSessionAsync

This method initializes your test framework at the start of the test session:

```csharp
public Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context)
{
    // Session identifier for logging and correlation
    SessionUid sessionId = context.SessionUid;
    
    // Information about who's running the tests (e.g., "testingplatform-console")
    ClientInfo client = context.Client;
    
    // Cancellation token to honor
    CancellationToken cancellationToken = context.CancellationToken;
    
    // Perform initialization (load configuration, set up state, etc.)
    
    return Task.FromResult(new CreateTestSessionResult
    {
        IsSuccess = true,
        // Set WarningMessage or ErrorMessage if needed
    });
}
```

Return `IsSuccess = false` to halt test execution if initialization fails.

### Implement ExecuteRequestAsync

This method handles requests from the platform to discover or execute tests:

```csharp
public async Task ExecuteRequestAsync(ExecuteRequestContext context)
{
    IRequest request = context.Request;
    IMessageBus messageBus = context.MessageBus;
    CancellationToken cancellationToken = context.CancellationToken;
    
    try
    {
        // Determine request type and handle accordingly
        switch (request)
        {
            case DiscoverTestExecutionRequest discoverRequest:
                await DiscoverTestsAsync(discoverRequest, messageBus, cancellationToken);
                break;
                
            case RunTestExecutionRequest runRequest:
                await RunTestsAsync(runRequest, messageBus, cancellationToken);
                break;
                
            default:
                throw new NotSupportedException($"Unsupported request type: {request.GetType()}");
        }
    }
    finally
    {
        // CRITICAL: Always call Complete() when done processing the request
        context.Complete();
    }
}
```

> [!WARNING]
> You must call `context.Complete()` when you finish processing a request. Failing to do so causes the test application to hang indefinitely.

### Implement CloseTestSessionAsync

This method finalizes your test framework at the end of the test session:

```csharp
public Task<CloseTestSessionResult> CloseTestSessionAsync(CloseTestSessionContext context)
{
    SessionUid sessionId = context.SessionUid;
    CancellationToken cancellationToken = context.CancellationToken;
    
    // Perform cleanup (flush buffers, save state, etc.)
    
    return Task.FromResult(new CloseTestSessionResult
    {
        IsSuccess = true,
        // Set WarningMessage or ErrorMessage if needed
    });
}
```

## Handle discovery requests

The `DiscoverTestExecutionRequest` instructs your framework to discover tests and report them via the message bus:

```csharp
private async Task DiscoverTestsAsync(
    DiscoverTestExecutionRequest request,
    IMessageBus messageBus,
    CancellationToken cancellationToken)
{
    // Find all tests in your test assembly
    foreach (var test in FindTests())
    {
        var testNode = new TestNode
        {
            Uid = new TestNodeUid(test.UniqueId),
            DisplayName = test.DisplayName,
            Properties = new PropertyBag(DiscoveredTestNodeStateProperty.CachedInstance)
        };
        
        await messageBus.PublishAsync(
            this,
            new TestNodeUpdateMessage(request.Session.SessionUid, testNode));
    }
}
```

Key points:

- **Unique ID**: Generate a stable, unique ID for each test that remains consistent across runs
- **Display name**: Provide a human-readable name
- **State property**: Use `DiscoveredTestNodeStateProperty` for discovered tests

## Handle execution requests

The `RunTestExecutionRequest` instructs your framework to execute tests and report results:

```csharp
private async Task RunTestsAsync(
    RunTestExecutionRequest request,
    IMessageBus messageBus,
    CancellationToken cancellationToken)
{
    // Execute all tests in your test assembly
    foreach (var test in FindTests())
    {
        var result = await test.RunAsync(cancellationToken);
        
        var testNode = new TestNode
        {
            Uid = new TestNodeUid(test.UniqueId),
            DisplayName = test.DisplayName,
            Properties = new PropertyBag(CreateStateProperty(result))
        };
        
        await messageBus.PublishAsync(
            this,
            new TestNodeUpdateMessage(request.Session.SessionUid, testNode));
    }
}

private IProperty CreateStateProperty(TestResult result)
{
    return result.Status switch
    {
        TestStatus.Passed => PassedTestNodeStateProperty.CachedInstance,
        TestStatus.Failed => new FailedTestNodeStateProperty(result.Exception),
        TestStatus.Skipped => SkippedTestNodeStateProperty.CachedInstance,
        _ => throw new InvalidOperationException($"Unknown status: {result.Status}")
    };
}
```

## Report test results with TestNodeUpdateMessage

The `TestNodeUpdateMessage` is the primary way to communicate test information to the platform:

```csharp
public sealed class TestNodeUpdateMessage
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
```

### The TestNode structure

A `TestNode` represents a single test or test container with:

- **Uid**: A unique, stable identifier (must be identical across runs and platforms)
- **DisplayName**: Human-readable name shown in test runners and reports
- **Properties**: A collection of properties describing the test's state and metadata
- **ParentTestNodeUid** (optional): Creates a tree structure for hierarchical tests

### Test node properties

The platform recognizes specific properties to determine test state and metadata.

#### Required state properties (one per test)

Each test node must have **exactly one** state property:

**For discovery:**

```csharp
DiscoveredTestNodeStateProperty.CachedInstance
```

**For execution (choose one):**

```csharp
// Test passed
PassedTestNodeStateProperty.CachedInstance

// Test failed (assertion failure)
new FailedTestNodeStateProperty(exception)

// Test had an error (not an assertion failure)
new ErrorTestNodeStateProperty(exception)

// Test was skipped
SkippedTestNodeStateProperty.CachedInstance

// Test timed out
new TimeoutTestNodeStateProperty(exception) { Timeout = timeoutDuration }

// Test was cancelled
new CancelledTestNodeStateProperty(exception)

// Test is in progress (optional, for real-time updates)
InProgressTestNodeStateProperty.CachedInstance
```

#### Optional metadata properties

Enhance test information with additional properties:

**Source location:**

```csharp
new TestFileLocationProperty(
    filePath: "C:\\Tests\\MyTests.cs",
    lineSpan: new LinePositionSpan(
        new LinePosition(10, 0),
        new LinePosition(20, 0)))
```

**Method identifier:**

```csharp
new TestMethodIdentifierProperty(
    assemblyFullName: "MyTests, Version=1.0.0.0",
    @namespace: "MyNamespace",
    typeName: "MyTestClass",
    methodName: "MyTestMethod",
    parameterTypeFullNames: new[] { "System.String", "System.Int32" },
    returnTypeFullName: "System.Void")
```

**Timing information:**

```csharp
new TimingProperty(
    globalTiming: new TimingInfo(
        startTime: DateTimeOffset.Now,
        endTime: DateTimeOffset.Now.AddSeconds(1),
        duration: TimeSpan.FromSeconds(1)))
```

**Test traits/metadata:**

```csharp
new TestMetadataProperty("Category", "Integration")
new TestMetadataProperty("Priority", "High")
```

**Custom key-value pairs:**

```csharp
new KeyValuePairStringProperty("CustomData", "CustomValue")
```

### Example: Complete test reporting

```csharp
private async Task ReportTestResultAsync(
    TestInfo test,
    TestResult result,
    SessionUid sessionUid,
    IMessageBus messageBus)
{
    var properties = new PropertyBag();
    
    // Required: Test state
    properties.Add(result.Status switch
    {
        TestStatus.Passed => PassedTestNodeStateProperty.CachedInstance,
        TestStatus.Failed => new FailedTestNodeStateProperty(result.Exception, result.Message),
        TestStatus.Skipped => SkippedTestNodeStateProperty.CachedInstance,
        _ => throw new InvalidOperationException()
    });
    
    // Optional: Source location
    if (test.SourceLocation != null)
    {
        properties.Add(new TestFileLocationProperty(
            test.SourceLocation.FilePath,
            test.SourceLocation.LineSpan));
    }
    
    // Optional: Timing
    if (result.Timing != null)
    {
        properties.Add(new TimingProperty(result.Timing));
    }
    
    // Optional: Traits
    foreach (var trait in test.Traits)
    {
        properties.Add(new TestMetadataProperty(trait.Key, trait.Value));
    }
    
    var testNode = new TestNode
    {
        Uid = new TestNodeUid(test.UniqueId),
        DisplayName = test.DisplayName,
        Properties = properties
    };
    
    await messageBus.PublishAsync(
        this,
        new TestNodeUpdateMessage(sessionUid, testNode));
}
```

## Declare produced data types

Your test framework must declare what types of data it publishes to the message bus:

```csharp
public class TestingFramework : ITestFramework, IDataProducer
{
    public Type[] DataTypesProduced => new[]
    {
        typeof(TestNodeUpdateMessage),
        // Add other types if you publish additional data
    };
    
    // ... ITestFramework implementation
}
```

## Use platform services

Access platform services through the `IServiceProvider` passed to your factory:

```csharp
public class TestingFramework : ITestFramework
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    
    public TestingFramework(
        ITestFrameworkCapabilities capabilities,
        IServiceProvider serviceProvider)
    {
        // Access configuration
        _configuration = serviceProvider.GetConfiguration();
        
        // Create a logger
        var loggerFactory = serviceProvider.GetLoggerFactory();
        _logger = loggerFactory.CreateLogger<TestingFramework>();
        
        // Access command-line options
        var commandLineOptions = serviceProvider.GetCommandLineOptions();
    }
    
    // ... implementation
}
```

For more information, see [Platform services](microsoft-testing-platform-architecture-services.md).

## Implement async initialization

If your framework requires async initialization, implement `IAsyncInitializableExtension`:

```csharp
public class TestingFramework : ITestFramework, IAsyncInitializableExtension
{
    public async Task InitializeAsync()
    {
        // Perform async initialization
        // This is called after the constructor
        await LoadConfigurationAsync();
        await ConnectToDatabaseAsync();
    }
    
    // ... ITestFramework implementation
}
```

Similarly, implement `IAsyncCleanableExtension` for async cleanup:

```csharp
public class TestingFramework : ITestFramework, IAsyncCleanableExtension
{
    public async Task CleanupAsync()
    {
        // Perform async cleanup
        // This is called before disposal
        await FlushBuffersAsync();
        await DisconnectFromDatabaseAsync();
    }
    
    // ... ITestFramework implementation
}
```

## Handle cancellation

Always honor cancellation tokens to allow users to interrupt test execution:

```csharp
private async Task RunTestAsync(TestInfo test, CancellationToken cancellationToken)
{
    // Check before starting
    cancellationToken.ThrowIfCancellationRequested();
    
    // Pass to async operations
    await test.SetupAsync(cancellationToken);
    
    // Check periodically during long operations
    if (cancellationToken.IsCancellationRequested)
    {
        return TestResult.Cancelled;
    }
    
    await test.ExecuteAsync(cancellationToken);
}
```

## Error handling best practices

### Distinguish between test failures and errors

Use `FailedTestNodeStateProperty` for assertion failures:

```csharp
try
{
    test.Execute();
}
catch (AssertionException ex)
{
    // Assertion failure - expected test failure
    return new FailedTestNodeStateProperty(ex);
}
```

Use `ErrorTestNodeStateProperty` for unexpected errors:

```csharp
try
{
    test.Setup();
    test.Execute();
}
catch (AssertionException ex)
{
    return new FailedTestNodeStateProperty(ex);
}
catch (Exception ex)
{
    // Unexpected error during setup or execution
    return new ErrorTestNodeStateProperty(ex);
}
```

### Report framework errors

If your framework encounters errors that prevent test execution, report them through session results:

```csharp
public Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context)
{
    try
    {
        Initialize();
        return Task.FromResult(new CreateTestSessionResult { IsSuccess = true });
    }
    catch (Exception ex)
    {
        return Task.FromResult(new CreateTestSessionResult
        {
            IsSuccess = false,
            ErrorMessage = $"Failed to initialize: {ex.Message}"
        });
    }
}
```

## Configuration and customization

Allow users to configure your framework through:

### Configuration files

```csharp
var config = serviceProvider.GetConfiguration();
var parallelism = config["MyTestFramework:Parallelism"];
var timeout = config["MyTestFramework:DefaultTimeout"];
```

Users can provide settings in `[assemblyname].testingplatformconfig.json`:

```json
{
  "MyTestFramework": {
    "Parallelism": 4,
    "DefaultTimeout": "30s"
  }
}
```

### Command-line options

Implement `ICommandLineOptionsProvider` to add custom options. For more information, see [Command-line options provider](microsoft-testing-platform-extensions.md#the-icommandlineoptionsprovider-extension).

## Test framework checklist

Use this checklist to ensure your test framework is complete:

- [ ] Implements `ITestFramework` with all required methods
- [ ] Implements `IExtension` with descriptive properties
- [ ] Implements `IDataProducer` declaring `TestNodeUpdateMessage`
- [ ] Implements `ITestFrameworkCapabilities` (can be empty initially)
- [ ] Generates stable, unique test IDs
- [ ] Calls `context.Complete()` after processing each request
- [ ] Publishes test results via `IMessageBus`
- [ ] Uses appropriate state properties (Passed, Failed, Skipped, etc.)
- [ ] Honors cancellation tokens
- [ ] Handles errors gracefully
- [ ] Returns meaningful session results
- [ ] Supports async initialization if needed
- [ ] Implements cleanup if needed
- [ ] Provides configuration options
- [ ] Includes diagnostic logging

## Next steps

- **Add command-line options**: [ICommandLineOptionsProvider](microsoft-testing-platform-extensions.md#the-icommandlineoptionsprovider-extension)
- **Understand capabilities**: [Capabilities system](microsoft-testing-platform-architecture-capabilities.md)
- **Use platform services**: [Platform services](microsoft-testing-platform-architecture-services.md)
- **View complete examples**: [Sample code](https://github.com/microsoft/testfx/tree/main/samples/public/TestingPlatformExamples)

## See also

- [Architecture overview](microsoft-testing-platform-architecture-overview.md)
- [Extensions guide](microsoft-testing-platform-extensions.md)
- [Platform services](microsoft-testing-platform-architecture-services.md)
