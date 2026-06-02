---
title: Troubleshoot GitHub Copilot modernization
description: "Find solutions to common problems when you use GitHub Copilot modernization for .NET, including workflow, build, Git, performance, and customization issues."
ms.topic: troubleshooting-general
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to troubleshoot issues with GitHub Copilot modernization so that I can resolve problems and continue my .NET upgrade.

---

# Troubleshoot GitHub Copilot modernization

This article covers common issues you might encounter when you use GitHub Copilot modernization for .NET, organized by category. Each entry follows a problem, cause, and solution format so you can find and resolve issues quickly.

## Workflow issues

These issues relate to scenario discovery, resuming work, and task state.

### Agent says "no scenarios found"

**Cause:** The agent doesn't recognize the workspace as a .NET project.

**Solution:**

1. Verify that the workspace root contains a `.sln`, `.csproj`, or `.vbproj` file.
1. Ask the agent: _"What solution or project file are you using?"_
1. If your solution or project file is in a subdirectory, open that directory as the workspace root or point the agent to the file explicitly.

### Agent can't resume previous work

**Cause:** The `.github/upgrades/` folder, where the agent stores all its state, is missing or corrupted.

**Solution:**

1. Check whether the `.github/upgrades/` folder exists in your repo root.
1. If you accidentally deleted the folder, start the scenario fresh. The agent can't recover without its state files.
1. If the folder exists but files appear corrupted, ask the agent to _"reassess and re-plan"_ to regenerate them.

> [!TIP]
> Commit the `.github/upgrades/` folder to your branch so it's preserved across sessions and machines.

### Tasks stuck in progress

**Cause:** The previous session ended while the agent was mid-task.

**Solution:**

1. The agent auto-detects stale tasks in most cases. Tell the agent _"resume"_ or _"restart the current task."_
1. If the stuck state persists, tell the agent _"mark the current task as pending and restart it"_ or _"reassess and continue from the last completed step."_
1. Check the corresponding `progress-details.md` file to understand where the previous session stopped.

### Agent keeps suggesting the wrong scenario

**Cause:** The agent's analysis picked up unexpected project characteristics and inferred a different scenario than you intended.

**Solution:**

Be explicit about what you want. Instead of _"upgrade my project,"_ say:

- _"I want to upgrade to .NET 10."_
- _"I want to upgrade from Newtonsoft.Json to System.Text.Json."_
- _"Convert my project to SDK-style format."_

Add scenario preferences to `scenario-instructions.md` to prevent future mismatches.

## Build and compilation issues

These issues relate to build failures, NuGet restore problems, and code generation errors.

### Build fails after agent's changes

**Cause:** Upgrades can introduce [breaking API changes](../../compatibility/breaking-changes.md), missing packages, or incompatible code patterns.

**Solution:**

1. Tell the agent about the failure. The agent analyzes errors automatically.
1. If the agent can't resolve the issue, revert the last commit (`git revert HEAD`) and ask the agent to try a different approach.
1. For complex failures, check `execution-log.md` to understand what the agent changed and in what order.

### NuGet restore fails

**Cause:** Package incompatibility with the target framework or authentication failures with private NuGet feeds.

**Solution:**

- **For private feeds:** Authenticate to the feed before you start the upgrade.
- **For incompatible packages:** Tell the agent which package is problematic. The agent can search for compatible versions or suggest alternative packages.
- **For feed connectivity issues:** Verify that you can run `dotnet restore` manually. Fix any feed issues first, then let the agent retry.

### Agent generates code that doesn't compile

**Cause:** AI-generated code might contain errors, especially in edge cases or with uncommon API patterns.

**Solution:**

1. The agent detects compilation errors automatically. If the agent is struggling, provide guidance or fix the code manually, and tell the agent to continue.
1. If the agent struggles with a specific fix after multiple attempts, edit the code manually and tell the agent: _"I fixed the compilation error in MyClass.cs, mark this task complete."_
1. The agent learns from your manual fix and applies similar patterns when the same issue appears elsewhere.

## Git issues

> [!NOTE]
> The agent works with non-Git folders too. If your workspace isn't a Git repository, the agent skips Git operations (branching, committing) and applies changes directly to your files. Without Git, back up your project manually before you start so you can revert if needed.

### Agent can't create a branch

**Cause:** Uncommitted changes in the working tree, a branch naming conflict, or Git isn't initialized in the workspace.

**Solution:**

1. Commit or stash your pending changes before you start a scenario.
1. Verify that Git is initialized by running `git status` in the workspace root.
1. If a branch with the agent's intended name already exists, delete the existing branch or ask the agent to use a different branch name.

### Undo all agent changes

**Cause:** The upgrade didn't go as planned and you want to start over.

**Solution:**

1. Switch back to your original branch with `git checkout main` (or your base branch).
1. The agent's working branch contains all changes isolated from your main branch.
1. To remove the agent's branch entirely, run `git branch -D <agent-branch-name>`.
1. To keep some changes, cherry-pick specific commits with `git cherry-pick <commit-hash>`.

> [!TIP]
> The agent makes granular commits per task, so you can selectively keep the changes that worked.

## Performance issues

These issues relate to upgrade speed and assessment duration.

### Agent is slow or takes a long time

**Cause:** Large solutions with many projects, complex dependency graphs, or numerous breaking changes naturally take longer.

**Solution:**

For large solutions (50+ projects), consider upgrading in batches. Group related projects and upgrade them together.

### Assessment takes a long time

**Cause:** The assessment analyzes every project's dependencies, NuGet packages, target frameworks, and applicable breaking changes. For large solutions, the assessment naturally takes longer.

**Solution:**

1. Long assessment times are normal for large solutions. No action is needed.
1. Monitor progress in the **Output** panel (select **AppModernizationExtension** from the dropdown in Visual Studio).
1. The assessment runs only once per scenario. Subsequent phases use the cached results.

## Customization issues

These issues relate to custom skills and scenario instruction files.

### Custom skill isn't picked up

**Cause:** The skill file is in the wrong location, has missing or invalid metadata, or has an incorrect format.

**Solution:**

1. Verify that the skill file is in one of the supported locations:
   - `.github/skills/` (repository-level, team-wide)
   - `.github/upgrades/skills/` (scenario-level)
   - `%UserProfile%/.copilot/skills/` (user-level, personal)
1. Check that the skill metadata includes at least `name` and `description` fields.
1. Confirm that the `discovery` field (if set) is one of: `lazy`, `preload`, or `scenario`.
1. Verify that the skill's `description` matches the kind of task you expect it to apply to. The agent uses description matching to select skills.

### Changes to scenario-instructions.md don't take effect

**Cause:** The agent might not reread the file midsession, or your edits are in the wrong section.

**Solution:**

1. Ask the agent to _"reload instructions"_ or start a new chat session to force a reread.
1. Verify that your edits are in the correct sections of the file:
   - **User Preferences:** For general preferences and constraints.
   - **Key Decisions:** For recording important decisions made during the upgrade.
   - **Custom Instructions:** For specific behavioral overrides.
1. Verify that the file is saved and in the expected path: `.github/upgrades/{scenarioId}/scenario-instructions.md`.

## Get help

When something isn't working as expected:

1. **Ask the agent:** Ask _"What went wrong with the last task?"_ The agent can often explain what happened and suggest next steps.
1. **Review the execution log:** Open `execution-log.md` in `.github/upgrades/{scenarioId}/`. The log shows a chronological record of what the agent did, including any errors it encountered.
1. **File an issue:** If you've found a bug or the agent consistently fails at something, file an issue at the [@modernize-dotnet GitHub repository](https://github.com/dotnet/modernize-dotnet).

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Best practices](best-practices.md)
- [Core concepts](concepts.md)
- [GitHub Copilot modernization FAQ](faq.yml)
