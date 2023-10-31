---
title: Azure AppCAT Installation
description: Learn how to install the Azure Application and Code Assessment Toolkit.
ms.topic: conceptual
ms.date: 10/16/2023
author: codemillmatt
ms.author: masoucou
---

# Install the Azure Application and Code Assessment Toolkit (Azure AppCAT)

Azure AppCAT for .NET can be installed as a Visual Studio extension or as a .NET command-line tool. When installed as a Visual Studio extension, loaded projects and solution can be upgraded through the context menu in Solution Explorer. The command-line version of the tool provides an interactive step-by-step experience.

## Prerequisites

- Windows operating system
- Visual Studio 2022 version 17.1 or later
- .NET SDK for the command-line tool

## Install the Visual Studio extension

The Azure AppCAT for .NET can be installed as a Visual Studio extension, which lets you analyze an open projects in your solution. Use the following steps to install the Azure AppCAT for .NET from inside Visual Studio. Alternatively, you can download and install the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.azureappcat).

  1. With Visual Studio opened, press the **Extensions > Manage Extensions** menu item, which opens the **Manage Extensions** window.
  1. In the **Manage Extensions** window, enter _Azure AppCAT_ into the search input box.
  1. Select the **Azure AppCAT (Application and Code Assessment Toolkit)** item, and then select **Download**.

  [!Screenshot of the Visual Studio manage extensions dialog with the Azure AppCAT extension shown](media/visual-studio-manage-extensions.png)

  1. Once the extension has been downloaded, close Visual Studio. This starts the the installation of the extension.

  [!Screenshot of Visual Studio installing the extension](media/install-prompt.png)

  1. Select **Modify** and follow the directions to install the extension.

## Install the .NET global tool

The Azure AppCAT for .NET is also available as a .NET global tool. You can install the tool with the following command.

```dotnetcli
dotnet tool install -g appcat
```

Similarly, because the Azure AppCAT tool is installed as a .NET tool, it can be easily updated by running:

```dotnetcli
dotnet tool update -g appcat
```

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors.
>
> ```dotnetcli
> dotnet tool install -g --ignore-failed-sources appcat
> ```
