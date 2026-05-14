---
title: Modernize applications using GitHub Copilot modernization in Copilot CLI
description: Overview of modernizing Java and .NET applications using GitHub Copilot modernization plugin in Copilot CLI.
ms.topic: concept-article
ms.custom: devx-track-java, devx-track-dotnet
ms.date: 05/14/2026
ms.reviewer: jessiehuang
---

# Modernize applications using GitHub Copilot modernization in Copilot CLI

## Overview

Learn how to modernize Java and .NET applications using the **GitHub Copilot modernization** plugin in [**Copilot CLI**](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli).

The plugin provides an autonomous, multi-agent workflow that assesses your application, generates an executable modernization plan, and carries out the migration — all from the terminal. It supports Java upgrades, Azure migrations, CVE vulnerability fixes, and application rearchitecture.

> [!NOTE]
> GitHub Copilot CLI is available in the GitHub Copilot Pro, GitHub Copilot Pro+, GitHub Copilot Business, and GitHub Copilot Enterprise plans.
> If you receive Copilot through an organization, an admin must enable the Copilot CLI policy in the organization settings.

## What you can do

| Capability | Description |
|---|---|
| **Java upgrades** | Java version upgrades (8 → 17 → 21), Spring Boot 2.x → 3.x, javax → jakarta migration, deprecated API migration |
| **Azure migration** | Migrate Java and .NET applications to Azure services (Service Bus, Azure SQL, Redis, Key Vault, Application Insights, Managed Identity) |
| **CVE and vulnerability fixing** | Scan and fix CVE vulnerabilities in Maven and NuGet dependencies |
| **Application rearchitecture** | Structural rewrites such as monolith-to-microservices decomposition, legacy UI modernization, and module extraction |
| **.NET modernization** | Assess and migrate .NET applications to Azure, including NuGet security audits and ASP.NET-to-Azure migrations |

## Prerequisites

- [Install Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli).
- A GitHub Copilot subscription. See [Copilot plans](https://github.com/features/copilot/plans?ref_product=copilot).
- For Java projects: JDK 8+ and Maven or Gradle installed.
- For .NET projects: .NET SDK installed.

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

1. Navigate to your project folder and start Copilot CLI:

    ```bash
    cd /path/to/your/project
    copilot --agent=github-copilot-modernization:modernize
    ```

1. Describe what you want in natural language:

    ```text
    copilot> modernize my application
    ```

    Or be more specific:

    ```text
    copilot> upgrade this app to Java 21
    copilot> migrate this Spring Boot app to Azure
    copilot> fix CVE vulnerabilities in my project
    copilot> modernize my .NET application for Azure
    ```

For unattended execution, use the `--allow-all` flag:

```bash
copilot --agent=github-copilot-modernization:modernize --allow-all
```

## How the workflow works

The plugin uses a three-phase workflow that runs automatically. You don't need to invoke each phase manually — the orchestrator handles routing based on your request.

### Phase 1: Assessment

- Auto-detects the project language (Java or .NET) and uses the appropriate analysis tools.
- Analyzes dependencies, frameworks, and versions.
- Identifies modernization opportunities and risks.
- Saves results to `.github/modernize/assessment/`.

### Phase 2: Planning

- Loads assessment results and enterprise playbook constraints (if present).
- Generates an executable task plan.
- Saves the plan to `.github/modernize/<app>/plan.md` and `tasks.json`.

### Phase 3: Execution

- Routes tasks to specialized executor agents based on language and task type.
- Each executor queries a knowledge base for migration patterns.
- Monitors progress with automatic retry on failure.
- Creates detailed per-task commits for review.

The orchestrator supports multiple entry points depending on your intent:

| Workflow | When it activates | What happens |
|---|---|---|
| **Broad intent** | "modernize my application" | Full assess → plan → execute pipeline |
| **Specific task** | "upgrade to Java 21" | Skips assessment, goes straight to plan → execute |
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
| **Upgrade standards** | Target Java version (17 or 21), Spring Boot version (3.x), .NET version, framework migration paths |
| **Guardrails** | Prohibited technologies, security requirements, compliance constraints, authentication standards |
| **Coding standards** | Naming conventions, authentication patterns, logging frameworks |
| **Migration strategy** | Scope boundaries, 6R classification preferences (rehost vs. refactor vs. rearchitect), phasing strategy |

### Example playbook

Create a file at `.github/modernize/playbook/enterprise-standards.md`:

```markdown
# Enterprise Modernization Standards

## Target Architecture
- All Java applications must target Java 21 and Spring Boot 3.x
- Use Azure Container Apps for microservices deployments
- Use Azure Service Bus for all asynchronous messaging (replace RabbitMQ, ActiveMQ)
- Use Azure Database for PostgreSQL Flexible Server for relational data

## Security & Compliance
- All services must authenticate using Managed Identity — no connection strings or passwords in code
- All public endpoints must be behind Azure Front Door

## Guardrails
- Do not use Azure Functions for long-running processes
- Do not introduce Kafka — use Event Hubs with Kafka protocol if needed
- All infrastructure must be defined in Bicep
```

No fixed naming or structure is required. The orchestrator infers the purpose of each file from its content.

### Built-in defaults

Without a playbook, the plugin applies sensible defaults:

- **Java**: Upgrade to 17+ (21 only if explicitly requested); Spring Boot 3.x with javax → jakarta migration.
- **Azure**: Managed Identity for authentication; managed database services for relational data.
- **Messaging**: RabbitMQ/ActiveMQ → Azure Service Bus; Kafka → Azure Event Hubs.
- **Infrastructure**: Bicep by default.

## Common scenarios

### Java version upgrade

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> upgrade this app to Java 21
```

### Azure migration (Java)

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> migrate this Spring Boot app to Azure
```

### Azure migration (.NET)

```bash
copilot --agent=github-copilot-modernization:modernize
copilot> modernize my .NET application for Azure
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

### Full modernization (upgrade + migration)

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

- For Java projects: verify `pom.xml` or `build.gradle` exists in your project root.
- For .NET projects: verify `.csproj` or `.sln` exists in your project root.
- Ensure you are in the correct directory before starting Copilot CLI.

### MCP server issues

The plugin uses the MCP server defined in its configuration. If you encounter issues, try reinstalling the plugin to reset the MCP configuration.

## Provide feedback

Share feedback about GitHub Copilot CLI using the [GitHub Copilot CLI feedback form](https://aka.ms/AM4DFeedback).

## Reference

- [Using GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli#using-copilot-cli)
- [GitHub Copilot modernization plugin](https://github.com/microsoft/github-copilot-modernization)
