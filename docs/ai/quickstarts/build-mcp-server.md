---
title: Quickstart - Create a minimal MCP server and publish to NuGet
description: Learn to create and connect to a minimal MCP server using C# and publish it to NuGet.
ms.date: 07/02/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Create a minimal MCP server using C# and publish to NuGet

In this quickstart, you create a minimal Model Context Protocol (MCP) server using the [C# SDK for MCP](https://github.com/modelcontextprotocol/csharp-sdk), connect to it using GitHub Copilot, and publish it to NuGet. MCP servers are services that expose capabilities to clients through the Model Context Protocol (MCP).

> [!NOTE]
> The `Microsoft.Extensions.AI.Templates` experience is currently in preview. The template uses the [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol/) library and the [MCP registry `server.json` schema](https://github.com/modelcontextprotocol/registry/blob/main/docs/server-json/README.md), which are both in preview.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet) (preview 6 or higher)
- [Visual Studio Code](https://code.visualstudio.com/)
- [GitHub Copilot extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) for Visual Studio Code
- [NuGet.org account](https://www.nuget.org/users/account/LogOn)

## Create the project

1. In a terminal window, install the MCP Server template:

   ```bash
   dotnet new install Microsoft.Extensions.AI.Templates::9.6.0-TBD
   ```

1. Create a new MCP server app with the `dotnet new mcpserver` command:

   ```bash
   dotnet new mcpserver -n SampleMcpServer
   ```

1. Navigate to the `SampleMcpServer` directory:

   ```bash
   cd SampleMcpServer
   ```

1. Build the project:

   ```bash
   dotnet build
   ```

1. Update the `<PackageId>` in the `.csproj` file to be unique on NuGet.org, for example `<NuGet.org username>.SampleMcpServer`.

## Configure the MCP server in Visual Studio Code

Configure GitHub Copilot for Visual Studio Code to use your custom MCP server:

1. If you haven't already, open your project folder in Visual Studio Code.
1. Create a `.vscode` folder at the root of your project.
1. Add an `mcp.json` file in the `.vscode` folder with the following content:

   ```json
   {
     "servers": {
       "SampleMcpServer": {
         "type": "stdio",
         "command": "dotnet",
         "args": [
           "run",
           "--project",
           "<RELATIVE PATH TO PROJECT DIRECTORY>"
         ]
       }
     }
   }
   ```

1. Save the file.

## Test the MCP server

The MCP server template includes a tool called `get_random_number` you can use for testing and as a starting point for development.

1. Open GitHub Copilot in Visual Studio Code and switch to chat mode.

1. Select the **Select tools** icon to verify your **SampleMcpServer** is available with the sample tool listed.

    :::image type="content" source="../media/mcp/available-tools-nuget.png" alt-text="A screenshot showing the available MCP tools.":::

1. Enter a prompt to run the **get_random_number** tool:

    ```console
    Give me a random number between 1 and 100.
    ```

1. GitHub Copilot requests permission to run the **get_random_number** tool for your prompt. Select **Continue** or use the arrow to select a more specific behavior:

    - **Current session** always runs the operation in the current GitHub Copilot Agent Mode session.
    - **Current workspace** always runs the command for the current Visual Studio Code workspace.
    - **Always allow** sets the operation to always run for any GitHub Copilot Agent Mode session or any Visual Studio Code workspace.

1. Verify that the server responds with a random number:

    ```output
    Your random number is 42.
    ```

## Add inputs and configuration options

In this example, you enhance the MCP server to use a configuration value set in an environment variable. This could be configuration needed for the functioning of your MCP server, such as an API key, an endpoint to connect to, or a local directory path.

1. Add another tool method after the `GetRandomNumber` method in `Tools/RandomNumberTools.cs`. Update the tool code to use an environment variable.

   :::code language="csharp" source="snippets/mcp-server/Tools/RandomNumberTools.cs" range="19-36":::

1. Update the `.vscode/mcp.json` to set the `WEATHER_CHOICES` environment variable for testing.

   ```json
   {
      "servers": {
        "SampleMcpServer": {
          "type": "stdio",
          "command": "dotnet",
          "args": [
            "run",
            "--project",
            "<RELATIVE PATH TO PROJECT DIRECTORY>"
          ],
          "env": {
             "WEATHER_CHOICES": "sunny,humid,freezing"
          }
        }
      }
    }
    ```

1. Try another prompt with Copilot in VS Code, such as:

    ```console
    What is the weather in Redmond, Washington?
    ```

    VS Code should return a random weather description.

1. Update the `.mcp/server.json` to declare your environment variable input. The `server.json` file schema is defined by the [MCP Registry project](https://github.com/modelcontextprotocol/registry/blob/main/docs/server-json/README.md) and is used by NuGet.org to generate VS Code MCP configuration.

   * Use the `environment_variables` property to declare environment variables used by your app that will be set by the client using the MCP server (for example, VS Code).

   * Use the `package_arguments` property to define CLI arguments that will be passed to your app. For more examples, see the [MCP Registry project](https://github.com/modelcontextprotocol/registry/blob/main/docs/server-json/examples.md).

   ```json
   {
     "description": "<your description here>",
     "name": "io.github.<your GitHub username here>/<your repo name>",
     "packages": [
       {
         "registry_name": "nuget",
         "name": "<your package ID here, defined by PackageId in the .csproj>",
         "version": "<your package version here, defined by PackageVersion in the .csproj>",
         "package_arguments": [],
         "environment_variables": [
           {
             "name": "WEATHER_CHOICES",
             "description": "Comma separated list of weather descriptions to randomly select.",
             "is_required": true,
             "is_secret": false
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

   The only information used by NuGet.org in the `server.json` is the first `packages` array item with the `registry_name` value matching `nuget`. The other top-level properties aside from the `packages` property are currently unused and are intended for the upcoming central MCP Registry. You can leave the placeholder values until the MCP Registry is live and ready to accept MCP server entries.

You can [test your MCP server again](#test-the-mcp-server) before moving forward.

## Pack and publish to NuGet

1. Pack the project:

    ```bash
    dotnet pack -c Release
    ```

1. Publish the package to NuGet:

    ```bash
    dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json
    ```

    If you want to test the publishing flow before publishing to NuGet.org, you can register an account on the NuGet Gallery integration environment: [https://int.nugettest.org](https://int.nugettest.org). The `push` command would be modified to:

    ```bash
    dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://apiint.nugettest.org/v3/index.json
    ```

For more information, see [Publish a package](/nuget/nuget-org/publish-a-package).

## Discover MCP servers on NuGet.org

1. Search for your MCP server package on [NuGet.org](https://www.nuget.org/packages?packagetype=mcpserver) (or [int.nugettest.org](https://int.nugettest.org/packages?packagetype=mcpserver) if you published to the integration environment) and select it from the list.

1. View the package details and copy the JSON from the "MCP Server" tab.

1. In your `mcp.json` file in the `.vscode` folder, add the copied JSON, which looks like this:

   ```json
   {
     "inputs": [
       {
         "type": "promptString",
         "id": "weather-choices",
         "description": "Comma separated list of weather descriptions to randomly select.",
         "password": false
       }
     ],
     "servers": {
       "Contoso.SampleMcpServer": {
         "type": "stdio",
         "command": "dnx",
         "args": [
           "Contoso.SampleMcpServer",
           "--version",
           "0.0.1-beta",
           "--yes"
         ],
         "env": {
           "WEATHER_CHOICES": "${input:weather-choices}"
         }
       }
     }
   }
   ```

   If you published to the NuGet Gallery integration environment, you need to add `"--add-source", "https://apiint.nugettest.org/v3/index.json"` at the end of the `"args"` array.

1. Save the file.

1. In GitHub Copilot, select the **Select tools** icon to verify your **SampleMcpServer** is available with the tools listed.

1. Enter a prompt to run the new **get_city_weather** tool:

    ```console
    What is the weather in Redmond?
    ```

1. If you added inputs to your MCP server (for example, `WEATHER_CHOICES`), you will be prompted to provide values.

1. Verify that the server responds with the random weather:

    ```output
    The weather in Redmond is balmy.
    ```

## Common issues

### The command "dnx" needed to run SampleMcpServer was not found.

If VS Code shows this error when starting the MCP server, you need to install a compatible version of the .NET SDK.

:::image type="content" source="../media/mcp/missing-dnx.png" alt-text="A screenshot showing the missing dnx command in VS Code.":::

The `dnx` command is shipped as part of the .NET SDK, starting with version 10 preview 6. [Install the .NET 10 SDK](https://dotnet.microsoft.com/download/dotnet) to resolve this issue.

## Related content

- [Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
- [Model Context Protocol .NET samples](https://github.com/microsoft/mcp-dotnet-samples)
- [Build a minimal MCP client](build-mcp-client.md)
- [Publish a package](/nuget/nuget-org/publish-a-package)
- [Find and evaluate NuGet packages for your project](/nuget/consume-packages/finding-and-choosing-packages)
- [What's new in .NET 10](../../core/whats-new/dotnet-10/overview.md)
