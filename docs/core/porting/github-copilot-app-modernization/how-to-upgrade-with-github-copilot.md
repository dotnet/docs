---
title: How to upgrade a .NET app with GitHub Copilot app modernization
description: "Learn how to upgrade your .NET applications to newer versions using GitHub Copilot app modernization in Visual Studio. This step-by-step guide covers the three-stage workflow: assessment, planning, and execution."
ms.topic: how-to
ms.date: 12/12/2025
ai-usage: ai-assisted

#customer intent: As a developer, I want to upgrade my .NET app using GitHub Copilot app modernization so that I can modernize my codebase efficiently with AI assistance through a structured three-stage process.

---

# Upgrade a .NET app with GitHub Copilot app modernization

GitHub Copilot app modernization is an AI-powered agent in Visual Studio that upgrades .NET projects to newer versions and migrates applications to Azure. This article guides you through upgrading your .NET applications using a structured three-stage workflow: assessment, planning, and execution.

The modernization agent analyzes your projects and dependencies, creates detailed upgrade documentation at each stage, and assists with code fixes throughout the process. It supports upgrading from older .NET versions to the latest, including migrations from .NET Framework to modern .NET.

## Prerequisites

Before you begin, ensure you have the following requirements:

[!INCLUDE [github-copilot-app-modernization-prereqs](../../../includes/github-copilot-app-modernization-prereqs.md)]

## Initiate the upgrade

To start an upgrade, interact with GitHub Copilot chat to initiate the modernization agent:

[!INCLUDE[github-copilot-how-to-initiate](./includes/how-to-initiate.md)]

When you start the upgrade, Copilot prompts you to create a new branch if you're working in a Git repository. Then Copilot runs a three-stage workflow, writing a Markdown file for each stage under `.github/upgrades` in your repository. Review each Markdown file before moving to the next stage. If `.github/upgrades` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

The three stages are:

- **Assessment stage** - Copilot examines your project to identify breaking changes, compatibility issues, and upgrade requirements.
- **Planning stage** - Copilot creates a detailed specification explaining how to resolve every issue.
- **Execution stage** - Copilot breaks the plan into sequential tasks and performs the upgrade.

## Review the assessment

In the assessment stage, Copilot examines your project structure, dependencies, and code patterns to build a comprehensive assessment. The `assessment.md` file lists breaking changes, API compatibility issues, deprecated patterns, and the upgrade scope so you know exactly what needs attention.

The following example shows part of an assessment for an ASP.NET Core project upgrading from .NET 6.0 to .NET 9.0:

```markdown
# Assessment

## Project Overview
- Current Target Framework: net6.0
- Target Framework: net9.0
- Project Type: ASP.NET Core Web Application

## Breaking Changes
<!-- TODO: List breaking changes from .NET 6.0 to .NET 9.0 -->

## Compatibility Issues
<!-- TODO: Document API compatibility issues -->

## Dependencies
<!-- TODO: List package updates required -->
```

To review and proceed:

1. Open the `assessment.md` file in `.github/upgrades`.
1. Review the identified breaking changes and compatibility issues.
1. Add any project-specific context or concerns to the document.
1. Tell Copilot to move to the planning stage.

## Review and customize the plan

In the planning stage, Copilot converts the assessment into a detailed specification explaining how to resolve every issue. The `plan.md` file documents upgrade strategies, refactoring approaches, dependency upgrade paths, and risk mitigations.

The following example shows part of a plan for an ASP.NET Core project:

```markdown
# Upgrade Plan

## Upgrade Strategy
<!-- TODO: Describe overall approach for upgrading from .NET 6.0 to .NET 9.0 -->

## Dependency Updates
<!-- TODO: List all package updates with version numbers and rationale -->

## Breaking Change Resolution
<!-- TODO: Explain how each breaking change will be addressed -->

## Risk Mitigation
<!-- TODO: Identify risks and mitigation strategies -->
```

To review and customize:

1. Open the `plan.md` file in `.github/upgrades`.
1. Review the upgrade strategies and dependency updates.
1. Edit the plan to adjust upgrade steps or add context if needed.
1. Tell Copilot to move to the execution stage.

> [!CAUTION]
> The plan is based on project interdependencies. The upgrade won't succeed if you modify the plan so the migration path can't complete. For example, if **Project A** depends on **Project B** and you remove **Project B** from the upgrade plan, upgrading **Project A** might fail.

## Run the upgrade

In the execution stage, Copilot breaks the plan into sequential, concrete tasks with validation criteria. The `tasks.md` file describes each task and explains how Copilot confirms it succeeded.

The following example shows part of a task list for an ASP.NET Core project:

```markdown
# Upgrade Tasks

## Task 1: Update SDK Version
<!-- TODO: Update global.json and project files to target .NET 9.0 -->
**Status**: Not Started

## Task 2: Update Package References
<!-- TODO: Update all NuGet packages to .NET 9.0 compatible versions -->
**Status**: Not Started

## Task 3: Address Breaking Changes
<!-- TODO: Fix code that uses deprecated APIs or patterns -->
**Status**: Not Started

## Task 4: Run Tests
<!-- TODO: Execute all unit tests and verify they pass -->
**Status**: Not Started
```

To run the upgrade:

1. Tell Copilot to start the upgrade.
1. Monitor progress by reviewing the `tasks.md` file as Copilot updates task statuses.
1. If Copilot encounters a problem it can't resolve, provide the requested help.
1. Let Copilot learn from your interventions and continue the upgrade.

The tool creates a Git commit for every portion of the process, so you can easily roll back changes or get detailed information about what changed.

## Verify the upgrade

When the upgrade completes, Copilot displays next steps in the chat response to guide you on what to do after the process completes. Review the `tasks.md` file for the status of every step. The tool creates a Git commit for every portion of the upgrade process, so you can easily roll back changes or get detailed information about what changed.

The following example shows completed tasks for an ASP.NET Core project upgrade:

```md
# Upgrade Tasks

## Task 1: Update SDK Version
<!-- Updated global.json and project files to target .NET 9.0 -->
**Status**: Completed
**Commit**: af8cf633

## Task 2: Update Package References
<!-- Updated all NuGet packages to .NET 9.0 compatible versions -->
**Status**: Completed
**Commit**: bf8deeac

## Task 3: Address Breaking Changes
<!-- Fixed code that uses deprecated APIs or patterns -->
**Status**: Completed
**Commit**: aa61a18d

## Task 4: Run Tests
<!-- Executed all unit tests - 2 passed, 0 failed -->
**Status**: Completed

## Next Steps
- Review test results
- Ensure all updated NuGet packages are compatible with your application
- Leverage new features and improvements in .NET 9.0
```

To verify the upgrade:

1. Review the final task status in `tasks.md`.
1. Address any failing tests or compilation errors.
1. Ensure all updated NuGet packages are compatible with your application.
1. Test your application thoroughly to verify the upgrade succeeded.
1. Apply new features and improvements available in the upgraded .NET version.

## Related content

* [What is GitHub Copilot app modernization?](overview.md)
* [GitHub Copilot app modernization FAQ](faq.yml)
