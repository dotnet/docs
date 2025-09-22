---
title: Migration guide from VSTest to Microsoft.Testing.Platform
description: Learn how to migrate from VSTest to Microsoft.Testing.Platform
author: Youssef1313
ms.author: ygerges
ms.date: 09/15/2025
---

# Migrate from VSTest to Microsoft.Testing.Platform

In this article, you learn how to migrate from VSTest to Microsoft.Testing.Platform.

## Opt-in to use Microsoft.Testing.Platform

The first step in the migration is to opt-in to using Microsoft.Testing.Platform.

For all test frameworks, add `<OutputType>Exe</OutputType>` to all test projects in the solution. After that, follow the framework-specific guidance.

### MSTest

Microsoft.Testing.Platform is supported by MSTest starting with 3.2.0. However, we recommend updating to the latest available MSTest version.

To opt-in, add `<EnableMSTestRunner>true</EnableMSTestRunner>` under a `PropertyGroup` in [`Directory.Build.props`](/visualstudio/msbuild/customize-by-directory) file.

> [!NOTE]
> When using MSTest.Sdk, Microsoft.Testing.Platform is used by default, unless `<UseVSTest>true</UseVSTest>` is specified.

### NUnit

Microsoft.Testing.Platform is supported by NUnit3TestAdapter starting with 5.0.0.

To opt-in, add `<EnableNUnitRunner>true</EnableNUnitRunner>` under a `PropertyGroup` in [`Directory.Build.props`](/visualstudio/msbuild/customize-by-directory) file.

### xUnit.net

Microsoft.Testing.Platform is supported starting with xunit.v3.

To opt-in, add `<UseMicrosoftTestingPlatformRunner>true</UseMicrosoftTestingPlatformRunner>` under a `PropertyGroup` in [`Directory.Build.props`](/visualstudio/msbuild/customize-by-directory) file.

## `dotnet test`

### Opt-in for .NET 9 SDK and earlier

In .NET 9 SDK and earlier, there is no *native* support for Microsoft.Testing.Platform for `dotnet test`. Support is built on top of the VSTest infrastructure. To use that, add `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` under a `PropertyGroup` in [`Directory.Build.props`](/visualstudio/msbuild/customize-by-directory) file.

> [!IMPORTANT]
> When running Microsoft.Testing.Platform support in this mode, you need to add `--` to separate the `dotnet test` arguments from the new platform arguments. For example, `dotnet test --no-build -- --list-tests`.

### Opt-in for .NET 10 SDK and later

Starting with .NET 10 SDK, there is *native* support for Microsoft.Testing.Platform. To use it, you must specify the test runner as `Microsoft.Testing.Platform` in *global.json*:

```json
{
  "test": {
    "runner": "Microsoft.Testing.Platform"
  }
}
```

> [!IMPORTANT]
> In this mode, the extra `--` is no longer used.

### Update `dotnet test` invocations

Command line options of `dotnet test` are divided into two categories: build-related arguments and test-related ones.

The build-related arguments are irrelevant to the test platform and as such don't need to be updated for the new platform. Build-related arguments are listed here:

- `-a|--arch <ARCHITECTURE>`
- `--artifacts-path <ARTIFACTS_DIR>`
- `-c|--configuration <CONFIGURATION>`
- `-f|--framework <FRAMEWORK>`
- `-e|--environment <NAME="VALUE">`
- `--interactive`
- `--no-build`
- `--nologo`
- `--no-restore`
- `-o|--output <OUTPUT_DIRECTORY>`
- `--os <OS>`
- `-r|--runtime <RUNTIME_IDENTIFIER>`
- `-v|--verbosity <LEVEL>`

The test-related arguments are VSTest specific and so need to be transformed to match the new platform. The following table shows the mapping between the VSTest arguments and the new platform:

| VSTest argument | New platform argument |
|-----------------|-----------------------|
| `--test-adapter-path <ADAPTER_PATH>` | Not relevant for Microsoft.Testing.Platform |
| `--blame` | Not relevant for Microsoft.Testing.Platform |
| `--blame-crash` | `--crashdump` (requires [Crash dump extension](./microsoft-testing-platform-extensions-diagnostics.md#crash-dump)) |
| `--blame-crash-dump-type <DUMP_TYPE>` | `--crashdump-type` (requires [Crash dump extension](./microsoft-testing-platform-extensions-diagnostics.md#crash-dump)) |
| `--blame-crash-collect-always` | Not supported |
| `--blame-hang` | `--hangdump` (requires [Hang dump extension](./microsoft-testing-platform-extensions-diagnostics.md#hang-dump)) |
| `--blame-hang-dump-type <DUMP_TYPE>` | `--hangdump-type` (requires [Hang dump extension](./microsoft-testing-platform-extensions-diagnostics.md#hang-dump)) |
| `--blame-hang-timeout <TIMESPAN>` | `--hangdump-timeout` (requires [Hang dump extension](./microsoft-testing-platform-extensions-diagnostics.md#hang-dump)) |
| `--collect <DATA_COLLECTOR_NAME>` | Depends on the data collector |
| `-d\|--diag <LOG_FILE>` | `--diagnostic` |
| `--filter <EXPRESSION>` | Depends upon the selected test framework |
| `-l\|--logger <LOGGER>` | Depends on the logger |
| `--results-directory <RESULTS_DIR>` | `--results-directory <RESULTS_DIR>` |
| `-s\|--settings <SETTINGS_FILE>` | Depends upon the selected test framework |
| `-t\|--list-tests` | `--list-tests` |
| `-- <RunSettings arguments>` | `--test-parameter` (provided by [VSTestBridge](microsoft-testing-platform-extensions-vstest-bridge.md)) |

#### `--collect`

`--collect` is a general extensibility point in VSTest for any data collector. The extensibility model of Microsoft.Testing.Platform is different and there is no such centralized argument to be used by all data collectors. With Microsoft.Testing.Platform, each data collector can add its own command-line option. For example, running Microsoft CodeCoverage through VSTest might be similar to the following:

```dotnetcli
dotnet test --collect "Code Coverage;Format=cobertura"
```

With Microsoft.Testing.Platform, this becomes:

```dotnetcli
dotnet test --coverage --coverage-output-format cobertura
```

> [!IMPORTANT]
> As explained earlier, when using Microsoft.Testing.Platform with the VSTest-based `dotnet test`, extra `--` is needed before the arguments intended to be passed to the platform.
> So, this becomes `dotnet test -- --coverage --coverage-output-format cobertura`.

#### `--filter`

`--filter` is the VSTest-based filter. 

MSTest and NUnit support the same filter format even when running with Microsoft.Testing.Platform. 

xUnit.net, does not support the same filter format when running with Microsoft.Testing.Platform. You must migrate from the VSTest-based filter to the new filter support in xunit.v3, which is provided using the following command-line options.

xUnit.net specific options:

- `--filter-class`
- `--filter-not-class`
- `--filter-method`
- `--filter-not-method`
- `--filter-namespace`
- `--filter-not-namespace`
- `--filter-trait`
- `--filter-not-trait`
- `--filter-query`

For more information, see [Microsoft.Testing.Platform documentation for xUnit.net](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform) and [Query Filter Language for xUnit.net](https://xunit.net/docs/query-filter-language).

#### `--logger`

What was usually referred to as "logger" in VSTest is referred to as "reporter" in Microsoft.Testing.Platform. In Microsoft.Testing.Platform, logging is explicitly for diagnosing purposes only.

Similar to `--collect`, `--logger` is a general extensibility point in VSTest for any logger (or, in the context of Microsoft.Testing.Platform, any *reporter*). Each Microsoft.Testing.Platform reporter is free to add its own command-line option, and as such there is no centralized command-line option like VSTest's `--logger`.

One of the very commonly used VSTest loggers is the TRX logger. This logger is usually called as follows:

```dotnetcli
dotnet test --logger trx
```

With Microsoft.Testing.Platform, the command becomes:

```dotnetcli
dotnet test --report-trx
```

> [!IMPORTANT]
> To use `--report-trx`, you must have the `Microsoft.Testing.Extensions.TrxReport` NuGet package installed.
>
> [!IMPORTANT]
> As explained earlier, when using Microsoft.Testing.Platform with the VSTest-based `dotnet test`, extra `--` is needed before the arguments intended to be passed to the platform.
> So, this becomes `dotnet test -- --report-trx`.

#### `--settings`

VSTest's `--settings` is used to specify a RunSettings file for the test run. RunSettings isn't supported by the core Microsoft.Testing.Platform and was replaced by a more modern [`testconfig.json`](./microsoft-testing-platform-config.md) configuration file. However, MSTest and NUnit still support the old RunSettings when running Microsoft.Testing.Platform and `--settings` is still supported.

## `vstest.console.exe`

If you are using `vstest.console.exe` directly, we recommend replacing it with the `dotnet test` command.

## Test Explorer

When using Visual Studio or Visual Studio Code Test Explorer, you might need to enable the support for Microsoft.Testing.Platform.

### Visual Studio

Visual Studio Test Explorer supports Microsoft.Testing.Platform starting with version 17.14. If you are using an earlier version, you might need to update your Visual Studio to the latest version.

### Visual Studio Code

Visual Studio Code with C# DevKit supports Microsoft.Testing.Platform.

## Azure DevOps

When using Azure DevOps tasks, you might need to update your pipeline to use Microsoft.Testing.Platform, depending on which task you use.

### VSTest task

If you're using the [VSTest task](/azure/devops/pipelines/tasks/reference/vstest-v3) in Azure DevOps, you can replace it with the [.NET Core task](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2).

### .NET Core CLI task

- If you have custom `arguments` passed to the task, follow the same guidance for `dotnet test` migration.
- If you're using the [DotNetCoreCLI](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2) task without opting-in to the native Microsoft.Testing.Platform experience for .NET 10 SDK and later via `global.json` file, you need to set the task `arguments` to correctly point to the results directory it used to point to, as well as the requested TRX report. For example:

    ```yml
    - task: DotNetCoreCLI@2
      displayName: Run unit tests
      inputs:
        command: 'test'
        arguments: '-- --report-trx --results-directory $(Agent.TempDirectory)
    ```
