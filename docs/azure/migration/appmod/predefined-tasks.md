---
title: Predefined tasks for GitHub Copilot app modernization for .NET (Preview)
description: Learn about the predefined tasks that are available for GitHub Copilot app modernization for .NET
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Predefined tasks for GitHub Copilot app modernization for .NET (Preview)

This article describes the predefined tasks available for GitHub Copilot app modernization for .NET (Preview).

Predefined tasks capture industry best practices for using Azure services. Currently, App Modernization for .NET (Preview) offers predefined tasks that cover common migration scenarios. These tasks address the following subjects, and more:

- Secret management
- Message queue integration
- Database migration
- Identity management

## Predefined task list

App Modernization for .NET currently supports the following predefined tasks:

- **Migrate to Managed Identity based Database on Azure, including Azure SQL DB and Azure PostgreSQL**
  
  Modernize your data layer by migrating from on-premises or legacy databases (such as DB2, Oracle DB, or SQL Server) to Azure SQL DB or Azure PostgreSQL, using secure managed identity authentication.

- **Migrate to Azure File Storage**
  
  Move file I/O operations from the local file system to Azure File Storage for scalable, cloud-based file management.

- **Migrate to Azure Blob Storage**
  
  Replace on-premises or cross-cloud object storage, or local file system file I/O, with Azure Blob Storage for unstructured data.

- **Migrate to Microsoft Entra ID**
  
  Transition authentication and authorization from Windows Active Directory to Microsoft Entra ID (formerly Azure AD) for modern identity management.

- **Migrate to secured credentials with Managed Identity and Azure Key Vault**
  
  Replace plaintext credentials in configuration or code with secure, managed identities and Azure Key Vault for secrets management.

- **Migrate to Azure Service Bus**
  
  Move from legacy or third-party message queues (such as MSMQ or RabbitMQ) to Azure Service Bus for reliable, cloud-based messaging.

- **Migrate to Azure Communication Service email**
  
  Replace direct SMTP email sending with Azure Communication Service for scalable, secure email delivery.

- **Migrate to Confluent Cloud/Azure Event Hub for Apache Kafka**
  
  Transition from local or on-premises Kafka to managed event streaming with Confluent Cloud or Azure Event Hubs.
