---
title: What's new in .NET Core 3.1
description: Learn about the new features found in .NET Core 3.1.
dev_langs:
  - "csharp"
author: adegeo
ms.author: adegeo
ms.date: 12/04/2019
---

# What's new in .NET Core 3.1

This article describes what is new in .NET Core 3.1. This release contains minor improvements to .NET Core 3.0, focusing on small, but important, fixes. The most important feature about .NET Core 3.1 is that it's a [long-term support (LTS)](#long-term-support) release.

If you're using Visual Studio 2019, you must update to [Visual Studio 2019 version 16.4 or later](https://visualstudio.microsoft.com/downloads/) to work with .NET Core 3.1 projects. For information on what's new in Visual Studio version 16.4, see [What's New in Visual Studio 2019 version 16.4](/visualstudio/releases/2019/release-notes-v16.4#whats-new-in-visual-studio-2019-version-164).

Visual Studio for Mac also supports and includes .NET Core 3.1 in Visual Studio for Mac 8.4.

For more information about the release, see the [.NET Core 3.1 announcement](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/).

- [Download and get started with .NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) on Windows, macOS, or Linux.

## Long-term support

.NET Core 3.1 is an LTS release with support from Microsoft for the next three years. It's highly recommended that you move your apps to .NET Core 3.1. The current lifecycle of other major releases is as follows:

| Release | Note |
| ------- | ---- |
| .NET Core 3.0 | End of life on March 3, 2020.     |
| .NET Core 2.2 | End of life on December 23, 2019. |
| .NET Core 2.1 | End of life on August 21, 2021.    |

For more information, see the [.NET Core support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## macOS appHost and notarization

*macOS only*

Starting with the notarized .NET Core SDK 3.1 for macOS, the appHost setting is disabled by default. For more information, see [macOS Catalina Notarization and the impact on .NET Core downloads and projects](../install/macos-notarization-issues.md).

When the appHost setting is enabled, .NET Core generates a native Mach-O executable when you build or publish. Your app runs in the context of the appHost when it is run from source code with the `dotnet run` command, or by starting the Mach-O executable directly.

Without the appHost, the only way a user can start a [framework-dependent](../deploying/index.md#publish-framework-dependent) app is with the `dotnet <filename.dll>` command. An appHost is always created when you publish your app [self-contained](../deploying/index.md#publish-self-contained).

You can either configure the appHost at the project level, or toggle the appHost for a specific `dotnet` command with the `-p:UseAppHost` parameter:

- Project file

  ```xml
  <PropertyGroup>
    <UseAppHost>true</UseAppHost>
  </PropertyGroup>
  ```

- Command-line parameter

  ```dotnetcli
  dotnet run -p:UseAppHost=true
  ```

For more information about the `UseAppHost` setting, see [MSBuild properties for Microsoft.NET.Sdk](../project-sdk/msbuild-props.md#useapphost).

## Windows Forms

*Windows only*

> [!WARNING]
> There are breaking changes in Windows Forms.

Legacy controls were included in Windows Forms that have been unavailable in the Visual Studio Designer Toolbox for some time. These were replaced with new controls back in .NET Framework 2.0. These have been removed from the Desktop SDK for .NET Core 3.1.

| Removed control | Recommended replacement | Associated APIs removed |
| --------------- | ----------------------- | ----------------------- |
| DataGrid        | <xref:System.Windows.Forms.DataGridView>      | DataGridCell<br/>DataGridRow<br/>DataGridTableCollection<br/>DataGridColumnCollection<br/>DataGridTableStyle<br/>DataGridColumnStyle<br/>DataGridLineStyle<br/>DataGridParentRowsLabel<br/>DataGridParentRowsLabelStyle<br/>DataGridBoolColumn<br/>DataGridTextBox<br/>GridColumnStylesCollection<br/>GridTableStylesCollection<br/>HitTestType |
| ToolBar         | <xref:System.Windows.Forms.ToolStrip>         | ToolBarAppearance |
| ToolBarButton   | <xref:System.Windows.Forms.ToolStripButton>   | ToolBarButtonClickEventArgs<br/>ToolBarButtonClickEventHandler<br/>ToolBarButtonStyle<br/>ToolBarTextAlign |
| ContextMenu     | <xref:System.Windows.Forms.ContextMenuStrip>  |  |
| :::no-loc text="Menu"::: | <xref:System.Windows.Forms.ToolStripDropDown><br/><xref:System.Windows.Forms.ToolStripDropDownMenu> | MenuItemCollection |
| MainMenu        | <xref:System.Windows.Forms.MenuStrip>         |  |
| MenuItem        | <xref:System.Windows.Forms.ToolStripMenuItem> |  |

We recommend you update your applications to .NET Core 3.1 and move to the replacement controls. Replacing the controls is a straightforward process, essentially "find and replace" on the type.

## C++/CLI

*Windows only*

Support has been added for creating C++/CLI (also known as "managed C++") projects. Binaries produced from these projects are compatible with .NET Core 3.0 and later versions.

To add support for C++/CLI in Visual Studio 2019 version 16.4, install the [Desktop development with C++ workload](/cpp/build/vscpp-step-0-installation?view=vs-2019#step-4---choose-workloads). This workload adds two templates to Visual Studio:

- CLR Class Library (.NET Core)
- CLR Empty Project (.NET Core)

## Next steps

- [Review the breaking changes between .NET Core 3.0 and 3.1.](../compatibility/3.0-3.1.md)
- [Review the breaking changes in .NET Core 3.1 for Windows Forms apps.](../compatibility/winforms.md#net-core-31)
