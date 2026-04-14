---
title: GitHub Copilot modernization core concepts
description: "Learn the key concepts behind GitHub Copilot modernization, including scenarios, skills, tasks, the three-stage workflow, state management, and flow modes."
ms.topic: concept-article
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to understand the core concepts of GitHub Copilot modernization so that I can use the agent effectively and get the best results from my upgrades.

---

# GitHub Copilot modernization concepts

GitHub Copilot modernization uses a structured approach to upgrade and migrate .NET projects. Understanding how the agent works, including its scenarios, skills, tasks, and workflow, helps you collaborate with the agent effectively and get the best results.

> [!TIP]
> Think of the agent as a skilled colleague who understands .NET deeply, follows a structured plan, and adapts to your feedback. The more context you give, the better the agent performs.

## The agent as a teammate

The agent excels at collaboration, not automation in a vacuum:

- **Deep .NET knowledge:** The agent understands project files, NuGet dependencies, breaking changes, and migration patterns across dozens of .NET technologies for both C# and Visual Basic projects.
- **Structured workflow:** Every upgrade goes through assessment, planning, and execution. No random changes, no surprises.
- **Learns your preferences:** When you say "always use explicit types instead of `var`," the agent writes that preference to `scenario-instructions.md` and remembers it across sessions.
- **Correctable mid-flight:** Made a wrong call? Tell the agent. It adapts and applies the correction going forward.
- **Explains its reasoning:** Ask _"why did you choose that approach?"_ and the agent walks you through the decision.

## Scenarios

A _scenario_ is a managed, end-to-end modernization workflow. When you tell the agent "upgrade my solution to .NET 10," you're triggering the `.NET version upgrade` scenario.

### How scenarios are discovered

You don't need to memorize scenario names. The agent discovers relevant scenarios automatically:

1. Analyzes your codebase to understand what technologies you're using, including language, framework version, libraries, and project types.
1. Identifies which scenarios are relevant to your projects.
1. Ranks scenarios by importance and weight. The most relevant ones surface first.

You can also ask directly: _"What scenarios are available for my solution?"_

### Scenario persistence

Each active scenario gets its own folder at `.github/upgrades/{scenarioId}/`. The scenario folder contains the plan, task progress, your preferences, and execution logs. The folder is part of your Git repository.

For a complete list of scenarios, see [Scenarios and skills reference](scenarios-and-skills.md).

## The workflow lifecycle

Every scenario follows the same lifecycle: a three-stage workflow.

### Stage 1: Assessment

The agent gathers everything it needs before starting work:

- **Target framework:** The version you're upgrading to.
- **Git strategy:** The agent suggests branching and you control the details: branch name, whether to use per-task branches, and commit timing.
- **Flow mode:** Automatic (agent drives) or Guided (you approve each stage).
- **Scenario-specific parameters:** Depending on the scenario, the agent might ask more questions.

The agent initializes the scenario workspace at `.github/upgrades/{scenarioId}/`.

The agent then analyzes your codebase:

- Project dependency graph (topological order)
- NuGet package compatibility with the target framework
- Breaking API changes
- Test coverage
- Complexity and risk factors

The agent saves a comprehensive assessment report to `assessment.md`.

Based on the assessment, the agent evaluates your solution and identifies which upgrade decisions are relevant. It presents sensible defaults and lets you review and override any choice.

Options might include:

- **Upgrade strategy:** Bottom-up, top-down, or all-at-once.
- **Project migration approach:** In-place rewrite or side-by-side for web applications; in-place or multi-targeting for libraries.
- **Technology modernization:** Choices for Entity Framework migration, dependency injection, logging, and configuration.
- **Package management:** Whether and when to adopt Central Package Management.
- **Compatibility handling:** How to address unsupported APIs and packages.

The agent saves confirmed decisions to `upgrade-options.md`.

In **Guided mode**, the agent pauses here for your review before proceeding.

### Stage 2: Planning

The agent creates the task plan based on the assessment and your confirmed options. Planning produces three key files:

- `plan.md`: The upgrade plan with strategy and task descriptions.
- `scenario-instructions.md`: Your preferences, decisions, and the agent's memory.
- `tasks.md` — The ordered list of tasks the agent will execute.

### Stage 3: Execution

The agent works through tasks sequentially. For each task in `tasks.md`, the agent follows a cycle: start, execute, validate (build and test), and complete. You control when and how the agent commits changes: per task, per group of tasks, or at the end. As the agent works, it updates `tasks.md` with live status indicators so you can track progress.

## Upgrade strategies

During the assessment stage, the agent evaluates your solution and recommends one of these strategies:

| Strategy | Best for | How it works |
|---|---|---|
| **Bottom-up** | Large solutions with deep dependency graphs | Start with leaf projects (no dependencies), work upward. |
| **Top-down** | Quick feedback on the main app | Start with the application project, fix dependencies as needed. |
| **All-at-once** | Small, simple solutions | Upgrade everything in one pass. |

> [!TIP]
> The agent only surfaces decisions that are relevant to your project. A simple console app doesn't see web framework choices, and a project without Entity Framework doesn't see database migration options.

## Skills

_Skills_ are smaller, targeted modernization capabilities. When the agent encounters EF6 code during an upgrade, it loads the EF6-to-EF-Core skill with detailed, step-by-step migration instructions. Invoke a skill directly during an upgrade: _"migrate the WCF services in my project to CoreWCF."_

The agent ships with 30+ built-in skills organized by domain:

- **Data access:** EF6 to EF Core (code-first and EDMX), LINQ to SQL, and SqlClient migration
- **Web/ASP.NET:** Identity, Global.asax, OWIN, MVC routing/filters/bundling, and WCF to CoreWCF
- **Serialization:** Newtonsoft.Json to System.Text.Json
- **Cloud:** Azure Functions in-process to isolated worker model
- **Libraries:** ADAL to MSAL, SignalR, PowerShell SDK, and more

Skills load automatically based on what the agent detects in your codebase. You don't need to manage skill loading. Just describe what you need.

For the complete list, see [Scenarios and skills reference](scenarios-and-skills.md).

## Tasks

_Tasks_ are the atomic units of work within a scenario. Each task represents a specific, bounded piece of the upgrade, such as "Upgrade CommonLib from .NET 6 to .NET 10" or "Migrate EF6 usage in DataLayer to EF Core."

### Task lifecycle

Tasks move through these states:

- **Available:** Ready to start, all dependencies met.
- **In Progress:** The agent is actively working on the task.
- **Completed:** Code changes applied, build passes, tests pass.

For each task, the agent:

1. Loads related skills and context.
1. Assesses complexity and decides whether the task needs subtasks.
1. Writes a scope summary to `tasks/{taskId}/task.md`.
1. Executes code changes.
1. Validates by running build and tests.
1. Records results in `tasks/{taskId}/progress-details.md`.
1. Commits changes and moves to the next task.

## State management

The agent maintains persistent state so you can stop and resume at any time. Everything lives in your repository under `.github/upgrades/{scenarioId}/`.

| File | Purpose |
|---|---|
| `scenario-instructions.md` | Your preferences, decisions, and custom instructions. The agent's persistent memory. |
| `upgrade-options.md` | Confirmed upgrade decisions |
| `plan.md` | The upgrade plan with strategy and task descriptions |
| `tasks.md` | Visual progress dashboard showing task status |
| `execution-log.md` | Detailed log of all changes and decisions |
| `tasks/{taskId}/task.md` | Per-task scope and context |
| `tasks/{taskId}/progress-details.md` | Per-task execution notes and results |

### Resumability

Close the chat, close your IDE, or come back the next day. The agent picks up where it left off:

1. On your next interaction, the agent checks the current state of your workspace automatically.
1. The agent detects the existing scenario and shows current progress, such as "3 of 8 tasks completed."
1. The agent detects stale tasks (stuck in progress from a previous interrupted session) and offers to resume or restart them.
1. The agent reloads your preferences from `scenario-instructions.md`.

### Cross-IDE continuity

Because state lives in Git, you can switch between VS Code, Visual Studio, and Copilot CLI mid-upgrade. The `.github/upgrades/` folder is the shared state that both IDEs understand.

> [!TIP]
> Commit the `.github/upgrades/` folder to your branch. Push the branch to a remote repository to let team members view progress or continue the upgrade on a different machine.

## Flow modes

The agent supports two flow modes that control how much oversight you have: [Automatic mode](#automatic-mode) and [Guided mode](#guided-mode).

### Automatic mode

The agent works through all stages (assessment, planning, and execution) without pausing for approval. It surfaces key findings and progress updates, but keeps moving forward.

Best for experienced users, straightforward upgrades, and small solutions.

### Guided mode

The agent pauses at each stage boundary for your review:

- After assessment: _"Here's what I found. Shall I proceed with upgrade options?"_
- After planning: _"Here's the task plan. Do you want me to start execution?"_
- Before complex task breakdowns: _"This task is complex. Here's how I'd break it down."_

Best for first-time users, complex solutions, and when you want to learn the process.

### Switch modes at any time

- Say **"pause"** or **"switch to guided"** to switch to Guided mode.
- Say **"continue"** or **"go ahead"** to switch to Automatic mode.

> [!TIP]
> Start with Guided mode for your first upgrade to understand the workflow, then switch to Automatic once you're comfortable.

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Scenarios and skills reference](scenarios-and-skills.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [Best practices](best-practices.md)
- [Troubleshoot GitHub Copilot modernization](troubleshooting.md)
