---
title: .NET Uninstall Tool overview
description: An overview of .NET Uninstall Tool. This tool is a guided command-line tool that removes .NET SDKs and runtimes.
author: adegeo
ms.custom: devdivchpfy22
ms.date: 08/04/2024
zone_pivot_groups: operating-systems-set-three
ms.topic: article
---

# .NET uninstall tool overview

The .NET Uninstall tool automates removing .NET SDKs and runtimes from your system. The tool supports Windows and macOS. Linux isn't supported.

> [!div class="nextstepaction"]
> [Download .NET Uninstall Tool from GitHub](https://aka.ms/dotnet-core-uninstall-tool)

## Limitations

::: zone pivot="os-windows"

The tool can only uninstall .NET SDKs and runtimes that were installed using one of the following methods:

- Installed with a .NET SDK or .NET Runtime installer.
- Installed by the Visual Studio Installer, but only for **Visual Studio 2019 16.3 and earlier**.

::: zone-end

::: zone pivot="os-macos"

The tool can only uninstall SDKs and runtimes located in the _/usr/local/share/dotnet_ folder.

::: zone-end

Because of these limitations, the tool might not be able to uninstall all of the .NET SDKs and runtimes on your machine. You can use the `dotnet --info` command to find all of the .NET SDKs and runtimes installed, including those SDKs and runtimes that the tool can't remove. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool.

## Install the tool

You can download .NET Uninstall Tool from [the tool's releases page](https://aka.ms/dotnet-core-uninstall-tool) and find the source code at the [dotnet/cli-lab](https://github.com/dotnet/cli-lab) GitHub repository.

To install the tool, perform the following steps:

::: zone pivot="os-windows"

1. Download the _dotnet-core-uninstall-\*.msi_ installer from the [the GitHub releases page](https://aka.ms/dotnet-core-uninstall-tool).
1. Run the installer.

::: zone-end

::: zone pivot="os-macos"

01. Download the _dotnet-core-uninstall.tar.gz_ tarball from the [the GitHub releases page](https://aka.ms/dotnet-core-uninstall-tool).
01. Run the following shell script to extract the tarball to a directory named _dotnet-core-uninstall_ in your home directory:

    ```bash
    mkdir -p ~/dotnet-core-uninstall
    tar -zxf dotnet-core-uninstall.tar.gz -C ~/dotnet-core-uninstall
    ```

::: zone-end

> [!IMPORTANT]
> The tool requires administrative privileges to uninstall .NET SDKs and runtimes. Therefore, it should be installed in a write-protected directory such as _C:\Program Files_ on Windows or _/usr/local/bin_ on macOS. For more information, see [Elevated access for dotnet commands](../tools/elevated-access.md).

## Uninstall the tool

::: zone pivot="os-windows"

To uninstall the tool, perform the following steps:

1. Open the Start menu.
1. Search for **Add or Remove Programs** and open it.
1. Search for `Microsoft .NET SDK Uninstall Tool`.
1. Select **Uninstall**.

::: zone-end

::: zone pivot="os-macos"

If you extracted the _dotnet-core-uninstall.tar.gz_ tarball, delete the extracted files.

::: zone-end

## Commands

- [dotnet-core-uninstall list](uninstall-tool-cli-list.md)
- [dotnet-core-uninstall dry-run](uninstall-tool-cli-dry-run.md)
- [dotnet-core-uninstall remove](uninstall-tool-cli-remove.md)
