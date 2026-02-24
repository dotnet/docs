---
title: Microsoft.Testing.Platform overview
description: Learn about Microsoft.Testing.Platform, a lightweight way to run tests without depending on the .NET SDK.
author: Evangelink
ms.author: amauryleve
ms.date: 03/17/2024
---

# Microsoft.Testing.Platform overview

Microsoft.Testing.Platform is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts, including continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Test Explorer. The Microsoft.Testing.Platform is embedded directly in your test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

> [!TIP]
> If you need help choosing between VSTest and Microsoft.Testing.Platform, start with [Test platforms overview](./test-platforms-overview.md).

Use this article when you already decided to use Microsoft.Testing.Platform and you want to understand its model, capabilities, and operational behavior.

`Microsoft.Testing.Platform` is open source. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Start here

Use the following path, based on what you need next:

- Run and debug tests from CLI, IDE, or CI: [Run and debug tests](./microsoft-testing-platform-run-and-debug.md)
- Understand platform behavior in CLI: [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
- Find platform and extension CLI switches in one place: [Microsoft.Testing.Platform CLI options reference](./microsoft-testing-platform-cli-options.md)
- Configure framework runners: [Run tests with MSTest](./unit-testing-mstest-running-tests.md) or [Microsoft.Testing.Platform support in NUnit (NUnit runner)](./unit-testing-nunit-runner-intro.md)
- Migrate an existing VSTest setup: [Migrate from VSTest to Microsoft.Testing.Platform](./migrating-vstest-microsoft-testing-platform.md)
- Add diagnostics, coverage, and reporting: [Microsoft.Testing.Platform extensions](./microsoft-testing-platform-extensions.md)
- Build your own extension: [Microsoft.Testing.Platform architecture](./microsoft-testing-platform-architecture.md), [Extension points](./microsoft-testing-platform-architecture-extensions.md), and [Services](./microsoft-testing-platform-architecture-services.md)

## Microsoft.Testing.Platform pillars

This new testing platform is built on the .NET Developer Experience Testing team's experience and aims to address the challenges encountered since the release of .NET Core in 2016. While there's a high level of compatibility between the .NET Framework and the .NET Core/.NET, some key features like the plugin-system and the new possible form factors of .NET compilations have made it complex to evolve or fully support the new runtime feature with the current [VSTest platform](https://github.com/microsoft/vstest) architecture.

The main driving factors for the evolution of the new testing platform are detailed in the following:

* **Determinism**: Ensuring that running the same tests in different contexts (local, CI) will produce the same result. The new runtime does not rely on reflection or any other dynamic .NET runtime feature to coordinate a test run.

* **Runtime transparency**: The test runtime does not interfere with the test framework code, it does not create isolated contexts like `AppDomain` or `AssemblyLoadContext`, and it does not use reflection or custom assembly resolvers.

* **Compile-time registration of extensions**: Extensions, such as test frameworks and in/out-of-process extensions, are registered during compile-time to ensure determinism and to facilitate detection of inconsistencies.

* **Zero dependencies**: The core of the platform is a single .NET assembly, `Microsoft.Testing.Platform.dll`, which has no dependencies other than the supported runtimes.

* **Hostable**: The test runtime can be hosted in any .NET application. While a console application is commonly used to run tests, you can create a test application in any type of .NET application. This allows you to run tests within special contexts, such as devices or browsers, where there may be limitations.

* **Support all .NET form factors**: Support current and future .NET form factors, including Native AOT.

* **Performant**: Finding the right balance between features and extension points to avoid bloating the runtime with non-fundamental code. The new test platform is designed to "orchestrate" a test run, rather than providing implementation details on how to do it.

* **Extensible enough**: The new platform is built on extensibility points to allow for maximum customization of runtime execution. It allows you to configure the test process host, observe the test process, and consume information from the test framework within the test host process.

* **Single module deploy**: The hostability feature enables a single module deploy model, where a single compilation result can be used to support all extensibility points, both out-of-process and in-process, without the need to ship different executable modules.

## Supported test frameworks

* MSTest. In MSTest, the support of `Microsoft.Testing.Platform` is done via [MSTest runner](unit-testing-mstest-running-tests.md).
* NUnit. In NUnit, the support of `Microsoft.Testing.Platform` is done via [NUnit runner](unit-testing-nunit-runner-intro.md).
* xUnit.net. For more information, see [Microsoft Testing Platform (xUnit.net v3)](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform) and [Microsoft Testing Platform (xUnit.net v2)](https://xunit.net/docs/getting-started/v2/microsoft-testing-platform) from the xUnit.net documentation.
* TUnit: entirely constructed on top of the `Microsoft.Testing.Platform`, for more information, see [TUnit documentation](https://tunit.dev/).

## Supported target frameworks

Microsoft.Testing.Platform supports .NET (.NET 8 and later), .NET Framework (versions 4.6.2 and later), and targets NETStandard 2.0 for maximum compatibility with other runtimes.

## Run and debug tests

For detailed guidance on running and debugging MTP test projects from CLI, Visual Studio, Visual Studio Code, and CI pipelines, see [Run and debug tests](./microsoft-testing-platform-run-and-debug.md).

## Options

For the full list of platform and extension command-line options, see [Microsoft.Testing.Platform CLI options reference](./microsoft-testing-platform-cli-options.md).

## MSBuild integration

The NuGet package [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) provides various integrations for `Microsoft.Testing.Platform` with MSBuild:

- Support for `dotnet test`. For more information, see [Testing with dotnet test](./unit-testing-with-dotnet-test.md).
- Support for `ProjectCapability` required by `Visual Studio` and `Visual Studio Code` Test Explorers.
- Automatic generation of the entry point (`Main` method).
- Automatic generation of the configuration file.

> [!NOTE]
> This integration works in a transitive way (a project that references another project referencing this package will behave as if it references the package) and can be disabled through the `IsTestingPlatformApplication` MSBuild property.

## See also

- [Test platforms overview](test-platforms-overview.md)
- [Microsoft.Testing.Platform extensions](microsoft-testing-platform-extensions.md)
- [Microsoft.Testing.Platform telemetry](microsoft-testing-platform-extensions-telemetry.md)
- [Microsoft.Testing.Platform troubleshooting](microsoft-testing-platform-troubleshooting.md)
