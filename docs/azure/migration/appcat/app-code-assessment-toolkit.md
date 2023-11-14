---
title: Azure Migrate application and code assessment for .NET
description: Learn how to assess .NET applications to evaluate their readiness to migrate to Azure.
ms.topic: conceptual
ms.date: 11/09/2023
author: codemillmatt
ms.author: masoucou
---

# Assess your .NET applications for migration to Azure

This guide describes how to use the application and code assessment for .NET to evaluate how ready your .NET applications are for moving to Azure and what changes you need to make for a successful cloud migration.

## What is the application and code assessment for .NET?

The utility is used to assess .NET source code to identify replatforming and migration opportunities to Azure. It helps you modernize and replatform large-scale .NET applications through a broad range of transformations, use cases, and code patterns.

It discovers application technology usage through static code analysis, supports effort estimation, and accelerates code replatforming, helping you move .NET applications to Azure.

Application and code assessment for .NET bundles a set of tools, engines, and rules to assess and replatform .NET applications to Azure App Service and in the future other Azure targets (such as Azure Kubernetes Service, Azure Container Apps, etc.) can be added.

### When should I use the application and code assessment?

The utility is designed to help organizations modernize their .NET applications in a way that reduces costs and enables faster innovation. It uses advanced analysis techniques to understand the structure and dependencies of any .NET application, and provides guidance on how to refactor and migrate the applications to Azure.

With it you can:

- **Discover technology usage:** Quickly see which technologies an application uses. Discovery is useful if you have legacy applications with not much documentation and want to know which technologies they use.
- **Assess the code to a specific target:** Assess an application for a specific Azure target. Check the effort and the modifications you have to do in order to replatform your applications to Azure.

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

- Azure App Service

More services may be added in the future.

## Next steps

### Install the Visual Studio extension or the CLI tool

For information on how to install the Azure Migrate application and code assessment for .NET extension for Visual Studio or CLi tool, see [installation instructions](./install.md).


For information on how to use and interpret results, see [Use the application and code assessment with Visual Studio](visual-studio.md).
