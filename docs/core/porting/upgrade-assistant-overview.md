---
title: Overview of the .NET Upgrade Assistant
description: Introducing the .NET Upgrade Assistant tool that helps migrate from .NET Framework and upgrades your projects to .NET 6.
author: adegeo
ms.date: 08/02/2022
---
# Overview of the .NET Upgrade Assistant

You might have apps that currently run on the .NET Framework that you're interested in porting to .NET 6. The .NET Upgrade Assistant tool can assist with this process. This article provides:

- An overview of the .NET Upgrade Assistant.
- How to install the .NET Upgrade Assistant.

## What is the .NET Upgrade Assistant

The .NET Upgrade Assistant is a command-line tool that can be run on different kinds of .NET Framework apps. It's designed to assist with upgrading .NET Framework apps to .NET 6. After running the tool, **in most cases the app will require additional effort to complete the migration**. The tool includes the installation of analyzers that can assist with completing the migration.

Currently the tool supports the following .NET Framework app types:

- .NET Framework Windows Forms apps
- .NET Framework WPF apps
- .NET Framework server-side WCF apps
- .NET Native UWP apps
- .NET Framework ASP.NET MVC apps
- .NET Framework console apps
- .NET Framework class libraries

The tool also supports projects that use these code languages:

- C#
- Visual Basic.NET

The .NET Upgrade Assistant is currently prerelease and is receiving frequent updates. If you discover problems using the tool, report them in the tool's [GitHub repository](https://github.com/dotnet/upgrade-assistant).

## Install the .NET Upgrade Assistant

This section describes how to install the .NET Upgrade Assistant. You can also follow [a step-by-step guided tutorial](https://dotnet.microsoft.com/platform/upgrade-assistant/tutorial/intro).

### Prerequisites

- Windows Operating System
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022 version 17.0 or later](https://visualstudio.microsoft.com/downloads/)

### Installation steps

The .NET Upgrade Assistant is a .NET tool that is installed globally with the following command:

```dotnetcli
dotnet tool install -g upgrade-assistant
```

Similarly, because the .NET Upgrade Assistant is installed as a .NET tool, it can be easily updated by running:

```dotnetcli
dotnet tool update -g upgrade-assistant
```

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors:
>
> ```dotnetcli
> dotnet tool install -g --ignore-failed-sources upgrade-assistant
> ```

## See also

- [Upgrade an ASP.NET MVC App to .NET 6](upgrade-assistant-aspnetmvc.md)
- [Upgrade a WPF App to .NET 6](upgrade-assistant-wpf-framework.md)
- [Upgrade a Windows Forms App to .NET 6](upgrade-assistant-winforms-framework.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)
