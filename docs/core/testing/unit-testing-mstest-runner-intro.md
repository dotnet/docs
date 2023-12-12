---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 11/28/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in continuous integration (CI) pipelines, and in Visual Studio Test Explorer.

The MSTest runner is embedded directly in your MSTest test projects, and there's no additional app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

The MSTest runner open source and you can view its code in the [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The MSTest runner comes bundled with MSTest in 3.2.0-preview. This preview is available in the [test-tools NuGet feed](https://pkgs.dev.azure.com/dnceng/public/_packaging/test-tools/nuget/v3/index.json).

## Enable MSTest runner in a MSTest project

To enable the MSTest Runner in an MSTest project, you need to add `UseMSTestRunner` into your project file, and make sure you are using MSTest 3.2.0-preview or newer, consider the following example _*.csproj_ file:

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
      It's equivalent to referencing: Microsoft.NET.Test.Sdk, MSTest.TestAdapter, MSTest.TestFramework and MSTest.Analyzers
    -->    
    <PackageReference Include="MSTest" Version="3.2.0-preview.23570.1" />

    <!-- 
      Coverlet collector is not compatible with MSTest runner, you can either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    --> 
    <PackageReference Include="Microsoft.Testing.Platform.Extensions.CodeCoverage" 
                      Version="17.9.4-beta.23563.1" />
  </ItemGroup>

</Project>
```

Building the application will generate an executable application for your test project. For example `Contoso.MyTests.exe` on Windows.

## Run and debug tests

> [!IMPORTANT]
> By default, the MStest runner collects telemetry. For more information and options on opting out, see [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md).

MSTest runner test projects are built as executables that can be run (or debugged) directly. There's no additional test running console or command that's needed.

The app exits with a non-zero exit code in case of an error, as typical with most executables. For more information on the known exit codes, see [MStest runner exit codes](unit-testing-mstest-runner-exit-codes.md).

### [.NET CLI](#tab/dotnetcli)

## Run the app with .NET CLI

Publishing the test project using `dotnet publish` and running the app directly is another way to run your tests. For example, executing the `./Contoso.MyTests.exe`. In some scenarios it's also viable to use `dotnet build` to produce the executable, but there can be edge cases to consider, such as when using Native AOT.

### Use `dotnet run`

The `dotnet run` command can be used to build and run your test project. This is the easiest, although sometimes slowest, way to run your tests. Using `dotnet run` is practical when you are editing and running tests locally, because it ensures that the test project is re-built when needed. `dotnet run` will also automatically find the project in the current folder.

### Use `dotnet exec`

`dotnet exec` can be used to run an already built test project, this is an alternative to running the application directly. `dotnet exec` requires path to the built test project dll.

> [!IMPORTANT]
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

#### Use `dotnet test`

> > [!IMPORTANT]
> The `dotnet test` command only works with MSTest, NUnit and xUnit tests.

For tests authored with MSTest, NUnit or xUnit test framework, it's possible to run tests with `dotnet test`.

Provide a path to the tested dll, or to the project and your tests will run.

### [Visual Studio](#tab/visual-studio)

Testing.Platform tests can be run (and debugged) in VisualStudio, they integrate with Test Explorer, and can also be run directly as Startup Project.

#### Run the app with Visual Studio

Testing.Platform test project are built as executables, and can be run directly. This will run all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right click it and select `Set as Startup Project`.

1. Select **Debug** > **Start without Debugging** (or use <kbd>Ctrl</kbd>+<kbd>F5</kbd>) to run the selected test project.

Console window will pop up with the execution and summary of your test run.

#### Debugging the application directly in VS

Testing.Platform test project are built as executables, and can be debugged directly. This will debug all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right click it and select `Set as Startup Project`.

1. Set breakpoint into the test that you'd like to debug.

1. Go to `Debug > Start Debugging`, (or press `F5`) to debug the selected test project.

All tests will be executed until your test with a breakpoint is reached. Step through your test to debug it. Once you are done debugging the application will resume running all remaining tests, unless you stop it.

### Using Test Explorer

Testing.Platform tests partially integrate with Test Explorer. Tests can be Run and Debugged from Test Explorer.

> [!IMPORTANT]
> Automatic update of tests without building the project is not yet available.

To run a test, navigate to Test Explorer, select the test (or tests) to run. Right click it, and choose `Run`.

Similarly to debug a test, select the test (or tests) in Test Explorer, right click and choose `Debug`.

## In Continuous Integration (CI)

There is no special pipeline task, or any additional tooling to run Testing.Platform tests. There is also no additional tooling to run multiple tests projects through a single command.

To run a test project in CI add one step for each test executable that you wish to run, such as this on AzureDevOps:

```yml
- task: CmdLine@2
  displayName: "Run Contonso.MyTests.exe"
  inputs:
    script: '.\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
```

## Extensions

### Test Reports

A test report is a file that contains information about the execution and outcome of the tests

#### TRX Test Report

Visual Studio Test Result file (TRX) is the default format for publishing test results.

Available options:

| Option | Description |
| ------ | ----------- |
| `--report-trx` | Generate the TRX report. |
| `--report-trx-filename` | Name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report will be saved inside the default `TestResults` folder that can be specified through the `--results-directory` command line argument.

## Troubleshooting

Microsoft Testing Platform offers some built-in functionalities and some extensions to ease troubleshooting of your test application.

### `--info` option

When running your Testing.Platform test application with the `--info` options, the platform will display advanced information about:

- the platform
- the environment
- for each registered command line providers: name, version, description and options
- for each registered tool: command, name, version, description and then all command line providers (with the same specification as above)

This feature can be used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

### Diagnostics logs

The platform can produce diagnostic logs that are helpful to understand what is happening during the execution of your test application.

The following options are available to configure the produced diagnostic logs:

| Option | Description |
| ------ | ----------- |
| `--diagnostic` | Enable the diagnostic logging. The default log level is `Information`. The file will be written in the output directory with the name `log_[MMddHHssfff].diag` |
| `⁠-⁠-⁠diagnostic-⁠filelogger-⁠synchronouswrite` | Force the built-in file logger to write the log synchronously. Useful for scenario where you don't want to lose any log (i.e. in case of crash). The effect is to slow down the test execution. |
| `--diagnostic-verbosity` | Define the level of the verbosity for the `--diagnostic`. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical` |
| `--diagnostic-output-fileprefix` | Prefix for the log file name that will replace [log]_. |
| `--diagnostic-output-directory` |  Output directory of the diagnostic logging, if not specified the file will be generated inside the default `TestResults` directory. |

You can enable the diagnostics logs also using the environment variables.

| Environment variable name | Description |
| ------ | ----------- |
| `TESTINGPLATFORM_DIAGNOSTIC` | If set to `1` enable the diagnostic logging.  |
| `TESTINGPLATFORM_DIAGNOSTIC_VERBOSITY` | Define the level of the verbosity. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical`  |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_DIRECTORY` | Output directory of the diagnostic logging, if not specified the file will be generated inside the default `TestResults` directory. |
| `TESTINGPLATFORM_DIAGNOSTIC_OUTPUT_FILEPREFIX` | Prefix for the log file name that will replace [log]_. |
| `TESTINGPLATFORM_DIAGNOSTIC_FILELOGGER_SYNCHRONOUSWRITE` | Force the built-in file logger to write the log synchronously. Useful for scenario where you don't want to lose any log (i.e. in case of crash). The effect is to slow down the test execution. |

**Environment variables take precedence on the command line arguments.**

### Hang Dump

This extension allows to create a dump file after a given timeout.

It can be configured using the following options:

| Option | Description |
| ------ | ----------- |
| `--hangdump` | Generated a dump file in case of test host process hang. |
| `-⁠-⁠hangdump-⁠filename` | Specify the file name of the dump. |
| `--hangdump-timeout` | Specify the timeout after which the dump will be generated. The timeout value is specified in one of the following formats:<br/>1.5h, 1.5hour, 1.5hours<br/>90m, 90min, 90minute, 90minutes<br/>5400s, 5400sec, 5400second, 5400seconds. Default is 30m. |
| `--hangdump-type` | Specify the type of the dump. Valid values are `Mini`, `Heap`, `Triage` (only .NET 6+), `Full`. Default type is `Full`. For more information visit [MS Learn Crash Dump Types](https://learn.microsoft.com/dotnet/core/diagnostics/collect-dumps-crash#types-of-mini-dumps) |

### Crash Dump

This extension allows to create a crash dump file in case of process crash.

It can be configured using the following options:

| Option | Description |
| ------ | ----------- |
| `--crashdump` | Generated a dump file in case of test host process crash. Supported by .NET 6.0+ |
| `⁠-⁠-⁠crashdump-⁠filename` | Specify the file name of the dump. |
| `--crashdump-type` | Specify the type of the dump. Valid values are `Mini`, `Heap`, `Triage`, `Full`. Default type is `Full`. For more information visit [MS Learn Crash Dump Types](https://learn.microsoft.com/dotnet/core/diagnostics/collect-dumps-crash#types-of-mini-dumps) |
