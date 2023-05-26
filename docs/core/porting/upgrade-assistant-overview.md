---
title: Overview of the .NET Upgrade Assistant
description: Introducing the .NET Upgrade Assistant tool that helps upgrade .NET, .NET Core, or .NET Framework apps to the latest version of .NET.
author: adegeo
ms.date: 05/22/2023
topic: overview
no-loc: ["appsettings.json", "App.config"]
---
# Overview of the .NET Upgrade Assistant

New versions of .NET are released throughout the year, with a major release once a year. The .NET Upgrade Assistant helps you upgrade apps from previous versions of .NET, .NET Core, and .NET Framework to the latest version.

The .NET Upgrade Assistant is a Visual Studio extension and command-line tool that's designed to assist with upgrading apps to the latest version of .NET.

Issues related to the .NET Upgrade Assistant can be filed within Visual Studio by selecting **Help** > **Send Feedback** > **Report a Problem...**

## Install the Upgrade Assistant

The .NET Upgrade Assistant can be installed as a Visual Studio extension or as a .NET command-line tool. For more information, see [Install the .NET Upgrade Assistant](upgrade-assistant-install.md).

## Supported languages

The following code languages are supported:

- C#
- Visual Basic

## Supported projects

The following types of projects are supported:

- ASP.NET
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps
- .NET Native UWP
- Xamarin Forms
- .NET MAUI

## Upgrade paths

The following upgrade paths are supported:

- .NET Framework to .NET
- .NET Core to .NET
- UWP to WinUI 3
- Previous .NET version to the latest .NET version
- Azure Functions v1-v3 to v4 isolated
- Xamarin Forms to .NET MAUI
  - XAML file transformations only support upgrading namespaces. For more comprehensive transformations, use Visual Studio 2022 version 17.6 or later.

## Upgrade with the Visual Studio extension

After you've [installed the .NET Upgrade Assistant extension](upgrade-assistant-install.md#install-the-visual-studio-extension), right-click on the project in the **Solution Explorer** window, and select **Upgrade**.

> [!CAUTION]
> Make sure you backup your projects prior to upgrading if you're not using source control.

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-upgrade.png" alt-text="The .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

A tab is opened which provides, based on your project type, different styles of upgrade:

- In-place project upgrade

  This option upgrades your project without making a copy.

- Side-by-side project upgrade

  Copies your project and upgrades the copy, leaving your original project alone.

- Side-by-side incremental

  A good choice for complicated web apps. Upgrading from ASP.NET to ASP.NET Core requires quite a bit of work and at times manual refactoring. This mode puts a .NET project next to your existing .NET Framework project, and routes endpoints that are implemented in the .NET project, while all other calls are sent to .NET Framework application.

  This mode lets you slowly upgrade your ASP.NET or Library app piece-by-piece.

Once your app has been upgraded, a status screen is displayed which shows all of the artifacts related to your project that were associated with the upgrade. Each upgrade artifact can be expanded to read more information about the status. The following list describes the status icons:

- **Filled green checkmark**: The artifact was upgraded and completed successfully.
- **Unfilled green checkmark**: The tool didn't find anything about the artifact to upgrade.
- **Yellow warning sign**: The artifact was upgraded, but there's important information you should consider.
- **Red _X_**: The artifact was to be upgraded, but the upgrade failed.

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-upgrade-results.png" alt-text="The .NET Upgrade Assistant's Upgrade results tab in Visual Studio.":::

Additionally, the actions the Upgrade Assistant performed are logged to the **Output** window under the **Upgrade Assistant** source, as shown inthe following image:

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-output-window.png" alt-text="The output window in Visual Studio showing the results from the .NET Upgrade Assistant.":::

After upgrading your project, you'll need to test it thoroughly.

## Upgrade with the CLI tool

After you've [installed the .NET Upgrade Assistant CLI tool](upgrade-assistant-install.md#install-the-net-global-tool), open a terminal window and navigate to the directory that contains the project you want to upgrade. You can use the `upgrade-assistant --help` command to see the available options the CLI provides.

> [!CAUTION]
> Make sure you backup your projects prior to upgrading if you're not using source control.

Run the tool with the `upgrade-assistant upgrade` command, all of the projects from the current folder and below, are listed. The CLI tool provides an interactive way of choosing which project to upgrade. Use the arrow keys to select an item, and press <kbd>Enter</kbd> to run the item. Select the project you want to upgrade. In the example provided by this article, there are four projects under the current folder:

```
 Selected options
───────────────────────────────────────────────────────────
 No options specified, follow steps below to continue

 Steps
─────────────────
 Source project
─────────────────

Which project do you want to upgrade (found 9)?

> MatchingGame (winforms\MatchingGame\MatchingGame.csproj)
  MatchingGame.Logic (winforms\MatchingGame.Logic\MatchingGame.Logic.csproj)
  StarVoteControl (csharp\StarVoteControl\StarVoteControl.csproj)
  WebSiteRatings (csharp\WebSiteRatings\WebSiteRatings.csproj)

  Navigation
    Exit
```

Depending on the project you upgrade, you may be presented with an option to specify how the upgrade should proceed:

- In-place project upgrade

  This option upgrades your project without making a copy.

- Side-by-side project upgrade

  This option is only available for .NET Framework projects. Copies your project and upgrades the copy, leaving your original project alone.

```
 Selected options
──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
 Source project     C:\Code\winforms\MatchingGame\MatchingGame.csproj

 Steps
───────────────────────────────
 Source project / Upgrade type
───────────────────────────────

How do you want to upgrade project MatchingGame?

> In-place project upgrade
  Side-by-side project upgrade

  Navigation
    Back
    Exit
```

After this step, if there's more than one upgradable target framework, you'll choose a target:

```
 Selected options
──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
 Source project     C:\Code\Work\dotnet\dotnet-docs\docs\core\porting\snippets\upgrade-assistant-wpf-framework\winforms\MatchingGame\MatchingGame.csproj
 Ugrade type        Inplace

 Steps
──────────────────────────────────────────────────
 Source project / Ugrade type / Target framework
──────────────────────────────────────────────────

What is your preferred target framework?

> .NET 6.0 (Supported until November, 2024)
  .NET 7.0 (Supported until May, 2024)
  .NET 8.0 (Try latest preview features)

  Navigation
    Back
    Exit
```

After upgrading your project, you'll need to test it thoroughly.
