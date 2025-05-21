---
title: Microsoft.Testing.Platform VSTest bridge extension
description: Learn about the various Microsoft.Testing.Platform VSTest bridge extension and how to use it.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
ms.topic: article
---

# VSTest Bridge extension

This extension provides a compatibility layer with VSTest allowing the test frameworks depending on it to continue supporting running in VSTest mode (`vstest.console.exe`, usual `dotnet test`, `VSTest task` on AzDo, Test Explorers of Visual Studio and Visual Studio Code...). This extension is shipped as part of [Microsoft.Testing.Extensions.VSTestBridge](https://www.nuget.org/packages/Microsoft.Testing.Extensions.VSTestBridge) package.

## Compatibility with VSTest

The main purpose of this extension is to offer an easy and smooth upgrade experience for VSTest users by allowing a dual mode where the new platform is enabled and in parallel a compatibility mode is offered to allow the usual workflows to continue working.

## Runsettings support

This extension allows you to provide a [VSTest *.runsettings* file](/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file), but not all options in this file are picked up by the platform. We describe below the supported and unsupported settings, configuration options and alternatives for the most used VSTest configuration options.

When enabled by the test framework, you can use `--settings <SETTINGS_FILE>` to provide the `.runsettings` file.

### RunConfiguration element

The following **RunConfiguration** elements are not supported by `Microsoft.Testing.Platform`:

| Node | Description | Reason / Workaround |
|------|-------------|---------------------|
| **MaxCpuCount** | This setting controls the level of parallelism on process-level. Use 0 to enable the maximum process-level parallelism.| When Microsoft.Testing.Platform is used with MSBuild, this option is [offloaded to MSBuild](/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild). When a single executable is run, this option has no meaning for Microsoft.Testing.Platform. |
| **ResultsDirectory** | The directory where test results are placed. The path is relative to the directory that contains the *.runsettings* file.| Use the command-line option `--results-directory` to determine the directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application. |
| **TargetFrameworkVersion** | This setting defines the framework version, or framework family to use to run tests.| This option is ignored. The `<TargetFramework>` or `<TargetFrameworks>` MSBuild properties determine the target framework of the application. The tests are hosted in the final application. |
| **TargetPlatform** | This setting defines the architecture to use to run tests. | `<RuntimeIdentifier>` determines the architecture of the final application that hosts the tests. |
| **TreatTestAdapterErrorsAsWarnings** | Suppresses test adapter errors to become warnings. | Microsoft.Testing.Platform allows only one type of tests to be run from a single assembly, and failure to load the test framework or other parts of infrastructure will become an un-skippable error, because it signifies that some tests could not be discovered or run. |
| **TestAdaptersPaths** | One or more paths to the directory where the TestAdapters are located| Microsoft.Testing.Platform does not use the concept of test adapters and does not allow dynamic loading of extensions unless they are part of the build, and are registered in `Program.cs`, either automatically via build targets or manually. |
| **TestCaseFilter** | A filter to limit tests which will run. | Starting with v1.6, this runsettings entry is now supported. Before this version, you should use `--filter` command line option instead. |
| **TestSessionTimeout** | Allows users to terminate a test session when it exceeds a given timeout.| There is no alternative option. |
| **DotnetHostPath** | Specify a custom path to dotnet host that is used to run the test host. | Microsoft.Testing.Platform is not doing any additional resolving of dotnet. It depends fully on how dotnet resolves itself, which can be controlled by environment variables such as [`DOTNET_HOST_PATH`](../tools/dotnet-environment-variables.md#dotnet_host_path). |
| **TreatNoTestsAsError** | Exit with non-zero exit code when no tests are discovered. | Microsoft.Testing.Platform will error by default when no tests are discovered or run in a test application. You can set how many tests you expect to find in the assembly by using `--minimum-expected-tests` command line parameter, which defaults to 1. |

### DataCollectors element

`Microsoft.Testing.Platform` is not using data collectors. Instead it has the concept of in-process and out-of-process extensions. Each extension is configured by its respective configuration file or through the command line.

Most importantly [hang](microsoft-testing-platform-extensions-diagnostics.md#hang-dump) and [crash](microsoft-testing-platform-extensions-diagnostics.md#crash-dump) extension, and [code coverage](microsoft-testing-platform-extensions-code-coverage.md) extension.

### LoggerRunSettings element

Loggers in `Microsoft.Testing.Platform` are configured through command-line parameters or by settings in code.

## VSTest filter support

This extension also offer the ability to use VSTest filtering mechanism to discover or run only the tests that matches the filter expression. For more information, see the [Filter option details](../tools/dotnet-test.md#filter-option-details) section or for framework specific details see the [Running selective unit tests](./selective-unit-tests.md) page.

When enabled by the test framework, you can use `--filter <FILTER_EXPRESSION>`.

## TestRun parameters

You can pass parameters to the test run by using the `--test-parameter` command line option in the format `key=value`. This option can be specified multiple times, one for each parameter to set.

These parameters can then be accessed by the test framework in the test run:

- for MSTest, use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.Properties>
- for NUnit, use [TestContext.TestParameters](https://docs.nunit.org/articles/nunit/writing-tests/TestContext.html#testparameters)
