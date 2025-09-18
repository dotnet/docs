---
title: GitHub Copilot app modernization for .NET quickstart
description: Learn how to assess and migrate a .NET project by using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/17/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Quickstart: Assess and migrate a .NET project to Azure

In this quickstart, you assess and migrate a .NET project by using [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/ghcp-appmod/dotNET). You complete the following tasks:

- Install and configure the GitHub Copilot app modernization for .NET extension
- Assess a sample project (Contoso University)
- Start the migration process

## Prerequisites

Before you begin, [complete the prerequisites](https://aka.ms/ghcp-appmod/dotNET#prerequisites).

### Sign in to GitHub Copilot

GitHub Copilot is a dependency of the app modernization extension and experience. Make sure you're signed in to GitHub Copilot in Visual Studio.

1. Select the **Copilot** icon at the top of Visual Studio to open the GitHub Copilot pane.
1. Follow the UI prompts to sign in to Copilot.

For more information, see [Set up GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states).

## Install the GitHub Copilot app modernization extension

To complete the steps ahead, you need to install the [GitHub Copilot app modernization for .NET](https://aka.ms/appmod-dotnet-marketplace) extension.

1. In Visual Studio, go to **Extensions** > **Manage Extensions**.
1. Search for **GitHub Copilot app modernization for .NET** in the marketplace.
1. On the extension page, select **Install**.
1. Follow the notification bar prompts to close Visual Studio and complete the installation.
1. Restart Visual Studio after installation.

You can also view the [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace) directly on the extension marketplace.

For more information, see [Find, install, and manage extensions for Visual Studio](/visualstudio/ide/finding-and-using-visual-studio-extensions).

## Assess application readiness

App Modernization for .NET assessment helps you identify your application readiness challenges, understand their impact, and find recommended migration tasks. Each migration task includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration process with assessment:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository to your local machine.

2. In Visual Studio, open the **Contoso University** solution from the samples repository. 

3. Right-click the solution in Solution Explorer and select **Modernize**.

    :::image type="content" source="media/Modernize.png" alt-text="Screenshot that shows the modernize option in the context menu.":::

4. A GitHub Copilot Chat window opens with a welcome message and predefined options. Select **Migrate to Azure** from the available choices and send it to Copilot.

    :::image type="content" source="media/Welcome.png" alt-text="Screenshot that shows the welcome message with migration options.":::

5. A new Copilot chat session opens and displays the welcome message. The assessment automatically begins and analyzes your project for migration readiness.

    :::image type="content" source="media/AssessmentInProcess.png" alt-text="Screenshot that shows assessment in progress with status indicators.":::

6. When the assessment completes, you can view a comprehensive assessment report UI page and receive a list of migration tasks in the chat window.

    :::image type="content" source="media/assessment-report.png" alt-text="Screenshot that shows the generated assessment report with detailed findings.":::

## Start migration

GitHub Copilot app modernization for .NET (Preview) includes [predefined tasks](predefined-tasks.md) for common migration scenarios, following Microsoft's best practices.

### Start a migration task

Start a migration task using one of the following options:

**Option 1. Run from the Assessment Report**

Select the **Run Task** button in the Assessment Report generated in the previous step to start a migration task.

**Option 2. Send in Copilot Chat**

Send the migration task number (e.g., 1.1) or its name in the chat.

:::image type="content" source="media/quickstart_chat_experience.png" alt-text="A screenshot showing sending the message in the Copilot Chat to start a migration task.":::

### Plan and progress tracker generation

- When you start the migration, GitHub Copilot begins a session named "App modernization: migrate from `<source technology>` to `<target technology>`" in agent mode with predefined prompts.
- The tool creates two files in the `.appmod/.migration` folder:
  - `plan.md` - the overall migration plan
  - `progress.md` - a progress tracker; GitHub Copilot marks items as it completes tasks
- Edit these files to customize your migration before proceeding.

### Start code remediation

- If you're satisfied with the plan and progress tracker, enter a prompt to initiate the migration, such as the following:

    ```console
    `The plan and progress tracker look good to me. Go ahead with the migration.`
    ```

- GitHub Copilot starts the migration process and might ask for your approval to use knowledge base tools in the Model Context Protocol (MCP) server. Grant permission when prompted.
- Copilot follows the plan and progress tracker to:
  - Manage dependencies
  - Apply configuration changes
  - Make code changes
  - Build the solution, fix all compilation and configuration errors, and ensure a successful build
  - Security vulnerability fix

## Default chat messages

The GitHub Copilot app modernization for .NET extension provides default chat message options to streamline your workflow.

:::image type="content" source="media/quickstart_followup.png" alt-text="Screenshot that shows default chat message options in the Copilot Chat.":::

You can choose one of the predefined options below and send it in the chat:

- **Run modernization assessment**: Initiates a comprehensive new assessment of your application to identify migration readiness issues and Azure compatibility challenges.
- **View assessment report**: Opens the previously generated assessment report and provides a summarized list of migration tasks based on the assessment results. If no previous assessment exists, it automatically runs a new assessment first.
- **Browse top migration tasks**: Displays recommended migration tasks and common modernization scenarios, independent of any specific assessment results.

> [!TIP]
> These default messages help you quickly navigate common workflows without typing custom prompts. You can also type your own custom messages to interact with Copilot for specific questions or requirements.

### Default chat messages

The GitHub Copilot app modernization for .NET extension provides default chat message options to streamline your workflow. When you open the Copilot chat interface, you can choose from the following predefined options:

- **Run modernization assessment**: Initiates a comprehensive new assessment of your application to identify migration readiness issues and Azure compatibility challenges.
- **View assessment report**: Opens the previously generated assessment report and provides a summarized list of migration tasks based on the assessment results. If no previous assessment exists, it will automatically run a new assessment first.
- **Browse top migration tasks**: Displays recommended migration tasks and common modernization scenarios, independent of any specific assessment results.

> [!TIP]
> These default messages help you quickly navigate common workflows without typing custom prompts. You can also type your own custom messages to interact with Copilot for specific questions or requirements.

## Next Steps

- [Predefined Tasks](predefined-tasks.md)
- [Frequently Asked Questions](faq.md)
