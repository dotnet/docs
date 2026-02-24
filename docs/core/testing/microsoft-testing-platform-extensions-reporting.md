---
title: Microsoft.Testing.Platform reporting extensions
description: Learn about the Microsoft.Testing.Platform extensions for test reports (TRX, Azure DevOps) and terminal output.
author: evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Reporting extensions

This article lists and explains all Microsoft.Testing.Platform extensions related to reporting test results, both as files and terminal output.

## Visual Studio test reports (TRX)

The Visual Studio test result file (or TRX) is the default format for publishing test results. This extension is shipped as part of [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) NuGet package.

### Options

| Option | Description |
|---|---|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

## Azure DevOps reports

Azure DevOps report plugin enhances test running for developers that host their code on GitHub, but build on Azure DevOps build agents. It adds additional information to failures to show failure directly in GitHub PR.

![Error annotation in GitHub PR files view](./media/test-azdoreport-failure.png)

This extension is shipped as part of [Microsoft.Testing.Extensions.AzureDevOpsReport](https://nuget.org/packages/Microsoft.Testing.Extensions.AzureDevOpsReport) NuGet package.

### Options

| Option | Description |
|---|---|
| `--report-azdo` | Enable outputting errors / warnings in CI builds. |
| `--report-azdo-severity` | Severity to use for the reported event. Options are: `error` (default) and `warning`. |

The extension automatically detects that it is running in continuous integration (CI) environment by checking the `TF_BUILD` environment variable.

## Terminal test reporter

Terminal test reporter is the default implementation of status and progress reporting to the terminal (console).

It comes built-in with **Microsoft.Testing.Platform**, and offers ANSI and non-ANSI mode, and progress indicator.

### Output modes

There are two output modes available:

- `Normal`, the output contains the banner, reports full failures of tests, warning messages, and writes summary of the run.
  ![Output with 1 failed test and a summary](./media/test-output-and-summary.png)

- `Detailed`, the same as `Normal` but it also reports `Passed` tests.
  ![Output with 1 failed, and 1 passed test and a summary](./media/test-output-and-summary-with-passed.png)

### ANSI

Internally there are 2 different output formatters that auto-detect the terminal capability to handle [ANSI escape codes](/windows/console/console-virtual-terminal-sequences).

- The ANSI formatter is used when the terminal is capable of rendering the escape codes.
- The non-ANSI formatter is used when the terminal can't handle the escape codes, when `--no-ansi` is used, or when output is redirected.

The default is to auto-detect the capabilities.

### Progress

A progress indicator is written to terminal. The progress indicator shows the number of passed tests, failed tests, and skipped tests, followed by the name of the tested assembly, its target framework, and architecture.

![A progress bar with 23 passed tests, 0 failed tests and 0 skipped tests](./media/test-progress-bar.png)

The progress bar is written based on the selected mode:

- ANSI, the progress bar is animated, sticking to the bottom of the screen and is refreshed every 500ms. The progress bar hides once test execution is done.
- non-ANSI, the progress bar is written to screen as is every 3 seconds. The progress remains in the output.

### Options

| Option | Description |
|---|---|
| `--no-progress` | Disable reporting progress to screen. |
| `--no-ansi` | Disable outputting ANSI escape characters to screen. |
| `--output` | Output verbosity when reporting tests. Valid values are `Normal` and `Detailed`. Default is `Normal`. |
