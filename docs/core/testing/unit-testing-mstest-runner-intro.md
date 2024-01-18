---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts (continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, VS Code Text Explorer...). The MSTest runner is embedded directly in your MSTest test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

The MSTest runner is open source, and builds on a `Microsoft.Testing.Platform` library. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The MSTest runner comes bundled with `MSTest in 3.2.0-preview.23623.1` or newer.

## Enable MSTest runner in a MSTest project

To enable the MSTest runner in a MSTest project, you need to add the `EnableMSTestRunner` property and set `OutputType` to `Exe` in your project file, and ensure that you're using `MSTest 3.2.0-preview.23623.1` or newer, consider the following example _*.csproj_ file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the MSTest runner, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>
    <OutputType>Exe</OutputType>

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
    <PackageReference Include="MSTest" Version="3.2.0-preview.23623.1" />

    <!-- 
      Coverlet collector isn't compatible with MSTest runner, you can 
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    --> 
    <PackageReference Include="Microsoft.Testing.Platform.Extensions.CodeCoverage" 
                      Version="17.10.0-preview.23622.1" />
  </ItemGroup>

</Project>
```

## Run and debug tests

MSTest runner test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, as typical with most executables. For more information on the known exit codes, see [MStest runner exit codes](unit-testing-mstest-runner-exit-codes.md).

> [!IMPORTANT]
> By default, the MSTest runner collects telemetry. For more information and options on opting out, see [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md).

### [.NET CLI](#tab/dotnetcli)

Publishing the test project using `dotnet publish` and running the app directly is another way to run your tests. For example, executing the `./Contoso.MyTests.exe`. In some scenarios it's also viable to use `dotnet build` to produce the executable, but there can be edge cases to consider, such [Native AOT](../deploying/native-aot/index.md).

### Use `dotnet run`

The `dotnet run` command can be used to build and run your test project. This is the easiest, although sometimes slowest, way to run your tests. Using `dotnet run` is practical when you're editing and running tests locally, because it ensures that the test project is rebuilt when needed. `dotnet run` will also automatically find the project in the current folder.

```dotnetcli
dotnet run --project Contoso.MyTests
```

For more information on `dotnet run`, see [dotnet run](../tools/dotnet-run.md).

### Use `dotnet exec`

The `dotnet exec` or `dotnet` command is used to execute (or run) an already built test project, this is an alternative to running the application directly. `dotnet exec` requires path to the built test project dll.

```dotnetcli
dotnet exec Contoso.MyTests.dll
```

or

```dotnetcli
dotnet Contoso.MyTests.dll
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

### Use `dotnet test`

MSTest runner offers a compatibility layer with `vstest.console.exe` and [`dotnet test`](../tools/dotnet-test.md) ensuring you can run your tests as before while enabling new execution scenario.

```dotnetcli
dotnet test Contoso.MyTests.dll
```

### [Visual Studio](#tab/visual-studio)

The `Microsoft.Testing.Platform` tests can be run (and debugged) in Visual Studio, they integrate with Test Explorer, and can also be run directly as startup project.

#### Run the app with Visual Studio

`Microsoft.Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Select **Debug** > **Start without Debugging** (or use <kbd>Ctrl</kbd>+<kbd>F5</kbd>) to run the selected test project.

Console window pops up with the execution and summary of your test run.

### Debug the app directly in Visual Studio

`Microsoft.Testing.Platform` test project can be debugged directly. To debug all the tests in the given executable, unless a filter is provided:

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Set breakpoint into the test that you'd like to debug.
1. Go to **Debug** > **Start Debugging** (or press <kbd>F5</kbd>) to debug the selected test project.

All tests are executed until your test with a breakpoint is reached. Step through your test to debug it. Once you're done debugging the app resumes running all remaining tests, unless you stop it.

### Use Test Explorer

To run a test, navigate to **Test Explorer**, select the test (or tests) to run. Right select it, and choose **Run**. Similarly to debug a test, select the test (or tests) in **Test Explorer**, right select and choose **Debug**.

> [!TIP]
> Automatic update of tests without building the project isn't available.

### [Visual Studio Code](#tab/visual-studio-code)

The C# extension along with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) allows you to debug/run tests in Visual Studio code, as well as adds integration with Visual Studio Code's Test Explorer.

#### Run the app with Visual Studio

`Microsoft.Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate to a test file that you want to run tests for.
1. Use <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the selected test project. If you have multiple projects a popup will ask you to select the one to run.

Console window pops up with the execution and summary of your test run.

#### Debug the app directly in Visual Studio Code

`Microsoft.Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate to a test file that you want to run tests for.
1. Use <kbd>F5</kbd> to debug the selected test project. If you have multiple projects a popup will ask you to select the one to run.

> [!TIP]
> There are several other ways to run a dotnet project using C# DevKit, such as running from solution explorer
> or creating corresponding launch configurations. These are specified in the [Visual Studio Code documentation](https://code.visualstudio.com/docs/csharp/debugging).

As the project is run the output tab pops up with the execution and summary of your test run.

### Use Test Explorer

To run a test, navigate to **Test Explorer**, select the test (or tests) to run. Right select it, and choose **Run**. Similarly to debug a test, select the test (or tests) in **Test Explorer**, right select and choose **Debug**.

> [!TIP]
> Automatic update of tests without building the project isn't available.

### [Continuous integration (CI)](#tab/continuous-integration)

There's no special pipeline task, or any extra tooling to run `Testing.Platform` tests. There's also no other tooling required to run multiple tests projects through a single command.

To run a test project in CI add one step for each test executable that you wish to run, such as this on Azure DevOps:

```yml
- task: CmdLine@2
  displayName: "Run Contoso.MyTests"
  inputs:
    script: '.\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
```

---

## Options

- **`--diagnostic`**

Enables the diagnostic logging. The default log level is `Information`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`.

- **`--diagnostic-filelogger-synchronouswrite`**

Forces the built-in file logger to synchronously write logs. Useful for scenarios where you don't want to lose any log entries (if the process crashes). This does slow down the test execution.

- **`--diagnostic-output-directory`**

The output directory of the diagnostic logging, if not specified the file is generated in the default _TestResults_ directory.

- **`--diagnostic-output-fileprefix`**

The prefix for the log file name. Defaults to `"log_"`.

- **`--diagnostic-verbosity`**

Defines the verbosity level when the `--diagnostic` switch is used. The available values are `Trace`, `Debug`, `Information`, `Warning`, `Error`, or `Critical`.

- **`--help`**

Prints out a description of how to use the command.

- **`-ignore-exit-code`**

Allows some non-zero exit codes to be ignored, and instead returned as `0`. For more information, see [Ignore specific exit codes](./unit-testing-mstest-runner-exit-codes.md#ignore-specific-exit-codes).

- **`--info`**

Displays advanced information about the .NET Test Application such as:

- The platform.
- The environment.
- Each registered command line provider, such as its, `name`, `version`, `description` and `options`.
- Each registered tool, such as its, `command`, `name`, `version`, `description`, and all command line providers.

This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

- **`--list-tests`**

List available tests. Tests will not be executed.

- **`--results-directory`**

The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

## See also

- [MSTest runner and VSTest comparison](unit-testing-mstest-runner-vs-vstest.md)
- [MSTest runner extensions](unit-testing-mstest-runner-extensions.md)
- [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md)
- [MSTest runner exit codes](unit-testing-mstest-runner-exit-codes.md)
