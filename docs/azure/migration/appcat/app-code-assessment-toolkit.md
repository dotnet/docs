---
title: Azure Migrate application and code assessment for .NET
description: Learn how to assess .NET applications to evaluate their readiness to migrate to Azure.
ms.topic: concept-article
ms.date: 11/09/2023
author: codemillmatt
ms.author: masoucou
---

# Assess your .NET applications for migration to Azure

This guide describes how to use the application and code assessment for .NET to evaluate how ready your .NET applications are for moving to Azure and what changes you need to make for a successful cloud migration.

## What is the application and code assessment for .NET?

The utility is used to assess .NET source code to identify replatforming and migration opportunities to Azure.

It discovers application technology usage through static code analysis, supports effort estimation, and accelerates code replatforming by giving you recommendations on how to overcome any potential issues and make your code cloud-compatible.

Application and code assessment is available in a Visual Studio extension and in a CLI tool.

Application and code assessment for .NET bundles a set of tools, engines, and rules to assess and replatform .NET applications to various Azure targets such as Azure App Service, Azure Kubernetes Service and Azure Container Apps.

### When should I use the application and code assessment?

The utility is designed to help organizations modernize their .NET applications in a way that reduces costs and enables faster innovation. It uses advanced analysis techniques to understand the structure and dependencies of any .NET application, and provides guidance on how to refactor and migrate the applications to Azure.

With it you can:

- **Assess the code compatibility with Azure:** get notified about every part of your code that might not work when you move your application to Azure.

- **Get recommendations on refactoring your code:** receive guidance and effort estimates on how to update your code to make it Azure-compatible, what verifications you should make to ensure your applications will work properly, and how to improve your applications performance, scalability, security, etc.

### Supported languages

Application and code assessment for .NET can analyze projects written in the following languages:

- C#
- Visual Basic

### Supported project types

It analyzes your code in the following project types:

- ASP.NET
- Class libraries

### Supported Azure targets

Currently application identifies potential issues for migration to Azure App Service, AKS, and Azure Container Apps. In the future the tool might have an ability to set the target explicitly and filter the exact issues and recommendations for each target separately.

## Next steps

### Install the Visual Studio extension or the CLI tool

For information on how to install the Azure Migrate application and code assessment for .NET extension for Visual Studio or CLi tool, see [installation instructions](./install.md).
