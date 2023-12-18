---
title: MSTest runner extensions
description: Learn about the various MSTest runner extensions and how to use them.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner extensions

The MSTest runner supports extensions that can be used to customize the behavior of the test runner.

## Test reports

A test report is a file that contains information about the execution and outcome of the tests

### Visual Studio test reports

The Visual Studio test result file (or TRX) is the default format for publishing test results. The available options as follows:

| Option | Description |
|--|--|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

## Troubleshoot

The `Microsoft.Testing.Platform` offers some built-in functionalities and extensions that ease the troubleshooting of your test apps.

### `--info` option

When you run your `Microsoft.Testing.Platform` test app with the `--info` switch, the platform displays advanced information about:

- The platform.
- The environment.
- Each registered command line provider, such as its, `name`, `version`, `description` and `options`.
- Each registered tool, such as its, `command`, `name`, `version`, `description`, and all command line providers.

This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

## Diagnostic logs

The platform produces diagnostic logs that are helpful to understand what is happening during the execution of your test application. The following options are available to configure the produced diagnostic logs:

| Option | Description |
|--|--|
| `--diagnostic` | Enables the diagnostic logging. The default log level is `Information`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`. |
| `⁠-⁠-⁠diagnostic-⁠filelogger-⁠synchronouswrite` | Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. |
| `--diagnostic-verbosity` | Defines the verbosity level when the `--diagnostic` switch is used. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.|
| `--diagnostic-output-fileprefix` | The prefix for the log file name. Defaults to `"log_"`. |
| `--diagnostic-output-directory` | The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory. |

You can enable the diagnostics logs also using the environment variables:

| Environment variable name | Description |
|--|--|
| `TESTINGPLATFORM_DIAGNOSTIC` | If set to `1`, enables the diagnostic logging. |
| `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` | Defines the verbosity level. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` | The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` | The prefix for the log file name. Defaults to `"log_"`. |
| `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` | Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. |

> [!NOTE]
> Environment variables take precedence over the command line arguments.

## Hang dump files

This extension allows you to create a dump file after a given timeout. To configure the hang dump file generation, use the following options:

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `-⁠-⁠hangdump-⁠filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|

## Crash dump files

This extension allows you to create a crash dump file if the process crashes. To configure the crash dump file generation, use the following options:

| Option | Description |
|--|--|
| `--crashdump` | Generates a dump file when the test host process crashes. Supported in .NET 6.0+. |
| `⁠-⁠-⁠crashdump-⁠filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|
