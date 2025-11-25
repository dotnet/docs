---
title: Quickstart - Publish a .NET MCP Server to the MCP Registry
description: Learn how to publish your NuGet-based MCP Server to the Official MCP Registry, including creating a server.json manifest, updating your package README, and using the MCP Publisher tool.
ms.date: 11/17/2025
ms.topic: quickstart
author: joelverhagen
zone_pivot_groups: operating-systems-set-one
ai-usage: ai-assisted
---

# Publish an MCP Server on NuGet.org to the Official MCP Registry

In this quickstart, you publish your NuGet-based local MCP Server to the [Official MCP Registry](https://github.com/modelcontextprotocol/registry/blob/main/docs/explanations/ecosystem-vision.md).

> [!NOTE]
> This guide focuses on publishing **local MCP servers** packaged with NuGet that use the stdio transport. The Official MCP Registry also supports **remote MCP servers** that use HTTP transports. While the `server.json` publishing process is similar for remote servers, their configuration differs as they don't require package managers. Remote servers can be implemented in any language since implementation details are transparent to consumers. See [an Azure Functions code sample for a .NET remote MCP server](/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/).

## Prerequisites

- A [GitHub account](https://github.com/join)
- [Visual Studio Code](https://code.visualstudio.com/)
- Your MCP Server is packaged with NuGet and published to NuGet.org ([quickstart](./build-mcp-server.md)).

## Create a server.json manifest file

*If you used the NuGet MCP Server quickstart and `mcpserver` project template, you can skip this step.*

1. Navigate to your MCP server's source directory and create a new `server.json` file.
   ::: zone pivot="os-windows"

   ```powershell
   cd path\my\project

   # create and open the server.json file
   code .mcp\server.json
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   cd path/my/project

   # create and open the server.json file
   code .mcp/server.json
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   cd path/my/project

   # create and open the server.json file
   code .mcp/server.json
   ```

   ::: zone-end
2. Use this content to start with and fill in the placeholders.
   :::code language="json" source="snippets/mcp-registry/server.json":::
3. Save the file.

Use this reference to understand more about the fields:

| Property            | Example                                | Purpose                                                                                                     |
| ------------------- | -------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| name                | `io.github.contoso/data-mcp`           | Unique identifier for the MCP Server, namespaced using reverse DNS names, **case sensitive**                |
| version             | `0.1.0-beta`                           | Version of the MCP Server listing<br>Consider using the same version as the MCP Server package on NuGet.org |
| description         | `Access Contoso data in your AI agent` | Description of your MCP Server, up to 100 characters                                                        |
| title               | `Contoso Data`                         | Optional: short human-readable title, up to 100 characters                                                  |
| websiteUrl          | `https://contoso.com/docs/mcp`         | Optional: URL to the server's homepage, documentation, or project website                                   |
| packages identifier | `Contoso.Data.Mcp`                     | The ID of your MCP Server package on NuGet.org                                                              |
| packages version    | `0.1.0-beta`                           | The version of your MCP Server package on NuGet.org                                                         |
| repository url      | `https://github.com/contoso/data-mcp`  | Optional: GitHub repository URL                                                                             |

The `name` field has two parts, separated by a forward slash `/`. The first part is a namespace based off of a reverse DNS name. The authentication method you use in later steps will give you access to a specific namespace. For example, using GitHub-based authentication will give you access to `io.github.<your GitHub username>/*`.  The second part, after the forward slash, is a custom identifier for your server within the namespace. Think of this much like a NuGet package ID. It should be unchanging and descriptive of your MCP server. Using your GitHub repository name is a reasonable option if you only have one MCP Server published from that repository.

## Update your package README

The Official MCP Registry verifies that your MCP Server package references the `name` specified in your `server.json` file.

1. If you haven't already, add a README.md to your MCP Server NuGet package. See [how to do this in your project file](/nuget/reference/msbuild-targets#packagereadmefile).
2. Open the README.md used by your NuGet package.
   ::: zone pivot="os-windows"

   ```powershell
   code path\to\README.md
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   code path/to/README.md
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   code path/to/README.md
   ```

   ::: zone-end
3. Add the following line to your README.md. Since it is enclosed in an HTML comment, it can be anywhere and won't be rendered.

   ```markdown
   <!-- mcp-name: [name property from the server.json] -->
   ```

   Example:

   ```markdown
   <!-- mcp-name: io.github.contoso/data-mcp -->
   ```

4. Save the README.md file.

## Publish your MCP Server package to NuGet.org

Because your README.md now has an `mcp-name` declared in it, publish the latest package to NuGet.org.

1. If needed, update your package version and the respective version strings in your `server.json`.
2. Pack your project so the latest README.md version is contained.

   ```bash
   dotnet pack
   ```

3. Push it to NuGet.org either [via the website](https://www.nuget.org/packages/manage/upload) or using the CLI:
   ::: zone pivot="os-windows"

   ```powershell
   dotnet push bin\Release\*.nupkg -k <API key here> -s https://api.nuget.org/v3/index.json
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   dotnet push bin/Release/*.nupkg -k <API key here> -s https://api.nuget.org/v3/index.json
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   dotnet push bin/Release/*.nupkg -k <API key here> -s https://api.nuget.org/v3/index.json
   ```

   ::: zone-end

## Wait for your package to become available

NuGet.org performs validations against your package before making it available so you must wait to publish your MCP server to the Official MCP Registry since it verifies that the package is accessible.

To wait for your package to become available, either continue to periodically refresh the package details page on NuGet.org until the validating message disappears, or use the following PowerShell script to poll for availability.

```powershell
$id = "<your NuGet package ID here>".ToLowerInvariant()
$version = "<your NuGet package version here>".ToLowerInvariant()
$url = "https://api.nuget.org/v3-flatcontainer/$id/$version/readme"
$elapsed = 0; $interval = 10; $timeout = 300
Write-Host "Checking for package README of $id $version."
while ($true) {
    if ($elapsed -gt $timeout) {
        Write-Error "Package README is not available after $elapsed seconds. URL: $url"
        exit 1
    }
    try {
        Invoke-WebRequest -Uri $url -ErrorAction Stop | Out-Null
        Write-Host "Package README is now available."
        break
    } catch {
        Write-Host "Package README is not yet available. Elapsed time: $elapsed seconds."
        Start-Sleep -Seconds $interval; $elapsed += $interval
        continue
    }
}
```

This script can be leveraged in a CI/CD pipeline to ensure the next step (publishing to the Official MCP Registry) does not happen before the NuGet package is available.

## Download the MCP Publisher tool

1. Download the `mcp-publisher-*.tar.gz` file from the Official MCP Registry GitHub repository that matches your CPU architecture.
   ::: zone pivot="os-windows"
   - Windows x64: [mcp-publisher_windows_amd64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_windows_amd64.tar.gz)
   - Windows Arm64: [mcp-publisher_windows_arm64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_windows_arm64.tar.gz)
   ::: zone-end
   ::: zone pivot="os-linux"
   - Linux x64: [mcp-publisher_linux_amd64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_linux_amd64.tar.gz)
   - Linux Arm64: [mcp-publisher_linux_arm64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_linux_arm64.tar.gz)
   ::: zone-end
   ::: zone pivot="os-macos"
   - macOS x64: [mcp-publisher_darwin_amd64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_darwin_amd64.tar.gz)
   - macOS Arm64: [mcp-publisher_darwin_arm64.tar.gz](https://github.com/modelcontextprotocol/registry/releases/latest/download/mcp-publisher_darwin_arm64.tar.gz)
   ::: zone-end
   See the full list of assets in the [latest release](https://github.com/modelcontextprotocol/registry/releases/latest).
2. Extract the downloaded .tar.gz to the current directory.
   ::: zone pivot="os-windows"

   ```powershell
   # For Windows x64
   tar xf 'mcp-publisher_windows_amd64.tar.gz'

   # For Windows ARM64
   tar xf 'mcp-publisher_windows_arm64.tar.gz'
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   # For Linux x64
   tar xf 'mcp-publisher_linux_amd64.tar.gz'

   # For Linux ARM64
   tar xf 'mcp-publisher_linux_arm64.tar.gz'
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   # For macOS x64
   tar xf 'mcp-publisher_darwin_amd64.tar.gz'

   # For macOS ARM64
   tar xf 'mcp-publisher_darwin_arm64.tar.gz'
   ```

   ::: zone-end

## Publish to the Official MCP Registry

The Official MCP Registry has different authentication mechanisms based on the namespace MCP Server's `name`. In this guide, we are using a namespace based on GitHub (`io.github.<your GitHub username>/*`) so GitHub authentication must be used. See the [registry documentation for information on other authentication modes](https://github.com/modelcontextprotocol/registry/blob/main/docs/modelcontextprotocol-io/authentication.mdx) which unlock other namespaces.

1. Log in using GitHub interactive authentication.
   ::: zone pivot="os-windows"

   ```powershell
   .\mcp-publisher.exe login github
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   ./mcp-publisher login github
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   ./mcp-publisher login github
   ```

   ::: zone-end
   Follow the instructions provided by the tool. You will provide a code to GitHub in your web browser to complete the flow.

   Once the flow is complete, you will be able to publish `server.json` files to the `io.github.<your GitHub username>/*` namespace.

2. Publish your `server.json` file to the Official MCP Registry.
   ::: zone pivot="os-windows"

   ```powershell
   .\mcp-publisher.exe publish path\to\.mcp\server.json
   ```

   ::: zone-end
   ::: zone pivot="os-linux"

   ```bash
   ./mcp-publisher publish path/to/.mcp/server.json
   ```

   ::: zone-end
   ::: zone pivot="os-macos"

   ```bash
   ./mcp-publisher publish path/to/.mcp/server.json
   ```

   ::: zone-end
3. When the command succeeds, you can verify that your MCP Server is published by going to the [registry home page](https://registry.modelcontextprotocol.io/) and searching for your server name.

## Related content

- [Build and publish an MCP Server to NuGet.org](./build-mcp-server.md)
- [Publish a NuGet package](/nuget/nuget-org/publish-a-package)
- [Conceptual: MCP Servers in NuGet Packages](/nuget/concepts/nuget-mcp)
- [Get started with .NET AI and the Model Context Protocol](../get-started-mcp.md)
