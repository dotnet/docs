---
title: Migrate .NET Apps to Azure Using GitHub Copilot App Modernization in Coding Agent
description: Provides an overview of how .NET developers can migrate applications to Azure using GitHub Copilot App Modernization in Copilot Coding Agent.
ms.author: ninpan
ms.reviewer: jessiehuang
ms.topic: overview
ms.date: 11/14/2025
ms.custom: devx-track-dotnet
ms.subservice: migration-copilot
---

# Migrate .NET Apps Using GitHub Copilot App Modernization in Coding Agent

This article provides an overview of how .NET developers can migrate their applications using **GitHub Copilot app modernization** within the [**Copilot Coding Agent**](https://docs.github.com/en/copilot/concepts/agents/coding-agent/about-coding-agent). The agent can work independently in the background to complete modernization tasks—just like a human developer. Developers can delegate tasks via issues or pull requests, and the agent executes them in the cloud, helping teams complete the entire modernization journey efficiently.  

>[!NOTE]
>Copilot coding agent is available with the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business and GitHub Copilot Enterprise plans. The agent is available in all repositories stored on GitHub, except repositories owned by managed user accounts and where it has been explicitly disabled.  

## Prerequisites
- [**Copilot Coding Agent**](https://docs.github.com/en/copilot/concepts/agents/coding-agent/about-coding-agent) configured  
- A GitHub Copilot Pro, Pro+, Business, or Enterprise subscription
- A GitHub repo
- A Copilot environment with .NET 10 SDK installed (for dnx command to run), See [customize the agent environment](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/customize-the-agent-environment) for more details. To install the .NET 10 SDK, add the following steps in the `copilot-setup-steps.yml`:
```
- name: Setup .NET 10
  uses: actions/setup-dotnet@v5
  with:
    dotnet-version: '10.x'

- name: Verify .NET 10
  run: |
    dotnet --info
```

## Getting Started
1. Go to the Settings of the target repository you want to modernize.(You must be an admin of this repository)
2. Select Copilot, then click "Coding Agent".
3. Under MCP Configuration in the Model Context Protocol (MCP) section, manually add the following configuration, and click "Save Configuration":
```
{
  "mcpServers": {
    "DotNetAppModMcpServer-migrate": {
      "type": "local",
      "command": "dnx",
      "tools": [
        "*"
      ],
      "args": [
        "Microsoft.AppModernization.McpServer.DotNet.Migration",
        "--yes",
        "--source",
        "https://api.nuget.org/v3/index.json"
      ]
    }
  }
}
```
:::image type="content" source="./media/coding-agent/mcp.png" lightbox="./media/coding-agent/mcp.png" alt-text="Screenshot of MCP configuration in coding agent":::
4. (Optional) If environment variables are required, set them under Environment → Copilot in the settings. These environment variables will be initialized automatically the first time a user invokes an agentic task in this repository.
5. Save the MCP configuration.

### Migrate your .NET Application to Azure
To migrate your .NET application to Azure, describe your migration scenario for Coding Agent.

For details on predefined migration tasks, see [migration tasks](predefined-tasks.md).
For example:
```
Migrate this project from local file IO to Azure Blob Storage
Migrate this project from local sql server to Azure SQL DB with managed identity
Migrate this project from file based logging to OpenTelemetry
```

Start by opening the Agents panel in the top-right corner and enter your prompt. After the prompt is entered, Copilot will start a new session and open a new Pull Request, which will appear in the list below the prompt box. Copilot will work on the task and then add you as a reviewer when it has finished, triggering a notification.

:::image type="content" source="./media/coding-agent/migrate-input.png" lightbox="./media/coding-agent/migrate-input.png" alt-text="Screenshot of .NET migrate task input in Coding Agent":::

After the migration starts, you can monitor the progress:
:::image type="content" source="./media/coding-agent/migrate-progress.png" lightbox="./media/coding-agent/migrate-progress.png" alt-text="Screenshot of .NET migrate progress in Coding Agent":::

Finally, you can review the migration summary for insights — ensuring your app is fully migrated and cloud-ready.
:::image type="content" source="./media/coding-agent/migrate-completion.png" lightbox="./media/coding-agent/migrate-completion.png" alt-text="Screenshot of .NET migrate completion in Coding Agent":::

### Deploy your .NET Application to Azure
After migrating your application, you can deploy it directly from Coding Agent by following prompt examples:
```
Deploy this application to Azure
```

You can follow the same steps as migration for deployment — the overall process remains consistent.

## Provide Feedback
If you have any feedback about GitHub Copilot agent, please let us know your [feedback](https://aka.ms/ghcp-appmod/feedback).

## Reference
- [Using GitHub Copilot agent](https://docs.github.com/en/copilot/how-tos/use-copilot-agents).