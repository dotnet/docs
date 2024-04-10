---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts (continuous integration (CI) pipelines, CLI, Visual Studio Test Explorer, VS Code Text Explorer...). The MSTest runner is embedded directly in your MSTest test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

The MSTest runner is open source, and builds on a [`Microsoft.Testing.Platform`](./unit-testing-platform-intro.md) library. You can find `Microsoft.Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository. The MSTest runner comes bundled with `MSTest in 3.2.0-preview.23623.1` or newer.

## Enable MSTest runner in a MSTest project

We recommend using [MSTest SDK](./unit-testing-mstest-sdk.md) as it greatly simplifies your project configuration, the update of the project and ensures a proper alignment of the versions of the platform (MSTest runner) and its extensions.

When using `MSTest SDK` you will by-default opt-in to use MSTest runner.

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

Alternatively, you can enable MSTest runner by adding the `EnableMSTestRunner` property and setting `OutputType` to `Exe` in your project file. You also need to ensure that you're using `MSTest 3.2.0-preview.23623.1` or newer.

Consider the following example project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the MSTest runner, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>
    <OutputType>Exe</OutputType>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <!-- 
      MSTest meta package is the recommended way to reference MSTest.
      It's equivalent to referencing:
          Microsoft.NET.Test.Sdk
          MSTest.TestAdapter
          MSTest.TestFramework
          MSTest.Analyzers
    -->    
    <PackageReference Include="MSTest" Version="3.2.0" />

    <!-- 
      Coverlet collector isn't compatible with MSTest runner, you can 
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    --> 
    <PackageReference Include="Microsoft.Testing.Extensions.CodeCoverage" 
                      Version="17.10.1" />
  </ItemGroup>

</Project>
```
