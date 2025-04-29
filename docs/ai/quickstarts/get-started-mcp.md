---
title: Get started with .NET AI and MCP
description: Learn about resources and starter examples for .NET AI and MCP
ms.date: 04/29/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Get started with .NET AI and the Model Context Protocol

The Model Context Protocol (MCP) is an open protocol that defines standards around how applications provide context to LLMs. In this article, you learn:

- Core concepts about MCP
- Resources to get started working with .NET AI and MCP
- How to create simple client and server apps that use MCP

## MCP overview

Large Language Models (LLMs) often need to integrate with additional services and tools to optimize their behavior. MCP enables you to connect AI models to various tools, data sources, and services in a consistent, standardized way. These integrations can improve the quality and relevance of your LLM responses by expanding the resources available to it. For example, using MCP you could connect your LLM to the following resources:

- A document database that contains thousands of PDFs
- Web APIs that surface business data or logic
- Tools to manage files or perform local tasks on a user's device

Due to the standardized nature of MCP, you can switch between different LLMs and still leverage the same set of tools and resources.

## MCP client-server architecture

MCP is designed around a client-server architecture. This allows a host application to connect to multiple MCP servers using an MCP client to improve the contextual awareness of an AI model. MCP architecture generally includes the following key components:

**MCP Hosts**: AI tools, IDEs, or other software that need to enhance their AI Models using contextual resources through MCP. For example, GitHub Copilot in Visual Studio code can act as an MCP host and use MCP clients and servers to expand its capabilities.
**MCP Clients**: Clients that connect to MCP servers to retrieve contextual data.
**MCP Servers**: Services that expose various capabilities through MCP. For example, an MCP server might provide an abstraction over a REST API or local data source to provide business data in a standardized way to the LLM.

The following diagram illustrates this architecture:

## MCP C# SDK and development resources

As a .NET developer, you generally work with MCP by programming MCP client and server behaviors and integrations. MCP reduces the effort and complexity involved with connecting an AI model to various tools, services, and data sources. Instead of building unique connectors for every integration point, you can rely on a combination of prebuilt integrations from various providers, and clear standards to build your own reusable connectors.

The official [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) is available through NuGet and enables you to build MCP clients and servers for .NET apps and libraries. The SDK is maintained through a collaboration between Microsoft and the MCP open protocol organization.

To get started, add the MCP C# SDK to your project:

```csharp
dotnet add package ModelContextProtocol --prerelease
```
