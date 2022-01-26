---
title: dotnet test command
description: The dotnet test command is used to execute unit tests in a given project.
ms.date: 07/20/2021
---
# dotnet test

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet test` - .NET test driver used to execute unit tests.

## Synopsis

```dotnetcli
dotnet test [<PROJECT> | <SOLUTION> | <DIRECTORY> | <DLL>]
    [-a|--test-adapter-path <ADAPTER_PATH>] [--arch <ARCHITECTURE>]
    [--blame] [--blame-crash]
    [--blame-crash-dump-type <DUMP_TYPE>] [--blame-crash-collect-always]
    [--blame-hang] [--blame-hang-dump-type <DUMP_TYPE>]
    [--blame-hang-timeout <TIMESPAN>]
    [-c|--configuration <CONFIGURATION>]
    [--collect <DATA_COLLECTOR_NAME>]
    [-d|--diag <LOG_FILE>] [-f|--framework <FRAMEWORK>]
    [--filter <EXPRESSION>] [--interactive]
    [-l|--logger <LOGGER>] [--no-build]
    [--nologo] [--no-restore] [-o|--output <OUTPUT_DIRECTORY>] [--os <OS>]
    [-r|--results-directory <RESULTS_DIR>] [--runtime <RUNTIME_IDENTIFIER>]
    [-s|--settings <SETTINGS_FILE>] [-t|--list-tests]
    [-v|--verbosity <LEVEL>] [[--] <RunSettings arguments>]

dotnet test -h|--help
```

## Description

The `dotnet test` command is used to execute unit tests in a given solution. The `dotnet test` command builds the solution and runs a test host application for each test project in the solution. The test host executes tests in the given project using a test framework, for example: MSTest, NUnit, or xUnit, and reports the success or failure of each test. If all tests are successful, the test runner returns 0 as an exit code; otherwise if any test fails, it returns 1.

For multi-targeted projects, tests are run for each targeted framework. The test host and the unit test framework are packaged as NuGet packages and are restored as ordinary dependencies for the project.

Test projects specify the test runner using an ordinary `<PackageReference>` element, as seen in the following sample project file:

[!code-xml[XUnit Basic Template](../../../samples/snippets/csharp/xunit-test/xunit-test.csproj)]

Where `Microsoft.NET.Test.Sdk` is the test host, `xunit` is the test framework. And `xunit.runner.visualstudio` is a test adapter, which allows the xUnit framework to work with the test host.

### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

- **`PROJECT | SOLUTION | DIRECTORY | DLL`**

  - Path to the test project.
  - Path to the solution.
  - Path to a directory that contains a project or a solution.
  - Path to a test project *.dll* file.

  If not specified, it searches for a project or a solution in the current directory.

## Options

<!-- markdownlint-disable MD012 -->

- **`-a|--test-adapter-path <ADAPTER_PATH>`**

  Path to a directory to be searched for additional test adapters. Only *.dll* files with suffix `.TestAdapter.dll` are inspected. If not specified, the directory of the test *.dll* is searched.

[!INCLUDE [arch-no-a](../../../includes/cli-arch-no-a.md)]

- **`--blame`**

  Runs the tests in blame mode. This option is helpful in isolating problematic tests that cause the test host to crash. When a crash is detected, it creates a sequence file in `TestResults/<Guid>/<Guid>_Sequence.xml` that captures the order of tests that were run before the crash.

- **`--blame-crash`** (Available since .NET 5.0 SDK)

  Runs the tests in blame mode and collects a crash dump when the test host exits unexpectedly. This option depends on the version of .NET used, the type of error, and the operating system.
  
  For exceptions in managed code, a dump will be automatically collected on .NET 5.0 and later versions. It will generate a dump for testhost or any child process that also ran on .NET 5.0 and crashed. Crashes in native code will not generate a dump. This option works on Windows, macOS, and Linux.
  
  Crash dumps in native code, or when using .NET Core 3.1 or earlier versions, can only be collected on Windows, by using Procdump. A directory that contains *procdump.exe* and *procdump64.exe* must be in the PATH or PROCDUMP_PATH environment variable. [Download the tools](/sysinternals/downloads/procdump). Implies `--blame`.
  
  To collect a crash dump from a native application running on .NET 5.0 or later, the usage of Procdump can be forced by setting the `VSTEST_DUMP_FORCEPROCDUMP` environment variable to `1`.

- **`--blame-crash-dump-type <DUMP_TYPE>`** (Available since .NET 5.0 SDK)

  The type of crash dump to be collected. Implies `--blame-crash`.

- **`--blame-crash-collect-always`** (Available since .NET 5.0 SDK)

  Collects a crash dump on expected as well as unexpected test host exit.

- **`--blame-hang`** (Available since .NET 5.0 SDK)

  Run the tests in blame mode and collects a hang dump when a test exceeds the given timeout.

- **`--blame-hang-dump-type <DUMP_TYPE>`** (Available since .NET 5.0 SDK)

  The type of crash dump to be collected. It should be `full`, `mini`, or `none`. When `none` is specified, test host is terminated on timeout, but no dump is collected. Implies `--blame-hang`.

- **`--blame-hang-timeout <TIMESPAN>`** (Available since .NET 5.0 SDK)

  Per-test timeout, after which a hang dump is triggered and the test host process and all of its child processes are dumped and terminated. The timeout value is specified in one of the following formats:
  
  - 1.5h, 1.5hour, 1.5hours
  - 90m, 90min, 90minute, 90minutes
  - 5400s, 5400sec, 5400second, 5400seconds
  - 5400000ms, 5400000mil, 5400000millisecond, 5400000milliseconds

  When no unit is used (for example, 5400000), the value is assumed to be in milliseconds. When used together with data driven tests, the timeout behavior depends on the test adapter used. For xUnit and NUnit the timeout is renewed after every test case. For MSTest, the timeout is used for all test cases. This option is supported on Windows with `netcoreapp2.1` and later, on Linux with `netcoreapp3.1` and later, and on macOS with `net5.0` or later. Implies `--blame` and `--blame-hang`.

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`--collect <DATA_COLLECTOR_NAME>`**

  Enables data collector for the test run. For more information, see [Monitor and analyze test run](https://aka.ms/vstest-collect).
  
  To collect code coverage on any platform that is supported by .NET Core, install [Coverlet](https://github.com/coverlet-coverage/coverlet/blob/master/README.md) and use the `--collect:"XPlat Code Coverage"` option.

  On Windows, you can collect code coverage by using the `--collect "Code Coverage"` option. This option generates a *.coverage* file, which can be opened in Visual Studio 2019 Enterprise. For more information, see [Use code coverage](/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested) and [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis).

- **`-d|--diag <LOG_FILE>`**

  Enables diagnostic mode for the test platform and writes diagnostic messages to the specified file and to files next to it. The process that is logging the messages determines which files are created, such as `*.host_<date>.txt` for test host log, and `*.datacollector_<date>.txt` for data collector log.

- **`-f|--framework <FRAMEWORK>`**

  Forces the use of `dotnet` or .NET Framework test host for the test binaries. This option only determines which type of host to use. The actual framework version to be used is determined by the *runtimeconfig.json* of the test project. When not specified, the [TargetFramework assembly attribute](/dotnet/api/system.runtime.versioning.targetframeworkattribute) is used to determine the type of host. When that attribute is stripped from the *.dll*, the .NET Framework host is used.

- **`--filter <EXPRESSION>`**

  Filters out tests in the current project using the given expression. For more information, see the [Filter option details](#filter-option-details) section. For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`-l|--logger <LOGGER>`**

  Specifies a logger for test results. Unlike MSBuild, dotnet test doesn't accept abbreviations: instead of `-l "console;v=d"` use `-l "console;verbosity=detailed"`. Specify the parameter multiple times to enable multiple loggers.

- **`--no-build`**

  Doesn't build the test project before running it. It also implicitly sets the - `--no-restore` flag.

- **`--nologo`**

  Run tests without displaying the Microsoft TestPlatform banner. Available since .NET Core 3.0 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Directory in which to find the binaries to run. If not specified, the default path is `./bin/<configuration>/<framework>/`.  For projects with multiple target frameworks (via the `TargetFrameworks` property), you also need to define `--framework` when you specify this option. `dotnet test` always runs tests from the output directory. You can use <xref:System.AppDomain.BaseDirectory%2A?displayProperty=nameWithType> to consume test assets in the output directory.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`-r|--results-directory <RESULTS_DIR>`**

  The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the project file.

- **`--runtime <RUNTIME_IDENTIFIER>`**

  The target runtime to test for.

- **`-s|--settings <SETTINGS_FILE>`**

  The `.runsettings` file to use for running the tests. The `TargetPlatform` element (x86|x64) has no effect for `dotnet test`. To run tests that target x86, install the x86 version of .NET Core. The bitness of the *dotnet.exe* that is on the path is what will be used for running tests. For more information, see the following resources:

  - [Configure unit tests by using a `.runsettings` file.](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file)
  - [Configure a test run](https://github.com/Microsoft/vstest-docs/blob/main/docs/configure.md)

- **`-t|--list-tests`**

  List the discovered tests instead of running the tests.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

- **`RunSettings`** arguments

 Inline `RunSettings` are passed as the last arguments on the command line after "-- " (note the space after --). Inline `RunSettings` are specified as `[name]=[value]` pairs. A space is used to separate multiple `[name]=[value]` pairs.

  Example: `dotnet test -- MSTest.DeploymentEnabled=false MSTest.MapInconclusiveToFailed=True`

  For more information, see [Passing RunSettings arguments through command line](https://github.com/Microsoft/vstest-docs/blob/main/docs/RunSettingsArguments.md).

## Examples

- Run the tests in the project in the current directory:

  ```dotnetcli
  dotnet test
  ```

- Run the tests in the `test1` project:

  ```dotnetcli
  dotnet test ~/projects/test1/test1.csproj
  ```

- Run the tests in the project in the current directory, and generate a test results file in the trx format:

  ```dotnetcli
  dotnet test --logger trx
  ```

- Run the tests in the project in the current directory, and generate a code coverage file (after installing [Coverlet](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/VSTestIntegration.md) collectors integration):

  ```dotnetcli
  dotnet test --collect:"XPlat Code Coverage"
  ```

- Run the tests in the project in the current directory, and generate a code coverage file (Windows only):

  ```dotnetcli
  dotnet test --collect "Code Coverage"
  ```

- Run the tests in the project in the current directory, and log with detailed verbosity to the console:

  ```dotnetcli
  dotnet test --logger "console;verbosity=detailed"
  ```

- Run the tests in the project in the current directory, and report tests that were in progress when the test host crashed:

  ```dotnetcli
  dotnet test --blame
  ```

## Filter option details

`--filter <EXPRESSION>`

`<Expression>` has the format `<property><operator><value>[|&<Expression>]`.

`<property>` is an attribute of the `Test Case`. The following are the properties supported by popular unit test frameworks:

| Test Framework | Supported properties                                                                                      |
| -------------- | --------------------------------------------------------------------------------------------------------- |
| MSTest         | <ul><li>FullyQualifiedName</li><li>Name</li><li>ClassName</li><li>Priority</li><li>TestCategory</li></ul> |
| xUnit          | <ul><li>FullyQualifiedName</li><li>DisplayName</li><li>Category</li></ul>                                 |
| NUnit          | <ul><li>FullyQualifiedName</li><li>Name</li><li>TestCategory</li><li>Priority</li></ul>                                   |

The `<operator>` describes the relationship between the property and the value:

| Operator | Function        |
| :------: | --------------- |
| `=`      | Exact match     |
| `!=`     | Not exact match |
| `~`      | Contains        |
| `!~`     | Not contains    |

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
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Passing runsettings arguments through commandline](https://github.com/Microsoft/vstest-docs/blob/main/docs/RunSettingsArguments.md)
