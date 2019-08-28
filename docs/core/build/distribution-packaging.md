---
title: .NET Core distribution packaging
description: Learn how to package, name, and version .NET Core for distribution.
author: tmds
ms.date: 03/02/2018
ms.custom: "seodec18"
---
# .NET Core distribution packaging

As .NET Core becomes available on more and more platforms, it's useful to learn how to package, name, and version it. This way, package maintainers can help ensure a consistent experience no matter where users choose to run .NET. This article is useful for users that are:

* Attempting to build .NET Core from source.
* Wanting to make changes to the .NET Core CLI that could impact the resulting layout or packages produced.

## Disk layout

When installed, .NET Core consists of several components that are laid out as follows in the filesystem:

```
.
├── dotnet                       (1)
├── LICENSE.txt                  (8)
├── ThirdPartyNotices.txt        (8)
├── host
│   └── fxr
│       └── <fxr version>        (2)
├── sdk
│   ├── <sdk version>            (3)
│   └── NuGetFallbackFolder      (4)
├── packs
│   ├── Microsoft.AspNetCore.App.Ref
│   │   └── <aspnetcore ref version>     (11)
│   ├── Microsoft.NETCore.App.Ref
│   │   └── <netcore ref version>        (12)
│   ├── Microsoft.NETCore.App.Host.<rid>
│   │   └── <apphost version>            (13)
│   ├── Microsoft.WindowsDesktop.App.Ref
│   │   └── <desktop ref version>        (14)
│   └── NETStandard.Library.Ref
│       └── <netstandard version>        (15)
├── shared
│   ├── Microsoft.NETCore.App
│   │   └── <runtime version>    (5)
│   ├── Microsoft.AspNetCore.App
│   │   └── <aspnetcore version> (6)
│   └── Microsoft.AspNetCore.All
│       └── <aspnetcore version> (7)
└── templates
│   └── <templates version>      (17)
/
├── etc/dotnet
│       └── install_location     (16)
├── usr/share/man/man1
│       └── dotnet.1.gz          (9)
└── usr/bin
        └── dotnet               (10)
```

- (1) **dotnet** The host (also known as the "muxer") has two distinct roles: activate a runtime to launch an application, and activate an SDK to dispatch commands to it. The host is a native executable (`dotnet.exe`).

While there's a single host, most of the other components are in versioned directories (2,3,5,6). This means multiple versions can be present on the system since they're installed side by side.

- (2) **host/fxr/\<fxr version>** contains the framework resolution logic used by the host. The host uses the latest hostfxr that is installed. The hostfxr is responsible for selecting the appropriate runtime when executing a .NET Core application. For example, an application built for .NET Core 2.0.0 uses the 2.0.5 runtime when it's available. Similarly, hostfxr selects the appropriate SDK during development.

- (3) **sdk/\<sdk version>** The SDK (also known as "the tooling") is a set of managed tools that are used to write and build .NET Core libraries and applications. The SDK includes the .NET Core Command-line interface (CLI), the managed languages compilers, MSBuild, and associated build tasks and targets, NuGet, new project templates, and so on.

- (4) **sdk/NuGetFallbackFolder** contains a cache of NuGet packages used by an SDK during the restore operation, such as when running `dotnet restore` or `dotnet build /t:Restore`. This folder is only used prior to .NET Core 3.0. It can't be built from source, because it contains prebuilt binary assets from `nuget.org`.

The **shared** folder contains frameworks. A shared framework provides a set of libraries at a central location so they can be used by different applications.

- (5) **shared/Microsoft.NETCore.App/\<runtime version>** This framework contains the .NET Core runtime and supporting managed libraries.

- (6,7) **shared/Microsoft.AspNetCore.{App,All}/\<aspnetcore version>** contains the ASP.NET Core libraries. The libraries under `Microsoft.AspNetCore.App` are developed and supported as part of the .NET Core project. The libraries under `Microsoft.AspNetCore.All` are a superset that also contains third-party libraries.

- (8) **LICENSE.txt,ThirdPartyNotices.txt** are the .NET Core license and licenses of third-party libraries used in .NET Core, respectively.

- (9,10) **dotnet.1.gz, dotnet** `dotnet.1.gz` is the dotnet manual page. `dotnet` is a symlink to the dotnet host(1). These files are installed at well known locations for system integration.

- (11,12) **Microsoft.NETCore.App.Ref,Microsoft.AspNetCore.App.Ref** describe the API of an `x.y` version of .NET Core and ASP.NET Core respectively. These packs are used when compiling for those target versions.

- (13) **Microsoft.NETCore.App.Host.\<rid>** contains a native binary for platform `rid`. This binary as a template when compiling a .NET Core application into a native binary for that platform.

- (14) **Microsoft.WindowsDesktop.App.Ref** describes the API of `x.y` version of Windows Desktop applications. These files are used when compiling for that target. This isn't provided on non-Windows platforms.

- (15) **NETStandard.Library.Ref** describes the netstandard `x.y` API. These files are used when compiling for that target.

- (16) **/etc/dotnet/install_location** file that contains the full path to the folder that contains the `dotnet` host binary. The path may be terminated with a newline. It's not necessary to add this file when the root is `/usr/share/dotnet`.

- (17) **templates** templates used by the sdk.

## Recommended packages

.NET Core versioning is based on the runtime component `[major].[minor]` version numbers.
The SDK version uses the same `[major].[minor]` and has an independent `[patch]` that combines feature and patch semantics for the SDK.
For example: SDK version 2.2.302 is the second patch release of the third feature release of the SDK that supports the 2.2 runtime. For more information about how versioning works, see [.NET Core versioning overview](../versions/index.md).

Some of the packages include part of the version number in their name. This allows you to install a specific version.
The rest of the version isn't included in the version name. This allows the OS package manager to update the packages (for example, automatically installing security fixes). Supported package managers are Linux specific.

The following lists the recommended packages:

* `dotnet-sdk-[major].[minor]` - Installs the latest sdk for specific runtime
  * **Version:** \<runtime version>
  * **Example:** dotnet-sdk-2.1
  * **Contains:** (3),(4)
  * **Dependencies:** `aspnetcore-runtime-[major].[minor]`, `dotnet-netcoreapp-targeting-pack-[major].[minor]`, `aspnetcore-targeting-pack-[major].[minor]`, `netstandard-targeting-pack-[netstandard_major].[netstandard_minor]`, `dotnet-apphost-pack-[major].[minor]`

* `aspnetcore-runtime-[major].[minor]` - Installs specific ASP.NET Core runtime
  * **Version:** \<aspnetcore runtime version>
  * **Example:** aspnetcore-runtime-2.1
  * **Contains:** (6),(7)
  * **Dependencies:** `dotnet-runtime-[major].[minor]`

* `dotnet-runtime-deps-[major].[minor]` _(Optional)_ - Installs the dependencies for running self-contained applications
  * **Version:** \<runtime version>
  * **Example:** dotnet-runtime-deps-2.1
  * **Dependencies:** _distro specific dependencies_

* `dotnet-runtime-[major].[minor]` - Installs a specific runtime
  * **Version:** \<runtime version>
  * **Example:** dotnet-runtime-2.1
  * **Contains:** (5)
  * **Dependencies:** `dotnet-hostfxr:<runtime version>+`, `dotnet-runtime-deps-[major].[minor]`

* `dotnet-hostfxr` - dependency
  * **Version:** \<runtime version>
  * **Example:** dotnet-hostfxr
  * **Contains:** (2)
  * **Dependencies:** `host:<runtime version>+`

* `dotnet-host` - dependency
  * **Version:** \<runtime version>
  * **Example:** dotnet-host
  * **Contains:** (1),(8),(9),(10),(16)

* `dotnet-apphost-pack-[major].[minor]` - dependency
  * **Version:** \<sdk version>
  * **Contains:** (13)

* `dotnet-targeting-pack-[major].[minor]` - Allows targeting a non-latest runtime
  * **Version:** \<sdk version>
  * **Contains:** (12)

* `aspnetcore-targeting-pack-[major].[minor]` - Allows targeting a non-latest runtime
  * **Version:** \<sdk version>
  * **Contains:** (11)

* `netstandard-targeting-pack-[major].[minor]` - Allows targeting a netstandard version
  * **Version:** \<sdk version>
  * **Contains:** (15)

* `dotnet-templates-[major].[minor]`
  * **Version:** \<sdk version>
  * **Contains:** (15)

The `dotnet-runtime-deps-[major].[minor]` requires understanding the _distro specific dependencies_. Because the distro build system may be able to derive this automatically, the package is optional, in which case these dependencies are added directly to the `dotnet-runtime-[major].[minor]` package.

When package content is under a versioned folder, the package name `[major].[minor]` match the versioned folder name. For all packages, except the `netstandard-targeting-pack-[major].[minor]`, this also matches with the .NET Core version.

Dependencies between packages should use a _equal or greater than_ version requirement. For example, `dotnet-sdk-2.2:2.2.6` requires `aspnetcore-runtime-2.2 >= 2.2.6`. This makes it possible for the user to upgrade their installation via a root package (e.g. `dnf update dotnet-sdk-2.2`).

Most distributions require all artifacts to be built from source. This has some impact on the packages:

- The third-party libraries under `shared/Microsoft.AspNetCore.All` can't be easily built from source. So that folder is omitted from the `aspnetcore-runtime` package.

- The `NuGetFallbackFolder` is populated using binary artifacts from `nuget.org`. It should remain empty.

Multiple `dotnet-sdk` packages may provide the same files for the `NuGetFallbackFolder`. To avoid issues with the package manager, these files should be identical (checksum, modification date, and so on).

## Building packages

The [dotnet/source-build](https://github.com/dotnet/source-build) repository provides instructions on how to build a source tarball of the .NET Core SDK and all its components. The output of the source-build repository matches the layout described in the first section of this article.
