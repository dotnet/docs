---
title: What's new in .NET Core 3.1
description: Learn about the new features found in .NET Core 3.1.
dev_langs:
  - "csharp"
author: thraka
ms.author: adegeo
ms.date: 12/04/2019
---

# What's new in .NET Core 3.1

This article describes what is new in .NET Core 3.1. This release contains minor improvements to .NET Core 3.0, focusing on small, but important, fixes. The most important feature about .NET Core 3.1 is that it's a long-term supported (LTS) release. For more information, see the [.NET Core support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

If you're using Visual Studio 2019, you must update to [Visual Studio 2019 16.4](https://visualstudio.microsoft.com/downloads/) to work with .NET Core 3.1 projects. For more information on what is new in Visual Studio, see the [Visual Studio Blog](https://devblogs.microsoft.com/visualstudio/tis-the-season-visual-studio-2019/).

Visual Studio for Mac also supports and includes .NET Core 3.1, in the Visual Studio for Mac 8.4 Preview channel. You'll need to opt into the Preview channel to use .NET Core 3.1.

For more information about the release, see the [.NET Core 3.1 announcement](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/).

- [Download and get started with .NET Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.1) on Windows, macOS, or Linux.

## Long-term support

.NET Core 3.1 is an LTS release with support from Microsoft for the next three years. It's highly recommended that you move your apps to .NET Core 3.1. The current lifecycle of other major releases is as follows:

| Release | Note |
| ------- | ---- |
| .NET Core 3.0 | End of life on March 3, 2020.     |
| .NET Core 2.2 | End of life on December 23, 2019. |
| .NET Core 2.1 | End of life on August 21, 2021    |

For more information, see the [.NET Core support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).

## Windows Forms

*Windows only*

> [!WARNING]
> There are breaking changes in Windows Forms.

Legacy controls were included in Windows Forms that have been unavailable in the Visual Studio Designer Toolbox for some time. These were replaced with new controls back in .NET Framework 2.0. These have been removed from the Desktop SDK for .NET Core 3.1

| Removed control | Recommended replacement | Associated APIs removed |
| --------------- | ----------------------- | ----------------------- |
| DataGrid        | DataGridView            | DataGridCell<br/>DataGridRow<br/>DataGridTableCollection<br/>DataGridColumnCollection<br/>DataGridTableStyle<br/>DataGridColumnStyle<br/>DataGridLineStyle<br/>DataGridParentRowsLabel<br/>DataGridParentRowsLabelStyle<br/>DataGridBoolColumn<br/>DataGridTextBox<br/>GridColumnStylesCollection<br/>GridTableStylesCollection<br/>HitTestType |
| ToolBar         | ToolStrip               | ToolBarAppearance |
| ToolBarButton   | ToolStripButton         | ToolBarButtonClickEventArgs<br/>ToolBarButtonClickEventHandler<br/>ToolBarButtonStyle<br/>ToolBarTextAlign |
| ContextMenu     | ContextMenuStrip        |  |
| :::no-loc text="Menu":::            | ToolStripDropDown<br/>ToolStripDropDownMenu | MenuItemCollection |
| MainMenu        | MenuStrip               |  |
| MenuItem        | ToolStripMenuItem       |  |

We recommend you update your applications to .NET Core 3.1 and move to the replacement controls. Replacing the controls is a straight-forward process, essentially "find and replace" on the type.

## C++/CLI

*Windows only*

Support has been added for creating C++/CLI (also known as "managed C++") projects. Binaries produced from these projects are compatible with .NET Core 3.0 and above.

To add support for C++/CLI in Visual Studio 2019 16.4, install the **Desktop development with C++** workload. This workload adds two templates to Visual Studio:

- CLR Class Library (.NET Core)
- CLR Empty Project (.NET Core)

## Next steps

- [Review the breaking changes between .NET Core 3.0 and 3.1.](../compatibility/3.0-3.1.md)
- [Review the breaking changes between .NET Framework and .NET Core 3.0 for Windows Forms apps.](../porting/winforms-breaking-changes.md)
