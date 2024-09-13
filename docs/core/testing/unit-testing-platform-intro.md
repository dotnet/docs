---
title: Microsoft.Testing.Platform overview
description: Learn about Microsoft.Testing.Platform, a lightweight way to run tests without depending on the .NET SDK.
author: Evangelink
ms.author: amauryleve
ms.date: 03/17/2024
---

# Microsoft.Testing.Platform overview

Microsoft.Testing.Platform is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts, including continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Text Explorer. The Microsoft.Testing.Platform is embedded directly in your test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

`Microsoft.Testing.Platform` is open source. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Supported test frameworks

* MSTest. In MSTest, the support of `Microsoft.Testing.Platform` is done via [MSTest runner](unit-testing-mstest-runner-intro.md).
* NUnit. In NUnit, the support of `Microsoft.Testing.Platform` is done via [NUnit runner](unit-testing-nunit-runner-intro.md).
* xUnit.net: In xUnit.net, the support of `Microsoft.Testing.Platform` is done via [xUnit.net runner](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform).
* TUnit: entirely constructed on top of the `Microsoft.Testing.Platform`, for more information, see [TUnit documentation](https://thomhurst.github.io/TUnit/)

## Run and debug tests

`Microsoft.Testing.Platform` test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, as typical with most executables. For more information on the known exit codes, see [Microsoft.Testing.Platform exit codes](unit-testing-platform-exit-codes.md).

> [!IMPORTANT]
> By default, `Microsoft.Testing.Platform` collects telemetry. For more information and options on opting out, see [Microsoft.Testing.Platform telemetry](unit-testing-platform-telemetry.md).

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

`Microsoft.Testing.Platform` offers a compatibility layer with `vstest.console.exe` and [`dotnet test`](../tools/dotnet-test.md) ensuring you can run your tests as before while enabling new execution scenario.

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

> [!NOTE]
> Automatic update of tests without building the project isn't available.

### [Visual Studio Code](#tab/visual-studio-code)

The C# extension along with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) allows you to debug/run tests in Visual Studio code, as well as adds integration with Visual Studio Code's Test Explorer.

#### Run the app with Visual Studio Code

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

> [!NOTE]
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

The list below described only the platform options. To see the specific options brought by each extension, either refer to the extension documentation page or use the `--help` option.

- **`--diagnostic`**

Enables the diagnostic logging. The default log level is `Trace`. The file is written in the output directory with the following name format, `log_[MMddHHssfff].diag`.

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

Allows some non-zero exit codes to be ignored, and instead returned as `0`. For more information, see [Ignore specific exit codes](./unit-testing-platform-exit-codes.md#ignore-specific-exit-codes).

- **`--info`**

Displays advanced information about the .NET Test Application such as:

- The platform.
- The environment.
- Each registered command line provider, such as its, `name`, `version`, `description` and `options`.
- Each registered tool, such as its, `command`, `name`, `version`, `description`, and all command line providers.

This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

- **`--list-tests`**

List available tests. Tests will not be executed.

- **`--minimum-expected-tests`**

Specifies the minimum number of tests that are expected to run. By default, at least one test is expected to run.

- **`--results-directory`**

The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

## MSBuild integration

The NuGet package [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) provides various integrations for `Microsoft.Testing.Platform` with MSBuild:

- Support for `dotnet test`. For more information, see [dotnet test integration](./unit-testing-platform-integration-dotnet-test.md).
- Support for `ProjectCapability` required by `Visual Studio` and `Visual Studio Code` Test Explorers.
- Automatic generation of the entry point (`Main` method).
- Automatic generation of the configuration file.

> [!NOTE]
> This integration works in a transitive way (a project that references another project referencing this package will behave as if it references the package) and can be disabled through the `IsTestingPlatformApplication` MSBuild property.

## See also

- [Microsoft.Testing.Platform and VSTest comparison](unit-testing-platform-vs-vstest.md)
- [Microsoft.Testing.Platform extensions](unit-testing-platform-extensions.md)
- [Microsoft.Testing.Platform telemetry](unit-testing-platform-telemetry.md)
- [Microsoft.Testing.Platform exit codes](unit-testing-platform-exit-codes.md)
