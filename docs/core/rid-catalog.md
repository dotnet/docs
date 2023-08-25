---
title: .NET Runtime Identifier (RID) catalog
description: Learn about the runtime identifier (RID) and how RIDs are used in .NET.
ms.date: 07/11/2022
ms.topic: reference
---
# .NET RID Catalog

RID is short for *runtime identifier*. RID values are used to identify target platforms where the application runs.
They're used by .NET packages to represent platform-specific assets in NuGet packages. The following values are examples of RIDs: `linux-x64`, `win-x64`, or `osx-x64`.
For the packages with native dependencies, the RID designates on which platforms the package can be restored.

A single RID can be set in the [`<RuntimeIdentifier>`](project-sdk/msbuild-props.md#runtimeidentifier) element of your project file. Multiple RIDs can be defined as a semicolon-delimited list in the project file's [`<RuntimeIdentifiers>`](project-sdk/msbuild-props.md#runtimeidentifiers) element. They're also used via the `--runtime` option with the following [.NET CLI commands](./tools/index.md):

- [dotnet build](./tools/dotnet-build.md)
- [dotnet clean](./tools/dotnet-clean.md)
- [dotnet pack](./tools/dotnet-pack.md)
- [dotnet publish](./tools/dotnet-publish.md)
- [dotnet restore](./tools/dotnet-restore.md)
- [dotnet run](./tools/dotnet-run.md)
- [dotnet store](./tools/dotnet-store.md)

RIDs that represent concrete operating systems usually follow this pattern: `[os].[version]-[architecture]-[additional qualifiers]` where:

- `[os]` is the operating/platform system moniker. For example, `ubuntu`.

- `[version]` is the operating system version in the form of a dot-separated (`.`) version number. For example, `15.10`.

  The version **shouldn't** be a marketing version, as marketing versions often represent multiple discrete versions of the operating system with varying platform API surface area.

- `[architecture]` is the processor architecture. For example: `x86`, `x64`, `arm`, or `arm64`.

- `[additional qualifiers]` further differentiate different platforms. For example: `aot`.

## RID graph

The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other.

These RIDs are defined in [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository. In this file, you can see that all RIDs, except for the base one, contain an `"#import"` statement. These statements indicate compatible RIDs.

Before .NET 8, version-specific and distro-specific RIDs were regularly added to the [Microsoft.NETCore.Platforms](https://www.nuget.org/packages/Microsoft.NETCore.Platforms/) package and the RID graph in the [*runtime.json*](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json) file, which is located in the `dotnet/runtime` repository. This graph is no longer updated and exists as a backwards compatibility option. Developers should [use RIDs that are non-version-specific and non-distro-specific](#using-rids).

When NuGet restores packages, it tries to find an exact match for the specified runtime.
If an exact match is not found, NuGet walks back the graph until it finds the closest compatible system according to the RID graph.

The following example is the actual entry for the `osx-x64` RID:

```json
"osx-x64": {
    "#import": [ "osx", "unix-x64" ]
}
```

The above RID specifies that `osx-x64` imports `unix-x64`. So, when NuGet restores packages, it tries to find an exact match for  `osx-x64` in the package. If NuGet can't find the specific runtime, it can restore packages that specify `unix-x64` runtimes, for example.

The following example shows a slightly bigger RID graph also defined in the *runtime.json*  file:

```
    linux-arm64     linux-arm32
         |     \   /     |
         |     linux     |
         |       |       |
    unix-arm64   |    unix-x64
             \   |   /
               unix
                 |
                any
```

All RIDs eventually map back to the root `any` RID.

There are some considerations about RIDs that you have to keep in mind when working with them:

- Don't try to parse RIDs to retrieve component parts.
- Use RIDs that are already defined for the platform.
- The RIDs need to be specific, so don't assume anything from the actual RID value.
- Don't build RIDs programmatically unless absolutely necessary.

  Some apps need to compute RIDs programmatically. If so, the computed RIDs must match the catalog exactly, including in casing. RIDs with different casing would cause problems when the OS is case sensitive, for example, Linux, because the value is often used when constructing things like output paths. For example, consider a custom publishing wizard in Visual Studio that relies on information from the solution configuration manager and project properties. If the solution configuration passes an invalid value, for example, `ARM64` instead of `arm64`, it could result in an invalid RID, such as `win-ARM64`.

## Using RIDs

To be able to use RIDs, you have to know which RIDs exist. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

RIDs that are considered 'portable' &mdash; that is, aren't tied to a specific version or OS distribution &mdash; are the recommended choice. This means that portable RIDs should be used for both [building a platform-specific application](./deploying/index.md#platform-specific-and-framework-dependent) and [creating a NuGet package with RID-specific assets](/nuget/create-packages/supporting-multiple-target-frameworks#architecture-specific-folders).

Starting with .NET 8, the default behavior of the .NET SDK and runtime is to only consider non-version-specific and non-distro-specific RIDs. When restoring and building, the SDK [uses a smaller portable RID graph](https://github.com/dotnet/docs/issues/36527). The <xref:System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier?displayProperty=nameWithType> [returns the platform for which the runtime was built](https://github.com/dotnet/docs/issues/36466). At run time, .NET finds [RID-specific assets using a known set of portable RIDs](./compatibility/deployment/8.0/rid-asset-list.md). When building an application with RID-specific assets that may be ignored at runtime, the SDK will emit a warning: [NETSDK1206](./tools/sdk-errors/netsdk1206.md).

### Loading assets for a specific OS version or distribution

.NET no longer attempts to provide first-class support for resolving dependencies that are specific to an OS version or distribution. If your application or package needs to load different assets based on OS version or distribution, it should implement the logic to conditionally load assets.

To get information about the platform, use <xref:System.OperatingSystem?displayProperty=nameWithType> APIs. On Windows and macOS, <xref:System.Environment.OSVersion?displayProperty=nameWithType> will [return the operating system version](./compatibility/core-libraries/5.0/environment-osversion-returns-correct-version.md). On Linux, it may be the kernel version &mdash; to get the Linux distro name and version information, the recommended approach is to read the */etc/os-release* file.

.NET provides various extension points for customizing loading logic &mdash; for example, <xref:System.Runtime.InteropServices.NativeLibrary.SetDllImportResolver(System.Reflection.Assembly,System.Runtime.InteropServices.DllImportResolver)?displayProperty=nameWithType> and <xref:System.Runtime.Loader.AssemblyLoadContext.ResolvingUnmanagedDll?displayProperty=nameWithType>. These can be used to load the asset corresponding to the current platform.

## Known RIDs

The following list shows a small subset of the most common RIDs used for each OS. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

### Windows RIDs

Only common values are listed. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

- `win-x64`
- `win-x86`
- `win-arm64`

For more information, see [.NET dependencies and requirements](./install/windows.md#dependencies).

### Linux RIDs

Only common values are listed. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

- `linux-x64` (Most desktop distributions like CentOS, Debian, Fedora, Ubuntu, and derivatives)
- `linux-musl-x64` (Lightweight distributions using [musl](https://wiki.musl-libc.org/projects-using-musl.html) like Alpine Linux)
- `linux-arm` (Linux distributions running on Arm like Raspbian on Raspberry Pi Model 2+)
- `linux-arm64` (Linux distributions running on 64-bit Arm like Ubuntu Server 64-bit on Raspberry Pi Model 3+)
- `linux-bionic-arm64` (Distributions using Android's bionic libc, for example, Termux)

For more information, see [.NET dependencies and requirements](./install/linux.md).

### macOS RIDs

macOS RIDs use the older "OSX" branding. Only common values are listed. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

- `osx-x64` (Minimum OS version is macOS 10.12 Sierra)
- `osx-arm64`

For more information, see [.NET dependencies and requirements](./install/macos.md).

### iOS RIDs

Only common values are listed. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

- `ios-arm64`

### Android RIDs

Only common values are listed. For the latest and complete version, see the [PortableRuntimeIdentifierGraph.json](https://github.com/dotnet/sdk/blob/main/src/Layout/redist/PortableRuntimeIdentifierGraph.json) in the [`dotnet/sdk`](https://github.com/dotnet/sdk) repository.

- `android-arm64`

## See also

- [Runtime IDs](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/readme.md)
