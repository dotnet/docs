---
title: How to analyze a project with .NET Upgrade Assistant
description: "Learn how to analyze one or more projects with .NET Upgrade Assistant. Before upgrading, it's a good idea to perform code analysis on your projects so that you understand if extra effort is required after upgrading."
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 10/08/2024

#customer intent: As a developer, I want to analyze my project before upgrading to identify any issues before performing an upgrade.

---

# Analyze projects with .NET Upgrade Assistant

This article teaches you how to perform code analysis on your projects with .NET Upgrade Assistant, using Visual Studio or the terminal. The analysis generates a report that you can browse to get more information about the upgrade.

## Prerequisites

- For Visual Studio, see [Install .NET Upgrade Assistant - Visual Studio extension](upgrade-assistant-install.md#visual-studio-extension).
- For the .NET Global Tool, see [Install .NET Upgrade Assistant - .NET Global Tool](upgrade-assistant-install.md#net-global-tool).

## Create a report in Visual Studio

Follow these steps to analyze a project in Visual Studio.

1. Open Visual Studio.
1. Open a project or solution.
1. In the **Solution Explorer** window, right-click on the **solution** > **Upgrade**.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-right-click.png" alt-text="The Solution Explorer window in Visual Studio, showing the right-click menu of the solution. The Upgrade menu item is highlighted.":::

1. In the **Upgrade Assistant: Home** tab, select **New Report**.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-new-report.png" alt-text="The .NET Upgrade Assistant Analyze wizard's welcome page in Visual Studio. The 'New Report' link is highlighted.":::

1. Select one or more projects to analyze, then select **Next**.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-select-projs.png" alt-text="The .NET Upgrade Assistant Analyze wizard's 'Select projects' page in Visual Studio. The list of projects is highlighted along with the 'Next' button.":::

1. Select the target framework, for example .NET 8.0. Then, select **Next**.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-target-framework.png" alt-text="The .NET Upgrade Assistant Analyze wizard's 'Target framework' page in Visual Studio. The '.NET 8.0' item is highlighted along with the 'Next' button.":::

1. Select the components to analyze and then select **Next**.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-select-components.png" alt-text="The .NET Upgrade Assistant Analyze wizard's 'Analysis settings' page in Visual Studio. The 'Source code and settings' option is selected. The 'Next' button is highlighted.":::

1. A progress indicator is displayed for each project that's being analyzed.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-progress.png" alt-text="The .NET Upgrade Assistant Analyze wizard running the analysis.":::

1. Once the analysis is complete, the report dashboard is shown. For more information about the dashboard, see [Reports](upgrade-assistant-analyze-overview.md#reports).

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/vs-upgrade-analyze-finished.png" alt-text="The .NET Upgrade Assistant Analyze wizard showing a report dashboard that contains the results from the analysis.":::

## Create a report from the CLI

Follow these steps to analyze a project using the terminal. The .NET Global Tool is an interactive tool that guides you through the analysis options. Use the <kbd>Up arrow</kbd> and <kbd>Down arrow</kbd> keys to change the highlighted option, and <kbd>Enter</kbd> to run the select the option. Each screen presents you options on how you want to configure the report.

1. Open a terminal and navigate to the folder containing the solution or project you want to analyze.
1. To start the tool, run the `upgrade-assistant analyze` command.
1. You're asked about what you want to analyze. For this example, choose **Application sources** and press <kbd>Enter</kbd>.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/cli-upgrade-start.png" alt-text="A terminal showing the initial screen of options for .NET Upgrade Assistant Global Tool. The question 'What do you want to analyze' is being asked.":::

1. Choose a target framework, such as **.NET 8.0**, and press <kbd>Enter</kbd>.
1. Select the types of items you want to scan. Use <kbd>Spacebar</kbd> to toggle the options, and then press <kbd>Enter</kbd>.
1. On the **Config file** screen, press <kbd>n</kbd>, unless you have a ruleset config file to apply.
1. Choose the format of the generated report. For the purposes of this example, select **Save as HTML**.
1. Enter the name **MyReport** and press <kbd>Enter</kbd>.
1. Select the appropriate privacy mode, such as **Restricted** and press <kbd>Enter</kbd>.
1. The final prompt is a confirmation, displaying all of the options you selected. Press <kbd>Enter</kbd> to run the analysis and generate the report.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/cli-upgrade-options-end.png" alt-text="A terminal showing the summary screen of options for .NET Upgrade Assistant Global Tool. The user is asked to continue.":::

1. Once the report finishes, a summary of the report is displayed. The results of the report are saved to the folder of the project or solution that was analyzed.

   :::image type="content" source="./media/upgrade-assistant-how-to-analyze/cli-upgrade-end.png" alt-text="A terminal showing the results of the analysis command when using the .NET Upgrade Assistant Global Tool.":::

## Related content

- [What is code analysis with .NET Upgrade Assistant?](upgrade-assistant-analyze-overview.md)
- [What is .NET Upgrade Assistant?](upgrade-assistant-overview.md)
- [Install .NET Upgrade Assistant](upgrade-assistant-install.md)
