---
title: .NET Uninstall Tool overview
description: An overview of .NET Uninstall Tool. This tool is a guided command-line tool that removes .NET SDKs and runtimes.
author: adegeo
ms.custom: devdivchpfy22
ms.date: 08/04/2024
zone_pivot_groups: operating-systems-set-three
---

# .NET uninstall tool overview

The .NET Uninstall tool automates removing .NET SDKs and runtimes from your system. The tool supports Windows and macOS. Linux isn't supported.

> [!div class="nextstepaction"]
> [Download .NET Uninstall Tool from GitHub](https://aka.ms/dotnet-core-uninstall-tool)

The tool supports Windows and macOS. Linux is currently not supported.

::: zone pivot="os-windows"

## Windows

The tool can only uninstall .NET SDKs and runtimes that were installed using one of the following methods:

- Installed with a .NET SDK or .NET Runtime installer.
- Installed by the Visual Studio Installer, but only for **Visual Studio 2019 16.3 and earlier**.

::: zone-end

::: zone pivot="os-macos"

## macOS

The tool can only uninstall SDKs and runtimes located in the _/usr/local/share/dotnet_ folder.

::: zone-end

Because of these limitations, the tool might not be able to uninstall all of the .NET SDKs and runtimes on your machine. You can use the `dotnet --info` command to find all of the .NET SDKs and runtimes installed, including those SDKs and runtimes that the tool can't remove. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool.

## Install the tool

You can download .NET Uninstall Tool from [the tool's releases page](https://aka.ms/dotnet-core-uninstall-tool) and find the source code at the [dotnet/cli-lab](https://github.com/dotnet/cli-lab) GitHub repository.

> [!NOTE]
> The tool requires administrative privileges to uninstall .NET SDKs and runtimes. Therefore, it should be installed in a write-protected directory such as _C:\Program Files_ on Windows or _/usr/local/bin_ on macOS. For more information, see [Elevated access for dotnet commands](../tools/elevated-access.md).

::: zone pivot="os-windows"

## Uninstall the tool

1. Open **Add or Remove Programs**.
2. Search for `Microsoft .NET SDK Uninstall Tool`.
3. Select **Uninstall**.

::: zone-end

::: zone pivot="os-macos"

## Uninstall the tool

If you extracted the _dotnet-core-uninstall.tar.gz_ tarball, delete the extracted files.

::: zone-end

## Commands

- [dotnet-core-uninstall list](uninstall-tool-cli-list.md)
- [dotnet-core-uninstall dry-run](uninstall-tool-cli-dry-run.md)
- [dotnet-core-uninstall remove](uninstall-tool-cli-remove.md)
