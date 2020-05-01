---
title: "Windows Forms Accessibility Improvements"
description: Learn about the ways in which .NET Core Windows Forms attempts to improve accessibility in comparison with .NET Framework Windows Forms.
ms.date: "04/20/2020"
helpviewer_keywords: 
  - "Windows Forms accessibility"
  - "accessibility"
author: "M-Lipin"
---
# Accessibility improvements in Windows Forms controls for .NET Core 3.0

Windows Forms is continuing to improve how it works with accessibility technologies to better support Windows Forms customers. These improvements include the following changes:

- Changes in various areas of interaction with accessibility client applications, including Narrator.
- Changes in the Accessible hierarchy (improving navigation through the UI Automation tree).
- Changes in keyboard navigation.

> [!IMPORTANT]
> Accessibility changes made in .NET Framework 4.7.1 through .NET Framework 4.8 are included in .NET Core 3.0 and above, and are enabled by default. The .NET Framework supported compatibility switches that allowed applications to opt out of the new accessibility behavior. On the other hand, .NET Core doesn't support these settings and doesn't allow applications to opt out of accessibility behavior.
  
Starting with .NET Core 3.0, Windows Forms applications benefit from all the new accessibility features (introduced in .NET Framework 4.7.1 - 4.8) without additional configuration.

## ListBox Accessibility support

The following changes apply to the <xref:System.Windows.Forms.ListBox> control:

- Enabled UI Automation support for `ListBox` control.
- Improved `ListBox` accessibility support by adding the <xref:System.Windows.Automation.ScrollItemPattern> to `ListBox` items and by enhancing the accessibility event raising and handling and Narrator navigation through the items (caps lock navigation isn't correct and doesn't throw the navigation outside the control unintentionally).

## CheckedListBox Accessibility support

The following changes apply to the <xref:System.Windows.Forms.CheckedListBox> control:

- Corrected `CheckedListBox` Bounds provided by accessibility properties for entries.
- Improved overall `ListBox` and `CheckedListBox` accessibility: corrected property values and event model.

## ComboBox Accessibility support

The following changes apply to the <xref:System.Windows.Forms.ComboBox> control:

- Updated the process of getting `ComboBox` items' accessibility objects to enable generating IDs for items instead of getting hash codes from items, which may be unsafe in case the <xref:System.Object.GetHashCode%2A> function is overridden.

## DataGridView Accessibility support

The following changes apply to the <xref:System.Windows.Forms.DataGridView> control:

- Corrected `DataGridView.Bounds` provided by accessibility properties for columns, rows, cells and corresponding headers, improved performance of bounding rectangle calculation. All accessibility bounds are represented correctly taking into account the bounds of entire control, along with its viewport.
- Corrected `Value.IsReadOnly` property value providing for accessible client applications. The property now shows correct `IsReadOnly` status for cells.
- Fixed the issue with <xref:System.Windows.Forms.DataGridView.CellParsing> event raising for the first cell change. Cell value can be changed without any issues including the first `DataGridView` control interaction.
- Improved `DataGridView` background color contrast when using Windows High Contrast themes. Changed `DataGridView` default back color when using HC#1, HC#2, and HC Black themes.

## PropertyGrid Accessibility support

The following changes apply to the <xref:System.Windows.Forms.PropertyGrid> control:

- Corrected `PropertyGrid.Bounds` provided by accessibility properties for grid entries, improved performance of bounding rectangle calculation. For now all accessibility bounds are represented correctly taking into account the bounds of entire control, along with its viewport.
- Corrected accessible names and descriptions of subcontrols to not include control type names and to avoid double announcement for control type names.

## ToolStrip Accessibility support

The following changes apply to the <xref:System.Windows.Forms.ToolStrip> control:

- Improved navigation through `ToolStrip`, `MenuStrip`, and `StatusStrip` items. Corrected `ToolStrip` and `MenuStrip` shift-tab navigation, back-looping the menu items when shift-tab up-arrow is pressed, which navigates to the bottom menu element.
- Improved `MenuStrip` accessible navigation, corrected menu accessible control types for submenus to make submenus of type 'Menu' instead of 'MenuItem'.

## PrintPreviewControl and PrintPreviewDialog Accessibility support

The following changes apply to the print controls:

- Improved accessible navigation (including Narrator navigation) through menu items.
- Improved High Contrast themes support and made the control element more contrasted.

## StringCollectionEditor Accessibility support

Windows Forms designer now uses the string collection editor with improved accessibility support.

## MonthCalendar Accessibility support (available in .NET Core 3.1)

The following changes apply to the <xref:System.Windows.Forms.MonthCalendar> control:

- Added UI Automation server providers to `MonthCalendar` control, added UI Automation Grid pattern and Table pattern providers.
- Changed _table_ accessible control type to _calendar_ accessible control type for `MonthCalendar` except the case when the control has a preceding label control that defines `MonthCalendar` control accessible name, in this specific case accessible control type becomes _table_.
- Improved announcement of selected date for `MonthCalendar` control.
- Improved `MonthCalendar` control support for screen readers and other accessibility tools. At this moment, users can navigate the control elements and interact with these elements using keyboard-only input. With Narrator, use CAPS + arrow keys to navigation through the control elements and CAPS + Enter to invoke element default action.
- Improved arrow key navigation across `MonthCalendar` child elements with a focusing rectangle: blue focus rectangle for Narrator.
- Improved accessibility for hit test action for `MonthCalendar` control elements to allow getting `MonthCalendar` child accessible element by provided coordinates.

## ToolTips accessibility (available in .NET Core 3.1)

- Added ability to announce a tooltip text by screen reader applications such as NVDA and Narrator. Screen reader application can now announce the text of keyboard or mouse tooltip of any Windows Forms control that configured to show tooltips.

## UI automation support for DataGridView, PropertyGrid, ListBox, ComboBox, ToolStrip, and other controls

UI Automation support is enabled for controls at runtime but isn't used during design time. For an overview of UI automation, see the [UI Automation Overview](https://docs.microsoft.com/dotnet/framework/ui-automation/ui-automation-overview).

## See also

- [Accessibility Best Practices](../ui-automation/accessibility-best-practices.md).
