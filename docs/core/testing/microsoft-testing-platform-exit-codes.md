---
title: Microsoft.Testing.Platform exit codes
description: Learn about the various Microsoft.Testing.Platform exit codes and their meaning.
author: nohwnd
ms.author: jajares
ms.date: 11/27/2025
ms.topic: reference
---

# Microsoft.Testing.Platform exit codes

Microsoft.Testing.Platform uses exit codes to communicate the results of test execution. Understanding these exit codes helps you troubleshoot test failures, configure CI/CD pipelines, and automate testing workflows.

## When to check exit codes

Check exit codes in these scenarios:

- **CI/CD pipelines fail** - Determine whether tests failed, crashed, or encountered configuration issues.
- **Automated scripts** - Make decisions based on specific test outcomes.
- **Debugging test runs** - Understand why a test session didn't complete as expected.
- **Configuring build systems** - Decide which exit codes should fail the build.

## Exit code reference

Microsoft.Testing.Platform uses exit codes starting at `0` and are non-negative. The following table details each exit code and its meaning:

| Exit code | Details |
|-----|----------|
| `0` | Success. All tests that were chosen to run ran to completion, and there were no errors. |
| `1` | Unknown error. Acts as a _catch all_ for unexpected failures. Check the diagnostic output for details. For more information, see [Enable diagnostics](microsoft-testing-platform-options.md#diagnostic-options). |
| `2` | Test failure. At least one test failed during execution. Review the test output to identify which tests failed and why. |
| `3` | Test session aborted. The test session was canceled, typically by pressing <kbd>Ctrl</kbd>+<kbd>C</kbd> or through a termination signal. |
| `4` | Invalid extension setup. The configuration of test extensions is invalid, and the test session can't run. Check your project references and extension configuration. |
| `5` | Invalid command-line arguments. The arguments passed to the test app are invalid. Use `--help` to see available options. For more information, see [Configuration reference](microsoft-testing-platform-options.md). |
| `6` | Feature not implemented. The test session attempted to use a feature that isn't implemented. Check that all extensions support the features you're using. |
| `7` | Test host crash. The test session was unable to complete successfully and likely crashed. Check for unhandled exceptions or memory issues in your tests. Enable crash dumps for more information. For more information, see [Crash dump options](microsoft-testing-platform-options.md#crash-dump-options). |
| `8` | No tests ran. The test session completed but found zero tests to execute. This can happen when all tests are ignored, or filter expressions match no tests. |
| `9` | Minimum execution policy violated. The test session didn't meet the minimum expected number of tests configured with `--minimum-expected-tests`. |
| `10` | Test adapter infrastructure failure. The test framework (MSTest, NUnit, or xUnit) failed to run tests due to an infrastructure issue unrelated to test code. For example, failing to create a fixture needed by tests. |
| `11` | Dependent process exited. The test process exited because a dependent process (specified with `--exit-on-process-exit`) terminated. |
| `12` | Protocol version mismatch. The test session couldn't run because the client doesn't support any of the supported protocol versions. Update your test framework or tools. |
| `13` | Maximum failed tests reached. The test session was stopped after reaching the specified number of maximum failed tests using `--maximum-failed-tests`. For more information, see [Test execution options](microsoft-testing-platform-options.md#test-execution-options). |

## Common scenarios and solutions

This section provides practical guidance for the most frequently encountered exit codes.

### Exit code 2: Test failures

**What it means**: One or more tests failed during execution.

**What to do**:

1. **Review test output** to identify which tests failed:

   ```dotnetcli
   dotnet run --project MyTests
   ```

2. **Run only failed tests** using a filter:

   ```dotnetcli
   dotnet run --project MyTests -- --filter "FullyQualifiedName~FailedTestName"
   ```

3. **Enable detailed diagnostics** for more information:

   ```dotnetcli
   dotnet run --project MyTests -- --diagnostic --diagnostic-verbosity Trace
   ```

4. **Ignore in specific scenarios** where test failures shouldn't fail the build:

   ```dotnetcli
   dotnet run --project MyTests -- --ignore-exit-code 2
   ```

For more information about filtering tests, see [Running selective unit tests](selective-unit-tests.md).

### Exit code 8: No tests ran

**What it means**: The test session completed but found no tests to execute.

**Common causes**:

- All tests are explicitly ignored or skipped
- Filter expression matched no tests
- Test discovery failed
- Tests aren't properly decorated with test attributes

**Solutions**:

1. **Check if tests are ignored**. Look for `[Ignore]` or similar attributes.

2. **Verify filter expressions**:

   ```dotnetcli
   # List all tests to see what's available
   dotnet run --project MyTests -- --list-tests
   ```

3. **Check test discovery**. Ensure tests have proper attributes like `[TestMethod]`, `[Test]`, or `[Fact]`.

4. **Ignore this exit code for projects with skipped tests**:

   Add to your project file:

   ```xml
   <PropertyGroup>
     <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
   </PropertyGroup>
   ```

### Exit code 5: Invalid command-line arguments

**What it means**: The arguments passed to the test executable are invalid.

**Solutions**:

1. **Check available options**:

   ```dotnetcli
   dotnet run --project MyTests -- --help
   ```

2. **Verify argument syntax**. Common mistakes include:
   - Missing values for options that require them
   - Using unsupported options
   - Incorrect format for complex arguments like filters

3. **Use response files** for complex command lines:

   Create a file named *test-args.rsp*:

   ```rsp
   --filter "FullyQualifiedName~Calculator"
   --timeout 5m
   --diagnostic
   ```

   Then run:

   ```dotnetcli
   dotnet run --project MyTests -- @test-args.rsp
   ```

For more information, see [Configuration reference](microsoft-testing-platform-options.md).

### Exit code 7: Test host crash

**What it means**: The test process crashed during execution.

**Solutions**:

1. **Enable crash dumps** to capture the crash state:

   ```dotnetcli
   dotnet add package Microsoft.Testing.Extensions.CrashDump
   ```

   Then run with crash dump enabled:

   ```dotnetcli
   dotnet run --project MyTests -- --crashdump
   ```

2. **Check for common crash causes**:
   - Unhandled exceptions in test code
   - Stack overflow
   - Out of memory errors
   - Native code crashes

3. **Run tests in isolation** to identify the problematic test:

   ```dotnetcli
   dotnet run --project MyTests -- --filter "FullyQualifiedName~SuspectedTest"
   ```

For more information about crash dumps, see [Crash dump options](microsoft-testing-platform-options.md#crash-dump-options).

### Exit code 13: Maximum failed tests reached

**What it means**: The test session was stopped after reaching the specified maximum number of test failures.

**What to do**:

1. **Review the failed tests** to identify common issues.

2. **Adjust the threshold** if needed:

   ```dotnetcli
   dotnet run --project MyTests -- --maximum-failed-tests 10
   ```

3. **Remove the limit** to see all failures:

   Remove the `--maximum-failed-tests` argument from your command line.

This feature is useful in CI/CD pipelines to fail fast when a certain number of tests fail, saving time and resources.

## Configuring exit code behavior

Microsoft.Testing.Platform is strict by default but allows you to configure which exit codes should be ignored. When an exit code is ignored, the process returns `0` instead.

### Using command-line options

Ignore specific exit codes using the `--ignore-exit-code` option:

```dotnetcli
dotnet run --project MyTests -- --ignore-exit-code 2
```

Ignore multiple exit codes with a semicolon-separated list:

```dotnetcli
dotnet run --project MyTests -- --ignore-exit-code 2;8
```

### Using environment variables

Set the `TESTINGPLATFORM_EXITCODE_IGNORE` environment variable:

**Windows (Command Prompt)**:

```cmd
set TESTINGPLATFORM_EXITCODE_IGNORE=2;8
dotnet run --project MyTests
```

**Windows (PowerShell)**:

```powershell
$env:TESTINGPLATFORM_EXITCODE_IGNORE = "2;8"
dotnet run --project MyTests
```

**Linux/macOS**:

```bash
export TESTINGPLATFORM_EXITCODE_IGNORE=2;8
dotnet run --project MyTests
```

### Using MSBuild properties

Set exit codes to ignore in your project file for consistent behavior across all test runs:

```xml
<PropertyGroup>
  <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
</PropertyGroup>
```

This approach is recommended for project-specific configuration, such as test projects where all tests are intentionally skipped.

### Common use cases

**Allow test failures without failing CI**:

Useful for generating test reports even when tests fail:

```dotnetcli
dotnet run --project MyTests -- --ignore-exit-code 2 --report-trx
```

**Ignore "no tests ran" for optional test projects**:

Some projects might have tests conditionally compiled. Ignore exit code 8 to avoid failures when no tests are present:

```xml
<PropertyGroup>
  <TestingPlatformCommandLineArguments>$(TestingPlatformCommandLineArguments) --ignore-exit-code 8</TestingPlatformCommandLineArguments>
</PropertyGroup>
```

**CI/CD pipeline examples**:

**Azure Pipelines**:

```yml
- task: CmdLine@2
  displayName: "Run Tests"
  inputs:
    script: 'dotnet run --project MyTests -- --ignore-exit-code 2'
  continueOnError: true
```

**GitHub Actions**:

```yml
- name: Run Tests
  run: dotnet run --project MyTests -- --ignore-exit-code 2
  continue-on-error: true
```

For more information about configuration methods, see [Configuration reference](microsoft-testing-platform-options.md).

## Troubleshooting tips

When encountering unexpected exit codes:

1. **Enable diagnostics** for detailed logging:

   ```dotnetcli
   dotnet run --project MyTests -- --diagnostic --diagnostic-verbosity Trace
   ```

   The diagnostic log is saved to the *TestResults* directory by default.

2. **Check the test output** for error messages and stack traces.

3. **Run tests with `--list-tests`** to verify test discovery:

   ```dotnetcli
   dotnet run --project MyTests -- --list-tests
   ```

4. **Isolate the problem** by running a subset of tests:

   ```dotnetcli
   dotnet run --project MyTests -- --filter "FullyQualifiedName~Namespace.Class"
   ```

5. **Check for extension conflicts**. Review installed NuGet packages for testing extensions and ensure they're compatible versions.

6. **Use `--info`** to see detailed platform information:

   ```dotnetcli
   dotnet run --project MyTests -- --info
   ```

For more information about diagnostics, see [Diagnostic options](microsoft-testing-platform-options.md#diagnostic-options).

## See also

- [Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md)
- [Run tests with Microsoft.Testing.Platform](microsoft-testing-platform-run-tests.md)
- [Configuration reference](microsoft-testing-platform-options.md)
- [Get started with Microsoft.Testing.Platform](microsoft-testing-platform-getting-started.md)
- [Running selective unit tests](selective-unit-tests.md)
- [Testing with dotnet test](unit-testing-with-dotnet-test.md)
