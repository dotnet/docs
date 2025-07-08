---
title: .NET Upgrade Assistant Overview
description: "Learn more about .NET Upgrade Assistant for .NET-related projects. This tool helps you upgrade from older versions of .NET, including .NET Framework, to the latest version of .NET. Code incompatibilities can be fixed as part of the upgrade."
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 10/08/2024

#customer intent: As a developer, I want to upgrade my project so that I can take advantage of the latest features.

---

# What is .NET Upgrade Assistant?

.NET Upgrade Assistant helps upgrade projects to newer versions of .NET, and analyzes your code to spot and fix potential incompatibilities. One focus of the tool is to help migrate a project from .NET Framework, .NET Core, or .NET, to the latest version of .NET. You use the extension or tool to upgrade entire .NET projects, or some aspect of the project, such migrating a configuration file from an older type to a newer type.

.NET Upgrade Assistant is distributed as a Visual Studio extension or a command-line interface (CLI) tool.

## Analyze and upgrade

.NET Upgrade Assistant includes an analysis engine that scans your projects and their dependencies. After the scan is complete, a report is generated with detailed information about performing an upgrade. You can use this information to upgrade either the entire project or specific parts of the project.

<!-- I don't have this information ready yet

## Extensibility

One key feature of .NET Upgrade Assistant is designing upgrade extensions for your own libraries. Upgrade extensions can be made up of one or two upgrades:

- Package Map

  This is something.

- API Map

  This is something.

-->

## Supported project types

.NET Upgrade Assistant supports upgrading projects coded in either C# or Visual Basic. The following types of projects are supported:

- ASP.NET
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps
- Xamarin Forms
- .NET MAUI
- .NET Native UWP

Some products provide guidance on how to use .NET Upgrade Assistant.

- [ASP.NET](/aspnet/core/migration/mvc)
- [Windows Presentation Foundation](/dotnet/desktop/wpf/migration/)
- [Windows Forms](/dotnet/desktop/winforms/migration/)
- [Universal Windows Platform](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/upgrade-assistant)
- [Windows Communication Foundation](../../core/porting/upgrade-assistant-wcf.md)

## Upgrade paths

The following upgrade paths are supported:

- .NET Framework to .NET
- .NET Core to .NET
- Azure Functions v1-v3 to v4 isolated (targeting net6.0+)
- UWP to WinUI 3
- Previous .NET version to the latest .NET version
- Xamarin Forms to .NET MAUI
  - XAML file transformations only support upgrading namespaces. For more comprehensive transformations, use Visual Studio 2022 version 17.6 or later.

## Upgrade details and options

When an upgrade is started, a wizard walks you through configuring some of the options before the upgrade is initiated. Based on the type of project you're upgrading, the wizard presents different options. For an example of upgrading a project, see [Upgrade projects with .NET Upgrade Assistant](upgrade-assistant-how-to-upgrade.md).

### How the upgrade should be performed

Based on the type of project you're upgrading, you might be able to change how the upgrade is performed. The type of project affects which options are available, and one or more of the following items might be missing:

- In-place project upgrade

  This option upgrades your project without making a copy.

- Side-by-side project upgrade

  Copies your project and upgrades the copy, leaving your original project alone.

- Side-by-side incremental

  This is a good choice for complicated web apps. Upgrading from ASP.NET to ASP.NET Core requires quite a bit of work and at times manual refactoring. This mode puts a .NET project next to the existing .NET Framework project. Endpoints are routed through the .NET project, while all other calls are sent to .NET Framework application.

  This mode lets you slowly upgrade your ASP.NET or library app piece-by-piece.

### Upgrade results

Once the upgrade is finished, a status screen is displayed which shows all of the artifacts associated with the upgrade. Each upgrade artifact can be expanded to read more information about the status. The following list describes the status icons:

- **Unfilled green checkmark**: The tool didn't find anything about the artifact to upgrade.
- **Filled green checkmark**: The artifact was upgraded and completed successfully.
- **Yellow warning sign**: The artifact was upgraded, but there's important information you should consider.
- **Red _X_**: The artifact upgrade was unsuccessful.

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-upgrade-results.png" alt-text="The .NET Upgrade Assistant's Upgrade results tab in Visual Studio.":::

Additionally, the actions the performed during the upgrade are logged to the **Output** window under the **Upgrade Assistant** source, as shown in the following image:

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-output-window.png" alt-text="The output window in Visual Studio showing the results from the .NET Upgrade Assistant.":::

After upgrading your project, test it thoroughly!

## Related content

- [What is code analysis with .NET Upgrade Assistant?](upgrade-assistant-analyze-overview.md)
- [Install .NET Upgrade Assistant](upgrade-assistant-install.md)
- [Analyze projects with .NET Upgrade Assistant](upgrade-assistant-how-to-analyze.md)
- [Upgrade projects with .NET Upgrade Assistant](upgrade-assistant-how-to-upgrade.md)
