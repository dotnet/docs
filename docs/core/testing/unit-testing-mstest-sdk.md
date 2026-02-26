---
title: MSTest SDK configuration
author: MarcoRossignoli
description: Learn how to configure MSTest.Sdk profiles, extensions, and advanced features.
ms.author: mrossignoli
ms.date: 02/13/2024
---

# MSTest SDK configuration

This article covers advanced configuration options for MSTest.Sdk. For basic setup and getting started, see [Get started with MSTest](./unit-testing-mstest-getting-started.md).

> [!IMPORTANT]
> By default, MSTest.Sdk uses the [MSTest runner with Microsoft.Testing.Platform](./unit-testing-mstest-running-tests.md), including with [dotnet test](./microsoft-testing-platform-integration-dotnet-test.md). This requires modifying your CI and local CLI calls, and also impacts the available entries of the _.runsettings_. You can keep the old integrations and tools by [switching to VSTest](#select-the-runner).
>
> MSTest.Sdk sets `EnableMSTestRunner` and `TestingPlatformDotnetTestSupport` to true by default. For more information about dotnet test and its different modes, see [Testing with dotnet test](./unit-testing-with-dotnet-test.md).

## Test utility helper libraries

If the project that uses MSTest.Sdk is intended to be a test utility helper library, and doesn't by itself contain any runnable tests, the project should have `<IsTestApplication>false</IsTestApplication>`.

## Select the runner

By default, MSTest SDK relies on [Microsoft.Testing.Platform](./unit-testing-mstest-running-tests.md), but you can switch to [VSTest](/visualstudio/test/vstest-console-options) by adding the property `<UseVSTest>true</UseVSTest>`.

## Extend Microsoft.Testing.Platform

You can customize `Microsoft.Testing.Platform` experience through a set of [NuGet package extensions](./microsoft-testing-platform-extensions.md). To simplify and improve this experience, MSTest SDK introduces two features:

- [Microsoft.Testing.Platform profile](#microsofttestingplatform-profile)
- [Enable or disable extensions](#enable-or-disable-extensions)

### Microsoft.Testing.Platform profile

The concept of *profiles* allows you to select the default set of configurations and extensions that will be applied to your test project.

You can set the profile using the property `TestingExtensionsProfile` with one of the following three profiles:

* `None` - No extensions are enabled.

* `Default` - Enables the recommended extensions for this version of MSTest.SDK. This is the default when the property isn't set explicitly.

  Enables the following extensions:

  * [Code Coverage](./microsoft-testing-platform-extensions-code-coverage.md#microsoft-code-coverage)
  * [Trx Report](./microsoft-testing-platform-extensions-test-reports.md#visual-studio-test-reports)

* `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

  Enables the following extensions:

  * [Code Coverage](./microsoft-testing-platform-extensions-code-coverage.md#microsoft-code-coverage)
  * [Crash Dump](./microsoft-testing-platform-extensions-diagnostics.md#crash-dump)
  * [Fakes](./microsoft-testing-platform-extensions-fakes.md#fakes-extension) (MSTest.Sdk 3.7.0+)
  * [Hang Dump](./microsoft-testing-platform-extensions-diagnostics.md#hang-dump)
  * [Hot Reload](./microsoft-testing-platform-extensions-hosting.md#hot-reload)
  * [Retry](./microsoft-testing-platform-extensions-policy.md#retry)
  * [Trx Report](./microsoft-testing-platform-extensions-test-reports.md#visual-studio-test-reports)
  * [AzureDevOpsReport](./microsoft-testing-platform-extensions-test-reports.md#azure-devops-reports)

Here's a full example, using the `None` profile:

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <TestingExtensionsProfile>None</TestingExtensionsProfile>
    </PropertyGroup>

</Project>
```

| Extension/Profile                                                                                 | None  |      Default       |    AllMicrosoft     |
| ------------------------------------------------------------------------------------------------- | :---: | :----------------: | :-----------------: |
| [Code Coverage](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage)         |       | :heavy_check_mark: | :heavy_check_mark:  |
| [Crash Dump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)               |       |                    | :heavy_check_mark:  |
| [Fakes](https://www.nuget.org/packages/Microsoft.Testing.Extensions.Fakes)                        |       |                    | :heavy_check_mark:¹ |
| [Hang Dump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.HangDump)                 |       |                    | :heavy_check_mark:  |
| [Hot Reload](https://www.nuget.org/packages/Microsoft.Testing.Extensions.HotReload)               |       |                    | :heavy_check_mark:  |
| [Retry](https://www.nuget.org/packages/Microsoft.Testing.Extensions.Retry)                        |       |                    | :heavy_check_mark:  |
| [Trx](https://www.nuget.org/packages/Microsoft.Testing.Extensions.TrxReport)                      |       | :heavy_check_mark: | :heavy_check_mark:  |
| [AzureDevOpsReport](./microsoft-testing-platform-extensions-test-reports.md#azure-devops-reports) |       |                    | :heavy_check_mark:²  |

¹ MSTest.Sdk 3.7.0+
² MSTest.Sdk 3.11.0+

### Enable or disable extensions

Extensions can be enabled and disabled by MSBuild properties with the pattern `Enable[NugetPackageNameWithoutDots]`.

For example, to enable the crash dump extension (NuGet package [Microsoft.Testing.Extensions.CrashDump](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CrashDump)), you can use the following property `EnableMicrosoftTestingExtensionsCrashDump` set to `true`:

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

<PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <EnableMicrosoftTestingExtensionsCrashDump>true</EnableMicrosoftTestingExtensionsCrashDump>
</PropertyGroup>

</Project>
```

For a list of all available extensions, see [Microsoft.Testing.Platform extensions](./microsoft-testing-platform-extensions.md).

> [!WARNING]
> It's important to review the licensing terms for each extension as they might vary.

Enabled and disabled extensions are combined with the extensions provided by your selected extension profile.

This property pattern can be used to enable an additional extension on top of the implicit `Default` profile (as seen in the previous CrashDumpExtension example).

You can also disable an extension that's coming from the selected profile. For example, disable the `MS Code Coverage` extension by setting `<EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>`:

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <EnableMicrosoftTestingExtensionsCodeCoverage>false</EnableMicrosoftTestingExtensionsCodeCoverage>
    </PropertyGroup>

</Project>
```

## Features

Outside of the selection of the runner and runner-specific extensions, `MSTest.Sdk` also provides additional features to simplify and enhance your testing experience.

### Test with Aspire

Aspire is an opinionated, cloud-ready stack for building observable, production ready, distributed applications. Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns. For more information, see the [Aspire docs](/dotnet/aspire/get-started/aspire-overview).

> [!NOTE]
> This feature is available from MSTest.Sdk 3.4.0.

By setting the property `EnableAspireTesting` to `true`, you can bring all dependencies and default `using` directives you need for testing with `Aspire` and `MSTest`.

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <EnableAspireTesting>true</EnableAspireTesting>
    </PropertyGroup>

</Project>
```

### Test with Playwright

Playwright enables reliable end-to-end testing for modern web apps. For more information, see the official [Playwright docs](https://playwright.dev/dotnet/docs/intro).

> [!NOTE]
> This feature is available from MSTest.Sdk 3.4.0.

By setting the property `EnablePlaywright` to `true` you can bring in all the dependencies and default `using` directives you need for testing with `Playwright` and `MSTest`.

```xml
<Project Sdk="MSTest.Sdk/4.1.0">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <EnablePlaywright>true</EnablePlaywright>
    </PropertyGroup>

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
        "MSTest.Sdk": "4.1.0"
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

Once you've updated your projects, if you're using `Microsoft.Testing.Platform` (default) and if you rely on `dotnet test` to run your tests, you must update your CI configuration. For more information and to guide your understanding of all the required changes, see [dotnet test integration](./unit-testing-with-dotnet-test.md).

If you're using the VSTest mode of `dotnet test`, here's an example update when using the `DotNetCoreCLI` task in Azure DevOps:

```diff
\- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/**.sln'
-    arguments: '--configuration Release'
+    arguments: '--configuration Release -- --report-trx --results-directory $(Agent.TempDirectory) --coverage'
```

## Known limitations

The NuGet-provided MSBuild SDKs (including MSTest.Sdk) have [limited tooling support](https://github.com/NuGet/Home/issues/13127) when it comes to updating their version, meaning that the usual NuGet update and Visual Studio UI for managing NuGet packages doesn't work as expected. You'll need to manually update the version in the `global.json` file and in the project file. (This applies even if you use Dependabot due to issues [dependabot-core#12824](https://github.com/dependabot/dependabot-core/issues/12824) and [dependabot-core#8615](https://github.com/dependabot/dependabot-core/issues/8615).)

## See also

- [Microsoft.Testing.Platform&ndash;related properties](../project-sdk/msbuild-props.md#microsofttestingplatformrelated-properties)
- [VSTest&ndash;related properties](../project-sdk/msbuild-props.md#vstestrelated-properties)
