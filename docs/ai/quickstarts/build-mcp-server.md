---
title: Quickstart - Create a minimal MCP Server using .NET
description: Learn to create and connect to a minimal MCP server using .NET
ms.date: 05/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Create and connect to a minimal MCP server using .NET

In this quickstart, you create a minimal Model Context Protocol (MCP) server using the [C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk) and connect to it using GitHub Copilot. MCP servers are services that expose capabilities to clients through the Model Context Protocol (MCP).

## Prerequisites

- [.NET 8.0 SDK or higher](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) for Visual Studio Code

## Create the project

1. In a terminal window, navigate to the directory where you want to create your app, and create a new console app with the `dotnet new` command:

   ```bash
   dotnet new console -n MinimalMcpServer
   ```

1. Navigate to the `MinimalMcpServer` directory:

   ```bash
   cd MinimalMcpServer
   ```

1. Add the following NuGet packages to your app:

   ```bash
   dotnet add package ModelContextProtocol --prerelease
   dotnet add package Microsoft.Extensions.Hosting
   ```

    - The [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol) package is the official C# SDK for working with the Model Context Protocol.
    - The [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package provides the generic .NET `HostBuilder` and services for logging and dependency injection.

## Add the app code

Replace the contents of `Program.cs` with the following code to implement a minimal MCP server that exposes simple echo tools. The AI model invokes these tools as necessary to generate responses to user prompts.

:::code language="csharp" source="snippets/mcp-server/program.cs" :::

The preceding code:

- Creates a generic host builder for dependency injection, logging, and configuration.
- Configures logging for better integration with MCP clients.
- Registers the MCP server, configures it to use stdio transport, and scans the assembly for tool definitions.
- Builds and runs the host, which starts the MCP server.
- Defines a static class to hold two MCP tools that echo values back to the client.

## Configure the MCP server in Visual Studio Code

Configure GitHub Copilot for Visual Studio Code to use your custom MCP server:

1. If you haven't already, open your project folder in Visual Studio Code.
1. Create a `.vscode` folder at the root of your project.
1. Add an `mcp.json` file in the `.vscode` folder with the following content:

   ```json
   {
     "inputs": [],
     "servers": {
       "MinimalMcpServer": {
         "type": "stdio",
         "command": "dotnet",
         "args": [
           "run",
           "--project",
           "${workspaceFolder}/MinimalMcpServer.csproj"
         ]
       }
     }
   }
   ```

1. Save the file.

## Test the MCP server

1. Open GitHub Copilot in Visual Studio Code and switch to agent mode.
1. Select the **Select tools** icon to verify your **MinimalMcpServer** is available with both tools listed.

    :::image type="content" source="../media/mcp/available-tools.png" alt-text="A screenshot showing the available MCP tools.":::

1. Enter a prompt to run the **ReverseEcho** tool:

    ```console
    Reverse the following: "Hello, minimal MCP server!"
    ```

1. GitHub Copilot requests permission to run the **ReverseEcho** tool for your prompt. Select **Continue** or use the arrow to select a more specific behavior:

    - **Current session** always runs the operation in the current GitHub Copilot Agent Mode session.
    - **Current workspace** always runs the command for the current Visual Studio Code workspace.
    - **Always allow** sets the operation to always run for any GitHub Copilot Agent Mode session or any Visual Studio Code workspace.

1. Verify that the server responds with the echoed message:

    ```output
    !revres PCM laminim ,olleH
    ```

## Related content

[Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
