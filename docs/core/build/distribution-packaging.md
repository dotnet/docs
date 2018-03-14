---
title: .NET Core distribution packaging
description: Learn how to package, name, and version .NET Core for distribution.
keywords: .NET, .NET Core, source, build
author: bleroy
ms.author: mairaw
ms.date: 06/28/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 71b9d722-c5a8-4271-9ce1-d87e7ae2494d
ms.workload: 
  - dotnetcore
---

# .NET Core distribution packaging

As .NET Core becomes available on more and more platforms, it's useful to learn how to package, name, and version it. This way, package maintainers can help ensure a consistent experience no matter where users choose to run .NET.

## Disk layout

When installed, .NET Core consists of several components that are layed out as follows in the filesystem:

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
└── shared
    ├── Microsoft.NETCore.App
    │   └── <runtime version>    (5)
    └── Microsoft.AspNetCore.App
        └── <aspnetcore version> (6)
    └── Microsoft.AspNetCore.All
        └── <aspnetcore version> (7)
/
├─usr/share/man/man1
│       └── dotnet.1.gz          (9)
└─usr/bin
        └── dotnet               (10)
```

- (1) **dotnet** The host (also known as the "muxer") has two distinct roles: activate a runtime to launch an application, and activate an SDK to dispatch commands to it. The host is a native executable (`dotnet.exe`).

While there is a single host, most of the other components are in versioned directories (2,3,5,6). These means multiple versions can be present on the system since they are installed side-by-side.

- (2) **host/fxr/\<fxr version>** contains the framework resolution logic used by the host. The host uses the latest hostfxr that is installed. The hostfxr is responsible for selecting the appropriate runtime when executing a .NET Core application. For example, an application built for .NET Core 2.0.0 will use the 2.0.5 runtime when it is available. Similarly, hostfxr selects the appropriate SDK during development.

- (3) **sdk/\<sdk version>** The SDK (also known as "the tooling") is a set of managed tools that can be used to write and build .NET Core libraries and applications. The SDK includes the CLI, the Roslyn compiler, MSBuild, and associated build tasks and targets, NuGet, new project templates, etc.

- (4) **sdk/NuGetFallbackFolder** contains a cache of NuGet packages used by an SDK during the `dotnet restore` step.

The **shared** folder contains frameworks. A shared framework provides a set of libraries at a central location so they can be used by different applications.

- (5) **shared/Microsoft.NETCore.App/\<runtime version>** This framework contains the .NET Core runtime and supporting managed libraries.

- (6,7) **shared/Microsoft.AspNetCore.{App,All}/\<aspnetcore version>** contains the ASP.NET Core libraries. The libraries under `Microsoft.AspNetCore.App` are developed and supported as part of the .NET Core project. The libraries under `Microsoft.AspNetCore.All` are a superset which also contains 3rd party libraries.

- (8) **LICENSE.txt,ThirdPartyNotices.txt** are the .NET Core license and licenses of third-party libraries used in .NET Core.

- (9,10) **dotnet.1.gz, dotnet** `dotnet.1.gz` is the dotnet man page. `dotnet` is a symlink to the dotnet host(1). These files are installed at well known locations for system integration.

## Recommended packages

.NET Core versioning is based on the runtime component `[major].[minor]` version numbers.
The SDK version uses the same `[major].[minor]` and has an independent `[patch]` which combines feature and patch semantics for the SDK.
For example: SDK version 2.2.302 is a the 2nd patch release of the 3rd feature release of the SDK that supports the 2.2 runtime.

Some of the packages include part of the version number in their name. This allows the end-user to install a specific version.
The remainder of the version is not included in the version name. This allows the OS package manager to update the packages (e.g. automatically installing security fixes).

The following tables shows the recommended packages.

| Name                                    | Example                | Use case: Install ...           | Contains           | Dependencies                                   | Version            |
|-----------------------------------------|------------------------|---------------------------------|--------------------|------------------------------------------------|--------------------|
| dotnet-sdk-[major]                      | dotnet-sdk-2           | Latest sdk for runtime major    |                    | dotnet-sdk-[major].[latestminor]               | \<sdk version>     |
| dotnet-sdk-[major].[minor]              | dotnet-sdk-2.1         | Latest sdk for specific runtime |                    | dotnet-sdk-[major].[minor].[latest sdk feat]xx | \<sdk version>     |
| dotnet-sdk-[major].[minor].[sdk feat]xx | dotnet-sdk-2.1.3xx     | Specific sdk feature release    | (3),(4)            | aspnetcore-runtime-[major].[minor]             | \<sdk version>     |
| aspnetcore-runtime-[major].[minor]      | aspnetcore-runtime-2.1 | Specific ASP.NET Core runtime   | (6),[(7)]          | dotnet-runtime-[major].[minor]                 | \<runtime version> |
| dotnet-runtime-[major].[minor]          | dotnet-runtime-2.1     | Specific runtime                | (5)                | host-fxr:\<runtime version>+                   | \<runtime version> |
| dotnet-host-fxr                         | dotnet-host-fxr        | _dependency_                    | (2)                | host:\<runtime version>+                       | \<runtime version> |
| dotnet-host                             | dotnet-host            | _dependency_                    | (1),(8),(9),(10)   |                                                | \<runtime version> |

Most distributions require all artifacts to be built from source. This has some impact on the packages:

- The 3rd party libraries under `shared/Microsoft.AspNetCore.All` cannot be easily built from source. So that folder is omitted from the `aspnetcore-runtime` package.

- The `NuGetFallbackFolder` is populated using binary artifacts from `nuget.org`. It should remain empty.

Multiple `dotnet-sdk` packages may provide the same files for the `NuGetFallbackFolder`. To avoid issues with the package manager, these files should be identical (checksum, modification date, ...).

#### Preview versions

Package maintainers may decide to provide preview versions of the shared framework and SDK. Preview releases may be provided using the `dotnet-sdk-[major].[minor].[sdk feat]xx`, `aspnetcore-runtime-[major].[minor]`, `dotnet-runtime-[major].[minor]` packages. For preview releases, the package version major must be set to zero. This way, the final release will be installed as an upgrade of the package.

#### Patch packages

Since a patch version of a packages may cause a breaking change, a package maintainer may want to provide _patch packages_. These packages allows to install a specific patch version which is not automatically upgraded. Patch packages should only be used in rare circumstances as they will not be upgraded with (security) fixes.

The following table shows the recommended packages and **patch packages**.

| Name                                           | Example                  | Contains         | Dependencies                                              |
|------------------------------------------------|--------------------------|------------------|-----------------------------------------------------------|
| dotnet-sdk-[major]                             | dotnet-sdk-2             |                  | dotnet-sdk-[major].[latest sdk minor]                     |
| dotnet-sdk-[major].[minor]                     | dotnet-sdk-2.1           |                  | dotnet-sdk-[major].[minor].[latest sdk feat]xx            |
| dotnet-sdk-[major].[minor].[sdk feat]xx        | dotnet-sdk-2.1.3xx       |                  | dotnet-sdk-[major].[minor].[latest sdk patch]             |
| **dotnet-sdk-[major].[minor].[patch]**         | dotnet-sdk-2.1.300       | (3),(4)          | aspnetcore-runtime-[major].[minor].[sdk runtime patch]    |
| aspnetcore-runtime-[major].[minor]             | aspnetcore-runtime-2.1   |                  | aspnetcore-runtime-[major].[minor].[latest runtime patch] |
| **aspnetcore-runtime-[major].[minor].[patch]** | aspnetcore-runtime-2.1.0 | (6),[(7)]        | dotnet-runtime-[major].[minor].[patch]                    |
| dotnet-runtime-[major].[minor]                 | dotnet-runtime-2.1       |                  | dotnet-runtime-[major].[minor].[latest runtime patch]     |
| **dotnet-runtime-[major].[minor].[patch]**     | dotnet-runtime-2.1.0     | (5)              | host-fxr:\<runtime version>+                              |
| dotnet-host-fxr                                | dotnet-host-fxr          | (2)              | host:\<runtime version>+                                  |
| dotnet-host                                    | dotnet-host              | (1),(8),(9),(10) |                                                           |

An alternative to using patch packages is _pinning_ the packages to a specific version using the package manager. To avoid affecting other applications/users, such applications can be built and deployed in a container.

## Building packages

The https://github.com/dotnet/source-build repository provides instructions on how to build a source tarball of the .NET Core SDK and all its components. The output of the source-build repository matches the layout described in the first section of this article.