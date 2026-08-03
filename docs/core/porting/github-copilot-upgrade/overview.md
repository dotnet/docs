---
title: GitHub Copilot upgrade overview
description: "Learn about GitHub Copilot upgrade, a Copilot agent available across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com that upgrades .NET projects to newer versions of .NET."
titleSuffix: ""
ms.topic: overview
ms.date: 07/07/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to learn about what GitHub Copilot upgrade is, so that I understand its capabilities and how I can take advantage of it.

---

# What is GitHub Copilot upgrade?

GitHub Copilot upgrade is a GitHub Copilot agent that helps you upgrade projects to newer versions of .NET quickly and confidently. It guides you through assessment, solution recommendations, code fixes, and validation across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com.

Use this agent to:

- Upgrade to a newer version of .NET.
- Modernize your .NET app, especially when upgrading from .NET Framework.
- Assess your application's code, configuration, and dependencies.
- Validate that your app builds and tests successfully.

## Scenarios

The agent provides multiple end-to-end modernization workflows called _scenarios_. Each scenario is a managed workflow that guides you through a specific type of upgrade or migration:

| Scenario | Description | Example prompt |
|---|---|---|
| **.NET version upgrade** | Upgrades from older .NET versions to .NET 8, 9, 10, or later. | _"Upgrade my solution to .NET 10"_ |
| **SDK-style conversion** | Converts legacy project format to SDK-style. | _"Convert to SDK-style"_ |
| **Newtonsoft.Json upgrade** | Replaces Newtonsoft.Json with System.Text.Json. | _"Upgrade from Newtonsoft.Json"_ |
| **SqlClient upgrade** | Upgrades from System.Data.SqlClient to Microsoft.Data.SqlClient. | _"Update SqlClient"_ |
| **Azure Functions upgrade** | Upgrades Azure Functions from in-process to isolated worker model. | _"Upgrade my Azure Functions"_ |
| **Semantic Kernel to Agents** | Upgrades Semantic Kernel Agents to Microsoft Agent Framework. | _"Upgrade my SK agents"_ |
| **Aspire integration** | Adds [Aspire](https://aspire.dev) support for inner-loop and Azure deployment. | _"Add Aspire to my app"_ |
| **Aspire version upgrade** | Upgrades existing Aspire applications to newer versions. | _"Upgrade my Aspire version"_ |
| **WebForms-to-Blazor upgrade** | Upgrades ASP.NET Web Forms applications to Blazor. | _"Migrate my Web Forms app to Blazor"_ |

For a full reference of all scenarios and 30+ built-in upgrade skills, see [Scenarios and skills reference](scenarios-and-skills.md).

## Provide feedback

Microsoft values your feedback and uses it to improve the agent. Leave feedback using either of these options:

- In Visual Studio, use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a problem](/visualstudio/ide/report-a-problem) options.

- File an issue at the [Upgrade Agent GitHub repository](https://github.com/microsoft/upgrade-agent-plugins).

## Prerequisites

Set up GitHub Copilot upgrade in your development environment before using the agent. For installation steps, see [Install GitHub Copilot upgrade](install.md).

## Upgrade .NET projects

The upgrade agent supports upgrading C# and Visual Basic projects of the following types:

- ASP.NET Core (and related technologies such as MVC, Razor Pages, and Web API)
- ASP.NET Web Forms
- Blazor
- Azure Functions
- Windows Presentation Foundation (WPF)
- Windows Forms
- WinUI
- .NET MAUI and Xamarin
- Class libraries
- Console apps
- Test projects (MSTest, NUnit, and xUnit)

To start an upgrade, see [Upgrade a .NET app with GitHub Copilot upgrade](how-to-upgrade-with-github-copilot.md).

### Supported upgrade paths

The agent supports the following upgrade paths:

[!INCLUDE[supported-upgrade-paths](./includes/supported-upgrade-paths.md)]

## Migrate .NET projects to Azure

To migrate your .NET applications to Azure, use the [GitHub Copilot modernization agent](../../../azure/migration/appmod/overview.md). The modernization agent handles Azure-specific scenarios such as database migration, storage, identity, messaging, and deployment.

## Monitor upgrades with the dashboard

The Upgrade Dashboard provides a visual view of an upgrade session in GitHub Copilot CLI and GitHub Copilot app. Use its panels to track overall progress, scenarios, tasks, projects, dependencies, assessment results, upgrade options, and agent activity.

To open the dashboard, ask Copilot to show it during an upgrade session. The dashboard isn't currently available in Visual Studio, Visual Studio Code, or other IDEs. For details about each panel, see [Monitor upgrades with the Upgrade Dashboard](dashboard.md).

## How it works

To start an upgrade or migration process, see:

[!INCLUDE[github-copilot-how-to-initiate](./includes/how-to-initiate.md)]

When you ask the upgrade agent to upgrade your app, Copilot first prompts you to create a new branch if you're working in a Git repository. Then Copilot assesses your project and runs a three-stage workflow. Each stage produces Markdown files under `.github/upgrades/{scenarioId}` in your repository so you can review what comes next before you continue. If `.github/upgrades/{scenarioId}` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

Copilot starts by examining your project structure, dependencies, and code patterns to build a comprehensive assessment. The `assessment.md` file lists breaking changes, API compatibility problems, deprecated patterns, and the upgrade scope.

After the assessment, Copilot runs the following three stages:

1. **Assessment:** Copilot examines your project structure, dependencies, and code patterns, then presents strategy decisions for your review, such as the upgrade strategy (bottom-up, top-down, or all-at-once), project upgrade approach, technology modernization options, and compatibility handling. Copilot saves confirmed decisions to `upgrade-options.md`.

1. **Planning:** Copilot converts the assessment and your confirmed options into a detailed specification. The `plan.md` file documents upgrade strategies, refactoring approaches, dependency paths, and risk mitigations.

1. **Execution:** Copilot breaks the plan into sequential, concrete tasks with validation criteria in `tasks.md`. Each task describes a single change and how Copilot confirms it succeeded.

Edit any of the Markdown files in `.github/upgrades/{scenarioId}` to adjust upgrade steps or add context before you move forward.

### Upgrade strategies

During the assessment stage, the agent evaluates your solution and recommends one of these strategies:

| Strategy | Best for | Description |
|---|---|---|
| **Bottom-up** | Large solutions with deep dependency graphs | Upgrades leaf projects first, then works upward. |
| **Top-down** | Quick feedback on the main application | Upgrades the application project first, then fixes dependencies. |
| **All-at-once** | Small, simple solutions | Upgrades all projects in one pass. |

### Flow modes

The agent supports two flow modes that control how much it pauses for your input:

- **Automatic:** The agent works through all stages without pausing, stopping only at genuine blockers. Best for experienced users and straightforward upgrades.
- **Guided:** The agent pauses at each stage boundary so you can review the assessment, plan, and tasks before proceeding. Best for first-time users and complex solutions.

Switch between modes at any time by saying _"pause"_ (to enter guided mode) or _"continue"_ (to enter automatic mode).

### State management

The agent stores all upgrade state in `.github/upgrades/{scenarioId}/`. The folder contains:

| File | Purpose |
|---|---|
| `assessment.md` | Analysis of your solution |
| `upgrade-options.md` | Confirmed upgrade decisions |
| `plan.md` | Ordered task plan |
| `tasks.md` | Live progress dashboard |
| `scenario-instructions.md` | Agent's persistent memory, including preferences, decisions, and custom instructions |
| `tasks/{taskId}/task.md` | Per-task scope and context |
| `tasks/{taskId}/progress-details.md` | Per-task execution notes and results |

Because all state lives in this folder, you can close your IDE, switch between sessions, or even switch between development environments (for example, start in VS Code and continue in Visual Studio). The agent picks up where it left off.

> [!TIP]
> Commit the `.github/upgrades/` folder to your branch. The committed state serves as a backup and lets team members view upgrade progress.

### Perform the upgrade

After each stage completes, review and modify the generated files as needed, and then tell Copilot to continue to the next stage.

When you reach the **Execution** stage, tell Copilot to start the upgrade. If Copilot runs into a problem, it tries to identify the cause and apply a fix. If Copilot can't correct the problem, it asks for your help. When you intervene, Copilot learns from the changes you make and tries to automatically apply them if the problem comes up again.

### Upgrade results

As Copilot runs each task, it updates the `tasks.md` file in `.github/upgrades/{scenarioId}` with the status of every step. Monitor progress by reviewing this file. Copilot creates a Git commit for every portion of the process, so you can roll back changes or review what changed.

When the upgrade finishes, Copilot displays next steps in the chat response.

## Telemetry

The tool collects data about project types, intent to upgrade, and upgrade duration. The development environment collects and aggregates the data and doesn't contain any user-identifiable information. For more information about Microsoft's privacy policy, see [Visual Studio Customer Experience Improvement Program](/visualstudio/ide/visual-studio-experience-improvement-program?view=visualstudio&preserve-view=true).

## Related content

- [Install GitHub Copilot upgrade](install.md)
- [Upgrade a .NET app with GitHub Copilot upgrade](how-to-upgrade-with-github-copilot.md)
- [Monitor upgrades with the Upgrade Dashboard](dashboard.md)
- [Core concepts](concepts.md)
- [Scenarios and skills reference](scenarios-and-skills.md)
- [Best practices](best-practices.md)
- [Troubleshoot GitHub Copilot upgrade](troubleshooting.md)
- [GitHub Copilot upgrade FAQ](faq.yml)
