---
title: .NET tools
description: How to install, use, update, and remove .NET tools. Covers global tools, tool-path tools, and local tools. 
author: KathleenDollard
ms.topic: how-to
ms.date: 02/12/2020
---
# How to manage .NET tools

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

A .NET tool is a special NuGet package that contains a console application. A tool can be installed on your machine in the following ways:

* As a global tool.

  The tool binaries are installed in a default directory that is added to the PATH environment variable. You can invoke the tool from any directory on the machine without specifying its location. One version of a tool is used for all directories on the machine.

* As a global tool in a custom location (also known as a tool-path tool).

  The tool binaries are installed in a location that you specify. You can invoke the tool from the installation directory or by providing the directory with the command name or by adding the directory to the PATH environment variable. One version of a tool is used for all directories on the machine.

* As a local tool (applies to .NET Core SDK 3.0 and later).

  The tool binaries are installed in a default directory. You invoke the tool from the installation directory or any of its subdirectories. Different directories can use different versions of the same tool.
  
  The .NET CLI uses manifest files to keep track of which tools are installed as local to a directory. When the manifest file is saved in the root directory of a source code repository, a contributor can clone the repository and invoke a single .NET CLI command that installs all of the tools listed in the manifest files.

> [!IMPORTANT]
> .NET tools run in full trust. Do not install a .NET tool unless you trust the author.

## Find a tool

Here are some ways to find tools:

* Use the [dotnet tool search](dotnet-tool-search.md) command to find a tool that is published to NuGet.org.
* Search the [NuGet](https://www.nuget.org) website by using the ".NET tool" package type filter. For more information, see [Finding and choosing packages](/nuget/consume-packages/finding-and-choosing-packages).
* See the source code for the tools created by the ASP.NET Core team in the [Tools directory of the dotnet/aspnetcore GitHub repository](https://github.com/dotnet/aspnetcore/tree/main/src/Tools).
* Learn about diagnostic tools at [.NET diagnostic tools](../diagnostics/index.md#net-core-diagnostic-global-tools).

## Check the author and statistics

Since .NET tools run in full trust, and global tools are added to the PATH environment variable, they can be very powerful. Don't download tools from people you don't trust.

If the tool is hosted on NuGet, you can check the author and statistics by searching for the tool.

## Install a global tool

To install a tool as a global tool, use the `-g` or `--global` option of [dotnet tool install](dotnet-tool-install.md), as shown in the following example:

```dotnetcli
dotnet tool install -g dotnetsay
```

The output shows the command used to invoke the tool and the version installed, similar to the following example:

```output
You can invoke the tool using the following command: dotnetsay
Tool 'dotnetsay' (version '2.1.4') was successfully installed.
```

The default location for a tool's binaries depends on the operating system:

| OS          | Path                          |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

This location is added to the user's path when the SDK is first run, so global tools can be invoked from any directory without specifying the tool location.

Tool access is user-specific, not machine global. A global tool is only available to the user that installed the tool.

### Install a global tool in a custom location

To install a tool as a global tool in a custom location, use the `--tool-path` option of [dotnet tool install](dotnet-tool-install.md), as shown in the following examples.

On Windows:

```dotnetcli
dotnet tool install dotnetsay --tool-path c:\dotnet-tools
```

On Linux or macOS:

```dotnetcli
dotnet tool install dotnetsay --tool-path ~/bin
```

The .NET SDK doesn't add this location automatically to the PATH environment variable. To [invoke a tool-path tool](#invoke-a-tool-path-tool), you have to make sure the command is available by using one of the following methods:

* Add the installation directory to the PATH environment variable.
* Specify the full path to the tool when you invoke it.
* Invoke the tool from within the installation directory.

## Install a local tool

**Applies to .NET Core 3.0 SDK and later.**

To install a tool for local access only (for the current directory and subdirectories), it has to be added to a tool manifest file. To create a tool manifest file, run the `dotnet new tool-manifest` command:

```dotnetcli
dotnet new tool-manifest
```

This command creates a manifest file named *dotnet-tools.json* under the *.config* directory. To add a local tool to the manifest file, use the [dotnet tool install](dotnet-tool-install.md) command and **omit** the `--global` and `--tool-path` options, as shown in the following example:

```dotnetcli
dotnet tool install dotnetsay
```

The command output shows which manifest file the newly installed tool is in, similar to the following example:

```console
You can invoke the tool from this directory using the following command:
dotnet tool run dotnetsay
Tool 'dotnetsay' (version '2.1.4') was successfully installed.
Entry is added to the manifest file /home/name/botsay/.config/dotnet-tools.json.
```

The following example shows a manifest file with two local tools installed:

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "botsay": {
      "version": "1.0.0",
      "commands": [
        "botsay"
      ]
    },
    "dotnetsay": {
      "version": "2.1.3",
      "commands": [
        "dotnetsay"
      ]
    }
  }
}
```

You typically add a local tool to the root directory of the repository. After you check in the manifest file to the repository, developers who check out code from the repository get the latest manifest file. To install all of the tools listed in the manifest file, they run the `dotnet tool restore` command:

```dotnetcli
dotnet tool restore
```

The output indicates which tools were restored:

```console
Tool 'botsay' (version '1.0.0') was restored. Available commands: botsay
Tool 'dotnetsay' (version '2.1.3') was restored. Available commands: dotnetsay
Restore was successful.
```

## Install a specific tool version

To install a pre-release version or a specific version of a tool, specify the version number by using the `--version` option, as shown in the following example:

```dotnetcli
dotnet tool install dotnetsay --version 2.1.3
```

To install a pre-release version of the tool without specifying the exact version number, use the `--version` option and provide a wildcard, as shown in the following example:

```dotnetcli
dotnet tool install --global dotnetsay --version "*-rc*"
```

## Use a tool

The command that you use to invoke a tool may be different from the name of the package that you install. To display all of the tools currently installed on the machine for the current user, use the [dotnet tool list](dotnet-tool-list.md) command:

```dotnetcli
dotnet tool list
```

The output shows each tool's version and command, similar to the following example:

```console
Package Id      Version      Commands       Manifest
-------------------------------------------------------------------------------------------
botsay          1.0.0        botsay         /home/name/repository/.config/dotnet-tools.json
dotnetsay       2.1.3        dotnetsay      /home/name/repository/.config/dotnet-tools.json
```

As shown in this example, the list shows local tools. To see global tools, use the `--global` option, and to see tool-path tools, use the `--tool-path` option.

### Invoke a global tool

For global tools, use the tool command by itself. For example, if the command is `dotnetsay` or `dotnet-doc`, that's what you use to invoke the command:

```console
dotnetsay
dotnet-doc
```

If the command begins with the prefix `dotnet-`, an alternative way to invoke the tool is to use the `dotnet` command and omit the tool command prefix. For example, if the command is `dotnet-doc`, the following command invokes the tool:

```dotnetcli
dotnet doc
```

However, in the following scenario you can't use the `dotnet` command to invoke a global tool:

* A global tool and a local tool have the same command prefixed by `dotnet-`.
* You want to invoke the global tool from a directory that is in scope for the local tool.

In this scenario, `dotnet doc` and `dotnet dotnet-doc` invoke the local tool. To invoke the global tool, use the command by itself:

```dotnetcli
dotnet-doc
```

### Invoke a tool-path tool

To invoke a global tool that is installed by using the `tool-path` option, make sure the command is available, as explained [earlier in this article](#install-a-global-tool-in-a-custom-location).

### Invoke a local tool

To invoke a local tool, you have to use the `dotnet` command from within the installation directory. You can use the long form (`dotnet tool run <COMMAND_NAME>`) or the short form (`dotnet <COMMAND_NAME>`), as shown in the following examples:

```dotnetcli
dotnet tool run dotnetsay
dotnet dotnetsay
```

If the command is prefixed by `dotnet-`, you can include or omit the prefix when you invoke the tool. For example, if the command is `dotnet-doc`, any of the following examples invokes the local tool:

```dotnetcli
dotnet tool run dotnet-doc
dotnet dotnet-doc
dotnet doc
```

## Update a tool

Updating a tool involves uninstalling and reinstalling it with the latest stable version. To update a tool, use the [dotnet tool update](dotnet-tool-update.md) command with the same option that you used to install the tool:

```dotnetcli
dotnet tool update --global <packagename>
dotnet tool update --tool-path <packagename>
dotnet tool update <packagename>
```

For a local tool, the SDK finds the first manifest file that contains the package ID by looking in the current directory and parent directories. If there is no such package ID in any manifest file, the SDK adds a new entry to the closest manifest file.

## Uninstall a tool

Remove a tool by using the [dotnet tool uninstall](dotnet-tool-uninstall.md) command with the same option that you used to install the tool:

```dotnetcli
dotnet tool uninstall --global <packagename>
dotnet tool uninstall --tool-path <packagename>
dotnet tool uninstall <packagename>
```

For a local tool, the SDK finds the first manifest file that contains the package ID by looking in the current directory and parent directories.

## Get help and troubleshoot

If a tool fails to install or run, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md). You can get a list of available `dotnet tool` commands and parameters by using the `--help` parameter:

```dotnetcli
dotnet tool --help
```

To get tool usage instructions, enter one of the following commands or see the tool's website:

```dotnetcli
<command> --help
dotnet <command> --help
```

## See also

- [Tutorial: Create a .NET tool using the .NET CLI](global-tools-how-to-create.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)
