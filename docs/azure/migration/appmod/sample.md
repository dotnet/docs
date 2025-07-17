---
title: GitHub Copilot App Modernization for .NET (Preview) sample
description: Learn about the sample project for GitHub Copilot App Modernization for .NET
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 7/15/2025
author: alexwolfmsft
ms.author: alexwolf
---

# Contoso University Migration Sample

The [Contoso University sample web app](https://github.com/Azure-Samples/dotnet-migration-copilot-samples/tree/main/ContosoUniversity) provides an example project you can experiment with using GitHub Copilot App Modernization for .NET (Preview). For more information and step-by-step instructions, see the [quickstart guide](quickstart.md).

## Scenario Overview

Contoso University is a fictional university management system originally built with .NET Framework 4.8. The application includes features such as:

- Student enrollment
- Course management
- Instructor assignments

The legacy system relies on Windows-based components:

- **SQL Server LocalDB** for database storage
- **Local file system** for file management
- **Microsoft Message Queue (MSMQ)** for notification messaging

## Modernization with Azure

Using App Modernization for .NET (Preview), you can update the sample to use modern, cloud-native Azure services:

- **Azure SQL Database** replaces SQL Server LocalDB
- **Azure Blob Storage** replaces local file system access
- **Azure Service Bus** replaces MSMQ
- **Azure Key Vault** provides secure secrets management

This migration illustrates how to transform a legacy, on-premises application into a scalable and maintainable cloud-native solution using GitHub Copilot and Azure services.

## Learn More

- [Quickstart: Assess and migrate a .NET project using GitHub Copilot App Modernization for .NET (Preview)](quickstart.md)