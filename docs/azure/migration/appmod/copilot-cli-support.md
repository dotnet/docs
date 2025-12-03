---
title: Migrate .NET apps to Azure using GitHub Copilot app modernization in Copilot CLI
description: Overview of migrating .NET applications to Azure using GitHub Copilot app modernization in Copilot CLI.
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 11/11/2025
author: alexwolfmsft
ms.author: alexwolf
ms.reviewer: jessiehuang
---

# Migrate .NET apps to Azure using GitHub Copilot app modernization in Copilot CLI

## Overview

Learn how to migrate .NET applications to Azure with **GitHub Copilot app modernization** in the [**Copilot CLI**](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli).

>[!NOTE]
> GitHub Copilot CLI is available in the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business, and GitHub Copilot Enterprise plans.
> If you receive Copilot through an organization, an admin must enable the Copilot CLI policy in the organization settings.

## Why use Copilot CLI with app modernization

- Run modernization tasks from the terminal - no need to switch to an IDE.
- Use interactive (human-in-the-loop) and batch workflows.

## Prerequisites

- [Install Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli).
- A GitHub Copilot subscription. See [Copilot plans](https://github.com/features/copilot/plans?ref_product=copilot).
- [Install the .NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

## Get started

1. In a terminal, navigate to the .NET project folder containing the code you want to work on.
1. Run `copilot` to start Copilot CLI.

    ```bash
    copilot
    ```

    :::image type="content" source="./media/copilot-cli-entrance.png" lightbox="./media/copilot-cli-entrance.png" alt-text="Screenshot of app modernization entrance in Copilot CLI.":::

    Copilot asks you to confirm that you trust the files in this folder. For details, see [Using Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#trusted-directories).

    Choose one of the options:

    - **Yes, proceed**: Copilot can work with the files in this location for this session only.
    - **Yes, and remember this folder for future sessions**: Trust the files in this folder for this and future sessions. You won't be asked again when you start Copilot CLI here. Only choose this option if you are sure it will always be safe for Copilot to work with files in this location.
    - **No, exit (Esc)**: End the Copilot CLI session.

### Add the MCP Server

1. Run `/mcp add` in Copilot CLI using the configuration below. For example, here are two ways to add the .NET migration MCP server:

    ```text
    /mcp add DotNetAppModMcpServer-migrate
    ```

1. Fill the fields as follows:

    - Server Type: Local
    - Command: `dnx Microsoft.AppModernization.McpServer.DotNet.Migration --yes --source https://api.nuget.org/v3/index.json`
    - Environment Variables: Leave empty.
    - Tools: Use the default value `*`.

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

1. Run `/mcp show` to confirm the MCP server configuration.

    ```text
    /mcp show
    ```

### Configure a custom agent

1. Create a file in the local `~/.copilot/agents` directory named `appmod-dotnet.agent.md`.
1. Add the following content to define a User-level custom agent.

    For more information, visit [Use custom agents in Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#use-custom-agents).

    ```text
    ---
    # .NET Modernization Assistant - Custom GitHub Copilot Agent
    # This agent helps modernize .NET applications with modern technologies and prepare them for Azure
    # For format details, see: https://gh.io/customagents/config

    name: dotnet-modernization
    description: Expert assistant for modernizing .NET applications with modern technologies (logging, authentication, configuration) and preparing them for Azure migration, with specialized tools for assessment, code analysis, and step-by-step migration guidance.
    ---

    # .NET Modernization Assistant

    I am a specialized AI assistant for modernizing .NET applications with modern technologies and preparing them for Azure.

    ## What I Can Do

    - **Migration**: Execute structured migrations to modern technologies (logging, authentication, configuration, data access)
    - **Validation**: Run builds, tests, CVE checks, and consistency/completeness verification
    - **Tracking**: Maintain migration plans and progress in `.appmod/.migration/` directory
    - **Azure Preparation**: Modernize code patterns for cloud-native Azure deployment

    ## ⚠️ CRITICAL: Migration Workflow

    ### 1. Planning Phase (REQUIRED FIRST STEP)
    **Before any migration work, I MUST call `dotnet_migration_plan_tool` first.**

    This tool will provide instructions for generating `plan.md` and `progress.md` files in `.appmod/.migration/`.

    ### 2. Execution Phase
    **I MUST strictly follow the plan and progress files.**

    Migration phases in order:
    1. **Analysis**: Analyze the solution structure and dependencies
    2. **Dependencies**: Update NuGet packages and project references
    3. **Configuration**: Migrate config files (app.config/web.config → appsettings.json)
    4. **Code**: Transform code to modern .NET patterns
    5. **Verification** (MANDATORY - NO SKIPPING):
      - ✅ Build verification (use bash command `dotnet msbuild`)
      - ✅ CVE vulnerability check (`check_cve_vulnerability`)
      - ✅ Consistency check (`migration_consistency`)
      - ✅ Completeness check (`migration_completeness`)
      - ✅ Unit test verification (use bash command `dotnet test`)

    ### 3. Completion Phase
    **Write a brief summary of the migration process**, including:
    - What was migrated
    - Key changes made
    - Verification results
    - Any issues encountered and resolved

    ## Core Principles

    1. **Always call tools in real-time** - Never reuse previous results
    2. **Follow the plan strictly** - Update `progress.md` after each task
    3. **Never skip verification steps** - All checks are mandatory
    4. **Use tools, not instructions** - Execute actions directly via tools
    5. **Track progress** - Create Git branches and commits for each task

    ## Important Rules

    ✅ **DO:**
    - Call `dotnet_migration_plan_tool` before any migration
    - Follow plan.md and progress.md strictly
    - Complete ALL verification steps
    - Write migration summary at completion
    - Read files before editing them
    - Track all changes in Git

    ❌ **DON'T:**
    - Skip the planning tool
    - Skip any verification steps
    - Reuse previous tool results
    - Stop mid-migration for confirmation
    - Skip progress tracking

    ---

    **Ready to modernize your .NET applications?** Ask me to start a migration!

    ```

    Use the custom agent in one of the following ways:

    - Use the slash command in interactive mode to select from the list of available custom agents:

      ```text
      /agent
      ```

      :::image type="content" source="./media/select-custom-agent.png" lightbox="./media/select-custom-agent.png" alt-text="Screenshot of selecting .NET migration custom agent in Copilot CLI.":::

    - Call the custom agent directly in a prompt:

      ```text
      Use the dotnet modernization agent to migrate this application from local File IO to use Azure Blob Storage.
      ```

### Run the migration task in Copilot CLI.

Describe your migration scenario in Copilot CLI to migrate your .NET app to Azure. Use a prompt like:

```text
*migrate from X to Y* for any migration task
```

Copilot CLI supports predefined migration scenarios that follow Microsoft best practices. For details, see [migration tasks](predefined-tasks.md).

Example prompts:

```text
Use the dotnet modernization agent to migrate this app from local file I/O to Azure Blob Storage
Use the dotnet modernization agent to migrate this app from local SQL Server to Azure SQL Database with managed identity
Use the dotnet modernization agent to migrate this app from file-based logging to OpenTelemetry
```

The migration task runs and shows progress in Copilot CLI.

:::image type="content" source="./media/migrate-details.png" lightbox="./media/migrate-details.png" alt-text="Screenshot of a .NET migration task progress details in Copilot CLI.":::

After migration, view the summary:

:::image type="content" source="./media/migrate-summary.png" lightbox="./media/migrate-summary.png" alt-text="Screenshot of the .NET migration summary in Copilot CLI.":::

## Provide feedback

Share feedback about GitHub Copilot CLI using the [GitHub Copilot CLI feedback form](https://aka.ms/AM4DFeedback).

## Reference

- [Using GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#using-copilot-cli)
