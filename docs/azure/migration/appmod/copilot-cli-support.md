---
title: Migrate .NET apps to Azure using GitHub Copilot modernization in Copilot CLI
description: Overview of migrating .NET applications to Azure using GitHub Copilot modernization plugin in Copilot CLI.
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 05/14/2026
ms.reviewer: jessiehuang
---

# Migrate .NET apps to Azure using GitHub Copilot modernization in Copilot CLI

## Overview

Learn how to migrate .NET applications to Azure using the **GitHub Copilot modernization** plugin in [**Copilot CLI**](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli).

The plugin provides an autonomous, multi-agent workflow that assesses your .NET application, generates an executable modernization plan, and carries out the migration — all from the terminal. It supports Azure migrations, CVE vulnerability fixes, and application rearchitecture.

> [!NOTE]
> GitHub Copilot CLI is available in the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business, and GitHub Copilot Enterprise plans.
> If you receive Copilot through an organization, an admin must enable the Copilot CLI policy in the organization settings.

## What you can do

| Capability | Description |
|---|---|
| **Azure migration** | Migrate .NET applications to Azure services (Service Bus, Azure SQL, Redis, Key Vault, Application Insights, Managed Identity) |
| **CVE and vulnerability fixing** | Scan and fix CVE vulnerabilities in NuGet dependencies |
| **Application rearchitecture** | Structural rewrites such as monolith-to-microservices decomposition, legacy UI modernization, and module extraction |
| **.NET modernization** | Assess and migrate .NET applications to Azure, including NuGet security audits and ASP.NET-to-Azure migrations |

## Prerequisites

- [Install Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli).
- A GitHub Copilot subscription. See [Copilot plans](https://github.com/features/copilot/plans?ref_product=copilot).
- .NET SDK installed.

## Install the plugin

1. In a terminal, run `copilot` to start Copilot CLI.

    ```bash
    copilot
    ```

1. Add the marketplace and install the plugin:

    ```bash
    copilot plugin marketplace add microsoft/github-copilot-modernization
    copilot plugin install github-copilot-modernization@github-copilot-modernization
    ```

1. Verify the plugin is installed by listing available agents:

    ```text
    /agent
    ```

    You should see `github-copilot-modernization:modernize` in the list.

> [!TIP]
> To update the plugin when a new version is available, run:
> ```bash
> copilot plugin update github-copilot-modernization@github-copilot-modernization
> ```

## Start a modernization task

### Option 1: Start with the agent directly

Navigate to your .NET project folder and start Copilot CLI with the modernization agent:

```bash
cd /path/to/your/dotnet-project
copilot --agent=github-copilot-modernization:modernize
```

### Option 2: Select the agent from inside Copilot CLI

If you're already in a Copilot CLI session, use the `/agent` command to switch to the modernization agent:

```text
/agent
```

Select `github-copilot-modernization:modernize` from the list.

> [!IMPORTANT]
> You must select the `github-copilot-modernization:modernize` agent before running any modernization prompts. Without selecting the agent, Copilot CLI uses the default agent which cannot leverage the full multi-agent orchestration, enterprise playbook support, and specialized migration capabilities provided by the plugin.

### Run a modernization prompt

Once the agent is active, describe what you want in natural language:

```text
copilot> modernize my application
```

Or be more specific:

```text
copilot> modernize my .NET application for Azure
copilot> migrate this app from local SQL Server to Azure SQL Database
copilot> fix CVE vulnerabilities in my project
```

For unattended execution, use the `--allow-all` flag:

```bash
copilot --agent=github-copilot-modernization:modernize --allow-all
```

## How the workflow works

The plugin uses a three-phase workflow that runs automatically. You don't need to invoke each phase manually — the orchestrator handles routing based on your request.

### Phase 1: Assessment

- Detects .NET project structure and uses the appropriate analysis tools.
- Analyzes dependencies, frameworks, and versions.
- Identifies modernization opportunities and risks.
- Saves results to `.github/modernize/assessment/`.

### Phase 2: Planning

- Loads assessment results and enterprise playbook constraints (if present).
- Generates an executable task plan.
- Saves the plan to `.github/modernize/<app>/plan.md` and `tasks.json`.

### Phase 3: Execution

- Routes tasks to specialized executor agents based on task type.
- Each executor queries a knowledge base for migration patterns.
- Monitors progress with automatic retry on failure.
- Creates detailed per-task commits for review.

The orchestrator supports multiple entry points depending on your intent:

| Workflow | When it activates | What happens |
|---|---|---|
| **Broad intent** | "modernize my application" | Full assess → plan → execute pipeline |
| **Specific task** | "migrate from SQL Server to Azure SQL" | Skips assessment, goes straight to plan → execute |
| **Execute existing plan** | "execute the plan" | Skips assessment and planning, runs an existing plan |
| **Headless** | Unattended execution with `--allow-all` | Same as broad intent with no user prompts |

## Define enterprise modernization policies

Organizations can embed their modernization intent — target architectures, upgrade standards, and compliance policies — directly into the workflow through a **playbook**. This ensures every generated plan aligns with enterprise standards without manual review of each decision.

### Set up a playbook

Place markdown files in the `.github/modernize/playbook/` directory of your project. The planning phase automatically reads all `.md` files in this folder and merges them with assessment results before generating the task plan.

> [!IMPORTANT]
> Playbook constraints override assessment recommendations. If your playbook specifies "use Azure Service Bus for messaging," that takes precedence regardless of what the assessment discovers.

### What you can define in a playbook

| Policy type | Examples |
|---|---|
| **Target architectures** | Compute services (App Service, AKS, Container Apps), database choices (Azure SQL, Cosmos DB), messaging platforms (Service Bus, Event Hubs) |
| **Upgrade standards** | Target .NET version, framework migration paths |
| **Guardrails** | Prohibited technologies, security requirements, compliance constraints, authentication standards |
| **Coding standards** | Naming conventions, authentication patterns, logging frameworks |
| **Migration strategy** | Scope boundaries, 6R classification preferences (rehost vs. refactor vs. rearchitect), phasing strategy |

### Example playbook

Create a file at `.github/modernize/playbook/enterprise-standards.md`:

```markdown
# Enterprise Modernization Standards

## Target Architecture
- Use Azure Container Apps for microservices deployments
- Use Azure Service Bus for all asynchronous messaging
- Use Azure SQL Database for relational data
- Use Azure Blob Storage for file storage

## Security & Compliance
- All services must authenticate using Managed Identity — no connection strings or passwords in code
- All public endpoints must be behind Azure Front Door

## Guardrails
- Do not use Azure Functions for long-running processes
- All infrastructure must be defined in Bicep
```

No fixed naming or structure is required. The orchestrator infers the purpose of each file from its content.

### Built-in defaults

Without a playbook, the plugin applies sensible defaults:

- **Azure**: Managed Identity for authentication; managed database services for relational data.
- **Messaging**: On-premises messaging → Azure Service Bus.
- **Infrastructure**: Bicep by default.

## Common scenarios

### Azure migration

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> modernize my .NET application for Azure
```

### Migrate from local SQL Server to Azure SQL

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> migrate this app from local SQL Server to Azure SQL Database with managed identity
```

### Migrate from file I/O to Azure Blob Storage

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> migrate this app from local file I/O to Azure Blob Storage
```

### CVE and security fix

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> fix CVE vulnerabilities in my project
```

### Application rearchitecture

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> rearchitect my monolithic application into microservices
```

### Full modernization

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> modernize my application
```

## Troubleshooting

### Plugin not found

```bash
# Verify marketplace is added
copilot plugin marketplace list

# Re-add marketplace if needed
copilot plugin marketplace add microsoft/github-copilot-modernization

# Reinstall
copilot plugin install github-copilot-modernization@github-copilot-modernization
```

### Assessment fails: no application found

- Verify `.csproj` or `.sln` exists in your project root.
- Ensure you are in the correct directory before starting Copilot CLI.

### MCP server issues

The plugin uses the MCP server defined in its configuration. If you encounter issues, try reinstalling the plugin to reset the MCP configuration.

## Provide feedback

Share feedback about GitHub Copilot CLI using the [GitHub Copilot CLI feedback form](https://aka.ms/AM4DFeedback).

## Reference

- [Using GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#using-copilot-cli)
- [GitHub Copilot modernization plugin](https://github.com/microsoft/github-copilot-modernization)
