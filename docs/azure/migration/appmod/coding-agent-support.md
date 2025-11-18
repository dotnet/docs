---
title: Migrate .NET apps to Azure using GitHub Copilot app modernization in Coding Agent
description: Overview of migrating .NET applications to Azure using GitHub Copilot app modernization in the Copilot Coding Agent.
ms.author: ninpan
ms.reviewer: jessiehuang
ms.topic: overview
ms.date: 11/14/2025
ms.custom: devx-track-dotnet
ms.subservice: migration-copilot
---

# Migrate .NET apps using GitHub Copilot app modernization in the Copilot Coding Agent

This article shows you how to migrate .NET apps using **GitHub Copilot app modernization** in the [**Copilot Coding Agent**](https://docs.github.com/en/copilot/concepts/agents/coding-agent/about-coding-agent). The agent works independently in the background to complete modernization tasks—similar to a human developer. Delegate tasks through issues or pull requests; the agent runs them in the cloud to help your team complete modernization efficiently.

> [!NOTE]
> Copilot Coding Agent is available with GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business, and GitHub Copilot Enterprise plans. The agent is available in all GitHub repositories except those owned by managed user accounts or where it's explicitly disabled.

## Prerequisites

- [**Copilot Coding Agent**](https://docs.github.com/en/copilot/concepts/agents/coding-agent/about-coding-agent) configured.
- A GitHub Copilot Pro, Pro+, Business, or Enterprise subscription.
- A GitHub repository containing your application source code.
- A Copilot environment with the .NET 10 SDK installed. See [customize the agent environment](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/customize-the-agent-environment) for details. To install the .NET 10 SDK, add these steps to the `copilot-setup-steps.yml`:

```yaml
- name: Set up .NET 10
  uses: actions/setup-dotnet@v5
  with:
    dotnet-version: '10.x'

- name: Verify .NET 10
  run: |
    dotnet --info
```

## Get started

1. Go to **Settings** for the target repository you want to modernize (admin access required).
1. Select **Copilot**, then select **Coding Agent**.
1. In the **Model Context Protocol (MCP)** section under **MCP Configuration**, add the following configuration, then select **Save Configuration**:

```json
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

:::image type="content" source="./media/coding-agent/mcp.png" lightbox="./media/coding-agent/mcp.png" alt-text="Screenshot of MCP configuration in coding agent.":::

1. (Optional) If environment variables are required, set them under **Environment → Copilot** in the settings. These variables initialize automatically the first time an agentic task is invoked in this repository.
1. Save the MCP configuration.

### Migrate your .NET application to Azure

To migrate your .NET application to Azure, describe your migration scenario in the agent prompt.

For details on predefined migration tasks, see [migration tasks](predefined-tasks.md). For example:

```text
Migrate this project from local file I/O to Azure Blob Storage
Migrate this project from local SQL Server to Azure SQL Database with managed identity
Migrate this project from file-based logging to OpenTelemetry
```

Open the Agents panel and enter your prompt. After you submit it, Copilot starts a new session and opens a new pull request. It appears in the list below the prompt box. Copilot works on the task and adds you as a reviewer when it finishes, triggering a notification.

:::image type="content" source="./media/coding-agent/migrate-input.png" lightbox="./media/coding-agent/migrate-input.png" alt-text="Screenshot of .NET migrate task input in Coding Agent.":::

After the migration starts, monitor the progress:
:::image type="content" source="./media/coding-agent/migrate-progress.png" lightbox="./media/coding-agent/migrate-progress.png" alt-text="Screenshot of .NET migrate progress in Coding Agent.":::

Finally, review the migration summary for insights—ensure your app is fully migrated and cloud-ready.
:::image type="content" source="./media/coding-agent/migrate-completion.png" lightbox="./media/coding-agent/migrate-completion.png" alt-text="Screenshot of .NET migrate completion in Coding Agent.":::

### Deploy your .NET application to Azure

After migration, deploy directly from Coding Agent using a prompt such as:

```text
Deploy this application to Azure
```

Follow the same workflow as migration—the overall process remains consistent.

## Provide feedback

Share feedback about the GitHub Copilot Coding Agent using the [GitHub Copilot agent feedback form](https://aka.ms/ghcp-appmod/feedback).

## Reference

- [Using GitHub Copilot Coding Agent](https://docs.github.com/en/copilot/how-tos/use-copilot-agents)
