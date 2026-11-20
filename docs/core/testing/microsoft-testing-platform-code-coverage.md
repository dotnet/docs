---
title: Microsoft.Testing.Platform (MTP) code coverage
description: Learn about collecting code coverage data with MTP.
author: evangelink
ms.author: amauryleve
ms.date: 11/05/2026
ai-usage: ai-assisted
---

# Code coverage

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), code coverage extensions are auto-registered when you install their NuGet packages — no code changes needed.

You can use the code coverage feature with Microsoft.Testing.Platform (MTP) to determine what proportion of your project's code is being tested by coded tests such as unit tests. To effectively guard against bugs, your tests should exercise or *cover* a large proportion of your code.

## Microsoft code coverage

Microsoft Code Coverage analysis is possible for both managed (CLR) and unmanaged (native) code. Both static and dynamic instrumentation are supported. This extension requires the [Microsoft.Testing.Extensions.CodeCoverage](https://nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) NuGet package.

> [!NOTE]
> Unmanaged (native) code coverage is disabled in the extension by default. Use flags `EnableStaticNativeInstrumentation` and `EnableDynamicNativeInstrumentation` to enable it if needed.
> For more information about unmanaged code coverage, see [Static and dynamic native instrumentation](/visualstudio/test/customizing-code-coverage-analysis?#static-and-dynamic-native-instrumentation).

> [!IMPORTANT]
> The package is shipped with Microsoft .NET library closed-source free to use licensing model.

For more information about Microsoft code coverage, see its [GitHub page](https://github.com/microsoft/codecoverage).

### Options

| Option | Description |
|---|---|
| `--coverage`               | Collect the code coverage using dotnet-coverage tool.                         |
| `--coverage-output`        | The name or path of the produced coverage file. Relative paths resolve from the [test results directory](microsoft-testing-platform-cli-options.md). The default is `<guid>.coverage` in that directory. See [Coverage output files](#coverage-output-files). |
| `--coverage-output-format` | Output file format. Supported values are: `coverage`, `xml`, and `cobertura`. Default is `coverage`. |
| `--coverage-settings`      | [XML code coverage settings](../additional-tools/dotnet-coverage.md#settings). |

For more information about the available options, see [settings](../additional-tools/dotnet-coverage.md#settings) and [samples](https://github.com/microsoft/codecoverage/tree/main/samples/Algorithms).

> [!NOTE]
> The default value of `IncludeTestAssembly` in Microsoft.Testing.Extensions.CodeCoverage is `false`, while it used to be `true` in VSTest. This means that test projects are excluded by default. For more information, see [Code Coverage configuration](https://github.com/microsoft/codecoverage/blob/main/docs/configuration.md).

### Coverage output files

To preserve every application's coverage report in a multi-module `dotnet test` run, omit `--coverage-output`. The extension generates a GUID-based name for each report and selects the file extension from `--coverage-output-format`:

```dotnetcli
dotnet test -- --coverage --coverage-output-format cobertura
```

If you specify `--coverage-output`, `dotnet test` forwards the same value to every test application. A relative path resolves from that application's results directory; an absolute path is used as specified. The option doesn't request a merged solution-level report.

> [!WARNING]
> With the default `flat` layout, applications that use the same output path overwrite one another's coverage reports, even if the applications run serially. The test command can succeed without a warning about the lost coverage.

To keep a fixed relative file name without collisions, use the SDK's [`--results-directory-layout per-module`](../tools/dotnet-test-mtp.md#options) option before `--`:

```dotnetcli
dotnet test --results-directory-layout per-module -- --coverage --coverage-output-format cobertura --coverage-output my-output-file.xml
```

Each application writes `my-output-file.xml` beneath its own project/framework/runtime directory. An absolute `--coverage-output` path bypasses those directories. To keep reports separate, use a relative file name or a different absolute path for each application.

Compatible coverage extensions can merge the preserved reports through [artifact post-processing](../tools/dotnet-test-mtp.md#results-and-artifacts). This feature is separate from `--coverage-output` and can't restore data overwritten before the merge.

Report file name placeholders, such as `{asm}`, `{tfm}`, and `{arch}`, apply to [test reports](microsoft-testing-platform-test-reports.md#report-file-names), not to `--coverage-output`.

## Coverage summaries and thresholds

> [!IMPORTANT]
> The first-class coverage result model is available starting with MTP 2.4.

Compatible collectors can publish covered and coverable measurements, threshold evaluations, and coverage report references as one correlated test coverage result. The terminal reporter and compatible report consumers render the measurements and derive percentages without parsing collector-specific files.

Collectors choose whether to publish this model. Use the collector's documented options to configure collection and thresholds.

If you author a collector, publish `TestCoverageMessage`, `TestCoverageThresholdMessage`, and `TestCoverageReportMessage` through the message bus. For contracts and runnable examples, see [Publish coverage results](./microsoft-testing-platform-architecture-extensions.md#publish-coverage-results). For correlated data in a report extension, use the [`ITestCoverageCapabilities`](./microsoft-testing-platform-architecture-services.md#the-itestcoveragecapabilities-service) and [`ITestCoverageResult`](./microsoft-testing-platform-architecture-services.md#the-itestcoverageresult-service) services.

When a published threshold evaluation fails, an otherwise successful run exits with code `14`. Use `--ignore-exit-code 14` when a threshold failure shouldn't fail the process.

## Version compatibility

The following table shows the compatibility between different versions of Microsoft.Testing.Extensions.CodeCoverage and MTP:

| Microsoft.Testing.Extensions.CodeCoverage | MTP |
|------------------------------------------|---------------------------|
| 18.1.x                                  | 2.0.x                     |
| 18.0.x                                  | 1.8.x                     |
| 17.14.x                                  | 1.6.2                     |

> [!NOTE]
> For the best compatibility and latest features, it's recommended to use the latest versions of both packages together.

## Coverlet

The Coverlet Microsoft Testing Platform Integration (`coverlet.MTP`) is a native extension for MTP that implements `coverlet.collector` functionality.

Add the `coverlet.MTP` NuGet package to your test project:

```bash
dotnet add package coverlet.MTP
```

To collect code coverage, run your tests with the `--coverlet` flag:

```bash
dotnet test --coverlet
```

Or run your test executable with the `--coverlet` flag:

```bash
dotnet exec <test-assembly.dll> --coverlet
```

After the test run, a `coverage.json` file containing the results is generated in the current directory.

### Options

| Option | Description |
|---|---|
| `--coverlet` | Enable code coverage data collection. |
| `--coverlet-output-format <format>` | Output formats for the coverage report. Supported formats: `json`, `lcov`, `opencover`, `cobertura`, and `teamcity`. Specify multiple times to include more than one format. |
| `--coverlet-include <filter>` | Include assemblies that match filters, such as `[Assembly]Type`. Specify multiple times to add more filters. |
| `--coverlet-include-directory <path>` | Include extra directories for source files. Specify multiple times to add more directories. |
| `--coverlet-exclude <filter>` | Exclude assemblies that match filters, such as `[Assembly]Type`. Specify multiple times to add more filters. |
| `--coverlet-exclude-by-file <pattern>` | Exclude source files that match glob patterns. Specify multiple times to add more patterns. |
| `--coverlet-exclude-by-attribute <attribute>` | Exclude methods or classes decorated with specific attributes. Specify multiple times to add more attributes. |
| `--coverlet-include-test-assembly` | Include the test assembly in the coverage report. |
| `--coverlet-single-hit` | Limit the number of hits to one for each location in the code. |
| `--coverlet-skip-auto-props` | Skip auto-implemented properties in the coverage. |
| `--coverlet-does-not-return-attribute <attribute>` | Attributes that mark methods as not returning. Specify multiple times to add more attributes. |
| `--coverlet-exclude-assemblies-without-sources <value>` | Exclude assemblies without source code. Values: `MissingAll`, `MissingAny`, and `None`. |

For more information, see the [coverlet.MTP documentation](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/Coverlet.MTP.Integration.md).
