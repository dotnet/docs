---
title: Microsoft.Testing.Platform (MTP) config options
description: Learn how to configure MTP using testconfig.json configuration settings and environment variables.
author: Evangelink
ms.author: amauryleve
ms.date: 06/01/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform (MTP) configuration settings

MTP supports the use of configuration files and environment variables to configure the behavior of the test platform. This article describes the configuration settings that you can use to configure the test platform.

## testconfig.json

The test platform uses a configuration file named *[appname].testconfig.json* to configure the behavior of the test platform. The *testconfig.json* file is a JSON file that contains configuration settings for the test platform.

The *testconfig.json* file has the following structure:

```json
{
    "platformOptions": {
        "resultDirectory": "./TestResults"
    }
}
```

The platform will automatically detect and load the *[appname].testconfig.json* file located in the output directory of the test project (close to the executable).

When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), you can simply create a *testconfig.json* file that will be automatically renamed to *[appname].testconfig.json* and moved to the output directory of the test project.

Starting with MTP 1.5, you can use the command-line argument `--config-file` to specify the path to the *testconfig.json*. This file takes precedence over the *[appname].testconfig.json* file.

> [!NOTE]
> The *[appname].testconfig.json* file will get overwritten on subsequent builds.

### Use a centralized testconfig.json

If you want a single *testconfig.json* shared across multiple test projects, you can place it in a central location and pass it via `--config-file`. When MSBuild is available (for example, `dotnet test` or `dotnet run`), you can use the `TestingPlatformCommandLineArguments` MSBuild property to automatically pass the argument. Adding this to a *Directory.Build.props* at the repository root ensures all test projects use the same configuration:

```xml
<PropertyGroup>
  <TestingPlatformCommandLineArguments>
    $(TestingPlatformCommandLineArguments) --config-file $(MSBuildThisFileDirectory)testconfig.json
  </TestingPlatformCommandLineArguments>
</PropertyGroup>
```

### Configuration precedence

When the same setting can be specified in multiple ways, MTP resolves it in the following order (first match wins):

1. Command-line arguments (for example, `--results-directory`)
1. Environment variables
1. *testconfig.json* settings
1. Built-in defaults

### Platform options

The `platformOptions` section of the *testconfig.json* file configures the core behavior of the test platform. The following table lists all supported platform options:

| Entry | Default | Description |
|-------|---------|-------------|
| `resultDirectory` | `TestResults` | The directory where the test results are placed. Can be a relative path (resolved from the current working directory) or an absolute path. The `--results-directory` command-line option takes precedence. |
| `exitProcessOnUnhandledException` | `false` | When set to `true`, the test host process exits immediately on unhandled exceptions instead of allowing graceful shutdown. The `TESTINGPLATFORM_EXIT_PROCESS_ON_UNHANDLED_EXCEPTION` environment variable (values `1` or `0`) takes precedence. |

> [!NOTE]
> Additional internal platform options exist for advanced scenarios (such as named-pipe timeouts for test host controllers). These options are intended for infrastructure use and are not covered here.

Example:

```json
{
  "platformOptions": {
    "resultDirectory": "../../TestResults",
    "exitProcessOnUnhandledException": false
  }
}
```

### Extension options are CLI-only

Extension features such as [crash dump](microsoft-testing-platform-crash-hang-dumps.md), [hang dump](microsoft-testing-platform-crash-hang-dumps.md), [retry](microsoft-testing-platform-retry.md), [TRX reports](microsoft-testing-platform-test-reports.md), and [code coverage](microsoft-testing-platform-code-coverage.md) are **not** configurable via *testconfig.json*. These features are configured exclusively through command-line arguments.

For a complete reference of command-line options, see [MTP CLI options reference](microsoft-testing-platform-cli-options.md).

### Test framework-specific settings

Test frameworks can define their own configuration sections in the *testconfig.json* file. Refer to the documentation for your test framework:

- **MSTest**: [Configure MSTest — testconfig.json](unit-testing-mstest-configure.md#testconfigjson)
- **xUnit.net v3**: [xUnit.net testconfig.json](https://xunit.net/docs/config-testconfig-json)
- **NUnit**: See NUnit documentation for the latest Microsoft.Testing.Platform support.
- **TUnit**: See TUnit documentation for the latest Microsoft.Testing.Platform support.

### Example testconfig.json

The following example shows a *testconfig.json* file that configures platform options and MSTest settings:

```json
{
  "platformOptions": {
    "resultDirectory": "./TestResults"
  },
  "mstest": {
    "parallelism": {
      "enabled": true,
      "workers": 4,
      "scope": "method"
    },
    "timeout": {
      "test": 30000
    },
    "execution": {
      "considerFixturesAsSpecialTests": true
    }
  }
}
```

### Migrating from .runsettings to testconfig.json

If you're migrating from a *.runsettings* file, the following table maps common settings to their *testconfig.json* equivalents or alternatives:

| .runsettings setting | testconfig.json equivalent | Notes |
|---|---|---|
| `RunConfiguration/ResultsDirectory` | `platformOptions.resultDirectory` | |
| `RunConfiguration/MaxCpuCount` | No equivalent | Process-level parallelism is controlled by `dotnet test --max-parallel-test-modules` or MSBuild `/m` option. |
| `MSTest/*` | `mstest.*` | See [Configure MSTest — testconfig.json](unit-testing-mstest-configure.md#testconfigjson). |
| `xUnit/*` | `xUnit.*` | See [xUnit.net testconfig.json](https://xunit.net/docs/config-testconfig-json). |
| `LoggerRunSettings/Loggers` | CLI only | Use `--report-trx` or similar CLI options. |
| `DataCollectionRunSettings` (blame) | CLI only | Use `--crashdump` and `--hangdump` CLI options. See [Crash and hang dumps](microsoft-testing-platform-crash-hang-dumps.md). |
| `DataCollectionRunSettings` (coverage) | CLI only | Use `--coverage` CLI option. See [Code coverage](microsoft-testing-platform-code-coverage.md). |
| `TestRunParameters` | `--test-parameter` CLI | Use `--test-parameter key=value` on the command line. |

## Environment variables

Environment variables can be used to supply some runtime configuration information.

> [!NOTE]
> Environment variables take precedence over configuration settings in the *testconfig.json* file.

### `TESTINGPLATFORM_EXIT_PROCESS_ON_UNHANDLED_EXCEPTION` environment variable

When set to `1`, the test host process exits immediately on unhandled exceptions. When set to `0`, the platform allows graceful shutdown. This setting takes precedence over the `platformOptions:exitProcessOnUnhandledException` configuration.

### `TESTINGPLATFORM_DEFAULT_HANG_TIMEOUT` environment variable

Overrides the default timeout (300 seconds) used for named-pipe connections between the test host controller and test host. The value must be a `TimeSpan`-compatible string.

### `TESTINGPLATFORM_UI_LANGUAGE` environment variable

Starting with MTP 1.5, this environment variable sets the language of the platform for displaying messages and logs using a locale value such as `en-us`. This language takes precedence over the Visual Studio and .NET SDK languages. The supported values are the same as for Visual Studio. For more information, see the section on changing the installer language in the [Visual Studio installation documentation](/visualstudio/install/install-visual-studio).

### `TESTINGPLATFORM_DIAGNOSTIC` environment variable

If set to `1`, enables the diagnostic logging.

### `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` environment variable

Defines the verbosity level when diagnostics are enabled. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

### `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` environment variable

The output directory of the diagnostic logging. If not specified, the file is generated in the default *TestResults* directory.

### `TESTINGPLATFORM_DIAGNOSTIC_FILE_PREFIX` environment variable

The prefix for the log file name. Defaults to `"log_"`. Matches the `--diagnostic-file-prefix` command-line option.

> [!NOTE]
> This environment variable name is available in MTP starting with version 2.3.0. The legacy `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` environment variable is still honored for backward compatibility but is deprecated and may be removed in a future major version. When both variables are set, `TESTINGPLATFORM_DIAGNOSTIC_FILE_PREFIX` takes precedence.

### `TESTINGPLATFORM_DIAGNOSTIC_SYNCHRONOUS_WRITE` environment variable

Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution. Matches the `--diagnostic-synchronous-write` command-line option.

> [!NOTE]
> This environment variable name is available in MTP starting with version 2.3.0. The legacy `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` environment variable is still honored for backward compatibility but is deprecated and may be removed in a future major version. When both variables are set, `TESTINGPLATFORM_DIAGNOSTIC_SYNCHRONOUS_WRITE` takes precedence.

### `TESTINGPLATFORM_EXITCODE_IGNORE` environment variable

A semicolon-separated list of exit codes to ignore. When an exit code is ignored, the process returns `0` instead. For example, `TESTINGPLATFORM_EXITCODE_IGNORE=2;8` ignores test failures and no-tests-ran scenarios.

### `TESTINGPLATFORM_NOBANNER` environment variable

When set to `1` or `true`, suppresses the startup banner, the copyright message, and the telemetry banner. Equivalent to the `--no-banner` command-line option. The `DOTNET_NOLOGO` environment variable has the same effect.

### `DOTNET_NOLOGO` environment variable

When set to `1` or `true`, suppresses the startup banner, the copyright message, and the telemetry banner. This is the standard .NET CLI environment variable and is honored by MTP. See also `TESTINGPLATFORM_NOBANNER`.

### `TESTINGPLATFORM_WAIT_ATTACH_DEBUGGER` environment variable

When set to `1`, the test process pauses at startup and waits for a debugger to attach before proceeding. Equivalent to the `--debug` command-line option. Not supported on browser platforms.

> [!NOTE]
> This environment variable is available in MTP starting with version 1.6.0.

### `TESTINGPLATFORM_LAUNCH_ATTACH_DEBUGGER` environment variable

When set to `1`, the test process calls `Debugger.Launch()` at startup, which prompts the system to launch a just-in-time debugger and attach it to the process. Use this variable to debug startup-time issues (for example, server-mode handshake) that occur before you can manually attach. On non-Windows platforms, the behavior depends on the configured JIT debugger.

> [!NOTE]
> This environment variable is available in MTP starting with version 1.6.0.

> [!NOTE]
> Diagnostic-related environment variables take precedence over their corresponding `--diagnostic-*` command-line arguments.

## See also

- [MTP CLI options reference](microsoft-testing-platform-cli-options.md)
- [MTP features](microsoft-testing-platform-features.md)
- [Configure MSTest](unit-testing-mstest-configure.md)
- [MTP troubleshooting](microsoft-testing-platform-troubleshooting.md)
