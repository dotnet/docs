---
title: .NET install tool for VS Code extension authors
description: An overview of the .NET install tool for extension authors, a Visual Studio Code extension for installing the .NET runtime.
author: sfoslund
ms.date: 11/18/2020
---
# .NET install tool for extension authors

The [.NET install tool for extension authors](https://github.com/dotnet/vscode-dotnet-runtime) is a Visual Studio Code extension that allows acquisition of the .NET runtime specifically for VS Code extension authors. This tool is intended to be leveraged in extensions that are written in .NET and require .NET to boot pieces of the extension (for example, a language server). The extension is not intended to be used directly by users to install .NET for development.

## Getting started: extension authors

To ensure that the .NET install tool for extension authors is the right fit for your scenario, start by reviewing the [goals of this extension](https://github.com/dotnet/vscode-dotnet-runtime#goals-acquiring-net-core-for-extensions) on our GitHub page.

> [!NOTE]
> This tool can be used to install the .NET runtime only, it currently does not have the capability to install the .NET SDK.

Once you have verified that the .NET install tool for extension authors fits your needs, you can take a dependency on it in your [extension manifest](https://code.visualstudio.com/api/references/extension-manifest) and begin using the commands we expose with the [VS Code API](https://code.visualstudio.com/api/extension-guides/command#programmatically-executing-a-command). You can find the list of commands this extension exposes on our [GitHub](https://github.com/dotnet/vscode-dotnet-runtime/blob/main/Documentation/commands.md).

Check out this [sample extension](https://github.com/dotnet/vscode-dotnet-runtime/tree/main/sample) to see these steps in action.

For more examples, check out these open source extensions that currently leverage this tool:

- [Azure Resource Manager (ARM) Tools for Visual Studio Code](https://github.com/microsoft/vscode-azurearmtools)

- [.NET Interactive Notebooks](https://github.com/dotnet/interactive/tree/main/src/dotnet-interactive-vscode)

## Getting started: end users

In general, the end user should not need to interact with the .NET install tool for extension authors at all. If you are having problems with the extension, check out our [troubleshooting page](https://github.com/dotnet/vscode-dotnet-runtime/blob/main/Documentation/troubleshooting-runtime.md) or file an issue on our [GitHub](https://github.com/dotnet/vscode-dotnet-runtime/issues).
