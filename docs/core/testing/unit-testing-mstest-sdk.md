---
title: MSTest SDK overview
author: MarcoRossignoli
description: Learn about the MSTest.Sdk and how to configure profiles and extensions with MSBuild properties.
ms.author: mrossignoli
ms.date: 02/13/2024
---

# MSTest SDK overview

`MSTest.Sdk` is an [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building MSTest apps.  
It's possible to build an MSTest app without this SDK, however, the MSTest SDK is:

* Tailored towards providing a first-class experience for testing with MSTest
* The recommended target for most users.
* Yet easy to configure for others.

The MSTest SDK will discover and run your tests using the [`MSTest runner`](./unit-testing-mstest-runner-intro.md)

How to use the `MSTest.Sdk` in a project:

  ```xml
  <Project Sdk="MSTest.Sdk/3.3.1">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>
    <!-- references to the code to test -->      
  </Project>
  ```

> [!NOTE]
> `/3.3.1` is given as example as it's the first version providing the SDK but it can be replaced with any newer version.
> Alternatively, you can set the SDK version at solution level using the _global.json_. For more information, see [Use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk?#how-project-sdks-are-resolved).

When you `build` the project all the needed components will be restored and installed using the standard NuGet workflow set by your project.

You don't need anything else to build and run your tests and you can use the same tooling (for example, `dotnet test` or Visual Studio) used by a ["classic" MSTest project](./unit-testing-with-mstest.md).

## Register extensions

The `MSTest runner` comes with a set of [extensions](./unit-testing-platform-extensions.md) that you can enable using an MSBuild property with the pattern `Enable[NugetPackageNameWithoutDots]`.  

For example, to enable the crash dump extension in the [Microsoft.Testing.Extensions.CrashDump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump) NuGet package use the following property `EnableMicrosoftTestingExtensionsCrashDump`:  

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

| Extension package | MSBuild property | 'Default' profile | 'AllMicrosoft' profile |
| -------- | ----------- | ----------- | ----------- |
| `Microsoft.Testing.Extensions.CodeCoverage` | `<EnableMicrosoftTestingExtensionsCodeCoverage>true</EnableMicrosoftTestingExtensionsCodeCoverage>` | ✔️ | ✔️ |
| `Microsoft.Testing.Extensions.TrxReport` | `<EnableMicrosoftTestingExtensionsTrxReport>true</EnableMicrosoftTestingExtensionsTrxReport>` | ✔️ | ✔️ |
| `Microsoft.Testing.Extensions.CrashDump` | `<EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>` | ❌ | ✔️ |
| `Microsoft.Testing.Extensions.HangDump` | `<EnableMicrosoftTestingExtensionsHangDump>true</EnableMicrosoftTestingExtensionsHangDump>` | ❌ | ✔️ |
| `Microsoft.Testing.Extensions.Retry` | `<EnableMicrosoftTestingExtensionsRetry>true</EnableMicrosoftTestingExtensionsRetry>` | ❌ | ✔️ |
| `Microsoft.Testing.Extensions.HotReload` | `<EnableMicrosoftTestingExtensionsHotReload>true</EnableMicrosoftTestingExtensionsHotReload>` | ❌ | ✔️ |

The `MSTest.Sdk` simplifies the registration of extensions by including a pre-packaged set of them under different profiles, as shown in the preceding table.

To enable a specific profile, use the `TestingExtensionsProfile` MSBuild property.  
For example, if you wish to enable all Microsoft testing extensions, you can configure the `TestingExtensionsProfile` as shown below:

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <TestingExtensionsProfile>AllMicrosoft</TestingExtensionsProfile>
    </PropertyGroup>    
    <!-- references to the code to test -->
</Project>
```

> [!NOTE]
> If you don't specify a custom `TestingExtensionsProfile`, the `Default` profile will be applied.

If you prefer not to use the default profile, you can set it to `None`:

```xml
<Project Sdk="MSTest.Sdk/3.3.0">
    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <TestingExtensionsProfile>None</TestingExtensionsProfile>
    </PropertyGroup>    
    <!-- references to the code to test -->
</Project>
```

You can always opt-out specific extension setting to false its respective MSBuild property.  
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

> [!WARNING]
> Please review the licensing terms for each extension as they may vary.
