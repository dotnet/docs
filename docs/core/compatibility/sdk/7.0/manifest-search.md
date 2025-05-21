---
title: "Breaking change: Tool manifests in root folder"
description: Learn about a breaking change where the .NET SDK no longer looks for local tool manifests in the root folder on Windows.
ms.date: 07/28/2023
ms.topic: concept-article
---
# Tool manifests in root folder

.NET no longer looks for local tool manifest files in the root folder on Windows, unless overridden via the `DOTNET_TOOLS_ALLOW_MANIFEST_IN_ROOT` environment variable. This change does not impact Linux or macOS.

## Previous behavior

Previously, .NET SDK local tools checked the root folder on all platforms when searching for a tool manifest. The search continued from the current directory up the directory tree to the root folder until it found a manifest. At each level, .NET searches for the tool manifest, named *dotnet-tools.json*, in a *.config* subfolder. On a Windows system, if no other tool manifest was found, the SDK ultimately looked for a tool manifest in *C:\\.config\dotnet-tools.json*.

## New behavior

.NET no longer searches in the root folder of the current directory tree by default on Windows, unless overridden via the `DOTNET_TOOLS_ALLOW_MANIFEST_IN_ROOT` environment variable. `DOTNET_TOOLS_ALLOW_MANIFEST_IN_ROOT` is set to `false` by default.

## Version introduced

- .NET SDK 7.0.3xx
- .NET SDK 7.0.1xx
- .NET SDK 6.0.4xx
- .NET SDK 6.0.3xx
- .NET SDK 6.0.1xx
- .NET SDK 3.1.4xx

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to address a security concern. Since all users can create files and folders in the *C:\\* directory on Windows, low-privilege attackers can hijack the *C:\\.config\dotnet-tools.json* file. When an administrator runs a `dotnet` tool command, the tool could potentially read malicious configuration information from the file and download and run malicious tools.

## Recommended action

To disable the new behavior, set the `DOTNET_TOOLS_ALLOW_MANIFEST_IN_ROOT` environment variable to `true` or `1`.

## See also

- [Tutorial: Install and use a .NET local tool using the .NET CLI](../../../tools/local-tools-how-to-use.md)
