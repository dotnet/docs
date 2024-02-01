---
title: Use MSTest runner with `dotnet test`
description: Learn how to run MSTest runner tests through dotnet test.
author: nohwnd
ms.author: jajares
ms.date: 12/20/2023
---

# Use MSTest runner with `dotnet test`

This article describes how to use `dotnet test` to run tests when using MSTest runner, and the various options that are available to configure the MSBuild output produced when running tests through MSTest runner.

This article shows how to use `dotnet test` to run all tests in a solution (_*.sln_) that uses MSTest runner.

## `dotnet test` integration

The [dotnet test](../tools/dotnet-test.md) command is a way to run tests from solutions, projects, or already built assemblies. [MSTest runner](unit-testing-mstest-runner-intro.md) hooks up into this infrastructure to provide a unified way to run tests, especially when migrating from VSTest to MSTest runner.

### `dotnet test` integration - VSTest mode

MSTest runner provides a compatibility layer to work with `dotnet test` seamlessly.

Tests can be run by running:

```dotnetcli
dotnet test
```

This layer runs test through VSTest and integrates with it on VSTest Test Framework Adapter level.

### `dotnet test` - MSTest runner mode

By default, VSTest is used to run MSTest runner tests. You can enable a full MSTest runner by specifying the `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` setting in your project. This setting disables VSTest and thanks to the transitive dependency to the [Microsoft.Testing.Platform.MSBuild](https://nuget.org/packages/Microsoft.Testing.Platform.MSBuild) NuGet package it will directly run all `MSTest runner` empowered tests project in your solution. It works seamlessly if you pass a direct `MSTest runner` test project.

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

    <!-- Add this to your project file. -->
    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

In this mode, additional parameters to the run aren't provided directly through the command line. They need to be provided as an MSBuild property named `TestingPlatformCommandLineArguments`:

```dotnetcli
dotnet test -p:TestingPlatformCommandLineArguments=" --minimum-expected-tests 10 "
```

## Additional MSBuild options

The MSBuild integration provides options that can be specified in user project or through global properties on the command line, such as `-p:TestingPlatformShowTestsFailure=true`.

These are the available options:

- [Show failure per test](#show-failure-per-test)
- [Show complete platform output](#show-complete-platform-output)

### Show failure per test

By default test failures are summarized into a _.log_ file, and a single failure per test project is reported to MSBuild.

To show errors per failed test, specify `-p:TestingPlatformShowTestsFailure=true` on the command line, or add `<TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>` property to your project file.

On command line:

```dotnetcli
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

  <!-- ... -->

</Project>
```

### Show complete platform output

By default, all console output that the underlying test executable writes is captured and hidden from the user. This includes the banner, version information, and formatted test information.

To show this information together with MSBuild output use`<TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>`.

This option doesn't impact how the testing framework captures user output written by `Console.WriteLine` or other similar ways to write to the console.

On command line:

```dotnetcli
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

  <!-- ... -->

</Project>
```
