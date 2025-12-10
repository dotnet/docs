---
title: GitHub Copilot app modernization overview
description: "Learn more about GitHub Copilot app modernization. This Visual Studio extension helps you upgrade your code and projects. Upgrades can include .NET versioning or migrating code from one technology to another."
titleSuffix: ""
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 12/09/2025
ai-usage: ai-assisted

#customer intent: As a developer, I want to learn about what the GitHub Copilot app modernization is, so that I understand its capabilities and how I can take advantage of it.

---

# What is GitHub Copilot app modernization?

GitHub Copilot app modernization is a GitHub Copilot agent that helps you upgrade projects to newer versions of .NET and migrate .NET applications to Azure quickly and confidently. It guides you through assessment, solution recommendations, code fixes, and validation—all within Visual Studio.

This process streamlines modernization and boosts developer productivity and confidence. GitHub Copilot app modernization is an all-in-one upgrade and migration agent that uses AI to improve developer velocity, quality, and results.

With this agent, you can:

- Upgrade to a newer version of .NET.
- Migrate technologies and deploy to Azure.
- Modernize your .NET app, especially when upgrading from .NET Framework.
- Assess your application's code, configuration, and dependencies.
- Plan and set up the right Azure resource.
- Fix issues and apply best practices for cloud migration.
- Validate that your app builds and tests successfully.

## Provide feedback

Feedback is important to Microsoft and the efficiency of this agent. Use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a problem](/visualstudio/ide/report-a-problem) features of Visual Studio to provide feedback.

## Prerequisites

Before using GitHub Copilot app modernization, you need these items:

[!INCLUDE [github-copilot-app-modernization-prereqs](../../../includes/github-copilot-app-modernization-prereqs.md)]

## How to start an upgrade or migration

To start an upgrade or migration, interact with GitHub Copilot by following these steps:

[!INCLUDE[github-copilot-how-to-initiate](./includes/how-to-initiate.md)]

If your repository already contains the `.github/upgrades` folder with the stage files from a previous upgrade or migration attempt, Copilot asks whether you want to continue that upgrade or start over with a fresh analysis.

## Upgrade .NET projects

The modernization agent supports upgrading projects coded in C#. The agent supports the following project types:

- ASP.NET Core (and related technologies such as MVC, Razor Pages, and Web API)
- Blazor
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps

To learn how to start an upgrade, see [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md).

### Upgrade paths

The agent supports the following upgrade paths:

- Upgrade projects from older .NET versions to the latest.
- Upgrade .NET Framework projects to .NET.
- Modernize your code base with new features.
- Migrate components and services to Azure.

## Migrate .NET projects to Azure

The modernization agent combines automated analysis, AI-driven code remediation, build and vulnerability checks, and deployment automation to simplify migrations to Azure. The agent assesses readiness, applies fixes, and streamlines the migration process through these capabilities:

- Analysis & Intelligent Recommendations.

  Assess your application's readiness for Azure migration and receive tailored guidance based on its dependencies and identified issues.

- AI-Powered Code Remediation.

  Apply predefined best-practice code patterns to accelerate modernization with minimal manual effort.

- Automatic Build and CVE Resolution.

  Automatically build your app and resolve compilation errors and vulnerabilities, streamlining development.

- Seamless Deployment.

  Deploy to Azure effortlessly, taking your code from development to cloud faster than ever.

### Predefined tasks for migration

Predefined tasks capture industry best practices for using Azure services. Currently, GitHub Copilot app modernization for .NET offers predefined tasks that cover common migration scenarios.

- **Migrate to Managed Identity based Database on Azure, including Azure SQL DB, Azure SQL MI, and Azure PostgreSQL**

  Modernize your data layer by migrating from on-premises or legacy databases (such as DB2, Oracle DB, or SQL Server) to Azure SQL DB, Azure SQL Managed Instance, or Azure PostgreSQL, using secure managed identity authentication.

- **Migrate to Azure File Storage**

  Move file I/O operations from the local file system to Azure File Storage for scalable, cloud-based file management.

- **Migrate to Azure Blob Storage**

  Replace on-premises or cross-cloud object storage, or local file system file I/O, with Azure Blob Storage for unstructured data.

- **Migrate to Microsoft Entra ID**

  Transition authentication and authorization from Windows Active Directory to Microsoft Entra ID (formerly Azure AD) for modern identity management.

- **Migrate to secured credentials with Managed Identity and Azure Key Vault**

  Replace plaintext credentials in configuration or code with secure, managed identities and Azure Key Vault for secrets management.

- **Migrate to Azure Service Bus**

  Move from legacy or third-party message queues (such as MSMQ or RabbitMQ) or Amazon SQS (AWS Simple Queue Service) to Azure Service Bus for reliable, cloud-based messaging.

- **Migrate to Azure Communication Service email**

  Replace direct SMTP email sending with Azure Communication Service for scalable, secure email delivery.

- **Migrate to Confluent Cloud/Azure Event Hub for Apache Kafka**

  Transition from local or on-premises Kafka to managed event streaming with Confluent Cloud or Azure Event Hubs.

- **Migrate to OpenTelemetry on Azure**

  Transition from local logging frameworks like log4net, serilog, and Windows event log to OpenTelemetry on Azure.

- **Migrate to Azure Cache for Redis with Managed Identity**
  Replace in-memory or local Redis cache implementations with Azure Cache for Redis for high availability, scalability, and enterprise-grade security.

## How it works

When you ask the modernization agent to upgrade or migrate your app, Copilot first prompts you to create a new branch if you're working in a Git repository. Then Copilot runs a three-stage workflow. Each stage writes a Markdown file under `.github/upgrades` in your repository so you can review what comes next before you continue. If `.github/upgrades` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

- **Analysis stage (`assessment.md`)**\
Copilot examines your project structure, dependencies, and code patterns to build a comprehensive assessment. The document lists breaking changes, API compatibility issues, deprecated patterns, and the migration scope so you know exactly what needs attention.

- **Planning stage (`plan.md`)**\
Copilot converts the assessment into a detailed specification that explains how to resolve every issue. The plan documents migration strategies, refactoring approaches, dependency upgrade paths, and risk mitigations.

- **Execution stage (`tasks.md`)**\
Copilot breaks the plan into sequential, concrete tasks with validation criteria. Each task describes a single change and how Copilot confirms it succeeded.

Edit any of the Markdown files in `.github/upgrades` to adjust upgrade steps or add context before you move forward.

### Perform the upgrade or migration

As each stage is prepared, tell Copilot to move on to the next stage, giving you time to research and modify (if necessary) any of the tasks the stage has laid out.

Once you reach the last stage, **Execution stage**, tell Copilot to start the upgrade or migration. If Copilot runs into a problem, it tries to identify the cause and apply a fix. If Copilot can't correct the problem, it asks for your help. When you intervene, Copilot learns from the changes you make and tries to automatically apply them for you if the problem is encountered again.

### Upgrade and migration results

As Copilot runs each task, it updates the `tasks.md` file in `.github/upgrades` with the status of every step. Monitor progress by reviewing this file. The tool creates a Git commit for every portion of the process, so you can easily roll back the changes or get detailed information about what changed.

When the upgrade or migration finishes, Copilot displays next steps in the chat response to guide you on what to do after the process completes.

## Telemetry

The tool collects data about project types, intent to upgrade, and upgrade duration. Visual Studio itself collects and aggregates the data and doesn't contain any user-identifiable information. For more information about Microsoft's privacy policy, see [Visual Studio Customer Experience Improvement Program](/visualstudio/ide/visual-studio-experience-improvement-program?view=visualstudio&preserve-view=true).

## Related content

- [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md)
- [Quickstart to migrate a .NET Project](../../../azure/migration/appmod/quickstart.md)
- [GitHub Copilot app modernization FAQ](faq.yml)
