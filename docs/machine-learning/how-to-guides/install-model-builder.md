---
title: How to install Model Builder
description: Learn how to install the ML.NET Model Builder tool
author: luisquintanilla
ms.author: luquinta
ms.date: 06/21/2019
ms.custom: mvc, how-to
#Customer intent: As a non-developer I want know how to install Model Builder to add machine learning to my .NET application.
---

# How to install ML.NET Model Builder

Learn how to install ML.NET Model Builder to add machine learning to your .NET applications.

> [!NOTE]
> Model Builder is currently in Preview.

## Pre-requisites

- Visual Studio 2017 15.9.12 or later / Visual Studio 2019
- .NET Core 2.1 or later SDK

## Limitations

- ML.NET Model Builder Extension currently only works on Visual Studio on Windows.
- Training dataset limit of 1GB
- SQL Server has a limit of 100 thousand rows for training
- Microsoft SQL Server Data Tools for Visual Studio 2017 is not supported

## Install

ML.NET Model builder can be installed either through the Visual Studio Marketplace or from within Visual Studio. 

### Visual Studio Marketplace

1. Download from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MLNET.07)
1. Follow prompts to install onto respective Visual Studio version

### Visual Studio 2017

1. In the menu bar, select **Tools** > **Extensions and Updates**

    ![VS201701](./media/install-model-builder/VS201701.png)

1. Inside the *Extension and Updates* prompt, select the *Online* node.
1. In the search bar, search for *ML.NET Model Builder* and from the results, select ML.NET Model Builder (Preview)

    ![VS201702](./media/install-model-builder/VS201702.png)

1. Follow the prompts to complete the installation

### Visual Studio 2019

1. On the menu bar, select **Extensions** > **Manage Extensions**

    ![VS201901](./media/install-model-builder/VS201901.png)

1. Inside the *Extension and Updates* prompt, select the *Online* node.
1. Type *ML.NET Model Builder* into the search bar select ML.NET Model Builder (Preview)

    ![VS201902](./media/install-model-builder/VS201902.png)

1. Follow the prompts to complete the installation

## Uninstall

### Visual Studio 2017

1. On the menu bar, select **Tools** > **Extensions and Updates**
1. Inside the *Extension and Updates* prompt, expand the *Installed* node and select *Tools*
1. Select ML.NET Model Builder (Preview) from the list of tools and then, select *Uninstall*
1. Follow the prompts to complete the uninstallation.

### Visual Studio 2019

1. On the menu bar, select **Extensions** > **Manage Extensions**
1. Inside the *Extension and Updates* prompt, expand the *Installed* node and select *Tools*
1. Select ML.NET Model Builder (Preview) from the list of tools and then, select *Uninstall*
1. Follow the prompts to complete the uninstallation.

## Upgrade

The upgrade process is similar to the installation process. Either download the latest version from Visual Studio Marketplace or use the Extensions Manager in Visual Studio.
