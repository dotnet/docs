---
title: GitHub Copilot app modernization for .NET quickstart
description: Learn how to assess and migrate a .NET project by using GitHub Copilot app modernization for .NET.
ms.topic: quickstart
ms.custom: devx-track-dotnet
ms.date: 09/17/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Quickstart: Assess and migrate a .NET project with GitHub Copilot app modernization for .NET (Preview)

In this quickstart, you assess and migrate a .NET project by using GitHub Copilot app modernization for .NET. You complete the following tasks:

- Assess a sample project (Contoso University)
- Start the migration process

## Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.14.16 or newer](https://visualstudio.microsoft.com/downloads/) (To be released)
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#change-workloads-or-individual-components) with the following optional components enabled:
  - GitHub Copilot
  - GitHub Copilot app modernization for .NET
- GitHub account with Copilot access and supported subscription plan:
  - [Sign in to Visual Studio using a GitHub account](/visualstudio/ide/work-with-github-accounts) with [Copilot access](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot#getting-access-to-copilot)
  - Supported subscription plans: Copilot Pro, Copilot Pro+, Copilot Business, or Copilot Enterprise
  - If you change subscriptions, you must restart Visual Studio

## Assess app readiness

App Modernization for .NET assessment helps you identify your application readiness challenges, understand their impact, and find recommended migration tasks. Each migration task includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration process with assessment:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository to your local machine.

2. In Visual Studio, open the **Contoso University** solution from the samples repository.

3. Right-click the solution in Solution Explorer and select **Modernize**.

    :::image type="content" source="media/modernize-solution.png" alt-text="Screenshot that shows the modernize option in the context menu.":::

4. A GitHub Copilot Chat window opens with a welcome message and predefined options. Select **Migrate to Azure** from the available choices and send it to Copilot.

    :::image type="content" source="media/modernization-welcome.png" alt-text="Screenshot that shows the welcome message with migration options.":::

    > [!TIP]
    > Alternative: Instead of steps 3 and 4, open **GitHub Copilot Chat** directly and send `@Modernize Migrate to Azure` to start the assessment and migration flow.

5. A new Copilot chat session opens and displays the welcome message. The assessment automatically begins and analyzes your project for migration readiness.

    :::image type="content" source="media/assessment-in-process.png" alt-text="Screenshot that shows assessment in progress with status indicators.":::

6. When the assessment completes, you can view a comprehensive assessment report UI page and receive a list of migration tasks in the chat window.

    :::image type="content" source="media/assessment-report.png" alt-text="Screenshot that shows the generated assessment report with detailed findings.":::

## App migrations

GitHub Copilot app modernization for .NET (Preview) includes [predefined tasks](predefined-tasks.md) for common migration scenarios, following Microsoft's best practices.

### Start a migration task

Start a migration task using one of the following options:

**Option 1. Run from the Assessment Report**

Select the **Run Task** button in the Assessment Report generated in the previous step to start a migration task.

**Option 2. Send in Copilot Chat**

Send the migration task number (e.g., 1.1) or its name in the chat.

:::image type="content" source="media/quickstart-chat-experience.png" alt-text="A screenshot showing sending the message in the Copilot Chat to start a migration task.":::

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

:::image type="content" source="media/quickstart-followup.png" alt-text="Screenshot that shows default chat message options in the Copilot Chat.":::

You can choose one of the predefined options below and send it in the chat:

- **Run modernization assessment**: Initiates a comprehensive new assessment of your application to identify migration readiness issues and Azure compatibility challenges.
- **View assessment report**: Opens the previously generated assessment report and provides a summarized list of migration tasks based on the assessment results. If no previous assessment exists, it automatically runs a new assessment first.
- **Browse top migration tasks**: Displays recommended migration tasks and common modernization scenarios, independent of any specific assessment results.

> [!TIP]
> These default messages help you quickly navigate common workflows without typing custom prompts. You can also type your own custom messages to interact with Copilot for specific questions or requirements.

## Next Steps

- [Predefined Tasks](predefined-tasks.md)
- [Frequently Asked Questions](faq.md)
