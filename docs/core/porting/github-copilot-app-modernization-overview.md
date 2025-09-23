---
title: GitHub Copilot app modernization overview
description: "Learn more about GitHub Copilot app modernization. This Visual Studio extension helps you upgrade your code and projects. Upgrades can include .NET versioning or migrating code from one technology to another."
titleSuffix: ""
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 09/23/2025

#customer intent: As a developer, I want to learn about what the GitHub Copilot app modernziation is, so that I understand its capabilities and how I can take advantage of it.

---

# What is GitHub Copilot app modernization?

GitHub Copilot app modernization is a GitHub Copilot agent that helps upgrade projects to newer versions of .NET and migrate .NET applications to Azure quickly and confidently by guiding you through assessment, solution recommendations, code fixes, and validation - all within Visual Studio.

This process streamlines modernization and boosts developer productivity and confidence. GitHub Copilot app modernization is an all-in-one upgrade and migration assistant that uses AI to improve developer velocity, quality, and results.

With this assistant, you can:

- Upgrade to a newer version of .NET.
- Migrate technologies and deploy to Azure.
- Modernize your .NET app, especially when upgrading from .NET Framework.
- Assess your application's code, configuration, and dependencies.
- Plan and set up the right Azure resource.
- Fix issues and apply best practices for cloud migration.
- Validate that your app builds and tests successfully.

> [!IMPORTANT]
> Starting with Visual Studio 2022 17.14.16, the GitHub Copilot app modernization agent is included with Visual Studio. If you're using an older version of Visual Studio 2022, upgrade to the latest release.
>
> If you installed any of the following extensions published by Microsoft, uninstall them before using the version now included in Visual Studio:
>
> - .NET Upgrade Assistant
> - GitHub Copilot App Modernization – Upgrade for .NET
> - Azure Migrate Application and Code Assessment for .NET

## Provide feedback

Feedback is important to Microsoft and the efficiency of this agent. Use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a problem](/visualstudio/ide/report-a-problem) features of Visual Studio to provide feedback.

## Prerequisites

The following items are required before you can use GitHub Copilot app modernization:

[!INCLUDE[github-copilot-app-mod-prereqs](../../includes/github-copilot-app-mod-prereqs.md)]

## How to start an upgrade or migration

To start an upgrade or migration, interact with GitHub Copilot, following these steps:

[!INCLUDE[github-copilot-how-to-initiate](./includes/github-copilot-how-to-initiate.md)]

## Upgrade .NET projects

The modernization agent supports upgrading projects coded in C#. The following types of projects are supported:

- Blazor
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps

> [!NOTE]
> ASP.NET and related technologies such as MVC, Razor Pages, Web API are still in preview. You may use the tool to attempt
> upgrading these, but be aware it will only work for limited scenarios. Please see [ASP.NET Migration](/aspnet/core/migration/fx-to-core)
> for details on recommendations for these kinds of migrations.

To learn how to start an upgrade, see [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md).

### Upgrade paths

The following upgrade paths are supported:

- Upgrade projects from older .NET versions to the latest.
- Modernize your code base with new features.
- Migrate components and services to Azure.

> [!NOTE]
> Upgrading projects from .NET Framework to the latest version of .NET is still in preview.

## Migrate .NET projects to Azure

The modernization agent combines automated analysis, AI-driven code remediation, build and vulnerability checks, and deployment automation to simplify migrations to Azure. The following capabilities describe how the agent assesses readiness, applies fixes, and streamlines the migration process:

- Analysis & Intelligent Recommendations.

  Assess your application's readiness for Azure migration and receive tailored guidance based on its dependencies and identified issues.

- AI-Powered Code Remediation.

  Apply predefined best-practice code patterns to accelerate modernization with minimal manual effort.

- Automatic Build and CVE Resolution.

  Automatically builds your app and resolves compilation errors and vulnerabilities, streamlining development.

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

## How does it work

Once you request the modernization agent to upgrade or migrate your app, Copilot analyzes your projects and their dependencies, and then asks you a series of questions about the upgrade or migration. After you answer these questions, a plan is written in the form of a Markdown file. If you tell Copilot to proceed with the upgrade or migration, it follows the steps described in the plan.

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
- [Quickstart to migrate a .NET Project](../../azure/migration/appmod/quickstart.md)
- [GitHub Copilot app modernization FAQ](github-copilot-app-modernization-faq.yml)
