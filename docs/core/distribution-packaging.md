---
title: .NET distribution packaging
description: Learn how to package, name, and version .NET for distribution.
author: tmds
ms.date: 12/01/2021
---
# .NET distribution packaging

As .NET 5 (and .NET Core) and later versions become available on more and more platforms, it's useful to learn how to package, name, and version apps and libraries that use it. This way, package maintainers can help ensure a consistent experience no matter where users choose to run .NET. This article is useful for users that are:

- Attempting to build .NET from source.
- Wanting to make changes to the .NET CLI that could impact the resulting layout or packages produced.

## Disk layout

When installed, .NET consists of several components that are laid out as follows in the file system:

```
{dotnet_root}                    (0)              (*)
├── dotnet                       (1)
├── LICENSE.txt                  (8)
├── ThirdPartyNotices.txt        (8)
├── host                                          (*)
│   └── fxr                                       (*)
│       └── <fxr version>        (2)
├── sdk                                           (*)
│   └── <sdk version>            (3)
├── sdk-manifests                (4)              (*)
│   └── <sdk feature band version>
├── library-packs                (21)             (*)
├── metadata                     (4)              (*)
│   └── workloads
│       └── <sdk feature band version>
├── template-packs               (4)              (*)
├── packs                                         (*)
│   ├── Microsoft.AspNetCore.App.Ref              (*)
│   │   └── <aspnetcore ref version>     (11)
│   ├── Microsoft.NETCore.App.Ref                 (*)
│   │   └── <netcore ref version>        (12)
│   ├── Microsoft.NETCore.App.Host.<rid>          (*)
│   │   └── <apphost version>            (13)
│   ├── Microsoft.WindowsDesktop.App.Ref          (*)
│   │   └── <desktop ref version>        (14)
│   ├── NETStandard.Library.Ref                   (*)
│   │   └── <netstandard version>        (15)
│   ├── Microsoft.NETCore.App.Runtime.<rid>       (*)
│   │   └── <runtime version>            (18)
│   ├── Microsoft.AspNetCore.App.Runtime.<rid>    (*)
│   │   └── <aspnetcore version>         (18)
│   ├── runtime.<rid>.Microsoft.DotNet.ILCompiler (*)
│   │   └── <runtime version>            (19)
│   └── Microsoft.NETCore.App.Runtime.NativeAOT.<rid> (*)
│       └── <runtime version>            (20)
├── shared                                        (*)
│   ├── Microsoft.NETCore.App                     (*)
│   │   └── <runtime version>     (5)
│   ├── Microsoft.AspNetCore.App                  (*)
│   │   └── <aspnetcore version>  (6)
│   ├── Microsoft.AspNetCore.All                  (*)
│   │   └── <aspnetcore version>  (6)
│   └── Microsoft.WindowsDesktop.App              (*)
│       └── <desktop app version> (7)
└── templates                                     (*)
│   └── <templates version>      (17)
/
├── etc/dotnet
│       └── install_location     (16)
├── usr/share/man/man1
│       └── dotnet.1.gz          (9)
└── usr/bin
        └── dotnet               (10)
```

- (0) **{dotnet_root}** is a shared root for all .NET major and minor versions. If multiple runtimes are installed, they share the **{dotnet_root}** folder, for example, `{dotnet_root}/shared/Microsoft.NETCore.App/6.0.11` and `{dotnet_root}/shared/Microsoft.NETCore.App/7.0.0`. The name of the `{dotnet_root}` folder should be version agnostic, that is, simply `dotnet`.

- (1) **dotnet** The host (also known as the "muxer") has two distinct roles: activate a runtime to launch an application, and activate an SDK to dispatch commands to it. The host is a native executable (`dotnet.exe`).

While there's a single host, most of the other components are in versioned directories (2,3,5,6). This means multiple versions can be present on the system since they're installed side by side.

- (2) **host/fxr/\<fxr version>** contains the framework resolution logic used by the host. The host uses the latest hostfxr that is installed. The hostfxr is responsible for selecting the appropriate runtime when executing a .NET application. For example, an application built for .NET 7.0.0 uses the 7.0.5 runtime when it's available. Similarly, hostfxr selects the appropriate SDK during development.

- (3) **sdk/\<sdk version>** The SDK (also known as "the tooling") is a set of managed tools that are used to write and build .NET libraries and applications. The SDK includes the .NET CLI, the managed languages compilers, MSBuild, and associated build tasks and targets, NuGet, new project templates, and so on.

- (4) **sdk-manifests/\<sdk feature band version>** The names and versions of the assets that an optional workload installation requires are maintained in workload manifests stored in this folder. The folder name is the feature band version of the SDK. So for an SDK version such as 7.0.102, this folder would still be named 7.0.100. When a workload is installed, the following folders are created as needed for the workload's assets: *metadata* and *template-packs*. A distribution can create an empty */metadata/workloads/\<sdkfeatureband>/userlocal* file if workloads should be installed under a user path rather than in the *dotnet* folder. For more information, see GitHub issue [dotnet/installer#12104](https://github.com/dotnet/installer/issues/12104).

The **shared** folder contains frameworks. A shared framework provides a set of libraries at a central location so they can be used by different applications.

- (5) **shared/Microsoft.NETCore.App/\<runtime version>** This framework contains the .NET runtime and supporting managed libraries.

- (6) **shared/Microsoft.AspNetCore.{App,All}/\<aspnetcore version>** contains the ASP.NET Core libraries. The libraries under `Microsoft.AspNetCore.App` are developed and supported as part of the .NET project. The libraries under `Microsoft.AspNetCore.All` are a superset that also contains third-party libraries.

- (7) **shared/Microsoft.Desktop.App/\<desktop app version>** contains the Windows desktop libraries. This isn't included on non-Windows platforms.

- (8) **LICENSE.txt,ThirdPartyNotices.txt** are the .NET license and licenses of third-party libraries used in .NET, respectively.

- (9,10) **dotnet.1.gz, dotnet** `dotnet.1.gz` is the dotnet manual page. `dotnet` is a symlink to the dotnet host(1). These files are installed at well-known locations for system integration.

- (11,12) **Microsoft.NETCore.App.Ref,Microsoft.AspNetCore.App.Ref** describe the API of an `x.y` version of .NET and ASP.NET Core respectively. These packs are used when compiling for those target versions.

- (13) **Microsoft.NETCore.App.Host.\<rid>** contains a native binary for platform `rid`. This binary is a template when compiling a .NET application into a native binary for that platform.

- (14) **Microsoft.WindowsDesktop.App.Ref** describes the API of `x.y` version of Windows Desktop applications. These files are used when compiling for that target. This isn't provided on non-Windows platforms.

- (15) **NETStandard.Library.Ref** describes the netstandard `x.y` API. These files are used when compiling for that target.

- (16) **/etc/dotnet/install_location** is a file that contains the full path for `{dotnet_root}`. The path may end with a newline. It's not necessary to add this file when the root is `/usr/share/dotnet`.

- (17) **templates** contains the templates used by the SDK. For example, `dotnet new` finds project templates here.

- (18) **Microsoft.NETCore.App.Runtime.\<rid>/\<runtime version>,Microsoft.AspNetCore.App.Runtime.\<rid>/\<aspnetcore version>** These files enable building self-contained applications. These directories contain symbolic links to files in (2), (5) and (6).

- (19) **runtime.\<rid>.Microsoft.DotNet.ILCompiler/\<runtime version>** These files enable building NativeAOT applications on the target platform.
- (20) **Microsoft.NETCore.App.Runtime.NativeAOT.\<rid>/\<runtime version>** These files enable building NativeAOT applications for the target platform.

- (21) **library-packs** contains NuGet package files. The SDK is configured to use this folder as a NuGet source. The list of NuGet packages provided by a .NET build is described below.

The folders marked with `(*)` are used by multiple packages. Some package formats (for example, `rpm`) require special handling of such folders. The package maintainer must take care of this.

Package files added to `library-packs` (21) can be packages that Microsoft does not distribute for the target platform. The files can also be packages that Microsoft distributes and for which `library-packs` provides a package that was built from source to meet platform package distribution guidelines. The following packages are included by the .NET build:

| Package name | Published by Microsoft | Needed for |
|----|----|----|
| `Microsoft.DotNet.ILCompiler.<version>.nupkg`<br>`Microsoft.NET.ILLink.Tasks.<version>.nupkg` | &#x2611; | NativeAOT |

## Recommended packages

.NET versioning is based on the runtime component `[major].[minor]` version numbers.
The SDK version uses the same `[major].[minor]` and has an independent `[patch]` that combines feature and patch semantics for the SDK.
For example: SDK version 7.0.302 is the second patch release of the third feature release of the SDK that supports the 7.0 runtime. For more information about how versioning works, see [.NET versioning overview](./versions/index.md).

Some of the packages include part of the version number in their name. This allows you to install a specific version.
The rest of the version isn't included in the version name. This allows the OS package manager to update the packages (for example, automatically installing security fixes). Supported package managers are Linux specific.

The following lists the recommended packages:

- `dotnet-sdk-[major].[minor]` - Installs the latest SDK for specific runtime
  - **Version:** \<sdk version>
  - **Example:** dotnet-sdk-7.0
  - **Contains:** (3),(4),(18),(21)
  - **Dependencies:** `dotnet-runtime-[major].[minor]`, `aspnetcore-runtime-[major].[minor]`, `dotnet-targeting-pack-[major].[minor]`, `aspnetcore-targeting-pack-[major].[minor]`, `netstandard-targeting-pack-[netstandard_major].[netstandard_minor]`, `dotnet-apphost-pack-[major].[minor]`, `dotnet-templates-[major].[minor]`

- `dotnet-sdk-aot-[major].[minor]` - Installs the SDK components for platform NativeAOT
  - **Version:** \<sdk version>
  - **Example:** dotnet-sdk-aot-9.0
  - **Contains:** (19, 20)
  - **Dependencies:** `dotnet-sdk-[major].[minor]`, _compiler toolchain and developer packages for libraries that the .NET runtime depends on_

- `aspnetcore-runtime-[major].[minor]` - Installs a specific ASP.NET Core runtime
  - **Version:** \<aspnetcore runtime version>
  - **Example:** aspnetcore-runtime-7.0
  - **Contains:** (6)
  - **Dependencies:** `dotnet-runtime-[major].[minor]`

- `dotnet-runtime-deps-[major].[minor]` _(Optional)_ - Installs the dependencies for running self-contained applications
  - **Version:** \<runtime version>
  - **Example:** dotnet-runtime-deps-7.0
  - **Dependencies:** _distribution-specific dependencies_

- `dotnet-runtime-[major].[minor]` - Installs a specific runtime
  - **Version:** \<runtime version>
  - **Example:** dotnet-runtime-7.0
  - **Contains:** (5)
  - **Dependencies:** `dotnet-hostfxr-[major].[minor]`, `dotnet-runtime-deps-[major].[minor]`

- `dotnet-hostfxr-[major].[minor]` - dependency
  - **Version:** \<runtime version>
  - **Example:** dotnet-hostfxr-7.0
  - **Contains:** (2)
  - **Dependencies:** `dotnet-host`

- `dotnet-host` - dependency
  - **Version:** \<runtime version>
  - **Example:** dotnet-host
  - **Contains:** (1),(8),(9),(10),(16)

- `dotnet-apphost-pack-[major].[minor]` - dependency
  - **Version:** \<runtime version>
  - **Contains:** (13)

- `dotnet-targeting-pack-[major].[minor]` - Allows targeting a non-latest runtime
  - **Version:** \<runtime version>
  - **Contains:** (12)

- `aspnetcore-targeting-pack-[major].[minor]` - Allows targeting a non-latest runtime
  - **Version:** \<aspnetcore runtime version>
  - **Contains:** (11)

- `netstandard-targeting-pack-[netstandard_major].[netstandard_minor]` - Allows targeting a netstandard version
  - **Version:** \<sdk version>
  - **Contains:** (15)

- `dotnet-templates-[major].[minor]`
  - **Version:** \<sdk version>
  - **Contains:** (17)

The following two meta packages are optional. They bring value for end users in that they abstract the top-level package (dotnet-sdk), which simplifies the installation of the full set of .NET packages. These meta packages reference a specific .NET SDK version.

- `dotnet[major]` - Installs the specified SDK version
  - **Version:** \<sdk version>
  - **Example:** dotnet7
  - **Dependencies:** `dotnet-sdk-[major].[minor]`

- `dotnet` - Installs a specific SDK version determined by distros to be the primary version&mdash;usually the latest available
  - **Version:** \<sdk version>
  - **Example:** dotnet
  - **Dependencies:** `dotnet-sdk-[major].[minor]`

The `dotnet-runtime-deps-[major].[minor]` requires understanding the _distro-specific dependencies_. Because the distro build system may be able to derive this automatically, the package is optional, in which case these dependencies are added directly to the `dotnet-runtime-[major].[minor]` package.

When package content is under a versioned folder, the package name `[major].[minor]` match the versioned folder name. For all packages, except the `netstandard-targeting-pack-[netstandard_major].[netstandard_minor]`, this also matches with the .NET version.

Dependencies between packages should use an _equal or greater than_ version requirement. For example, `dotnet-sdk-7.0:7.0.401` requires `aspnetcore-runtime-7.0 >= 7.0.6`. This makes it possible for the user to upgrade their installation via a root package (for example, `dnf update dotnet-sdk-7.0`).

Most distributions require all artifacts to be built from source. This has some impact on the packages:

- The third-party libraries under `shared/Microsoft.AspNetCore.All` can't be easily built from source. So that folder is omitted from the `aspnetcore-runtime` package.

- The `NuGetFallbackFolder` is populated using binary artifacts from `nuget.org`. It should remain empty.

Multiple `dotnet-sdk` packages may provide the same files for the `NuGetFallbackFolder`. To avoid issues with the package manager, these files should be identical (checksum, modification date, and so on).

### Debug packages

Debug content should be packaged in debug-named packages that follow the .NET package split described previously in this article. For instance, debug content for the `dotnet-sdk-[major].[minor]` package should be included in a package named `dotnet-sdk-dbg-[major].[minor]`. You should install debug content to the same location as the binaries.

Here are a few binary examples:

In the `{dotnet_root}/sdk/<sdk version>` directory, the following two files are expected:

- `dotnet.dll` - installed with `dotnet-sdk-[major].[minor]` package
- `dotnet.pdb` - installed with `dotnet-sdk-dbg-[major].[minor]` package

In the `{dotnet_root}/shared/Microsoft.NETCore.App/<runtime version>` directory, the following two files are expected:

- `System.Text.Json.dll` - installed with `dotnet-runtime-[major].[minor]` package
- `System.Text.Json.pdb` - installed with `dotnet-runtime-dbg-[major].[minor]` package

In the `{dotnet_root/shared/Microsoft.AspNetCore.App/<aspnetcore version>` directory, the following two files are expected:

- `Microsoft.AspNetCore.Routing.dll` - installed with `aspnetcore-runtime-[major].[minor]` packages
- `Microsoft.AspNetCore.Routing.pdb` - installed with `aspnetcore-runtime-dbg-[major].[minor]` packages

Starting with .NET 8.0, all .NET debug content (PDB files), produced by source-build, is available in a tarball named `dotnet-symbols-sdk-<version>-<rid>.tar.gz`. This archive contains PDBs in subdirectories that match the directory structure of the .NET SDK tarball - `dotnet-sdk-<version>-<rid>.tar.gz`.

While all debug content is available in the debug tarball, not all debug content is equally important. End users are mostly interested in the content of the `shared/Microsoft.AspNetCore.App/<aspnetcore version>` and `shared/Microsoft.NETCore.App/<runtime version>` directories.

The SDK content under `sdk/<sdk version>` is useful for debugging .NET SDK toolsets.

The following packages are the recommended debug packages:

- `aspnetcore-runtime-dbg-[major].[minor]` - Installs debug content for a specific ASP.NET Core runtime
  - **Version:** \<aspnetcore runtime version>
  - **Example:** aspnetcore-runtime-dbg-8.0
  - **Contains:** debug content for (6)
  - **Dependencies:** `aspnetcore-runtime-[major].[minor]`

- `dotnet-runtime-dbg-[major].[minor]` - Installs debug content for a specific runtime
  - **Version:** \<runtime version>
  - **Example:** dotnet-runtime-dbg-8.0
  - **Contains:** debug content for (5)
  - **Dependencies:** `dotnet-runtime-[major].[minor]`

The following debug package is optional:

- `dotnet-sdk-dbg-[major].[minor]` - Installs debug content for a specific SDK version
  - **Version:** \<sdk version>
  - **Example:** dotnet-sdk-dbg-8.0
  - **Contains:** debug content for (3),(4),(18)
  - **Dependencies:** `dotnet-sdk-[major].[minor]`

The debug tarball also contains some debug content under `packs`, which represents copies of content under `shared`. In the .NET layout, the `packs` directory is used for *building* .NET applications. There are no debugging scenarios, so you shouldn't package the debug content under `packs` in the debug tarball.

## Building packages

The [dotnet/source-build](https://github.com/dotnet/source-build) repository provides instructions on how to build a source tarball of the .NET SDK and all its components. The output of the source-build repository matches the layout described in the first section of this article.
