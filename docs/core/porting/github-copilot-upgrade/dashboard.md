---
title: Upgrade Dashboard in GitHub Copilot upgrade
description: "Learn about the Upgrade Dashboard, a built-in panel that provides a visual overview of the upgrade agent's progress, tasks, projects, dependencies, and assessment results."
author: adegeo
ms.author: adegeo
ms.topic: conceptual
ms.date: 07/31/2026
ai-usage: ai-assisted

#customer intent: As a developer using GitHub Copilot upgrade, I want to understand the Upgrade Dashboard so that I can monitor my upgrade progress and review assessment results visually.

---

<!-- REFERENCE MATERIAL AND RULES

## Key Content Requirements

### Audience Focus

- Primary audience: Developers already using or planning to use the GitHub Copilot upgrade agent.
- Secondary audience: Developers who want to monitor and understand their upgrade session visually.

### Terminology

- The feature is called "Upgrade Dashboard" (titled "Code Upgrade" in the UI header).
- Available in GitHub Copilot CLI and GitHub Copilot App (desktop) only — NOT in VS Code or other IDEs.
- Do NOT cover installation — the dashboard is bundled automatically with the upgrade-agent plugin.
- To open it, the user asks Copilot to show the dashboard (include it in the initial prompt, or ask at any time).

### Source Material

- Raw README: https://github.com/microsoft/upgrade-agent-plugins/blob/main/plugins/upgrade-agent/extensions/modernize-dashboard/README.md
- Screenshots (one per panel): docs/core/porting/github-copilot-upgrade/media/dashboard/

### Tab order (from screenshots)

Overview | Scenario | Tasks | Projects | Dependencies | Assessment | Options | Activity

### Per-panel detail from screenshots

**Overview**
- Header: "Code Upgrade" with global progress bar (e.g., "1/5 tasks (20%) · 1 in progress")
- Scenario card: scenario name (dotnet-version-upgrade), source → target TFM (net472 → net10.0), progress bar, phase dots
- "At a glance" stat tiles:
  - Tasks complete (e.g., 1/5, with "in progress" sub-count)
  - Projects assessed — discovered .csproj/.fsproj files
  - Assessment incidents — individual rule violations found across all projects
  - Mandatory rules — issues you must fix before upgrade can complete (highlighted in yellow/amber)
  - NuGet packages — distinct packages across the solution for the target framework
  - Incompatible packages — packages flagged as not compatible with the target framework (highlighted in red)

**Scenario**
- Sub-tabs: Active | All scenarios
- Active card: scenario ID (DOTNET-VERSION-UPGRADE), current TFM → target TFM (net472 → net10.0)
- Phase pipeline: ordered phase pills showing completed (✓) and in-progress (•) phases
- Scenario description text at the bottom

**Tasks**
- Summary tiles: TOTAL, COMPLETE, IN PROGRESS, FAILED
- Progress bar with percentage (e.g., 20% 1/5)
- Scenario label (e.g., "Scenario: dotnet-version-upgrade")
- Overview: natural-language description of the upgrade plan/strategy
- Hierarchical numbered task list with state indicators:
  - ✓ checkbox = complete (strikethrough label)
  - Spinner icon = in progress (bold label)
  - Square = pending

**Projects**
- Summary tiles: PROJECTS count, TFM UPGRADED (e.g., 0/3), INCIDENTS (total, highlighted in yellow)
- Note: "Incidents are individual locations in code that triggered an assessment rule."
- View toggle: Table | Graph
- Table columns: PROJECT (name + path), FRAMEWORK (current TFM), KIND (project type, e.g., ClassicWinForms), INCIDENTS (count, colored, clickable)

**Dependencies**
- Dependency Analysis Target: shows target TFM (e.g., net10.0)
- Number of projects analyzed against the target
- Stat tiles: NUGET PACKAGES (distinct), VERSION DRIFT (same package pinned at different versions), ASSEMBLY REFERENCES (direct GAC/loose DLL refs), PROJECT REFERENCES, FRAMEWORK REFERENCES
- Compatibility breakdown bar: Valid (green), Partial (amber), Incompatible (red), Unknown (gray) with counts
- Source file path shown (dependencies-health.json location)
- Packages table: PACKAGE, PROJECTS, VERSIONS, RECOMMENDED, COMPAT (OK / Incompat)
- "Explain" button on incompatible packages — asks the agent to explain the issue

**Assessment**
- Summary stats: PROJECTS, ISSUES, INCIDENTS, MANDATORY (highlighted in red), EFFORT
- Top categories tiles: the three largest incident categories with counts (e.g., API: 86, NuGet: 10, Project: 6)
- By Severity bar chart: Mandatory (red), Optional (amber), Potential (blue), Information (purple) with counts
- By Category bar chart: NuGet, Project, Api with counts
- Sub-tabs: Summary | Issues | Features
  - Summary: narrative assessment text (table of contents structure)
- Share icon (top-right): publishes the current assessment as a private GitHub gist
- Info icon (top-right): shows assessment metadata

**Options**
- Strategy section: selected strategy name (e.g., Bottom-Up (Dependency-First)) + rationale text
- Execution Constraints: strict tier ordering, between-tier validation rules, additional bullet constraints
- Preferences:
  - Target Framework (e.g., net10.0, net10.0-windows for WPF)
  - Flow Mode (e.g., Automatic) with "Switch to Guided" / "Switch to Automatic" toggle button
  - Commit Strategy (e.g., After Each Task)
  - Pace (e.g., Standard)

**Activity**
- Source path shown (activity.jsonl location)
- Sub-tabs: Log | Commits | By File
- Log: timestamped event list with colored event-type labels:
  - File created (green), File modified (yellow), File deleted (red), Commit (purple), Build session completed (orange)
  - Each entry: timestamp, event type, file path or message, line diff (+N -N)
- Updates live as the agent runs

-->

# Upgrade Dashboard in GitHub Copilot upgrade

[Introduce the Upgrade Dashboard as the visual monitoring panel available during GitHub Copilot upgrade sessions. State that it lets developers track upgrade progress, review the assessment, monitor tasks, and inspect projects and dependencies — all without leaving the Copilot interface.]

## Use cases

- [Use case]
- [Use case]

<!--
- Use the dashboard to monitor a long-running upgrade session in real time without polling the agent chat.
- Review assessment results — severity, categories, mandatory issues — before deciding on next steps.
- Check which tasks are complete, in progress, or failed to understand where the agent is in the upgrade.
- Identify incompatible NuGet packages and ask the agent to explain specific dependencies directly from the dashboard.
- Review the upgrade strategy, target framework, flow mode, and execution constraints the agent is using.
- Share the assessment report as a private GitHub gist for team review.
-->

## Open the dashboard

<!--
- The dashboard is not opened automatically; the user must ask Copilot to show it.
- Tell users to include a request to show the dashboard in their initial prompt, or ask at any time during an upgrade session.
- Example prompts: "Show the upgrade dashboard" or "Upgrade my solution to .NET 10 and show the dashboard."
- Available surfaces: GitHub Copilot CLI and GitHub Copilot App (desktop).
- NOT available in VS Code, Visual Studio, or other IDEs.
-->

## Dashboard panels

<!--
- Introduce the tabbed interface. The dashboard is titled "Code Upgrade" in the UI.
- A global progress bar in the top-right corner always shows overall task progress (e.g., "1/5 tasks (20%) · 1 in progress").
- List the tabs in order: Overview, Scenario, Tasks, Projects, Dependencies, Assessment, Options, Activity.
- Each tab is documented in its own section below.
-->

## Panel - Overview

<!--
- The default landing tab when the dashboard opens.
- Scenario card shows: active scenario name (e.g., dotnet-version-upgrade), current TFM → target TFM (e.g., net472 → net10.0), a progress bar, and phase dots indicating completed and in-progress phases.
- "At a glance" section shows six stat tiles:
  - Tasks complete (e.g., 1/5, with "N in progress" sub-label)
  - Projects assessed — number of discovered .csproj/.fsproj files
  - Assessment incidents — total individual rule violations across all projects
  - Mandatory rules — issues that must be resolved before the upgrade can complete (highlighted in yellow/amber)
  - NuGet packages — distinct packages referenced across the solution, analyzed against the target framework
  - Incompatible packages — packages flagged as incompatible with the target framework (highlighted in red)
- Screenshot: media/dashboard/overview.png
-->

## Panel - Scenario

<!--
- Shows the active upgrade scenario and all available scenarios.
- Sub-tabs: Active | All scenarios.
- Active scenario card shows: scenario ID (e.g., DOTNET-VERSION-UPGRADE), current TFM → target TFM with arrow (e.g., net472 → net10.0).
- Phase pipeline below the card shows each phase as a pill: completed phases have a checkmark (✓); the current phase has a dot (•).
- A description of the scenario appears at the bottom of the panel.
- Screenshot: media/dashboard/scenario.png
-->

## Panel - Tasks

<!--
- Shows all tasks the agent is executing as part of the current scenario.
- Four summary tiles at the top: TOTAL, COMPLETE, IN PROGRESS, FAILED.
- Progress bar below the tiles shows overall percentage (e.g., 20% 1/5).
- Scenario label shown (e.g., "Scenario: dotnet-version-upgrade").
- Overview section: a natural-language paragraph describing the upgrade strategy and plan (e.g., which projects are upgraded first, the overall approach).
- Task list: numbered, hierarchical. State is shown with icons:
  - Checkmark = complete (task label shown with strikethrough).
  - Spinner = in progress (task label shown in bold).
  - Square = pending (task not yet started).
- Screenshot: media/dashboard/tasks.png
-->

## Panel - Projects

<!--
- Shows all .csproj and .fsproj files discovered in the repository.
- Three summary tiles: PROJECTS (total count), TFM UPGRADED (e.g., 0/3 projects with target TFM applied), INCIDENTS (total incidents across all projects, highlighted in yellow when non-zero).
- Note shown: "Incidents are individual locations in code that triggered an assessment rule. One project may have many incidents across multiple rules."
- View toggle: Table | Graph.
- Table columns: PROJECT (name + file path), FRAMEWORK (current target framework), KIND (project type, e.g., ClassicWinForms, ClassicClassLibrary), INCIDENTS (count, color-coded and clickable).
- Screenshot: media/dashboard/projects.png
-->

## Panel - Dependencies

<!--
- Shows NuGet package and reference health for the target framework.
- Dependency Analysis Target card: shows the target TFM (e.g., net10.0).
- Projects count: how many projects were analyzed against the target.
- Five stat tiles:
  - NUGET PACKAGES — distinct NuGet packages referenced anywhere in the solution.
  - VERSION DRIFT — cases where the same NuGet package is pinned at different versions across projects.
  - ASSEMBLY REFERENCES — direct assembly references (Reference Include=...), typically GAC or loose DLLs.
  - PROJECT REFERENCES — ProjectReference edges between projects in the solution.
  - FRAMEWORK REFERENCES — FrameworkReference entries (e.g., Microsoft.AspNetCore.App); only meaningful for SDK-style projects.
- Compatibility breakdown bar: Valid (green) / Partial (amber) / Incompatible (red) / Unknown (gray) with counts.
- Source file path of the dependencies-health.json used is displayed.
- Packages table: columns are PACKAGE, PROJECTS, VERSIONS, RECOMMENDED, COMPAT. Compatibility is shown as "OK" (green) or "Incompat" (red).
- "Explain" button appears next to incompatible packages — clicking it asks the agent to explain the incompatibility.
- Screenshot: media/dashboard/dependencies.png
-->

## Panel - Assessment

<!--
- Shows the full assessment of the codebase against the target framework.
- Summary stat tiles: PROJECTS, ISSUES, INCIDENTS, MANDATORY (highlighted in red when non-zero), EFFORT.
- Top categories tiles: the three largest incident categories with counts (e.g., API: 86, NuGet: 10, Project: 6).
- By Severity bar chart: Mandatory (red), Optional (amber), Potential (blue), Information (purple) with counts.
- By Category bar chart: shows incident counts per category (NuGet, Project, Api, etc.).
- Sub-tabs: Summary | Issues | Features.
  - Summary: a narrative assessment document with table of contents (Executive Summary, Projects Compatibility, Package Compatibility, API Compatibility, etc.).
  - Issues and Features provide per-issue and per-feature breakdowns.
- Share icon (top-right): publishes the current assessment as a private GitHub gist.
- Info icon (top-right): shows assessment metadata.
- Screenshot: media/dashboard/assessment.png
-->

## Panel - Options

<!--
- Shows the configuration the agent is using for the current upgrade session.
- Strategy section:
  - Selected strategy name (e.g., Bottom-Up (Dependency-First)).
  - Rationale explaining why the agent chose this strategy for the solution.
- Execution Constraints section:
  - Strict tier ordering: defines which projects/tiers must complete before others begin.
  - Between-tier validation: validation steps that run after each tier completes.
  - Additional constraint bullets as applicable.
- Preferences section (table layout):
  - Target Framework — the TFM the solution is being upgraded to.
  - Flow Mode — Automatic or Guided, with a toggle button ("Switch to Guided" / "Switch to Automatic") to change mode.
  - Commit Strategy — when the agent commits changes (e.g., After Each Task).
  - Pace — upgrade pace (e.g., Standard).
- Screenshot: media/dashboard/options.png
-->

## Panel - Activity

<!--
- Shows a live, timestamped log of everything the agent has done.
- Source file path of the activity.jsonl being tailed is displayed at the top.
- Sub-tabs: Log | Commits | By File.
- Log sub-tab: chronological event list. Each entry shows:
  - Timestamp (date and time).
  - Event type label (color-coded): File created (green), File modified (yellow), File deleted (red), Commit (purple), Build session completed (orange).
  - File path or commit message.
  - Line diff (e.g., +3 in green, -1 in red) for file change events.
- Updates in real time as the agent runs — new entries appear at the top as the activity log grows.
- Screenshot: media/dashboard/activity.png
-->

## Limitations

- [Limitation]
- [Limitation]

<!--
- The dashboard is available only when using GitHub Copilot upgrade through the GitHub Copilot CLI or GitHub Copilot App (desktop). It is not available in VS Code, Visual Studio, or other IDEs.
- The dashboard is read-only — it shows what the agent has done and its current configuration; it does not let you edit the upgrade session directly.
- Requires an active or previously started upgrade session; a repo with no upgrade artifacts shows an empty state.
- The Activity tab updates live only while the agent is running; a completed or stopped session shows the historical log.
-->

## Related content

- [What is GitHub Copilot upgrade?](overview.md)
- [Upgrade with GitHub Copilot](how-to-upgrade-with-github-copilot.md)
- [Scenarios and skills reference](scenarios-and-skills.md)
