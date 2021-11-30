---
title: dotnet vstest command
description: The dotnet vstest command builds a project and all of its dependencies.
ms.date: 02/27/2020
---
# dotnet vstest

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

> [!IMPORTANT]
> The `dotnet vstest` command is superseded by `dotnet test`, which can now be used to run assemblies. See [dotnet test](dotnet-test.md).

## Name

`dotnet-vstest` - Runs tests from the specified assemblies.

## Synopsis

```dotnetcli
dotnet vstest [<TEST_FILE_NAMES>] [--Blame] [--Diag <PATH_TO_LOG_FILE>]
    [--Framework <FRAMEWORK>] [--InIsolation] [-lt|--ListTests <FILE_NAME>]
    [--logger <LOGGER_URI/FRIENDLY_NAME>] [--Parallel]
    [--ParentProcessId <PROCESS_ID>] [--Platform] <PLATFORM_TYPE>
    [--Port <PORT>] [--ResultsDirectory<PATH>] [--Settings <SETTINGS_FILE>]
    [--TestAdapterPath <PATH>] [--TestCaseFilter <EXPRESSION>]
    [--Tests <TEST_NAMES>] [[--] <args>...]]

dotnet vstest -?|--Help
```

## Description

The `dotnet-vstest` command runs the `VSTest.Console` command-line application to run automated unit tests.

## Arguments

- **`TEST_FILE_NAMES`**

  Run tests from the specified assemblies. Separate multiple test assembly names with spaces. Wildcards are supported.

## Options

- **`--Blame`**

  Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as *Sequence.xml* that captures the order of tests execution before the crash.

- **`--Diag <PATH_TO_LOG_FILE>`**

  Enables verbose logs for the test platform. Logs are written to the provided file.

- **`--Framework <FRAMEWORK>`**

  Target .NET Framework version used for test execution. Examples of valid values are `.NETFramework,Version=v4.6` or `.NETCoreApp,Version=v1.0`. Other supported values are `Framework40`, `Framework45`, `FrameworkCore10`, and `FrameworkUap10`.

- **`--InIsolation`**

  Runs the tests in an isolated process. This makes *vstest.console.exe* process less likely to be stopped on an error in the tests, but tests may run slower.

- **`-lt|--ListTests <FILE_NAME>`**

  Lists all discovered tests from the given test container.

- **`--logger <LOGGER_URI/FRIENDLY_NAME>`**

  Specify a logger for test results.

  - To publish test results to Team Foundation Server, use the `TfsPublisher` logger provider:

    ```console
    /logger:TfsPublisher;
        Collection=<team project collection url>;
        BuildName=<build name>;
        TeamProject=<team project name>
        [;Platform=<Defaults to "Any CPU">]
        [;Flavor=<Defaults to "Debug">]
        [;RunTitle=<title>]
    ```

  - To log results to a Visual Studio Test Results File (TRX), use the `trx` logger provider. This switch creates a file in the test results directory with given log file name. If `LogFileName` isn't provided, a unique file name is created to hold the test results.

    ```console
    /logger:trx [;LogFileName=<Defaults to unique file name>]
    ```

- **`--Parallel`**

  Run tests in parallel. By default, all available cores on the machine are available for use. Specify an explicit number of cores by setting the `MaxCpuCount` property under the `RunConfiguration` node in the *runsettings* file.

- **`--ParentProcessId <PROCESS_ID>`**

  Process ID of the parent process responsible for launching the current process.

- **`--Platform <PLATFORM_TYPE>`**

  Target platform architecture used for test execution. Valid values are `x86`, `x64`, and `ARM`.

- **`--Port <PORT>`**

  Specifies the port for the socket connection and receiving the event messages.

- **`--ResultsDirectory:<PATH>`**

  Test results directory will be created in specified path if not exists.

- **`--Settings <SETTINGS_FILE>`**

  Settings to use when running tests.

- **`--TestAdapterPath <PATH>`**

  Use custom test adapters from a given path (if any) in the test run.

- **`--TestCaseFilter <EXPRESSION>`**

  Run tests that match the given expression. `<EXPRESSION>` is of the format `<property>Operator<value>[|&<EXPRESSION>]`, where Operator is one of `=`, `!=`, or `~`. Operator `~` has 'contains' semantics and is applicable for string properties like `DisplayName`. Parentheses `()` are used to group subexpressions. For more information, see [TestCase filter](https://github.com/Microsoft/vstest-docs/blob/main/docs/filter.md).

- **`--Tests <TEST_NAMES>`**

  Run tests with names that match the provided values. Separate multiple values with commas.

- **`-?|--Help`**

  Prints out a short help for the command.

- **`@<file>`**

  Reads response file for more options.

- **`args`**

  Specifies extra arguments to pass to the adapter. Arguments are specified as name-value pairs of the form `<n>=<v>`, where `<n>` is the argument name and `<v>` is the argument value. Use a space to separate multiple arguments.

## Examples

Run tests in *mytestproject.dll*:

```dotnetcli
dotnet vstest mytestproject.dll
```

Run tests in *mytestproject.dll*, exporting to custom folder with custom name:

```dotnetcli
dotnet vstest mytestproject.dll --logger:"trx;LogFileName=custom_file_name.trx" --ResultsDirectory:custom/file/path
```

Run tests in *mytestproject.dll* and *myothertestproject.exe*:

```dotnetcli
dotnet vstest mytestproject.dll myothertestproject.exe
```

Run `TestMethod1` tests:

```dotnetcli
dotnet vstest /Tests:TestMethod1
```

Run `TestMethod1` and `TestMethod2` tests:

```dotnetcli
dotnet vstest /Tests:TestMethod1,TestMethod2
```

## See also

- [VSTest.Console.exe command-line options](/visualstudio/test/vstest-console-options)
