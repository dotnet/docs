---
title: Quickstart: deploy your project to Azure using GitHub Copilot App Modernization for .NET (Preview)
description: deploy your project to Azure using GitHub Copilot App Modernization for .NET (Preview)
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 9/03/2025
author: JiDong
ms.author: donji
---

# Quickstart: deploy your project to Azure using GitHub Copilot App Modernization for .NET

This quickstart shows you how to deploy your project to Azure when you use [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace).
In code development, developers often need to deploy their project to a cloud environment for testing. Our tools help deploy your migrated project to Azure and fix any deployment errors in the process.

## Prerequisites

Before you begin, ensure you have:

- A GitHub account with [GitHub Copilot](https://github.com/features/copilot) enabled (Pro, Pro+, Business, or Enterprise plan required)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) version 17.14.7 or later
- Agent mode enabled for GitHub Copilot in Visual Studio ([Learn how](/visualstudio/ide/copilot-agent-mode))

### Sign-in to GitHub Copilot

GitHub Copilot is a dependency of the App Modernization Extension and experience. Make sure you're signed-in to GitHub Copilot inside Visual Studio.

1. Select the Copilot icon at the top of Visual Studio to open the GitHub Copilot pane.
1. Follow the UI prompts to sign-in to Copilot.

For more information, see [Set up GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states).

## Install the GitHub Copilot app modernization extension

To complete the steps ahead, you need to install the GitHub Copilot app modernization for .NET (Preview) Visual Studio extension.

1. Inside Visual Studio, navigate to `Extensions` > `Manage Extensions`.
1. Search for **GitHub Copilot app modernization for .NET** in the marketplace.
1. On the extension page, select **Install**.
1. Follow the notification bar prompts to close Visual Studio and complete the installation.
1. Relaunch Visual Studio after installation.

You can also view the [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace) extension directly on the extension marketplace.

For more information, see [Find, install, and manage extensions for Visual Studio](/visualstudio/ide/finding-and-using-visual-studio-extensions).

## Deploy your project

App Modernization for .NET deployment helps you deploy your migrated app to an Azure environment. Follow these steps to start your deployment process:

1. In Visual Studio, open your migrated project.

2. Start the deployment using one of the following approaches:
    * Deploy your project after completing your migration task. Copilot will ask you if you would like to deploy your project to Azure upon completing a migration task. Instructing Copilot to continue will start the deployment process.

    :::image type="content" source="media/start-deploy.png" alt-text="A screenshot showing how to start the deployment process in GitHub Copilot.":::

    * Deploy prompt.
      
      You can input the following prompt in Copilot chat to deploy your project to Azure.
      
      *Scan my project to identify all Azure-relevant resources, programming languages, frameworks, dependencies, and configuration files needed for deployment, and develop an architecture diagram for me using #appmod-generate-architecture-diagram. Based on that diagram, help me develop and execute a plan using #appmod-get-plan to deploy my project to Azure. deployTool: azcli, hosting service: non-aks.*

    :::image type="content" source="media/start-deploy-prompt.png" alt-text="A screenshot showing how to start the deployment process in GitHub Copilot.":::

3.	After you start the deployment, GitHub Copilot might ask for your approval to use tools in the Model Context Protocol (MCP) server. Grant permission when prompted.

4.	GitHub Copilot will create a plan.copilot.md file in the.azure folder. This file explains the overall deployment plan including deployment goal, project information, Azure resource architecture, Azure resources, and execution steps. 

5.	Edit the file directly or ask GitHub Copilot to edit to customize your deployment before proceeding.

6.	Once you are satisfied with the plan, instruct GitHub Copilot to continue.

7.	GitHub Copilot follows the plan and executes the deployment process.

## Notes
* We recommend using Claude Sonnet 4 or later models for the best results.
* It might take Copilot a few iterations to correct deployment errors.
