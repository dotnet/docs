---
title: Microsoft.Testing.Platform configuration reference
description: Complete reference of all configuration methods for Microsoft.Testing.Platform, including command-line options, environment variables, and configuration files.
author: Evangelink
ms.author: amauryleve
ms.date: 11/27/2025
---

# Microsoft.Testing.Platform configuration reference

This article provides a complete reference of all configuration methods available for Microsoft.Testing.Platform. You can configure tests using command-line options, environment variables, and configuration files. The configuration methods are organized by category, starting with core platform options followed by options provided by various features.

> [!TIP]
> To see all available options for your specific test project, use the `--help` option:
>
> ```dotnetcli
> dotnet run --project YourTestProject -- --help
> ```

## Configuration methods

Microsoft.Testing.Platform supports three configuration methods, with the following precedence (from highest to lowest):

1. **Command-line arguments** - Options passed when running the test executable
2. **Environment variables** - System or user environment variables
3. **Configuration files** - Settings in *testconfig.json* file

## Command-line options

Command-line options are specified when running your test project. They provide the most flexibility and override all other configuration methods.

### Platform options

These core options are available in all test projects using Microsoft.Testing.Platform.

#### General options

- **`--help`**

  Prints out a description of how to use the command.

- **`--info`**

  Displays advanced information about the .NET Test Application such as:

  - The platform.
  - The environment.
  - Each registered command line provider, such as its `name`, `version`, `description`, and `options`.
  - Each registered tool, such as its `command`, `name`, `version`, `description`, and all command-line providers.

  This feature is useful to understand which features are registering the same command line option or the changes in available options between multiple versions of a feature or the platform.

- **`@<response-file>`**

  Specifies the name of the response file. The response file name must immediately follow the @ character with no white space between the @ character and the response file name.

  Options in a response file are interpreted as if they were present at that place in the command line. Each argument in a response file must begin and end on the same line. You can't use the backslash character (\\) to concatenate lines. Using a response file helps for very long commands that might exceed the terminal limits. You can combine a response file with inline command-line arguments. For example:

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

#### Test execution options

- **`--list-tests`**

  Lists available tests. Tests aren't executed.

- **`--timeout`**

  A global test execution timeout. Takes one argument as string in the format `<value>[h|m|s]` where `<value>` is float.

- **`--minimum-expected-tests`**

  Specifies the minimum number of tests that are expected to run. By default, at least one test is expected to run.

- **`--maximum-failed-tests`**

  Specifies the maximum number of tests failures that, when reached, stops the test run. Support for this switch requires framework authors to implement the `IGracefulStopTestExecutionCapability` capability. The exit code when reaching that amount of test failures is 13. For more information, see [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md).

  > [!NOTE]
  > This feature is available in Microsoft.Testing.Platform starting with version 1.5.

#### Configuration options

- **`--config-file`**

  Specifies a [*testconfig.json*](microsoft-testing-platform-config.md) file.

- **`--results-directory`**

  The directory where the test results are placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

#### Diagnostic options

- **`--diagnostic`**

  Enables the diagnostic logging. The default log level is `Trace`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`.

- **`--diagnostic-verbosity`**

  Defines the verbosity level when the `--diagnostic` switch is used. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

- **`--diagnostic-output-directory`**

  The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory.

- **`--diagnostic-output-fileprefix`**

  The prefix for the log file name. Defaults to `"log_"`.

- **`--diagnostic-filelogger-synchronouswrite`**

  Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution.

#### Process options

- **`--exit-on-process-exit`**

  Exits the test process if dependent process exits. PID must be provided.

- **`--ignore-exit-code`**

  Allows some non-zero exit codes to be ignored, and instead returned as `0`. For more information, see [Ignore specific exit codes](./microsoft-testing-platform-exit-codes.md#ignore-specific-exit-codes).

### Code coverage options

Options for collecting code coverage. These options require the [Microsoft.Testing.Extensions.CodeCoverage](https://nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) NuGet package.

- **`--coverage`**

  Collects the code coverage using dotnet-coverage tool.

- **`--coverage-output`**

  The name or path of the produced coverage file. By default, the file is `TestResults/<guid>.coverage`.

- **`--coverage-output-format`**

  Output file format. Supported values are: `coverage`, `xml`, and `cobertura`. Default is `coverage`.

- **`--coverage-settings`**

  [XML code coverage settings](../additional-tools/dotnet-coverage.md#settings).

For more information, see [Code coverage extensions](microsoft-testing-platform-extensions-code-coverage.md).

### Test report options

Options for generating test reports.

#### TRX reports

These options require the [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) NuGet package.

- **`--report-trx`**

  Generates the TRX report.

- **`--report-trx-filename`**

  The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`.

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

For more information, see [Test reports extensions](microsoft-testing-platform-extensions-test-reports.md).

#### Azure DevOps reports

These options require the [Microsoft.Testing.Extensions.AzureDevOpsReport](https://nuget.org/packages/Microsoft.Testing.Extensions.AzureDevOpsReport) NuGet package.

- **`--report-azdo`**

  Enables outputting errors and warnings in CI builds.

- **`--report-azdo-severity`**

  Severity to use for the reported event. Options are: `error` (default) and `warning`.

The extension automatically detects that it's running in continuous integration (CI) environment by checking the `TF_BUILD` environment variable.

For more information, see [Test reports extensions](microsoft-testing-platform-extensions-test-reports.md).

### Dump generation options

Options for generating crash and hang dumps for troubleshooting.

#### Crash dump options

These options require the [Microsoft.Testing.Extensions.CrashDump](https://nuget.org/packages/Microsoft.Testing.Extensions.CrashDump) NuGet package.

- **`--crashdump`**

  Generates a dump file when the test host process crashes. Supported in .NET 6.0 and later.

- **`--crashdump-filename`**

  Specifies the file name of the dump.

- **`--crashdump-type`**

  Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).

> [!CAUTION]
> The extension isn't compatible with .NET Framework and will be silently ignored. For .NET Framework support, enable the postmortem debugging with Sysinternals ProcDump. For more information, see [Enabling Postmortem Debugging: Window Sysinternals ProcDump](/windows-hardware/drivers/debugger/enabling-postmortem-debugging#window-sysinternals-procdump).

#### Hang dump options

These options require the [Microsoft.Testing.Extensions.HangDump](https://nuget.org/packages/Microsoft.Testing.Extensions.HangDump) NuGet package.

- **`--hangdump`**

  Generates a dump file in case the test host process hangs.

- **`--hangdump-filename`**

  Specifies the file name of the dump.

- **`--hangdump-timeout`**

  Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:
  - `1.5h`, `1.5hour`, `1.5hours`
  - `90m`, `90min`, `90minute`, `90minutes`
  - `5400s`, `5400sec`, `5400second`, `5400seconds`
  
  Defaults to `30m` (30 minutes).

- **`--hangdump-type`**

  Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).

For more information, see [Diagnostics extensions](microsoft-testing-platform-extensions-diagnostics.md).

### Test retry options

Options for retrying failed tests. These options require the [Microsoft.Testing.Extensions.Retry](https://nuget.org/packages/Microsoft.Testing.Extensions.Retry) NuGet package.

- **`--retry-failed-tests`**

  Reruns any failed tests until they pass or until the maximum number of attempts is reached.

- **`--retry-failed-tests-max-percentage`**

  Avoids rerunning tests when the percentage of failed test cases crosses the specified threshold.

- **`--retry-failed-tests-max-tests`**

  Avoids rerunning tests when the number of failed test cases crosses the specified limit.

> [!NOTE]
> The package is shipped with the restrictive Microsoft.Testing.Platform Tools license. The full license is available at <https://www.nuget.org/packages/Microsoft.Testing.Extensions.Retry/1.0.0/License>.

For more information, see [Policy extensions](microsoft-testing-platform-extensions-policy.md).

### Terminal output options

Options for controlling how test results are displayed in the terminal.

- **`--no-progress`**

  Disables reporting progress to screen.

- **`--no-ansi`**

  Disables outputting ANSI escape characters to screen.

- **`--output`**

  Output verbosity when reporting tests. Valid values are `Normal` and `Detailed`. Default is `Normal`.

For more information, see [Output extensions](microsoft-testing-platform-extensions-output.md).

### Framework-specific options

Some options are specific to the test framework you're using.

#### MSTest options

- **`--filter <expression>`**

  Runs tests that match the given expression. For more information, see [Running selective unit tests](selective-unit-tests.md).

- **`--settings <runsettings-file>`**

  Specifies a runsettings file for test configuration. For more information, see [Configure MSTest](unit-testing-mstest-configure.md).

For more information, see [MSTest runner](unit-testing-mstest-runner-intro.md).

#### NUnit options

- **`--filter <expression>`**

  Runs tests that match the given expression. NUnit uses the same filter syntax as MSTest. For more information, see [Running selective unit tests](selective-unit-tests.md).

For more information, see [NUnit runner](unit-testing-nunit-runner-intro.md).

#### xUnit.net options

xUnit.net provides its own set of filtering options:

- **`--filter-class <pattern>`**

  Runs tests in classes that match the pattern.

- **`--filter-not-class <pattern>`**

  Excludes tests in classes that match the pattern.

- **`--filter-method <pattern>`**

  Runs tests with methods that match the pattern.

- **`--filter-not-method <pattern>`**

  Excludes tests with methods that match the pattern.

- **`--filter-namespace <pattern>`**

  Runs tests in namespaces that match the pattern.

- **`--filter-not-namespace <pattern>`**

  Excludes tests in namespaces that match the pattern.

- **`--filter-trait <name>=<value>`**

  Runs tests with traits that match the name and value.

- **`--filter-not-trait <name>=<value>`**

  Excludes tests with traits that match the name and value.

- **`--filter-query <query>`**

  Runs tests matching the query filter language. For more information, see [Query Filter Language for xUnit.net](https://xunit.net/docs/query-filter-language).

For more information, see [Microsoft.Testing.Platform documentation for xUnit.net](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform).

## Environment variables

Environment variables provide a way to configure tests globally without modifying command-line arguments or configuration files. Environment variables take precedence over configuration files but are overridden by command-line arguments.

### Platform environment variables

- **`TESTINGPLATFORM_TELEMETRY_OPTOUT`** or **`DOTNET_CLI_TELEMETRY_OPTOUT`**

  Set to `1` to disable telemetry. For more information, see [Microsoft.Testing.Platform telemetry](microsoft-testing-platform-telemetry.md).

- **`TESTINGPLATFORM_UI_LANGUAGE`**

  Sets the language of the platform for displaying messages and logs using a locale value such as `en-us`. This language takes precedence over the Visual Studio and .NET SDK languages. The supported values are the same as for Visual Studio. For more information, see [Visual Studio installation documentation](/visualstudio/install/install-visual-studio).

- **`TESTINGPLATFORM_EXITCODE_IGNORE`**

  Allows some non-zero exit codes to be ignored. The valid format is a semi-colon separated list of exit codes (for example, `2;3;8`).

### Diagnostic environment variables

- **`TESTINGPLATFORM_DIAGNOSTIC`**

  If set to `1`, enables the diagnostic logging.

- **`TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY`**

  Defines the verbosity level. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

- **`TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY`**

  The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory.

- **`TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX`**

  The prefix for the log file name. Defaults to `"log_"`.

- **`TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE`**

  Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution.

### Hot reload environment variable

- **`TESTINGPLATFORM_HOTRELOAD_ENABLED`**

  Set to `1` to enable hot reload support. Requires the [Microsoft.Testing.Extensions.HotReload](https://nuget.org/packages/Microsoft.Testing.Extensions.HotReload) NuGet package. For more information, see [Hosting extensions](microsoft-testing-platform-extensions-hosting.md).

## Configuration file

The *testconfig.json* file provides a way to configure the test platform using a JSON configuration file. Configuration files have the lowest precedence and are overridden by both environment variables and command-line arguments.

### File location and naming

The test platform uses a configuration file named *[appname].testconfig.json* to configure the behavior of the test platform. The platform automatically detects and loads the *[appname].testconfig.json* file located in the output directory of the test project (close to the executable).

When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), you can simply create a *testconfig.json* file that's automatically renamed to *[appname].testconfig.json* and moved to the output directory of the test project.

> [!NOTE]
> The *[appname].testconfig.json* file gets overwritten on subsequent builds.

Starting with Microsoft.Testing.Platform 1.5, you can use the command-line argument `--config-file` to specify the path to a *testconfig.json* file. This file takes precedence over the *[appname].testconfig.json* file.

### File structure

The *testconfig.json* file is a JSON file that contains configuration settings for the test platform. The file has the following structure:

```json
{
    "platformOptions": {
        "config-property-name1": "config-value1",
        "config-property-name2": "config-value2"
    }
}
```

For more information about available configuration options, see the individual feature documentation.

## See also

- [Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md)
- [Running selective unit tests](selective-unit-tests.md)
- [Code coverage extensions](microsoft-testing-platform-extensions-code-coverage.md)
- [Test reports extensions](microsoft-testing-platform-extensions-test-reports.md)
- [Diagnostics extensions](microsoft-testing-platform-extensions-diagnostics.md)
