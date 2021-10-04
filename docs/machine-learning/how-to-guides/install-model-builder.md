---
title: How to install Model Builder
description: Learn how to install the ML.NET Model Builder tool
author: luisquintanilla
ms.author: luquinta
ms.date: 09/20/2021
ms.custom: mvc, how-to, mlnet-tooling
#Customer intent: As a non-developer I want know how to install Model Builder to add machine learning to my .NET application.
---

# How to install ML.NET Model Builder

Learn how to install ML.NET Model Builder to add machine learning to your .NET applications.

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

- Visual Studio 2019 or in Visual Studio 2022 Preview 4 or later
- .NET Core 3.1 SDK or later.

## Limitations

- ML.NET Model Builder Extension currently only works on Visual Studio on Windows.
- Microsoft SQL Server Data Tools for Visual Studio 2017 is not supported

## Install Model Builder

ML.NET Model builder is built into Visual Studio. To enable it:

# [Visual Studio 2019](#tab/visual-studio-2019)

1. Open the Visual Studio Installer.
1. Select **Modify** to modify your current version of Visual Studio.
1. In the Visual Studio Installer, select the **Individual components** tab.
1. From the list of .NET components, **check** the **ML.NET Model Builder (Preview)** checkbox.

    :::image type="content" source="media/install-model-builder/enable-model-builder-visual-studio-2019.png" alt-text="Enable Model Builder Visual Studio 2019" lightbox="media/install-model-builder/enable-model-builder-visual-studio-2019.png":::

# [Visual Studio 2022](#tab/visual-studio-2022)

1. Open the Visual Studio Installer.
1. Select **Modify** to modify your current version of Visual Studio.
1. In the Visual Studio Installer, select the **Individual components** tab.
1. From the list of .NET components, **check** the **ML.NET Model Builder** checkbox.

    :::image type="content" source="media/install-model-builder/enable-model-builder-visual-studio-2022.png" alt-text="Enable Model Builder Visual Studio 2022" lightbox="media/install-model-builder/enable-model-builder-visual-studio-2022.png":::

---

## Uninstall Model Builder

ML.NET Model builder is built into Visual Studio. To disable it:

### [Visual Studio 2019](#tab/visual-studio-2019)

1. Open the Visual Studio Installer.
1. Select **Modify** to modify your current version of Visual Studio.
1. In the Visual Studio Installer, select the **Individual components** tab.
1. From the list of .NET components, **uncheck** the **ML.NET Model Builder (Preview)** checkbox.

    :::image type="content" source="media/install-model-builder/disable-model-builder-visual-studio-2019.png" alt-text="Disable Model Builder Visual Studio 2019" lightbox="media/install-model-builder/disable-model-builder-visual-studio-2019.png":::

### [Visual Studio 2022](#tab/visual-studio-2022)

1. Open the Visual Studio Installer.
1. Select **Modify** to modify your current version of Visual Studio.
1. In the Visual Studio Installer, select the **Individual components** tab.
1. From the list of .NET components, **uncheck** the **ML.NET Model Builder** checkbox.

    :::image type="content" source="media/install-model-builder/disable-model-builder-visual-studio-2022.png" alt-text="Disable Model Builder Visual Studio 2022" lightbox="media/install-model-builder/disable-model-builder-visual-studio-2022.png":::

---

## Upgrade Model Builder

Model Builder automatically updates when there's a new version.

However, if you'd prefer to manually install the latest version, either download it  from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=MLNET.07) or use the Extensions Manager in Visual Studio. See [how to update a Visual Studio extension](/visualstudio/extensibility/how-to-update-a-visual-studio-extension) for more information.
