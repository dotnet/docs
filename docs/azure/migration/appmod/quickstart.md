---
title: GitHub Copilot app modernization for .NET (Preview) quickstart
description: Get started with GitHub Copilot app modernization for .NET
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Quickstart: Assess and migrate a .NET Project with GitHub Copilot app modernization for .NET (Preview)

In this quickstart, you assess and migrate a .NET project using [GitHub Copilot app modernization for .NET (Preview)](https://aka.ms/appmod-dotnet-marketplace). You complete the following tasks:

- Install and configure the GitHub Copilot app modernization for .NET extension
- Assess a sample project (Contoso University)
- Start the migration process

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

## Assess application readiness

App Modernization for .NET assessment helps you identify your application readiness challenges, understand their impact, and find recommended solutions. Each solution recommendation includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration process with assessment:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository.
2. In Visual Studio, open the **Contoso University** project folder from the samples repository.
3. Right-click the solution and select **Modernize**.

    :::image type="content" source="media/Modernize.png" alt-text="A screenshot showing the modernize option.":::

4. A GitHub Copilot Chat window opens with a welcome message and a list of options. Choose **Migrate to Azure** and send it to Copilot.

    :::image type="content" source="media/Welcome.png" alt-text="A screenshot showing the welcome message.":::

5. A new Copilot chat session opens and displays the welcome message. The assessment runs automatically.

    :::image type="content" source="media/AssessmentInProcess.png" alt-text="A screenshot showing assessment in progress.":::

6. When the assessment finishes, you can view an assessment report UI page and a list of migration tasks in the chat.

    :::image type="content" source="media/assessment-report.png" alt-text="A screenshot showing the generated assessment report.":::


## Start a migration

GitHub Copilot app modernization for .NET (Preview) includes [predefined tasks](predefined-tasks.md) for common migration scenarios, following Microsoft's best practices.

1. Select the **Migrate** button in the Assessment Report generated in the previous step to start a migration.

    > [!TIP]
    > If you already know which migration scenario you want, go to `GitHub Copilot app modernization for .NET` > `Migration Tasks` and select the appropriate task directly.

### Plan and progress tracker generation

- When you start the migration, GitHub Copilot begins a session in agent mode with predefined prompts.
- The tool creates two files in the `.appmod/.migration` folder:
  - `plan.md` - the overall migration plan
  - `progress.md` - a progress tracker; GitHub Copilot marks items as it completes tasks
- Edit these files to customize your migration before proceeding.

### Start code remediation

- If you're satisfied with the plan and progress tracker, enter prompt to initiate the migration, such as the following:

    ```console
    `The plan and progress tracker look good to me. Go ahead with the migration.`
    ```

- GitHub Copilot starts the migration process and might ask for your approval to use knowledge base tools in the Model Context Protocol (MCP) server. Grant permission when prompted.
- Copilot follows the plan and progress tracker to:
  - Manage dependencies
  - Apply configuration changes
  - Make code changes
  - Build the solution, fix all compilation and configuration errors, and ensure a successful build

## Next Steps

- [Predefined Tasks](predefined-tasks.md)
- [Frequently Asked Questions](faq.md)
