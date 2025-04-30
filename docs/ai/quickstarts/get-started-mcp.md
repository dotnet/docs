---
title: Get started with .NET AI and MCP
description: Learn about .NET AI and MCP key concepts and development resources
ms.date: 04/29/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Get started with .NET AI and the Model Context Protocol

The Model Context Protocol (MCP) is an open protocol designed to standardize integrations between AI apps and external tools and data sources. By using MCP, developers can enhance the capabilities of AI models, enabling them to produce more accurate, relevant, and context-aware responses.

For example, using MCP, you can connect your LLM to resources such as:

- Document databases or storage services
- Web APIs that expose business data or logic
- Tools that manage files or performing local tasks on a user's device

Many Microsoft products already support MCP, including:
- [Copilot Studio](/microsoft-copilot/blog/copilot-studio/introducing-model-context-protocol-mcp-in-copilot-studio-simplified-integration-with-ai-apps-and-agents)
- [Visual Studio Code GitHub Copilot agent mode](https://code.visualstudio.com/blogs/2025/02/24/introducing-copilot-agent-mode)
- [Semantic Kernel](https://devblogs.microsoft.com/semantic-kernel/integrating-model-context-protocol-tools-with-semantic-kernel-a-step-by-step-guide/).

You can use the [MCP C# SDK](#develop-with-mcp-c-sdk) to quickly create your own MCP integrations and switch between different AI models without significant code changes.

### MCP client-server architecture

MCP uses a client-server architecture that enables an AI-powered app (the host) to connect to multiple MCP servers through MCP clients:

- **MCP Hosts**: AI tools, code editors, or other software that enhance their AI models using contextual resources through MCP. For example, GitHub Copilot in Visual Studio Code can act as an MCP host and use MCP clients and servers to expand its capabilities.
- **MCP Clients**: Clients used by the host application to connect to MCP servers to retrieve contextual data.
- **MCP Servers**: Services that expose capabilities to clients through MCP. For example, an MCP server might provide an abstraction over a REST API or local data source to provide business data to the AI model.

The following diagram illustrates this architecture:

:::image type="content" source="../media/mcp/model-context-protocol-architecture-diagram.png" alt-text="A diagram showing the architecture pattern of MCP, including hosts, clients, and servers.":::

MCP client and server can exchange a set of standard messages:

|Message  |Description  |
|---------|---------|
|InitializeRequest     |  This request is sent by the client to the server when it first connects, asking it to begin initialization       |
|ListToolsRequest     |  Sent by the client to request a list of tools the server has       |
|CallToolRequest     |  Used by the client to invoke a tool provided by the server       |
|ListResourcesRequest     | Sent by the client to request a list of resources the server has        |
|ReadResourceRequest     |  Sent by the client to the server, to read a specific resource URI       |
|ListPromptsRequest     | Sent by the client to request a list of prompts and prompt templates the server has       |
|GetPromptRequest     |  Used by the client to get a prompt provided by the server       |
|PingRequest     |   A ping, issued by either the server or the client, to check that the other party is still alive      |
|CreateMessageRequest     |  A request by the server to sample an LLM via the client. The client has full discretion over which model to select. The client should also inform the user before beginning sampling, to allow them to inspect the request (human in the loop) and decide whether to approve it       |
|SetLevelRequest     | A request by the client to the server, to enable or adjust logging        |

## Develop with the MCP C# SDK

As a .NET developer, you can use MCP by creating MCP clients and servers to enhance your apps with custom integrations. MCP reduces the complexity involved in connecting an AI model to various tools, services, and data sources.

The official [MCP C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) is available through NuGet and enables you to build MCP clients and servers for .NET apps and libraries. The SDK is maintained through collaboration between Microsoft, Anthropic, and the MCP open protocol organization.

To get started, add the MCP C# SDK to your project:

```dotnetcli
dotnet add package ModelContextProtocol --prerelease
```

Instead of building unique connectors for each integration point, you can often leverage or reference prebuilt integrations from various providers such as GitHub and Docker:

- [Available MPC clients](https://modelcontextprotocol.io/clients)
- [Available MCP servers](https://modelcontextprotocol.io/examples)

## More .NET MCP development resources

Various tools, services, and learning resources are available in the .NET and Azure ecosystems to help you build MCP clients and servers or integrate with existing MCP servers.

Get started with the following development tools:

- [Semantic Kernel](/semantic-kernel/concepts/plugins/adding-mcp-plugins) allows you to add plugins for MCP servers. Semantic Kernel supports both local MCP servers through standard I/O and remote servers that connect through SSE over HTTPS.
- [Azure Functions remote MCP servers](https://devblogs.microsoft.com/dotnet/build-mcp-remote-servers-with-azure-functions/) combine MCP standards with the flexible architecture of Azure Functions. Visit the [Remote MCP functions sample repository](https://aka.ms/cadotnet/mcp/functions/remote-sample) for code examples.
- [Azure MCP Server](https://github.com/Azure/azure-mcp) implements the MCP specification to seamlessly connect AI agents with key Azure services like Azure Storage, Cosmos DB, and more.

Learn more about .NET and MCP using these resources:

- [Microsoft partners with Anthropic to create official C# SDK for Model Context Protocol](https://devblogs.microsoft.com/blog/microsoft-partners-with-anthropic-to-create-official-c-sdk-for-model-context-protocol)
- [Build a Model Context Protocol (MCP) server in C#](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)
- [MCP C# SDK README](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/README.md)

## Next steps

The Model Context Protocol simplifies integrating large language models with external tools, services, and data sources, enabling you to build powerful, context-aware AI applications. To continue your learning journey, explore the provided resources and start building your own MCP-enabled .NET applications today.
