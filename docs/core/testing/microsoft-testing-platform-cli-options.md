---
title: Microsoft.Testing.Platform CLI options reference
description: Find platform and extension command-line options for Microsoft.Testing.Platform in one place.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform CLI options reference

This article gives a central entry point for Microsoft.Testing.Platform command-line options.

## Platform options

- **`@`**

  Specifies the name of the response file. The response file name must immediately follow the @ character with no white space between the @ character and the response file name.

  Options in a response file are interpreted as if they were present at that place in the command line. Each argument in a response file must begin and end on the same line. You cannot use the backslash character (\) to concatenate lines. Using a response file helps for very long commands that might exceed the terminal limits. You can combine a response file with inline command-line arguments. For example:

  ```console
  ./TestExecutable.exe @"filter.rsp" --timeout 10s
  ```

  where *filter.rsp* can have the following contents:

  ```rsp
  --filter "A very long filter"
  ```

  Or a single rsp file can be used to specify both timeout and filter as follows:

  ```console
  ./TestExecutable.exe @"arguments.rsp"
  ```

  ```rsp
  --filter "A very long filter"
  --timeout 10s
  ```

- **`--config-file`**

  Specifies a [*testconfig.json*](microsoft-testing-platform-config.md) file.

- **`--diagnostic`**

  Enables the diagnostic logging. The default log level is `Trace`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`.

- **`--diagnostic-synchronous-write`**

  Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution.

- **`--diagnostic-output-directory`**

  The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory.

- **`--diagnostic-file-prefix`**

  The prefix for the log file name. Defaults to `"log"`.

- **`--diagnostic-verbosity`**

  Defines the verbosity level when the `--diagnostic` switch is used. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

- **`--exit-on-process-exit`**

  Exit the test process if dependent process exits. PID must be provided.

- **`--help`**

  Prints out a description of how to use the command.

- **`--ignore-exit-code`**

  Allows some non-zero exit codes to be ignored, and instead returned as `0`. For more information, see [Ignore specific exit codes](./microsoft-testing-platform-troubleshooting.md#ignore-specific-exit-codes).

- **`--info`**

  Displays advanced information about the .NET Test Application such as:

  - The platform.
  - The environment.
  - Each registered command line provider, such as its `name`, `version`, `description`, and `options`.
  - Each registered tool, such as its `command`, `name`, `version`, `description`, and all command-line providers.

  This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

- **`--list-tests`**

  List available tests. Tests will not be executed.

- **`--maximum-failed-tests`**

  Specifies the maximum number of tests failures that, when reached, will stop the test run. Support for this switch requires framework authors to implement the `IGracefulStopTestExecutionCapability` capability. The exit code when reaching that amount of test failures is 13. For more information, see [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-troubleshooting.md#exit-codes).

  > [!NOTE]
  > This feature is available in Microsoft.Testing.Platform starting with version 1.5.

- **`--minimum-expected-tests`**

  Specifies the minimum number of tests that are expected to run. By default, at least one test is expected to run.

- **`--results-directory`**

  The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

- **`--timeout`**

  A global test execution timeout. Takes one argument as string in the format `<value>[h|m|s]` where `<value>` is float.

## Extension options by scenario

Use the following table to find extension options quickly.

| Scenario | Extension documentation |
|---|---|
| Collect code coverage | [Code Coverage extensions](./microsoft-testing-platform-extensions-code-coverage.md) |
| Collect crash or hang dumps | [Diagnostics extensions](./microsoft-testing-platform-extensions-diagnostics.md) |
| Generate test reports (for example TRX) or customize terminal output | [Reporting extensions](./microsoft-testing-platform-extensions-reporting.md) |
| Apply hosting-level controls | [Hot Reload extension](./microsoft-testing-platform-extensions-hot-reload.md) |
| Apply policy controls | [Retry extension](./microsoft-testing-platform-extensions-retry.md) |
| Run tests that use Microsoft Fakes | [Microsoft Fakes extension](./microsoft-testing-platform-extensions-fakes.md) |
| Retry failed tests | [Retry extension](./microsoft-testing-platform-extensions-retry.md#retry) |
| Emit OpenTelemetry traces and metrics | [OpenTelemetry extension](./microsoft-testing-platform-extensions-open-telemetry.md) |

## Discover options in your test app

Run your test executable with `--help` to list the options available for your current extension set.

For advanced diagnostics of registered providers and options, run with `--info`.

## See also

- [Microsoft.Testing.Platform overview](./microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform extensions](./microsoft-testing-platform-extensions.md)
- [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
