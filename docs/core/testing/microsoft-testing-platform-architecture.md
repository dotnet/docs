---
title: Microsoft.Testing.Platform architecture
description: Navigation page for Microsoft.Testing.Platform architecture documentation, including guides for building test frameworks and extensions.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 11/27/2025
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform architecture

This article provides links to comprehensive documentation about Microsoft.Testing.Platform's architecture, extensibility model, and services.

## Getting started

If you're new to Microsoft.Testing.Platform architecture, start here:

- **[Architecture overview](microsoft-testing-platform-architecture-overview.md)**: High-level concepts, process models, and component types
- **[Microsoft.Testing.Platform introduction](microsoft-testing-platform-intro.md)**: Platform features and capabilities

## Building components

### Test frameworks

Test frameworks are the core components that discover and execute tests:

- **[Build a test framework](microsoft-testing-platform-architecture-testframework.md)**: Complete guide to creating custom test frameworks
  - Register test frameworks
  - Handle discovery and execution requests
  - Report test results
  - Test node properties reference

### Extensions

Extensions add custom functionality to the platform:

- **[Build extensions](microsoft-testing-platform-extensions.md)**: Guide to building platform extensions
  - In-process extensions (data consumers, lifetime handlers)
  - Out-of-process extensions (environment providers, process monitors)
  - Command-line option providers
  - Extension execution order

## Core concepts

### Capabilities

The capabilities system enables feature negotiation between components:

- **[Capabilities system](microsoft-testing-platform-architecture-capabilities.md)**: How components discover and declare features
  - Query capabilities
  - Design custom capabilities
  - Built-in capabilities
  - Best practices

### Services

Platform services provide common functionality:

- **[Services reference](microsoft-testing-platform-architecture-services.md)**: Comprehensive service documentation
  - IConfiguration: Configuration management
  - ICommandLineOptions: Command-line parsing
  - IMessageBus: Inter-component communication
  - ILoggerFactory: Diagnostic logging
  - IOutputDevice: Console output
  - IPlatformInformation: Platform details

## Quick reference

### Component registration patterns

**Test framework**:

```csharp
builder.RegisterTestFramework(
    sp => new MyFrameworkCapabilities(),
    (cap, sp) => new MyFramework(cap, sp));
```

**In-process extension**:

```csharp
builder.TestHost.AddDataConsumer(sp => new MyConsumer(sp));
```

**Out-of-process extension**:

```csharp
builder.TestHostControllers.AddProcessLifetimeHandler(sp => new MyMonitor(sp));
```

**Command-line options** (both contexts):

```csharp
builder.CommandLine.AddProvider(() => new MyOptions());
```

### Extension types at a glance

| Extension | Context | Use case |
|-----------|---------|----------|
| IDataConsumer | In-process | Process test results, generate reports |
| ITestSessionLifetimeHandler | In-process | Run code before/after test session |
| ITestApplicationLifecycleCallbacks | In-process | Run code at process start/end |
| ICommandLineOptionsProvider | Both | Add custom command-line options |
| ITestHostEnvironmentVariableProvider | Out-of-process | Set environment variables for test host |
| ITestHostProcessLifetimeHandler | Out-of-process | Monitor test host externally |

### Process architecture

**Single process** (no out-of-process extensions):

```
┌─────────────────┐
│   Test Host     │
│  ┌───────────┐  │
│  │   Tests   │  │
│  └───────────┘  │
│  ┌───────────┐  │
│  │Framework  │  │
│  └───────────┘  │
│  ┌───────────┐  │
│  │Extensions │  │
│  └───────────┘  │
└─────────────────┘
```

**Multi-process** (with out-of-process extensions):

```
┌───────────────────┐
│ Test Host         │
│   Controller      │
│  ┌─────────────┐  │
│  │ Out-of-proc │  │
│  │ Extensions  │  │
│  └─────────────┘  │
│        │          │
│        ▼          │
│  ┌─────────────┐  │
│  │ Test Host   │  │
│  │  (spawned)  │  │
│  └─────────────┘  │
└───────────────────┘
```

## Additional resources

- **[Sample code](https://github.com/microsoft/testfx/tree/main/samples/public/TestingPlatformExamples)**: Complete working examples
- **[Exit codes](microsoft-testing-platform-exit-codes.md)**: Platform exit code reference
- **[FAQ](microsoft-testing-platform-faq.md)**: Frequently asked questions

## See also

- [Microsoft.Testing.Platform vs VSTest](microsoft-testing-platform-vs-vstest.md)
- [MSTest runner](unit-testing-mstest-runner-intro.md)
- [NUnit runner](unit-testing-nunit-runner-intro.md)
