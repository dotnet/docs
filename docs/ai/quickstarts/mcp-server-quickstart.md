---
title: Quickstart - Create a minimal MCP Server using .NET
description: Learn to create and connect to a minimal MCP server using .NET
ms.date: 05/21/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
zone_pivot_groups: openai-library
---

# Create and connect to a minimal MCP server using .NET

MCP servers are services that expose capabilities to clients through the Model Context Protocol (MCP). In this quickstart, you create a minimal Model Context Protocol (MCP) server using the [C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk) and connect to it using GitHub Copilot.

## Prerequisites

- [.NET 9.0](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) for Visual Studio Code

## Create the project

1. Open a terminal and run the following command to create a new console app:

   ```bash
   dotnet new console -n MinimalMcpServer
   ```

1. Change to the project directory:

   ```bash
   cd MinimalMcpServer
   ```

1. Add the following NuGet packages:

   ```bash
   dotnet add package ModelContextProtocol --prerelease
   dotnet add package Microsoft.Extensions.Hosting
   ```

    - The [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol) package is the official C# SDK for working with the Model Context Protocol.
    - The [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) package provides the generic .NET `HostBuilder` and services for logging and dependency injection.

## Add the app code

Replace the contents of `Program.cs` with the following code to implement a minimal MCP server that exposes a simple echo tool:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Log to stderr for better integration with MCP clients
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();

[McpServerToolType]
public static class EchoTool
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"Hello from C#: {message}";

    [McpServerTool, Description("Echoes in reverse the message sent by the client.")]
    public static string ReverseEcho(string message) => new string(message.Reverse().ToArray());
}
```

## Configure the MCP server in Visual Studio Code

1. Open your project folder in Visual Studio Code.
1. Create a `.vscode` folder if it doesn't exist.
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
1. Select the **Select tools...** icon to verify your **MinimalMcpServer** is available with both tools listed.

    :::image type="content" source="../media/mcp/available-tools.png" alt-text="A screenshot showing the available MCP tools.":::

1. Enter a prompt to run the **ReverseEcho** tool, such as *Reverse the following: "Hello, minimal MCP server!"*
1. GitHub Copilot prompts you for a confirmation to run the selected **ReverseEcho** tool. Select **Continue**.
1. Verify that the server responds with the echoed message:

```output
!revres PCM laminim ,olleH
```

## Related content

[Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
