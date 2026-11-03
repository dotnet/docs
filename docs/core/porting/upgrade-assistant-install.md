---
title: Install .NET Upgrade Assistant
description: "Learn how to install .NET Upgrade Assistant in Visual Studio or as a .NET Global Tool. .NET Upgrade Assistant assists you when upgrading projects to the latest dependencies or when upgrading to a new .NET"
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy
ms.date: 03/19/2026

#customer intent: As a developer, I want to install .NET Upgrade Assistant so that I can upgrade my projects.

---

# Install .NET Upgrade Assistant

This article teaches you how to install .NET Upgrade Assistant in Visual Studio or using the command-line interface (CLI) tool.

[!INCLUDE [github-copilot-suggestion](includes/github-copilot-suggestion.md)]

## Prerequisites

- Windows Operating System
- [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) (or Visual Studio 2022 version 17.14.17+).
- [.NET SDK 8 or later](https://dotnet.microsoft.com/download/dotnet/).

## Methods

.NET Upgrade Assistant is built into Visual Studio or can be installed as a .NET Global Tool.

The Upgrade Assistant runs inside Visual Studio, on the solution or project you have open. The .NET Global Tool is an interactive console application that runs on a solution or project file at or below the current directory.

If you want the streamlined experience of opening a project in Visual Studio and upgrading it, use the Upgrade Assistant.

## Visual Studio

The following steps enable the legacy Upgrade Assistant in Visual Studio.

01. Open Visual Studio.

    If the **Open Recent \ Get Started** window opens, select the **Continue without code** link.

01. Select the **Tools** > **Options** menu, which opens the **Options** window.
01. Navigate to **All Settings** > **Projects and Solutions** > **Modernization**.
01. Select the **Enable legacy Upgrade Assistant** item.
01. Restart Visual Studio

    :::image type="content" source="media/upgrade-assistant-install/enable.png" alt-text="A screen shot showing the options window in Visual Studio with the Modernization settings page open.":::

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

- **Visual Studio**

  To determine if .NET Upgrade Assistant is enabled, right-click on any .NET or .NET Framework project in the **Solution Explorer** window and check for an **Upgrade** menu item.

- **.NET Global Tool**

  Open a command prompt and run the `upgrade-assistant` command. If the command response indicates that the command is unknown, the tool didn't install correctly or isn't in PATH.

## Troubleshoot - .NET Global Tool

If you configured extra NuGet feed sources, the install might fail with an error indicating that the NuGet package isn't available in the feed. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors, bypassing the other NuGet feed sources:

```dotnetcli
dotnet tool install -g --ignore-failed-sources upgrade-assistant
```
