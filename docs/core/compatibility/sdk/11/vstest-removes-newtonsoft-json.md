---
title: "Breaking change: VSTest removes dependency on Newtonsoft.Json"
description: "Learn about the breaking change in .NET 11 where the VSTest platform and Microsoft.NET.Test.SDK no longer depend on Newtonsoft.Json."
ms.date: 05/04/2026
ai-usage: ai-assisted
---

# VSTest removes dependency on Newtonsoft.Json

The VSTest platform and `Microsoft.NET.Test.SDK` NuGet package no longer depend on `Newtonsoft.Json`. On .NET, `System.Text.Json` is used instead. On .NET Framework, JSONite is used.

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, `Microsoft.NET.Test.SDK` brought a transitive dependency on `Newtonsoft.Json` into test projects. `Newtonsoft.Json` was available for compilation and at runtime without an explicit package reference. Projects that used `Newtonsoft.Json` types without declaring a direct dependency on the package compiled and ran successfully.

Additionally, VSTest's internal communication utilities exposed `Newtonsoft.Json` types (such as `Newtonsoft.Json.Linq.JToken`) in its public API.

## New behavior

Starting in .NET 11, `Newtonsoft.Json` is no longer a transitive dependency of `Microsoft.NET.Test.SDK`. Projects that used `Newtonsoft.Json` types without a direct package reference fail to compile. Projects that excluded `Newtonsoft.Json` runtime assets and relied on the copy shipped with VSTest now fail at runtime with:

```
FileNotFoundException: Could not load 'Newtonsoft.Json'
```

Test extensions (such as data collectors or test adapters) that depended on `Newtonsoft.Json` being provided by VSTest also fail with:

```
Data collector 'SampleDataCollector' threw an exception during type loading, construction, or initialization:
System.IO.FileNotFoundException: Could not load file or assembly 'Newtonsoft.Json,
Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'.
```

The `Newtonsoft.Json`-based types in `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities` have been removed from the public API.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

To align the VSTest platform's dependencies with the .NET SDK and the broader .NET ecosystem, `Newtonsoft.Json` was removed as a dependency. To minimize unintended side effects on the code under test, the number of assemblies that VSTest adds to the test output folder is reduced. Test projects can bring exactly the dependencies they need at the versions they require.

## Recommended action

In all cases, the fix is to add an explicit `Newtonsoft.Json` package reference to any project that uses it:

```xml
<PackageReference Include="Newtonsoft.Json" Version="..." />
```

### Test projects that fail to compile

If your test project uses `Newtonsoft.Json` types (for example, `JsonConvert`, `JToken`, or `JObject`) without a direct package reference, add a `PackageReference` to `Newtonsoft.Json` in your test project file.

### Tests that fail with FileNotFoundException at runtime

If your project has a `PackageReference` for `Newtonsoft.Json` with `<ExcludeAssets>runtime</ExcludeAssets>` and previously relied on the copy shipped with VSTest, remove the `ExcludeAssets` restriction or add a separate direct reference:

```xml
<!-- Before: excluded runtime assets, relying on VSTest to provide the DLL -->
<PackageReference Include="Newtonsoft.Json" Version="13.0.3">
  <ExcludeAssets>runtime</ExcludeAssets>
</PackageReference>

<!-- After: include runtime assets -->
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

### Test extensions that fail with FileNotFoundException

If you maintain or use a test extension (data collector or test adapter) that depended on `Newtonsoft.Json` being provided by VSTest, add `Newtonsoft.Json` as a direct dependency to the extension's project.

## Affected APIs

The following `Newtonsoft.Json`-based APIs were removed from `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities`:

- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Message.Payload` property (type `Newtonsoft.Json.Linq.JToken?`)
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.DefaultTestPlatformContractResolver`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.TestCaseConverter`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.TestObjectConverter`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.TestPlatformContractResolver<T>`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.TestResultConverter`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization.TestRunStatisticsConverter`
- `Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.VersionedMessage`
