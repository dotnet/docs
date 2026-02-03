---
title: dotnet test command with Microsoft.Testing.Platform
description: The dotnet test command is used to execute unit tests in a given project using Microsoft.Testing.Platform (MTP).
ms.date: 02/03/2026
ai-usage: ai-assisted
---
# dotnet test with Microsoft.Testing.Platform (MTP)

**This article applies to:** ✔️ .NET 10 SDK and later versions

## Name

`dotnet test` - .NET test driver used to execute unit tests with Microsoft.Testing.Platform.

## Synopsis

```dotnetcli
dotnet test
    [--project <PROJECT_PATH>]
    [--solution <SOLUTION_PATH>]
    [--test-modules <EXPRESSION>] 
    [--root-directory <ROOT_PATH>]
    [--max-parallel-test-modules <NUMBER>]
    [--config-file <CONFIG_FILE>]
    [--results-directory <RESULTS_DIRECTORY>]
    [--diagnostic-output-directory <DIAGNOSTIC_OUTPUT_DIRECTORY>]
    [--minimum-expected-tests <NUMBER>]
    [-a|--arch <ARCHITECTURE>]
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>]
    [--os <OS>]
    [-r|--runtime <RUNTIME_IDENTIFIER>]
    [-v|--verbosity <LEVEL>]
    [--no-build]
    [--no-restore]
    [--no-ansi]
    [--no-progress]
    [--output <VERBOSITY_LEVEL>]
    [--no-launch-profile]
    [--no-launch-profile-arguments]
    [<args>...]

dotnet test -h|--help
```

## Description

With Microsoft Testing Platform, `dotnet test` operates faster than with VSTest. The test-related arguments are no longer fixed, as they are tied to the registered extensions in the test project(s). Moreover, MTP supports a globbing filter when running tests. For more information, see [Microsoft.Testing.Platform](../testing/microsoft-testing-platform-intro.md).

> [!WARNING]
> When Microsoft.Testing.Platform is opted in via `global.json`, `dotnet test` expects all test projects to use Microsoft.Testing.Platform. It is an error if any of the test projects use VSTest.

## Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

## Options

> [!NOTE]
> You can use only one of the following options at a time: `--project`, `--solution`, or `--test-modules`. These options can't be combined.
> In addition, when using `--test-modules`, you can't specify `--arch`, `--configuration`, `--framework`, `--os`, or `--runtime`. These options aren't relevant for an already-built module.

- **`--project <PROJECT_PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

- **`--solution <SOLUTION_PATH>`**

  Specifies the path of the solution file to run (folder name or full path). If not specified, it defaults to the current directory.

- **`--test-modules <EXPRESSION>`**

  Filters test modules using file globbing in .NET. Only tests belonging to those test modules will run. For more information and examples on how to use file globbing in .NET, see [File globbing](../extensions/file-globbing.md).

- **`--root-directory <ROOT_PATH>`**

  Specifies the root directory of the `--test-modules` option. It can only be used with the `--test-modules` option.

- **`--max-parallel-test-modules <NUMBER>`**

  Specifies the maximum number of test modules that can run in parallel. The default is <xref:System.Environment.ProcessorCount?displayProperty=nameWithType>.

- **`--config-file <CONFIG_FILE>`**

  Specifies the configuration file to use for test execution. If a relative path is provided, it's converted to an absolute path based on the current directory.

- **`--results-directory <RESULTS_DIRECTORY>`**

  Specifies the directory where test results are stored. If the directory doesn't exist, it's created. If a relative path is provided, it's converted to an absolute path based on the current directory.

- **`--diagnostic-output-directory <DIAGNOSTIC_OUTPUT_DIRECTORY>`**

  Specifies the directory where diagnostic output is stored. If the directory doesn't exist, it's created. If a relative path is provided, it's converted to an absolute path based on the current directory.

- **`--minimum-expected-tests <NUMBER>`**

  Specifies the minimum number of tests that must be executed. If the actual number of tests is less than the specified minimum, the test run fails with exit code 9.

- [!INCLUDE [arch](includes/cli-arch.md)]

- [!INCLUDE [configuration](includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  The [target framework moniker (TFM)](../../standard/frameworks.md) of the target framework to run tests for. The target framework must also be specified in the project file.

- [!INCLUDE [os](includes/cli-os.md)]

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  The target runtime to test for.

  Short form `-r` available starting in .NET SDK 7.

  > [!NOTE]
  > Running tests for a solution with a global `RuntimeIdentifier` property (explicitly or via `--arch`, `--runtime`, or `--os`) isn't supported. Set `RuntimeIdentifier` on an individual project level instead.

- [!INCLUDE [verbosity](includes/cli-verbosity.md)]

- **`--no-build`**

  Specifies that the test project isn't built before being run. It also implicitly sets the `--no-restore` flag.

- **`--no-restore`**

  Specifies that an implicit restore isn't executed when running the command.

- **`--no-ansi`**

  Disables outputting ANSI escape characters to screen.

- **`--no-progress`**

  Disables reporting progress to screen.

- **`--output <VERBOSITY_LEVEL>`**

  Specifies the output verbosity when reporting tests. Valid values are `Normal` and `Detailed`. The default is `Normal`.

- **`--no-launch-profile`**

  Don't attempt to use launchSettings.json to configure the application. By default, `launchSettings.json` is used, which can apply environment variables and command-line arguments to the test executable.

- **`--no-launch-profile-arguments`**

  Don't use arguments specified by `commandLineArgs` in launch profile to run the application.

- **`--property:<NAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  The short form `-p` can be used for `--property`. The same applies for `/property:property=value` and its short form is `/p`.
  More information about the available arguments can be found in [the dotnet msbuild documentation](dotnet-msbuild.md).

- [!INCLUDE [help](includes/cli-help.md)]

- **`args`**

  Specifies extra arguments to pass to the test application(s). Use a space to separate multiple arguments. For more information and examples on what to pass, see [Microsoft.Testing.Platform overview](../testing/microsoft-testing-platform-intro.md) and [Microsoft.Testing.Platform extensions](../testing/microsoft-testing-platform-extensions.md).

  > [!TIP]
  > To specify extra arguments for specific projects, use the `TestingPlatformCommandLineArguments` MSBuild property.

> [!NOTE]
> To enable trace logging to a file, use the environment variable `DOTNET_CLI_TEST_TRACEFILE` to provide the path to the trace file.

## Examples

- Run the tests in the project or solution in the current directory:

  ```dotnetcli
  dotnet test
  ```

- Run the tests in the `TestProject` project:

  ```dotnetcli
  dotnet test --project ./TestProject/TestProject.csproj
  ```

- Run the tests in the `TestProjects` solution:

  ```dotnetcli
  dotnet test --solution ./TestProjects/TestProjects.sln
  ```

- Run the tests using `TestProject.dll` assembly:

  ```dotnetcli
  dotnet test --test-modules "**/bin/**/Debug/net10.0/TestProject.dll"
  ```

- Run the tests using `TestProject.dll` assembly with the root directory:

  ```dotnetcli
  dotnet test --test-modules "**/bin/**/Debug/net10.0/TestProject.dll" --root-directory "c:\code"
  ```

- Run the tests in the current directory with code coverage:

  ```dotnetcli
  dotnet test --coverage
  ```

- Run the tests and store results in a specific directory:

  ```dotnetcli
  dotnet test --results-directory ./TestResults
  ```

- Run the tests with diagnostic output in a specific directory:

  ```dotnetcli
  dotnet test --diagnostic-output-directory ./Diagnostics
  ```

- Run the tests ensuring at least 10 tests are executed:

  ```dotnetcli
  dotnet test --minimum-expected-tests 10
  ```

- Run the tests in the `TestProject` project, providing the `-bl` (binary log) argument to `msbuild`:

  ```dotnetcli
  dotnet test --project ./TestProject/TestProject.csproj -bl
  ```

- Run the tests in the `TestProject` project, setting the MSBuild `DefineConstants` property to `DEV`:

  ```dotnetcli
  dotnet test --project ./TestProject/TestProject.csproj -p:DefineConstants="DEV"
  ```

## See also

- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Microsoft.Testing.Platform](../testing/microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform extensions](../testing/microsoft-testing-platform-extensions.md)
- [dotnet test](dotnet-test.md)
- [dotnet test with VSTest](dotnet-test-vstest.md)
