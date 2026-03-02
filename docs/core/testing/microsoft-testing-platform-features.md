---
title: Microsoft.Testing.Platform features
description: Learn about the various Microsoft.Testing.Platform features, both built-in and available as extensions.
author: nohwnd
ms.author: jajares
ms.date: 02/25/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform features

Microsoft.Testing.Platform ships with built-in features and can be extended through NuGet packages.

When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), installing an extension NuGet package is all you need — extensions are automatically detected and registered, and the entry point is generated for you.

If you opt out of the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`, you must register extensions manually in your `Main` method. Each extension page documents the manual registration call.

Extensions that require a NuGet package are shipped with their own licensing model (some less permissive), be sure to refer to the license associated with the extensions you want to use.

## Start here

Use the following path based on your goal:

- Find command-line switches in one place: [Microsoft.Testing.Platform CLI options reference](./microsoft-testing-platform-cli-options.md).
- Add capabilities to your test runs: use the feature pages in this article.
- Create your own extension: [Microsoft.Testing.Platform architecture](./microsoft-testing-platform-architecture.md), [Extension points](./microsoft-testing-platform-architecture-extensions.md), and [Services](./microsoft-testing-platform-architecture-services.md).

## Choose by scenario

- Need to customize terminal output: [Terminal output](./microsoft-testing-platform-terminal-output.md) (built-in)
- Need TRX or Azure DevOps reports: [Test reports](./microsoft-testing-platform-test-reports.md) (extension)
- Need coverage data: [Code coverage](./microsoft-testing-platform-code-coverage.md) (extension)
- Need crash or hang diagnostics: [Crash and hang dumps](./microsoft-testing-platform-crash-hang-dumps.md) (extension)
- Need to retry failed tests: [Retry](./microsoft-testing-platform-retry.md#retry) (extension)
- Need hot reload support: [Hot Reload](./microsoft-testing-platform-hot-reload.md) (extension)
- Need Microsoft Fakes support: [Microsoft Fakes](./microsoft-testing-platform-fakes.md) (extension)
- Need OpenTelemetry traces and metrics: [OpenTelemetry](./microsoft-testing-platform-open-telemetry.md) (extension)
- Need telemetry opt-out information: [Telemetry](./microsoft-testing-platform-telemetry.md) (extension)

## Built-in features

These features are part of the core platform and don't require additional NuGet packages.

**[Terminal output](./microsoft-testing-platform-terminal-output.md)**

Status and progress reporting to the terminal: output modes, ANSI support, and progress indicators.

## Extension features

These features require installing NuGet packages.

**[Test reports](./microsoft-testing-platform-test-reports.md)**

Generate test report files (TRX, Azure DevOps).

**[Code coverage](./microsoft-testing-platform-code-coverage.md)**

Collect code coverage data during test execution.

**[Crash and hang dumps](./microsoft-testing-platform-crash-hang-dumps.md)**

Collect process dump files when the test host crashes or hangs.

**[OpenTelemetry](./microsoft-testing-platform-open-telemetry.md)**

Emit traces and metrics through OpenTelemetry during test runs.

**[Retry](./microsoft-testing-platform-retry.md)**

Retry failed tests with configurable policies.

**[Hot Reload](./microsoft-testing-platform-hot-reload.md)**

Run tests with hot reload support for rapid iteration.

**[Microsoft Fakes](./microsoft-testing-platform-fakes.md)**

Run tests that use Microsoft Fakes for stubs and shims.

**[Telemetry](./microsoft-testing-platform-telemetry.md)**

Telemetry collection. Learn how to opt out and what data is collected.
