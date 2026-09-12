---
title: dotnet test command with Microsoft.Testing.Platform (MTP)
description: The dotnet test command is used to execute unit tests in a given project using MTP.
ms.date: 09/12/2026
ai-usage: ai-assisted
---
# dotnet test with Microsoft.Testing.Platform (MTP)

**This article applies to:** ✔️ .NET 10 SDK and later versions

## Name

`dotnet test` - .NET test driver used to execute unit tests with MTP.

## Synopsis

```dotnetcli
dotnet test
    [<PROJECT_OR_TRAVERSAL_PATH>]
    [--project <PROJECT_PATH>]
    [--solution <SOLUTION_PATH>]
    [--test-modules <EXPRESSION>]
    [--root-directory <ROOT_PATH>]
    [--max-parallel-test-modules <NUMBER>]
    [--config-file <CONFIG_FILE>]
    [--results-directory <RESULTS_DIRECTORY>]
    [--results-directory-layout <flat|per-module>]
    [--diagnostic-output-directory <DIAGNOSTIC_OUTPUT_DIRECTORY>]
    [--minimum-expected-tests <NUMBER>]
    [--maximum-failed-tests <NUMBER>]
    [--timeout <DURATION>]
    [-e|--environment <NAME="VALUE">]
    [-a|--arch <ARCHITECTURE>]
    [--artifacts-path <ARTIFACTS_DIR>]
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>]
    [--os <OS>]
    [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--use-current-runtime|--ucr]
    [-v|--verbosity <LEVEL>]
    [--no-build]
    [--no-dependencies]
    [--no-restore]
    [--nologo|--no-logo|--no-banner]
    [--no-ansi]
    [--no-progress]
    [--no-artifact-post-processing]
    [--output <VERBOSITY_LEVEL>]
    [--show-test-results <OUTCOME>]
    [--list-tests [text|json]]
    [--no-launch-profile]
    [--no-launch-profile-arguments]
    [--device <DEVICE_ID>]
    [--list-devices]
    [--collect-test-map]
    [--affected-tests]
    [<args>...]

dotnet test -h|--help
```

## Description

With MTP, `dotnet test` operates faster than with VSTest. The test-related arguments are no longer fixed, as they are tied to the registered extensions in the test project(s). Moreover, MTP supports a globbing filter when running tests. For more information, see [MTP](../testing/microsoft-testing-platform-intro.md).

> [!IMPORTANT]
> Extension-specific options aren't built into MTP. Each targeted test application must register the extension that provides an option. Add the extension's NuGet package directly, or use a test SDK configuration or profile that includes the package. Otherwise, the test run fails with exit code 5 because the option is unrecognized. Run `dotnet test --help` to see the options available to the selected test applications, and see [Extension options by scenario](../testing/microsoft-testing-platform-cli-options.md#extension-options-by-scenario) to find the package for an option.

> [!WARNING]
> When MTP is opted in via `global.json`, `dotnet test` expects all test projects to use MTP. It is an error if any of the test projects use VSTest.

### Version requirements

The MTP mode of `dotnet test` requires the .NET 10 SDK and MTP 1.7 or later. Options added after .NET 10 have individual SDK version requirements in the following sections. Some options also require a newer MTP package because the SDK coordinates the complete run while each test application implements the corresponding capability.

## Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

## Options

> [!NOTE]
> You can use only one of the following options at a time: `--project`, `--solution`, or `--test-modules`. These options can't be combined.
> In addition, when you use `--test-modules`, you can't specify `--arch`, `--configuration`, `--framework`, `--os`, `--runtime`, or `--use-current-runtime`. These options aren't relevant for an already-built module.

- **`PROJECT_OR_TRAVERSAL_PATH`**

  Specifies a project or traversal project to run. Starting with .NET 11 Preview 7, `dotnet test` supports `Microsoft.Build.Traversal` projects, such as `dirs.proj`, and recursively runs their referenced test projects.

  Starting with .NET 12 Preview 1, the argument can also identify a C# file-based MTP test app. File-based test apps don't support `--device`.

- **`--project <PROJECT_PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

- **`--solution <SOLUTION_PATH>`**

  Specifies the path of the solution file to run (folder name or full path). If not specified, it defaults to the current directory.

- **`--test-modules <EXPRESSION>`**

  Filters test modules using file globbing. Only tests belonging to those test modules run. Starting with .NET 11 Preview 6, prefix a pattern with `!` to exclude matching modules. Separate multiple patterns with semicolons; whitespace around each pattern is ignored.

- **`--root-directory <ROOT_PATH>`**

  Specifies the root directory of the `--test-modules` option. It can only be used with the `--test-modules` option.

- **`--max-parallel-test-modules <NUMBER>`**

  Specifies the maximum number of test modules that can run in parallel. The default is <xref:System.Environment.ProcessorCount?displayProperty=nameWithType>.

- **`--config-file <CONFIG_FILE>`**

  Specifies the configuration file to use for test execution. If a relative path is provided, it's converted to an absolute path based on the current directory. For more information about the configuration file settings, see [testconfig.json](../testing/microsoft-testing-platform-config.md#testconfigjson).

- **`--results-directory <RESULTS_DIRECTORY>`**

  Specifies the directory where test results are stored. If the directory doesn't exist, it's created. If a relative path is provided, it's converted to an absolute path based on the current directory.

- **`--results-directory-layout <flat|per-module>`**

  Specifies how a multi-module run organizes files under the results directory. The default, `flat`, writes all results to the same directory. `per-module` writes each module's results to `<project>/<target-framework>_<runtime-or-architecture>`, which prevents reports with the same file name from overwriting one another.

  Available starting with .NET 11 RC 1.

- **`--diagnostic-output-directory <DIAGNOSTIC_OUTPUT_DIRECTORY>`**

  Specifies the directory where diagnostic output is stored. If the directory doesn't exist, it's created. If a relative path is provided, it's converted to an absolute path based on the current directory.

- **`--minimum-expected-tests <NUMBER>`**

  Specifies the minimum number of tests that must be executed. If the actual number of tests is less than the specified minimum, the test run fails with exit code 9. For more information about exit codes, see [MTP exit codes](../testing/microsoft-testing-platform-troubleshooting.md#exit-codes).

- **`--maximum-failed-tests <NUMBER>`**

  Stops the complete run after it reaches the specified number of failed, errored, timed-out, or canceled tests. The run exits with code 13.

  Available starting with .NET 11 RC 1 and requires MTP 2.4 or later.

- **`--timeout <DURATION>`**

  Stops the complete run after the specified duration while at least one test application is running. Specify a positive number followed by a unit, such as `500ms`, `90s`, `10m`, `2h`, or `1d`. A timed-out run exits with code 3.

  Available starting with .NET 11 RC 1 and requires MTP 2.4 or later.

- **`-e|--environment <NAME="VALUE">`**

  Sets an environment variable for the test process. Specify the option multiple times to set multiple variables. Command-line values override values from a launch profile.

  Use .NET SDK 10.0.110 or later when no launch profile exists or when you specify `--no-launch-profile`; earlier .NET 10 SDK versions can ignore the variables in those cases. Starting with .NET 11 Preview 7, the variables also flow to capability-aware build, device selection, deployment, and run-argument targets.

- [!INCLUDE [arch](includes/cli-arch.md)]

- [!INCLUDE [artifacts-path](includes/cli-artifacts-path.md)]

  Available for MTP mode starting with .NET 11.

- [!INCLUDE [configuration](includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  The [target framework moniker (TFM)](../../standard/frameworks.md) of the target framework to run tests for. The target framework must also be specified in the project file.

- [!INCLUDE [os](includes/cli-os.md)]

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  The target runtime to test for.

  Short form `-r` available starting in .NET SDK 7.

  > [!NOTE]
  > Running tests for a solution with a global `RuntimeIdentifier` property (explicitly or via `--arch`, `--runtime`, or `--os`) isn't supported. Set `RuntimeIdentifier` on an individual project level instead.

- **`--use-current-runtime|--ucr`**

  Uses the current runtime as the target runtime during restore and build.

  Available starting with .NET 11 Preview 6. You can't combine this option with `--test-modules`.

- [!INCLUDE [verbosity](includes/cli-verbosity.md)]

- **`--no-build`**

  Specifies that the test project isn't built before being run. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Skips building project-to-project references.

  Available starting with .NET 11 Preview 6.

- **`--no-restore`**

  Specifies that an implicit restore isn't executed when running the command.

- **`--nologo|--no-logo|--no-banner`**

  Suppresses the .NET and MTP startup banners. The `-nologo` and `/nologo` forms and the `DOTNET_NOLOGO` environment variable are also supported.

  Available in MTP mode starting with .NET 11 Preview 7.

- **`--no-ansi`**

  Disables outputting ANSI escape characters to screen.

- **`--no-progress`**

  Disables reporting progress to screen.

- **`--no-artifact-post-processing`**

  Disables post-processing of compatible artifacts after a multi-module run. Starting with .NET 11 RC 1 and MTP 2.4, registered artifact post-processors can combine compatible reports, such as TRX results. If post-processing fails, the SDK preserves the original artifacts and the test exit code.

- **`--output <VERBOSITY_LEVEL>`**

  Specifies the output verbosity for test results. Valid values are `Minimal`, `Normal`, and `Detailed`. The default is `Normal`. `Minimal` requires MTP 2.4 preview.

- **`--show-test-results <OUTCOME>`**

  Selects result blocks by outcome. In MTP 2.4 preview, use `passed`, `failed`, `skipped`, `all`, or `none`. The `failed` value also includes errors, timeouts, and cancellations.

  Combine `passed`, `failed`, and `skipped` with commas, spaces, or repeated `--show-test-results` options. Don't combine `all` or `none` with another value. This explicit option overrides the `--output` preset regardless of option order.

- **`--list-tests [text|json]`**

  Lists discovered tests without executing them. Omit the value or specify `text` for human-readable output. Starting with .NET 11 Preview 7, specify `json` for a versioned JSON document that groups tests by assembly, target framework, and architecture and includes available identifiers, source locations, methods, parameters, and traits.

- **`--no-launch-profile`**

  Don't attempt to use launchSettings.json to configure the application. By default, `launchSettings.json` is used, which can apply environment variables and command-line arguments to the test executable.

- **`--no-launch-profile-arguments`**

  Don't use arguments specified by `commandLineArgs` in launch profile to run the application.

- **`--device <DEVICE_ID>`**

  Selects a device, emulator, or simulator for each target framework in an Android or iOS test project. The MTP path also supports macOS and Mac Catalyst test projects. If input is interactive and more than one device is available, `dotnet test` can prompt you to select one.

  Available starting with .NET 11 Preview 6. For multi-targeted projects, use .NET 11 RC 2 or later so device discovery evaluates each target framework correctly. Browser WebAssembly test projects aren't supported by this option.

- **`--list-devices`**

  Lists available devices for a project without running tests. Specify a project rather than a solution.

  Available starting with .NET 11 Preview 7.

- **`--collect-test-map`** and **`--affected-tests`**

  Collect a repository test map or run tests affected by a change. These experimental options require a separately distributed extension and the `DOTNET_CLI_ENABLE_AFFECTED_TESTS=1` environment variable. You can't combine the two options. Affected-test workflows also don't support device testing, parallel test modules, or minimum-test policies.

  Available starting with .NET 11 RC 1.

- **`--property:<NAME>=<VALUE>`**

  Sets one or more MSBuild properties. Specify multiple properties by repeating the option:

  ```dotnetcli
  --property:<NAME1>=<VALUE1> --property:<NAME2>=<VALUE2>
  ```

  The short form `-p` can be used for `--property`. The same applies for `/property:property=value` and its short form is `/p`.
  More information about the available arguments can be found in [the dotnet msbuild documentation](dotnet-msbuild.md).

- [!INCLUDE [help](includes/cli-help.md)]

- **`args`**

  Specifies extra arguments to pass to the test application(s). Use a space to separate multiple arguments. For more information and examples on what to pass, see [MTP overview](../testing/microsoft-testing-platform-intro.md) and [MTP features](../testing/microsoft-testing-platform-features.md).

  > [!TIP]
  > To specify extra arguments for specific projects, use the `TestingPlatformCommandLineArguments` MSBuild property. This property is especially useful when your solution mixes test frameworks (for example, MSTest and xUnit.net) or when only some projects reference a particular extension. For more information, see [Solutions with mixed test frameworks or extensions](../testing/unit-testing-with-dotnet-test.md#solutions-with-mixed-test-frameworks-or-extensions).

> [!NOTE]
> To enable trace logging to a file, use the environment variable `DOTNET_CLI_TEST_TRACEFILE` to provide the path to the trace file.
>
> Starting with .NET 11 RC 1, `dotnet test -bl` uses one MSBuild session for multi-project, multi-targeted, and device runs so the binary log contains the complete build.

## Output and cancellation behavior

Starting with .NET 11 Preview 6, interactive ANSI output shows tests that are currently running and reports per-assembly test counts. The progress display remains disabled when output is redirected, ANSI or progress output is disabled, or the environment isn't interactive.

Starting with .NET 11 Preview 6, the first <kbd>Ctrl</kbd>+<kbd>C</kbd> stops scheduling new test applications and requests cooperative cancellation. Press <kbd>Ctrl</kbd>+<kbd>C</kbd> again to terminate the child processes immediately. An aborted run exits with code 3.

Live test-host output requires an MTP host that supports protocol 1.1 or later. Older hosts keep output captured and replay it for a failed module. Starting with .NET 11 Preview 7, failure summaries truncate captured standard output longer than 40 lines to the first 30 and last 10 lines; diagnostic logs retain the complete output.

For multi-module runs, `dotnet test` evaluates the zero-test result across the complete run starting with .NET 11 Preview 7. A module with no tests doesn't fail the run if another module executes tests successfully, unless an explicit minimum-test policy requires more tests.

## Results and artifacts

When the SDK artifacts output layout is enabled, .NET 11 RC 1 and later versions place MTP reports, coverage files, and diagnostics under `<ArtifactsPath>/test/<project>/<pivot>` by default. An explicit `--results-directory` or `--results-directory-layout` takes precedence.

Starting with .NET 11 RC 1 and MTP 2.4, compatible extensions can post-process artifacts from a multi-module run. For example, the TRX extension can create a merged report while preserving the per-module reports. For extension and report requirements, see [MTP test reports](../testing/microsoft-testing-platform-test-reports.md).

## Forward arguments to the test application

`dotnet test` forwards any token it doesn't recognize to the test application. When a recognized option appears between an unrecognized option name and its value, removing the recognized option can change how the leftover tokens bind to options in the test application. To avoid this ambiguity, place test application arguments after a literal `--`:

```dotnetcli
dotnet test --results-directory TestResults -- --report-trx --report-trx-filename A.trx
```

The preceding example requires the [`Microsoft.Testing.Extensions.TrxReport`](https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) package, either as a direct package reference or through a test SDK configuration that includes it.

The same parser behavior applies to `dotnet run` and `dotnet build`. For a detailed example, see [Forward arguments to the application](dotnet-run.md#forward-arguments-to-the-application) in the `dotnet run` reference.

Starting with .NET 11 Preview 6, `--tl`, `--terminallogger`, and `--tlp` are forwarded to MSBuild instead of the test application. Starting with .NET 12 Preview 1, the recognized `-mt` and `-multiThreaded` forms are also forwarded to MSBuild. To pass an application option with one of these names, place it after `--`.

Pass execution-mode options such as `--help` and `--list-tests` directly to `dotnet test`. Starting with .NET 11 Preview 6, the SDK validates the execution mode negotiated with the test application. If a launch profile or `TestingPlatformCommandLineArguments` injects one of these options, the requested SDK operation and the application operation don't match, and the run fails with a diagnostic.

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

- Run all test projects referenced by a traversal project with .NET 11 Preview 7 or later:

  ```dotnetcli
  dotnet test dirs.proj
  ```

- List tests as JSON with .NET 11 Preview 7 or later:

  ```dotnetcli
  dotnet test --list-tests json
  ```

- Run a C# file-based MTP test app with .NET 12 Preview 1 or later:

  ```dotnetcli
  dotnet test App.Tests.cs
  ```

- Run the tests in the current directory with the Microsoft Code Coverage extension. The test application must reference [`Microsoft.Testing.Extensions.CodeCoverage`](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage), either directly or through a test SDK configuration that includes it:

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
- [MTP](../testing/microsoft-testing-platform-intro.md)
- [MTP features](../testing/microsoft-testing-platform-features.md)
- [MTP CLI options](../testing/microsoft-testing-platform-cli-options.md)
- [Run and debug MTP tests](../testing/microsoft-testing-platform-run-and-debug.md)
- [Run tests with MSTest](../testing/unit-testing-mstest-running-tests.md)
- [MSTest SDK configuration](../testing/unit-testing-mstest-sdk.md)
- [dotnet test](dotnet-test.md)
- [dotnet test with VSTest](dotnet-test-vstest.md)
