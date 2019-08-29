---
title: .NET Core Runtime IDentifier (RID) catalog
description: Learn about the Runtime IDentifier (RID) and how RIDs are used in .NET Core.
ms.date: 02/22/2019
---
# .NET Core RID Catalog

RID is short for *Runtime IDentifier*. RID values are used to identify target platforms where the application runs.
They're used by .NET packages to represent platform-specific assets in NuGet packages. The following values are examples of RIDs: `linux-x64`, `ubuntu.14.04-x64`, `win7-x64`, or `osx.10.12-x64`.
For the packages with native dependencies, the RID designates on which platforms the package can be restored.

A single RID can be set in the `<RuntimeIdentifier>` element of your project file. Multiple RIDs can be defined as a semicolon-delimited list in the project file's `<RuntimeIdentifiers>` element. They're also used via the `--runtime` option with the following [.NET Core CLI commands](./tools/index.md):

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

  - The version **shouldn't** be marketing versions, as they often represent multiple discrete versions of the operating system with varying platform API surface area.

- `[architecture]` is the processor architecture. For example: `x86`, `x64`, `arm`, or `arm64`.

- `[additional qualifiers]` further differentiate different platforms. For example: `aot`.

## RID graph

The RID graph or runtime fallback graph is a list of RIDs that are compatible with each other. The RIDs are defined in the [Microsoft.NETCore.Platforms](https://www.nuget.org/packages/Microsoft.NETCore.Platforms/) package. You can see the list of supported RIDs and the RID graph in the [*runtime.json*](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file, which is located at the CoreFX repo. In this file, you can see that all RIDs, except for the base one, contain an `"#import"` statement. These statements indicate compatible RIDs.

When NuGet restores packages, it tries to find an exact match for the specified runtime.
If an exact match is not found, NuGet walks back the graph until it finds the closest compatible system according to the RID graph.

The following example is the actual entry for the `osx.10.12-x64` RID:

```json
"osx.10.12-x64": {
    "#import": [ "osx.10.12", "osx.10.11-x64" ]
}
```

The above RID specifies that `osx.10.12-x64` imports `osx.10.11-x64`. So, when NuGet restores packages, it tries to find an exact match for  `osx.10.12-x64` in the package. If NuGet cannot find the specific runtime, it can restore packages that specify `osx.10.11-x64` runtimes, for example.

The following example shows a slightly bigger RID graph also defined in the *runtime.json*  file:

```console
    win7-x64    win7-x86
       |   \   /    |
       |   win7     |
       |     |      |
    win-x64  |  win-x86
          \  |  /
            win
             |
            any
```

All RIDs eventually map back to the root `any` RID.

There are some considerations about RIDs that you have to keep in mind when working with them:

- RIDs are **opaque strings** and should be treated as black boxes.
- Don't build RIDs programmatically.
- Use RIDs that are already defined for the platform.
- The RIDs need to be specific, so don't assume anything from the actual RID value.

## Using RIDs

To be able to use RIDs, you have to know which RIDs exist. New values are added regularly to the platform.
For the latest and complete version, see the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo.

.NET Core 2.0 SDK introduces the concept of portable RIDs. They are new values added to the RID graph that aren't tied to a specific version or OS distribution and are the preferred choice when using .NET Core 2.0 and higher. They're particularly useful when dealing with multiple Linux distros since most distribution RIDs are mapped to the portable RIDs.

The following list shows a small subset of the most common RIDs used for each OS.

## Windows RIDs

Only common values are listed. For the latest and complete version, see the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo.

- Portable (.NET Core 2.0 or later versions)
  - `win-x64`
  - `win-x86`
  - `win-arm`
  - `win-arm64`
- Windows 7 / Windows Server 2008 R2
  - `win7-x64`
  - `win7-x86`
- Windows 8.1 / Windows Server 2012 R2
  - `win81-x64`
  - `win81-x86`
  - `win81-arm`
- Windows 10 / Windows Server 2016
  - `win10-x64`
  - `win10-x86`
  - `win10-arm`
  - `win10-arm64`

See [Prerequisites for .NET Core on Windows](windows-prerequisites.md) for more information.

## Linux RIDs

Only common values are listed. For the latest and complete version, see the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo. Devices running a distribution not listed below may work with one of the Portable RIDs. For example, Raspberry Pi devices running a Linux distribution not listed can be targeted with `linux-arm`.

- Portable (.NET Core 2.0 or later versions)
  - `linux-x64` (Most desktop distributions like CentOS, Debian, Fedora, Ubuntu and derivatives)
  - `linux-musl-x64` (Lightweight distributions using [musl](https://wiki.musl-libc.org/projects-using-musl.html) like Alpine Linux)
  - `linux-arm` (Linux distributions running on ARM like Raspberry Pi)
- Red Hat Enterprise Linux
  - `rhel-x64` (Superseded by `linux-x64` for RHEL above version 6)
  - `rhel.6-x64` (.NET Core 2.0 or later versions)
- Tizen (.NET Core 2.0 or later versions)
  - `tizen`
  - `tizen.4.0.0`
  - `tizen.5.0.0`

See [Prerequisites for .NET Core on Linux](linux-prerequisites.md) for more information.

## macOS RIDs

macOS RIDs use the older "OSX" branding. Only common values are listed. For the latest and complete version, see the [runtime.json](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/runtime.json) file on CoreFX repo.

- Portable (.NET Core 2.0 or later versions)
  - `osx-x64` (Minimum OS version is macOS 10.12 Sierra)
- macOS 10.10  Yosemite
  - `osx.10.10-x64`
- macOS 10.11 El Capitan
  - `osx.10.11-x64`
- macOS 10.12 Sierra (.NET Core 1.1 or later versions)
  - `osx.10.12-x64`
- macOS 10.13 High Sierra (.NET Core 1.1 or later versions)
  - `osx.10.13-x64`
- macOS 10.14 Mojave (.NET Core 1.1 or later versions)
  - `osx.10.14-x64`

See [Prerequisites for .NET Core on macOS](macos-prerequisites.md) for more information.

## See also

- [Runtime IDs](https://github.com/dotnet/corefx/blob/master/pkg/Microsoft.NETCore.Platforms/readme.md)
