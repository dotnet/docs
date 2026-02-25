---
title: Microsoft.Testing.Platform test reports
description: Learn about the Microsoft.Testing.Platform extensions for generating test report files (TRX, Azure DevOps).
author: evangelink
ms.author: amauryleve
ms.date: 02/25/2026
ai-usage: ai-assisted
---

# Test reports

These features require installing additional NuGet packages, as described in each section.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), these extensions are auto-registered when you install their NuGet packages — no code changes needed. The manual registration below is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

## Visual Studio test reports (TRX)

The Visual Studio test result file (or TRX) is the default format for publishing test results. This extension requires the [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) NuGet package.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.AddTrxReportProvider();
```

### Options

| Option | Description |
|---|---|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

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
| `--report-azdo` | Enable outputting errors / warnings in CI builds. |
| `--report-azdo-severity` | Severity to use for the reported event. Options are: `error` (default) and `warning`. |

The extension automatically detects that it is running in continuous integration (CI) environment by checking the `TF_BUILD` environment variable.
