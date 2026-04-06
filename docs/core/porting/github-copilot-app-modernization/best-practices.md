---
title: Best practices for GitHub Copilot modernization
description: "Learn best practices for using GitHub Copilot modernization to upgrade .NET projects, including preparation, collaboration tips, common pitfalls, and recovery strategies."
ms.topic: best-practice
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to follow best practices when using GitHub Copilot modernization so that I can get the best results from my .NET upgrades and avoid common problems.

---

# Best practices for GitHub Copilot modernization

Follow these guidelines to get the best results from GitHub Copilot modernization when upgrading and migrating .NET projects.

## Before you start

### Verify that your solution builds and tests pass

The agent validates every change it makes by running builds and tests. If your solution is already broken before you start, the agent can't distinguish pre-existing failures from problems it introduced.

```dotnetcli
dotnet build YourSolution.sln
dotnet test YourSolution.sln
```

If there are known test failures, document them in `scenario-instructions.md` so the agent knows to ignore them.

### Commit or stash uncommitted work

Start with a clean working directory to avoid mixing your uncommitted changes with the agent's modifications. A clean baseline makes it easier to review or revert changes.

```console
git stash
git status
```

### Back up non-Git repositories

The agent also works with folders that aren't under source control. If your project isn't in a Git repository, the agent skips branch and commit operations. In this case, back up your project folder before starting so you can restore it if needed.

### Review your test coverage

The agent relies on tests to validate that its changes don't break behavior. Projects with good test coverage get higher-confidence upgrades.

> [!TIP]
> You don't need 100% coverage. Focus on the code most likely to be affected by the upgrade—API boundaries, serialization, database access, and authentication.

### Start small

If this is your first time using the agent, pick a small, low-risk project as a pilot. A class library or utility project is ideal. Starting small lets you understand the workflow, build confidence, and discover any repo-specific issues before tackling your main application.

## During the upgrade

### Use guided mode for your first upgrade

The agent supports both guided and automatic modes. In guided mode, the agent pauses at key decision points for your review and approval. Start with guided mode to understand what the agent does and why. Switch to automatic mode once you're comfortable with the workflow.

### Review the assessment carefully

The assessment is your best opportunity to catch issues before the agent starts making changes. Look for:

- Projects the agent might have missed or misidentified.
- Dependencies that you know are problematic.
- Anything unusual about your solution that the agent should know.

If you spot something, tell the agent in chat or add the information to `scenario-instructions.md`.

### Take time with the planning phase

The agent generates a task plan based on its assessment. Review the plan before proceeding:

- Does the order make sense for your codebase?
- Are there dependencies the agent might not know about?
- Should any projects be excluded or handled differently?

You can ask the agent to reorder tasks, skip projects, or change its approach. You know your codebase better than the agent—use that knowledge.

### Give feedback immediately

The agent learns from your corrections within a session. If the agent makes a choice you disagree with:

- Tell it right away: *"Don't use that pattern, use X instead."*
- Add persistent guidance to `scenario-instructions.md` so the agent remembers across tasks and sessions.

## Common pitfalls

### Large solutions with 50+ projects

The agent works project-by-project, so large solutions take time. Be patient and monitor progress. Consider starting with one representative project end-to-end before committing to the full solution. Doing so surfaces systemic issues early.

### Private NuGet feeds

For private NuGet feeds, authenticate before starting the upgrade (for example, through your organization's credential provider or feed configuration). Without authentication, package restore failures block progress.

### Custom MSBuild targets and imports

Complex build customizations—custom `.targets` files, conditional imports, or non-standard build logic—can confuse the assessment and cause unexpected build failures. If your solution has these customizations, mention them in chat or in `scenario-instructions.md` so the agent can account for them.

### Session timeouts

Long-running upgrades might span multiple sessions. The agent tracks its progress in workflow files (under `.github/upgrades/`), so the agent can pick up where it left off. When you start a new session, mention where you were: *"Continue the .NET 10 upgrade—I was in the middle of the Data.Access project."*

## Collaborate effectively

### Be specific about scope

The more specific you are, the better the agent performs:

| Instead of | Try |
|---|---|
| *"Upgrade everything"* | *"Upgrade the Data.Access project to .NET 10"* |
| *"Fix the build"* | *"Fix the build error in CustomerService.cs related to the removed API"* |
| *"Migrate the database stuff"* | *"Migrate Entity Framework 6 to EF Core in the Repository project"* |

### Share your constraints

Tell the agent about real-world constraints upfront:

- *"We can't break backward compatibility for the public API."*
- *"We have a release deadline in two weeks—prioritize the web projects."*
- *"The legacy reporting module should be excluded from this upgrade."*

### Explain your architecture

The agent analyzes code structure, but it doesn't know your team's mental model. Help the agent understand:

- *"Project A is our shared library—B, C, and D all depend on it."*
- *"The WebApi project is our public-facing API; Internal.Api is for internal services only."*
- *"The Models project is auto-generated from our OpenAPI spec—don't modify it directly."*

### Ask why

The agent can explain its reasoning. If a decision doesn't look right, ask:

- *"Why did you choose bottom-up order?"*
- *"Why are you upgrading this package to version X instead of Y?"*
- *"Why did you break this into sub-tasks?"*

Understanding the reasoning helps you give better feedback.

### Save preferences early

If you have strong preferences about coding style, patterns, or approaches, add them to `scenario-instructions.md` in the first session. This file persists across sessions and is always in the agent's context, making it the most reliable way to influence behavior.

## Recover from problems

### Build failures after a task

Tell the agent: *"The build is failing after the last task."* The agent analyzes the error and attempts to fix it. If the agent can't resolve the issue:

1. Provide a manual fix and tell the agent what you did—the agent learns from it.
1. Revert the commit (`git revert` or reset to the previous commit) and ask the agent to try a different approach.
1. Skip the problematic task and come back to it later.

### Wrong strategy chosen

If the agent's overall approach doesn't work for your codebase, restart the planning phase:

- *"Let's redo the plan—I want to upgrade the web projects first instead of bottom-up."*
- *"Change the strategy to upgrade all shared libraries in one batch."*

### Agent stuck in a loop

If the agent repeats the same fix without progress, say *"Stop"* and describe what you're observing. The agent can reset its approach and try something different.

### Undo all changes

If you used a Git branch for the upgrade, undo everything by switching back to your original branch:

```console
git checkout your-original-branch
git branch -D upgrade-branch
```

Your original code is untouched. If you're working without source control, restore from the backup you made before starting.

## Security and privacy

- **Code snippets** sent to GitHub Copilot for analysis are processed according to [GitHub's Copilot privacy policy](https://docs.github.com/en/copilot/responsible-use-of-github-copilot-features/responsible-use-of-github-copilot-chat-in-your-ide) and aren't retained beyond the immediate session.
- **Workflow files** (`scenario-instructions.md`, custom tasks, preferences) are stored locally in your repository under `.github/upgrades/`. These files aren't transmitted to external services.
- **The `.github/upgrades/` folder** is part of your repository. Commit the folder—it contains your upgrade progress and state. The agent needs the folder to resume work across sessions. You can remove it after the upgrade is complete.
- **Telemetry** can be disabled through your IDE's telemetry settings.

## Performance tips

- **Close unnecessary files and tabs** — The agent analyzes the active workspace, and fewer open files means less noise.
- **Upgrade in stages for very large solutions** — Rather than upgrading all projects at once, batch them. For example, upgrade all libraries first, then all web projects, then tests.
- **Use build caching** — The agent runs many incremental builds during validation. Warm build caches make validation significantly faster. Avoid cleaning the build output between tasks.

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [Core concepts](concepts.md)
- [Troubleshoot GitHub Copilot modernization](troubleshooting.md)
