---
title: MSTest SDK overview
author: MarcoRossignoli
description: Learn about the MSTest.Sdk and how to configure profiles and extensions with MSBuild properties.
ms.author: mrossignoli
ms.date: 02/13/2024
---

# MSTest SDK overview

[MSTest.Sdk](https://www.nuget.org/packages/MSTest.Sdk) is a [MSBuild project SDK](/visualstudio/msbuild/how-to-use-project-sdk) for building MSTest apps. It's possible to build a MSTest app without this SDK, however, the MSTest SDK is:

* Tailored towards providing a first-class experience for testing with MSTest.
* The recommended target for most users.
* Easy to configure for other users.

The MSTest SDK discovers and runs your tests using the [MSTest runner](./unit-testing-mstest-runner-intro.md).

You can enable `MSTest.Sdk` in a project by simply updating the `Sdk` attribute of the `Project` node of your project:

```xml
<Project Sdk="MSTest.Sdk/3.6.3">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

> [!NOTE]
> `/3.6.3` is given as example and can be replaced with any newer version.

To simplify handling of versions, we recommend setting the SDK version at solution level using the _global.json_ file. For example, your project file would look like:

```xml
<Project Sdk="MSTest.Sdk">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

Then, specify the `MSTest.Sdk` version in the _global.json_ file as follows:

```json
{
    "msbuild-sdks": {
        "MSTest.Sdk": "3.6.3"
    }
}
```

For more information, see [Use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved).

When you `build` the project, all the needed components are restored and installed using the standard NuGet workflow set by your project.

You don't need anything else to build and run your tests and you can use the same tooling (for example, `dotnet test` or Visual Studio) used by a ["classic" MSTest project](./unit-testing-with-mstest.md).

> [!IMPORTANT]
> By switching to the `MSTest.Sdk`, you opt in to using the [MSTest runner](./unit-testing-mstest-runner-intro.md), including with [dotnet test](./unit-testing-platform-integration-dotnet-test.md#dotnet-test---microsofttestingplatform-mode). That requires modifying your CI and local CLI calls, and also impacts the available entries of the _.runsettings_. You can use `MSTest.Sdk` and still keep the old integrations and tools by instead switching the [runner](#select-the-runner).

## Select the runner

By default, MSTest SDK relies on [Microsoft.Testing.Platform](./unit-testing-mstest-runner-intro.md), but you can switch to [VSTest](/visualstudio/test/vstest-console-options) by adding the property `<UseVSTest>true</UseVSTest>`.

## Extend Microsoft.Testing.Platform

You can customize Microsoft.Testing.Platform experience through a set of [NuGet package extensions](./unit-testing-platform-extensions.md). To simplify and improve this experience, MSTest SDK introduces two features:

- [Microsoft.Testing.Platform profile](#microsoft-testing-platform-profile)
- [Enable or disable extensions](#enable-or-disable-extensions)

### [Microsoft.Testing.Platform profile](#microsoft-testing-platform-profile)

The concept of *profiles* allows you to select the default set of configurations and extensions that will be applied to your test project.

You can set the profile using the property `TestingExtensionsProfile` with one of the following three profiles:

* `None` - No extensions are enabled.

* `Default` - Enables the recommended extensions for this version of MSTest.SDK. This is the default when the property isn't set explicitly.

  Enables the following extensions:

  * [Code Coverage](./unit-testing-platform-extensions-code-coverage.md#microsoft-code-coverage)

  * [Trx Report](./unit-testing-platform-extensions-test-reports.md#visual-studio-test-reports)
  
* `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

  Enables the following extensions:

  * [Code Coverage](./unit-testing-platform-extensions-code-coverage.md#microsoft-code-coverage)

  * [Crash Dump](./unit-testing-platform-extensions-diagnostics.md#crash-dump)

  * [Fakes](./unit-testing-platform-extensions-fakes.md#fakes-extension) (MSTest.Sdk 3.7.0+)

  * [Hang Dump](./unit-testing-platform-extensions-diagnostics.md#hang-dump)

  * [Hot Reload](./unit-testing-platform-extensions-hosting.md#hot-reload)

  * [Retry](./unit-testing-platform-extensions-policy.md#retry)
  
  * [Trx Report](./unit-testing-platform-extensions-test-reports.md#visual-studio-test-reports)

Here's a full example, using the `None` profile:

```xml
<Project Sdk="MSTest.Sdk/3.6.3">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <TestingExtensionsProfile>None</TestingExtensionsProfile>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

| Extension/Profile                                                                         | None | Default            | AllMicrosoft                           |
|-------------------------------------------------------------------------------------------|:----:|:------------------:|:--------------------------------------:|
| [Code Coverage](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) |      | :heavy_check_mark: | :heavy_check_mark:                     |
| [Crash Dump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)       |      |                    | :heavy_check_mark:                     |
| [Fakes](https://www.nuget.org/packages/Microsoft.Testing.Extensions.Fakes)                |      |                    | :heavy_check_mark: (MSTest.Sdk 3.7.0+) |
| [Hang Dump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.HangDump)         |      |                    | :heavy_check_mark:                     |
| [Hot Reload](https://www.nuget.org/packages/Microsoft.Testing.Extensions.HotReload)       |      |                    | :heavy_check_mark:                     |
| [Retry](https://www.nuget.org/packages/Microsoft.Testing.Extensions.Retry)                |      |                    | :heavy_check_mark:                     |
| [Trx](https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport)              |      | :heavy_check_mark: | :heavy_check_mark:                     |

### Enable or disable extensions

Extensions can be enabled and disabled by MSBuild properties with the pattern `Enable[NugetPackageNameWithoutDots]`.

For example, to enable the crash dump extension (NuGet package [Microsoft.Testing.Extensions.CrashDump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)), you can use the following property `EnableMicrosoftTestingExtensionsCrashDump` set to `true`:

```xml
<Project Sdk="MSTest.Sdk/3.6.3">

<PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>
</PropertyGroup>

<!-- references to the code to test -->

</Project>
```

For a list of all available extensions, see [Microsoft.Testing.Platform extensions](./unit-testing-platform-extensions.md).

> [!WARNING]
> It's important to review the licensing terms for each extension as they might vary.

Enabled and disabled extensions are combined with the extensions provided by your selected extension profile.

This property pattern can be used to enable an additional extension on top of the implicit `Default` profile (as seen in the previous CrashDumpExtension example).

You can also disable an extension that's coming from the selected profile. For example, disable the `MS Code Coverage` extension by setting `<EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>`:

```xml
<Project Sdk="MSTest.Sdk/3.6.3">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

## Features

Outside of the selection of the runner and runner-specific extensions, `MSTest.Sdk` also provides additional features to simplify and enhance your testing experience.

### Test with .NET Aspire

.NET Aspire is an opinionated, cloud-ready stack for building observable, production ready, distributed applications. .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns. For more information, see the [.NET Aspire docs](/dotnet/aspire/get-started/aspire-overview).

> [!NOTE]
> This feature is available from MSTest.Sdk 3.4.0

By setting the property `EnableAspireTesting` to `true`, you can bring all dependencies and default `using` directives you need for testing with `Aspire` and `MSTest`.

```xml
<Project Sdk="MSTest.Sdk/3.4.0">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <EnableAspireTesting>true</EnableAspireTesting>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

### Test with Playwright

Playwright enables reliable end-to-end testing for modern web apps. For more information, see the official [Playwright docs](https://playwright.dev/dotnet/docs/intro).

> [!NOTE]
> This feature is available from MSTest.Sdk 3.4.0

By setting the property `EnablePlaywright` to `true` you can bring in all the dependencies and default `using` directives you need for testing with `Playwright` and `MSTest`.

```xml
<Project Sdk="MSTest.Sdk/3.4.0">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <EnablePlaywright>true</EnablePlaywright>
    </PropertyGroup>

    <!-- references to the code to test -->

</Project>
```

## Migrate to MSTest SDK

Consider the following steps that are required to migrate to the MSTest SDK.

### Update your project

When migrating an existing MSTest test project to MSTest SDK, start by replacing the `Sdk="Microsoft.NET.Sdk"` entry at the top of your test project with `Sdk="MSTest.Sdk"`

```diff
- Sdk="Microsoft.NET.Sdk"
+ Sdk="MSTest.Sdk"
```

Add the version to your `global.json`:

```json
{
    "msbuild-sdks": {
        "MSTest.Sdk": "3.6.3"
    }
}
```

You can then start simplifying your project.

Remove default properties:

```diff
- <EnableMSTestRunner>true</EnableMSTestRunner>
- <OutputType>Exe</OutputType>
- <IsPackable>false</IsPackable>
- <IsTestProject>true</IsTestProject>
```

Remove default package references:

```diff
- <PackageReference Include="MSTest"
- <PackageReference Include="MSTest.TestFramework"
- <PackageReference Include="MSTest.TestAdapter"
- <PackageReference Include="MSTest.Analyzers"
- <PackageReference Include="Microsoft.NET.Test.Sdk"
```

Finally, based on the extensions profile you're using, you can also remove some of the `Microsoft.Testing.Extensions.*` packages.

### Update your CI

Once you've updated your projects, if you're using `Microsoft.Testing.Platform` (default) and if you rely on `dotnet test` to run your tests, you must update your CI configuration. For more information and to guide your understanding of all the required changes, see [dotnet test integration](./unit-testing-platform-integration-dotnet-test.md#dotnet-test---microsofttestingplatform-mode).

Here's an example update when using the `DotNetCoreCLI` task in Azure DevOps:

```diff
\- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/**.sln'
-    arguments: '--configuration Release'
+    arguments: '--configuration Release -p:TestingPlatformCommandLineArguments="--report-trx --results-directory $(Agent.TempDirectory) --coverage"'
```

## Known limitations

The NuGet-provided MSBuild SDKs (including MSTest.Sdk) have limited tooling support when it comes to updating its version, meaning that the usual NuGet update and Visual Studio UI for managing NuGet packages does not work as expected. See this issue for more details: [NuGet#13127](https://github.com/NuGet/Home/issues/13127).

> [!NOTE]
> This limitation is not specific to MSTest SDK but to any NuGet-provided MSBuild SDK.
> Dependabot will handle updating the version in the `global.json` file, but you will need to [manually update the version in the project file](https://github.com/dependabot/dependabot-core/issues/8615).

## See also

- [Test project&ndash;related properties](../project-sdk/msbuild-props.md#test-projectrelated-properties)
