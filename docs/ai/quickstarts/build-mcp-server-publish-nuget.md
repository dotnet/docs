---
title: Quickstart - Create a minimal MCP Server using .NET and publish to NuGet
description: Learn to create and connect to a minimal MCP server using .NET and publish it to NuGet.
ms.date: 06/30/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: jondouglas
ms.author: jondouglas
---

# Create, connect, and publish a minimal MCP server to NuGet

In this quickstart, you create a minimal Model Context Protocol (MCP) server using the [C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk), connect to it using GitHub Copilot, and publish it to NuGet. MCP servers are services that expose capabilities to clients through the Model Context Protocol (MCP).

## Prerequisites

- [.NET 10.0 SDK or higher](https://dotnet.microsoft.com/download/dotnet) (preview 6 or newer)
- [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) for Visual Studio Code
- [NuGet.org account](https://www.nuget.org/users/account/LogOn)

## Create the project

1. In a terminal window, install the `dotnet new mcpserver` template:

   ```bash
   dotnet new install Microsoft.Extensions.AI.Templates::9.6.0-preview.2.25310.2
   ```

1. Create a new MCP server app with the `dotnet new mcpserver` command:

   ```bash
   dotnet new mcpserver -n MinimalMcpServer
   ```

1. Navigate to the `MinimalMcpServer` directory:

   ```bash
   cd MinimalMcpServer
   ```

1. Build the project:

   ```bash
   dotnet build
   ```

## Configure the MCP server in Visual Studio Code

Configure GitHub Copilot for Visual Studio Code to use your custom MCP server:

1. If you haven't already, open your project folder in Visual Studio Code.
1. Create a `.vscode` folder at the root of your project.
1. Add an `mcp.json` file in the `.vscode` folder with the following content:

   ```json
   {
     "servers": {
       "MinimalMcpServer": {
         "type": "stdio",
         "command": "dotnet",
         "args": [
           "run"
         ],
         "env": {
           "MAX_RANDOM_NUMBER": 100
         }
       }
     }
   }
   ```

1. Save the file.

## Test the MCP server

1. Open GitHub Copilot in Visual Studio Code and switch to agent mode.

1. Select the **Select tools** icon to verify your **MinimalMcpServer** is available with both tools listed.

    :::image type="content" source="../media/mcp/available-tools-nuget.png" alt-text="A screenshot showing the available MCP tools.":::

1. Enter a prompt to run the **get_random_number** tool:

    ```console
    Give me a random number between 1 and 100.
    ```

1. GitHub Copilot requests permission to run the **get_random_number** tool for your prompt. Select **Continue** or use the arrow to select a more specific behavior:

    - **Current session** always runs the operation in the current GitHub Copilot Agent Mode session.
    - **Current workspace** always runs the command for the current Visual Studio Code workspace.
    - **Always allow** sets the operation to always run for any GitHub Copilot Agent Mode session or any Visual Studio Code workspace.

1. Verify that the server responds with the echoed message:

    ```output
    Your random number is 9.
    ```

## Pack and publish to NuGet

1. Update the `<PackageId>` in the `.csproj` file to be unique on NuGet.org.

1. Update your `.mcp/server.json` file with your respective MCP configuration details.

    ```json
    {
      "description": "<your description here>",
      "name": "io.github.<your GitHub username here>/<your repo name>",
      "packages": [
        {
          "registry_name": "nuget",
          "name": "<your package ID here>",
          "version": "0.1.0-beta",
          "package_arguments": [],
          "environment_variables": [
            {
              "description": "The maximum number to return from the random number generator",
              "name": "MAX_RANDOM_NUMBER"
            }
          ]
        }
      ],
      "repository": {
        "url": "https://github.com/<your GitHub username here>/<your repo name>",
        "source": "github"
      },
      "version_detail": {
        "version": "0.1.0-beta"
      }
    }
    ```

    The `server.json` file schema is defined by the [MCP Registry project](https://github.com/modelcontextprotocol/registry) and is used by NuGet.org to generate VS Code MCP configuration.

1. Pack the project:

    ```bash
    dotnet pack -c Release
    ```

1. Publish the package to NuGet:

    ```bash
    dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json  
    ```

For more information, see [Publish a package](/nuget/nuget-org/publish-a-package).

## Discover MCP servers on NuGet.org

1. Search for your MCP Server package on [NuGet.org](https://www.nuget.org/packages?packagetype=mcpserver).

1. View the MCP Server details and copy the JSON.

1. In your `mcp.json` file in the `.vscode` folder, add the following:

   ```json
   {
     "servers": {
       "MinimalMcpServer": {
         "type": "stdio",
         "command": "dotnet",
         "args": [
           "tool",
           "exec",
           "<your-package-id>",
           "--version",
           "0.0.1-beta",
           "--yes"
         ],
         "env": {
           "MAX_RANDOM_NUMBER": 100
         }
       }
     }
   }
   ```

1. Save the file.

1. In GitHub Copilot, select the **Select tools** icon to verify your **MinimalMcpServer** is available with the tools listed.

1. Enter a prompt to run the **get_random_number** tool:

    ```console
    Give me a random number between 1 and 100.
    ```

1. Verify that the server responds with the echoed message:

    ```output
    Your random number is 9.
    ```

## Related content

- [Build a minimal MCP server](build-mcp-server.md)
- [Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
- [Use agent mode in VS Code](https://code.visualstudio.com/docs/copilot/chat/chat-agent-mode)
- [Use agent mode in Visual Studio](/visualstudio/ide/copilot-agent-mode)
- [Model Context Protocol .NET Samples](https://github.com/microsoft/mcp-dotnet-samples)
- [What's new in .NET 10](../../core/whats-new/dotnet-10/overview.md)
- [Find and evaluate NuGet packages for your project](/nuget/consume-packages/finding-and-choosing-packages)
- [Publish a package](/nuget/nuget-org/publish-a-package)
