---
title: Run and debug tests with Microsoft.Testing.Platform
description: Learn how to run and debug Microsoft.Testing.Platform test projects from CLI, Visual Studio, Visual Studio Code, and CI pipelines.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Run and debug tests

`Microsoft.Testing.Platform` test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, which is typical for most executables. For more information on the known exit codes, see [Microsoft.Testing.Platform exit codes](microsoft-testing-platform-troubleshooting.md#exit-codes).

> [!TIP]
> You can ignore a specific [exit code](./microsoft-testing-platform-troubleshooting.md#ignore-specific-exit-codes) using the `--ignore-exit-code` command line option.
>
> You can also set command line options that apply to a specific test project in the project file using the [`TestingPlatformCommandLineArguments`](../project-sdk/msbuild-props.md#testingplatformcommandlinearguments) MSBuild property. One common use case is for test projects that have all the tests ignored, which will normally exit with exit code 8 (the test session ran zero tests). In this scenario, you can add the following under a `PropertyGroup` in your project file:
>
> ```xml
> <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
> ```

> [!IMPORTANT]
> By default, `Microsoft.Testing.Platform` collects telemetry. For more information and options on opting out, see [Microsoft.Testing.Platform telemetry](microsoft-testing-platform-telemetry.md).

## [.NET CLI](#tab/dotnetcli)

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
>     previously found assembly: 'S:\t\Contoso.MyTests\bin\Debug\net10.0\Contoso.MyTests.exe'
> ```

For more information on `dotnet exec`, see [dotnet exec](../tools/dotnet.md#options-for-running-an-application-with-the-exec-command).

### Use `dotnet test`

`Microsoft.Testing.Platform` offers a compatibility layer with `vstest.console.exe` and [`dotnet test`](../tools/dotnet-test.md) ensuring you can run your tests as before while enabling new execution scenario.

```dotnetcli
dotnet test Contoso.MyTests.dll
```

## [Visual Studio](#tab/visual-studio)

The `Microsoft.Testing.Platform` tests can be run (and debugged) in Visual Studio, they integrate with Test Explorer, and can also be run directly as startup project.

### Run the app with Visual Studio

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

## [Visual Studio Code](#tab/visual-studio-code)

The C# extension along with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) allows you to debug/run tests in Visual Studio code, as well as adds integration with Visual Studio Code's Test Explorer.

### Run the app with Visual Studio Code

`Microsoft.Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate to a test file that you want to run tests for.
1. Use <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the selected test project. If you have multiple projects a popup will ask you to select the one to run.

Console window pops up with the execution and summary of your test run.

### Debug the app directly in Visual Studio Code

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

## [Continuous integration (CI)](#tab/continuous-integration)

- To run a single test project in CI, add one step for each test executable that you wish to run, such as the following on Azure DevOps:

  ```yml
  - task: CmdLine@2
    displayName: "Run Contoso.MyTests"
    inputs:
      script: '.\Contoso.MyTests\bin\Debug\net10.0\Contoso.MyTests.exe'
  ```

- Run the `dotnet test` command manually, similar to the typical local workflow:

  ```yml
  - task: CmdLine@2
    displayName: "Run tests"
    inputs:
      script: 'dotnet test' # add command-line options as needed
  ```

- Run using the `DotNetCoreCLI` Azure task with test command. This requires a [`global.json`](../tools/global-json.md) file in your repository root that specifies Microsoft.Testing.Platform as the test runner:

  ```json
  {
      "test": {
          "runner": "Microsoft.Testing.Platform"
      }
  }
  ```

  ```yml
  - task: DotNetCoreCLI@2
    displayName: "Run tests"
    inputs:
      command: test
  ```

  > [!NOTE]
  > Support for Microsoft.Testing.Platform in `DotNetCoreCLI` was added in [2.263.0](https://github.com/microsoft/azure-pipelines-tasks/pull/21315) version of the task.

---

## See also

- [Microsoft.Testing.Platform overview](./microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform CLI options reference](./microsoft-testing-platform-cli-options.md)
- [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
