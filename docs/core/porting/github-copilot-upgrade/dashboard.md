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

# Upgrade Dashboard in GitHub Copilot upgrade

The Upgrade Dashboard is the visual monitoring panel for GitHub Copilot upgrade sessions. Titled "Code Upgrade" in the UI, it gives you a real-time view of your upgrade across eight tabs: Overview, Scenario, Tasks, Projects, Dependencies, Assessment, Options, and Activity. Use it to track progress, review assessment results, inspect NuGet package compatibility, and examine the upgrade configuration.

The dashboard appears as a side panel in the GitHub Copilot App (desktop). When you run the upgrade agent through the GitHub Copilot CLI, it opens in your browser. The dashboard isn't available in VS Code, Visual Studio, or other IDEs.

## Use cases

The Upgrade Dashboard supports these monitoring scenarios during an upgrade session:

- **Monitor progress in real time**: Track which tasks the agent has completed, which are in progress, and which have failed, without polling the agent chat.
- **Review assessment results**: Examine severity levels, incident categories, and mandatory issues before deciding on next steps.
- **Inspect NuGet compatibility**: Identify packages that aren't compatible with the target framework and ask the agent to explain specific dependencies directly from the dashboard.
- **Understand the upgrade strategy**: Review the target framework, flow mode, execution constraints, and commit strategy the agent is using.
- **Share assessment reports**: Publish the current assessment as a private GitHub gist for team review.

## Open the dashboard

The dashboard doesn't open automatically. Ask Copilot to show it as part of your initial prompt or at any point during an active upgrade session.

Example prompts:

- "Show the upgrade dashboard."
- "Upgrade my solution to .NET 10 and show the dashboard."

When you're using the GitHub Copilot App, the dashboard opens in the side panel. When you're using the GitHub Copilot CLI, it opens in your browser.

## Dashboard tabs

The dashboard is organized into eight tabs, accessible from the top navigation bar. A global progress bar in the header shows overall task progress at a glance, so you always know where the session stands, no matter which tab you're viewing.

The tabs, in order, are: **Overview**, **Scenario**, **Tasks**, **Projects**, **Dependencies**, **Assessment**, **Options**, and **Activity**.

## Overview tab

The Overview tab is the default view when you open the dashboard. It summarizes the entire upgrade session on a single screen.

At the top, a scenario card shows the active upgrade scenario. The details include its name (for example, `dotnet-version-upgrade`), the current TFM and the upgrade target (for example, `net472 → net10.0`), a progress bar, and phase dots indicating which phases are complete and which are in progress.

Below the scenario card, an "At a glance" section displays six stat tiles:

- **Tasks complete**: The number of completed tasks out of the total (for example, 1/5), with an "N in progress" sub-label.
- **Projects assessed**: The number of project files discovered in the repository.
- **Assessment incidents**: The total count of individual rule violations found across all projects.
- **Mandatory rules**: Issues that must be resolved before the upgrade can complete (highlighted in amber).
- **NuGet packages**: The number of distinct NuGet packages referenced across the solution, analyzed against the target framework.
- **Incompatible packages**: Packages flagged as incompatible with the target framework (highlighted in red).

:::image type="content" source="media/dashboard/overview.png" alt-text="Screenshot of the Upgrade Dashboard Overview tab." lightbox="media/dashboard/overview.png":::

## Scenario tab

The Scenario tab shows the active upgrade scenario and all available scenarios for the repository.

It has two sub-tabs: **Active** and **All scenarios**. The Active sub-tab displays a card for the current scenario, showing the scenario ID (for example, `DOTNET-VERSION-UPGRADE`) and the TFM transition (for example, `net472 → net10.0`).

Below the card, a phase pipeline displays each phase of the upgrade as a labeled pill. Completed phases show a checkmark (✓), and the current phase shows a dot (•). This pipeline gives you a quick view of how far along the upgrade is within the current scenario. A short description of the scenario's purpose and approach appears at the bottom of the panel.

:::image type="content" source="media/dashboard/scenario.png" alt-text="Screenshot of the Upgrade Dashboard Scenario tab." lightbox="media/dashboard/scenario.png":::

## Tasks tab

The Tasks tab shows every task the agent is executing as part of the current scenario, along with a natural-language overview of the upgrade plan.

Four summary tiles at the top show counts for TOTAL, COMPLETE, IN PROGRESS, and FAILED tasks. A progress bar below the tiles shows the overall percentage complete (for example, "20% 1/5"), and a scenario label identifies which scenario the tasks belong to.

An Overview section appears below the progress bar. The section contains a narrative paragraph that describes the upgrade strategy. For example, which projects are being upgraded first and the overall sequencing approach.

The task list below is numbered and hierarchical. Each task shows its current state with an icon:

- **Checkmark**: The task is complete. The task label appears with strikethrough formatting.
- **Spinner**: The task is in progress. The task label appears in bold.
- **Square**: The task is pending and hasn't started yet.

:::image type="content" source="media/dashboard/tasks.png" alt-text="Screenshot of the Upgrade Dashboard Tasks tab." lightbox="media/dashboard/tasks.png":::

## Projects tab

The Projects tab lists every `.csproj` and `.fsproj` file discovered in the repository, along with per-project assessment data.

Three summary tiles appear at the top: **PROJECTS** (total count), **TFM UPGRADED** (how many projects have had the target TFM applied, for example, "0/3"), and **INCIDENTS** (total incidents across all projects, highlighted in amber when non-zero). A note below the tiles explains that incidents are individual locations in code that triggered an assessment rule.

The project list supports two views, toggled with **Table** and **Graph** buttons. In table view, four columns describe each project:

- **PROJECT**: The project name and its file path.
- **FRAMEWORK**: The project's current target framework.
- **KIND**: The project type (for example, `ClassicWinForms`, `ClassicClassLibrary`).
- **INCIDENTS**: The incident count, color-coded and clickable to drill into specific issues.

In graph view, the projects are displayed as circles with connected lines demonstrating how projects depend or reference each other.

:::image type="content" source="media/dashboard/projects.png" alt-text="Screenshot of the Upgrade Dashboard Projects tab." lightbox="media/dashboard/projects.png":::

## Dependencies tab

The Dependencies tab analyzes the NuGet package and assembly reference health of your solution against the target framework.

A **Dependency Analysis Target** card at the top shows the target TFM (for example, `net10.0`) and the number of projects analyzed. Five stat tiles summarize the dependency landscape:

- **NUGET PACKAGES**: The number of distinct NuGet packages referenced anywhere in the solution.
- **VERSION DRIFT**: Cases where the same package is pinned at different versions across projects.
- **ASSEMBLY REFERENCES**: Direct assembly references (`<Reference Include="..."/>`), typically from the GAC or loose DLLs.
- **PROJECT REFERENCES**: `<ProjectReference>` edges between projects in the solution.
- **FRAMEWORK REFERENCES**: `<FrameworkReference>` entries (for example, `Microsoft.AspNetCore.App`), meaningful only in SDK-style projects.

A compatibility breakdown bar shows the overall health of packages at a glance: **Valid** (green), **Partial** (amber), **Incompatible** (red), and **Unknown** (gray), each with a count. The path of the `dependencies-health.json` file the dashboard is reading appears beneath the bar.

The packages table lists every package with five columns: **PACKAGE**, **PROJECTS**, **VERSIONS**, **RECOMMENDED**, and **COMPAT**. Compatibility appears as either "OK" (green) or "Incompat" (red). Incompatible packages show an **Explain** button that, when selected, asks the agent to explain the incompatibility directly in the chat.

:::image type="content" source="media/dashboard/dependencies.png" alt-text="Screenshot of the Upgrade Dashboard Dependencies tab." lightbox="media/dashboard/dependencies.png":::

## Assessment tab

The Assessment tab provides the full codebase assessment against the target framework, including severity breakdowns, category charts, and a narrative assessment document.

Five summary stat tiles appear at the top: **PROJECTS**, **ISSUES**, **INCIDENTS**, **MANDATORY** (highlighted in red when non-zero), and **EFFORT**. Below these, three "top category" tiles highlight the largest incident groups. For example, API: 86, NuGet: 10, Project: 6.

Two bar charts visualize the incident distribution:

- **By Severity**: Breaks incidents into Mandatory (red), Optional (amber), Potential (blue), and Information (purple).
- **By Category**: Shows counts per category, such as NuGet, Project, and API.

The tab has three sub-tabs: **Summary**, **Issues**, and **Features**. The Summary sub-tab contains a narrative assessment document with a table of contents covering sections such as Executive Summary, Projects Compatibility, Package Compatibility, and API Compatibility. The Issues and Features sub-tabs provide per-issue and per-feature breakdowns.

Two icons appear in the top-right corner of the Assessment tab. The **info** icon displays assessment metadata such as the assessment date and version. The **share** icon publishes the current assessment as a private GitHub gist that you can share with your team.

:::image type="content" source="media/dashboard/assessment.png" alt-text="Screenshot of the Upgrade Dashboard Assessment tab." lightbox="media/dashboard/assessment.png":::

## Options tab

The Options tab shows the configuration the agent is using for the current upgrade session. This tab is read-only. It reflects choices made when you started the session, though you can change some preferences through the agent chat or the toggle provided on this tab.

The tab is organized into three sections:

**Strategy** shows the selected upgrade strategy name (for example, "Bottom-Up (Dependency-First)") and the agent's rationale for choosing it, based on the structure of your solution.

**Execution Constraints** lists the rules governing how the upgrade proceeds: strict tier ordering (which projects or tiers must complete before others begin), between-tier validation steps (checks run after each tier completes), and any other constraints.

**Preferences** is displayed as a table with four rows:

- **Target Framework**: The TFM the solution is being upgraded to (for example, `net10.0` or `net10.0-windows` for WPF applications).
- **Flow Mode**: Whether the agent runs automatically or waits for your approval at each step. A **Switch to Guided** or **Switch to Automatic** button lets you toggle the mode, which relays the request to the agent.
- **Commit Strategy**: When the agent commits changes (for example, "After Each Task").
- **Pace**: The upgrade pace (for example, "Standard").

:::image type="content" source="media/dashboard/options.png" alt-text="Screenshot of the Upgrade Dashboard Options tab." lightbox="media/dashboard/options.png":::

## Activity tab

The Activity tab provides a live, timestamped log of every action the agent has taken. The path to the `activity.jsonl` file being tailed appears at the top of the panel.

The tab has three sub-tabs: **Log**, **Commits**, and **By File**. The Log sub-tab is a chronological event list that updates in real time as the agent runs, with new entries appearing at the top as the log grows. Each entry shows:

- **Timestamp**: The date and time the event occurred.
- **Event type**: A color-coded label: File created (green), File modified (yellow), File deleted (red), Commit (purple), Build session completed (orange).
- **Details**: The file path or commit message associated with the event.
- **Line diff**: For file-change events, a diff indicator (for example, +3 in green, -1 in red) shows how many lines were added or removed.

:::image type="content" source="media/dashboard/activity.png" alt-text="Screenshot of the Upgrade Dashboard Activity tab." lightbox="media/dashboard/activity.png":::

## Limitations

- The dashboard is available only through the GitHub Copilot App (desktop) and GitHub Copilot CLI. It isn't available in VS Code, Visual Studio, or other IDEs.
- The dashboard is read-only. It shows the agent's current configuration and what it has done, but doesn't let you edit the upgrade session directly. To change preferences such as flow mode, use the agent chat or the toggle button on the Options tab.
- A repository with no upgrade artifacts shows an empty state. To see meaningful data, the repository must have an active or previously started upgrade session.
- The Activity tab updates live only while the agent is running. A completed or stopped session shows the historical log but doesn't continue updating.

## Related content

- [What is GitHub Copilot upgrade?](overview.md)
- [Upgrade with GitHub Copilot](how-to-upgrade-with-github-copilot.md)
- [Scenarios and skills reference](scenarios-and-skills.md)
