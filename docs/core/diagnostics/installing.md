---
title: Installing dotnet diagnostic tools - .NET Core
description: Installing dotnet diagnostic command-line tools.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/21/2019
---
# Installing the `dotnet` diagnostic command-line tools

Depending on the diagnostics scenario, you can use one or more tools to get to root cause.

These tools are implemented as [.NET Core Global Tools](../../tools/global-tools.md). They're installed, upgraded, and uninstalled using the `dotnet tool` commands:
- [dotnet tool install](../../tools/dotnet-tool-install.md).
- [dotnet tool update](../../tools/dotnet-tool-update.md).
- [dotnet tool uninstall](../../tools/dotnet-tool-uninstall.md).

## Using prerelease versions

As tools are developed, we initially release them with a pre-release version.

### Finding available pre-release versions

The pre-release packages are published on [NuGet package](https://www.nuget.org/). You can search for each package by name. Releases are listed on each packages page. For instance:
- [dotnet-counters](https://www.nuget.org/packages/dotnet-counters)
- [dotnet-dump](https://www.nuget.org/packages/dotnet-dump)
- [dotnet-trace](https://www.nuget.org/packages/dotnet-trace)

### Install

These prerelease versions can't be installed without an explicit `--version` option to the [dotnet tool install](../../tools/dotnet-tool-install.md) command. For instance:

```bash
dotnet tool install --global dotnet-dump --version 3.0.0-preview8.19412.1
```

### Upgrade

To upgrade from or to a prerelease version, [dotnet tool uninstall](../../tools/dotnet-tool-uninstall.md) the previous version of the tool before upgrade. Preview versions can't be automatically updated. For instance:

```bash
dotnet tool uninstall --global dotnet-dump
dotnet tool install --global dotnet-dump --version 3.0.0-preview8.19412.1
```

## Handling common install problems

### "Tool already installed"

If you see the error message `Tool 'dotnet-...' is already installed`, you can either:
- [Uninstall](../../tools/dotnet-tool-uninstall.md) the global tool before reinstalling the tool.
- Install to a different path.

### "Specified command or file was not found"

If this install is the first global tool or you get message `Could not execute because the specified command or file was not found.`, you need to add the global tools directory to your path.

| OS          | Default global tool path      |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |
