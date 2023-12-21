---
title: MSTest runner integrations
description: Learn how to run MSTest runner tests through MSBuild and dotnet test.
author: nohwnd
ms.author: jajares
ms.date: 12/20/2023
---

# MSTest runner integrations

This article describes how to use `dotnet test` to run tests when using MSTest runner, and the various options that are available to configure the MSBuild output produced when running tests through MSTest runner.

This article shows how to use `dotnet test` to run all tests in a solution (`.sln`) that uses MSTest runner.

## `dotnet test` integration

`dotnet test` command is a way to run tests from solutions, projects or already built assemblies. MSTest runner hooks up into this infrastructure to provide a unified way to run tests. Especially when migrating from VSTest to MSTest runner.

### `dotnet test` integration - VSTest mode

MSTest runner provides a compatibility layer to work with `dotnet test` seamlessly. This layer requires `Microsoft.Testing.Platform.MSBuild` NuGet package. This package is automatically installed as a dependency of `MSTest` and `MSTest.TestAdapter` package.

Tests can be run by running:

```
dotnet test
```

This layer runs test through VSTest and integrates with it on VSTest Test Framework Adapter level.

### `dotnet test` - MSTest runner mode

By default VSTest is used to run MSTest runner tests. User can opt-in to a fully MSTest runner provided mode. This mode integrates directly with the `dotnet test` target at MSBuild target level. The user opts-in by specifying `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` in their csproj file. When this mode is enabled, VSTest is not used to run tests at all.

In this mode additional parameters to the run are not provided directly through commandline. They need to be provided as MSBuild property `TestingPlatformCommandLineArguments`:

```
dotnet test -p:TestingPlatformCommandLineArguments=" --minimum-expected-tests 10 "
```

## Additional MSBuild options

The MSBuild integration provides options that can be specified in user project or through global properties on command line, such as `-p:TestingPlatformShowTestsFailure=true`.

These are the available options:

### Show failure per test

By default test failures are summarized into a _.log_ file, and a single failure per test project is reported to MSBuild.

> [!CAUTION]
> Enabling this option adds overhead to test execution and may degrade performance.

To show errors per failed test, specify `-p:TestingPlatformShowTestsFailure=true` on commandline, or add `<TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>` property to your project file.

On command line:

```
dotnet test -p:TestingPlatformShowTestsFailure=true
```

Or in project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>

  </PropertyGroup>

  ...

</Project>
```

### Show complete platform output

By default, all console output that the underlying test executable writes is captured and hidden from the user. This includes the banner, version information, and formatted test information.

> [!CAUTION]
> Enabling this option adds overhead to test execution and may degrade performance.

To show this information together with MSBuild output use`<TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>`.

This option doesn't impact how the testing framework captures user output written by `Console.WriteLine` or other similar ways to write to the console.

On command line:

```
dotnet test -p:TestingPlatformCaptureOutput=true
```

Or in project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>

  </PropertyGroup>

  ...

</Project>
```
