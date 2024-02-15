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

* Tailored towards providing a first-class experience for testing with MSTest
* The recommended target for most users.
* Yet easy to configure for others.

The MSTest SDK will discover and run your tests using the [`MSTest runner`](./unit-testing-mstest-runner-intro.md)

How to use the `MSTest.Sdk` in a project:

  ```xml
  <Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>
    <!-- references to the code to test -->      
  </Project>
  ```

> [!NOTE]
> You can set a different sdk version, 3.3.0 is an example.  
> Alternatively, you can set the SDK version at solution level using the global.json, [follow this guide](https://learn.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk?#how-project-sdks-are-resolved).

When you `build` the project all the needed components will be restored and installed using the standard NuGet workflow set by your project.

You don't need anything else to build and run your tests and you can use the same tooling (i.e. `dotnet test`, Visual Studio etc...) used by a ["classic" MSTest project](./unit-testing-with-mstest.md)

## Register extensions

 The `MSTest runner` comes with a set of [extensions](./unit-testing-mstest-runner-extensions.md) that you can enable using an MSBuild property with the pattern `Enable[NugetPackageNameWithoutDots]`.  

 For instance to enable the crash dump shipped as `Microsoft.Testing.Extensions.CrashDump` NuGet package you can use the property `<EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>`:  

  ```xml
  <Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>
    </PropertyGroup>
    <!-- references to the code to test -->
  </Project>
  ```

### Available extensions

| Extension package | MSBuild property | Enabled by default |
| -------- | ----------- | ----------- |
| `Microsoft.Testing.Extensions.CodeCoverage` | `<EnableMicrosoftTestingExtensionsCodeCoverage>true</EnableMicrosoftTestingExtensionsCodeCoverage>` | ✔️ |
| `Microsoft.Testing.Extensions.TrxReport` | `<EnableMicrosoftTestingExtensionsTrxReport>true</EnableMicrosoftTestingExtensionsTrxReport>` | ✔️ |
| `Microsoft.Testing.Extensions.CrashDump` | `<EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>` | ❌ |
| `Microsoft.Testing.Extensions.HangDump` | `<EnableMicrosoftTestingExtensionsHangDump>true</EnableMicrosoftTestingExtensionsHangDump>` | ❌ |
| `Microsoft.Testing.Extensions.Retry` | `<EnableMicrosoftTestingExtensionsRetry>true</EnableMicrosoftTestingExtensionsRetry>` | ❌ |
| `Microsoft.Testing.Extensions.HotReload` | `<EnableMicrosoftTestingExtensionsHotReload>true</EnableMicrosoftTestingExtensionsHotReload>` | ❌ |

If you want to disable the default extensions registration you can set the MSBuild property `EnableDefaultMicrosoftTestingExtensions` to `false` (e.g. `<EnableDefaultMicrosoftTestingExtensions>false</EnableDefaultMicrosoftTestingExtensions>`).

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableDefaultMicrosoftTestingExtensions>false</EnableDefaultMicrosoftTestingExtensions>
    </PropertyGroup>    
    <!-- references to the code to test -->
</Project>
```

You can also opt-out specific extension setting to false its respective MSBuild property.  
For instance you can opt-out the default `MS Code Coverage` by setting `<EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>`. Full-example below:

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>
    </PropertyGroup>    
    <!-- references to the code to test -->
</Project>
```

You can enable all the available extensions in "bulk" using the `<EnableAllTestingExtensions>true</EnableAllTestingExtensions>`

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableAllMicrosoftTestingExtensions>true</EnableAllMicrosoftTestingExtensions>
    </PropertyGroup>    
    <!-- references to the code to test -->
</Project>
```

> [!WARNING]
> Different extensions come with different licensing model, we invite you to check the rights.
