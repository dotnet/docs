---
title: MSTest runner integrations
description: Learn how to run MSTest runner tests through MSBuild and dotnet test.
author: nohwnd
ms.author: jajares
ms.date: 12/20/2023
---

# MSTest runner integrations

MSTest runner integrates with MSBuild and `dotnet test` to provide a simple way to run all tests in a solution (`.sln`) or in a single project.

## `dotnet test` integration

### `dotnet test` integration - VSTest mode

MSTest runner provides a compatibility layer to work with `dotnet test` seamlessly. This layer requires `Microsoft.Testing.Platform.MSBuild` NuGet package. This package is automatically installed as a dependency of `MSTest` and `MSTest.TestAdapter` package.

Tests can be executed by running:

```
dotnet test
```

This layer runs test through VSTest and integrates with it on VSTest Test Framework Adapter level.

### `dotnet test` - MSTest runner mode

By default VSTest is used to execute MSTest runner tests. User can opt-in to a fully MSTest runner provided mode. This mode integrates directly with the `dotnet test` target at MSBuild target level. The user opts-in by specifying `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` in their project file. When this mode is enabled, VSTest is not used to run tests at all.

In this mode additional parameters to the run are not provided directly through commandline. They need to be provided as MSBuild property `TestingPlatformCommandLineArguments`:

```
dotnet test -p:TestingPlatformCommandLineArguments=" --minimum-expected-tests 10 "
```

## Additional MSBuild options

### Show failure per test

By default test failures are summarized into an output file (`.log` file), and a single failure per test project is reported to MSBuild.


> [!CAUTION]
> Enabling this option adds overhead to test execution and may degrade performance.

To show errors per failed test, specify `<TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>` in your project file.

### Show complete platform output

Be default all console output that the underlying test executable writes is captured and hidden from the user. This includes the banner, version information, and formatted test information.

> [!CAUTION]
> Enabling this option adds overhead to test execution and may degrade performance.

To show this information together with MSBuild output use`<TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>`.

This option does not impact how the testing framework captures user output written by `Console.WriteLine` or other similar ways to write to the console.
