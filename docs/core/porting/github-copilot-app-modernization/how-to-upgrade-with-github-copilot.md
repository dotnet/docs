---
title: How to upgrade a .NET app with GitHub Copilot modernization
description: "Learn how to upgrade your .NET applications to newer versions using GitHub Copilot modernization. This step-by-step guide covers assessment and the three-stage workflow: assessment, planning, and execution."
ms.topic: how-to
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to upgrade my .NET app using GitHub Copilot modernization so that I can modernize my codebase efficiently with AI assistance through a structured three-stage process.

---

# Upgrade a .NET app with GitHub Copilot modernization

GitHub Copilot modernization is an AI-powered agent that upgrades .NET projects to newer versions and migrates applications to Azure. This article walks you through upgrading your .NET applications with a structured three-stage workflow: assessment, planning, and execution.

The modernization agent analyzes your projects and dependencies, creates detailed upgrade documentation at each stage, and helps with code fixes throughout the process. The agent supports upgrading from older .NET versions to the latest, including upgrades from .NET Framework to modern .NET.

## Prerequisites

Set up GitHub Copilot modernization in your development environment before starting an upgrade. For installation steps, see [Install GitHub Copilot modernization](install.md).

## Initiate the upgrade

To start an upgrade, use the `modernize-dotnet` agent in Copilot:

[!INCLUDE[github-copilot-how-to-initiate](./includes/how-to-initiate.md)]

When you start the upgrade, Copilot collects pre-initialization information: the target framework version, Git branching strategy, and workflow mode (automatic or guided by you). Copilot then assesses your project and runs a three-stage workflow, writing Markdown files for each stage under `.github/upgrades/{scenarioId}` in your repository. The `{scenarioId}` value is a unique identifier for the upgrade type, such as `dotnet-version-upgrade`. If `.github/upgrades/{scenarioId}` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

The three stages are:

- **Assessment stage.** Copilot examines your project, presents strategy decisions for your review, and saves confirmed decisions. Customize the assessment before proceeding.
- **Planning stage.** Copilot creates a detailed specification with the steps to reach the target upgrade.
- **Execution stage.** Copilot breaks the plan into sequential tasks and performs the upgrade.

## Review the assessment

The assessment examines your project structure, dependencies, and code patterns to identify what needs to change. Copilot automatically starts the assessment and generates an `assessment.md` file in `.github/upgrades/{scenarioId}`.

The assessment lists breaking changes, API compatibility problems, deprecated patterns, and upgrade scope. The following example shows part of an assessment for an ASP.NET Core project upgrading from .NET 6.0 to .NET 10.0:

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

To review and customize the assessment:

1. Open the `assessment.md` file in `.github/upgrades/{scenarioId}`.
1. Review the identified breaking changes and compatibility problems.
1. Add project-specific context or concerns to the document.
1. Tell Copilot to _proceed to the planning stage._

## Review upgrade options

After the assessment, Copilot evaluates your solution and presents upgrade strategy decisions for your review. The agent recommends an approach based on your project's structure and saves confirmed decisions to `upgrade-options.md` in `.github/upgrades/{scenarioId}`.

The options typically include:

- **Upgrade strategy.** Bottom-up (leaf projects first), top-down (application first), or all-at-once (all projects in one pass).
- **Project upgrade approach.** In-place rewrite or side-by-side upgrade.
- **Technology modernization.** Whether to upgrade technologies like Entity Framework (EF6 to EF Core), dependency injection, logging, and configuration.
- **Package management.** Whether to adopt Central Package Management.
- **Compatibility handling.** How to address unsupported APIs, incompatible packages, and platform-specific functionality.

Review the proposed options and confirm or override them. Tell Copilot to _proceed to the planning stage._

## Start planning and review the plan

The planning stage converts the assessment and your confirmed upgrade options into a detailed specification that explains how to resolve every issue. When you tell Copilot to proceed to planning, it generates a `plan.md` file in `.github/upgrades/{scenarioId}`. The agent also creates a `scenario-instructions.md` file that stores preferences, decisions, and custom instructions for the upgrade.

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

1. Open the `plan.md` file in `.github/upgrades/{scenarioId}`.
1. Review the upgrade strategies and dependency updates.
1. Edit the plan to adjust upgrade steps or add context as needed.

   > [!CAUTION]
   > The plan depends on project interdependencies. The upgrade doesn't succeed if you modify the plan in a way that prevents the upgrade path from completing. For example, if **Project A** depends on **Project B** and you remove **Project B** from the upgrade plan, upgrading **Project A** might fail.

1. Tell Copilot to _move to the execution stage._

## Start execution and run the upgrade

The execution stage breaks the plan into sequential, concrete tasks with validation criteria. When you tell Copilot to proceed to execution, it generates a `tasks.md` file in `.github/upgrades/{scenarioId}`.

The task list describes each task and how Copilot validates success. The following example shows a task list for a solution containing ASP.NET Core and WPF projects:

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

1. Tell Copilot to _start the upgrade._
1. Monitor progress by reviewing the `tasks.md` file as Copilot updates task statuses.
1. If Copilot encounters a problem it can't resolve, provide the requested help.
1. Based on your decisions and changes, Copilot adapts its strategy to the remaining tasks and continues the upgrade.

Copilot commits changes according to the Git strategy you configured during pre-initialization: per task, per group of tasks, or at the end.

## Verify the upgrade

When the upgrade finishes, Copilot shows recommended next steps in the chat response. Review the `tasks.md` file in `.github/upgrades/{scenarioId}` for the status of every step.

The following example shows completed tasks for an ASP.NET Core project upgrade:

```markdown
# MvcMovieNet6 .NET 10 Upgrade Tasks

## Overview

This document tracks the execution of the MvcMovieNet6 solution upgrade from .NET 6 to .NET 10. All projects will be upgraded simultaneously in a single atomic operation.

**Progress**: 3/3 tasks complete (100%) ![0%](https://progress-bar.xyz/100)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2025-12-12 21:09)*
**References**: Plan §Phase 0

- [✓] (1) Verify .NET 10 SDK installed per Plan §Phase 0
- [✓] (2) .NET 10 SDK meets minimum requirements (**Verify**)

...
```

To verify the upgrade:

1. Review the final task status in `tasks.md`.
1. Address any failing tests or compilation errors.
1. Ensure all updated NuGet packages are compatible with your application.
1. Test your application thoroughly to verify the upgrade succeeded.
1. Apply new features and improvements available in the upgraded .NET version.

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Install GitHub Copilot modernization](install.md)
- [Core concepts](concepts.md)
- [Best practices](best-practices.md)
- [Troubleshoot GitHub Copilot modernization](troubleshooting.md)
- [GitHub Copilot modernization FAQ](faq.yml)
