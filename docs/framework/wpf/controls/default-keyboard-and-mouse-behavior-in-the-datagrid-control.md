---
title: "Default Keyboard and Mouse Behavior in the DataGrid Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "DataGrid [WPF], keyboard behavior"
  - "DataGrid [WPF], mouse behavior"
  - "keyboard behavior [WPF], DataGrid"
  - "mouse behavior [WPF], DataGrid"
ms.assetid: 563b8854-ca39-4d97-8235-17eaa0f93c8d
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Default Keyboard and Mouse Behavior in the DataGrid Control
This topic describes how users can interact with the <xref:System.Windows.Controls.DataGrid> control by using the keyboard and mouse.  
  
 Typical interactions with the <xref:System.Windows.Controls.DataGrid> include navigation, selection, and editing. Selection behavior is affected by the <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> and <xref:System.Windows.Controls.DataGrid.SelectionUnit%2A> properties. The default values that cause the behavior described in this topic are <xref:System.Windows.Controls.DataGridSelectionMode.Extended?displayProperty=nameWithType> and <xref:System.Windows.Controls.DataGridSelectionUnit.FullRow?displayProperty=nameWithType>. Changing these values might cause behavior that is different from that described. When a cell is in edit mode, the editing control might override the standard keyboard behavior of the <xref:System.Windows.Controls.DataGrid>.  
  
## Default Keyboard Behavior  
 The following table lists the default keyboard behavior for the <xref:System.Windows.Controls.DataGrid>.  
  
|Key or key combination|Description|  
|----------------------------|-----------------|  
|DOWN ARROW|Moves the focus to the cell directly below the current cell. If the focus is in the last row, pressing the DOWN ARROW does nothing.|  
|UP ARROW|Moves the focus to the cell directly above the current cell. If the focus is in the first row, pressing the UP ARROW does nothing.|  
|LEFT ARROW|Moves the focus to the previous cell in the row. If the focus is in the first cell in the row, pressing the LEFT ARROW does nothing.|  
|RIGHT ARROW|Moves the focus to the next cell in the row. If the focus is in the last cell in the row, pressing the RIGHT ARROW does nothing.|  
|HOME|Moves the focus to the first cell in the current row.|  
|END|Moves the focus to the last cell in the current row.|  
|PAGE DOWN|If rows are not grouped, scrolls the control downward by the number of rows that are fully displayed. Moves the focus to the last fully displayed row without changing columns.<br /><br /> If rows are grouped, moves the focus to the last row in the <xref:System.Windows.Controls.DataGrid> without changing columns.|  
|PAGE UP|If rows are not grouped, scrolls the control upward by the number of rows that are fully displayed. Moves focus to the first displayed row without changing columns.<br /><br /> If rows are grouped, moves the focus to the first row in the <xref:System.Windows.Controls.DataGrid> without changing columns.|  
|TAB|Moves the focus to the next cell in the current row. If the focus is in the last cell of the row, moves the focus to the first cell in the next row. If the focus is in the last cell in the control, moves the focus to the next control in the tab order of the parent container.<br /><br /> If the current cell is in edit mode and pressing TAB causes focus to move away from the current row, any changes that were made to the row are committed before focus is changed.|  
|SHIFT+TAB|Moves the focus to the previous cell in the current row. If the focus is already in the first cell of the row, moves the focus to the last cell in the previous row. If the focus is in the first cell in the control, moves the focus to the previous control in the tab order of the parent container.<br /><br /> If the current cell is in edit mode and pressing TAB causes focus to move away from the current row, any changes that were made to the row are committed before focus is changed.|  
|CTRL+DOWN ARROW|Moves the focus to the last cell in the current column.|  
|CTRL+UP ARROW|Moves the focus to the first cell in the current column.|  
|CTRL+RIGHT ARROW|Moves the focus to the last cell in the current row.|  
|CTRL+LEFT ARROW|Moves the focus to the first cell in the current row.|  
|CTRL+HOME|Moves the focus to the first cell in the control.|  
|CTRL+END|Moves the focus to the last cell in the control.|  
|CTRL+PAGE DOWN|Same as PAGE DOWN.|  
|CTRL+PAGE UP|Same as PAGE UP.|  
|F2|If the <xref:System.Windows.Controls.DataGrid.IsReadOnly%2A?displayProperty=nameWithType> property is `false` and the <xref:System.Windows.Controls.DataGridColumn.IsReadOnly%2A?displayProperty=nameWithType> property is `false` for the current column, puts the current cell into cell edit mode.|  
|ENTER|Commits any changes to the current cell and row and moves the focus to the cell directly below the current cell. If the focus is in the last row, commits any changes without moving the focus.|  
|ESC|If the control is in edit mode, cancels the edit and reverts any changes that were made in the control. If the underlying data source implements <xref:System.ComponentModel.IEditableObject>, pressing ESC a second time cancels edit mode for the entire row.|  
|BACKSPACE|Deletes the character before the cursor when editing a cell.|  
|DELETE|Deletes the character after the cursor when editing a cell.|  
|CTRL+ENTER|Commits any changes to the current cell without moving the focus.|  
|CTRL+A|If <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, selects all rows in the <xref:System.Windows.Controls.DataGrid>.|  
  
## Selection Keys  
 If the <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> property is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, the navigation behavior does not change, but navigating with the keyboard while pressing SHIFT (including CTRL+SHIFT) will modify a multi-row selection. Before navigation starts, the control marks the current row as an anchor row. When you navigate while pressing SHIFT, the selection includes all rows between the anchor row and the current row.  
  
 The following selection keys modify multi-row selection.  
  
-   SHIFT+DOWN ARROW  
  
-   SHIFT+UP ARROW  
  
-   SHIFT+PAGE DOWN  
  
-   SHIFT+PAGE UP  
  
-   CTRL+SHIFT+DOWN ARROW  
  
-   CTRL+SHIFT+UP ARROW  
  
-   CTRL+SHIFT+HOME  
  
-   CTRL+SHIFT+END  
  
## Default Mouse Behavior  
 The following table lists the default mouse behavior for the <xref:System.Windows.Controls.DataGrid>.  
  
|Mouse action|Description|  
|------------------|-----------------|  
|Click an unselected row|Makes the clicked row the current row, and the clicked cell the current cell.|  
|Click the current cell|Puts the current cell into edit mode.|  
|Drag a column header cell|If the <xref:System.Windows.Controls.DataGrid.CanUserReorderColumns%2A?displayProperty=nameWithType> property is `true` and the <xref:System.Windows.Controls.DataGridColumn.CanUserReorder%2A?displayProperty=nameWithType> property is `true` for the current column, moves the column so that it can be dropped into a new position.|  
|Drag a column header separator|If the <xref:System.Windows.Controls.DataGrid.CanUserResizeColumns%2A?displayProperty=nameWithType> property is `true` and the <xref:System.Windows.Controls.DataGridColumn.CanUserResize%2A?displayProperty=nameWithType> property is `true` for the current column, resizes the column.|  
|Double-click a column header separator|If the <xref:System.Windows.Controls.DataGrid.CanUserResizeColumns%2A?displayProperty=nameWithType> property is `true` and the <xref:System.Windows.Controls.DataGridColumn.CanUserResize%2A?displayProperty=nameWithType> property is `true` for the current column, auto-sizes the column using the <xref:System.Windows.Controls.DataGridLength.Auto%2A> sizing mode.|  
|Click a column header cell|If the <xref:System.Windows.Controls.DataGrid.CanUserSortColumns%2A?displayProperty=nameWithType> property is `true` and the <xref:System.Windows.Controls.DataGridColumn.CanUserSort%2A?displayProperty=nameWithType> property is `true` for the current column, sorts the column.<br /><br /> Clicking the header of a column that is already sorted will reverse the sort direction of that column.<br /><br /> Pressing the SHIFT key while clicking multiple column headers will sort by multiple columns in the order clicked.|  
|CTRL+click a row|If <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, modifies a non-contiguous multi-row selection.<br /><br /> If the row is already selected, deselects the row.|  
|SHIFT+click a row|If <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, modifies a contiguous multi-row selection.|  
|Click a row group header|Expands or collapses the group.|  
|Click the Select All button at the top left corner of the <xref:System.Windows.Controls.DataGrid>|If <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, selects all rows in the <xref:System.Windows.Controls.DataGrid>.|  
  
## Mouse Selection  
 If the <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> property is set to <xref:System.Windows.Controls.DataGridSelectionMode.Extended>, clicking a row while pressing CTRL or SHIFT will modify a multi-row selection.  
  
 When you click a row while pressing CTRL, the row will change its selection state while all other rows retain their current selection state. Do this to select non-adjacent rows.  
  
 When you click a row while pressing SHIFT, the selection includes all rows between the current row and an anchor row located at the position of the current row prior to the click. Subsequent clicks while pressing SHIFT change the current row, but not the anchor row. Do this to select a range of adjacent rows.  
  
 CTRL+SHIFT can be combined to select non-adjacent ranges of adjacent rows. To do this, select the first range by using SHIFT+click as described earlier. After the first range of rows is selected, use CTRL+click to select the first row in the next range, and then click the last row in the next range while pressing CTRL+SHIFT.  
  
## See Also  
 <xref:System.Windows.Controls.DataGrid>  
 <xref:System.Windows.Controls.DataGrid.SelectionMode%2A>
