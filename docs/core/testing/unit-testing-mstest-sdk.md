---
title: MSTest SDK configuration
author: MarcoRossignoli
description: Learn how to configure MSTest.Sdk profiles, extensions, and advanced features.
ms.author: mrossignoli
ms.date: 08/06/2026
ai-usage: ai-assisted
---

# MSTest SDK configuration

This article covers advanced configuration options for MSTest.Sdk. For basic setup and getting started, see [Get started with MSTest](./unit-testing-mstest-getting-started.md).

> [!IMPORTANT]
> By default, MSTest.Sdk uses the [MSTest runner with MTP](./unit-testing-mstest-running-tests.md), including with [dotnet test](./unit-testing-with-dotnet-test.md). This requires modifying your CI and local CLI calls, and also impacts the available entries of the _.runsettings_. You can keep the old integrations and tools by [switching to VSTest](#select-the-runner).
>
> MSTest.Sdk sets `EnableMSTestRunner` and `TestingPlatformDotnetTestSupport` to true by default. For more information about dotnet test and its different modes, see [Testing with dotnet test](./unit-testing-with-dotnet-test.md).

## Test utility helper libraries

If the project that uses MSTest.Sdk is intended to be a test utility helper library, and doesn't by itself contain any runnable tests, the project should have `<IsTestApplication>false</IsTestApplication>`.

## Select the runner

By default, MSTest SDK relies on [MTP](./unit-testing-mstest-running-tests.md), but you can switch to [VSTest](/visualstudio/test/vstest-console-options) by adding the property `<UseVSTest>true</UseVSTest>`.

## Extend MTP

You can customize the MTP experience through a set of [NuGet package extensions](./microsoft-testing-platform-features.md). To simplify and improve this experience, MSTest SDK introduces two features:

- [Microsoft.Testing.Platform profile](#microsofttestingplatform-profile)
- [Enable or disable extensions](#enable-or-disable-extensions)

### Microsoft.Testing.Platform profile

The concept of *profiles* allows you to select the default set of configurations and extensions that will be applied to your test project.

You can set the profile using the property `TestingExtensionsProfile` with one of the following three profiles:

* `None` - No extensions are enabled.

* `Default` - Enables the recommended extensions for this version of MSTest.SDK. This is the default when the property isn't set explicitly.

  Enables the following extensions:

  * [Code Coverage](./microsoft-testing-platform-code-coverage.md#microsoft-code-coverage)
  * [Trx Report](./microsoft-testing-platform-test-reports.md#visual-studio-test-reports-trx)

* `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

  Enables the following extensions:

  * [Code Coverage](./microsoft-testing-platform-code-coverage.md#microsoft-code-coverage)
  * [Crash Dump](./microsoft-testing-platform-crash-hang-dumps.md#crash-dump)
  * [Fakes](./microsoft-testing-platform-fakes.md) (MSTest.Sdk 3.7.0+)
  * [Hang Dump](./microsoft-testing-platform-crash-hang-dumps.md#hang-dump)
  * [Hot Reload](./microsoft-testing-platform-hot-reload.md#hot-reload)
  * [Retry](./microsoft-testing-platform-retry.md#retry)
  * [Trx Report](./microsoft-testing-platform-test-reports.md#visual-studio-test-reports-trx)
  * [AzureDevOpsReport](./microsoft-testing-platform-test-reports.md#azure-devops-reports)

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
| [AzureDevOpsReport](./microsoft-testing-platform-test-reports.md#azure-devops-reports) |       |                    | :heavy_check_mark:²  |

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

For a list of all available extensions, see [MTP features](./microsoft-testing-platform-features.md).

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

Aspire is an opinionated, cloud-ready stack for building observable, production ready, distributed applications. Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns. For more information, see the [Aspire docs](https://aspire.dev/get-started/what-is-aspire/).

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

Once you've updated your projects, if you're using MTP (default) and if you rely on `dotnet test` to run your tests, you must update your CI configuration. For more information and to guide your understanding of all the required changes, see [dotnet test integration](./unit-testing-with-dotnet-test.md).

If you're using the VSTest mode of `dotnet test`, here's an example update when using the `DotNetCoreCLI` task in Azure DevOps:

```diff
\- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: '**/**.sln'
-    arguments: '--configuration Release'
+    arguments: '--configuration Release -- --report-trx --results-directory $(Agent.TempDirectory) --coverage'
```

## Experimental features

The following MSTest 4.3 features are **experimental**. Their public APIs are subject to change, and they're surfaced behind experimental diagnostics, so opting in requires acknowledging the corresponding diagnostic ID. Use them with that caveat in mind.

### Reflection source generator

> [!NOTE]
> Introduced in MSTest 4.3.0 (experimental).

The MSTest reflection source generator moves test discovery, construction, and invocation from runtime reflection to compile time. Two problems motivate it:

- When you publish a test project with [trimming](../deploying/trimming/trimming-options.md) or [Native AOT](../deploying/native-aot/index.md), the trimmer can't prove which types and methods MSTest's own reflection calls will touch at run time, so it can remove them. MSTest's reflection call sites are already annotated to suppress the resulting build warnings, but that suppression doesn't stop the trimmer from removing the members. Without the generator, a trimmed or Native AOT test binary can discover zero tests or throw `MissingMethodException`, even though the build itself is clean.
- Reflecting over an assembly's types and methods at startup (`Assembly.GetTypes()`, then per-class `Type.GetMethods()`) costs time on every run, trimmed or not. Replacing that scan with a compile-time registry reduces startup cost, most noticeably for large test suites.

Enable the generator by adding a reference to the [MSTest.SourceGeneration](https://www.nuget.org/packages/MSTest.SourceGeneration) package. Only prerelease versions are published today, so reference an explicit prerelease version:

```xml
<ItemGroup>
    <PackageReference Include="MSTest.SourceGeneration" Version="2.0.0-alpha.*" />
</ItemGroup>
```

Your test code doesn't change. The generator emits a module initializer that registers your `[TestClass]` types and their `[TestMethod]`s with the adapter before it would otherwise scan the assembly.

#### Choose a source generation mode

The `MSTestSourceGenMode` MSBuild property selects what the generator emits for classes and methods it discovers:

- `ReflectionFree` (the default): emits pre-built attribute arrays plus constructor, method, and property-setter delegates, so the adapter constructs tests, invokes them, and reads their attributes without runtime reflection.
- `Rooting`: emits only the type and method registry plus `[DynamicDependency(All, typeof(T))]` for each discovered class and its accessible base types. This keeps the trimmer from removing those members, but the adapter still constructs tests, invokes them, and reads their attributes through runtime reflection.

```xml
<PropertyGroup>
    <MSTestSourceGenMode>Rooting</MSTestSourceGenMode>
</PropertyGroup>
```

Both modes still fall back to runtime reflection for operations the generator doesn't model, such as enumerating every constructor or property on a type, or resolving a type by name across assemblies.

#### Supported test shapes

With the generator active, it discovers and models:

- Ordinary `[TestClass]` types with `[TestMethod]`s, as long as `[TestClass]` is declared directly on the type.
- `[DataRow]` arguments, bound through the same generated invoker that calls the test method.
- `[DynamicData]` sources. The generator still evaluates the referenced member at run time, but generated code constructs and invokes the test with the resulting values.
- Base-class test fixtures, as long as `[TestClass]` is on the concrete (most derived) type. The generator still finds inherited test methods and shared `[ClassInitialize]`/`[TestContext]` members from accessible base types.

#### Unsupported test shapes

The generator silently skips the following shapes. Tests with these shapes keep working when the generator isn't active, because runtime reflection finds them, but they're invisible to the generator's registry:

| Shape | Why it's skipped | Workaround |
|-------|-------------------|------------|
| A class relies on a `[TestClass]` attribute inherited from a base class | Discovery doesn't follow inheritance | Apply `[TestClass]` directly to the derived class. Flagged by [MSTEST0069](mstest-analyzers/mstest0069.md) |
| Open generic test class (`class Foo<T>`) | An open generic type can't be referenced at the point where the generator registers types | Make the class non-generic, or instantiate a concrete derived class |
| Generic test method | A generic method's type arguments aren't known at compile time | Replace it with one or more non-generic methods |
| Test method with a `ref`, `out`, or `in` parameter | The generated invoker passes arguments as `object?[]`, which can't represent a by-ref parameter | Use a wrapper type or a non-by-ref signature |
| `file`-local test class | The generated registration code lives in a different file and can't reference a file-local type | Move the class out of file scope |
| Private or protected nested test class | The generated registration code can't reference a type that's not visible outside its container | Make the test class, and every type that contains it, at least `internal` |
| Static test class | The generator models instance-based test execution | Remove the `static` modifier |
| Abstract test class | An abstract class can't be instantiated directly | Add a concrete derived class annotated with `[TestClass]`; the abstract class's members stay rooted through that derived class |

Only the first row has a shipping diagnostic ([MSTEST0069](mstest-analyzers/mstest0069.md)) today. The generator's design defines dedicated diagnostics for the other shapes, but as of this writing those diagnostics aren't included in the publicly published `MSTest.SourceGeneration` package, so don't expect to see them yet.

#### Rooting compared with discovery

Two different questions matter for a trimmed or Native AOT test project, and it helps to keep them separate:

- **Discovery** is whether the generator's compile-time registry knows about a class or method at all. A shape from the previous table is invisible to the registry regardless of how you configure trimming.
- **Rooting** is whether the trimmer keeps a class or method's IL in the published output. The registry roots every class and method it discovers: `ReflectionFree` mode through direct code references, and `Rooting` mode through `[DynamicDependency(All, typeof(T))]`.

Because rooting only applies to what the generator discovers, an unsupported shape isn't rooted either, and its tests silently don't run once your assembly also has other source-generated test classes. Adding `<TrimmerRootAssembly Include="$(AssemblyName)" />` (see [Prepare .NET libraries for trimming](../deploying/trimming/prepare-libraries-for-trimming.md)) keeps the trimmer from removing that assembly's members, but it doesn't add a class back to the generator's discovery registry. For a genuinely unsupported shape, the fix is to change the shape, not to add a trimmer root.

For more information about the generator's design and current limitations, see the [source generator design document](https://github.com/microsoft/testfx/blob/main/docs/source-generator/design.md) in the testfx repository.

### Programmatic test filtering with `ITestFilter`

> [!NOTE]
> Introduced in MSTest 4.3.0 (experimental).

The experimental `ITestFilter` extension point, registered through `[TestFilterProviderAttribute]`, lets you decide programmatically whether each test runs, before any test class is loaded. This is useful for custom selection logic that can't be expressed with command-line filters.

### `TestRun.Current` and planned tests

> [!NOTE]
> Introduced in MSTest 4.3.0 (experimental).

The experimental `TestRun.Current` API (from RFC 014) exposes information about the current run, including the set of planned tests, so extensions and fixtures can inspect what's scheduled to execute.

## Known limitations

The NuGet-provided MSBuild SDKs (including MSTest.Sdk) have [limited tooling support](https://github.com/NuGet/Home/issues/13127) when it comes to updating their version, meaning that the usual NuGet update and Visual Studio UI for managing NuGet packages doesn't work as expected. You'll need to manually update the version in the `global.json` file and in the project file. (This applies even if you use Dependabot due to issues [dependabot-core#12824](https://github.com/dependabot/dependabot-core/issues/12824) and [dependabot-core#8615](https://github.com/dependabot/dependabot-core/issues/8615).)

## See also

- [MTP&ndash;related properties](../project-sdk/msbuild-props.md#microsofttestingplatformrelated-properties)
- [VSTest&ndash;related properties](../project-sdk/msbuild-props.md#vstestrelated-properties)
