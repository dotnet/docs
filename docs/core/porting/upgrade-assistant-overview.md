---
title: Overview of the .NET Upgrade Assistant
description: Introducing the .NET Upgrade Assistant tool that helps migrate from .NET Framework and upgrades your projects to .NET 5.
author: ardalis
ms.date: 03/08/2021
---
# Overview of the .NET Upgrade Assistant

You might have apps that currently run on the .NET Framework that you're interested in porting to .NET 5. The .NET Upgrade Assistant tool can assist with this process. This article provides:

- An overview of the .NET Upgrade Assistant.
- How to install the .NET Upgrade Assistant.

## What is the .NET Upgrade Assistant

The .NET Upgrade Assistant is a command-line tool that can be run on different kinds of .NET Framework apps. It's designed to assist with upgrading .NET Framework apps to .NET 5. After running the tool, **in most cases the app will require more effort to complete the migration**. The tool includes the installation of analyzers that can assist with completing the migration.

Currently the tool supports the following .NET Framework app types:

- .NET Framework Windows Forms apps
- .NET Framework WPF apps
- .NET Framework ASP.NET MVC apps
- .NET Framework console apps
- .NET Framework class libraries

The .NET Upgrade Assistant is currently prerelease and is receiving frequent updates. If you discover problems using the tool, please report them in the tool's [GitHub repository](https://github.com/dotnet/upgrade-assistant).

## How to install the .NET Upgrade Assistant

The [Get Started tutorial](https://aka.ms/dotnet-upgrade-assistant-install) walks through how to install and use the .NET Upgrade Assistant.

### Prerequisites

1. This tool uses MSBuild to work with project files. Make sure that a recent version of MSBuild is installed. An easy way to do this is to [install Visual Studio 2019](https://visualstudio.microsoft.com/downloads/).
1. This tool depends on [try-convert](https://github.com/dotnet/try-convert). In order for the tool to run correctly, you must install the try-convert tool for converting project files to the new SDK style. If you already have **try-convert** installed, you may need to update it instead (since **upgrade-assistant** depends on version _0.7.212201_ or later)
    1. To install try-convert: `dotnet tool install -g try-convert`
    1. To update try-convert: `dotnet tool update -g try-convert`

### Installation steps

The tool can be installed as a .NET CLI tool by running:

```dotnet
dotnet tool install -g upgrade-assistant
```

Similarly, because the .NET Upgrade Assistant is installed as a .NET CLI tool, it can be easily updated by running:

```dotnet
dotnet tool update -g upgrade-assistant
```

For detailed installation instructions, please refer to the project's [README](https://github.com/dotnet/upgrade-assistant).

## See also

- [Upgrade a WPF App to .NET 5 with the .NET Upgrade Assistant](upgrade-assistant-wpf-framework.md)
- [Upgrade a Windows Forms App to .NET 5 with the .NET Upgrade Assistant](upgrade-assistant-winforms-framework.md)
- [Upgrade an ASP.NET MVC App to .NET 5 with the .NET Upgrade Assistant](upgrade-assistant-aspnetmvc.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)
