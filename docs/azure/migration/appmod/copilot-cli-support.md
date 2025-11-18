---
title: Migrate .NET Apps to Azure Using GitHub Copilot App Modernization in Copilot CLI
description: Provides an overview of how .NET developers can migrate applications to Azure using GitHub Copilot App Modernization in the Copilot CLI.
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 11/11/2025
author: alexwolfmsft
ms.author: alexwolf
ms.reviewer: jessiehuang
---

# Migrate .NET apps to Azure using GitHub Copilot App Modernization in Copilot CLI

## Overview

Learn how .NET developers migrate applications to Azure with **GitHub Copilot App Modernization** in the [**Copilot CLI**](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli). Modernize apps wherever you code. It’s in public preview—give it a try and let us know if you have [feedback](https://aka.ms/ghcp-appmod/feedback).
:::image type="content" source="./media/copilot-cli-entrance.png" lightbox="./media/copilot-cli-entrance.png" alt-text="Screenshot of app modernization entrance in Copilot CLI.":::

>[!NOTE]
>GitHub Copilot CLI is available in the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business, and GitHub Copilot Enterprise plans.
>If you get Copilot through an organization, an admin enables the Copilot CLI policy in the organization settings.

## Why use Copilot CLI with app modernization

- Run modernization tasks from the terminal—no need to switch to an IDE  
- Use interactive (human-in-the-loop) and batch workflows

## Prerequisites

- [Install Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli)
- GitHub Copilot subscription. See [Copilot plans](https://github.com/features/copilot/plans?ref_product=copilot).
- Install the .NET 10 SDK (required for the dnx command). [Download .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0).

## Getting started

1. In a terminal, go to the .NET project folder that has the code you want to work on.
1. Run `copilot` to start Copilot CLI.

    ```bash
    copilot
    ```

    Copilot asks you to confirm that you trust the files in this folder. For details, see [Using Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#trusted-directories).

    Choose one of the options:

    - Yes, proceed: Copilot can work with the files in this location for this session only.
    - Yes, and remember this folder for future sessions: You trust the files in this folder for this and future sessions. You won't be asked again when you start Copilot CLI from this folder. Only choose this option if you are sure that it will always be safe for Copilot to work with files in this location.
    - No, exit (Esc): End your Copilot CLI session.

1. Add MCP servers. Run `/mcp add` in Copilot CLI using the configuration below. For example, to add the .NET migration MCP server:

    ```bash
    /mcp add DotNetAppModMcpServer-migrate
    ```

    Fill the fields as follows:

    - Server Type: Local
    - Command: dnx Microsoft.AppModernization.McpServer.DotNet.Migration --yes --source https://api.nuget.org/v3/index.json  
    - Environment Variables: Leave empty
    - Tools: Use the default value *

    Or update the `~/.config/mcp-config.json` file with the following information. For details, see [Add an MCP server](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#add-an-mcp-server).

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

    Run `/mcp show` to check that the MCP servers are configured.

    ```bash
    /mcp show
    ```

1. Run the migration task in Copilot CLI.

    Describe your migration scenario in Copilot CLI to migrate your .NET app to Azure.
    Use a prompt like "migrate from X to Y" for any migration task.
    Copilot CLI supports predefined migration scenarios that follow Microsoft best practices. For details, see [migration tasks](predefined-tasks.md).

    Some example prompts:

    ```text
    Migrate this app from local file I/O to Azure Blob Storage
    Migrate this app from local SQL Server to Azure SQL DB with managed identity
    Migrate this app from file-based logging to OpenTelemetry
    ```

    The migration task runs and shows progress in Copilot CLI.
    :::image type="content" source="./media/migrate-details.png" lightbox="./media/migrate-details.png" alt-text="Screenshot of a .NET migration task progress details in Copilot CLI.":::

    The project is migrated. View the summary:
    :::image type="content" source="./media/migrate-summary.png" lightbox="./media/migrate-summary.png" alt-text="Screenshot of the .NET migration summary in Copilot CLI.":::

## Provide feedback

Share feedback about GitHub Copilot CLI in the [GitHub Copilot CLI feedback form](https://aka.ms/AM4DFeedback).

## Reference

- [Using GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#using-copilot-cli)
