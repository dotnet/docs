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

The Model Context Protocol (MCP) is an open protocol created by Anthropic that standardizes how applications provide context to large language models (LLMs). In this article, you'll learn:

- Core concepts of MCP.
- Resources to help you get started with .NET AI and MCP.
- How to create simple client and server applications using MCP.

## What is MCP?

The Model Context Protocol simplifies the integration of large language models with external tools, services, and data sources. The protocol enables you to build powerful, standardized, context-aware AI applications. These integrations improve the quality and relevance of your LLM responses by expanding the resources available to them.

For example, using MCP, you can connect your LLM to resources such as:

- Document databases or storage services containing thousands of PDFs.
- Web APIs that expose business data or logic.
- Tools for managing files or performing local tasks on a user's device.

Many Microsoft products have already added support for MCP, including [Copilot Studio](/microsoft-copilot/blog/copilot-studio/introducing-model-context-protocol-mcp-in-copilot-studio-simplified-integration-with-ai-apps-and-agents), [Visual Studio Code GitHub Copilot agent mode](https://code.visualstudio.com/blogs/2025/02/24/introducing-copilot-agent-mode), and [Semantic Kernel](https://devblogs.microsoft.com/semantic-kernel/integrating-model-context-protocol-tools-with-semantic-kernel-a-step-by-step-guide/). By leveraging the [MCP C# SDK](), you can also quickly create your own robust MCP integrations and easily switch between different AI models without significant code changes.

### MCP client-server architecture

MCP uses a client-server architecture, enabling a host application to connect to multiple MCP servers through MCP clients. This architecture enhances the contextual awareness of AI models. MCP architecture includes the following key components:

- **MCP Hosts**: AI tools, IDEs, or other software that enhance their AI models using contextual resources through MCP. For example, GitHub Copilot in Visual Studio Code can act as an MCP host, using MCP clients and servers to expand its capabilities.
- **MCP Clients**: Clients used by the host application to connect to MCP servers to retrieve contextual data.
- **MCP Servers**: Services that expose capabilities through MCP. For example, an MCP server might abstract a REST API or local data source to provide business data to the LLM.

The following diagram illustrates this architecture:

:::image type="content" source="../media/mcp/model-context-protocol-architecture-diagram.png" alt-text="A diagram showing the architecture pattern of MCP, including hosts, clients, and servers.":::

There are a set of standard messages that the MCP client and server can exchange, including:

|Message  |Description  |
|---------|---------|
|InitializeRequest     |  This request is sent from the client to the server when it first connects, asking it to begin initialization       |
|ListToolsRequest     |  Sent from the client to request a list of tools the server has       |
|CallToolRequest     |  Used by the client to invoke a tool provided by the server       |
|ListResourcesRequest     | Sent from the client to request a list of resources the server has        |
|ReadResourceRequest     |  Sent from the client to the server, to read a specific resource URI       |
|ListPromptsRequest     | Sent from the client to request a list of prompts and prompt templates the server has       |
|GetPromptRequest     |  Used by the client to get a prompt provided by the server       |
|PingRequest     |   A ping, issued by either the server or the client, to check that the other party is still alive      |
|CreateMessageRequest     |  A request from the server to sample an LLM via the client. The client has full discretion over which model to select. The client should also inform the user before beginning sampling, to allow them to inspect the request (human in the loop) and decide whether to approve it       |
|SetLevelRequest     | A request from the client to the server, to enable or adjust logging        |

## Develop with MCP C# SDK

As a .NET developer, you can use MCP by programming MCP client and server behaviors and integrations. MCP reduces the complexity involved in connecting an AI model to various tools, services, and data sources. Instead of building unique connectors for each integration point, you can rely on prebuilt integrations from various providers and clear standards to build your own reusable connectors.

The official [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) is available through NuGet and enables you to build MCP clients and servers for .NET apps and libraries. The SDK is maintained through collaboration between Microsoft, Anthropic, and the MCP open protocol organization.

To get started, add the MCP C# SDK to your project:

```dotnetcli
dotnet add package ModelContextProtocol --prerelease
```

## Additional .NET MCP development resources

Various tools and services in the .NET and Azure ecosystems are available to help you build MCP clients and servers or integrate with existing MCP servers. Explore the following resources for more information:

- [Semantic Kernel](/semantic-kernel/concepts/plugins/adding-mcp-plugins) allows you to add plugins for MCP servers. Semantic Kernel supports both local MCP servers through standard I/O and remote servers that connect through SSE over HTTPS.
- [Azure Functions remote MCP servers](https://devblogs.microsoft.com/dotnet/build-mcp-remote-servers-with-azure-functions/) combine MCP standards with the flexible architecture of Azure Functions. Visit the [Remote MCP functions sample repository](https://aka.ms/cadotnet/mcp/functions/remote-sample) for code examples.
- [Azure MCP Server](https://github.com/Azure/azure-mcp) implements the MCP specification to seamlessly connect AI agents with key Azure services like Azure Storage, Cosmos DB, and more.

## Next steps

The Model Context Protocol simplifies integrating large language models with external tools, services, and data sources, enabling you to build powerful, context-aware AI applications. To continue your learning journey, explore the provided resources and start building your own MCP-enabled .NET applications today.
