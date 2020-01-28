---
title: .NET Core SDK overview
description: Learn about the .NET Core SDK and how to install it.
ms.date: 01/28/2020
ms.topic: conceptual
---
# .NET Core SDKs and project files

The .NET Core SDK is a set of libraries and tools that allow developers to create .NET Core applications and libraries. It contains the following components that are used to build and run applications:

- The .NET Core CLI tools.
- .NET Core libraries and runtime.
- The `dotnet` [driver](tools/index.md#driver).

.NET Core projects are associated with a .NET software development kit (SDK). These SDKs, as the [layering document](../tools/cli-msbuild-architecture.md) describes, are a set of MSBuild [tasks](/visualstudio/msbuild/msbuild-tasks) and [targets](/visualstudio/msbuild/msbuild-targets) that can build .NET Core code. The following SDKs are available for .NET Core:

| Description | ID | Introduced version |
| - | - | - |
| The .NET Core SDK | `Microsoft.NET.Sdk` |
| The .NET Core web SDK | `Microsoft.NET.Sdk.Web` |
| The .NET Core Razor Class Library SDK | `Microsoft.NET.Sdk.Razor` |
| The .NET Core Worker Service SDK | `Microsoft.NET.Sdk.Worker` | .NET Core 3.0 |
| The .NET Core WinForms and WPF SDK | `Microsoft.NET.Sdk.WindowsDesktop` | .NET Core 3.0 |

## Acquire the .NET Core SDK

As with any tooling, the first thing is to get the tools to your machine. Depending on your scenario, you can install the SDK using one of the following methods:

- Use the native installers.
- Use the installation shell script.

The native installers are primarily meant for developer's machines. The SDK is distributed using each supported platform's
native install mechanism, such as DEB packages on Ubuntu or MSI bundles on Windows. These installers install
and set up the environment as needed for the user to use the SDK immediately after the install. However, they also
require administrative privileges on the machine. You can find the SDK to install on the
[.NET downloads](https://dotnet.microsoft.com/download) page.

Install scripts, on the other hand, don't require administrative privileges. However, they also don't install any
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for
setting up build servers or when you wish to install the tools without admin privileges (do note the prerequisites
caveat above). You can find more information in the [install script reference](tools/dotnet-install-script.md) article. If you're
interested in how to set up the SDK on your CI build server, see the [Using .NET Core SDK and tools in Continuous Integration (CI)](tools/using-ci-with-cli.md) article.

By default, the SDK installs in a "side-by-side" (SxS) manner, which means multiple versions of the CLI tools
can coexist at any given time on a single machine. How the version gets picked when you're running CLI commands is explained in more detail in the [Select the .NET Core version to use](versions/selection.md) article.

## Project files

.NET Core projects are based on the [MSBuild](/visualstudio/msbuild/msbuild) format. Project files are in XML format. Each property in the file can have attributes and subitems.

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [.NET Core run-time configuration settings](../run-time-config/index.md)
-
-



## See also

- [.NET Core CLI](tools/index.md)
- [.NET Core versioning overview](versions/index.md)
- [How to remove the .NET Core runtime and SDK](versions/remove-runtime-sdk-versions.md)
- [Select the .NET Core version to use](versions/selection.md)
