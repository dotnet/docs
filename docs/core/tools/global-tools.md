---
title: .NET Core Global Tools
description: An overview of what .NET Core Global Tools are and the .NET Core CLI commands available for them. 
author: KathleenDollard
ms.author: mairaw
ms.date: 04/25/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# .NET Core Global Tools overview

.NET Core Global Tools are applications that are installed on your path.

If you want to use a .NET Core Global Tool:

* Find information about the tool (usually a website or GitHub page).
* Check the author and statistics in the home for the feed (usually NuGet.org).
* Install the tool.
* Call the tool.

> [!IMPORTANT]
> .NET Core Global Tools appear on your path and run in full trust. Do not install .NET Core Global Tools unless you trust the author.

## Find a .NET Core Global Tool

Currently, there isn't a Global Tool search feature in the .NET Core CLI.

You can find .NET Core Global Tools on [NuGet](https://www.nuget.org). However, NuGet doesn't yet allow you to search specifically for .NET Core Global Tools.

You may also find tool recommendations in blog posts.

## Check the author and statistics

Since .NET Core Global Tools run in full trust and are installed on your path, they can be very powerful. Don't download tools from people you don't trust.

If the tool is hosted on NuGet, you can check the author and statistics by searching for the tool.

## Install a global tool

To install a global tool, you use the [dotnet tool install](dotnet-tool-install.md) .NET Core CLI command like in the following example:

```bash
dotnet tool install -g dotnetsay
```

If the tool can't be installed, error messages are displayed. Check that the feeds you expected are being checked.

If you're trying to install a pre-release version or a specific version of the tool, you can specify the version number using the following format:

```bash
dotnet tool install -g <package-name> --version <version-number>
```

If installation is successful, a message is displayed showing the command used to call the tool and the version installed, similar to the following example:

```
You can invoke the tool using the following command: dotnetsay
Tool 'dotnetsay' (version '2.0.0') was successfully installed.
```

Global Tools are installed in the following directories by default when you specify the `-g` (or `--global`) option:

| OS          | Path                          |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

## Use the tool

Once the tool is installed, you can call it by using its command. Note that the command may not be the same as the package name.

If the command is `dotnetsay`, you call it with:

```bash
dotnetsay
```

If the tool author wanted the tool to appear in the context of the `dotnet` prompt, they may have written it in a way that you call it as `dotnet <command>`, such as:

```bash
dotnet ef
```

You can find which tools are included in an installed Global Tool package by listing the installed packages.

You can also look for usage instructions at the tool's website or by typing one of the following commands:

```bash
<command> --help
dotnet <command> --help
```

### What could go wrong

Global Tools are shared framework applications, which means they rely on a .NET Core runtime installed on your machine. If the expected runtime is not found, they follow normal .NET Core runtime roll-forward rules such as:

* An application rolls forward to the highest patch release of the specified major and minor version.
* If there is no matching runtime with a matching major and minor version number, the next higher minor version is used.
* Roll forward doesn't occur between preview versions of the runtime or between preview versions and release versions.

If an application cannot find an appropriate runtime, it fails to run and reports an error.

Another issue that might happen is that a Global Tool that was created during an earlier preview may not run with your currently installed .NET Core runtimes. You can see which runtimes are installed on your machine using the following command:

```bash
dotnet --list-runtimes
```

Contact the author of the Global Tool and see if they can recompile and republish their tool package to NuGet with an updated version number. Once they have updated the package on NuGet, you can update your copy.

The .NET Core CLI tries to add the default locations to the PATH environment variable on its first usage. However, there are a couple of scenarios where the location might not be added to PATH automatically, such as:

* If you've set the `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` environment variable.
* On macOS, if you've installed the .NET Core SDK using *.tar.gz* files and not *.pkg*.
* On Linux, you need to edit the shell environment file to configure the PATH.

## Other CLI commands

The .NET Core SDK contains other commands that support .NET Core Global Tools. Use any of the `dotnet tool` commands with one of the following options:

* `--global` or `-g` specifies that the command is applicable to user-wide Global Tools.
* `--tool-path` specifies a custom location for Global Tools.

To find out which commands are available for Global Tools:

```bash
dotnet tool --help
```

Updating a Global Tool involves uninstalling and reinstalling it with the latest stable version. To update a Global Tool, use the [dotnet tool update](dotnet-tool-update.md) command:

```bash
dotnet tool update -g <packagename>
```

Remove a Global Tool using the [dotnet tool uninstall](dotnet-tool-uninstall.md):

```bash
dotnet tool uninstall -g <packagename>
```

To display all of the Global Tools currently installed on the machine, along with their version and commands, use the [dotnet tool list](dotnet-tool-list.md) command:

```bash
dotnet tool list -g
```