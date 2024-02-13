---
title: MSTest SDK
author: MarcoRossignoli
description: Overview of MSTest.Sdk.
ms.author: mrossignoli
ms.date: 02/13/2024
---

# MSTest SDK

## Overview

`MSTest.Sdk` is an [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building MSTest apps.  
It's possible to build an MSTest app without this SDK, however, the MSTest SDK is:

* Clear and coincise letting you to focus on your tests without the noise of the test infrastructure.
* Simple to configure.
* The recommended target for most users.

How to use the `MSTest.Sdk` in a project:

  ```xml
  <!-- 
       You can set a different sdk version, 3.3.0 is an example
       You can set the SDK version at solution level using the global.json
       Follow this guide:
       https://learn.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk?#how-project-sdks-are-resolved
  -->
  <Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>
    <!-- references to the code to test -->      
  </Project>
  ```

When you `build` the project all the needed components will be restored and installed using the standard NuGet workflow set by your project. Usually the components are downloaded from the official NuGet feed unless set differently.

You don't need anything else to build and run your tests and you can use the same tooling (i.e. `dotnet test`, Visual Studio etc...) used by a ["classic"](./index.md/#mstest) MSTest project.

## `MSTest.Sdk` with the `MSTest runner`

The `MSTest.Sdk` supports the [`MSTest runner`](./unit-testing-mstest-runner-intro.md) and simplify the configuration of extensions to make the experience easy and smooth.

How to use the `MSTest.Sdk` with the `MSTest runner` in a project:

  ```xml
  <Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMSTestRunner>true</EnableMSTestRunner> 
        <OutputType>Exe</OutputType> 
    </PropertyGroup>
    <!-- references to the code to test -->
  </Project>
  ```

 The `MSTest runner` comes with a set of built-in [extensions](./unit-testing-mstest-runner-extensions.md) that you can enable using an MSBuild property with the pattern `Enable[NugetPackageNameWithoutDots]`.  

 For instance to enable the `MS Code Coverage` shipped as `Microsoft.Testing.Extensions.CodeCoverage` NuGet package you can use the property `<EnableMicrosoftTestingExtensionsCodeCoverage>true</EnableMicrosoftTestingExtensionsCodeCoverage>`:  

  ```xml
  <Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMSTestRunner>true</EnableMSTestRunner> 
        <OutputType>Exe</OutputType> 
    </PropertyGroup>

    <!-- Extensions -->
    <PropertyGroup>
        <EnableMicrosoftTestingExtensionsCodeCoverage>true</EnableMicrosoftTestingExtensionsCodeCoverage>
    </PropertyGroup>

    <!-- references to the code to test -->
  </Project>
  ```

### Available extensions

| Extension package | MSBuild property |
| -------- | ----------- |
| `Microsoft.Testing.Extensions.CodeCoverage` | `<EnableMicrosoftTestingExtensionsCodeCoverage>true</EnableMicrosoftTestingExtensionsCodeCoverage>` |
| `Microsoft.Testing.Extensions.TrxReport` | `<EnableMicrosoftTestingExtensionsTrxReport>true</EnableMicrosoftTestingExtensionsTrxReport>` |
| `Microsoft.Testing.Extensions.CrashDump` | `<EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>` |
| `Microsoft.Testing.Extensions.HangDump` | `<EnableMicrosoftTestingExtensionsHangDump>true</EnableMicrosoftTestingExtensionsHangDump>` |
| `Microsoft.Testing.Extensions.Retry` | `<EnableMicrosoftTestingExtensionsRetry>true</EnableMicrosoftTestingExtensionsRetry>` |
| `Microsoft.Testing.Extensions.HotReload` | `<EnableMicrosoftTestingExtensionsHotReload>true</EnableMicrosoftTestingExtensionsHotReload>` |

You can enable all the available extensions in "bulk" using the `<EnableAllTestingExtensions>true</EnableAllTestingExtensions>`

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMSTestRunner>true</EnableMSTestRunner> 
        <OutputType>Exe</OutputType> 
        <EnableAllTestingExtensions>true</EnableAllTestingExtensions>
    </PropertyGroup>
    
    <!-- references to the code to test -->
</Project>
```
