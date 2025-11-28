---
title: Microsoft.Testing.Platform architecture overview
description: Learn about the high-level architecture of Microsoft.Testing.Platform, including design principles, process models, and extension points.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 11/27/2025
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform architecture overview

Microsoft.Testing.Platform is a flexible, extensible testing platform built on key architectural principles that ensure reliability, performance, and compatibility across all .NET scenarios. This article provides a high-level overview of the platform's architecture to help you understand how components work together and decide which extension points to use.

## Architectural principles

The platform is built on several core principles:

- **Determinism**: Running the same tests in different contexts (local, CI) produces the same results. The runtime doesn't rely on reflection or dynamic .NET runtime features to coordinate test runs.

- **Runtime transparency**: The test runtime doesn't interfere with test framework code. It doesn't create isolated contexts like `AppDomain` or `AssemblyLoadContext`, and it doesn't use reflection or custom assembly resolvers.

- **Compile-time registration**: Extensions, test frameworks, and both in-process and out-of-process extensions are registered at compile time to ensure determinism and detect inconsistencies early.

- **Zero dependencies**: The platform core is a single .NET assembly, `Microsoft.Testing.Platform.dll`, with no dependencies other than the supported runtimes.

- **Hostable**: The test runtime can be hosted in any .NET application—not just console apps. You can run tests in devices, browsers, or any context where .NET runs.

- **Support all .NET form factors**: The platform supports current and future .NET form factors, including Native AOT.

- **Performant**: The platform orchestrates test runs efficiently without bloating the runtime with non-essential code.

- **Extensible**: Built on well-defined extension points that allow maximum customization of test execution.

## Process architecture

Microsoft.Testing.Platform uses a flexible process model to accommodate different testing scenarios. Understanding this model is key to choosing the right extension points.

### Single-process execution

In the simplest scenario, your test application runs as a single process:

:::image type="content" source="./media/platform-testhost.png" lightbox="./media/platform-testhost.png" alt-text="Diagram showing a single test host process executing tests.":::

This single process (the **test host**) contains:

- Your test framework
- Your tests
- In-process extensions

This model is sufficient when extensions don't need to:

- Modify environment variables before the process starts
- Monitor the test process from outside (to detect hangs or crashes)

### Multi-process execution

When you register out-of-process extensions, the platform creates a multi-process architecture:

:::image type="content" source="./media/platform-testhostcontroller-testhost.png" lightbox="./media/platform-testhostcontroller-testhost.png" alt-text="Diagram showing test host controller and test host processes.":::

The **test host controller** (parent process):

- Sets up the environment
- Spawns the **test host** (child process) with appropriate configuration
- Monitors test execution from outside
- Remains stable even if test code crashes the test host

This model enables scenarios like:

- Code coverage (requires environment variable setup)
- Hang detection (monitors process from outside)
- Crash recovery (parent survives child crashes)

## Component types

The platform consists of three main component types:

### Test framework (mandatory)

The test framework is the only mandatory component. It:

- Discovers tests in your code
- Executes tests
- Reports results to the platform

Examples: MSTest, NUnit, xUnit, TUnit

For more information, see [Build a test framework](microsoft-testing-platform-architecture-testframework.md).

### In-process extensions (optional)

In-process extensions run inside the test host process alongside your tests. They can:

- Consume test results as they're produced
- Add custom command-line options
- Participate in session lifecycle events
- Generate reports or artifacts

Common uses:

- TRX report generation
- Custom logging
- Test filtering
- Result aggregation

For more information, see [In-process extensions](microsoft-testing-platform-extensions.md#in-process-extensions).

### Out-of-process extensions (optional)

Out-of-process extensions run in the test host controller, separate from your tests. They can:

- Modify test host environment variables
- Monitor test execution externally
- Survive test host crashes
- Implement cross-cutting concerns safely

Common uses:

- Code coverage collection
- Hang detection
- Performance monitoring
- Resource cleanup

For more information, see [Out-of-process extensions](microsoft-testing-platform-extensions.md#out-of-process-extensions).

## Communication infrastructure

The platform provides several mechanisms for components to communicate and share data.

### Message bus

The message bus is the central communication hub using a publish-subscribe pattern:

:::image type="content" source="./media/message-bus.png" lightbox="./media/message-bus.png" alt-text="Diagram showing message bus with producers and consumers.":::

- **Producers** publish data to the bus (test frameworks, extensions)
- **Consumers** subscribe to specific data types
- Enables loose coupling between components
- Supports version-independent evolution

For more information, see [IMessageBus service](microsoft-testing-platform-architecture-services.md#the-imessagebus-service).

### Capabilities

The capability system allows components to declare and discover features:

```csharp
// Extension queries test framework capabilities
var capabilities = serviceProvider.GetRequiredService<ITestFrameworkCapabilities>();
var parallelism = capabilities.GetCapability<IDisableParallelismCapability>();

if (parallelism?.CanDisableParallelism == true)
{
    parallelism.Enable();
}
```

This enables:

- Feature negotiation between components
- Graceful degradation when features aren't available
- Version-independent compatibility

For more information, see [Capabilities system](microsoft-testing-platform-architecture-capabilities.md).

### Services

The platform provides services through dependency injection:

- **IConfiguration**: Access configuration from JSON files or environment variables
- **ICommandLineOptions**: Parse and access command-line arguments
- **IMessageBus**: Publish and subscribe to test data
- **ILoggerFactory**: Create loggers for diagnostic output
- **IOutputDevice**: Send information to the console or other output devices

For more information, see [Platform services](microsoft-testing-platform-architecture-services.md).

## Extension lifecycle

Understanding when extensions are invoked helps you choose the right extension point.

### High-level flow

1. **Setup phase** (out-of-process):
   - Environment variable providers configure test host environment
   - Process lifetime handlers prepare for test host start

2. **Test host startup** (in-process):
   - Application lifecycle callbacks run first
   - Session lifetime handlers initialize
   - Test framework creates session

3. **Test execution** (in-process):
   - Test framework processes requests (discovery, execution)
   - Data consumers receive and process test results
   - Results flow through message bus

4. **Teardown** (in-process):
   - Test framework closes session
   - Session lifetime handlers finalize
   - Application lifecycle callbacks complete
   - Extensions clean up

5. **Monitoring** (out-of-process):
   - Process lifetime handlers observe test host exit

For a detailed execution order, see [Extension execution order](microsoft-testing-platform-extensions.md#extension-execution-order).

## Choosing the right extension point

Use this decision guide to select appropriate extension points:

| If you need to... | Use this extension point |
|-------------------|--------------------------|
| Discover and run tests | [Test framework](microsoft-testing-platform-architecture-testframework.md) (mandatory) |
| Add command-line options | [ICommandLineOptionsProvider](microsoft-testing-platform-extensions.md#the-icommandlineoptionsprovider-extension) |
| Consume test results | [IDataConsumer](microsoft-testing-platform-extensions.md#the-idataconsumer-extension) |
| Run code before/after test session | [ITestSessionLifetimeHandler](microsoft-testing-platform-extensions.md#the-itestsessionlifetimehandler-extension) |
| Run code at process start/end | [ITestApplicationLifecycleCallbacks](microsoft-testing-platform-extensions.md#the-itestapplicationlifecyclecallbacks-extension) |
| Set environment variables | [ITestHostEnvironmentVariableProvider](microsoft-testing-platform-extensions.md#the-itesthostenvironmentvariableprovider-extension) |
| Monitor test process externally | [ITestHostProcessLifetimeHandler](microsoft-testing-platform-extensions.md#the-itesthostprocesslifetimehandler-extension) |

## Registration patterns

### Register a test framework

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

builder.RegisterTestFramework(
    serviceProvider => new TestFrameworkCapabilities(),
    (capabilities, serviceProvider) => new MyTestFramework(capabilities, serviceProvider));

using var app = await builder.BuildAsync();
return await app.RunAsync();
```

### Register in-process extensions

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// Command-line options (available in both processes)
builder.CommandLine.AddProvider(() => new CustomCommandLineOptions());

// In-process extensions
builder.TestHost.AddDataConsumer(serviceProvider => new CustomDataConsumer());
builder.TestHost.AddTestSessionLifetimeHandle(serviceProvider => new CustomLifetimeHandler());

using var app = await builder.BuildAsync();
return await app.RunAsync();
```

### Register out-of-process extensions

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

// Out-of-process extensions
builder.TestHostControllers.AddEnvironmentVariableProvider(
    serviceProvider => new CustomEnvironmentVariableProvider());
builder.TestHostControllers.AddProcessLifetimeHandler(
    serviceProvider => new CustomProcessMonitor());

using var app = await builder.BuildAsync();
return await app.RunAsync();
```

## Next steps

Now that you understand the high-level architecture, explore these areas based on your needs:

- **Building a test framework**: [Test framework guide](microsoft-testing-platform-architecture-testframework.md)
- **Building extensions**: [Extensions guide](microsoft-testing-platform-extensions.md)
- **Understanding capabilities**: [Capabilities system](microsoft-testing-platform-architecture-capabilities.md)
- **Using platform services**: [Services reference](microsoft-testing-platform-architecture-services.md)
- **Working examples**: [Sample code](https://github.com/microsoft/testfx/tree/main/samples/public/TestingPlatformExamples)

## See also

- [Microsoft.Testing.Platform introduction](microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md)
- [Microsoft.Testing.Platform FAQ](microsoft-testing-platform-faq.md)
