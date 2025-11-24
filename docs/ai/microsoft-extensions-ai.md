---
title: Microsoft.Extensions.AI libraries
description: Learn about experimental and preview AI features in .NET using Microsoft.Extensions.AI.
author: IEvangelist
ms.author: dapine
ms.topic: overview
ms.date: 11/24/2025
ms.service: dotnet
ms.subservice: intelligent-apps
---

# Microsoft.Extensions.AI libraries

Microsoft.Extensions.AI is a set of core .NET libraries developed in collaboration with developers across the .NET ecosystem, including Semantic Kernel. These libraries provide a unified layer of C# abstractions for interacting with AI services, such as language models, embeddings, and middleware.

This article introduces the libraries and provides guidance on both existing and experimental functionality.

## Overview

The Microsoft.Extensions.AI libraries enable:

- Consistent APIs for AI services
- Cross-provider compatibility
- Middleware pipelines for telemetry, caching, tooling, etc.
- Familiar .NET dependency injection patterns

## Installation

Install the main packages from NuGet:

```bash
dotnet add package Microsoft.Extensions.AI
dotnet add package Microsoft.Extensions.AI.Abstractions
// TODO: Add Chat Reduction example
// TODO: Add Tool Reduction example
// TODO: Add Image Generation example
// TODO: Add Data Ingestion example
