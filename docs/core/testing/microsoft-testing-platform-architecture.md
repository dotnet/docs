---
title: Create custom extensions for Microsoft.Testing.Platform
description: Learn how to build custom test frameworks and extensions for Microsoft.Testing.Platform.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Create custom extensions

This article is for developers building custom test frameworks or extensions for Microsoft.Testing.Platform.

> [!NOTE]
> For complete sample code, see the [TestingPlatformExamples](https://github.com/microsoft/testfx/tree/main/samples/public/TestingPlatformExamples) in the Microsoft Test Framework repository.

## Extension point summary

| Extension point | In/Out of process | Purpose |
|---|---|---|
| [ITestFramework](./microsoft-testing-platform-architecture-test-framework.md) | In-process | The only mandatory extension. Discovers and runs tests. |
| [IDataConsumer](./microsoft-testing-platform-architecture-extensions.md#the-idataconsumer-extensions) | In-process | Subscribes to and processes test data from the message bus. |
| [ITestSessionLifetimeHandler](./microsoft-testing-platform-architecture-extensions.md#the-itestsessionlifetimehandler-extensions) | In-process | Runs code before and after a test session. |
| [ITestApplicationLifecycleCallbacks](./microsoft-testing-platform-architecture-extensions.md#the-itestapplicationlifecyclecallbacks-extensions) | In-process | Runs code at the very start and very end of the test host. |
| [ICommandLineOptionsProvider](./microsoft-testing-platform-architecture-extensions.md#the-icommandlineoptionsprovider-extensions) | Both | Adds custom command-line options. |
| [ITestHostEnvironmentVariableProvider](./microsoft-testing-platform-architecture-extensions.md#the-itesthostenvironmentvariableprovider-extensions) | Out-of-process | Sets environment variables before the test host starts. |
| [ITestHostProcessLifetimeHandler](./microsoft-testing-platform-architecture-extensions.md#the-itesthostprocesslifetimehandler-extensions) | Out-of-process | Observes the test host process externally. |

## In-process vs out-of-process extensions

Extensions are categorized into two types:

- **In-process extensions** run inside the test host process, alongside the test framework. Register them through `builder.TestHost`:

    ```csharp
    var builder = await TestApplication.CreateBuilderAsync(args);
    builder.TestHost.AddXXX(/* ... */);
    ```

- **Out-of-process extensions** run in a separate process that observes the test host. Register them through `builder.TestHostControllers`:

    ```csharp
    var builder = await TestApplication.CreateBuilderAsync(args);
    builder.TestHostControllers.AddXXX(/* ... */);
    ```

Out-of-process extensions are needed when:

- You need to set environment variables before the test host starts.
- You need to monitor the test host externally because user code might crash or hang the process.

When any out-of-process extension is registered, the platform starts a second process automatically.

## The `IExtension` interface

All extension points inherit from `IExtension`, which provides identification and opt-in/opt-out:

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

- `Uid`: A unique identifier for the extension. Choose a unique value to avoid conflicts.
- `Version`: The version of the extension, using [semantic versioning](https://semver.org/).
- `DisplayName`: A user-friendly name that appears in logs and `--info` output.
- `Description`: A description that appears in `--info` output.
- `IsEnabledAsync()`: Return `false` to exclude the extension from the session. Typically decisions are based on configuration or command-line options.

## What to read next

- [Build a test framework](./microsoft-testing-platform-architecture-test-framework.md): Create a custom `ITestFramework` implementation, handle requests, and report test results.
- [Build extensions](./microsoft-testing-platform-architecture-extensions.md): Create in-process and out-of-process extensions such as data consumers, session handlers, and process monitors.
- [VSTest Bridge](./microsoft-testing-platform-extensions-vstest-bridge.md): Simplify migration of existing VSTest-based test frameworks to Microsoft.Testing.Platform.
- [Capabilities](./microsoft-testing-platform-architecture-capabilities.md): Declare and query framework and extension capabilities.
- [Services](./microsoft-testing-platform-architecture-services.md): Access configuration, logging, message bus, and other platform services.
