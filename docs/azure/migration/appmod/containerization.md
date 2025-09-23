---
title: Containerize your project using GitHub Copilot app modernization for .NET
description: Learn how to containerize your .NET project using GitHub Copilot app modernization for .NET.
#customer intent: As a .NET developer, I want to containerize my project using GitHub Copilot App Modernization so that I can modernize my application efficiently.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/17/2025
author: JiDong
ms.author: donji
---

# Quickstart: Containerize your project using GitHub Copilot app modernization for .NET

In this quickstart, you learn how to containerize your project using GitHub Copilot app modernization for .NET. The app modernization tooling uses GitHub Copilot's AI capabilities to:

- Analyze your project structure and dependencies
- Generate Dockerfile configurations
- Create build-ready Docker images
- Guide you through the containerization process

## Prerequisites

Before you begin, make sure you have:

- Windows operating system
- [Visual Studio 2022 version 17.14.16 or newer](https://visualstudio.microsoft.com/downloads/)
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#change-workloads-or-individual-components) with these optional components enabled:
  - GitHub Copilot
  - GitHub Copilot app modernization for .NET
- GitHub account with Copilot access and a supported subscription plan:
  - [Sign in to Visual Studio using a GitHub account](/visualstudio/ide/work-with-github-accounts) with [Copilot access](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot#getting-access-to-copilot).
  - Supported subscription plans: Copilot Pro, Copilot Pro+, Copilot Business, or Copilot Enterprise.
  - If you change subscriptions, restart Visual Studio.

## Containerize your project

The GitHub Copilot app modernization for .NET containerization feature helps you containerize your project. To start the containerization process, complete the following steps:

1. Open your project in Visual Studio.

1. Start containerization by using one of these approaches:

    - **Containerize from Assessment Report**: In the assessment report, select **Run Task** for the Docker Containerization issue.

        :::image type="content" source="media/containerize-assessment-report.png" alt-text="Screenshot that shows containerization task in assessment report.":::

    - **Use a containerization prompt**: You can input the following prompt in Copilot chat to containerize your project:

        *Scan my project and help me plan how to containerize my application using the #appmod-get-containerization-plan tool. Execute the plan. The end goal is to have Dockerfiles that are able to be built.*

        :::image type="content" source="media/containerization-prompt.png" alt-text="Screenshot that shows how to start the containerization process in GitHub Copilot using a prompt.":::

1. After you start the process, GitHub Copilot can ask for your approval to use tools or run commands. Grant permission when prompted.

1. GitHub Copilot analyzes your project and generates a plan. The plan includes a breakdown of your project and steps for containerizing your project.

1. GitHub Copilot follows the steps to generate a Dockerfile and validate that your Docker image builds successfully.

1. When GitHub Copilot finishes containerizing your project, it provides a summary of what it did.

## Notes

- Use Claude Sonnet 4 or later models for the best results.
- Copilot might take a few iterations to fix containerization errors.
