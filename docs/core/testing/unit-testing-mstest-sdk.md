---
title: MSTest SDK overview
author: MarcoRossignoli
description: Learn about the MSTest.Sdk and how to configure profiles and extensions with MSBuild properties.
ms.author: mrossignoli
ms.date: 02/13/2024
---

# MSTest SDK overview

[MSTest.Sdk](https://www.nuget.org/packages/MSTest.Sdk) is a [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building MSTest apps.  
It's possible to build a MSTest app without this SDK, however, the MSTest SDK is:

* Tailored towards providing a first-class experience for testing with MSTest
* The recommended target for most users.
* Yet easy to configure for others.

The MSTest SDK will discover and run your tests using the [MSTest runner](./unit-testing-mstest-runner-intro.md)

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

## Selecting the runner

By default, MSTest SDK will rely on MSTest runner but you can easily switch to VSTest by adding the following property `<UseVSTest>true</UseVSTest>`.

## Extending MSTest runner

You can customize `MSTest runner` experience through a set of [NuGet package extensions](./unit-testing-platform-extensions.md). To simplify and improve this experience, MSTest SDK introduces two features.

### MSTest Runner profile

The concept of profile, allows you to select the default set of configurations and extensions that will be applied to your test project.

You can set the profile using the property `TestingExtensionsProfile` to one of the following 3 profiles:

- `Default` - Enables the recommended extensions for this version of MSTest.SDK. This is the default when the property is not set explicitly.
- `None` - No extensions are enabled.
- `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

Here is a full example, using the `None` profile:

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <TestingExtensionsProfile>None</TestingExtensionsProfile>
    </PropertyGroup>    

    <!-- references to the code to test -->

</Project>
```

### Enabling or disabling extensions

Extensions can be enabled and disabled by MSBuild properties with the pattern `Enable[NugetPackageNameWithoutDots]`.

For example, to enable the crash dump extension (NuGet package [Microsoft.Testing.Extensions.CrashDump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)), you can use the following property `EnableMicrosoftTestingExtensionsCrashDump` set to `true`:

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

<PropertyGroup> 
    <TargetFramework>net8.0</TargetFramework>
    <EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>
</PropertyGroup>

<!-- references to the code to test -->

</Project>
```

This page lists all [extensions](./unit-testing-platform-extensions.md) available.

> [!WARNING]
> Please review the licensing terms for each extension as they may vary.

You can combine the profiles with this feature. For example, you can opt-out from the `Default` profile the `MS Code Coverage` extension by setting `<EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>`. Full-example below:

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

    <PropertyGroup> 
        <TargetFramework>net8.0</TargetFramework>
        <EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>
    </PropertyGroup>    

    <!-- references to the code to test -->

</Project>
```

## Migrating to MSTest SDK

When migrating an existing MSTest test project to MSTest SDK, start by replacing the `Sdk="Microsoft.NET.Sdk"` entry at the top of your test project with `Sdk="MSTest.Sdk/3.3.1"`

`Sdk="MSTest.Sdk/3.3.1"`

```diff
- Sdk="Microsoft.NET.Sdk"
+ Sdk="MSTest.Sdk/3.3.1"
```

You can then start simplifying your project.

Removing default properties:

```diff
- <EnableMSTestRunner>true</EnableMSTestRunner> 
- <OutputType>Exe</OutputType>
- <IsPackable>false</IsPackable>
- <IsTestProject>true</IsTestProject>
```

Removing default package references:

```diff
- <PackageReference Include="MSTest"
- <PackageReference Include="MSTest.TestFramework"
- <PackageReference Include="MSTest.TestAdapter" 
- <PackageReference Include="MSTest.Analyzers" 
- <PackageReference Include="Microsoft.NET.Test.Sdk" 
```

Finally, based on the extensions profile you are using, you can also remove some of the `Microsoft.Testing.Extensions.*` packages.
