---
title: .NET SDK overview
description: Learn about the .NET SDK (formerly known as the .NET Core SDK), which is a set of libraries and tools used to create .NET projects.
ms.date: 08/10/2023
ms.topic: concept-article
---
# What is the .NET SDK?

The .NET SDK is a set of libraries and tools that developers use to create .NET applications and libraries. It contains the following components that are used to build and run applications:

- The [.NET CLI](tools/index.md).
- The [.NET runtime and libraries](introduction.md).
- The `dotnet` [driver](tools/index.md#driver).

## How to install the .NET SDK

As with any tooling, the first step is to get the tools on your machine. Depending on your scenario, you can install the SDK using one of the following methods:

- Use the native installers.
- Use the installation shell script.

The native installers are primarily meant for development machines. The SDK is distributed using each supported platform's
native install mechanism, such as DEB packages on Ubuntu or MSI bundles on Windows. These installers install
and set up the environment as needed for the user to use the SDK immediately after the install. However, they also
require administrative privileges on the machine. You can find the SDK to install on the
[.NET downloads](https://dotnet.microsoft.com/download) page.

Install scripts, on the other hand, don't require administrative privileges. However, they also don't install any
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for
setting up build servers or when you wish to install the tools without admin privileges. You can find more information in the [install script reference](tools/dotnet-install-script.md) article. For information on setting up the SDK on your CI build server, see [Use the .NET SDK in Continuous Integration (CI) environments](../devops/dotnet-cli-and-continuous-integration.md).

By default, the SDK installs in a "side-by-side" (SxS) manner, which means multiple versions
can coexist on a single machine. For information about how the version gets picked when you run CLI commands, see [Select the .NET version to use](versions/selection.md).

## Security guide

> [!IMPORTANT]
> The .NET SDK locates and executes various tools that ship as separate executable binaries in the SDK. In most cases, the SDK is able to determine the full path to the executable. However, there are exceptions where the SDK cannot determine the path and relies on user input. It's possible that a user can provide input that causes the .NET SDK to execute malicious software. For this reason, you shouldn't trust any repos with binaries that match specific file names in the SDK install location, for example, *msbuild.exe*. The SDK installs to a versioned folder such as *C:\Program Files\dotnet\sdk\7.0.400\\* on Windows or */usr/bin/share/dotnet/sdk/7.0.400* on Linux.

## See also

- [.NET downloads](https://dotnet.microsoft.com/download)
- [.NET CLI overview](tools/index.md)
- [.NET versioning overview](versions/index.md)
- [How to remove the .NET runtime and SDK](install/remove-runtime-sdk-versions.md)
- [Select the .NET version to use](versions/selection.md)
