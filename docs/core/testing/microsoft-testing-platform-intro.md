---
title: Microsoft.Testing.Platform overview
description: Learn about Microsoft.Testing.Platform, a lightweight way to run tests without depending on the .NET SDK.
author: Evangelink
ms.author: amauryleve
ms.date: 03/17/2024
---

# Microsoft.Testing.Platform overview

Microsoft.Testing.Platform is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts, including continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, and VS Code Test Explorer. The Microsoft.Testing.Platform is embedded directly in your test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

`Microsoft.Testing.Platform` is open source. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Microsoft.Testing.Platform pillars

This new testing platform is built on the .NET Developer Experience Testing team's experience and aims to address the challenges encountered since the release of .NET Core in 2016. While there's a high level of compatibility between the .NET Framework and the .NET Core/.NET, some key features like the plugin-system and the new possible form factors of .NET compilations have made it complex to evolve or fully support the new runtime feature with the current [VSTest platform](https://github.com/microsoft/vstest) architecture.

The main driving factors for the evolution of the new testing platform are detailed in the following:

* **Determinism**: Ensuring that running the same tests in different contexts (local, CI) will produce the same result. The new runtime does not rely on reflection or any other dynamic .NET runtime feature to coordinate a test run.

* **Runtime transparency**: The test runtime does not interfere with the test framework code, it does not create isolated contexts like `AppDomain` or `AssemblyLoadContext`, and it does not use reflection or custom assembly resolvers.

* **Compile-time registration of extensions**: Extensions, such as test frameworks and in/out-of-process extensions, are registered during compile-time to ensure determinism and to facilitate detection of inconsistencies.

* **Zero dependencies**: The core of the platform is a single .NET assembly, `Microsoft.Testing.Platform.dll`, which has no dependencies other than the supported runtimes.

* **Hostable**: The test runtime can be hosted in any .NET application. While a console application is commonly used to run tests, you can create a test application in any type of .NET application. This allows you to run tests within special contexts, such as devices or browsers, where there may be limitations.

* **Support all .NET form factors**: Support current and future .NET form factors, including Native AOT.

* **Performant**: Finding the right balance between features and extension points to avoid bloating the runtime with non-fundamental code. The new test platform is designed to "orchestrate" a test run, rather than providing implementation details on how to do it.

* **Extensible enough**: The new platform is built on extensibility points to allow for maximum customization of runtime execution. It allows you to configure the test process host, observe the test process, and consume information from the test framework within the test host process.

* **Single module deploy**: The hostability feature enables a single module deploy model, where a single compilation result can be used to support all extensibility points, both out-of-process and in-process, without the need to ship different executable modules.

## Supported test frameworks

* MSTest. In MSTest, the support of `Microsoft.Testing.Platform` is done via [MSTest runner](unit-testing-mstest-runner-intro.md).
* NUnit. In NUnit, the support of `Microsoft.Testing.Platform` is done via [NUnit runner](unit-testing-nunit-runner-intro.md).
* xUnit.net: In xUnit.net, the support of `Microsoft.Testing.Platform` is done via [xUnit.net runner](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform).
* TUnit: entirely constructed on top of the `Microsoft.Testing.Platform`, for more information, see [TUnit documentation](https://tunit.dev/).

## Run and debug tests

`Microsoft.Testing.Platform` test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, which is typical for most executables. For more information on the known exit codes, see [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md).

> [!TIP]
> You can ignore a specific [exit code](./microsoft-testing-platform-exit-codes.md) using the [`--ignore-exit-code`](#options) command line option.
>
> You can also set command line options that apply to a specific test project in the project file using the [`TestingPlatformCommandLineArguments`](../project-sdk/msbuild-props.md#testingplatformcommandlinearguments) MSBuild property. One common use case is for test projects that have all the tests ignored, which will normally exit with exit code 8 (the test session ran zero tests). In this scenario, you can add the following under a `PropertyGroup` in your project file:
>
> ```xml
> <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
> ```

> [!IMPORTANT]
> By default, `Microsoft.Testing.Platform` collects telemetry. For more information and options on opting out, see [Microsoft.Testing.Platform telemetry](microsoft-testing-platform-telemetry.md).

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

- **`@`**

  Specifies the name of the response file. The response file name must immediately follow the @ character with no white space between the @ character and the response file name.

  Options in a response file are interpreted as if they were present at that place in the command line. Each argument in a response file must begin and end on the same line. You cannot use the backslash character (\) to concatenate lines. Using a response file helps for very long commands that might exceed the terminal limits. You can combine a response file with inline command-line arguments. For example:

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

- **`--config-file`**

  Specifies a [*testconfig.json*](microsoft-testing-platform-config.md) file.

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

- **`--exit-on-process-exit`**

  Exit the test process if dependent process exits. PID must be provided.

- **`--help`**

  Prints out a description of how to use the command.

- **`--ignore-exit-code`**

  Allows some non-zero exit codes to be ignored, and instead returned as `0`. For more information, see [Ignore specific exit codes](./microsoft-testing-platform-exit-codes.md#ignore-specific-exit-codes).

- **`--info`**

  Displays advanced information about the .NET Test Application such as:

  - The platform.
  - The environment.
  - Each registered command line provider, such as its `name`, `version`, `description`, and `options`.
  - Each registered tool, such as its `command`, `name`, `version`, `description`, and all command-line providers.

  This feature is used to understand extensions that would be registering the same command line option or the changes in available options between multiple versions of an extension (or the platform).

- **`--list-tests`**

  List available tests. Tests will not be executed.

- **`--maximum-failed-tests`**

  Specifies the maximum number of tests failures that, when reached, will stop the test run. Support for this switch requires framework authors to implement the `IGracefulStopTestExecutionCapability` capability. The exit code when reaching that amount of test failures is 13. For more information, see [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md).

  > [!NOTE]
  > This feature is available in Microsoft.Testing.Platform starting with version 1.5.

- **`--minimum-expected-tests`**

  Specifies the minimum number of tests that are expected to run. By default, at least one test is expected to run.

- **`--results-directory`**

  The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.

- **`--timeout`**

  A global test execution timeout. Takes one argument as string in the format `<value>[h|m|s]` where `<value>` is float.

## MSBuild integration

The NuGet package [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) provides various integrations for `Microsoft.Testing.Platform` with MSBuild:

- Support for `dotnet test`. For more information, see [Testing with dotnet test](./unit-testing-with-dotnet-test.md).
- Support for `ProjectCapability` required by `Visual Studio` and `Visual Studio Code` Test Explorers.
- Automatic generation of the entry point (`Main` method).
- Automatic generation of the configuration file.

> [!NOTE]
> This integration works in a transitive way (a project that references another project referencing this package will behave as if it references the package) and can be disabled through the `IsTestingPlatformApplication` MSBuild property.

## See also

- [Microsoft.Testing.Platform and VSTest comparison](microsoft-testing-platform-vs-vstest.md)
- [Microsoft.Testing.Platform extensions](microsoft-testing-platform-extensions.md)
- [Microsoft.Testing.Platform telemetry](microsoft-testing-platform-telemetry.md)
- [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-exit-codes.md)
