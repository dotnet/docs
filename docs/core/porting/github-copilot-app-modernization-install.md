---
title: Install GitHub Copilot app modernization - upgrade for .NET
description: "Learn how to install the GitHub Copilot app modernization - upgrade for .NET Visual Studio extension. App modernization assists you when upgrading projects to the latest dependencies or when upgrading to a new version of .NET"
titleSuffix: ""
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy
ms.date: 05/16/2025

#customer intent: As a developer, I want to install GitHub Copilot App Modernization so that I can upgrade my projects.

---

# Install GitHub Copilot app modernization - upgrade for .NET

This article guides you through installing GitHub Copilot app modernization - upgrade for .NET extension in Visual Studio.

## Prerequisites

- Windows operating system
- [Visual Studio 2022 version 17.14 or newer](https://visualstudio.microsoft.com/downloads/)
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#change-workloads-or-individual-components)

## Visual Studio extension

The following steps install the Visual Studio extension.

> [!TIP]
> As an alternative to using the **Manage Extensions** feature of Visual Studio, you can download and run the extensions installer from the [Visual Studio Marketplace](https://aka.ms/ghcp-appmod/dotnet-upgrade-vsix).

01. Open Visual Studio.

    If the **Open Recent \ Get Started** window opens, select the **Continue without code** link.

01. Select the **Extensions** > **Manage Extensions** menu to open **Extension Manager**.
01. Select the **Browse** tab.
01. Enter `GitHub Copilot app modernization` into the search box.
01. Select **GitHub Copilot app modernization**, and then select **Install**.

    :::image type="content" source="media/github-copilot-app-modernization-install/visual-studio-manage-extensions.png" alt-text="The manage extensions window in Visual Studio, showing GitHub Copilot app modernization.":::

01. Once the extension finishes downloading, close Visual Studio to automatically start the installation.

    :::image type="content" source="media/github-copilot-app-modernization-install/install-prompt.png" alt-text="A prompt to install the GitHub Copilot App Modernization extension.":::

01. Select **Modify** and follow the instructions to install the extension.

## Validation

There are two ways to determine if GitHub Copilot App Modernization is installed as a Visual Studio extension:

- The quickest way is to right-click on any .NET or .NET Framework project in **Solution Explorer** and check for an **Upgrade** menu item.
- Another way is to select the **Extensions** > **Manage Extensions** menu to open the **Extension Manager** window. Then, select the **Installed** tab and find it in the list of installed extensions.

## Related content

- [What is GitHub Copilot app modernization - upgrade for .NET?](github-copilot-app-modernization-overview.md)
