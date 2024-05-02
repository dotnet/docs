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
* Easy to configure for other users.

The MSTest SDK discovers and runs your tests using the [MSTest runner](./unit-testing-mstest-runner-intro.md).

You can enable `MSTest.Sdk` in a project by simply updating the `Sdk` attribute of the `Project` node of your project:

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

To simplify handling of versions we recommend setting the SDK version at solution level using the _global.json_. For example, your project file would look like:

```xml
<Project Sdk="MSTest.Sdk">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

Then, you would have a _global.json_ file that specifies the `MSTest.Sdk` version as follows:

```json
{
    "msbuild-sdks": {
        "MSTest.Sdk": "3.3.1"
    }
}
```

For more information, see [Use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved).

When you `build` the project, all the needed components are restored and installed using the standard NuGet workflow set by your project.

You don't need anything else to build and run your tests and you can use the same tooling (for example, `dotnet test` or Visual Studio) used by a ["classic" MSTest project](./unit-testing-with-mstest.md).

## Select the runner

By default, MSTest SDK relies on [MSTest runner](./unit-testing-mstest-runner-intro.md), but you can easily switch to [VSTest](/visualstudio/test/vstest-console-options.md) by adding the property `<UseVSTest>true</UseVSTest>`.

## Extend MSTest runner

You can customize `MSTest runner` experience through a set of [NuGet package extensions](./unit-testing-platform-extensions.md). To simplify and improve this experience, MSTest SDK introduces two features.

### MSTest Runner profile

The concept of *profiles* allows you to select the default set of configurations and extensions that will be applied to your test project.

You can set the profile using the property `TestingExtensionsProfile` with one of the following three profiles:

* `Default` - Enables the recommended extensions for this version of MSTest.SDK. This is the default when the property isn't set explicitly.
* `None` - No extensions are enabled.
* `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

Here's a full example, using the `None` profile:

```xml
<Project Sdk="MSTest.Sdk/3.3.1">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <TestingExtensionsProfile>None</TestingExtensionsProfile>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

### Enable or disable extensions

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

Enabled and disabled extensions are combined with the extensions provided by your selected extension profile.

This can be used to enable an additional extension on top of the implicit `Default` profile (as seen in the previous CrashDumpExtension example).

Or to disable an extension that is coming from the selected profile. In this case disabling `MS Code Coverage` extension by setting `<EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>`:

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
+ Sdk="MSTest.Sdk"
```

Add the version to your `global.json`:

```json
{
    "msbuild-sdks": {
        "MSTest.Sdk": "3.3.1"
    }
}
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

Finally, based on the extensions profile you're using, you can also remove some of the `Microsoft.Testing.Extensions.*` packages.
