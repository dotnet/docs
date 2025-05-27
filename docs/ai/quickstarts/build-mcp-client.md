---
title: Quickstart - Create a minimal MCP client using .NET
description: Learn to create a minimal MCP client and connect it to an MCP server using .NET
ms.date: 05/27/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
---

# Create a minimal MCP client using .NET

In this quickstart, you build a minimal [Model Context Protocol (MCP)](../get-started-mcp.md) client using the [C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk). You also learn how to configure the client to connect to an MCP server, such as the one created in the [Build a minimal MCP server](build-mcp-server.md) quickstart.

## Prerequisites

- [.NET 8.0 SDK or higher](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)

> [!NOTE]
> The MCP client you build in the sections ahead connects to the sample MCP server from the [Build a minimal MCP server](build-mcp-server.md) quickstart. You can also use your own MCP server if you provide your own connection configuration.

## Create the .NET host app

Complete the following steps to create a .NET console app. The app acts as a host for an MCP client that connects to an MCP Server.

### Create the project

1. In a terminal window, navigate to the directory where you want to create your app, and create a new console app with the `dotnet new` command:

   ```console
   dotnet new console -n MCPHostApp
   ```

1. Navigate into the newly created project folder:

   ```console
   cd MCPHostApp
   ```

1. Run the following commands to add the necessary NuGet packages:

   ```console
   dotnet add package Azure.AI.OpenAI --prerelease
   dotnet add package Azure.Identity
   dotnet add package Microsoft.Extensions.AI --prerelease
   dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
   dotnet add package ModelContextProtocol --prerelease
   ```

1. Open the project folder in your editor of choice, such as Visual Studio Code:

    ```console
    code .
    ```

### Add the app code

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="snippets/mcp-client/program.cs" :::

The preceding code accomplishes the following tasks:

- Initializes an `IChatClient` abstraction using the [`Microsoft.Extensions.AI`](/dotnet/ai/microsoft-extensions-ai) libraries.
- Creates an MCP client and configures it to connect to your MCP server
- Retrieves and displays a list of available tools from the MCP server, which is a standard MCP function.
- Implements a conversational loop that processes user prompts and utilizes the tools for responses.

## Run and test the app

Complete the following steps to test your .NET host app:

1. In a terminal window open to the root of your project, run the following command to start the app:

   ```console
   dotnet run
   ```

1. Once the app is running, enter a prompt to run the **ReverseEcho** tool:

    ```console
    Reverse the following: "Hello, minimal MCP server!"
    ```

1. Verify that the server responds with the echoed message:

    ```output
    !revres PCM laminim ,olleH
    ```

## Related content

[Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
