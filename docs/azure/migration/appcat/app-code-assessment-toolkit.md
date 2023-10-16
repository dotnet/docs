---
title: Azure Application and Code Assessment Toolkit
description: Learn how to assess .NET applications with Azure AppCAT to evaluate their readiness to migrate to Azure.
ms.topic: conceptual
ms.date: 10/16/2023
---

# Assess your .NET applications for migration to Azure with Azure AppCAT for .NET

This guide describes how to assess .NET applications with Azure AppCAT (Azure Application and Code Assessment Toolkit) to evaluate their readiness to migrate to Azure.

## What is Azure AppCAT for .NET?

Azure AppCAT is a tool to assess .NET source code to identify replatforming and migration opportunities to Azure. It helps you modernize and replatform large-scale .NET applications through a broad range of transformations, use cases, and code patterns.

Azure AppCAT discovers application technology usage through static code analysis, supports effort estimation, and accelerates code replatforming, helping you move .NET applications to Azure.

AppCAT bundles a set of tools, engines, and rules to assess and replatform .NET applications to different Azure targets (Azure App Service, Azure Kubernetes Service, Azure Container Apps, and Azure Spring Apps) with specific Azure replatforming rules.

### When should I use Azure AppCAT?

Azure AppCAT is designed to help organizations modernize their .NET applications in a way that reduces costs and enables faster innovation. The tool uses advanced analysis techniques to understand the structure and dependencies of any .NET application, and provides guidance on how to refactor and migrate the applications to Azure.

With Azure AppCAT you can:

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
