---
title: GitHub Copilot App Modernization for .NET (Preview) quickstart
description: Get started with GitHub Copilot App Modernization for .NET
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Quickstart: Assess and Migrate a .NET Project with GitHub Copilot App Modernization for .NET (Preview)

In this quickstart, you assess and migrate a .NET project using [GitHub Copilot App Modernization for .NET (Preview)]([GitHub Copilot App Modernization for .NET (Preview)](https://marketplace.visualstudio.com/items?itemName=vscjava.appmod-dotnet)). You complete the following tasks:

- Install and configure the GitHub Copilot App Modernization for .NET extension
- Assess a sample project (Contoso University)
- Start the migration process

## Prerequisites

Before you begin, ensure you have:

- A GitHub account with [GitHub Copilot](https://github.com/features/copilot) enabled (Pro, Pro+, Business, or Enterprise plan required)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) version 17.14.7 or later
- Agent mode enabled for GitHub Copilot in Visual Studio ([Learn how](/visualstudio/ide/copilot-agent-mode?view=vs-2022))

### Sign-in to GitHub Copilot

GitHub Copilot is a dependency of the App Modernization Extension and experience. Make sure you're signed-in to GitHub Copilot inside Visual Studio.

1. Select the Copilot icon at the top of Visual Studio to open the GitHub Copilot pane.
1. Follow the UI prompts to sign-in to Copilot.

For more information, see [Set up GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states?view=vs-2022).

## Install the GitHub Copilot App Modernization Extension

To complete the steps ahead, you need to install the GitHub Copilot App Modernization for .NET (Preview) Visual Studio extension.

1. Inside Visual Studio, navigate to `Extensions` > `Manage Extensions`.
1. Search for **GitHub Copilot App Modernization for .NET** in the marketplace.
1. On the extension page, select **Install**.
1. Follow the notification bar prompts to close Visual Studio and complete the installation.
1. Relaunch Visual Studio after installation.

You can also view the [GitHub Copilot App Modernization for .NET](https://marketplace.visualstudio.com/items?itemName=vscjava.appmod-dotnet) extension directly on the extension marketplace.

For more information, see [Find, install, and manage extensions for Visual Studio](/visualstudio/ide/finding-and-using-visual-studio-extensions?view=vs-2022).

## Assess application readiness

App Modernization for .NET assessment helps you identify your application readiness challenges, understand their impact, and find recommended solutions. Each solution recommendation includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration process with assessment:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository.
2. In Visual Studio, open the **Contoso University** project folder from the samples repository.
3. Start the assessment using one of the following approaches:

   - **Solution explorer**

    Right-click the top-level solution node, then select `GitHub Copilot App Modernization for .NET` > `Run Assessment`.  

    :::image type="content" source="media/solution-start-assessment.png" alt-text="A screenshot showing how to start the assessment through the solution explorer.":::

   - **Top navigation**

    On the top menu, go to `Extensions` > `GitHub Copilot App Modernization for .NET` > `Run Assessment`.  

    :::image type="content" source="media/extension-start-assessment.png" alt-text="A screenshot showing how to start the assessment from the top navigation.":::

   - **Search panel**

    In the feature search panel (`Ctrl+Shift+P`), search for `Run Assessment`.

4. When the background task finishes, you see an assessment report tab with the results.

    :::image type="content" source="media/assessment-report.png" alt-text="A screenshot showing the generated assessment report.":::

    > [!NOTE]
    > A small icon in the lower-left corner shows the background task is running.

## Start a migration

GitHub Copilot App Modernization for .NET (Preview) includes [predefined tasks](predefined-tasks.md) for common migration scenarios, following Microsoft's best practices.

1. Select the **Migrate** button in the Assessment Report generated in the previous step to start a migration.

    > [!TIP]
    > If you already know which migration scenario you want, go to `GitHub Copilot App Modernization for .NET` > `Migration Tasks` and select the appropriate task directly.

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
