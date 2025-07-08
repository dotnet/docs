---
title: Azure Migrate application and code assessment for .NET installation
description: Learn how to install Azure Migrate application and code assessment for .NET
ms.topic: concept-article
ms.date: 11/09/2023
author: codemillmatt
ms.author: masoucou
---

# Install Azure Migrate application and code assessment for .NET

Application and code assessment can be installed as a Visual Studio extension or as a .NET command-line tool. When installed as a Visual Studio extension, loaded projects can be analyzed through the context menu in Solution Explorer. The command-line version of the tool provides an interactive step-by-step experience.

## Prerequisites

- Windows operating system
- Visual Studio 2022 version 17.1 or later - for the Visual Studio extension
- .NET SDK - for the command-line tool

## Install the Visual Studio extension

The application and code assessment for .NET can be installed as a Visual Studio extension, which lets you analyze an open projects in your solution. Use the following steps to install it from inside Visual Studio. Alternatively, you can download and install the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.appcat).

  1. With Visual Studio opened, press the **Extensions > Manage Extensions** menu item, which opens the **Manage Extensions** window.
  2. In the **Manage Extensions** window, enter **"Azure Migrate"** into the search input box.
  3. Select the **Azure Migrate application and code assessment** item, and then select **Download**.
  4. Once the extension has been downloaded, close Visual Studio. This starts the installation of the extension.
  5. In the VSIX Installer dialog select **Modify** and follow the directions to install the extension.

## Install the .NET global tool

Azure Migrate application and code assessment for .NET is also available as a .NET global tool. You can install the tool with the following command.

```dotnetcli
dotnet tool install -g dotnet-appcat
```

Similarly, to update the tool, use the following command:

```dotnetcli
dotnet tool update -g dotnet-appcat
```

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors.
>
> ```dotnetcli
> dotnet tool install -g --ignore-failed-sources dotnet-appcat
> ```

## Next steps

### Use with Visual Studio

For information on how to use and interpret results with Visual Studio, see [Use the application and code assessment with Visual Studio](visual-studio.md).

### Use with .NET CLI

For information on how to use and interpret results with the .NET CLI, see [Use the application and code assessment with the .NET CLI](dotnet-cli.md).
