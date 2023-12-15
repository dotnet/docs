---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in continuous integration (CI) pipelines, and in Visual Studio Test Explorer. The MSTest runner is embedded directly in your MSTest test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

The MSTest runner is open source, and builds on a Microsoft.`Testing.Platform` library. You can find Microsoft.`Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.`Testing.Platform`) GitHub repository. The MSTest runner comes bundled with MSTest in 3.2.0-preview. This preview is available in the [test-tools NuGet feed](https://pkgs.dev.azure.com/dnceng/public/_packaging/test-tools/nuget/v3/index.json).

## Enable MSTest runner in a MSTest project

To enable the MSTest runner in an MSTest project, you need to add the `UseMSTestRunner` in your project file, and unsure that you're using MSTest 3.2.0-preview or newer, consider the following example _*.csproj_ file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the MSTest runner, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <!-- 
      MSTest meta package is the recommended way to reference MSTest.
      It's equivalent to referencing:
          Microsoft.NET.Test.Sdk
          MSTest.TestAdapter
          MSTest.TestFramework
          MSTest.Analyzers
    -->    
    <PackageReference Include="MSTest" Version="3.2.0-preview.23570.1" />

    <!-- 
      Coverlet collector isn't compatible with MSTest runner, you can 
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    --> 
    <PackageReference Include="Microsoft.`Testing.Platform`.Extensions.CodeCoverage" 
                      Version="17.9.4-beta.23563.1" />
  </ItemGroup>

</Project>
```

## Run and debug tests

MSTest runner test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, as typical with most executables. For more information on the known exit codes, see [MStest runner exit codes](unit-testing-mstest-runner-exit-codes.md).

> [!IMPORTANT]
> By default, the MStest runner collects telemetry. For more information and options on opting out, see [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md).

### [.NET CLI](#tab/dotnetcli)

## Run the app with .NET CLI

Publishing the test project using `dotnet publish` and running the app directly is another way to run your tests. For example, executing the `./Contoso.MyTests.exe`. In some scenarios it's also viable to use `dotnet build` to produce the executable, but there can be edge cases to consider, such [Native AOT](../deploying/native-aot/index.md).

### Use `dotnet run`

The `dotnet run` command can be used to build and run your test project. This is the easiest, although sometimes slowest, way to run your tests. Using `dotnet run` is practical when you're editing and running tests locally, because it ensures that the test project is rebuilt when needed. `dotnet run` will also automatically find the project in the current folder.

```dotnetcli
dotnet run --project Contoso.MyTests
```

For more information on `dotnet run`, see [dotnet run](../tools/dotnet-run.md).

### Use `dotnet exec`

The `dotnet exec` command is used to execute (or run) an already built test project, this is an alternative to running the application directly. `dotnet exec` requires path to the built test project dll.

```dotnetcli
dotnet exec Contoso.MyTests.dll
```

> [!NOTE]
> Providing the path to the test project executable (_*.exe_) results in an error:
>
> ```Output
> Error:
>   An assembly specified in the application dependencies manifest
>   (Contoso.MyTests.deps.json) has already been found but with a different
>   file extension:
>     package: 'Contoso.MyTests', version: '1.0.0'
>     path: 'Contoso.MyTests.dll'
>     previously found assembly: 'S:\t\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
> ```

For more information on `dotnet exec`, see [dotnet exec](../tools/dotnet.md#options-for-running-an-application-with-the-exec-command).

#### Use `dotnet test`

For tests authored with MSTest, NUnit or xUnit test framework, it's possible to run tests with [dotnet test](../tools/dotnet-test.md). The `dotnet test` command only works with MSTest, NUnit and xUnit tests. Provide a path to the tested dll, or to the project and your tests run:

```dotnetcli
dotnet test Contoso.MyTests.dll
```

### [Visual Studio](#tab/visual-studio)

`Testing.Platform` tests can be run (and debugged) in Visual Studio, they integrate with Test Explorer, and can also be run directly as startup project.

#### Run the app with Visual Studio

`Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Select **Debug** > **Start without Debugging** (or use <kbd>Ctrl</kbd>+<kbd>F5</kbd>) to run the selected test project.

Console window pops up with the execution and summary of your test run.

#### Debug the app directly in Visual Studio

`Testing.Platform` test project can be debugged directly. To debug all the tests in the given executable, unless a filter is provided:

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Set breakpoint into the test that you'd like to debug.
1. Go to **Debug** > **Start Debugging** (or press <kbd>F5</kbd>) to debug the selected test project.

All tests are executed until your test with a breakpoint is reached. Step through your test to debug it. Once you're done debugging the app resumes running all remaining tests, unless you stop it.

### Use Test Explorer

`Testing.Platform` tests partially integrate with Visual Studio's **Test Explorer**. Tests can be run and debugged from **Test Explorer**.

To run a test, navigate to **Test Explorer**, select the test (or tests) to run. Right select it, and choose **Run**. Similarly to debug a test, select the test (or tests) in **Test Explorer**, right select and choose **Debug**.

> [!TIP]
> Automatic update of tests without building the project isn't available.

## In continuous integration (CI)

There's no special pipeline task, or any extra tooling to run `Testing.Platform` tests. There's also no other tooling required to run multiple tests projects through a single command.

To run a test project in CI add one step for each test executable that you wish to run, such as this on Azure DevOps:

```yml
- task: CmdLine@2
  displayName: "Run Contoso.MyTests.exe"
  inputs:
    script: '.\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
```

## Extensions

The MSTest runner supports extensions that can be used to customize the behavior of the test runner.

### Test reports

A test report is a file that contains information about the execution and outcome of the tests

#### Visual Studio test reports

The Visual Studio test result file (or TRX) is the default format for publishing test results. The available options as follows:

| Option | Description |
|--|--|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.

## Troubleshoot

The Microsoft `Testing.Platform` offers some built-in functionalities and extensions that ease the troubleshooting of your test apps.

### `--info` option

When you run your `Testing.Platform` test app with the `--info` switch, the platform displays advanced information about:

- The platform.
- The environment.
- Each registered command line provider, such as its, `name`, `version`, `description` and `options`.
- Each registered tool, such as its, `command`, `name`, `version`, `description`, and all command line providers.

This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

### Diagnostic logs

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

### Hang dump files

This extension allows you to create a dump file after a given timeout. To configure the hang dump file generation, use the following options:

| Option | Description |
|--|--|
| `--hangdump` | Generates a dump file in case the test host process hangs. |
| `-⁠-⁠hangdump-⁠filename` | Specifies the file name of the dump. |
| `--hangdump-timeout` | Specifies the timeout after which the dump is generated. The timeout value is specified in one of the following formats:<br/>`1.5h`, `1.5hour`, `1.5hours`<br/>`90m`, `90min`, `90minute`, `90minutes`<br/>`5400s`, `5400sec`, `5400second`, `5400seconds`. Defaults to `30m` (30 minutes). |
| `--hangdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|

### Crash dump files

This extension allows you to create a crash dump file if the process crashes. To configure the crash dump file generation, use the following options:

| Option | Description |
|--|--|
| `--crashdump` | Generates a dump file when the test host process crashes. Supported in .NET 6.0+. |
| `⁠-⁠-⁠crashdump-⁠filename` | Specifies the file name of the dump. |
| `--crashdump-type` | Specifies the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Defaults as `Full`. For more information, see [Types of mini dumps](../diagnostics/collect-dumps-crash.md#types-of-mini-dumps).|

## See also

- [MSTest runner and VSTest comparison](unit-testing-mstest-runner-vs-vstest.md)
- [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md)
- [MSTest runner exit codes](unit-testing-mstest-runner-exit-codes.md)
