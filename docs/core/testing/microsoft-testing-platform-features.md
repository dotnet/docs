---
title: Microsoft.Testing.Platform features
description: Learn about the various Microsoft.Testing.Platform features, both built-in and available as extensions.
author: nohwnd
ms.author: jajares
ms.date: 07/03/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform (MTP) features

MTP ships with built-in features and can be extended through NuGet packages.

When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), installing an extension NuGet package is all you need — extensions are automatically detected and registered, and the entry point is generated for you.

If you opt out of the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`, you must register extensions manually in your `Main` method. Each extension page documents the manual registration call.

Extensions that require a NuGet package are shipped with their own licensing model (some less permissive), be sure to refer to the license associated with the extensions you want to use.

Some extensions are *experimental*: their APIs are annotated with the `TPEXP` diagnostic and might change in a future release, so you must acknowledge the diagnostic to use them. Experimental extensions are marked **(experimental)** in the following lists. For more information, see [Microsoft.Testing.Platform diagnostics](https://aka.ms/testingplatform/diagnostics).

## Start here

Use the following path based on your goal:

- Find command-line switches in one place: [MTP CLI options reference](./microsoft-testing-platform-cli-options.md).
- Add capabilities to your test runs: use the feature pages in this article.
- Create your own extension: [MTP architecture](./microsoft-testing-platform-architecture.md), [Extension points](./microsoft-testing-platform-architecture-extensions.md), and [Services](./microsoft-testing-platform-architecture-services.md).

## Choose by scenario

- Need to customize terminal output: [Terminal output](./microsoft-testing-platform-terminal-output.md) (built-in)
- Need TRX or Azure DevOps reports: [Test reports](./microsoft-testing-platform-test-reports.md) (extension)
- Need GitHub Actions-native output (log groups, annotations, and job summary): [GitHub Actions report](https://www.nuget.org/packages/Microsoft.Testing.Extensions.GitHubActionsReport) (extension, experimental)
- Need coverage data: [Code coverage](./microsoft-testing-platform-code-coverage.md) (extension)
- Need crash or hang diagnostics: [Crash and hang dumps](./microsoft-testing-platform-crash-hang-dumps.md) (extension)
- Need to retry failed tests: [Retry](./microsoft-testing-platform-retry.md#retry) (extension)
- Need hot reload support: [Hot Reload](./microsoft-testing-platform-hot-reload.md) (extension)
- Need Microsoft Fakes support: [Microsoft Fakes](./microsoft-testing-platform-fakes.md) (extension)
- Need OpenTelemetry traces and metrics: [OpenTelemetry](./microsoft-testing-platform-open-telemetry.md) (extension)
- Telemetry data collection and opt-out: [Telemetry](./microsoft-testing-platform-telemetry.md) (extension)

## Built-in features

These features are part of the core platform and don't require additional NuGet packages.

**[Terminal output](./microsoft-testing-platform-terminal-output.md)**

Status and progress reporting to the terminal: output modes, ANSI support, and progress indicators.

## Extension features

These features require installing NuGet packages.

**[Test reports](./microsoft-testing-platform-test-reports.md)**

Generate test report files (TRX, Azure DevOps).

**[GitHub Actions report](https://www.nuget.org/packages/Microsoft.Testing.Extensions.GitHubActionsReport)** (experimental, introduced in MTP 2.3.0)

Emit GitHub Actions-native workflow commands so test runs produce a first-class experience: per-assembly log groups, failure annotations (surfaced in the workflow **Annotations** tab and, when the source location resolves, on the pull request's **Files changed** diff), a Markdown job summary appended to `GITHUB_STEP_SUMMARY`, and slow-test notices. The extension activates automatically when the `GITHUB_ACTIONS` environment variable is `true`, or elsewhere with the `--report-gh` switch. Each feature can be turned on or off individually with the `--report-gh-groups`, `--report-gh-annotations`, `--report-gh-step-summary`, and `--report-gh-slow-test-notices` options, and the slow-test threshold is set with `--report-gh-slow-test-threshold`. Register it manually with `builder.AddGitHubActionsProvider()`.

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

**[Video recorder](https://www.nuget.org/packages/Microsoft.Testing.Extensions.VideoRecorder)** (experimental, introduced in MTP 2.3.0)

Record the screen during a test run. It requires `ffmpeg` to be available on the machine and is enabled with the `--capture-video` option. Register it manually with `builder.AddVideoRecorderProvider()`.

**[Packaged app deployment](https://www.nuget.org/packages/Microsoft.Testing.Extensions.PackagedApp)** (experimental, introduced in MTP 2.3.0)

A reference extension that uses the experimental `ITestHostLauncher` extension point to deploy and launch a packaged-app test host. Register it manually with `builder.AddPackagedAppDeployment()`.

## Microsoft.Extensions integration

These extensions bridge Microsoft.Testing.Platform to the `Microsoft.Extensions.*` libraries your application already uses.

**[Logging bridge](https://www.nuget.org/packages/Microsoft.Testing.Extensions.Logging)** (experimental, introduced in MTP 2.3.0)

The Microsoft.Testing.Extensions.Logging package bridges Microsoft.Testing.Platform diagnostics to <xref:Microsoft.Extensions.Logging.ILogger>, so platform and extension logs flow through the same `Microsoft.Extensions.Logging` pipeline your application already uses. Register it manually with the following call:

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddMicrosoftExtensionsLogging(logging => logging.AddConsole());
```
