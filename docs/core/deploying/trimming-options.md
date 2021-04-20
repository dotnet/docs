---
title: Trimming options
description: Learn how to control trimming of self-contained apps.
author: sbomer
ms.author: svbomer
ms.date: 08/25/2020
ms.topic: reference
---
# Trimming options

The following MSBuild properties and items influence the behavior of [trimmed self-contained deployments](trim-self-contained.md). Some of the options mention `ILLink`, which is the name of the underlying tool that implements trimming. More information about the underlying tool can be found at the [Linker documentation](https://github.com/mono/linker/tree/master/docs).

Trimming with `PublishTrimmed` was introduced in .NET Core 3.0. The other options are available only in .NET 5 and above.

## Enable trimming

- `<PublishTrimmed>true</PublishTrimmed>`

   Enable trimming during publish, with the default settings defined by the SDK.

This will trim any assemblies which have been configured for trimming. With `Microsoft.NET.Sdk` in .NET 6, this includes the any assemblies with `[AssemblyMetadata("IsTrimmable", "True")]`, which is the case for framework assemblies. In .NET 5, framework assemblies from the netcoreapp runtime pack are configured for trimming via `<IsTrimmable>` MSBuild metadata. Other SDKs may define different defaults.

## Trimming granularity

The following granularity settings control how aggressively unused IL is discarded. This can be set as a property affecting all trimmer input assemblies, or as metadata on an [individual assembly](#trimmed-assemblies) which overrides the property setting.

- `<TrimMode>link</TrimMode>`

    Enable member-level trimming, which removes unused members from types. This is the default in .NET 6+.

- `<TrimMode>copyused</TrimMode>`

   Enable assembly-level trimming, which will keep an entire assembly if any part of it is used (in a statically understood way).

Assemblies with `<IsTrimmable>true</IsTrimmable>` metadata but no explicit `TrimMode` will use the global `TrimMode`. The default `TrimMode` for `Microsoft.NET.Sdk` is `link` in .NET 6+, and `copyused` in previous versions.

## Trim additional assemblies

In .NET 6+, `PublishTrimmed` trims assemblies with the assembly-level attribute

```csharp
[AssemblyMetadata("IsTrimmable", "True")]
```

which includes the framework libraries. In .NET 6+, you can also opt in to trimming for a library without this attribute, specifying the assembly by name (without the `.dll` extension).

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

- `<TrimmerSingleWarn>True</TrimmerSingleWarn>` or `<TrimmerSingleWarn>False<TrimmerSingleWarn>`

  Control whether to show [single warnings](#show-detailed-warnings) for this assembly.

## Root assemblies

All assemblies that do not have `<IsTrimmable>true</IsTrimmable>` are considered roots for the analysis, which means that they and all of their statically understood dependencies will be kept. Additional assemblies may be "rooted" by name (without the `.dll` extension):

```xml
<ItemGroup>
  <TrimmerRootAssembly Include="MyAssembly" />
</ItemGroup>
```

## Root descriptors

Another way to specify roots for analysis is using an XML file that uses the linker [descriptor format](https://github.com/mono/linker/blob/master/docs/data-formats.md#descriptor-format). This lets you root specific members instead of a whole assembly.

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

Trim analysis respects the [`AnalysisLevel`](../project-sdk/msbuild-props.md#analysislevel) property that controls the version of analysis warnings across the SDK. There is another property that controls the version of trim analysis warnings independently (similar to `WarningLevel` for the compiler):

- `<ILLinkWarningLevel>5</ILLinkWarningLevel>`

    Emit only warnings of the given level or lower. This can be `9999` to include all warning versions.

## Suppressing warnings

Individual [warning codes](https://github.com/mono/linker/blob/master/docs/error-codes.md#warning-codes) can be suppressed using the usual MSBuild properties respected by the toolchain, including `NoWarn`, `WarningsAsErrors`, `WarningsNotAsErrors`, and `TreatWarningsAsErrors`. There is an additional option that controls the ILLink warn-as-error behavior independently:

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

Several feature areas of the framework libraries come with linker directives that make it possible to remove the code for disabled features.

- `<DebuggerSupport>false</DebuggerSupport>`

    Remove code that enables better debugging experiences. This will also [remove symbols](#remove-symbols).

- `<EnableUnsafeBinaryFormatterSerialization>false</EnableUnsafeBinaryFormatterSerialization>`

    Remove BinaryFormatter serialization support. For more information, see [BinaryFormatter serialization methods are obsolete](../compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete.md).

- `<EnableUnsafeUTF7Encoding>false</EnableUnsafeUTF7Encoding>`

    Remove insecure UTF-7 encoding code. For more information, see [UTF-7 code paths are obsolete](../compatibility/core-libraries/5.0/utf-7-code-paths-obsolete.md).

- `<EventSourceSupport>false</EventSourceSupport>`

    Remove EventSource related code or logic.

- `<HttpActivityPropagationSupport>false</HttpActivityPropagationSupport>`

    Remove code related to diagnostics support for System.Net.Http.

- `<InvariantGlobalization>true</InvariantGlobalization>`

    Remove globalization specific code and data. For more information, see [Invariant mode](../run-time-config/globalization.md#invariant-mode).

- `<UseSystemResourceKeys>true</UseSystemResourceKeys>`

    Strip exception messages for `System.*` assemblies. When an exception is thrown from a `System.*` assembly, the message will be a simplified resource ID instead of the full message.

 These properties will cause the related code to be trimmed and will also disable features via the [runtimeconfig](../run-time-config/index.md) file. For more information about these properties, including the corresponding runtimeconfig options, see [feature switches](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md). Some SDKs may have default values for these properties.
