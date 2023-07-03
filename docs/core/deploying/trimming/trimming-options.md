---
title: Trimming options
description: Learn how to control trimming of self-contained apps.
author: sbomer
ms.author: svbomer
ms.date: 08/25/2020
ms.topic: reference
zone_pivot_groups: dotnet-version
---

# Trimming options

The following MSBuild properties and items influence the behavior of [trimmed self-contained deployments](trim-self-contained.md). Some of the options mention `ILLink`, which is the name of the underlying tool that implements trimming. For more information about the underlying tool, see the [Trimmer documentation](https://github.com/dotnet/linker/tree/main/docs).

Trimming with `PublishTrimmed` was introduced in .NET Core 3.0. The other options are available only in .NET 5 and later versions.

## Enable trimming

- `<PublishTrimmed>true</PublishTrimmed>`

  Enable trimming during publish. This also turns off trim-incompatible features and enables [trim analysis](#roslyn-analyzer) during build.

> [!NOTE]
> If you specify trimming as enabled from the command line, your debugging experience will differ and you may encounter additional bugs in the final product.

Place this setting in the project file to ensure that the setting applies during `dotnet build`, not just `dotnet publish`.

:::zone pivot="dotnet-7-0"

This setting enables trimming and will trim all assemblies by default. In .NET 6, only assemblies that opted-in
to trimming via `[AssemblyMetadata("IsTrimmable", "True")]` would be trimmed by default. You can return to the
previous behavior by using `<TrimMode>partial</TrimMode>`.

:::zone-end

:::zone pivot="dotnet-6-0"

This setting trims any assemblies that have been configured for trimming. With `Microsoft.NET.Sdk` in .NET 6, this includes any assemblies with `[AssemblyMetadata("IsTrimmable", "True")]`, which is the case for the .NET runtime assemblies. In .NET 5, assemblies from the netcoreapp runtime pack are configured for trimming via `<IsTrimmable>` MSBuild metadata. Other SDKs may define different defaults.

:::zone-end

This setting also enables the trim-compatibility [Roslyn analyzer](#roslyn-analyzer) and disables [features that are incompatible with trimming](#framework-features-disabled-when-trimming).

## Trimming granularity

:::zone pivot="dotnet-7-0"

The default is to trim all assemblies in the app. This can be changed using the `TrimMode` property.

To only trim assemblies that have opted-in to trimming, set the property to `partial`:

```csharp
<TrimMode>partial</TrimMode>
```

The default setting is `full`:

```csharp
<TrimMode>full</TrimMode>
```

:::zone-end

:::zone pivot="dotnet-6-0"

The following granularity settings control how aggressively unused IL is discarded. This can be set as a property affecting all trimmer input assemblies, or as metadata on an [individual assembly](#trimming-settings-for-individual-assemblies), which overrides the property setting.

- `<TrimMode>link</TrimMode>`

  Enable member-level trimming, which removes unused members from types. This is the default in .NET 6+.

- `<TrimMode>copyused</TrimMode>`

  Enable assembly-level trimming, which keeps an entire assembly if any part of it is used (in a statically understood way).

Assemblies with `<IsTrimmable>true</IsTrimmable>` metadata but no explicit `TrimMode` will use the global `TrimMode`. The default `TrimMode` for `Microsoft.NET.Sdk` is `link` in .NET 6+, and `copyused` in previous versions.

## Trim additional assemblies

In .NET 6+, `PublishTrimmed` trims assemblies with the following assembly-level attribute:

```csharp
[AssemblyMetadata("IsTrimmable", "True")]
```

The framework libraries have this attribute. In .NET 6+, you can also opt in to trimming for a library without this attribute, specifying the assembly by name (without the `.dll` extension).

:::zone-end

:::zone pivot="dotnet-7-0"
In .NET 7, `<TrimMode>full</TrimMode>` is the default, but if you change the trim mode to `partial`, you can
opt-in individual assemblies to trimming.

```xml
<ItemGroup>
  <TrimmableAssembly Include="MyAssembly" />
</ItemGroup>
```

This is equivalent to setting `[AssemblyMetadata("IsTrimmable", "True")]` when building the assembly.

:::zone-end

:::zone pivot="dotnet-6-0"

## Trimming settings for individual assemblies

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

:::zone-end

## Root assemblies

If an assembly is not trimmed it is considered "rooted", which means that it and all of its statically understood dependencies will be kept. Additional assemblies may be "rooted" by name (without the `.dll` extension):

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

- `<SuppressTrimAnalysisWarnings>false</SuppressTrimAnalysisWarnings>`

  Enable trim analysis warnings.

Trimming removes IL that is not statically reachable. Apps that use reflection or other patterns that create dynamic dependencies may be broken by trimming. To warn about such patterns, set `<SuppressTrimAnalysisWarnings>` to `false`. This will include warnings about the entire app, including your own code, library code, and framework code.

## Roslyn analyzer

Setting `PublishTrimmed` in .NET 6+ also enables a Roslyn analyzer that shows a _limited_ set of analysis warnings. You can also enable or disable the analyzer independently of `PublishTrimmed`.

- `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>`

  Enable a Roslyn analyzer for a subset of trim analysis warnings.

## Suppress warnings

You can suppress individual [warning codes](https://github.com/dotnet/linker/blob/main/docs/error-codes.md#warning-codes) using the usual MSBuild properties respected by the toolchain, including `NoWarn`, `WarningsAsErrors`, `WarningsNotAsErrors`, and `TreatWarningsAsErrors`. There is an additional option that controls the ILLink warn-as-error behavior independently:

- `<ILLinkTreatWarningsAsErrors>false</ILLinkTreatWarningsAsErrors>`

  Don't treat ILLink warnings as errors. This may be useful to avoid turning trim analysis warnings into errors when treating compiler warnings as errors globally.

## Show detailed warnings

In .NET 6+, trim analysis produces at most one warning for each assembly that comes from a `PackageReference`, indicating that the assembly's internals are not compatible with trimming. You can also show individual warnings for all assemblies:

- `<TrimmerSingleWarn>false</TrimmerSingleWarn>`

  Show all detailed warnings, instead of collapsing them to a single warning per assembly.

## Remove symbols

Symbols are usually trimmed to match the trimmed assemblies. You can also remove all symbols:

- `<TrimmerRemoveSymbols>true</TrimmerRemoveSymbols>`

  Remove symbols from the trimmed application, including embedded PDBs and separate PDB files. This applies to both the application code and any dependencies that come with symbols.

The SDK also makes it possible to disable debugger support using the property `DebuggerSupport`. When debugger support is disabled, trimming will remove symbols automatically (`TrimmerRemoveSymbols` will default to true).

## Trimming framework library features

Several feature areas of the framework libraries come with trimmer directives that make it possible to remove the code for disabled features.

- `<AutoreleasePoolSupport>false</AutoreleasePoolSupport>` (default)

  Remove code that creates autorelease pools on supported platforms. See [AutoreleasePool for managed threads](../../runtime-config/threading.md#autoreleasepool-for-managed-threads). This is the default for the .NET SDK.

- `<DebuggerSupport>false</DebuggerSupport>`

  Remove code that enables better debugging experiences. This setting also [removes symbols](#remove-symbols).

- `<EnableUnsafeBinaryFormatterSerialization>false</EnableUnsafeBinaryFormatterSerialization>`

  Remove BinaryFormatter serialization support. For more information, see [BinaryFormatter serialization methods are obsolete](../../compatibility/serialization/5.0/binaryformatter-serialization-obsolete.md).

- `<EnableUnsafeUTF7Encoding>false</EnableUnsafeUTF7Encoding>`

  Remove insecure UTF-7 encoding code. For more information, see [UTF-7 code paths are obsolete](../../compatibility/core-libraries/5.0/utf-7-code-paths-obsolete.md).

- `<EventSourceSupport>false</EventSourceSupport>`

  Remove EventSource related code or logic.

- `<HttpActivityPropagationSupport>false</HttpActivityPropagationSupport>`

  Remove code related to diagnostics support for System.Net.Http.

- `<InvariantGlobalization>true</InvariantGlobalization>`

  Remove globalization-specific code and data. For more information, see [Invariant mode](../../runtime-config/globalization.md#invariant-mode).

- `<MetadataUpdaterSupport>false</MetadataUpdaterSupport>`

  Remove metadata update-specific logic related to hot reload.

- `<StackTraceSupport>false</StackTraceSupport>`

  Remove support for generating stack traces (for example, <xref:System.Environment.StackTrace?displayProperty=nameWithType>, or <xref:System.Exception.ToString%2A?displayProperty=nameWithType>) by the runtime. The amount of information that will be removed from stack trace strings may depend on other deployment options. This option does not affect stack traces generated by debuggers.

- `<UseNativeHttpHandler>true</UseNativeHttpHandler>`

  Use the default platform implementation of HttpMessageHandler for Android/iOS and remove the managed implementation.

- `<UseSystemResourceKeys>true</UseSystemResourceKeys>`

  Strip exception messages for `System.*` assemblies. When an exception is thrown from a `System.*` assembly, the message will be a simplified resource ID instead of the full message.

These properties cause the related code to be trimmed and also disable features via the [runtimeconfig](../../runtime-config/index.md) file. For more information about these properties, including the corresponding *runtimeconfig* options, see [feature switches](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md). Some SDKs may have default values for these properties.

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
