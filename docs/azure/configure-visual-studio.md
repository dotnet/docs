---
title: Configure Visual Studio for Azure Development with .NET
description: This article helps you configure Visual Studio for Azure development including getting the right workloads installed and connecting Visual Studio to your Azure account.
ms.topic: concept-article
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 3/20/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Configure Visual Studio for Azure development with .NET

Visual Studio includes tooling to help with the development and deployment of applications on Azure. This guide helps you make sure that Visual Studio is properly configured for Azure development.

## Download Visual Studio

If you already have Visual Studio installed, you can skip this step.

> [!div class="nextstepaction"]
> [Download Visual Studio](https://www.visualstudio.com/downloads/)

## Install Azure workloads

Open Visual Studio Installer and validate that the workloads **Azure development**&dagger; and **ASP.NET and web development** are installed. If either of these workloads isn't installed, select them to be installed.

![Screenshot of the Visual Studio Installer showing the Azure development and ASP.NET and Web Development Workloads selected](./media/visual-studio-installer-azure-development.png)

&dagger;The **Azure development** workload is currently unavailable in the Windows 11 Arm64 build of Visual Studio 2022.

## Authenticate Visual Studio with Azure

[!INCLUDE [auth-visual-studio](sdk/includes/auth-visual-studio.md)]

## Next steps

If you also use [Visual Studio Code](https://code.visualstudio.com/) for development in .NET or any other language, you should [configure Visual Studio Code for Azure development](./configure-vs-code.md). Otherwise, proceed to [Installing the Azure CLI](./install-azure-cli.md).
