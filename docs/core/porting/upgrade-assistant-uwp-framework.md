---
title: Upgrade UWP apps to .NET 6
description: Use the .NET Upgrade Assistant to migrate a C# UWP app to a Windows UI Library (WinUI) 3 app that uses the Windows App SDK. The .NET Upgrade Assistant is a CLI tool.
author: adegeo
ms.date: 09/20/2022
---

# Migrate UWP apps to Windows App SDK with the .NET Upgrade Assistant

> [!IMPORTANT]
> This article was written before the release of the Upgrade Asstant extension for Visual Studio. The CLI version of the tool used in this article may be out of date. The article will be updated after the Microsoft Build 2023 conference.

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with migrating a C# Universal Windows Platform (UWP) app to a [Windows UI Library (WinUI) 3](/windows/apps/winui/) app that uses the Windows App SDK.

For full details, see [Migrate from UWP to the Windows App SDK with the .NET Upgrade Assistant](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/upgrade-assistant) in the Windows App SDK migration documentation.

You can also visit the [Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) GitHub repository.

## Running the tool

To use the .NET Upgrade Assistant to migrate a C# UWP app to a WinUI 3 app, you issue the command `upgrade-assistant upgrade`, and pass in the name of the project or solution you want to migrate. For example:

```console
upgrade-assistant upgrade PhotoLab.sln
```

As it runs, the tool lists out the steps and stages in the migration process that it will carry out. It also provides migration guidance in the form of warning messages within the tool's output, and **Task List** TODOs in the form of comments within your project's source code. And as the developer, you're always in control of the migration process.

Next, visit [Migrate from UWP to the Windows App SDK with the .NET Upgrade Assistant](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/upgrade-assistant) for full details.
