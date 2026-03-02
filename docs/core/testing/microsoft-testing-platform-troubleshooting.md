---
title: Microsoft.Testing.Platform troubleshooting
description: Troubleshoot Microsoft.Testing.Platform issues, exit codes, and known problems.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform troubleshooting

This article contains troubleshooting guidance for `Microsoft.Testing.Platform`.

## Exit codes

`Microsoft.Testing.Platform` uses known exit codes to communicate test failure or app errors. Exit codes start at `0` and are non-negative.

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
| `13` | The exit code `13` indicates that the test session was stopped due to reaching the specified number of maximum failed tests using `--maximum-failed-tests` command-line option. For more information, see [the Options section in Microsoft.Testing.Platform CLI options reference](microsoft-testing-platform-cli-options.md) |

To enable verbose logging and troubleshoot issues, see [Diagnostic logging](#diagnostic-logging).

### Ignore specific exit codes

`Microsoft.Testing.Platform` is designed to be strict by default but allows for configurability. As such, it's possible for users to decide which exit codes should be ignored (an exit code of `0` will be returned instead of the original exit code).

To ignore specific exit codes, use the `--ignore-exit-code` command line option or the `TESTINGPLATFORM_EXITCODE_IGNORE` environment variable. The valid format accepted is a semi-colon separated list of exit codes to ignore (for example, `--ignore-exit-code 2;3;8`). A common scenario is to consider that test failures shouldn't result in a nonzero exit code (which corresponds to ignoring exit-code `2`).

## Diagnostic logging

The platform provides built-in diagnostic logging to help you troubleshoot test execution. You can enable diagnostic logging through command-line options or environment variables.

### Command-line options

The following [platform options](./microsoft-testing-platform-cli-options.md) provide useful information for troubleshooting your test apps:

- `--info`
- `--diagnostic`
- `--diagnostic-synchronous-write`
- `--diagnostic-verbosity`
- `--diagnostic-file-prefix`
- `--diagnostic-output-directory`

### Environment variables

You can also enable the diagnostic logs using the environment variables:

| Environment variable name | Description |
|--|--|
| `TESTINGPLATFORM_DIAGNOSTIC` | If set to `1`, enables the diagnostic logging. |
| `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` | Defines the verbosity level. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` | The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` | The prefix for the log file name. Defaults to `"log_"`. |
| `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` | Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. |

> [!NOTE]
> Environment variables take precedence over the command line arguments.

## Resolve configuration errors

### Microsoft.Testing.Platform.MSBuild

The following are common configuration errors related to Microsoft.Testing.Platform.MSBuild.

#### error CS8892: Method 'TestingPlatformEntryPoint.Main(string[])' will not be used as an entry point because a synchronous entry point 'Program.Main(string[])' was found

Manually defining an entry point (`Main`) in a test project or referencing a test project from an application that already has an entry point results in a conflict with the entry point generated by `Microsoft.Testing.Platform`. To avoid this issue, take one of these steps:

- Remove your manually defined entry point, typically `Main` method in _Program.cs_, and let the testing platform generate one for you.

- Disable the generation of the entry point by setting the `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>` MSBuild property.

- Completely disable the transitive dependency to `Microsoft.Testing.Platform.MSBuild` by setting the `<IsTestingPlatformApplication>false</IsTestingPlatformApplication>` MSBuild property in the project that references a test project. This is needed when you reference a test project from a non-test project, for example, a console app that references a test application.

### Microsoft.Testing.Extensions.Fakes

#### Fakes error Failed to resolve profiler path from COR_PROFILER_PATH and COR_PROFILER environment variables

This error can occur if not all of the Fakes assemblies are present in the bin folder.

- Ensure that the project either uses the [MSTest.SDK](./unit-testing-mstest-sdk.md) or references [Microsoft.Testing.Extensions.Fakes](./microsoft-testing-platform-fakes.md).
- For .NET Framework projects, avoid setting `<PlatformTarget>AnyCPU</PlatformTarget>` as this results in NuGet not copying all files to the bin folder.
