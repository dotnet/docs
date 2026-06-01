---
title: Microsoft.Testing.Platform (MTP) test reports
description: Learn about the MTP extensions for generating test report files (TRX, Azure DevOps).
author: evangelink
ms.author: amauryleve
ms.date: 06/01/2026
ai-usage: ai-assisted
---

# Test reports

These features require installing additional NuGet packages, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), these extensions are auto-registered when you install their NuGet packages — no code changes needed. The manual registration specified in this article is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

## Visual Studio test reports (TRX)

The Visual Studio test result file (or TRX) is the default format for publishing test results. This extension requires the [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) NuGet package.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddTrxReportProvider();
```

> [!NOTE]
> When using manual registration, register the TRX report provider last. The current implementation depends on registration order, so registering it after all other extensions ensures it captures all test data.

### Options

| Option | Description |
|---|---|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd_HH_mm_ss.fffffff>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

## Azure DevOps reports

Azure DevOps report plugin enhances test running for developers that host their code on GitHub, but build on Azure DevOps build agents. It adds additional information to failures to show failure directly in GitHub PR.

![Error annotation in GitHub PR files view](./media/test-azdoreport-failure.png)

This extension requires the [Microsoft.Testing.Extensions.AzureDevOpsReport](https://nuget.org/packages/Microsoft.Testing.Extensions.AzureDevOpsReport) NuGet package.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.TestHost.AddAzureDevOpsProvider();
```

### Options

| Option | Description |
|---|---|
| `--report-azdo` | Enables the Azure DevOps report generator. Errors and warnings are written to the output in a format that Azure DevOps understands. |
| `--report-azdo-severity` | Severity to use for reported events. Valid values are `error` (default) and `warning`. |
| `--report-azdo-flaky-history` | Queries Azure DevOps test result history for the past N days (1-90) and annotates reported failures with flakiness context. Requires `--report-azdo`. |
| `--report-azdo-demote-known-flaky` | Demotes failures that are flaky enough in the Azure DevOps history window (default threshold is 25%) from errors to warnings. Requires `--report-azdo` and `--report-azdo-flaky-history`. |
| `--report-azdo-quarantine-file` | Path to a text file that lists quarantined test fully qualified names or glob patterns. Matching failures are reported as warnings. Requires `--report-azdo`. |
| `--report-azdo-upload-artifacts` | Uploads test result files and/or adds build tags to Azure DevOps. Valid values are `off` (default), `tags-only`, `files`, and `all`. |
| `--report-azdo-upload-artifact-include` | Includes files in the Azure DevOps artifact upload using glob patterns relative to the test results directory. Defaults to `**/*`. Requires `--report-azdo-upload-artifacts` to be a value other than `off`. |
| `--report-azdo-upload-artifact-exclude` | Excludes files from the Azure DevOps artifact upload using glob patterns relative to the test results directory. Requires `--report-azdo-upload-artifacts` to be a value other than `off`. |
| `--report-azdo-upload-artifact-name` | Overrides the Azure DevOps artifact container name. Defaults to `TestResults_{assemblyName}_{tfm}`. Requires `--report-azdo-upload-artifacts` to be a value other than `off`. |
| `--publish-azdo-test-results` | Publishes test results live to the Azure DevOps **Tests** tab. |
| `--publish-azdo-run-name` | Sets a custom Azure DevOps test run name for live test-result publishing. Requires `--publish-azdo-test-results`. |

The extension automatically detects that it is running in continuous integration (CI) environment by checking the `TF_BUILD` environment variable.
