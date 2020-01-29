---
title: .NET Core SDK overview
description: Learn about the .NET Core SDK and how to install it.
ms.date: 01/28/2020
ms.topic: conceptual
---
# .NET Core SDKs and project files

.NET Core projects are associated with a .NET software development kit (SDK). These SDKs, as the [layering document](../tools/cli-msbuild-architecture.md) describes, are a set of MSBuild [tasks](/visualstudio/msbuild/msbuild-tasks) and [targets](/visualstudio/msbuild/msbuild-targets) that can build .NET Core code. The following SDKs are available for .NET Core:

| Description | ID | Introduced version |
| - | - | - |
| .NET Core SDK | `Microsoft.NET.Sdk` |
| [.NET Core web SDK](/aspnet/core/razor-pages/web-sdk) | `Microsoft.NET.Sdk.Web` |
| [.NET Core Razor Class Library SDK](/aspnet/core/razor-pages/sdk) | `Microsoft.NET.Sdk.Razor` |
| .NET Core Worker Service SDK | `Microsoft.NET.Sdk.Worker` | .NET Core 3.0 |
| .NET Core WinForms and WPF SDK | `Microsoft.NET.Sdk.WindowsDesktop` | .NET Core 3.0 |

The remainder of this article focuses on the .NET Core SDK.

The .NET Core SDK is a set of libraries and tools that allow developers to create .NET Core applications and libraries. It contains the following components that are used to build and run applications:

- .NET Core [CLI tools](tools/index.md)
- .NET Core libraries and runtime
- The `dotnet` [driver](tools/index.md#driver)

## Acquire the .NET Core SDK

You can [install the SDK](../install/sdk.md) using native installers or installation scripts.

The native installers are primarily meant for developer's machines. The SDK is distributed using each supported platform's native install mechanism, such as DEB packages on Ubuntu or MSI bundles on Windows. These installers install
and set up the environment as needed for the user to use the SDK immediately after the install. However, they also require administrative privileges on the machine. You can find the SDK to install on the [.NET downloads](https://dotnet.microsoft.com/download) page.

Installation scripts, on the other hand, don't require administrative privileges. However, they also don't install any prerequisites on the machine, and you must install all of the prerequisites manually. The scripts are meant mostly for setting up build servers or when you wish to install the tools without admin privileges. You can find more information in the [install script reference](tools/dotnet-install-script.md) article. For information about setting up the SDK on a CI build server, see [Using .NET Core SDK and tools in Continuous Integration (CI)](tools/using-ci-with-cli.md).

By default, the SDK installs in a "side-by-side" manner, which means multiple versions of the CLI tools can coexist on a single machine. For information about which version gets picked when you run CLI commands, see [Select the .NET Core version to use](versions/selection.md).

## Project files

.NET Core projects are based on the [MSBuild](/visualstudio/msbuild/msbuild) format. Project files are in XML format.

For information about MSBuild *properties* for the .NET Core SDK, see [MSBuild properties for .NET Core SDK projects](msbuild-props.md). For information about MSBuild *targets* for the .NET Core SDK, see [MSBuild targets for .NET Core SDK projects](msbuild-targets.md).

## See also

- [Install the SDK](../install/sdk.md)
- [.NET Core CLI](tools/index.md)
