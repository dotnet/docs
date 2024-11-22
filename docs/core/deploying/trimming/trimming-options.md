---
title: Trimming options
description: Learn how to control trimming of self-contained apps using MSBuild properties. For example, set trimming granularity or suppress trim analysis warnings.
author: sbomer
ms.author: svbomer
ms.date: 08/29/2024
ms.topic: reference
---

# Trimming options

The MSBuild properties and items described in this article influence the behavior of [trimmed, self-contained deployments](trim-self-contained.md). Some of the options mention `ILLink`, which is the name of the underlying tool that implements trimming. For more information about the underlying tool, see the [Trimmer documentation](https://github.com/dotnet/runtime/tree/main/docs/tools/illink).

Trimming with `PublishTrimmed` was introduced in .NET Core 3.0. The other options are available in .NET 5 and later versions.

## Enable trimming

- `<PublishTrimmed>true</PublishTrimmed>`

  Enable trimming during publish. This setting also turns off trim-incompatible features and enables [trim analysis](#roslyn-analyzer) during build. In .NET 8 and later apps, this setting also enables the configuration binding and request delegate source generators.

> [!NOTE]
> If you specify trimming as enabled from the command line, your debugging experience will differ and you might encounter additional bugs in the final product.

Place this setting in the project file to ensure that the setting applies during `dotnet build`, not just `dotnet publish`.

This setting enables trimming and trims all assemblies by default. In .NET 6, only assemblies that opted-in to trimming via `[AssemblyMetadata("IsTrimmable", "True")]` (added in projects that set `<IsTrimmable>true</IsTrimmable>`) were trimmed by default. You can return to the previous behavior by using `<TrimMode>partial</TrimMode>`.

This setting also enables the trim-compatibility [Roslyn analyzer](#roslyn-analyzer) and disables [features that are incompatible with trimming](#framework-features-disabled-when-trimming).

## Trimming granularity

Use the `TrimMode` property to set the trimming granularity to either `partial` or `full`. The default setting for console apps (and, starting in .NET 8, Web SDK apps) is `full`:

```xml
<TrimMode>full</TrimMode>
```

To only trim assemblies that have opted-in to trimming, set the property to `partial`:

```xml
<TrimMode>partial</TrimMode>
```

If you change the trim mode to `partial`, you can opt-in individual assemblies to trimming by using a `<TrimmableAssembly>` MSBuild item.

```xml
<ItemGroup>
  <TrimmableAssembly Include="MyAssembly" />
</ItemGroup>
```

This is equivalent to setting `[AssemblyMetadata("IsTrimmable", "True")]` when building the assembly.

## Root assemblies

If an assembly is not trimmed, it's considered "rooted", which means that it and all of its statically understood dependencies will be kept. Additional assemblies can be "rooted" by name (without the `.dll` extension):

```xml
<ItemGroup>
  <TrimmerRootAssembly Include="MyAssembly" />
</ItemGroup>
```

## Root descriptors

Another way to specify roots for analysis is using an XML file that uses the trimmer [descriptor format](https://github.com/dotnet/runtime/blob/main/docs/tools/illink/data-formats.md#descriptor-format). This lets you root specific members instead of a whole assembly.

```xml
<ItemGroup>
  <TrimmerRootDescriptor Include="MyRoots.xml" />
</ItemGroup>
```

For example, `MyRoots.xml` might root a specific method that's dynamically accessed by the application:

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

Trimming removes IL that's not statically reachable. Apps that use reflection or other patterns that create dynamic dependencies might be broken by trimming. To warn about such patterns, set `<SuppressTrimAnalysisWarnings>` to `false`. This setting will surface warnings about the entire app, including your own code, library code, and framework code.

## Roslyn analyzer

Setting `PublishTrimmed` in .NET 6+ also enables a Roslyn analyzer that shows a _limited_ set of analysis warnings. You can also enable or disable the analyzer independently of `PublishTrimmed`.

- `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>`

  Enable a Roslyn analyzer for a subset of trim analysis warnings.

## Suppress warnings

You can suppress individual [warning codes](https://github.com/dotnet/runtime/blob/main/docs/tools/illink/error-codes.md#warning-codes) using the usual MSBuild properties respected by the toolchain, including `NoWarn`, `WarningsAsErrors`, `WarningsNotAsErrors`, and `TreatWarningsAsErrors`. There's an additional option that controls the ILLink warn-as-error behavior independently:

- `<ILLinkTreatWarningsAsErrors>false</ILLinkTreatWarningsAsErrors>`

  Don't treat ILLink warnings as errors. This might be useful to avoid turning trim analysis warnings into errors when treating compiler warnings as errors globally.

## Show detailed warnings

In .NET 6+, trim analysis produces at most one warning for each assembly that comes from a `PackageReference`, indicating that the assembly's internals are not compatible with trimming. You can also show individual warnings for all assemblies:

- `<TrimmerSingleWarn>false</TrimmerSingleWarn>`

  Show all detailed warnings, instead of collapsing them to a single warning per assembly.

## Remove symbols

Symbols are usually trimmed to match the trimmed assemblies. You can also remove all symbols:

- `<TrimmerRemoveSymbols>true</TrimmerRemoveSymbols>`

  Remove symbols from the trimmed application, including embedded PDBs and separate PDB files. This applies to both the application code and any dependencies that come with symbols.

The SDK also makes it possible to disable debugger support using the property `DebuggerSupport`. When debugger support is disabled, trimming removes symbols automatically (`TrimmerRemoveSymbols` will default to true).

## Trim framework library features

Several feature areas of the framework libraries come with trimmer directives that make it possible to remove the code for disabled features.

| MSBuild property | Description |
| - | - |
| `AutoreleasePoolSupport` | When set to `false`, removes code that creates [autorelease pools](../../runtime-config/threading.md#autoreleasepool-for-managed-threads) on supported platforms. `false` is the default for the .NET SDK. |
| `DebuggerSupport` | When set to `false`, removes code that enables better debugging experiences. This setting also [removes symbols](#remove-symbols). |
| `EnableUnsafeBinaryFormatterSerialization` | When set to `false`, removes BinaryFormatter serialization support. For more information, see [BinaryFormatter serialization methods are obsolete](../../compatibility/serialization/5.0/binaryformatter-serialization-obsolete.md) and [In-box BinaryFormatter implementation removed and always throws](../../compatibility/serialization/9.0/binaryformatter-removal.md). |
| `EnableUnsafeUTF7Encoding` | When set to `false`, removes insecure UTF-7 encoding code. For more information, see [UTF-7 code paths are obsolete](../../compatibility/core-libraries/5.0/utf-7-code-paths-obsolete.md). |
| `EventSourceSupport` | When set to `false`, removes EventSource-related code and logic. |
| `HttpActivityPropagationSupport` | When set to `false`, removes code related to diagnostics support for <xref:System.Net.Http>. |
| `InvariantGlobalization` | When set to `true`, removes globalization-specific code and data. For more information, see [Invariant mode](../../runtime-config/globalization.md#invariant-mode). |
| `MetadataUpdaterSupport` | When set to `false`, removes metadata update&ndash;specific logic related to hot reload. |
| `MetricsSupport` | When set to `false`, removes support for <xref:System.Diagnostics.Metrics> instrumentation. |
| `StackTraceSupport` (.NET 8+) | When set to `false`, removes support for generating stack traces (for example, <xref:System.Environment.StackTrace?displayProperty=nameWithType> or <xref:System.Exception.ToString%2A?displayProperty=nameWithType>) by the runtime. The amount of information that is removed from stack trace strings might depend on other deployment options. This option does not affect stack traces generated by debuggers. |
| `UseNativeHttpHandler` | When set to `true`, uses the default platform implementation of <xref:System.Net.Http.HttpMessageHandler> for Android and iOS and removes the managed implementation. |
| `UseSystemResourceKeys` | When set to `true`, strips exception messages for `System.*` assemblies. When an exception is thrown from a `System.*` assembly, the message is a simplified resource ID instead of the full message. |
| `XmlResolverIsNetworkingEnabledByDefault` (.NET 8+) | When set to `false`, removes support for resolving non-file URLs in <xref:System.Xml>. Only file-system resolving is supported. |

These properties cause the related code to be trimmed and also disable features via the [runtimeconfig](../../runtime-config/index.md) file. For more information about these properties, including the corresponding _runtimeconfig_ options, see [feature switches](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md). Some SDKs might have default values for these properties.

## Framework features disabled when trimming

The following features are incompatible with trimming because they require code that's not statically referenced. These features are disabled by default in trimmed apps.

> [!WARNING]
> Enable these features at your own risk. They are likely to break trimmed apps without extra work to preserve the dynamically referenced code.

- `<BuiltInComInteropSupport>`

  Built-in COM support is disabled.

- `<CustomResourceTypesSupport>`

  Use of custom resource types isn't supported. ResourceManager code paths that use reflection for custom resource types are trimmed.

- `<EnableCppCLIHostActivation>`

  C++/CLI host activation is disabled.

- `<EnableUnsafeBinaryFormatterInDesigntimeLicenseContextSerialization>`

  <xref:System.ComponentModel.Design.DesigntimeLicenseContextSerializer> use of `BinaryFormatter` serialization is disabled.

- `<StartupHookSupport>`

  Running code before `Main` with `DOTNET_STARTUP_HOOKS` isn't supported. For more information, see [host startup hook](https://github.com/dotnet/runtime/blob/main/docs/design/features/host-startup-hook.md).
