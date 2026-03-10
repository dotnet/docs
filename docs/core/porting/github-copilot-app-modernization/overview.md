---
title: GitHub Copilot app modernization overview
description: "Learn about GitHub Copilot app modernization, a Copilot agent available across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com that upgrades .NET projects and migrates apps to Azure."
titleSuffix: ""
ms.topic: overview
ms.date: 03/04/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to learn about what GitHub Copilot app modernization is, so that I understand its capabilities and how I can take advantage of it.

---

# What is GitHub Copilot app modernization?

GitHub Copilot app modernization is a GitHub Copilot agent that helps you upgrade projects to newer versions of .NET and migrate .NET applications to Azure quickly and confidently. It guides you through assessment, solution recommendations, code fixes, and validation across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com.

Use this agent to:

- Upgrade to a newer version of .NET.
- Migrate technologies and deploy to Azure.
- Modernize your .NET app, especially when upgrading from .NET Framework.
- Assess your application's code, configuration, and dependencies.
- Plan and set up the right Azure resource.
- Fix issues and apply best practices for cloud migration.
- Validate that your app builds and tests successfully.

## Provide feedback

Microsoft values your feedback and uses it to improve this agent. There are two ways to leave feedback:

- In Visual Studio, use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a problem](/visualstudio/ide/report-a-problem) options.

- File an issue at the [@modernize-dotnet GitHub repository](https://github.com/dotnet/modernize-dotnet).

## Prerequisites

Set up GitHub Copilot app modernization in your development environment before using the agent. For installation steps, see [Install GitHub Copilot app modernization](install.md).

## Upgrade .NET projects

The modernization agent supports upgrading C# projects of the following types:

- ASP.NET Core (and related technologies such as MVC, Razor Pages, and Web API)
- Blazor
- Azure Functions
- Windows Presentation Foundation (WPF)
- Windows Forms
- Class libraries
- Console apps

To start an upgrade, see [Upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md).

### Upgrade paths

The agent supports the following upgrade paths:

- Upgrade projects from older .NET versions to the latest.
- Upgrade .NET Framework projects to .NET.
- Modernize your code base by using new features.
- Migrate components and services to Azure.

## Migrate .NET projects to Azure

The modernization agent simplifies Azure migrations through automated analysis, AI-driven code remediation, build and vulnerability checks, and deployment automation:

- Analysis and intelligent recommendations

  Assess your application's readiness for Azure migration and receive tailored guidance based on its dependencies and identified problems.

- AI-powered code remediation

  Apply predefined best-practice code patterns to accelerate modernization with minimal manual effort.

- Automatic build and CVE resolution

  Build your app and resolve compilation errors and vulnerabilities, streamlining development.

- Seamless deployment

  Deploy to Azure, taking your code from development to production faster.

### Predefined tasks for migration

GitHub Copilot app modernization for .NET offers predefined tasks that capture industry best practices and cover common migration scenarios.

- **Migrate to Managed Identity based Database on Azure, including Azure SQL DB, Azure SQL MI, and Azure PostgreSQL**

  Modernize your data layer by migrating from on-premises or legacy databases (such as DB2, Oracle DB, or SQL Server) to Azure SQL DB, Azure SQL Managed Instance, or Azure PostgreSQL. Use secure managed identity authentication.

- **Migrate to Azure File Storage**

  Move file I/O operations from the local file system to Azure File Storage for scalable, cloud-based file management.

- **Migrate to Azure Blob Storage**

  Replace on-premises or cross-cloud object storage, or local file system file I/O, with Azure Blob Storage for unstructured data.

- **Migrate to Microsoft Entra ID**

  Transition authentication and authorization from Windows Active Directory to Microsoft Entra ID (formerly Azure AD) for modern identity management.

- **Migrate to secured credentials by using Managed Identity and Azure Key Vault**

  Replace plaintext credentials in configuration or code with secure, managed identities and Azure Key Vault for secrets management.

- **Migrate to Azure Service Bus**

  Move from legacy or third-party message queues (such as MSMQ or RabbitMQ) or Amazon SQS (AWS Simple Queue Service) to Azure Service Bus for reliable, cloud-based messaging.

- **Migrate to Azure Communication Service email**

  Replace direct SMTP email sending by using Azure Communication Service for scalable, secure email delivery.

- **Migrate to Confluent Cloud/Azure Event Hub for Apache Kafka**

  Transition from local or on-premises Kafka to managed event streaming by using Confluent Cloud or Azure Event Hubs.

- **Migrate to OpenTelemetry on Azure**

  Transition from local logging frameworks like log4net, serilog, and Windows event log to OpenTelemetry on Azure.

- **Migrate to Azure Cache for Redis by using Managed Identity**

  Replace in-memory or local Redis cache implementations with Azure Cache for Redis for high availability, scalability, and enterprise-grade security.

## How it works

To start an upgrade or migration process, see:

[!INCLUDE[github-copilot-how-to-initiate](./includes/how-to-initiate.md)]

When you ask the modernization agent to upgrade your app, Copilot first prompts you to create a new branch if you're working in a Git repository. Then Copilot runs a three-stage workflow. Each stage writes a Markdown file under `.github/upgrades` in your repository so you can review what comes next before you continue. If `.github/upgrades` already exists from a prior attempt, Copilot asks whether to continue or start fresh.

- **Assessment stage (`assessment.md`)**\
Copilot examines your project structure, dependencies, and code patterns to build a comprehensive assessment. The document lists breaking changes, API compatibility problems, deprecated patterns, and the upgrade scope so you know exactly what needs attention.

- **Planning stage (`plan.md`)**\
Copilot converts the assessment into a detailed specification that explains how to resolve every problem. The plan documents upgrade strategies, refactoring approaches, dependency upgrade paths, and risk mitigations.

- **Execution stage (`tasks.md`)**\
Copilot breaks the plan into sequential, concrete tasks with validation criteria. Each task describes a single change and how Copilot confirms it succeeded.

Edit any of the Markdown files in `.github/upgrades` to adjust upgrade steps or add context before you move forward.

### Perform the upgrade

After each stage completes, review and modify the generated tasks as needed, and then tell Copilot to continue to the next stage.

When you reach the **Execution stage**, tell Copilot to start the upgrade. If Copilot runs into a problem, it tries to identify the cause and apply a fix. If Copilot can't correct the problem, it asks for your help. When you intervene, Copilot learns from the changes you make and tries to automatically apply them if the problem comes up again.

### Upgrade results

As Copilot runs each task, it updates the `tasks.md` file in `.github/upgrades` with the status of every step. Monitor progress by reviewing this file. The tool creates a Git commit for every portion of the process, so you can roll back changes or review what changed.

When the upgrade finishes, Copilot displays next steps in the chat response.

## Telemetry

The tool collects data about project types, intent to upgrade, and upgrade duration. The development environment collects and aggregates the data and doesn't contain any user-identifiable information. For more information about Microsoft's privacy policy, see [Visual Studio Customer Experience Improvement Program](/visualstudio/ide/visual-studio-experience-improvement-program?view=visualstudio&preserve-view=true).

## Related content

- [Install GitHub Copilot app modernization](install.md)
- [Upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md)
- [Quickstart: Migrate a .NET project](../../../azure/migration/appmod/quickstart.md)
- [GitHub Copilot app modernization FAQ](faq.yml)
