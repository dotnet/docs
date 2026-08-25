---
title: Microsoft.Testing.Platform (MTP) CLI options reference
description: Find platform and extension command-line options for MTP in one place.
author: Evangelink
ms.author: amauryleve
ms.date: 07/09/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform (MTP) CLI options reference

This article gives a central entry point for MTP command-line options.

## Platform options

- **`@`**

  Specifies the name of the response file. The response file name must immediately follow the `@` character with no white space between the `@` character and the response file name.

  Options in a response file are interpreted as if they were present at that place in the command line. You can't use the backslash character `\` to concatenate lines. Using a response file helps for very long commands that might exceed the terminal limits. You can combine a response file with inline command-line arguments. For example:

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
  --filter "A very long filter" --timeout 10s
  ```

  > [!NOTE]
  > When using `dotnet test`, the SDK command-line parser uses a token-per-line approach where each line in the response file is treated as a single token. In that case, each argument must be on a separate line:
  >
  > ```rsp
  > --filter
  > A very long filter
  > --timeout
  > 10s
  > ```

- **`--config-file`**

  Specifies a [*testconfig.json*](microsoft-testing-platform-config.md) file.

- **`--debug`**

  Pauses test execution at startup so you can attach a debugger to the test process. Equivalent to setting the `TESTINGPLATFORM_WAIT_ATTACH_DEBUGGER` [environment variable](./microsoft-testing-platform-config.md#testingplatform_wait_attach_debugger-environment-variable) to `1`. Not supported on browser platforms.

  > [!NOTE]
  > This option is available in MTP starting with version 1.9.0. It replaces the previous `--debug-wait-attach` option (introduced in MTP 1.6.0); the old name was removed and must no longer be used.

- **`--diagnostic`**

  Enables the diagnostic logging. The default log level is `Trace`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`.

- **`--diagnostic-synchronous-write`**

  Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This slows down the test execution.

  > [!NOTE]
  > Available in MTP starting with version 2.0.0. It replaces the previous `--diagnostic-filelogger-synchronouswrite` option, which was removed in MTP 2.0.0.

- **`--diagnostic-output-directory`**

  The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory.

- **`--diagnostic-file-prefix`**

  The prefix for the log file name. Defaults to `"log"`.

  > [!NOTE]
  > Available in MTP starting with version 2.0.0. It replaces the previous `--diagnostic-output-fileprefix` option, which was removed in MTP 2.0.0.

- **`--diagnostic-verbosity`**

  Defines the verbosity level when the `--diagnostic` switch is used. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

- **`--exit-on-process-exit`**

  Exit the test process if dependent process exits. PID must be provided.

- **`--filter-uid`**

  Filters the tests to run by their test node UIDs. Accepts one or more UIDs.

  > [!NOTE]
  > This option is available in MTP starting with version 1.8.0. Starting with MTP 2.3.0, you can't combine `--filter-uid` with `--treenode-filter`; specifying both fails command-line validation with the `InvalidCommandLine` exit code.

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

  Lists the available tests without executing them. Optionally takes an argument that controls the output format: `text` (default, human-readable) or `json`.

  > [!NOTE]
  > The `json` output format is available in MTP starting with version 2.3.0.

- **`--maximum-failed-tests`**

  Specifies the maximum number of tests failures that, when reached, will stop the test run. Support for this switch requires framework authors to implement the `IGracefulStopTestExecutionCapability` capability. The exit code when reaching that amount of test failures is 13. For more information, see [MTP exit codes](microsoft-testing-platform-troubleshooting.md#exit-codes).

  > [!NOTE]
  > This feature is available in MTP starting with version 1.5.

- **`--minimum-expected-tests`**

  Specifies the minimum number of tests that are expected to run. By default, at least one test is expected to run.

- **`--no-banner`**

  Disables the startup banner, the copyright message, and the telemetry banner. The same effect can be achieved through the `TESTINGPLATFORM_NOBANNER` or `DOTNET_NOLOGO` [environment variables](./microsoft-testing-platform-config.md#environment-variables).

- **`--results-directory`**

  The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

- **`--timeout`**

  A global test execution timeout. Takes one argument as string in the format `<value>[h|m|s]` where `<value>` is float.

- **`--treenode-filter`**

  Filters the tests to run by using a tree filter expression. Tree filters offer richer matching than `--filter` for advanced scenarios.

  > [!NOTE]
  > Starting with MTP 2.3.0, you can't combine `--treenode-filter` with `--filter-uid`; specifying both fails command-line validation with the `InvalidCommandLine` exit code.

- **`--zero-tests-policy`**

  Controls whether a run that executes no tests because every test was skipped is treated as a failure. Valid values are `allow-skipped` (default) and `strict`. With `allow-skipped`, an all-skipped run succeeds; with `strict`, it fails with exit code 8 (the behavior before 2.3.0).

  > [!NOTE]
  > This option is available in MTP starting with version 2.3.0.

## Extension options by scenario

Use the following table to find extension options quickly.

| Scenario | Feature documentation |
|---|---|
| Collect code coverage | [Code coverage](./microsoft-testing-platform-code-coverage.md) |
| Collect crash or hang dumps | [Crash and hang dumps](./microsoft-testing-platform-crash-hang-dumps.md) |
| Generate test reports (for example TRX) | [Test reports](./microsoft-testing-platform-test-reports.md) |
| Customize terminal output | [Terminal output](./microsoft-testing-platform-terminal-output.md) |
| Apply hosting-level controls | [Hot Reload](./microsoft-testing-platform-hot-reload.md) |
| Retry failed tests | [Retry](./microsoft-testing-platform-retry.md#retry) |
| Run tests that use Microsoft Fakes | [Microsoft Fakes](./microsoft-testing-platform-fakes.md) |
| Emit OpenTelemetry traces and metrics | [OpenTelemetry](./microsoft-testing-platform-open-telemetry.md) |

## Discover options in your test app

Run your test executable with `--help` to list the options available for your current extension set.

For advanced diagnostics of registered providers and options, run with `--info`.

## See also

- [MTP overview](./microsoft-testing-platform-intro.md)
- [MTP features](./microsoft-testing-platform-features.md)
- [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
