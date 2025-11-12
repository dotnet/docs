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

# Migrate .NET Apps to Azure Using GitHub Copilot App Modernization in Copilot CLI

## Overview

This article provides an overview of how .NET developers can migrate their applications to Azure using **GitHub Copilot App Modernization** within the [**Copilot CLI**](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli), enabling them to modernize applications wherever they code. It’s currently in public preview — give it a try and let us know if any [feedback](https://aka.ms/ghcp-appmod/feedback).
:::image type="content" source="./media/copilot-cli-entrance.png" lightbox="./media/copilot-cli-entrance.png" alt-text="Screenshot of app mod entrance in Copilot CLI":::

>[!NOTE]
>GitHub Copilot CLI is available with the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business and GitHub Copilot Enterprise plans.
>If you receive Copilot from an organization, the Copilot CLI policy must be enabled in the organization's settings.

## Why Use Copilot CLI with App Modernization
- Run modernization tasks directly from the terminal — no need to switch to an IDE  
- Supports both interactive (human-in-the-loop) and batch workflows

## Prerequisites
- [Install Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli)
- A GitHub Copilot subscription, See [Copilot plans](https://github.com/features/copilot/plans?ref_product=copilot)
- Node.js version 22 or later
- npm version 10 or later

## Getting Started
1. In your terminal, navigate to the .NET project folder containing the code you want to work on.
2. Enter `copilot` to start Copilot CLI.
```
copilot
```
Copilot will ask you to confirm that you trust the files in this folder. Refer to [Using Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#trusted-directories)
Choose one of the options:
- Yes, proceed: Copilot can work with the files in this location for this session only.
- Yes, and remember this folder for future sessions: You trust the files in this folder for this and future sessions. You won't be asked again when you start Copilot CLI from this folder. Only choose this option if you are sure that it will always be safe for Copilot to work with files in this location.
- No, exit (Esc): End your Copilot CLI session.
3. You can add MCP servers by running `/mcp add` in Copilot CLI according to the configuration below, here is an example of adding .NET migration MCP:
```
/mcp add net-migrate
```
Or by manually updating the `~/.config/mcp-config.json` file with the following info. Refer to [Add an MCP server](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#add-an-mcp-server)
```
{
  "mcpServers": {
    "dotnet-migrate": {
      "type": "local",
      "tools": [
        "*"
      ],
      "command": "npx",
      "args": [
        "-y",
        "net-migrate" // TODO: update to actual package name
      ]
    }
  }
}
```
You can run `/mcp show` to verify the MCP servers are correctly configured.
```
/mcp show
```
4. Execute the migration task in Copilot CLI
To migrate your .NET application to Azure, describe your migration scenario in Copilot CLI.
For details on predefined migration tasks, see [migration tasks](predefined-tasks.md)
For example:
```
Migrate this app from local file IO to Azure Blob Storage
```

Then the migration task will be executed and showing progress in Copilot CLI
:::image type="content" source="./media/migrate-details.png" lightbox="./media/migrate-details.png" alt-text="Screenshot of migrating .NET in Copilot CLI":::

The project has been successfully migrated to Azure, with below summary:
:::image type="content" source="./media/migrate-summary.png" lightbox="./media/migrate-summary.png" alt-text="Screenshot of migrating .NET summary in Copilot CLI":::

## Provide Feedback
If you have any feedback about GitHub Copilot CLI, please let us know your [feedback](https://aka.ms/AM4DFeedback).

## Reference
- [Using GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#using-copilot-cli).
