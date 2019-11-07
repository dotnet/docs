---
title: "Windows Forms Accessibility Improvements"
ms.date: "08/16/2019"
helpviewer_keywords: 
  - "Windows Forms accessibility"
  - "accessibility"
author: "M-Lipin"
---
# Accessibility improvements in Windows Forms controls for .NET Core 3.0

Windows Forms is continuing to improve how it works with accessibility technologies to better support Windows Forms customers. These include the following changes:
- Changes in various areas of interaction with accessibility client applications, including Narrator.
- Changes in the Accessible hierarchy (improving navigation through the UI Automation tree).
- Changes in keyboard navigation.

- [x] The quirks which were used in .NET Framework 4.7.1 - 4.8 to opt-in/out new accessibility features have been removed, so previously quirked behavior is now enabled by default.

### Recommended Action
__The changes which could be opted in or out in .NET Framework 4.7.1 - 4.8 are now enabled by default and cannot be opted out__
  
Starting with .NET Core 3.0, Windows Forms applications benefit from all the new accessibility features (introduced in .NET Framework 4.7.1 - 4.8) without additional configuration.

## Improved ListBox Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.ListBox control:
- Enabled UIA support for ListBox control.
- Improved ListBox accessibility support by adding the ScrollItem pattern to ListBox items and by enhancing the accessibility event raising and handling and Narrator navigation through the items (caps lock navigation is not correct and does not throw the navigation outside the control unintentionally).

## Improved CheckedListBox Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.CheckedListBox control:
- Corrected CheckedListBox Bounds provided by accessibility properties for entries. Improved overall ListBox and CheckedListBox accessibility (corrected pproperty values and event model).

## Improved ComboBox Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.ComboBox control:
- Updated the process of getting ComboBox items' accessibility objects to enable generating IDs for items instead of getting hash codes from items which may be unsafe in case of GetHashCode function is overriden.

## Improved DataGridView Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.DataGridView control:
- Corrected DataGridView Bounds provided by accessibility properties for columns, rows, cells and corresponding headers, improved performance of bounding rectangle calculation. For now all accessibility bounds are represented correctly taking into account the bounds of entire control, its viewport and scrolls.
- Corrected Value.IsReadOnly property value providing for accessible client applications. The property now shows correct IsReadOnly status for cells.
- Fixed the issue with CellParsing event raising for the very first cell change. Cell value is now can be changed without any issues including the very first DataGridView control interaction.
- Improved DataGridView background color contrast when using Windows High Contrast themes. Changed DataGridView default back color when using HC#1, HC#2, and HC Black themes.

## Improved PropertyGrid Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.PropertyGrid control:
- Corrected PropertyGrid Bounds provided by accessibility properties for grid entries, improved performance of bounding rectangle calculation. For now all accessibility bounds are represented correctly taking into account the bounds of entire control, its viewport and scrolls.
- Corrected accessible names and descriptions of subcontrols to not include control type names and to avoid double announcement for control type names.

## Improved ToolStrip Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.ToolStrip control:
- Improved navigation through ToolStrip items. Corrected ToolStrip and Menu shift-tab navigation (back-looping the menu items when shift-tab up-arrow is pressed - navigate to the bottom menu element)
- Improved Menu accessible navigation, corrected menu accessible control types for submenus to make submenus of type 'Menu' instead of 'MenuItem'.

## Improved PrintPreviewControl and PrintPreviewDialog Accessibility support
On .NET Core, Windows Forms includes the following changes that affect the print controls:
- Improved accessible navigation (including Narrator navigation) through menu items.
- Improved High Contrast themes support and made the control element more contrasted.

## StringCollectionEditor Accessibility support
On .NET Core, Windows Forms gets StringCollectionEditor with improved accessibility support.

## Improved MonthCalendar Accessibility support (available in .NET Core 3.1)
On .NET Core, Windows Forms includes the following changes that affect the xref:System.Windows.Forms.MonthCalendar control:
- Added UI Automation server providers to MonthCalendar control, added UI Automation Grid pattern and Table pattern providers.
- Changed _table_ accessible control type to _calendar_ accessible control type for MonthCalendar except the case when the control has a preceeding label control which defines MonthCalendar control accessible name, in this specific case accessible control type becomes _table_.
- Improved announcement of selected date for MonthCalendar control.
- Improved MounthCalendar control support for screen readers and other accessibility tools. At this moment users are able to navigate the control elements and interact with these elements using keyboard only input (For Narrator: ca use CAPS + arrow keys to navigation thru the control elements and CAPS + Enter to invoke element default action). Improved arrow key navigation across MonthCalendar child elements accompanied with focusing rectangle (blue focus rectangle for Narrator).
- Improved accessibility for hit test action for MonthCalendar control elements to allow getting MonthCalendar child accessible element by provided coordinates.

## Improved ToolTips accessibility (available in .NET Core 3.1)
- Added ability to announce a tooltip text by screen reader applications (NVDA/Narrator). Screen reader application can now announce the text of keyboard or mouse tooltip of any WinForms control that configured to show tooltip/s.

## UI automation support for DataGridView, PropertyGrid, ListBox, ComboBox, ToolStrip and other controls
Note: UI automation support is enabled for controls in runtime but is not used in design time.
For an overview of UI automation, see the [UI Automation Overview](https://docs.microsoft.com/dotnet/framework/ui-automation/ui-automation-overview).
