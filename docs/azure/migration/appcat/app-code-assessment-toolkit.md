---
title: Application and Code Assessment Toolkit for .NET
description: Learn how to assess .NET applications with AppCAT to evaluate their readiness to migrate to Azure.
ms.topic: conceptual
ms.date: 10/16/2023
author: codemillmatt
ms.author: masoucou
---

# Assess your .NET applications for migration to Azure with AppCAT for .NET

This guide describes how to assess .NET applications with the AppCAT (Application and Code Assessment Toolkit) for .NET to evaluate their readiness to migrate to Azure.

## What is AppCAT for .NET?

The AppCAT for .NET is a tool to assess .NET source code to identify replatforming and migration opportunities to Azure. It helps you modernize and replatform large-scale .NET applications through a broad range of transformations, use cases, and code patterns.

AppCAT discovers application technology usage through static code analysis, supports effort estimation, and accelerates code replatforming, helping you move .NET applications to Azure.

AppCAT bundles a set of tools, engines, and rules to assess and replatform .NET applications to Azure App Service and in the future other Azure targets (such as Azure Kubernetes Service, Azure Container Apps, etc.) can be added.

### When should I use AppCAT for .NET?

AppCAT for .NET is designed to help organizations modernize their .NET applications in a way that reduces costs and enables faster innovation. The tool uses advanced analysis techniques to understand the structure and dependencies of any .NET application, and provides guidance on how to refactor and migrate the applications to Azure.

With AppCAT for .NET you can:

- **Discover technology usage:** Quickly see which technologies an application uses. Discovery is useful if you have legacy applications with not much documentation and want to know which technologies they use.
- **Assess the code to a specific target:** Assess an application for a specific Azure target. Check the effort and the modifications you have to do in order to replatform your applications to Azure.

### Supported languages

The toolkit can analyze projects written in the following languages:

- C#
- Visual Basic

### Supported project types

The toolkit analyzes your code in the following project types:

- ASP.NET
- Class libraries

### Supported Azure targets

The toolkit contains rules for helping you migrate your applications so you can deploy to and use the following Azure services.

- Azure App Service

More services may be added in the future.

## Next steps

### Install the Visual Studio extension

For information on how to install the AppCAT for .NET extension for Visual Studio, see [AppCAT for .NET installation](./install.md).

### Use AppCAT for .NET with Visual Studio

For information on how to use and interpret results, see [Use AppCAT for .NET with Visual Studio](visual-studio.md).
