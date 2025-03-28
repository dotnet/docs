---
title: Use Microsoft.Testing.Platform with VSTest mode of `dotnet test`
description: Learn how to run Microsoft.Testing.Platform tests through dotnet test.
author: nohwnd
ms.author: jajares
ms.date: 03/26/2025
---

# Use Microsoft.Testing.Platform with VSTest mode of `dotnet test`

This article describes `dotnet test` integration for Microsoft.Testing.Platform that is provided by Microsoft.Testing.Platform.MSBuild when running with VSTest mode of `dotnet test`.

Before reading this article, it's advised to read [Testing with dotnet test](unit-testing-with-dotnet-test.md) first.

By default, `dotnet test` is using VSTest behavior to run tests. To enable support for `Microsoft.Testing.Platform` in `dotnet test`, there are two options:

1. Use `dotnet test` in VSTest mode, and specify `<TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>` MSBuild property in your project file.
2. Use `dotnet test` in MTP mode, and enjoy more native support of MTP in `dotnet test`. This is only supported starting with .NET 10 SDK.

Both of these options are explained in details in the [Testing with dotnet test](unit-testing-with-dotnet-test.md) article.

> [!IMPORTANT]
> The remaining of this article is specific to the first option.

## Show failure per test

By default, test failures are summarized into a _.log_ file, and a single failure per test project is reported to MSBuild.

To show errors per failed test, specify `-p:TestingPlatformShowTestsFailure=true` on the command line, or add the `<TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>` property to your project file.

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

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformShowTestsFailure>true</TestingPlatformShowTestsFailure>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

## Show complete platform output

By default, all console output that the underlying test executable writes is captured and hidden from the user. This includes the banner, version information, and formatted test information.

To show this information together with MSBuild output, use `<TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>`.

This option doesn't impact how the testing framework captures user output written by `Console.WriteLine` or other similar ways to write to the console.

On command line:

```dotnetcli
dotnet test -p:TestingPlatformCaptureOutput=false
```

Or in project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>

    <OutputType>Exe</OutputType>
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TestingPlatformDotnetTestSupport>true</TestingPlatformDotnetTestSupport>

    <!-- Add this to your project file. -->
    <TestingPlatformCaptureOutput>false</TestingPlatformCaptureOutput>

  </PropertyGroup>

  <!-- ... -->

</Project>
```

> [!IMPORTANT]
> All examples above add properties like `EnableMSTestRunner`, `TestingPlatformDotnetTestSupport`, and `TestingPlatformCaptureOutput` in the csproj file. However, it's highly recommended that you set these properties in `Directory.Build.props`. That way, you don't have to add it to every test project file, and you don't risk introducing a new project that doesn't set these properties and end up with a solution where some projects are VSTest while others are Microsoft.Testing.Platform, which may not work correctly and is unsupported scenario.
