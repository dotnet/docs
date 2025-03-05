---
title: dotnet test command
description: The dotnet test command is used to execute unit tests in a given project.
ms.date: 03/27/2024
---
# dotnet test

## Name

`dotnet test` - .NET test driver used to execute unit tests.

## Description

The `dotnet test` command builds the solution and runs the tests with either VSTest or Microsoft Testing Platform (MTP). To enable MTP, you need to add a config file named `dotnet.config` with TOML format located at the root of the solution or repository.

Some examples of the `dotnet.config` file:

  ```toml
  [dotnet.test:runner]
  name = "Microsoft.Testing.Platform"
  ```

  ```toml
  [dotnet.test:runner]
  name = "VSTest"
  ```

## VSTest and Microsoft Testing Platform (MTP)

### [dotnet test with VSTest](#tab/dotnet-test-with-vstest)

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

#### Synopsis

```dotnetcli
dotnet test [<PROJECT> | <SOLUTION> | <DIRECTORY> | <DLL> | <EXE>]
    [--test-adapter-path <ADAPTER_PATH>]
    [-a|--arch <ARCHITECTURE>]
    [--artifacts-path <ARTIFACTS_DIR>]
    [--blame]
    [--blame-crash]
    [--blame-crash-dump-type <DUMP_TYPE>]
    [--blame-crash-collect-always]
    [--blame-hang]
    [--blame-hang-dump-type <DUMP_TYPE>]
    [--blame-hang-timeout <TIMESPAN>]
    [-c|--configuration <CONFIGURATION>]
    [--collect <DATA_COLLECTOR_NAME>]
    [-d|--diag <LOG_FILE>]
    [-f|--framework <FRAMEWORK>]
    [-e|--environment <NAME="VALUE">]
    [--filter <EXPRESSION>]
    [--interactive]
    [-l|--logger <LOGGER>]
    [--no-build]
    [--nologo]
    [--no-restore]
    [-o|--output <OUTPUT_DIRECTORY>]
    [--os <OS>]
    [--results-directory <RESULTS_DIR>]
    [-r|--runtime <RUNTIME_IDENTIFIER>]
    [-s|--settings <SETTINGS_FILE>]
    [-t|--list-tests]
    [-v|--verbosity <LEVEL>]
    [<args>...]
    [[--] <RunSettings arguments>]

dotnet test -h|--help
```

#### Description

The `dotnet test` command is used to execute unit tests in a given solution. The `dotnet test` command builds the solution and runs a test host application for each test project in the solution using `VSTest`. The test host executes tests in the given project using a test framework, for example: MSTest, NUnit, or xUnit, and reports the success or failure of each test. If all tests are successful, the test runner returns 0 as an exit code; otherwise if any test fails, it returns 1.

> [!NOTE]
> `dotnet test` was originally designed to support only `VSTest`-based test projects. Recent versions of the test frameworks are adding support for [Microsoft.Testing.Platform](../testing/unit-testing-platform-intro.md). This alternative test platform is more lightweight and faster than `VSTest` and supports `dotnet test` with different command line options. For more information, see [Microsoft.Testing.Platform](../testing/unit-testing-platform-intro.md).

For multi-targeted projects, tests are run for each targeted framework. The test host and the unit test framework are packaged as NuGet packages and are restored as ordinary dependencies for the project. Starting with the .NET 9 SDK, these tests are run in parallel by default. To disable parallel execution, set the `TestTfmsInParallel` MSBuild property to `false`. For more information, see [Run tests in parallel](../whats-new/dotnet-9/sdk.md#run-tests-in-parallel) and the [example command line later in this article](#testtfmsinparallel).

Test projects specify the test runner using an ordinary `<PackageReference>` element, as seen in the following sample project file:

[!code-xml[XUnit Basic Template](../../../samples/snippets/csharp/xunit-test/xunit-test.csproj)]

Where `Microsoft.NET.Test.Sdk` is the test host, `xunit` is the test framework. And `xunit.runner.visualstudio` is a test adapter, which allows the xUnit framework to work with the test host.

#### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

#### Arguments

- **`PROJECT | SOLUTION | DIRECTORY | DLL | EXE`**

  - Path to the test project.
  - Path to the solution.
  - Path to a directory that contains a project or a solution.
  - Path to a test project *.dll* file.
  - Path to a test project *.exe* file.

  If not specified, the effect is the same as using the `DIRECTORY` argument to specify the current directory.

#### Options

> [!WARNING]
> Breaking changes in options:
>
> - Starting in .NET 7: switch `-a` to alias `--arch` instead of `--test-adapter-path`
> - Starting in .NET 7: switch `-r` to alias `--runtime` instead of `--results-directory`

> [!WARNING]
> When using `Microsoft.Testing.Platform`, please refer to [dotnet test integration](../testing/unit-testing-platform-integration-dotnet-test.md) for the supported options. As a rule of thumbs, every option non-related to testing is supported while every testing-related option is not supported as-is.

- **`--test-adapter-path <ADAPTER_PATH>`**

  Path to a directory to be searched for additional test adapters. Only *.dll* files with suffix `.TestAdapter.dll` are inspected. If not specified, the directory of the test *.dll* is searched.

  Short form `-a` available in .NET SDK versions earlier than 7.

[!INCLUDE [arch-no-a](../../../includes/cli-arch-no-a.md)]

[!INCLUDE [artifacts-path](../../../includes/cli-artifacts-path.md)]

- **`--blame`**

  Runs the tests in blame mode. This option is helpful in isolating problematic tests that cause the test host to crash. When a crash is detected, it creates a sequence file in `TestResults/<Guid>/<Guid>_Sequence.xml` that captures the order of tests that were run before the crash.

  This option does not create a memory dump and is not helpful when the test is hanging.

- **`--blame-crash`** (Available since .NET 5.0 SDK)

  Runs the tests in blame mode and collects a crash dump when the test host exits unexpectedly. This option depends on the version of .NET used, the type of error, and the operating system.

  For exceptions in managed code, a dump will be automatically collected on .NET 5.0 and later versions. It will generate a dump for testhost or any child process that also ran on .NET 5.0 and crashed. Crashes in native code will not generate a dump. This option works on Windows, macOS, and Linux.

  Crash dumps in native code, or when using .NET Core 3.1 or earlier versions, can only be collected on Windows, by using Procdump. A directory that contains *procdump.exe* and *procdump64.exe* must be in the PATH or PROCDUMP_PATH environment variable. [Download the tools](/sysinternals/downloads/procdump). Implies `--blame`.

  To collect a crash dump from a native application running on .NET 5.0 or later, the usage of Procdump can be forced by setting the `VSTEST_DUMP_FORCEPROCDUMP` environment variable to `1`.

- **`--blame-crash-dump-type <DUMP_TYPE>`** (Available since .NET 5.0 SDK)

  The type of crash dump to be collected. Supported dump types are `full` (default), and `mini`. Implies `--blame-crash`.

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

  When no unit is used (for example, 5400000), the value is assumed to be in milliseconds. When used together with data driven tests, the timeout behavior depends on the test adapter used. For xUnit, NUnit. and MSTest 2.2.4+, the timeout is renewed after every test case. For MSTest before version 2.2.4, the timeout is used for all test cases. This option is supported on Windows with `netcoreapp2.1` and later, on Linux with `netcoreapp3.1` and later, and on macOS with `net5.0` or later. Implies `--blame` and `--blame-hang`.

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`--collect <DATA_COLLECTOR_NAME>`**

  Enables data collector for the test run. For more information, see [Monitor and analyze test run](https://aka.ms/vstest-collect).

  For example you can collect code coverage by using the `--collect "Code Coverage"` option. For more information, see [Use code coverage](/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested), [Customize code coverage analysis](/visualstudio/test/customizing-code-coverage-analysis), and [GitHub issue dotnet/docs#34479](https://github.com/dotnet/docs/issues/34479).

  To collect code coverage you can also use [Coverlet](https://github.com/coverlet-coverage/coverlet/blob/master/README.md) by using the `--collect "XPlat Code Coverage"` option.

- **`-d|--diag <LOG_FILE>`**

  Enables diagnostic mode for the test platform and writes diagnostic messages to the specified file and to files next to it. The process that is logging the messages determines which files are created, such as `*.host_<date>.txt` for test host log, and `*.datacollector_<date>.txt` for data collector log.

- **`-e|--environment <NAME="VALUE">`**

  Sets the value of an environment variable. Creates the variable if it does not exist, overrides if it does exist. Use of this option will force the tests to be run in an isolated process. The option can be specified multiple times to provide multiple variables.

- **`-f|--framework <FRAMEWORK>`**

  The [target framework moniker (TFM)](../../standard/frameworks.md) of the target framework to run tests for. The target framework must also be specified in the project file.

- **`--filter <EXPRESSION>`**

  Filters tests in the current project using the given expression. Only tests that match the filter expression are run. For more information, see the [Filter option details](#filter-option-details) section. For more information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`-l|--logger <LOGGER>`**

  Specifies a logger for test results and optionally switches for the logger. Specify this parameter multiple times to enable multiple loggers. For more information, see [Reporting test results](https://github.com/microsoft/vstest/blob/main/docs/report.md#available-test-loggers), [Switches for loggers](/visualstudio/msbuild/msbuild-command-line-reference#switches-for-loggers), and the [examples](#examples) later in this article.

  In order to pass command-line switches to the logger:

  * Use the full name of the switch, not the abbreviated form (for example, `verbosity` instead of `v`).
  * Omit any leading dashes.
  * Replace the space separating each switch with a semicolon `;`.
  * If the switch has a value, replace the colon separator between that switch and its value with the equals sign `=`.

  For example, `-v:detailed --consoleLoggerParameters:ErrorsOnly` would become `verbosity=detailed;consoleLoggerParameters=ErrorsOnly`.

- **`--no-build`**

  Doesn't build the test project before running it. It also implicitly sets the `--no-restore` flag.

- **`--nologo`**

  Run tests without displaying the Microsoft TestPlatform banner. Available since .NET Core 3.0 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Directory in which to find the binaries to run. If not specified, the default path is `./bin/<configuration>/<framework>/`.  For projects with multiple target frameworks (via the `TargetFrameworks` property), you also need to define `--framework` when you specify this option. `dotnet test` always runs tests from the output directory. You can use <xref:System.AppDomain.BaseDirectory%2A?displayProperty=nameWithType> to consume test assets in the output directory.

  - .NET 7.0.200 SDK and later

    If you specify the `--output` option when running this command on a solution, the CLI will emit a warning (an error in 7.0.200) due to the unclear semantics of the output path. The `--output` option is disallowed because all outputs of all built projects would be copied into the specified directory, which isn't compatible with multi-targeted projects, as well as projects that have different versions of direct and transitive dependencies. For more information, see [Solution-level `--output` option no longer valid for build-related commands](../compatibility/sdk/7.0/solution-level-output-no-longer-valid.md).

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`--results-directory <RESULTS_DIR>`**

  The directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the project file.

  Short form `-r` available in .NET SDK versions earlier than 7.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  The target runtime to test for.

  Short form `-r` available starting in .NET SDK 7.

- **`-s|--settings <SETTINGS_FILE>`**

  The `.runsettings` file to use for running the tests. The `TargetPlatform` element (x86|x64) has no effect for `dotnet test`. To run tests that target x86, install the x86 version of .NET Core. The bitness of the *dotnet.exe* that is on the path is what will be used for running tests. For more information, see the following resources:

  - [Configure unit tests by using a `.runsettings` file.](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file)
  - [Configure a test run](https://github.com/microsoft/vstest/blob/main/docs/configure.md)

- **`-t|--list-tests`**

  List the discovered tests instead of running the tests.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

- **`args`**

  Specifies extra arguments to pass to the adapter. Use a space to separate multiple arguments.

  The list of possible arguments depends upon the specified behavior:
  - When you specify a project, solution, or a directory, or if you omit this argument, the call is forwarded to `msbuild`. In that case, the available arguments can be found in [the dotnet msbuild documentation](dotnet-msbuild.md).
  - When you specify a *.dll* or an *.exe*, the call is forwarded to `vstest`. In that case, the available arguments can be found in [the dotnet vstest documentation](dotnet-vstest.md).

- **`RunSettings`** arguments

 Inline `RunSettings` are passed as the last arguments on the command line after "-- " (note the space after --). Inline `RunSettings` are specified as `[name]=[value]` pairs. A space is used to separate multiple `[name]=[value]` pairs.

  Example: `dotnet test -- MSTest.DeploymentEnabled=false MSTest.MapInconclusiveToFailed=True`

  For more information, see [Passing RunSettings arguments through command line](https://github.com/Microsoft/vstest-docs/blob/main/docs/RunSettingsArguments.md).

#### Examples

- Run the tests in the project in the current directory:

  ```dotnetcli
  dotnet test
  ```

- Run the tests in the `test1` project:

  ```dotnetcli
  dotnet test ~/projects/test1/test1.csproj
  ```

- Run the tests using `test1.dll` assembly:

  ```dotnetcli
  dotnet test ~/projects/test1/bin/debug/test1.dll
  ```

- Run the tests in the project in the current directory, and generate a test results file in the trx format:

  ```dotnetcli
  dotnet test --logger trx
  ```

- Run the tests in the project in the current directory, and generate a code coverage file using [Microsoft Code Coverage](https://github.com/microsoft/codecoverage/blob/main/README.md):

  ```dotnetcli
  dotnet test --collect "Code Coverage"
  ```

- Run the tests in the project in the current directory, and generate a code coverage file using [Coverlet](https://github.com/coverlet-coverage/coverlet/blob/master/README.md) (after installing [Coverlet](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/VSTestIntegration.md) collectors integration):

  ```dotnetcli
  dotnet test --collect:"XPlat Code Coverage"
  ```

- Run the tests in the project in the current directory, and log with detailed verbosity to the console:

  ```dotnetcli
  dotnet test --logger "console;verbosity=detailed"
  ```

- Run the tests in the project in the current directory, and log with the trx logger to *testResults.trx* in the *TestResults* folder:

  ```dotnetcli
  dotnet test --logger "trx;logfilename=testResults.trx"
  ```

  Since the log file name is specified, the same name is used for each target framework in the case of a multi-targeted project. The output for each target framework overwrites the output for preceding target frameworks. The file is created in the *TestResults* folder in the test project folder, because relative paths are relative to that folder. The following example shows how to produce a separate file for each target framework.

- Run the tests in the project in the current directory, and log with the trx logger to files in the *TestResults* folder, with file names that are unique for each target framework:

  ```dotnetcli
  dotnet test --logger:"trx;LogFilePrefix=testResults"
  ```

- Run the tests in the project in the current directory, and log with the html logger to *testResults.html* in the *TestResults* folder:

  ```dotnetcli
  dotnet test --logger "html;logfilename=testResults.html"
  ```

- Run the tests in the project in the current directory, and report tests that were in progress when the test host crashed:

  ```dotnetcli
  dotnet test --blame
  ```

- Run the tests in the `test1` project, providing the `-bl` (binary log) argument to `msbuild`:

  ```dotnetcli
  dotnet test ~/projects/test1/test1.csproj -bl
  ```

- Run the tests in the `test1` project, setting the MSBuild `DefineConstants` property to `DEV`:

  ```dotnetcli
  dotnet test ~/projects/test1/test1.csproj -p:DefineConstants="DEV"
  ```

  <a id="testtfmsinparallel"></a>

- Run the tests in the `test1` project, setting the MSBuild `TestTfmsInParallel` property to `false`:

  ```dotnetcli
  dotnet test ~/projects/test1/test1.csproj -p:TestTfmsInParallel=false
  ```

#### Filter option details

`--filter <EXPRESSION>`

`<Expression>` has the format `<property><operator><value>[|&<Expression>]`.

`<property>` is an attribute of the `Test Case`. The following are the properties supported by popular unit test frameworks:

| Test Framework | Supported properties                                                                                      |
| -------------- | --------------------------------------------------------------------------------------------------------- |
| MSTest         | <ul><li>FullyQualifiedName</li><li>Name</li><li>ClassName</li><li>Priority</li><li>TestCategory</li></ul> |
| xUnit          | <ul><li>FullyQualifiedName</li><li>DisplayName</li><li>Category</li></ul>                                 |
| NUnit          | <ul><li>FullyQualifiedName</li><li>Name</li><li>Category</li><li>Priority</li></ul>                                   |

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

#### See also

- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Passing runsettings arguments through commandline](https://github.com/microsoft/vstest/blob/main/docs/RunSettingsArguments.md)

### [dotnet test with MTP](#tab/dotnet-test-with-mtp)

**This article applies to:** ✔️ .NET 10 SDK and later versions

#### Synopsis

```dotnetcli
dotnet test
    [--project <PROJECT_PATH>]
    [--solution <SOLUTION_PATH>]
    [--directory <DIRECTORY_PATH>]
    [--test-modules <EXPRESSION>] 
    [--root-directory <ROOT_PATH>]
    [--max-parallel-test-modules <NUMBER>]
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
    [<args>...]

dotnet test -h|--help
```

#### Description

With Microsoft Testing Platform, `dotnet test` operates faster than with VSTest. The test-related arguments are no longer fixed, as they are tied to the registered extensions in the test project(s). Moreover, MTP supports a globbing filter when running tests. For more information, see [Microsoft.Testing.Platform](../testing/unit-testing-platform-intro.md).

> [!WARNING]
> `dotnet test` doesn't run in environments that have test projects using both VSTest and Microsoft Testing Platform in the same solution, as the two platforms are mutually incompatible.

#### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

#### Options

- **`--project <PROJECT_PATH>`**

  Specifies the path to the test project.

- **`--solution <SOLUTION_PATH>`**

  Specifies the path to the solution.

- **`--directory <DIRECTORY_PATH>`**

  Specifies the path to a directory that contains a project or a solution.

> [!NOTE]
> You can use only one of the following options at a time: `--project`, `--solution`, or `--directory`. These options can't be combined.

- **`--test-modules <EXPRESSION>`**

  Filters test modules using file globbing in .NET. Only tests belonging to those test modules will run. For more information and examples on how to use file globbing in .NET, see [File globbing](../../../docs/core/extensions/file-globbing.md).

- **`--root-directory <ROOT_PATH>`**

  Specifies the root directory of the `--test-modules` option. It can only be used with the `--test-modules` option.

- **`--max-parallel-test-modules <NUMBER>`**

  Specifies the maximum number of test modules that can run in parallel.

[!INCLUDE [arch-no-a](../../../includes/cli-arch-no-a.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  The [target framework moniker (TFM)](../../standard/frameworks.md) of the target framework to run tests for. The target framework must also be specified in the project file.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  The target runtime to test for.

  Short form `-r` available starting in .NET SDK 7.

- **`-v|--verbosity <LEVEL>`**
  
  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. For more information, see <xref:Microsoft.Build.Framework.LoggerVerbosity>.

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

- **`--property:<NAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  The short form `-p` can be used for `--property`. The same applies for `/property:property=value` and its short form is `/p`.
  More informatiom about the available arguments can be found in [the dotnet msbuild documentation](dotnet-msbuild.md).

- **`-?|-h|--help`**

  Prints out a description of how to use the command. There are static options along with platform and extension options. Extension options are dynamic and might differ from one test application to another, as they are based on the registered extensions in the test project.

- **`args`**

  Specifies extra arguments to pass to the test application(s). Use a space to separate multiple arguments. For more information and examples on what to pass, see [Microsoft Testing Platform](../../../docs/core/testing/unit-testing-platform-intro.md) and [Microsoft.Testing.Platform extensions](../../../docs/core/testing/unit-testing-platform-extensions.md).

> [!NOTE]
> To enable trace logging to a file, use the environment variable `DOTNET_CLI_TEST_TRACEFILE` to provide the path to the trace file.

#### Examples

- Run the tests in the project in the current directory:

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

- Run the tests in the `TestProjects` directory:

  ```dotnetcli
  dotnet test --directory ./TestProjects
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

- Run the tests in the `TestProject` project, providing the `-bl` (binary log) argument to `msbuild`:

  ```dotnetcli
  dotnet test --project ./TestProject/TestProject.csproj -bl
  ```

- Run the tests in the `TestProject` project, setting the MSBuild `DefineConstants` property to `DEV`:

  ```dotnetcli
  dotnet test --project ./TestProject/TestProject.csproj -p:DefineConstants="DEV"
  ```

#### See also

- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Microsoft.Testing.Platform](../../../docs/core/testing/unit-testing-platform-intro.md)
- [Microsoft.Testing.Platform extensions](../../../docs/core/testing/unit-testing-platform-extensions.md)
