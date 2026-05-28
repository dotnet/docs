---
ms.topic: include
ms.date: 05/22/2026
title: GitHub Copilot modernization in Copilot CLI
description: Learn how to assess .NET app readiness and migrate to Azure with GitHub Copilot modernization plugin in Copilot CLI. Follow step-by-step guidance for seamless modernization.
---

## Prerequisites

- A GitHub account with an active [GitHub Copilot](https://github.com/features/copilot) subscription under any plan.
- [Copilot CLI](https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli) installed.

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

1. Verify the plugin is installed:

    ```text
    /plugin list
    ```

    You should see `github-copilot-modernization` in the list.

## Assess app readiness

GitHub Copilot modernization assessment helps you find app readiness challenges, learn their impact, and see recommended migration tasks.

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository to your computer.

1. Navigate to the **Contoso University** project folder:

    ```bash
    cd dotnet-migration-copilot-samples/ContosoUniversity
    ```

1. Start Copilot CLI with the modernization agent:

    ```bash
    copilot --agent=github-copilot-modernization:modernize
    ```

    > [!IMPORTANT]
    > You must select the `github-copilot-modernization:modernize` agent before running any modernization prompts. If you're already in a Copilot CLI session, use `/agent` and select `github-copilot-modernization:modernize` from the list.

1. Ask the agent to assess the application:

    ```text
    copilot> modernize my application
    ```

    The agent automatically starts the assessment phase, analyzing your project for migration readiness — including dependencies, frameworks, and Azure migration opportunities.

1. When the assessment finishes, the agent presents a summary of findings and asks: **"Proceed to planning?"**

## App migrations

After reviewing the assessment, continue through the planning and execution phases.

### Full modernization (assess → plan → execute)

The agent runs the complete workflow automatically when you confirm each phase:

1. **Assessment** → Review findings → Confirm to proceed
1. **Planning** → The agent generates a migration plan (`plan.md`) → Review and confirm
1. **Execution** → The agent routes tasks to specialized executor agents that apply code changes, run builds, and validate results

The agent handles everything — just confirm at each checkpoint.

### Specific migration task

If you already know what you want to migrate, skip the assessment and go straight to execution:

```text
copilot> migrate from local SQL Server to Azure SQL Database
```

Or for multiple tasks:

```text
copilot> migrate from RabbitMQ to Azure Service Bus and upgrade to .NET 9
```

### Unattended execution

For fully autonomous execution without prompts, use the `--allow-all` flag:

```bash
copilot --agent=github-copilot-modernization:modernize --allow-all
```

### Enterprise rulebook

Organizations can embed modernization policies by placing markdown files in the `.github/modernize/rulebook/` directory. The planning phase merges rulebook constraints with assessment results — rulebook policies take precedence over assessment recommendations.

For more information, see [Migrate .NET apps to Azure using GitHub Copilot modernization in Copilot CLI](../copilot-cli-support.md#define-enterprise-modernization-policies).

### Validation

After code changes finish, the agent runs validation checks:

1. Build the project and resolve any build errors.
1. Detect Common Vulnerabilities and Exposures (CVEs) in dependencies and fix them.
1. Run tests and fix failures.

After all validations pass, the agent generates a summary. Review the results and verify:

```bash
dotnet build
dotnet test
```
