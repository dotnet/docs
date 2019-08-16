---
title: "Windows Forms Accessibility Improvements"
ms.date: "08/16/2019"
helpviewer_keywords: 
  - "Windows Forms accessibility"
  - "accessibility"
ms.assetid: 
---
# Accessibility improvements in Windows Forms controls for .NET Core

## Scope
Major

## Version Introduced
.NET Core 3.0

## Change Description
The Windows Forms is continuing to improve how it works with accessibility technologies to better support Windows Forms customers. These include the following changes:
- Changes in various areas of interaction with accessibility client applications including Narrator.
- Changes in the Accessible hierarchy (improving navigation through the UI Automation tree).

- [x] The quirks which were used in .NET Framework 4.7.1 - 4.8 to opt-in/out new accessibility features have been removed, so previously quirked behavior is now enabled by default.

### Recommended Action
__The changes which could be opted in or out in .NET Framework 4.7.1 - 4.8 are now enabled by default and cannot be opted out__
  
Applications now benefit from all the new accessibility features (introduced in .NET Framework 4.7.1 - 4.8) without additional configuration.

__Improved ListBox Accessibility support__
- Enabled UIA support for ListBox control.
- Improved ListBox Accessibility support by adding the ScrollItem pattern to ListBox items and by enhancing the accessibility event raising and handling and Narrator navigation through the items (caps lock navigation is not correct and does not throw the navigation outside the control unintentionally).

__Improved CheckedListBox Accessibility support__
- Corrected CheckedListBox Bounds provided by accessibility properties for entries. Improved overall ListBox and CheckedListBox accessibility (corrected pproperty values and event model).

__Improved ComboBox Accessibility support__
- Updated the process of getting ComboBox items' accessibility objects to enable generating IDs for items instead of getting hash codes from items which maybe unsafe in case of GetHashCode function is overriden.

__Improved DataGridView Accessibility support__
- Corrected DataGridView Bounds provided by accessibility properties for columns, rows, cells and corresponding headers, imroved performance of bounding rectangle calculation. For now all accessibility bounds are represented correctly taking into account the bounds of entire control, its viewport and scrolls.
- Corrected Value.IsReadOnly property value providing for accessible client applications. The property now shows correct IsReadOnly status for cells.
- Fixed the issue with CellParsing event raising for the very first cell change. Cell value is now can be changed without any issues including the very first DataGridView control interaction.

__Improved PropertyGrid Accessibility support__
- Corrected PropertyGrid Bounds provided by accessibility properties for grid entries, imroved performance of bounding rectangle calculation. For now all accessibility bounds are represented correctly taking into account the bounds of entire control, its viewport and scrolls.
- Corrected accessible names and descriptions of subcontrols to not include control type names and to avoid double announcement for control type names.

__Improved Menu Accessibility support__
- Improved Menu accessible navigation, corrected menu accessible control types for submenus to make submenus of type 'Menu' instead of 'MenuItem'.

__Improved ToolStrip Accessibility support__
- Improved navigation through <xref:System.Windows.Forms.ToolStrip> items. Corrected ToolStrip and Menu shift-tab navigation (back-looping the menu items when shift-tab up-arrow is pressed - navigate to the bottom menu element)

__Improved PrintPreviewControl and PrintPreviewDialog Accessibility support__
- Improved accessible navigation (including Narrator navigation) through menu items.
- Improved High Contrast themes support and made the control element more contrasted.

__StringCollectionEditor Accessibility support__
- Added StringCollectionEditor with improved accessibility support.

__UI automation support for DataGridView, PropertyGrid, ListBox, ComboBox, ToolStrip and other controls__
Note: UI automation support is enabled for controls in runtime but is not used in design time.
For an overview of UI automation, see the [UI Automation Overview](https://docs.microsoft.com/dotnet/framework/ui-automation/ui-automation-overview).

 
### Affected APIs 
None

### Category
Windows Forms

<!--

WinForms Pulls:
#180 Ported three accessibility bug fixes from .NET 4.8
#400 Net FX 48 Accessibility Fixes port
#711 Accessibility: fixing DataGridView BoundingRectangle property for row, data cells and header cells
#754 Accessibility: removing accessibility quirks
#857 Accessibility: fixing BoundingRectangle property for PropertyGrid entries
#870 Replacing getting hash codes from ComboBox items with generating IDs for items
#1027 Accessibility: adding the ScrollItem pattern to ListBox items, fixing ListBox navigation by Narrator
#1055 Accessibility: Fixing ItemStatus property in programmatically sorted DataGridView
#1136 Accessibility: Fixing BoundingRectangle value for CheckedListBox entries
#1179 Accessibility: Fixing Name property of "Description” pane and "ToolBar" pane in PropertyGrid
#1284 Fix 1270 port `StringCollectionEditor`
#1301 Accessibility: Fixing ToolStrip shift-tab navigation
#1354 Fix 1353 Accessibility: Removing 'button' text from PrintButton accessible name of PrintPreviewDialog
#1398 Fix 1396 Accessibility: High Contrast - PrintPreview - The border of the PrintPreviewControl is inconsistent in the four themes of High Contrast AutoMerge
#1471 Fixing #1470: PageNumericUpDown accessible name is not correct
#1524 The CellParsing event of the datagridview can't be invoked when changing the value of the cell firstly #1098 AutoMerge tell-mode
#1592 Fixing DataGridViewCell AccessibleObject Value.IsReadOnly property a11yMAS tell-mode
#1594 Fixing menu control type and menu items navigation a11yMAS ask-mode

-->

<!-- breaking change id:  -->

