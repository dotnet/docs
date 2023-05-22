---
title: How to install the .NET Upgrade Assistant
description: This article describes how to install the .NET Upgrade Assistant tool, which can be installed as a Visual Studio extension or a dotnet command-line tool.
author: adegeo
topic: how-to
ms.date: 05/16/2023
---
# Install the .NET Upgrade Assistant

The .NET Upgrade Assistant can be installed as a Visual Studio extension or as a .NET command-line tool. When installed as a Visual Studio extension, loaded projects can be upgraded through the context menu. The .NET command-line tool version of the tool provides an interactive step-by-step expreience. For more information about the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

### Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.1 or later](https://visualstudio.microsoft.com/downloads/)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0), for the command-line tool

## Install the Visual Studio extension

The .NET Upgrade Assistant can be installed as a Visul Studio extension, which lets you upgrade an opened project. Use the following steps to install the .NET Upgrade Assistant from inside Visual Studio. Alternatively, you can download and install the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant).

01. With Visual Studio opened, press the **Extensions** > **Manage Extensions** menu item, which opens the **Manage Extensions** window.
01. In the **Manage Extensions** window, enter *upgrade* into the search input box.
01. Select the **.NET Upgrade Assistant** item, and then select **Download**.

    :::image type="content" source="media/upgrade-assistant-install/visual-studio-manage-extensions.png" alt-text="The manage extensions window in Visual Studio, showing the .NET Upgrade Assistant.":::

01. Once the extension has been downloaded, close Visual Studio. This starts the installation of the extension:

    :::image type="content" source="media/upgrade-assistant-install/install-prompt.png" alt-text="A prompt to install the .NET Upgrade Assistant extension.":::

01. Select **Modify** and follow the directions to install the extension.

## Install the .NET global tool

The .NET Upgrade Assistant is also available as a .NET global tool. You can install install the tool with the following command:

```dotnetcli
dotnet tool install -g upgrade-assistant
```

Similarly, because the .NET Upgrade Assistant is installed as a .NET tool, it can be easily updated by running:

```dotnetcli
dotnet tool update -g upgrade-assistant
```

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors:
>
> ```dotnetcli
> dotnet tool install -g --ignore-failed-sources upgrade-assistant
> ```
