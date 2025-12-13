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

When you start the upgrade, Copilot prompts you to create a new branch if you're working in a Git repository. Copilot then runs a three-stage workflow, writing a Markdown file for each stage under `.github/upgrades` in your repository. If `.github/upgrades` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

The three stages are:

- **Assessment stage** - Copilot examines your project to identify breaking changes, compatibility problems, and upgrade requirements.
- **Planning stage** - Copilot creates a detailed specification explaining how to resolve every problem.
- **Execution stage** - Copilot breaks the plan into sequential tasks and performs the upgrade.

## Start assessment and review results

The assessment stage examines your project structure, dependencies, and code patterns to identify what needs to change. Copilot automatically starts this stage and generates an `assessment.md` file in `.github/upgrades`.

The assessment lists breaking changes, API compatibility problems, deprecated patterns, and the upgrade scope so you know exactly what needs attention. The following example shows part of an assessment for an ASP.NET Core project upgrading from .NET 6.0 to .NET 9.0:

```markdown
# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [MvcMovie.Tests\MvcMovie.Tests.csproj](#mvcmovietestsmvcmovietestscsproj)
  - [MvcMovie\MvcMovie.csproj](#mvcmoviemvcmoviecsproj)
  - [RazorMovie.Tests\RazorMovie.Tests.csproj](#razormovietestsrazormovietestscsproj)
  - [RazorMovie\RazorMovie.csproj](#razormovierazormoviecsproj)
  - [WpfMovie.Tests\WpfMovie.Tests.csproj](#wpfmovietestswpfmovietestscsproj)
  - [WpfMovie\WpfMovie.csproj](#wpfmoviewpfmoviecsproj)

...
```

To review and customize the plan:

1. Open the `assessment.md` file in `.github/upgrades`.
1. Review the identified breaking changes and compatibility problems.
1. Add any project-specific context or concerns to the document.
1. Tell Copilot to move to the planning stage.

## Start planning and review the plan

The planning stage converts the assessment into a detailed specification that explains how to resolve every issue. When you tell Copilot to proceed to planning, it generates a `plan.md` file in `.github/upgrades`.

The plan documents upgrade strategies, refactoring approaches, dependency upgrade paths, and risk mitigations. The following example shows part of a plan for an ASP.NET Core project:

```markdown
# .NET 10 Upgrade Plan

## Table of Contents

- [Executive Summary](#executive-summary)
- [Migration Strategy](#migration-strategy)
- [Detailed Dependency Analysis](#detailed-dependency-analysis)
- [Project-by-Project Plans](#project-by-project-plans)
- ... <removed to save space> ...
- ...

---

## Executive Summary

### Scenario Description
Upgrade all projects in the MvcMovieNet6 solution from .NET 6 to .NET 10 (Long Term Support). The solution contains:
- **RazorMovie**: ASP.NET Core Razor Pages application (primary focus)
- **MvcMovie**: ASP.NET Core MVC application
- **WpfMovie**: Windows Presentation Foundation desktop application
- **3 Test Projects**: Unit test projects for each application

### Scope & Current State
- **6 projects** requiring framework upgrade (net6.0 → net10.0)
- **1,862 total lines of code** across 54 files
- **16 NuGet packages** (6 require updates, 10 compatible)
- **65 identified issues** (1 security vulnerability, 1 deprecated package, 51 WPF API issues, minor behavioral changes)
- **All projects are SDK-style** (modern project format)

...
```

To review and customize the plan:

1. Open the `plan.md` file in `.github/upgrades`.
1. Review the upgrade strategies and dependency updates.
1. Edit the plan to adjust upgrade steps or add context if needed.

   > [!CAUTION]
   > The plan is based on project interdependencies. The upgrade won't succeed if you modify the plan in such a way that the migration path can't complete. For example, if **Project A** depends on **Project B** and you remove **Project B** from the upgrade plan, upgrading **Project A** might fail.

1. Tell Copilot to move to the execution stage.

## Start execution and run the upgrade

The execution stage breaks the plan into sequential, concrete tasks with validation criteria. When you tell Copilot to proceed to execution, it generates a `tasks.md` file in `.github/upgrades`.

The task list describes each task and explains how Copilot confirms it succeeded. The following example shows the task list for a solution containing ASP.NET Core and WPF projects:

```markdown
# MvcMovieNet6 .NET 10 Upgrade Tasks

## Overview

This document tracks the execution of the MvcMovieNet6 solution upgrade from .NET 6 to .NET 10. All projects will be upgraded simultaneously in a single atomic operation.

**Progress**: 0/3 tasks complete (0%) ![0%](https://progress-bar.xyz/0)

---

## Tasks

### [ ] TASK-001: Verify prerequisites
**References**: Plan §Phase 0

- [ ] (1) Verify .NET 10 SDK installed per Plan §Phase 0
- [ ] (2) .NET 10 SDK meets minimum requirements (**Verify**)

---

### [ ] TASK-002: Atomic framework and package upgrade with compilation fixes
**References**: Plan §Phase 1, Plan §Package Update Reference, Plan §Breaking Changes Catalog, Plan §Project-by-Project Plans

- [ ] (1) Update TargetFramework to net10.0 in MvcMovie.csproj, MvcMovie.Tests.csproj, RazorMovie.csproj, RazorMovie.Tests.csproj per Plan §Phase 1
- [ ] (2) Update TargetFramework to net10.0-windows in WpfMovie.csproj, WpfMovie.Tests.csproj per Plan §Phase 1
- [ ] (3) All project files updated to target framework (**Verify**)
- [ ] (4) Update package references per Plan §Package Update Reference (MvcMovie: EF Core 10.0.1, Code Generation 10.0.0; RazorMovie: HtmlSanitizer 9.0.889 security fix)
- [ ] (5) All package references updated (**Verify**)
- [ ] (6) Restore all dependencies across solution
- [ ] (7) All dependencies restored successfully (**Verify**)
- [ ] (8) Build solution and fix all compilation errors per Plan §Breaking Changes Catalog (focus: BinaryFormatter removal in WpfMovie, WPF control API binary incompatibilities, UseExceptionHandler behavioral changes, HtmlSanitizer API changes)
- [ ] (9) Solution builds with 0 errors (**Verify**)
- [ ] (10) Commit changes with message: "TASK-002: Complete atomic upgrade to .NET 10 (all projects, packages, and compilation fixes)"

---

### [ ] TASK-003: Run full test suite and validate upgrade
**References**: Plan §Phase 2, Plan §Testing & Validation Strategy

- [ ] (1) Run tests in MvcMovie.Tests, RazorMovie.Tests, and WpfMovie.Tests projects
- [ ] (2) Fix any test failures (reference Plan §Breaking Changes Catalog for common issues: HtmlSanitizer behavior, BinaryFormatter replacement, framework behavioral changes)
- [ ] (3) Re-run all tests after fixes
- [ ] (4) All tests pass with 0 failures (**Verify**)
- [ ] (5) Commit test fixes with message: "TASK-003: Complete testing and validation for .NET 10 upgrade"
```

To run the upgrade:

1. Tell Copilot to start the upgrade.
1. Monitor progress by reviewing the `tasks.md` file as Copilot updates task statuses.
1. If Copilot encounters a problem it can't resolve, provide the requested help.
1. Let Copilot learn from your interventions and continue the upgrade.

The tool creates a Git commit for every portion of the process, so you can easily roll back changes or get detailed information about what changed.

## Verify the upgrade

When the upgrade finishes, Copilot shows next steps in the chat response to guide you on what to do after the process. Review the `tasks.md` file for the status of every step. The tool creates a Git commit for every portion of the upgrade process, so you can easily roll back changes or get detailed information about what changed.

The following example shows completed tasks for an ASP.NET Core project upgrade:

```markdown
<!-- TODO -->
```

To verify the upgrade:

1. Review the final task status in `tasks.md`.
1. Address any failing tests or compilation errors.
1. Ensure all updated NuGet packages are compatible with your application.
1. Test your application thoroughly to verify the upgrade succeeded.
1. Apply new features and improvements available in the upgraded .NET version.

## Related content

- [What is GitHub Copilot app modernization?](overview.md)
- [GitHub Copilot app modernization FAQ](faq.yml)
