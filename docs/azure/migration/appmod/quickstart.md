---
title: Assess and migrate a .NET project with GitHub Copilot app modernization for .NET
ms.reviewer: alexwolf
description: Learn how to assess and migrate a .NET project by using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/22/2025
author: alexwolfmsft
ms.author: alexwolf
#customer intent: As a .NET developer, I want to assess my project's migration readiness so that I can identify potential challenges and plan the modernization process effectively.
---

# Quickstart: Assess and migrate a .NET project with GitHub Copilot app modernization for .NET

In this quickstart, you assess and migrate a .NET project by using GitHub Copilot app modernization for .NET. You complete the following tasks:

- Assess a sample project (Contoso University)
- Start the migration process

## Prerequisites

[!INCLUDE[github-copilot-app-mod-prereqs](../../../includes/github-copilot-app-mod-prereqs.md)]

## Assess app readiness

GitHub Copilot app modernization for .NET assessment helps you find app readiness challenges, learn their impact, and see recommended migration tasks. Each migration task includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository to your computer.

1. In Visual Studio, open the **Contoso University** solution from the samples repository.

1. In Solution Explorer, right-click the solution node and select **Modernize**.

    :::image type="content" source="media/modernize-solution.png" alt-text="Screenshot that shows the modernize option in the context menu.":::

1. The GitHub Copilot Chat window opens with a welcome message and predefined options. Select **Migrate to Azure** from the available choices and send it to Copilot.

    :::image type="content" source="media/modernization-welcome.png" alt-text="Screenshot that shows the welcome message with migration options.":::

    > [!TIP]
    > Instead of steps 3 and 4, you can open **GitHub Copilot Chat** directly and send `@Modernize Migrate to Azure` to start the assessment and migration flow.

1. A new Copilot chat session opens and shows the welcome message. The assessment starts automatically and analyzes your project for migration readiness.

    :::image type="content" source="media/assessment-in-process.png" alt-text="Screenshot that shows assessment in progress with status indicators.":::

1. When the assessment finishes, you see a comprehensive assessment report UI page and a list of migration tasks in the chat window.

    :::image type="content" source="media/assessment-report.png" alt-text="Screenshot that shows the generated assessment report with detailed findings.":::

## App migrations

GitHub Copilot app modernization for .NET includes [predefined tasks](predefined-tasks.md) for common migration scenarios and follows Microsoft's best practices.

### Start a migration task

Start a migration task in one of the following ways:

**Option 1. Run from the Assessment Report**

Select the **Run Task** button in the Assessment Report from the previous step to start a migration task.

**Option 2. Send in Copilot Chat**

Send the migration task number (for example, 1.1) or its name in the chat.

:::image type="content" source="media/quickstart-chat-experience.png" alt-text="Screenshot of sending a message in Copilot Chat to start a migration task.":::

### Plan and progress tracker generation

- When you start the migration, GitHub Copilot starts a session named "App modernization: migrate from `<source technology>` to `<target technology>`" in agent mode with predefined prompts.
- The tool creates two files in the `.appmod/.migration` folder:
  - `plan.md` - the overall migration plan
  - `progress.md` - a progress tracker; GitHub Copilot marks items as it completes tasks
- Edit these files to customize your migration before you continue.

### Start code remediation

- If you're satisfied with the plan and progress tracker, enter a prompt to start the migration, such as:

    ```console
    The plan and progress tracker look good to me. Go ahead with the migration.
    ```

- GitHub Copilot starts the migration process and might ask for your approval to use knowledge base tools in the Model Context Protocol (MCP) server. Grant permission when prompted.
- Copilot follows the plan and progress tracker to:
  - Manage dependencies
  - Apply configuration changes
  - Make code changes
  - Build the solution, fix all compilation and configuration errors, and ensure a successful build
  - Fix security vulnerabilities

## Default chat messages

GitHub Copilot app modernization for .NET gives you default chat message options to streamline your workflow.

:::image type="content" source="media/quickstart-followup.png" alt-text="Screenshot that shows default chat message options in the Copilot Chat.":::

You can choose one of the predefined options and send it in the chat:

- **Run modernization assessment**: Starts a new assessment of your application to identify migration readiness issues and Azure compatibility challenges.
- **View assessment report**: Opens the previous assessment report and shows a summary of migration tasks based on the results. If no previous assessment exists, it runs a new assessment first.
- **Browse top migration tasks**: Shows recommended migration tasks and common modernization scenarios, regardless of any specific assessment results.

> [!TIP]
> These default messages help you quickly navigate common workflows without typing custom prompts. You can also enter your own messages to interact with Copilot for specific questions or needs.

## Next Steps

- [Predefined Tasks](predefined-tasks.md)
- [Frequently Asked Questions](../../../core/porting/github-copilot-app-modernization-faq.yml)
