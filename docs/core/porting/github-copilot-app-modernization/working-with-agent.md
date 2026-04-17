---
title: Work with GitHub Copilot modernization
description: "Learn how to collaborate effectively with GitHub Copilot modernization, including communication patterns, teaching preferences, mid-session corrections, and multi-session workflows."
ms.topic: concept-article
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to learn how to work effectively with the GitHub Copilot modernization agent so that I can get the best results from my .NET upgrade.

---

# Work with GitHub Copilot modernization

This article covers how to communicate with the GitHub Copilot modernization agent, teach it your preferences, correct mistakes, review its work, and manage upgrades across multiple sessions.

GitHub Copilot modernization is an interactive collaborator that asks questions, proposes strategies, adapts to your feedback, and learns from your preferences over time. To get the best results, give the agent context. The more it knows about your goals, constraints, and preferences, the better it performs.

```text
❌ Vague — the agent has to guess
"Upgrade my project"

✅ Specific — the agent knows exactly what you need
"Upgrade the WebAPI project to .NET 10. We need to keep backward
compatibility with our existing REST clients, and we can't change the
public API surface."
```

> [!TIP]
> You don't have to give all context up front. The agent asks follow-up questions when it needs more information.

## Start a conversation

1. Open **Copilot Chat** in VS Code, Visual Studio, or Copilot CLI.
1. Select the **GitHub Copilot modernization agent for .NET** from the agent picker, or type the correct agent mention for your environment: `@modernize-dotnet` in VS Code and Copilot CLI, or `@Modernize` in Visual Studio.
1. Describe what you want to accomplish in natural language.

### What to say

Natural language works. Try these examples:

| What you want | What to say |
|---|---|
| Upgrade a full solution | _"Upgrade my solution to .NET 10"_ |
| Upgrade a specific technology | _"Help me upgrade from EF6 to EF Core"_ |
| See what's available | _"What scenarios are available?"_ |
| Upgrade one project first | _"Upgrade the API project first, then the shared library"_ |
| Understand the current state | _"What's the current status of my upgrade?"_ |

### What happens next

When you start a conversation, the agent checks for existing upgrade work in your workspace:

- If there's no existing work, the agent starts fresh, typically beginning with an assessment of your solution.
- If there's existing work in progress, the agent picks up where you left off and shows current status, such as "3 of 8 tasks completed."

## Choose a flow mode

The agent supports two flow modes that control how much the agent pauses for your input.

### Automatic mode

In automatic mode, the agent works through the stages (assessment, planning, execution) without pausing for approval at each boundary. The agent still stops at genuine blockers or when it needs a decision only you can make.

Best for experienced users, straightforward upgrades, and small solutions.

### Guided mode

In guided mode, the agent pauses at each stage boundary for your review:

- After assessment, before creating the plan.
- After planning, before executing any tasks.
- Before complex task breakdowns.
- At key decision points where multiple valid approaches exist.

Best for first-time users, complex solutions, and when you want to learn the process.

### Switch modes mid-session

Switch freely between modes at any time:

| To switch to | What to say |
|---|---|
| Guided mode | _"Pause"_ or _"Switch to guided mode"_ |
| Automatic mode | _"Continue"_ or _"Go ahead"_ |

> [!TIP]
> Start with guided mode for your first upgrade. Guided mode is the best way to learn how the agent thinks and what decisions it makes. Switch to automatic mode once you're comfortable.

## Teach the agent

The agent learns from you. The agent saves your corrections, preferences, and instructions to `scenario-instructions.md` in the upgrade state folder. These preferences persist across sessions.

### Correct mistakes

When the agent makes a decision you disagree with, tell the agent:

```text
You: "Actually, don't use Newtonsoft.Json — we're standardizing on System.Text.Json."
Agent: "Got it. I'll use System.Text.Json for all serialization going forward.
        I've saved this as a preference."
```

The agent updates `scenario-instructions.md` and won't make the same choice again, even in a future session.

### Set preferences

Proactively tell the agent how you like things done:

```text
You: "Always use bottom-up strategy for this solution — upgrade leaf projects first."
Agent: "Noted. I'll use a bottom-up upgrade strategy, starting with projects that
        have no internal dependencies and working up to the top-level projects."
```

### Give task-specific instructions

Sometimes a preference only applies to a specific task:

```text
You: "For this task, skip the test validation — the tests are broken for a known
      reason and we'll fix them separately."
Agent: "Understood. I'll skip test validation for this task only."
```

### What the agent saves

The `scenario-instructions.md` file is organized into clear sections:

| Section | What it contains | Example |
|---|---|---|
| **User Preferences (Technical)** | Package choices, framework decisions, coding patterns | _"Use System.Text.Json, not Newtonsoft"_ |
| **User Preferences (Execution Style)** | How the agent works | _"Always use bottom-up strategy"_ |
| **Key Decisions Log** | Important decisions and their rationale | _"Chose EF Core over Dapper because..."_ |
| **Custom Instructions per Task** | Task-specific overrides | _"Skip tests for task 3.1"_ |

> [!TIP]
> Also edit `scenario-instructions.md` directly. It's a Markdown file in `.github/upgrades/{scenarioId}/`. The agent reads the file at the start of every interaction.

## Make mid-session corrections

The agent handles interruptions gracefully and doesn't lose track of where it is or what it was doing.

### Pause and review

```text
You: "Wait, stop — let me review that change first."
Agent: "Here's what I was about to do: [describes planned changes].
        Would you like me to proceed, or adjust the approach?"
```

### Redirect

```text
You: "Actually, let's do Project B before Project A — it has fewer dependencies."
Agent: "Good call. I'll reorder the tasks and start with Project B."
```

### Undo

```text
You: "That last change broke the build. Can we revert it?"
Agent: "I'll revert the last commit (abc1234: 'Migrate auth middleware').
        Reverting now."
```

Also revert commits yourself using standard Git commands. The agent writes clear, descriptive commit messages so you know exactly what each commit changed.

### Ask questions mid-flow

Asking questions doesn't derail the workflow:

```text
You: "Why did you choose to migrate the data layer before the API controllers?"
Agent: "The API controllers depend on the data layer interfaces. By migrating
        the data layer first, we avoid temporary compilation errors in the
        controllers and can validate each layer independently."
```

## Review the agent's work

The agent provides multiple ways to review its work.

### Source control

The agent suggests working on a separate branch and commits changes as it works. Review the agent's changes with standard Git commands:

```console
git log --oneline -10
git diff main..<agent-branch>
```

### Workflow files

The agent maintains several files in `.github/upgrades/{scenarioId}/` that give you full visibility:

| File | What it shows |
|---|---|
| `tasks.md` | Visual progress overview with all tasks, status indicators (✅ done, 🔄 in progress, ⬜ pending), and a progress bar |
| `execution-log.md` | Complete chronological audit trail of every action the agent took, when, and what happened |
| `assessment.md` | The initial analysis of your solution, including dependencies, breaking changes, and upgrade complexity |
| `scenario-instructions.md` | Your preferences and the agent's learned decisions |
| `tasks/{taskId}/progress-details.md` | Per-task details: build errors encountered, how they were resolved, test results, and decisions made |

## Resume interrupted work

Close the chat or shut down your IDE. The agent handles this situation seamlessly.

The agent stores all state in `.github/upgrades/` inside your repository. When you start a new conversation, the agent checks the current state and immediately knows:

- Which scenario is active.
- Which tasks are completed, in progress, or pending.
- What artifacts exist (assessment, plan, task files).
- Whether any tasks appear stale (stuck in 🔄 status from a previous session).

### Stale task detection

If a task is in progress from a previous session, the agent recognizes the task might be stale and offers options to continue, restart, or skip.

> [!TIP]
> Because state lives in `.github/upgrades/` inside your repo, it travels with your code. Push your branch to a remote, pull it on another machine, and the agent picks up right where you left off.

## Work across multiple sessions

Large upgrades, such as a 20-project solution, a complex framework upgrade, or a multi-step modernization, often span multiple sessions over days or weeks. The agent handles multi-session work naturally:

- **Persistent state:** Everything is in `.github/upgrades/`. No in-memory state to lose.
- **Session independence:** Each chat session is independent. The agent reconstructs its context from the state files every time.
- **Cross-IDE support:** Start in VS Code, continue in Visual Studio or Copilot CLI. The state folder is the shared contract.

### Tips for multi-session work

- **Commit the state folder.** Push `.github/upgrades/` to your branch to back up the folder and make it visible to your team.
- **Review between sessions.** Read `tasks.md` and `execution-log.md` to refresh your memory on what happened in the last session.
- **Update preferences as you learn.** If you discover something in testing that should change the agent's approach, tell the agent at the start of the next session.

## Ask for help

Not sure what the agent can do or where things stand? Ask:

| What you want to know | What to say |
|---|---|
| Available upgrade scenarios | _"What can you do?"_ or _"What scenarios are available?"_ |
| Current progress | _"What's the current status?"_ or _"Show me the progress"_ |
| The upgrade plan | _"Explain the plan"_ or _"Walk me through the tasks"_ |
| Assessment details | _"Show me the assessment"_ or _"What did the assessment find?"_ |
| Available skills | _"What skills do you have?"_ or _"List your skills"_ |
| A specific decision | _"Why did you choose X over Y?"_ |
| Risks or concerns | _"What are the risks with this upgrade?"_ |

## Communicate effectively

The quality of your interaction directly affects the quality of the results.

### Be specific about scope

_"Upgrade just the Data.Access and Data.Models projects to .NET 10"_ gives the agent a clear focus. _"Upgrade everything"_ works, but the agent makes more decisions on its own about ordering and priorities.

### Share context

The agent doesn't know your business constraints unless you share them:

- _"We're upgrading because Azure App Service is dropping .NET 8 support in November."_
- _"This is a high-traffic production service—zero behavioral changes in the API responses."_

### Express constraints

Tell the agent what it _shouldn't_ do, not just what it should:

- _"Don't change the public API surface—we have external consumers."_
- _"We can't upgrade Newtonsoft.Json yet—the team that owns shared contracts hasn't upgraded."_
- _"Don't touch the legacy reporting module—that's being rewritten separately."_

### Give feedback

Positive feedback helps just as much as corrections and confirms the agent is on the right track:

- _"That upgrade looks great—do the same approach for the other repository project."_
- _"That works, but we prefer constructor injection over property injection in this codebase."_

## Quick reference

| Situation | What to say |
|---|---|
| Start a new upgrade | _"Upgrade my solution to .NET 10"_ |
| Resume previous work | _"Continue"_ or _"What's the status?"_ |
| Switch to guided mode | _"Pause"_ or _"Switch to guided mode"_ |
| Switch to automatic mode | _"Go ahead"_ or _"Continue without asking"_ |
| Correct a decision | _"Actually, use X instead of Y"_ |
| Set a preference | _"Always do X for this solution"_ |
| Review changes | _"Show me what you changed"_ or check Git log |
| Undo a change | _"Revert the last change"_ |
| Ask why | _"Why did you choose that approach?"_ |
| Skip a task | _"Skip this task for now"_ |
| Get help | _"What can you do?"_ |

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Core concepts](concepts.md)
- [Best practices](best-practices.md)
- [Customize GitHub Copilot modernization](customization.md)
- [Troubleshoot GitHub Copilot modernization](troubleshooting.md)
