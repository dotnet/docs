---
title: Use GitHub Copilot for Visual Studio with the Azure Migrate application and code assessment for .NET
description: Learn how to use GitHub Copilot with the Azure Migrate application and code assessment tool for .NET when evaluating apps for Azure migrations.
ms.topic: upgrade-and-migration-article
ms.date: 10/09/2024
author: alexwolfmsft
ms.author: alexwolf
---

# Use Copilot Conversational Assessment with the Azure Migrate application and code assessment tool

Azure Migrate application and code assessment for .NET integrates with the GitHub Copilot extension for Visual Studio. Together, they provide conversational analysis about your migration reports. GitHub Copilot can help you learn more about the overall results and specific issues and determine next steps. In this article, you learn how to use GitHub Copilot to analyze the results of a completed Azure migration report.

> [!NOTE]
> Copilot integration is not available natively using the [.NET CLI version](dotnet-cli.md) of Azure Migrate application and code assessment for .NET.

## Prerequisites

- Install [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) version 17.10 or later
- [Install GitHub Copilot for Visual Studio extension](visual-studio.md)
- [Install a version of .NET](https://dotnet.microsoft.com/download) that supports the app you're trying to migrate
- [Scan your application in Visual Studio](visual-studio.md) to use Copilot conversational analysis. Copilot relies on a completed scan report to provide suggestions.

## Analyze the Azure compatibility report with Copilot

Visual Studio displays the results of the Azure Migrate application and code assessment tool scan using an interactive dashboard. If you have the GitHub Copilot extension installed, additional options are available to start a chat with your Copilot. You can start a chat about the overall results of the report, or prompt Copilot about a specific issue.

### Chat about the dashboard results

The main dashboard of the Azure compatibility report shows a summary of the scan, including next steps, issue severity, and issue categories. You can use GitHub Copilot to chat about these results and specific follow-up tasks.

1. In the **NEXT STEPS** section of the Azure compatibility report, select the **Open chat** button to launch a chat session with GitHub Copilot.
1. Visual Studio sends a default prompt asking for assistance with migrating the scanned solution. Copilot responds with a summary of the identified issues and provides clickable links to select specific issues to follow up on.

    :::image type="content" source="media/vs/copilot-dashbboard-analyze.png" lightbox="media/vs/copilot-dashbboard-analyze.png" alt-text="A screenshot showing GitHub Copilot integration with the Azure Migrate application and code assessment tool dashboard report page.":::

1. Select one of the proposed issues in the chat response to begin further analysis. You can also send your own custom chat prompts to Copilot using the input box at the bottom of the Copilot extension window.
1. Continue chatting with Copilot to explore solutions to the discovered issues.

### Chat about a specific issue

The Azure compatibility report also provides specific details about the aggregate issues discovered during the scan. You can use Copilot to investigate and learn more about these issues, as well as discover options or next steps to resolve them.

1. On the main dashboard page of the Azure compatibility report, select **Aggregate issues** on the left navigation to switch to the issues view. The new view displays a list of issues and related information, such as their estimated severity and state.
1. Select the arrow icon next to an issue you're interested in to see more details, and then select the **Ask Copilot** button to start a new Copilot chat about that specific issue.

    > [!NOTE]
    > The **Ask Copilot** feature shares the description of the issue and details about the code snippet that triggered the issue with GitHub Copilot. Only select **Ask Copilot** if you're comfortable sending the details of that issue to Copilot.

    :::image type="content" source="media/vs/copilot-issue-analyze.png" lightbox="media/vs/copilot-issue-analyze.png" alt-text="A screenshot showing GitHub Copilot integration with the Azure Migrate application and code assessment tool issues report page.":::

    In the preceding screenshot, the scan discovered that the app is using Windows authentication, which is not available on Azure, so Copilot responds with alternatives and general implementation steps.

1. Ask clarifying questions using the chat input at the bottom of the Copilot extension window.

## Next steps

- [Interpret the analysis results from the Azure Migrate application and code assessment for .NET](./interpret-results.md).
- [Customize analysis using run configs](custom-configuration.md)
- [Frequently asked questions](faq.md)
