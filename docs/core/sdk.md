---
title: .NET SDK overview
description: Learn about the .NET SDK (formerly known as the .NET Core SDK), which is a set of libraries and tools used to create .NET projects.
ms.date: 07/14/2022
ms.technology: dotnet-cli
---
# What is the .NET SDK?

The .NET SDK is a set of libraries and tools that allow developers to create .NET applications and libraries. It contains the following components that are used to build and run applications:

- The [.NET CLI](tools/index.md).
- The [.NET runtime and libraries](introduction.md).
- The `dotnet` [driver](tools/index.md#driver).

## How to install the .NET SDK

As with any tooling, the first thing is to get the tools on your machine. Depending on your scenario, you can install the SDK using one of the following methods:

- Use the native installers.
- Use the installation shell script.

The native installers are primarily meant for developers' machines. The SDK is distributed using each supported platform's
native install mechanism, such as DEB packages on Ubuntu or MSI bundles on Windows. These installers install
and set up the environment as needed for the user to use the SDK immediately after the install. However, they also
require administrative privileges on the machine. You can find the SDK to install on the
[.NET downloads](https://dotnet.microsoft.com/download) page.

Install scripts, on the other hand, don't require administrative privileges. However, they also don't install any
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for
setting up build servers or when you wish to install the tools without admin privileges (do note the prerequisites
caveat above). You can find more information in the [install script reference](tools/dotnet-install-script.md) article. If you're
interested in how to set up the SDK on your CI build server, see [Use the .NET SDK in Continuous Integration (CI) environments](../devops/dotnet-cli-and-continuous-integration.md).

By default, the SDK installs in a "side-by-side" (SxS) manner, which means multiple versions
can coexist at any given time on a single machine. For information about how the version gets picked when you're running CLI commands, see [Select the .NET version to use](versions/selection.md).

## See also

- [.NET downloads](https://dotnet.microsoft.com/download)
- [.NET CLI overview](tools/index.md)
- [.NET versioning overview](versions/index.md)
- [How to remove the .NET runtime and SDK](install/remove-runtime-sdk-versions.md)
- [Select the .NET version to use](versions/selection.md)
