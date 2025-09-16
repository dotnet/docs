---
title: GitHub Copilot app modernization overview
description: "Learn more about GitHub Copilot app modernization. This Visual Studio extension helps you upgrade your code and projects. Upgrades can include .NET versioning or migrating code from one technology to another."
titleSuffix: ""
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 09/15/2025

#customer intent: As a developer, I want to upgrade my project so that I can take advantage of the latest features.

---

# What is GitHub Copilot app modernization

GitHub Copilot app modernization is a GitHub Copilot agent that helps upgrade projects to newer versions of .NET and migrate .NET applications to Azure quickly and confidently by guiding you through assessment, solution recommendations, code fixes, and validation - all within Visual Studio.  

This process streamlines modernization and boosts developer productivity and confidence. GitHub Copilot app modernization is an all-in-one upgrade and migration assistant that uses AI to improve developer velocity, quality, and results.

With this assistant, you can:

- Upgrade to a newer version of .NET.
- Migrate technologies to Azure.
- Modernize your .NET app, especially when upgrading from .NET Framework.
- Assess your application's code, configuration, and dependencies.
- Plan and set up the right Azure resource.
- Fix issues and apply best practices for cloud migration.
- Validate that your app builds and tests successfully.

## Provide feedback

Feedback is important to Microsoft and the efficiency of this agent. Use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a Problem](/visualstudio/ide/report-a-problem) features of in Visual Studio to provide feedback.

## Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.14.16 or newer](https://visualstudio.microsoft.com/downloads/). (To be released)
- [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#change-workloads-or-individual-components) with the following optional components enabled:

  - GitHub Copilot
  - GitHub Copilot app modernization for .NET

- Copilot license and supported subscription plan:

  [Sign in to Visual Studio using a GitHub account](/visualstudio/ide/work-with-github-accounts) with [Copilot access](https://docs.github.com/copilot/about-github-copilot/what-is-github-copilot#getting-access-to-copilot).

  Supported subscription plans:

  - Copilot Pro
  - Copilot Pro+
  - Copilot Business
  - Copilot Enterprise

  (If you change subscriptions, you must restart Visual Studio.)

- Code must be written in C#.

## Upgrade .NET projects

The modernization agent supports upgrading projects coded in C#. The following types of projects are supported:

- ASP.NET and related technologies such as MVC, Razor Pages, Web API
- Blazor
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps

To learn how to start an upgrade, see [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md).

### Upgrade paths

The following upgrade paths are supported:

- Upgrade projects from older .NET versions to the latest.
- Upgrade projects from .NET Framework to the latest version of .NET.
- Modernize your code base with new features.
- Migrate components and services to Azure.

## Migrate .NET projects to Azure

The modernization agent combines automated analysis, AI-driven code remediation, build and vulnerability checks, and deployment automation to simplify migrations to Azure. The following capabilities describe how the agent assesses readiness, applies fixes, and streamlines the migration process:

- Analysis & Intelligent Recommendations.

  Assess your application's readiness for Azure migration and receive tailored guidance based on its dependencies and identified issues.

- AI-Powered Code Remediation.

  Apply predefined best-practice code patterns to accelerate modernization with minimal manual effort.

- Automatic Build and CVE Resolution.

  automatically builds your app and resolves compilation errors and vulnerabilities, streamlining development.

- Seamless Deployment.

  Deploy to Azure effortlessly, taking your code from development to cloud faster than ever.

## How does it work

Once you request the Modernization agent to upgrade or migrate your app, Copilot analyzes your projects and their dependencies, and then asks you a series of questions about the upgrade or migration. After you answer these questions, a plan is written in the form of a Markdown file. If you tell Copilot to proceed with the upgrade or migration, it follows the steps described in the plan.

You can adjust the plan by editing the Markdown file to change the upgrade steps or add more context.

### Perform the upgrade or migration

Once a plan is ready, tell Copilot to start using it. Once the process starts, Copilot lets you know what it's doing in the chat window and it opens the **Upgrade Progress Details** document, which lists the status of every step.

If it runs into a problem, Copilot tries to identify the cause of a problem and apply a fix. If Copilot can't seem to correct the problem, it asks for your help. When you intervene, Copilot learns from the changes you make and tries to automatically apply them for you, if the problem is encountered again.

Each major step in the plan is committed to the local Git repository.

### Upgrade and migration results

When the process completes, a report is generated that describes every step taken by Copilot. The tool creates a Git commit for every portion of the process, so you can easily roll back the changes or get detailed information about what changed. The report contains the Git commit hashes.

The report also provides a _Next steps_ section that describes the steps you should take after the upgrade finishes.

## Telemetry

The tool only collects data about project types, intent to upgrade, and upgrade duration. The data is collected and aggregated through Visual Studio itself and doesn't contain any user-identifiable information. For more information about Microsoft's privacy policy, see [Visual Studio Customer Experience Improvement Program](/visualstudio/ide/visual-studio-experience-improvement-program?view=vs-2022&preserve-view=true).

## Related content

- [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md)
- [GitHub Copilot app modernization FAQ](github-copilot-app-modernization-faq.yml)
