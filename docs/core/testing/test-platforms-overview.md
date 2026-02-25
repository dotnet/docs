---
title: Test platforms overview for .NET
description: Learn how VSTest and Microsoft.Testing.Platform differ, and choose the right test platform for your .NET test projects.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Test platforms overview for .NET

In .NET, a test framework and a test platform are different components.

- The test framework defines the test model you write against, such as MSTest, NUnit, xUnit.net, or TUnit.
- The test platform runs tests, integrates with IDEs and CLI, and provides shared extension points.

You can choose between two test platforms:

- **VSTest**
- **Microsoft.Testing.Platform (MTP)**

> [!WARNING]
> Don't mix VSTest and Microsoft.Testing.Platform test projects in the same repository run configuration.
>
> Choose one platform for your repository test workflow, and configure test projects, CI, and tooling consistently for that platform.

## How to choose your platform

Use the following scenarios to choose quickly.

| Use case | Choose | Why |
|---|---|---|
| You need Native AOT or trimming test execution scenarios. | Microsoft.Testing.Platform | MTP supports these modern deployment scenarios, while VSTest doesn't. |
| You need to mix .NET tests and non-.NET test adapters (for example JavaScript or C++ adapters). | VSTest | VSTest supports mixed-language adapter scenarios, while MTP is .NET-specific. |
| You want test projects to behave like regular executables (`dotnet run`, direct executable run, `dotnet watch`, and startup-project F5 flows). | Microsoft.Testing.Platform | MTP is executable-first, so test apps run like standard .NET apps in local and CI workflows. |
| You rely on long-established integrations across Microsoft and non-Microsoft tooling. | VSTest | VSTest has the longest compatibility track record across existing products, tasks, and pipelines. |
| You prioritize reproducibility and tighter control of extension loading across machines. | Microsoft.Testing.Platform | MTP favors explicit, build-time extension registration, which reduces machine-dependent behavior from dynamically discovered components and can simplify security review. |
| You need a minimal core with optional features that you can disable per environment. | Microsoft.Testing.Platform | MTP uses a lightweight core with opt-in extensions. If an extension introduces unsupported dependencies or version conflicts in a specific environment, you can remove or disable that extension. |
| You prefer strict defaults and explicit behavior. | Microsoft.Testing.Platform | MTP favors deterministic execution with explicit checks. For example, it can fail when no tests run, reduce environment-dependent variability, and avoid implicit discovery and execution heuristics. |
| You prefer softer, broad backward-compatible defaults. | VSTest | VSTest prioritizes compatibility-oriented defaults for diverse, existing toolchains. |
| You are blocked by a VSTest-specific issue or behavior in your current workflow. | Microsoft.Testing.Platform | In many scenarios, the same workflow isn't affected when moved to MTP because of differences in runtime model and extension architecture. |

If your specific use case isn't listed, both platforms are valid choices.

## Integration and tooling support

| Integration area | VSTest | Microsoft.Testing.Platform |
|---|---|---|
| IDE integration | Mature integration across Visual Studio and other tools that depend on VSTest protocol and adapters. | Supported in Visual Studio and Visual Studio Code scenarios, with ongoing integration work in parts of the ecosystem. |
| CI and external tools | Broad support across long-established Microsoft and non-Microsoft tools and tasks. In Azure DevOps, you can use either the VSTest task (`VSTest@3`, `vstest.console`) or the .NET task (`DotNetCoreCLI@2`, `dotnet test`). | Works in CI and modern .NET workflows, but some third-party integrations might still lag behind VSTest. In Azure DevOps, use the .NET task (`DotNetCoreCLI@2`, `dotnet test`). |
| `dotnet test` behavior | Default VSTest mode. VSTest arguments and behavior apply. | Native MTP mode is available in .NET 10 SDK and later. Before .NET 10 SDK, MTP ran through VSTest mode with limitations (`TestingPlatformDotnetTestSupport`, plus the extra `--` argument separator). |

For complete details about `dotnet test` modes and arguments, see [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md).

## Start from your test framework

### If you choose VSTest

- MSTest: [Run tests with MSTest](./unit-testing-mstest-running-tests.md)
- NUnit: [NUnit and Microsoft.Testing.Platform](https://docs.nunit.org/articles/vs-test-adapter/NUnit-And-Microsoft-Test-Platform.html)
- xUnit.net: [Get started with xUnit.net](https://xunit.net/docs/getting-started/v2/getting-started)
- TUnit: Not supported on VSTest. Use Microsoft.Testing.Platform.

### If you choose Microsoft.Testing.Platform

- MSTest: [Run tests with MSTest](./unit-testing-mstest-running-tests.md)
- NUnit: [Microsoft.Testing.Platform support in NUnit (NUnit runner)](./unit-testing-nunit-runner-intro.md)
- xUnit.net: [Microsoft Testing Platform (xUnit.net v3)](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform)
- TUnit: [TUnit documentation](https://thomhurst.github.io/TUnit/)

## Next steps

- Learn MTP concepts: [Microsoft.Testing.Platform overview](./microsoft-testing-platform-intro.md)
- Understand VSTest options: [VSTest options](/visualstudio/test/vstest-console-options)
- Migrate from VSTest: [Migrate from VSTest to Microsoft.Testing.Platform](./migrating-vstest-microsoft-testing-platform.md)
- Add capabilities: [Microsoft.Testing.Platform features](./microsoft-testing-platform-features.md)
