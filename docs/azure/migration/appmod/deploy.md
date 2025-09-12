---
title: Deploy your project to Azure using GitHub Copilot app modernization for .NET
description: Learn how to deploy your migrated .NET project to Azure using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/03/2025
author: JiDong
ms.author: donji
---

# Deploy your project to Azure using GitHub Copilot app modernization for .NET

In this quickstart, you learn how to deploy your project to Azure when you use [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace). This tool helps you deploy migrated projects to Azure and automatically fixes deployment errors during the process.

## Prerequisites

Before you begin, ensure you have the following prerequisites:

- A GitHub account with [GitHub Copilot](https://github.com/features/copilot) enabled (Pro, Pro+, Business, or Enterprise plan required)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) version 17.14.7 or later
- Agent mode enabled for GitHub Copilot in Visual Studio ([Learn how](/visualstudio/ide/copilot-agent-mode))

### Sign in to GitHub Copilot

GitHub Copilot is required for the App Modernization extension. Make sure you're signed-in to GitHub Copilot inside Visual Studio:

1. Select the Copilot icon at the top of Visual Studio to open the GitHub Copilot pane.
1. Follow the UI prompts to sign in to Copilot.

For more information, see [Set up GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states).

## Install the GitHub Copilot app modernization extension

To complete the steps in this quickstart, you need to install the GitHub Copilot app modernization for .NET (Preview) Visual Studio extension:

1. Inside Visual Studio, navigate to **Extensions** > **Manage Extensions**.
1. Search for **GitHub Copilot app modernization for .NET** in the marketplace.
1. On the extension page, select **Install**.
1. Follow the notification bar prompts to close Visual Studio and complete the installation.
1. Relaunch Visual Studio after installation.

You can also view the [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace) extension directly in the extension marketplace.

For more information, see [Find, install, and manage extensions for Visual Studio](/visualstudio/ide/finding-and-using-visual-studio-extensions).

## Deploy your project

The App Modernization for .NET deployment feature helps you deploy your migrated app to Azure. Follow these steps to start the deployment process:

1. In Visual Studio, open your migrated project.

1. Start the deployment using one of the following approaches:

    - **Deploy after migration**: Deploy your project after completing your migration task. Copilot will ask if you'd like to deploy your project to Azure upon completing a migration task. Instructing Copilot to continue will start the deployment process.

        :::image type="content" source="media/start-deploy.png" alt-text="Screenshot showing how to start the deployment process in GitHub Copilot.":::

    - **Use a deployment prompt**: You can input the following prompt in Copilot chat to deploy your project to Azure:

        *Scan my project to identify all Azure-relevant resources, programming languages, frameworks, dependencies, and configuration files needed for deployment, and develop an architecture diagram for me using #appmod-generate-architecture-diagram. Based on that diagram, help me develop and execute a plan using #appmod-get-plan to deploy my project to Azure. deployTool: azcli, hosting service: non-aks.*

        :::image type="content" source="media/start-deploy-prompt.png" alt-text="Screenshot showing how to start the deployment process in GitHub Copilot using a prompt.":::

1. After you start the deployment, GitHub Copilot might ask for your approval to use tools in the Model Context Protocol (MCP) server. Grant permission when prompted.

1. GitHub Copilot creates a `plan.copilot.md` file in the `.azure` folder. This file explains the overall deployment plan, including deployment goals, project information, Azure resource architecture, Azure resources, and execution steps.

1. Edit the file directly or ask GitHub Copilot to edit it to customize your deployment before proceeding.

1. Once you're satisfied with the plan, instruct GitHub Copilot to continue.

1. GitHub Copilot follows the plan and executes the deployment process.

## Notes

- We recommend using Claude Sonnet 4 or later models for the best results.
- It might take Copilot a few iterations to correct deployment errors.
