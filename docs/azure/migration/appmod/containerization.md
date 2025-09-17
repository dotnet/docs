---
title: Containerization your project using GitHub Copilot app modernization for .NET
description: Learn how to containerize your .NET project using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/17/2025
author: JiDong
ms.author: donji
---

# Containerization your project using GitHub Copilot app modernization for .NET

In this quickstart, you learn how to to containerize your project using [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace).
This tool helps you generate dockerfile and build docker image.

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

## Containerize your project

The App Modernization for .NET containerization feature helps you containerize your project. Follow these step to start the containerization process:

1. In Visual Studio, open your project.

1. Start containerization using one of the following approaches:

    - **Conatinerize from Assessment Report**: From the assessment report, click on "Run Task" for the Docker Containerization issue.

        :::image type="content" source="media/containerize-assessment-report.png" alt-text="Screenshot showing containerization task in assessment report.":::

    - **Use a containerization prompt**: You can input the following prompt in Copilot chat to containerize your project:

        *Scan my project and help me plan how to containerize my application using the #appmod-get-containerization-plan tool. Execute the plan. The end goal is to have Dockerfiles that are able to be built.*

        :::image type="content" source="media/containerization-prompt.png" alt-text="Screenshot showing how to start the containerization process in GitHub Copilot using a prompt.":::







