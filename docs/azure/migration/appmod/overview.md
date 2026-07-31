---
title: GitHub Copilot modernization overview
description: "Learn about GitHub Copilot modernization, a Copilot agent that migrates .NET applications to Azure through automated assessment, AI-driven code remediation, and deployment automation."
titleSuffix: ""
ms.topic: overview
ms.date: 07/30/2026
ms.custom: devx-track-dotnet
ai-usage: ai-assisted

#customer intent: As a developer, I want to learn about what GitHub Copilot modernization is, so that I understand its capabilities and how I can take advantage of it.

---

# What is GitHub Copilot modernization?

GitHub Copilot modernization is a GitHub Copilot agent that migrates .NET applications to Azure quickly and confidently. It guides you through assessment, solution recommendations, code fixes, and deployment across Visual Studio, Visual Studio Code, GitHub Copilot CLI, and GitHub.com.

Use this agent to:

- Migrate technologies and deploy to Azure.
- Assess your application's code, configuration, and dependencies for Azure readiness.
- Plan and set up the right Azure resources.
- Fix issues and apply best practices for cloud migration.
- Validate that your app builds and tests successfully after migration.

When your migration requires upgrading to a newer version of .NET, the modernization agent invokes [GitHub Copilot upgrade](../../../core/porting/github-copilot-upgrade/overview.md) to handle the version upgrade.

## Scenarios

The agent provides predefined migration scenarios for common Azure targets. For a full reference, see the [Predefined tasks for migration](#predefined-tasks-for-migration) section below.

When a migration requires upgrading the .NET version, the modernization agent coordinates with [GitHub Copilot upgrade](../../../core/porting/github-copilot-upgrade/overview.md) to perform the version upgrade as part of the migration workflow.

## Provide feedback

Microsoft values your feedback and uses it to improve the agent. Leave feedback using either of these options:

- In Visual Studio, use the [Suggest a feature](/visualstudio/ide/suggest-a-feature) and [Report a problem](/visualstudio/ide/report-a-problem) options.

- File an issue at the [Upgrade Agent GitHub repository](https://github.com/microsoft/upgrade-agent-plugins).

## Prerequisites

Set up GitHub Copilot modernization in your development environment before using the agent. For installation steps, see [Install GitHub Copilot modernization](install.md).

## Migrate .NET projects to Azure

The modernization agent simplifies Azure migrations through automated analysis, AI-driven code remediation, build and vulnerability checks, and deployment automation:

- Analysis and intelligent recommendations.

  Assess your application's readiness for Azure migration and receive tailored guidance based on its dependencies and identified problems.

- AI-powered code remediation.

  Apply predefined best-practice code patterns to accelerate modernization with minimal manual effort.

- Automatic build and CVE resolution.

  Build your app and resolve compilation errors and vulnerabilities, streamlining development.

- Seamless deployment.

  Deploy to Azure, taking your code from development to production faster.

### Predefined tasks for migration

GitHub Copilot modernization for .NET offers predefined tasks that capture industry best practices and cover common migration scenarios.

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

  Replace direct SMTP email sending with Azure Communication Service for scalable, secure email delivery.

- **Migrate to Confluent Cloud/Azure Event Hub for Apache Kafka**

  Transition from local or on-premises Kafka to managed event streaming with Confluent Cloud or Azure Event Hubs.

- **Migrate to OpenTelemetry on Azure**

  Transition from local logging frameworks such as log4net, Serilog, and Windows event log to OpenTelemetry on Azure.

- **Migrate to Azure Cache for Redis by using Managed Identity**

  Replace in-memory or local Redis cache implementations with Azure Cache for Redis for high availability, scalability, and enterprise-grade security.

## Upgrade .NET projects

When your migration requires upgrading your .NET projects to a newer version, the GitHub Copilot modernization agent calls [GitHub Copilot upgrade](../../../core/porting/github-copilot-upgrade/overview.md) to perform the version upgrade. The upgrade runs as part of the overall modernization workflow. For more information about what the upgrade agent supports, see [What is GitHub Copilot upgrade?](../../../core/porting/github-copilot-upgrade/overview.md).

## Telemetry

The tool collects data about project types, intent to upgrade, and upgrade duration. The development environment collects and aggregates the data and doesn't contain any user-identifiable information. For more information about Microsoft's privacy policy, see [Visual Studio Customer Experience Improvement Program](/visualstudio/ide/visual-studio-experience-improvement-program?view=visualstudio&preserve-view=true).

## Related content

- [Install GitHub Copilot modernization](install.md)
- [Quickstart: Migrate a .NET project to Azure](quickstart.md)
- [GitHub Copilot modernization FAQ](faq.yml)
