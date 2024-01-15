---
title: MSTest runner extensions
description: Learn about the various MSTest runner extensions and how to use them.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner extensions

The MSTest runner can be customized through extensions. These extension are either built-in or can be installed as NuGet packages. Extensions installed through NuGet packages will auto-register the extensions they are holding to become available in test execution.

## Test reports

A test report is a file that contains information about the execution and outcome of the tests.

### Visual Studio test reports

The Visual Studio test result file (or TRX) is the default format for publishing test results. This extension is shipped as part of [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) package.

The package is shipped with Microsoft .NET LIBRARY closed-source free to use licensing model.

The available options as follows:

| Option | Description |
|--|--|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

## Troubleshoot

The `Microsoft.Testing.Platform` offers some built-in functionalities and extensions that ease the troubleshooting of your test apps.

### Platform options

The following [platform options](./unit-testing-mstest-runner-intro.md#options) provide useful information for troubleshooting your test apps:

- `--info`
- `--diagnostic`
- `⁠-⁠-⁠diagnostic-⁠filelogger-⁠synchronouswrite`
- `--diagnostic-verbosity`
- `--diagnostic-output-fileprefix`
- `--diagnostic-output-directory`

You can also enable the diagnostics logs using the environment variables:

| Environment variable name | Description |
|--|--|
| `TESTINGPLATFORM_DIAGNOSTIC` | If set to `1`, enables the diagnostic logging. |
| `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` | Defines the verbosity level. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` | The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` | The prefix for the log file name. Defaults to `"log_"`. |
| `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` | Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. |

> [!NOTE]
> Environment variables take precedence over the command line arguments.

### Hang dump files

This extension allows you to create a dump file after a given timeout. This extension is shipped as part of [Microsoft.Testing.Extensions.HangDump](https://nuget.org/packages/Microsoft.Testing.Extensions.HangDump) package.

The package is shipped with Microsoft .NET LIBRARY closed-source free to use licensing model.

To configure the hang dump file generation, use the following options:

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `-⁠-⁠hangdump-⁠filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|

### Crash dump files

This extension allows you to create a crash dump file if the process crashes. This extension is shipped as part of [Microsoft.Testing.Extensions.CrashDump](https://nuget.org/packages/Microsoft.Testing.Extensions.CrashDump) NuGet package.

The package is shipped with Microsoft .NET LIBRARY closed-source free to use licensing model.

To configure the crash dump file generation, use the following options:

| Option | Description |
|--|--|
| `--crashdump` | Generates a dump file when the test host process crashes. Supported in .NET 6.0+. |
| `⁠-⁠-⁠crashdump-⁠filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|

## Code coverage

To determine what proportion of your project's code is being tested by coded tests such as unit tests, you can use the code coverage feature. To effectively guard against bugs, your tests should exercise or 'cover' a large proportion of your code.

### Microsoft code coverage

Microsoft Code Coverage analysis is possible for both managed (CLR) and unmanaged (native) code. Both static and dynamic instrumentation are supported. This extension is shipped as part of [Microsoft.Testing..Extensions.CodeCoverage](https://nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) NuGet package.

The package is shipped with Microsoft .NET LIBRARY closed-source free to use licensing model.

> [!NOTE]
> Microsoft code coverage is closed source but it's free to use.

For more information about Microsoft code coverage, see its [GitHub page](https://github.com/microsoft/codecoverage).

Microsoft Code Coverage provides the following options:

| Option | Description |
|--|--|
| `--coverage` | Collect the code coverage using dotnet-coverage tool |
| `--coverage-output` | Output file |
| `--coverage-output-format` | Output file format. Supported values: 'coverage', 'xml' and 'cobertura' |
| `--coverage-settings` | XML code coverage settings |

For more information about the available options, see [settings](../additional-tools/dotnet-coverage.md#settings).
