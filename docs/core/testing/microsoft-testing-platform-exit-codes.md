---
title: Microsoft.Testing.Platform exit codes
description: Learn about the various Microsoft.Testing.Platform exit codes and their meaning.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
ms.topic: reference
---

# Microsoft.Testing.Platform exit codes

`Microsoft.Testing.Platform` uses known exit codes to communicate test failure or app errors. Exit codes start at `0` and are non-negative. Consider the following table that details the various exit codes and their corresponding reasons:

| Exit code | Details |
|-----|----------|
| `0` | The `0` exit code indicates success. All tests that were chosen to run ran to completion and there were no errors. |
| `1` | The `1` exit code indicates unknown errors and acts as a _catch all_. To find additional error information and details, look in the output. |
| `2` | An exit code of `2` is used to indicate that there was at least one test failure. |
| `3` | The exit code `3` indicates that the test session was aborted. A session can be aborted using <kbd>Ctrl</kbd>+<kbd>C</kbd>, as an example. |
| `4` | The exit code `4` indicates that the setup of used extensions is invalid and the tests session cannot run. |
| `5` | The exit code `5` indicates that the command line arguments passed to the test app are invalid. |
| `6` | The exit code `6` indicates that the test session is using a non-implemented feature. |
| `7` | The exit code `7` indicates that a test session was unable to complete successfully, and likely crashed. It's possible that this was caused by a test session that was run via a test controller's extension point. |
| `8` | The exit code `8` indicates that the test session ran zero tests. |
| `9` | The exit code `9` indicates that the minimum execution policy for the executed tests was violated. |
| `10` | The exit code `10` indicates that the test adapter, Testing.Platform Test Framework, MSTest, NUnit, or xUnit, failed to run tests for an infrastructure reason unrelated to the test's self. An example is failing to create a fixture needed by tests. |
| `11` | The exit code `11` indicates that the test process will exit if dependent process exits. |
| `12` | The exit code `12` indicates that the test session was unable to run because the client does not support any of the supported protocol versions. |
| `13` | The exit code `13` indicates that the test session was stopped due to reaching the specified number of maximum failed tests using `--maximum-failed-tests` command-line option. For more information, see [the Options section in Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md#options) |

To enable verbose logging and troubleshoot issues, see [Microsoft.Testing.Platform Diagnostics extensions](microsoft-testing-platform-extensions-diagnostics.md#built-in-options).

## Ignore specific exit codes

`Microsoft.Testing.Platform` is designed to be strict by default but allows for configurability. As such, it's possible for users to decide which exit codes should be ignored (an exit code of `0` will be returned instead of the original exit code).

To ignore specific exit codes, use the `--ignore-exit-code` command line option or the `TESTINGPLATFORM_EXITCODE_IGNORE` environment variable. The valid format accepted is a semi-colon separated list of exit codes to ignore (for example, `--ignore-exit-code 2;3;8`). A common scenario is to consider that test failures shouldn't result in a nonzero exit code (which corresponds to ignoring exit-code `2`).
