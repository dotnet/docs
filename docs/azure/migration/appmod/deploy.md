---
title: Deploy your project to Azure by using GitHub Copilot app modernization for .NET
description: Learn how to deploy your migrated .NET project to Azure by using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/17/2025
author: JiDong
ms.author: donji
---

# Quickstart: Use GitHub Copilot app modernization for .NET to deploy your project to Azure

In this quickstart, you learn how to deploy your project to Azure with GitHub Copilot app modernization for .NET. This tool lets you deploy migrated projects to Azure and automatically fixes deployment errors during the process.

## Prerequisites

[!INCLUDE[github-copilot-app-mod-prereqs](../../../core/porting/github-copilot-app-modernization/includes/prereqs.md)]

## Deploy your project

The App Modernization for .NET deployment feature helps you deploy your migrated app to Azure. Follow these steps to start the deployment process:

1. In Visual Studio, open your migrated project.

1. Start the deployment with one of the following approaches:

    - **Deploy after migration**: Deploy your project after completing your migration task. GitHub Copilot asks if you'd like to deploy your project to Azure upon completing a migration task. Instructing Copilot to continue starts the deployment process.

        :::image type="content" source="media/start-deploy.png" alt-text="Screenshot that shows how to start the deployment process in GitHub Copilot.":::

    - **Use a deployment prompt**: You can enter the following prompt in Copilot chat to deploy your project to Azure:

        *Scan my project to identify all Azure-relevant resources, programming languages, frameworks, dependencies, and configuration files needed for deployment, and develop an architecture diagram for me using #appmod-generate-architecture-diagram. Based on that diagram, help me develop and execute a plan using #appmod-get-plan to deploy my project to Azure. deployTool: azcli, hosting service: non-aks.*

        :::image type="content" source="media/start-deploy-prompt.png" alt-text="Screenshot that shows how to start the deployment process in GitHub Copilot by using a prompt.":::

1. After you start the deployment, GitHub Copilot might ask for your approval to use tools or run commands. Grant permission when prompted.

1. GitHub Copilot creates a plan. The plan explains the deployment strategy, including deployment goals, project information, Azure resource architecture, Azure resources, and execution steps.

1. You can edit the plan directly or ask GitHub Copilot to edit it to customize your deployment before you proceed.

1. When you're satisfied with the plan, instruct GitHub Copilot to continue.

1. GitHub Copilot follows the plan and runs the deployment process.

1. When deployment finishes, GitHub Copilot provides a summary of the deployment process.

## Notes

- Use Claude Sonnet 4 or later models for the best results.
- Copilot can need a few iterations to fix deployment errors.
