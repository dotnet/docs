---
title: Run and debug tests with Microsoft.Testing.Platform (MTP)
description: Learn how to run and debug MTP test projects from CLI, Visual Studio, Visual Studio Code, and CI pipelines.
author: Evangelink
ms.author: amauryleve
ms.date: 11/10/2026
ai-usage: ai-assisted
---

# Run and debug tests

MTP test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, which is typical for most executables. For more information on the known exit codes, see [MTP exit codes](microsoft-testing-platform-troubleshooting.md#exit-codes).

> [!TIP]
> You can ignore a specific [exit code](./microsoft-testing-platform-troubleshooting.md#ignore-specific-exit-codes) using the `--ignore-exit-code` command line option.
>
> You can also set command line options that apply to a specific test project in the project file using the [`TestingPlatformCommandLineArguments`](../project-sdk/msbuild-props.md#testingplatformcommandlinearguments) MSBuild property. One common use case is for test projects that have all the tests ignored, which will normally exit with exit code 8 (the test session ran zero tests). In this scenario, you can add the following under a `PropertyGroup` in your project file:
>
> ```xml
> <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
> ```

> [!IMPORTANT]
> By default, MTP collects telemetry. For more information and options on opting out, see [MTP telemetry](microsoft-testing-platform-telemetry.md).

> [!NOTE]
> Available in MTP starting with version 2.3.0.
>
> For a graceful stop, press <kbd>Ctrl</kbd>+<kbd>C</kbd> once to request cancellation. Running tests can finish teardown. To terminate immediately, press <kbd>Ctrl</kbd>+<kbd>C</kbd> again.

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

Starting with the .NET 10 SDK, [`dotnet test`](../tools/dotnet-test-mtp.md) has a dedicated MTP mode. Select MTP through `global.json`, or use the `DOTNET_TEST_RUNNER` environment variable with .NET 11 or later. The dedicated mode supports projects, solutions, built test modules, and additional input types in newer SDK versions.

```dotnetcli
dotnet test --test-modules Contoso.MyTests.dll
```

For runner selection and migration from the VSTest-compatible mode, see [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md).

## [Visual Studio](#tab/visual-studio)

The MTP tests can be run (and debugged) in Visual Studio, they integrate with Test Explorer, and can also be run directly as startup project.

### Run the app with Visual Studio

MTP test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Select **Debug** > **Start without Debugging** (or use <kbd>Ctrl</kbd>+<kbd>F5</kbd>) to run the selected test project.

Console window pops up with the execution and summary of your test run.

### Debug the app directly in Visual Studio

MTP test project can be debugged directly. To debug all the tests in the given executable, unless a filter is provided:

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

MTP test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate to a test file that you want to run tests for.
1. Use <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the selected test project. If you have multiple projects a popup will ask you to select the one to run.

Console window pops up with the execution and summary of your test run.

### Debug the app directly in Visual Studio Code

MTP test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

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

To run multiple test projects in parallel, invoke `dotnet test` once for the solution instead of adding a pipeline step for every test executable. When you add an MTP test project to the solution, the same command includes it without a pipeline change.

### Run a solution in Azure Pipelines

Use the .NET 10 SDK or later and MTP 1.7 or later. All test projects in the solution must support MTP; VSTest-only test projects aren't supported in this mode. For earlier SDK versions, see [Run MTP projects with VSTest mode](unit-testing-with-dotnet-test.md#run-mtp-projects-with-vstest-mode).

At the repository root, create a [`global.json`](../tools/global-json.md) file with the following content. If the file already exists, add the `test` section and ensure its SDK settings select .NET 10 or later.

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

For TRX reports, each test project must reference [`Microsoft.Testing.Extensions.TrxReport`](https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport), either directly or through a test SDK configuration or profile that includes it. For details, see [Visual Studio test reports (TRX)](microsoft-testing-platform-test-reports.md#visual-studio-test-reports-trx).

Add the following `azure-pipelines.yml` file to your repository. The example assumes that `Contoso.sln` and `global.json` are at the repository root. Replace `Contoso.sln` with the repository-relative path of your solution.

:::code language="yaml" source="./snippets/microsoft-testing-platform-run-and-debug/azure-pipelines.yml":::

The [`DotNetCoreCLI@2` task](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2) invokes `dotnet test` once for the solution. The command restores dependencies, builds the solution, and runs its MTP test modules in parallel. By default, `dotnet test` runs up to <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> modules at once. The example uses `--max-parallel-test-modules 4` to limit concurrency to four modules. Adjust the limit to match your agent's CPU, memory, and other resources.

> [!IMPORTANT]
> Select a solution file in `projects`, not a project-file pattern such as `**/*.csproj`. The task invokes `dotnet test` separately for each matched file, one after another. A single solution invocation lets `dotnet test` coordinate parallel execution across its test projects.

Module-level parallelism is separate from parallel execution of tests within a module. To configure parallel tests within an assembly, use your test framework's settings. For MSTest, see [ParallelizeAttribute](unit-testing-mstest-writing-tests-controlling-execution.md#parallelizeattribute).

With `publishTestResults: true`, the task adds `--report-trx` and `--results-directory` and publishes the reports to the pipeline run's **Tests** tab, even if tests fail. A nonzero `dotnet test` exit code also fails the task and pipeline.

> [!NOTE]
> MTP support in `DotNetCoreCLI@2` requires task version 2.263.0 or later. Keep `global.json` in the task's working directory so both the task and the .NET SDK select MTP.

### Run a solution with a script

For task versions without MTP support, or to control the CLI command directly, use a script and publish the TRX reports in a separate step. The same .NET SDK, `global.json`, and TRX extension requirements apply.

:::code language="yaml" source="./snippets/microsoft-testing-platform-run-and-debug/azure-pipelines-script.yml":::

The `succeededOrFailed()` condition publishes results after a successful or failed test run. The script's nonzero exit code still fails the pipeline. To avoid report overwrites across modules, don't assign the same TRX file name to every module. For naming and isolation options, see [Report file names](microsoft-testing-platform-test-reports.md#report-file-names).

### Run a single test executable

For a single test project, build or publish the project before you invoke its executable directly:

```yml
- task: CmdLine@2
  displayName: "Run Contoso.MyTests"
  inputs:
    script: '.\Contoso.MyTests\bin\Debug\net10.0\Contoso.MyTests.exe'
```

---

## See also

- [MTP overview](./microsoft-testing-platform-intro.md)
- [MTP CLI options reference](./microsoft-testing-platform-cli-options.md)
- [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
- [`dotnet test` with MTP](../tools/dotnet-test-mtp.md)
- [Run tests with MSTest](./unit-testing-mstest-running-tests.md)
