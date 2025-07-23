# MCP Server

This README was created using the C# MCP server template project. It demonstrates how you can easily create an MCP server using C# and then package it in a NuGet package.

See [aka.ms/nuget/mcp/guide](https://aka.ms/nuget/mcp/guide) for the full guide.

## Checklist before publishing to NuGet.org

- Test the MCP server locally using the steps below.
- Update the package metadata in the .csproj file, in particular the `<PackageId>`.
- Update `.mcp/server.json` to declare your MCP server's inputs.
  - See [configuring inputs](https://aka.ms/nuget/mcp/guide/configuring-inputs) for more details.
- Pack the project using `dotnet pack`.

The `bin/Release` directory will contain the package file (.nupkg), which can be [published to NuGet.org](https://learn.microsoft.com/nuget/nuget-org/publish-a-package).

## Using the MCP Server in VS Code

Once the MCP server package is published to NuGet.org, you can use the following VS Code user configuration to download and install the MCP server package. See [Use MCP servers in VS Code (Preview)](https://code.visualstudio.com/docs/copilot/chat/mcp-servers) for more information about using MCP servers in VS Code.

```json
{
  "mcp": {
    "servers": {
      "SampleMcpServer": {
        "type": "stdio",
        "command": "dnx",
        "args": [
          "SampleMcpServer",
          "--version",
          "0.1.0-beta",
          "--yes"
        ]
      }
    }
  }
}
```

Now you can ask Copilot Chat for a random number, for example, `Give me 3 random numbers`. It should prompt you to use the `get_random_number` tool on the `SampleMcpServer` MCP server and show you the results.

## Developing locally in VS Code

To test this MCP server from source code (locally) without using a built MCP server package, create a `.vscode/mcp.json` file (a VS Code workspace settings file) in your project directory and add the following configuration:

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

Alternatively, you can configure your VS Code user settings to use your local project:

```json
{
  "mcp": {
    "servers": {
      "SampleMcpServer": {
        "type": "stdio",
        "command": "dotnet",
        "args": [
          "run",
          "--project",
          "<FULL PATH TO PROJECT DIRECTORY>"
        ]
      }
    }
  }
}
```
