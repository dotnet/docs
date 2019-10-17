---
title: dotnet test command
description: The dotnet test command is used to execute unit tests in a given project.
ms.date: 05/29/2018
---
# dotnet test

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet test` - .NET test driver used to execute unit tests.

## Synopsis

<!-- markdownlint-disable MD025 -->

# [.NET Core 2.1](#tab/netcore21)

```dotnetcli
dotnet test [<PROJECT>] [-a|--test-adapter-path] [--blame] [-c|--configuration] [--collect] [-d|--diag] [-f|--framework] [--filter]
    [-l|--logger] [--no-build] [--no-restore] [-o|--output] [-r|--results-directory] [-s|--settings] [-t|--list-tests] 
    [-v|--verbosity] [-- <RunSettings arguments>]

dotnet test [-h|--help]
```

# [.NET Core 2.0](#tab/netcore20)

```dotnetcli
dotnet test [<PROJECT>] [-a|--test-adapter-path] [-c|--configuration] [--collect] [-d|--diag] [-f|--framework] [--filter]
    [-l|--logger] [--no-build] [--no-restore] [-o|--output] [-r|--results-directory] [-s|--settings] [-t|--list-tests] [-v|--verbosity]

dotnet test [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)

```dotnetcli
dotnet test [<PROJECT>] [-a|--test-adapter-path] [-c|--configuration] [-d|--diag] [-f|--framework] [--filter] [-l|--logger] [--no-build] [-o|--output] [-s|--settings] [-t|--list-tests]  [-v|--verbosity]

dotnet test [-h|--help]
```

---

## Description

The `dotnet test` command is used to execute unit tests in a given project. The `dotnet test` command launches the test runner console application specified for a project. The test runner executes the tests defined for a unit test framework (for example, MSTest, NUnit, or xUnit) and reports the success or failure of each test. If all tests are successful, the test runner returns 0 as an exit code; otherwise if any test fails, it returns 1. The test runner and the unit test library are packaged as NuGet packages and are restored as ordinary dependencies for the project.

Test projects specify the test runner using an ordinary `<PackageReference>` element, as seen in the following sample project file:

[!code-xml[XUnit Basic Template](../../../samples/snippets/csharp/xunit-test/xunit-test.csproj)]

## Arguments

`PROJECT`

Path to the test project. If not specified, it defaults to current directory.

## Options

# [.NET Core 2.1](#tab/netcore21)

`-a|--test-adapter-path <PATH_TO_ADAPTER>`

Use the custom test adapters from the specified path in the test run.

`--blame`

Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as *Sequence.xml* that captures the order of tests execution before the crash.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`, but your project's configuration could override this default SDK setting.

`--collect <DATA_COLLECTOR_FRIENDLY_NAME>`

Enables data collector for the test run. For more information, see [Monitor and analyze test run](https://aka.ms/vstest-collect).

`-d|--diag <PATH_TO_DIAGNOSTICS_FILE>`

Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.

`-f|--framework <FRAMEWORK>`

Looks for test binaries for a specific [framework](../../standard/frameworks.md).

`--filter <EXPRESSION>`

Filters out tests in the current project using the given expression. For more information, see the [Filter option details](#filter-option-details) section. For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

`-h|--help`

Prints out a short help for the command.

`-l|--logger <LoggerUri/FriendlyName>`

Specifies a logger for test results.

`--no-build`

Doesn't build the test project before running it. It also implicit sets the `--no-restore` flag.

`--no-restore`

Doesn't execute an implicit restore when running the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to find the binaries to run.

`-r|--results-directory <PATH>`

The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created.

`-s|--settings <SETTINGS_FILE>`

The `.runsettings` file to use for running the tests. [Configure unit tests by using a `.runsettings` file.](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file)

`-t|--list-tests`

List all of the discovered tests in the current project.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

`RunSettings arguments`

Arguments passed as RunSettings configurations for the test. Arguments are specified as `[name]=[value]` pairs after "-- " (note the space after --). A space is used to separate multiple `[name]=[value]` pairs.

Example: `dotnet test -- MSTest.DeploymentEnabled=false MSTest.MapInconclusiveToFailed=True`

For more information about RunSettings, see [vstest.console.exe: Passing RunSettings args](https://github.com/Microsoft/vstest-docs/blob/master/docs/RunSettingsArguments.md).

# [.NET Core 2.0](#tab/netcore20)

`-a|--test-adapter-path <PATH_TO_ADAPTER>`

Use the custom test adapters from the specified path in the test run.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`, but your project's configuration could override this default SDK setting.

`--collect <DATA_COLLECTOR_FRIENDLY_NAME>`

Enables data collector for the test run. For more information, see [Monitor and analyze test run](https://aka.ms/vstest-collect).

`-d|--diag <PATH_TO_DIAGNOSTICS_FILE>`

Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.

`-f|--framework <FRAMEWORK>`

Looks for test binaries for a specific [framework](../../standard/frameworks.md).

`--filter <EXPRESSION>`

Filters out tests in the current project using the given expression. For more information, see the [Filter option details](#filter-option-details) section. For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

`-h|--help`

Prints out a short help for the command.

`-l|--logger <LoggerUri/FriendlyName>`

Specifies a logger for test results.

`--no-build`

Doesn't build the test project before running it. It also implicit sets the `--no-restore` flag.

`--no-restore`

Doesn't execute an implicit restore when running the command.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to find the binaries to run.

`-r|--results-directory <PATH>`

The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created.

`-s|--settings <SETTINGS_FILE>`

The `.runsettings` file to use for running the tests. [Configure unit tests by using a `.runsettings` file.](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file)

`-t|--list-tests`

List all of the discovered tests in the current project.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

# [.NET Core 1.x](#tab/netcore1x)

`-a|--test-adapter-path <PATH_TO_ADAPTER>`

Use the custom test adapters from the specified path in the test run.

`-c|--configuration {Debug|Release}`

Defines the build configuration. The default value is `Debug`, but your project's configuration could override this default SDK setting.

`-d|--diag <PATH_TO_DIAGNOSTICS_FILE>`

Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.

`-f|--framework <FRAMEWORK>`

Looks for test binaries for a specific [framework](../../standard/frameworks.md).

`--filter <EXPRESSION>`

Filters out tests in the current project using the given expression. For more information, see the [Filter option details](#filter-option-details) section. For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

`-h|--help`

Prints out a short help for the command.

`-l|--logger <LoggerUri/FriendlyName>`

Specifies a logger for test results.

`--no-build`

Doesn't build the test project before running it.

`-o|--output <OUTPUT_DIRECTORY>`

Directory in which to find the binaries to run.

`-s|--settings <SETTINGS_FILE>`

The `.runsettings` file to use for running the tests. [Configure unit tests by using a `.runsettings` file.](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file)

`-t|--list-tests`

List all of the discovered tests in the current project.

`-v|--verbosity <LEVEL>`

Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

---

## Examples

Run the tests in the project in the current directory:

`dotnet test`

Run the tests in the `test1` project:

`dotnet test ~/projects/test1/test1.csproj`

Run the tests in the project in the current directory and generate a test results file in the trx format:

`dotnet test --logger trx`

## Filter option details

`--filter <EXPRESSION>`

`<Expression>` has the format `<property><operator><value>[|&<Expression>]`.

`<property>` is an attribute of the `Test Case`. The following are the properties supported by popular unit test frameworks:

| Test Framework | Supported properties                                                                                      |
| -------------- | --------------------------------------------------------------------------------------------------------- |
| MSTest         | <ul><li>FullyQualifiedName</li><li>Name</li><li>ClassName</li><li>Priority</li><li>TestCategory</li></ul> |
| xUnit          | <ul><li>FullyQualifiedName</li><li>DisplayName</li><li>Traits</li></ul>                                   |

The `<operator>` describes the relationship between the property and the value:

| Operator | Function        |
| :------: | --------------- |
| `=`      | Exact match     |
| `!=`     | Not exact match |
| `~`      | Contains        |

`<value>` is a string. All the lookups are case insensitive.

An expression without an `<operator>` is automatically considered as a `contains` on `FullyQualifiedName` property (for example, `dotnet test --filter xyz` is same as `dotnet test --filter FullyQualifiedName~xyz`).

Expressions can be joined with conditional operators:

| Operator            | Function |
| ------------------- | -------- |
| <code>&#124;</code> | OR       |
| `&`                 | AND      |

You can enclose expressions in parenthesis when using conditional operators (for example, `(Name~TestMethod1) | (Name~TestMethod2)`).

For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

## See also

- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
