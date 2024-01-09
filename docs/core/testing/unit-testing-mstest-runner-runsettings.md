---
title: MSTest runner runsettings
description: Learn how to use runsettings with MSTest runner to configure MSTest test framework.
author: nohwnd
ms.author: jajares
ms.date: 01/03/2024
---


# Using runsettings with MSTest runner

MSTest runner allows you to provide a [VSTest *.runsettings* file](https://learn.microsoft.com/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file), but not all options in this file are picked up by the runner. This article will teach you about the supported and unsupported settings, and configuration options. This article will show you alternatives for the most used VSTest configuration options.

## Supported runsettings

### MSTest runsettings

All runsettings in `<MSTest>` section of the configuration file are supported by MSTest runner. 

Their full description can be [found here](https://learn.microsoft.com/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2022#mstest-element).

## Unsupported runsettings

### RunConfiguration

The **RunConfiguration** element can include the following elements. None of these settings are respected by the MSTest runner:

|Node|Description|Reason / workaround |
|-|-|-|
|**MaxCpuCount**|This setting controls the level of parallelism on process-level. Use 0 to enable the maximum process-level parallelism.| When MSTest runner is used with MSBuild, this option is [offloaded to MSBuild](https://learn.microsoft.com/visualstudio/msbuild/building-multiple-projects-in-parallel-with-msbuild). When a single executable is run, this option has no meaning for MSTest runner.
|**ResultsDirectory**|The directory where test results are placed. The path is relative to the directory that contains .runsettings file.| Use the commandline option `--results-directory` to determine the directory where the test results are going to be placed. If the specified directory doesn't exist, it's created. The default is `TestResults` in the directory that contains the test application.
|**TargetFrameworkVersion**| This setting defines the framework version, or framework family to use to run tests.| This option is ignored. The `<TargetFramework>` or `<TargetFrameworks>` MSBuild properties determine the target framework of the application. The tests are hosted in the final application.
|**TargetPlatform**|This setting defines the architecture to use to run tests. | `<RuntimeIdentifier>` determines the architecture of the final application that hosts the tests.
|**TreatTestAdapterErrorsAsWarnings**|Suppresses test adapter errors to become warnings. | MSTest runner allows only one type of tests to be run from a single assembly, and failure to load the test framework or other parts of infrastructure will become an unskippable error, because it signifies that some tests could not be discovered or run.
|**TestAdaptersPaths**| One or more paths to the directory where the TestAdapters are located| MSTest runner does not use the concept of test adapters and does not allow dynamic loading of extensions unless they are part of the build, and are registered in `Program.cs`, either automatically via build targets or manually. |
|**TestCaseFilter**| A filter to limit tests which will run. | To filter tests use `--filter` command line option.
|**TestSessionTimeout**|Allows users to terminate a test session when it exceeds a given timeout.| There is no alternative option. |
|**DotnetHostPath**|Specify a custom path to dotnet host that is used to run the testhost. | MSTest runner is not doing any additional resolving of dotnet. It depends fully on how dotnet resolves itself, which can be controlled by environment variables such as [`DOTNET_HOST_PATH`](https://learn.microsoft.com/dotnet/core/tools/dotnet-environment-variables#dotnet_host_path)
|**TreatNoTestsAsError**| Exit with non-zero exit code when no tests are discovered. | MSTest runner will error by default when no tests are discovered or run in a test application. You can set how many tests you expect to find in the assembly by using `--minimum-expected-tests` command line parameter, which defaults to 1.


### DataCollectionRunSettings

MSTest runner is not using data collectors. Instead it has the concept of in-process and out-of-process extensions. Each extension is configured by its respective configuration file, or through commandline.

Most importantly [hang](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-runner-extensions#hang-dump-files) and [crash](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-runner-extensions#crash-dump-files) extension, and [code coverage](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-runner-extensions#microsoft-code-coverage) extension.

### LoggerRunSettings

Loggers in MSTest runner are configured through commandline parameters, or by settings in code.
