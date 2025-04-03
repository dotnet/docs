---
title: Install .NET Upgrade Assistant
description: "Learn how to install .NET Upgrade Assistant as a Visual Studio extension or a .NET Global Tool. .NET Upgrade Assistant assists you when upgrading projects to the latest dependencies or when upgrading to a new .NET"
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy
ms.date: 10/08/2024

#customer intent: As a developer, I want to install .NET Upgrade Assistant so that I can upgrade my projects.

---

# Install .NET Upgrade Assistant

This article teaches you how to install .NET Upgrade Assistant using either the Visual Studio extension or the command-line interface (CLI) tool.

## Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.1 or newer](https://visualstudio.microsoft.com/downloads/).
- [.NET SDK 8 or later](https://dotnet.microsoft.com/download/dotnet/).

## Methods

.NET Upgrade Assistant can be installed as a Visual Studio extension or as a .NET Global Tool.

The Visual Studio extension runs inside Visual Studio, on the solution or project you have open. The .NET Global Tool is an interactive console application that runs on a solution or project file at or below the current directory.

If you want the streamlined experience of opening a project in Visual Studio and upgrading it, install the extension.

## Visual Studio Extension

The following steps install the Visual Studio extension.

> [!TIP]
> As an alternative to using the **Manage Extensions** feature of Visual Studio, you can download and run the extensions installer from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.upgradeassistant).

01. Open Visual Studio.

    If the **Open Recent \ Get Started** window opens, select the **Continue without code** link.

01. Select the **Extensions** > **Manage Extensions** menu to open the **Extension Manager** window.
01. Select the **Browse** tab.
01. Type **.NET upgrade assistant** into the search box.
01. Select the **.NET Upgrade Assistant** item, and then select **Install**.

    :::image type="content" source="media/upgrade-assistant-install/visual-studio-manage-extensions.png" alt-text="The manage extensions window in Visual Studio, showing the .NET Upgrade Assistant.":::

01. Once the extension finishes downloading, close Visual Studio to automatically start the installation.

    :::image type="content" source="media/upgrade-assistant-install/install-prompt.png" alt-text="A prompt to install the .NET Upgrade Assistant extension.":::

01. Select **Modify** and follow the instructions to install the extension.

## .NET Global Tool

The following steps install .NET Upgrade Assistant as a .NET Global Tool. .NET Upgrade Assistant is distributed in the [upgrade-assistant NuGet package](https://www.nuget.org/packages/upgrade-assistant).

01. Open a command prompt that has the `dotnet` command in Path.
01. Run the following command to install the tool:

    ```dotnetcli
    dotnet tool install -g upgrade-assistant
    ```

    > [!IMPORTANT]
    > Installing this tool may fail if you've configured another NuGet feed source. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors, bypassing those other NuGet feed sources:
    >
    > ```dotnetcli
    > dotnet tool install -g --ignore-failed-sources upgrade-assistant
    > ```

## Validation

The following information helps you determine that .NET Upgrade Assistant is installed.

- **Visual Studio Extension**

  There are two ways to determine if .NET Upgrade Assistant is installed as a Visual Studio extension. The quickest way is to right-click on any .NET or .NET Framework project in the **Solution Explorer** window and check for an **Upgrade** menu item.

  Another way is to select the **Extensions** > **Manage Extensions** menu to open the **Extension Manager** window. Then, select the **Installed** tab and find it in the list of installed extensions.

- **.NET Global Tool**

  Open a command prompt and run the `upgrade-assistant` command. If the command response indicates that the command is unknown, the tool didn't install correctly or isn't in PATH.

## Troubleshoot - .NET Global Tool

If you configured extra NuGet feed sources, the install might fail with an error indicating that the NuGet package isn't available in the feed. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors, bypassing the other NuGet feed sources:

```dotnetcli
dotnet tool install -g --ignore-failed-sources upgrade-assistant
```
