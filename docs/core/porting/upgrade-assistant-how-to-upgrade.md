---
title: How to upgrade a project with .NET Upgrade Assistant
description: "Learn how to upgrade one or more projects with .NET Upgrade Assistant using either Visual Studio or a terminal."
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 10/08/2024

#customer intent: As a developer, I want to upgrade my project to take advantage of the latest version of .NET.

---

# Upgrade projects with .NET Upgrade Assistant

The focus of this article is to provide the basic steps to upgrade a project with .NET Upgrade Assistant. This involves initiating the upgrade and reviewing the results. Based on how complex your project is, you might be required to perform manual updates to your code.

Some project types have specific guidance on upgrading. For more information, see [Supported project types](upgrade-assistant-overview.md#supported-project-types).

## Prerequisites

- For Visual Studio, see [Install .NET Upgrade Assistant - Visual Studio extension](upgrade-assistant-install.md#visual-studio-extension).
- For the .NET Global Tool, see [Install .NET Upgrade Assistant - .NET Global Tool](upgrade-assistant-install.md#net-global-tool).

## Upgrade a project in Visual Studio

Follow these steps to upgrade a project in Visual Studio.

1. Back up your code.
1. Open Visual Studio.
1. Open a project or solution.
1. In the **Solution Explorer** window, right-click on the **project** > **Upgrade**.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-right-click.png" alt-text="The Solution Explorer window in Visual Studio, showing the right-click menu of a project. The Upgrade menu item is highlighted.":::

1. In the **Upgrade** tab, select the appropriate upgrade options.

   Based on the type of project and the target framework version, different options are presented. The following image shows two options when upgrading a Windows Forms for .NET Framework project. These options aren't displayed when upgrading a .NET project:

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-welcome-framework.png" alt-text="The .NET Upgrade Assistant welcome screen in Visual Studio.":::

   In this example, select **Upgrade project to a newer .NET version**.

1. Select how you want to perform the upgrade. Select **In-place project upgrade**, then select **Next**.

   Some projects may only present you with a single option. For more information about these options, see [How the upgrade should be performed](upgrade-assistant-overview.md#how-the-upgrade-should-be-performed).

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-type.png" alt-text="The .NET Upgrade Assistant wizard showing the 'What is your upgrade type' selection. 'In-place project upgrade' is highlighted, as is the 'Next' button.":::

1. Select the target framework, for example **.NET 8.0**. Then, select **Next**.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-target-framework.png" alt-text="The .NET Upgrade Assistant wizard showing the 'What is your preferred target framework' selection. '.NET 8.0' is highlighted, as is the 'Next' button.":::

1. Select the components to upgrade, then select **Upgrade selection**.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-select-components.png" alt-text="The .NET Upgrade Assistant wizard showing the 'Select components to upgrade' selection. The list of components is highlighted, as is the 'Upgrade selection' button.":::

1. Once the upgrade is complete, a list of processed items is shown.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/vs-upgrade-finished.png" alt-text="The .NET Upgrade Assistant wizard showing the summary screen. Each artifact processed by the upgrade is listed, with a status icon.":::

Each artifact processed by the upgrade is listed, along with its status. For more information, see [Upgrade results](upgrade-assistant-overview.md#upgrade-results).

## Upgrade a project from the CLI

Follow these steps to upgrade a project using the terminal. The .NET Global Tool is an interactive tool that guides you through the upgrade options. Use the <kbd>Up arrow</kbd> and <kbd>Down arrow</kbd> keys to change the highlighted option, and <kbd>Enter</kbd> to run the select the option. Each screen presents you options on how you want to configure the upgrade.

1. Back up your code.
1. Open a terminal and navigate to the folder containing the solution or project you want to upgrade.
1. To start the tool, run the `upgrade-assistant upgrade` command.

   You're asked about what you want to upgrade. Depending on what is detected, some options might be automatically applied or missing entirely.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/cli-upgrade-start.png" alt-text="A terminal showing the initial screen of options for .NET Upgrade Assistant Global Tool. The question 'Which project do you want to upgrade' is being asked.":::

1. If more than one project is found, choose one of the projects and press <kbd>Enter</kbd>.

   Upgrade projects in the order of their dependency. For example, the previous image showed two projects: `MatchingGame` and `MatchingGame.Logic`. `MatchingGame` is dependent on `MatchingGame.Logic`, so `MatchingGame.Logic` should be upgraded first.

1. If you have an option to change the **Upgrade type**, choose one and press <kbd>Enter</kbd>. If only one option was available, it would have been automatically selected.

   For more information about these options, see [How the upgrade should be performed](upgrade-assistant-overview.md#how-the-upgrade-should-be-performed).

   > [!TIP]
   > If you've backed up your code, it's safe to select **In-place project upgrade**.

1. Choose a target framework, such as **.NET 8.0**, and press <kbd>Enter</kbd>.
1. The final prompt is a confirmation, displaying all of the options selected. Press <kbd>Enter</kbd> to start the upgrade.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/cli-upgrade-options-end.png" alt-text="A terminal showing the summary screen of options for .NET Upgrade Assistant Global Tool. The user is asked to continue.":::

1. Once the upgrade finishes, a summary is shown.

   :::image type="content" source="./media/upgrade-assistant-how-to-upgrade/cli-upgrade-end.png" alt-text="A terminal showing the results of the upgrade command when using the .NET Upgrade Assistant Global Tool.":::

## Related content

- [What is .NET Upgrade Assistant?](upgrade-assistant-overview.md)
- [What is code analysis with .NET Upgrade Assistant?](upgrade-assistant-analyze-overview.md)
- [Analyze projects with .NET Upgrade Assistant](upgrade-assistant-how-to-analyze.md)
