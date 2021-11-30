---
title: Trimming options
description: Learn how to control trimming of self-contained apps.
author: sbomer
ms.author: svbomer
ms.date: 08/25/2020
ms.topic: reference
---
# Trimming options

The following MSBuild properties and items influence the behavior of [trimmed self-contained deployments](trim-self-contained.md). Some of the options mention `ILLink`, which is the name of the underlying tool that implements trimming. For more information about the underlying tool, see the [Trimmer documentation](https://github.com/dotnet/linker/tree/main/docs).

Trimming with `PublishTrimmed` was introduced in .NET Core 3.0. The other options are available only in .NET 5 and above.

## Enable trimming

- `<PublishTrimmed>true</PublishTrimmed>`

   Enable trimming during publish. This also turns off trim-incompatible features and enables [trim analysis](#roslyn-analyzer) during build.

Place this setting in the project file to ensure that the setting applies during `dotnet build`, not just `dotnet publish`.

This setting trims any assemblies that have been configured for trimming. With `Microsoft.NET.Sdk` in .NET 6, this includes any assemblies with `[AssemblyMetadata("IsTrimmable", "True")]`, which is the case for framework assemblies. In .NET 5, framework assemblies from the netcoreapp runtime pack are configured for trimming via `<IsTrimmable>` MSBuild metadata. Other SDKs may define different defaults.

Starting in .NET 6, this setting also enables the trim-compatibility [Roslyn analyzer](#roslyn-analyzer) and disables [features that are incompatible with trimming](#framework-features-disabled-when-trimming).

## Trimming granularity

The following granularity settings control how aggressively unused IL is discarded. This can be set as a property affecting all trimmer input assemblies, or as metadata on an [individual assembly](#trimmed-assemblies), which overrides the property setting.

- `<TrimMode>link</TrimMode>`

    Enable member-level trimming, which removes unused members from types. This is the default in .NET 6+.

- `<TrimMode>copyused</TrimMode>`

   Enable assembly-level trimming, which will keep an entire assembly if any part of it is used (in a statically understood way).

Assemblies with `<IsTrimmable>true</IsTrimmable>` metadata but no explicit `TrimMode` will use the global `TrimMode`. The default `TrimMode` for `Microsoft.NET.Sdk` is `link` in .NET 6+, and `copyused` in previous versions.

## Trim additional assemblies

In .NET 6+, `PublishTrimmed` trims assemblies with the following assembly-level attribute:

```csharp
[AssemblyMetadata("IsTrimmable", "True")]
```

The framework libraries have this attribute. In .NET 6+, you can also opt in to trimming for a library without this attribute, specifying the assembly by name (without the `.dll` extension).

```xml
<ItemGroup>
  <TrimmableAssembly Include="MyAssembly" />
</ItemGroup>
```

This is equivalent to setting MSBuild metadata `<IsTrimmable>true</IsTrimmable>` for the assembly in `ManagedAssemblyToLink` (see below).

## Trimmed assemblies

When publishing a trimmed app, the SDK computes an `ItemGroup` called `ManagedAssemblyToLink` that represents the set of files to be processed for trimming. `ManagedAssemblyToLink` may have metadata that controls the trimming behavior per assembly. To set this metadata, create a target that runs before the built-in `PrepareForILLink` target. The following example shows how to enable trimming of `MyAssembly`.

```xml
<Target Name="ConfigureTrimming"
        BeforeTargets="PrepareForILLink">
  <ItemGroup>
    <ManagedAssemblyToLink Condition="'%(Filename)' == 'MyAssembly'">
      <IsTrimmable>true</IsTrimmable>
    </ManagedAssemblyToLink>
  </ItemGroup>
</Target>
```

You can also use this to override the trimming behavior specified by the library author, by setting `<IsTrimmable>false</IsTrimmable>` for an assembly with `[AssemblyMetadata("IsTrimmable", "True"])`.

Do not add or remove items to/from `ManagedAssemblyToLink`, because the SDK computes this set during publish and expects it not to change. The supported metadata is:

- `<IsTrimmable>true</IsTrimmable>`

  Control whether the given assembly is trimmed.

- `<TrimMode>copyused</TrimMode>` or `<TrimMode>link</TrimMode>`

  Control the [trimming granularity](#trimming-granularity) of this assembly. This takes precedence over the global `TrimMode`. Setting `TrimMode` on an assembly implies `<IsTrimmable>true</IsTrimmable>`.

- `<TrimmerSingleWarn>True</TrimmerSingleWarn>` or `<TrimmerSingleWarn>False</TrimmerSingleWarn>`

  Control whether to show [single warnings](#show-detailed-warnings) for this assembly.

## Root assemblies

All assemblies that do not have `<IsTrimmable>true</IsTrimmable>` are considered roots for the analysis, which means that they and all of their statically understood dependencies will be kept. Additional assemblies may be "rooted" by name (without the `.dll` extension):

```xml
<ItemGroup>
  <TrimmerRootAssembly Include="MyAssembly" />
</ItemGroup>
```

## Root descriptors

Another way to specify roots for analysis is using an XML file that uses the trimmer [descriptor format](https://github.com/dotnet/linker/blob/main/docs/data-formats.md#descriptor-format). This lets you root specific members instead of a whole assembly.

```xml
<ItemGroup>
  <TrimmerRootDescriptor Include="MyRoots.xml" />
</ItemGroup>
```

For example, `MyRoots.xml` might root a specific method that is dynamically accessed by the application:

```xml
<linker>
  <assembly fullname="MyAssembly">
    <type fullname="MyAssembly.MyClass">
      <method name="DynamicallyAccessedMethod" />
    </type>
  </assembly>
</linker>
```

## Analysis warnings

Trimming will remove IL that is not statically reachable. Apps that use reflection or other patterns that create dynamic dependencies may be broken by trimming. To warn about such patterns:

- `<SuppressTrimAnalysisWarnings>false</SuppressTrimAnalysisWarnings>`

    Enable trim analysis warnings.

This will include warnings about the entire app, including your own code, library code, and framework code.

## Roslyn analyzer

Setting `PublishTrimmed` in .NET 6+ will also enable a Roslyn analyzer that shows a _limited_ set of analysis warnings. The analyzer may also be enabled or disabled independently of `PublishTrimmed`.

- `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>`

    Enable a Roslyn analyzer for a subset of trim analysis warnings.

## Warning versions

Trim analysis respects the [`AnalysisLevel`](../../project-sdk/msbuild-props.md#analysislevel) property that controls the version of analysis warnings across the SDK. There is another property that controls the version of trim analysis warnings independently (similar to `WarningLevel` for the compiler):

- `<ILLinkWarningLevel>5</ILLinkWarningLevel>`

    Emit only warnings of the given level or lower. This can be `9999` to include all warning versions.

## Suppressing warnings

Individual [warning codes](https://github.com/dotnet/linker/blob/main/docs/error-codes.md#warning-codes) can be suppressed using the usual MSBuild properties respected by the toolchain, including `NoWarn`, `WarningsAsErrors`, `WarningsNotAsErrors`, and `TreatWarningsAsErrors`. There is an additional option that controls the ILLink warn-as-error behavior independently:

- `<ILLinkTreatWarningsAsErrors>false</ILLinkTreatWarningsAsErrors>`

    Don't treat ILLink warnings as errors. This may be useful to avoid turning trim analysis warnings into errors when treating compiler warnings as errors globally.

## Show detailed warnings

In .NET 6+, trim analysis will produce at most one warning for each assembly that comes from a `PackageReference`, indicating that the assembly's internals are not compatible with trimming. You can also show individual warnings for all assemblies:

- `<TrimmerSingleWarn>false</TrimmerSingleWarn>`

    Show all detailed warnings, instead of collapsing them to a single warning per assembly.

The defaults show detailed warnings for the project assembly and `ProjectReference`s. `<TrimmerSingleWarn>` can also be set as metadata on an [individual assembly](#trimmed-assemblies) to control the warning behavior for that assembly only.

## Remove symbols

Symbols will normally be trimmed to match the trimmed assemblies. You can also remove all symbols:

- `<TrimmerRemoveSymbols>true</TrimmerRemoveSymbols>`

    Remove symbols from the trimmed application, including embedded PDBs and separate PDB files. This applies to both the application code and any dependencies that come with symbols.

The SDK also makes it possible to disable debugger support using the property `DebuggerSupport`. When debugger support is disabled, trimming will remove symbols automatically (`TrimmerRemoveSymbols` will default to true).

## Trimming framework library features

Several feature areas of the framework libraries come with trimmer directives that make it possible to remove the code for disabled features.

- `<AutoreleasePoolSupport>false</AutoreleasePoolSupport>` (default)

   Remove code that creates autorelease pools on supported platforms. See [AutoreleasePool for managed threads](../../run-time-config/threading.md#autoreleasepool-for-managed-threads). This is the default for the .NET SDK.

- `<DebuggerSupport>false</DebuggerSupport>`

    Remove code that enables better debugging experiences. This will also [remove symbols](#remove-symbols).

- `<EnableUnsafeBinaryFormatterSerialization>false</EnableUnsafeBinaryFormatterSerialization>`

    Remove BinaryFormatter serialization support. For more information, see [BinaryFormatter serialization methods are obsolete](../../compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete.md).

- `<EnableUnsafeUTF7Encoding>false</EnableUnsafeUTF7Encoding>`

    Remove insecure UTF-7 encoding code. For more information, see [UTF-7 code paths are obsolete](../../compatibility/core-libraries/5.0/utf-7-code-paths-obsolete.md).

- `<EventSourceSupport>false</EventSourceSupport>`

    Remove EventSource related code or logic.

- `<HttpActivityPropagationSupport>false</HttpActivityPropagationSupport>`

    Remove code related to diagnostics support for System.Net.Http.

- `<InvariantGlobalization>true</InvariantGlobalization>`

    Remove globalization-specific code and data. For more information, see [Invariant mode](../../run-time-config/globalization.md#invariant-mode).

- `<MetadataUpdaterSupport>false</MetadataUpdaterSupport>`

    Remove metadata update specific logic related to hot reload.

- `<UseNativeHttpHandler>true</UseNativeHttpHandler>`

    Use the default platform implementation of HttpMessageHandler for Android/iOS and remove the managed implementation.

- `<UseSystemResourceKeys>true</UseSystemResourceKeys>`

    Strip exception messages for `System.*` assemblies. When an exception is thrown from a `System.*` assembly, the message will be a simplified resource ID instead of the full message.

 These properties will cause the related code to be trimmed and will also disable features via the [runtimeconfig](../../run-time-config/index.md) file. For more information about these properties, including the corresponding *runtimeconfig* options, see [feature switches](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md). Some SDKs may have default values for these properties.

## Framework features disabled when trimming

The following features are incompatible with trimming because they require code that is not statically referenced. These are disabled by default in trimmed apps.

> [!WARNING]
> Enable these features at your own risk. They are likely to break trimmed apps without extra work to preserve the dynamically referenced code.

- `<BuiltInComInteropSupport>`

  Built-in COM support is disabled.

- `<CustomResourceTypesSupport>`

  Use of custom resource types is not supported. ResourceManager code paths that use reflection for custom resource types is trimmed.

- `<EnableCppCLIHostActivation>`

  C++/CLI host activation is disabled.

- `<EnableUnsafeBinaryFormatterInDesigntimeLicenseContextSerialization>`

  <xref:System.ComponentModel.Design.DesigntimeLicenseContextSerializer> use of `BinaryFormatter` serialization is disabled.

- `<StartupHookSupport>`

  Running code before `Main` with `DOTNET_STARTUP_HOOKS` is not supported. For more information, see [host startup hook](https://github.com/dotnet/runtime/blob/main/docs/design/features/host-startup-hook.md).
