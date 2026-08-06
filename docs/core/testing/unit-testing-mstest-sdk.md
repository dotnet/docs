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

The MSTest reflection source generator replaces the assembly-wide reflection scan that finds `[TestClass]` types (`Assembly.GetTypes()`) with a compile-time class registry, and it supplies pre-built construction, invocation, and attribute data for the test methods it recognizes on those classes. It doesn't remove reflection everywhere: enumerating the methods on a discovered class (`Type.GetMethods()`) always happens at run time, in both source generation modes. Two problems motivate the generator:

- When you publish a test project with [trimming](../deploying/trimming/trimming-options.md) or [Native AOT](../deploying/native-aot/index.md), the trimmer can't prove which types and members MSTest's own reflection calls will touch at run time, so it can remove them. MSTest's reflection call sites are already annotated to suppress the resulting build warnings, but that suppression doesn't stop the trimmer from removing the members. Without the generator, a trimmed or Native AOT test binary can discover zero tests or throw `MissingMethodException`, even though the build itself is clean.
- Reflecting over an assembly's types (`Assembly.GetTypes()`) at startup costs time on every run, trimmed or not. Replacing that scan with a compile-time class registry reduces startup discovery cost, most noticeably for large test suites. Per-class method enumeration (`Type.GetMethods()`) still happens at run time for every discovered class; the generator doesn't change that cost.

Enable the generator by adding a reference to the [MSTest.SourceGeneration](https://www.nuget.org/packages/MSTest.SourceGeneration) package. Only prerelease versions are published today:

```dotnetcli
dotnet add package MSTest.SourceGeneration --prerelease
```

Your test code doesn't change. The generator emits a module initializer that adds your `[TestClass]` types to a compile-time class registry, replacing the assembly-wide reflection scan the adapter would otherwise perform to find test classes. For each `[TestMethod]` whose shape the generator recognizes (see [Supported test shapes](#supported-test-shapes)), it also emits pre-built attribute data and constructor/invocation delegates, which the adapter uses once it locates that method. Locating the methods on a class still happens through `Type.GetMethods()`, regardless of source generation mode.

#### Choose a source generation mode

The `MSTestSourceGenMode` MSBuild property selects what the generator emits for the classes it discovers and the recognized methods on them:

- `ReflectionFree` (the default): for a recognized method, the generator emits pre-built attribute data plus constructor, method, and property-setter delegates. Once the adapter locates that method (still through `Type.GetMethods()`), it uses the generated delegates instead of reflecting further to construct the instance, invoke the method, or read its attributes.
- `Rooting`: emits the class and recognized-method registries plus `[DynamicDependency(All, typeof(T))]` for each discovered class and its accessible base types. This keeps the trimmer from removing those members, but construction, invocation, and attribute reads all go through runtime reflection, for every method.

```xml
<PropertyGroup>
    <MSTestSourceGenMode>Rooting</MSTestSourceGenMode>
</PropertyGroup>
```

Neither mode makes method discovery itself reflection-free: enumerating the methods on a class always uses `Type.GetMethods()`. Both modes also still fall back to runtime reflection for operations the generator doesn't model at all, such as enumerating every constructor or property on a type, or resolving a type by name across assemblies.

#### Supported test shapes

With the generator active, it discovers and models:

- Ordinary `[TestClass]` types with `[TestMethod]`s, as long as `[TestClass]` is declared directly on the type.
- `[DataRow]` arguments, bound through the same generated invoker that calls the test method.
- `[DynamicData]` sources. The generator still evaluates the referenced member at run time, but generated code constructs and invokes the test with the resulting values.
- Base-class test fixtures, as long as `[TestClass]` is on the concrete (most derived) type. The generator still finds inherited test methods and shared `[ClassInitialize]`/`[TestContext]` members from accessible base types. The base class doesn't need its own registry entry — including when it's abstract — because its members become part of the concrete derived class's generated data.

#### Unsupported test shapes

Two different limitations apply, with different consequences for whether a test still runs.

**Classes the registry omits.** The generator can't add the following class shapes to its compile-time class registry, so they're invisible to it. In an assembly where the generator did register at least one other class, these classes aren't reflectively rediscovered as a fallback — their tests don't run:

| Shape | Why it's omitted | Workaround |
|-------|-------------------|------------|
| A class relies on a `[TestClass]` attribute inherited from a base class | Discovery doesn't follow inheritance | Apply `[TestClass]` directly to the derived class. Flagged by [MSTEST0069](mstest-analyzers/mstest0069.md) |
| Open generic test class (`class Foo<T>`) | An open generic type can't be referenced at the point where the generator registers types | Make the class non-generic, or instantiate a concrete derived class |
| `file`-local test class | The generated registration code lives in a different file and can't reference a file-local type | Move the class out of file scope |
| Private or protected nested test class | The generated registration code can't reference a type that's not visible outside its container | Make the test class, and every type that contains it, at least `internal` |
| Static test class | The generator models instance-based test execution | Remove the `static` modifier |

Only the first row has a shipping diagnostic today ([MSTEST0069](mstest-analyzers/mstest0069.md)). The generator's design defines dedicated diagnostics for the other rows, but those diagnostics aren't included in the publicly published `MSTest.SourceGeneration` package as of this writing.

**Methods the generator doesn't model.** These method shapes don't get generated attribute data or an invocation delegate, but they still run: enumerating the methods on a class always uses runtime reflection, so a method with one of these shapes is still found and still executes through reflection, the same as it would without the generator active, as long as its containing class is otherwise in the registry.

| Shape | Why it isn't modeled |
|-------|-----------------------|
| Generic test method | Its type arguments aren't known at compile time |
| Test method with a `ref`, `out`, or `in` parameter | The generated invoker's arguments are `object?[]`, which can't represent a by-ref parameter |

#### Rooting compared with discovery

Two different questions matter for a trimmed or Native AOT test project, and it helps to keep them separate:

- **Discovery** is whether the generator's compile-time class registry knows about a class at all. The class shapes in the first table above are invisible to the registry regardless of how you configure trimming. Method-level gaps don't affect discovery: reflection always enumerates a class's methods, so a generic method or a method with a by-ref parameter is found whether or not the generator modeled it.
- **Rooting** is whether the trimmer keeps a class's IL, and its members', in the published output. The registry roots every class it discovers: `ReflectionFree` mode through direct code references to the generated delegates, and `Rooting` mode through `[DynamicDependency(All, typeof(T))]`.

Because rooting only applies to classes the generator discovers, a class that's omitted from the registry isn't rooted either, and its tests silently don't run in a trimmed or Native AOT publish once your assembly also has other source-generated test classes. Adding `<TrimmerRootAssembly Include="$(AssemblyName)" />` (see [Prepare .NET libraries for trimming](../deploying/trimming/prepare-libraries-for-trimming.md)) keeps the trimmer from removing that assembly's members, but it doesn't add the class back to the generator's discovery registry — the adapter still doesn't consider it to exist in that assembly. For a genuinely omitted class, the fix is to change its shape, not to add a trimmer root. Unsupported method shapes don't need this workaround at all: their containing class is rooted normally, and because method enumeration is always reflective, those methods keep working without any additional trimming configuration.

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
