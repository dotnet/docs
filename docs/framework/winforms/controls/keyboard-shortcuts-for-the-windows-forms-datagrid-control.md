---
title: "Keyboard Shortcuts for the Windows Forms DataGrid Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "keyboard shortcuts [Windows Forms], DataGrid control"
  - "DataGrid control [Windows Forms], navigation keys"
ms.assetid: a01780f9-20d5-4f5f-808f-c790c9a007a5
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Keyboard Shortcuts for the Windows Forms DataGrid Control
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 The following table lists the keyboard shortcuts that can be used for navigation within the Windows Forms <xref:System.Windows.Forms.DataGrid> control:  
  
|Action|Shortcut|  
|------------|--------------|  
|Complete a cell entry and move down to the next cell.<br /><br /> If focus is on a child table link, navigate to that table.|ENTER|  
|Cancel cell editing if in cell edit mode.<br /><br /> If in marquee selection, cancel editing on the row.|ESC|  
|Delete the character before the insertion point when editing a cell.|BACKSPACE|  
|Delete the character after the insertion point when editing a cell.|DELETE|  
|Move to the first cell in the current row.|HOME|  
|Move to the last cell in the current row.|END|  
|Highlight characters in the current cell and position the insertion point at the end of the line. Same behavior as double-clicking a cell.|F2|  
|If focus is on a cell, move to the next cell in the row.<br /><br /> If focus is on the last cell in a row, move to the first child table link of the row and expand it.<br /><br /> If focus is on a child link, move to the next child link.<br /><br /> If focus is on the last child link, move to the first cell of the next row.|TAB|  
|If focus is on a cell, move to the previous cell in the row.<br /><br /> If focus is on the first cell in a row, move to the last expanded child table link of the previous row, or move to the last cell of the previous row.<br /><br /> If focus is on a child link, move to the previous child link.<br /><br /> If focus is on the first child link, move to the last cell of the previous row.|SHIFT+TAB|  
|Move to the next control in the tab order.|CTRL+TAB|  
|Move to the previous control in the tab order.|CTRL+SHIFT+TAB|  
|Move up to the parent table if in a child table. Same behavior as clicking the Back button.|ALT+LEFT ARROW|  
|Expand child table links. ALT+DOWN ARROW expands all links, not just the ones selected.|ALT+DOWN ARROW or CTRL+PLUS SIGN|  
|Collapse child table links. ALT+UP ARROW collapses all links, not just the ones selected.|ALT+UP ARROW or CTRL+MINUS SIGN|  
|Move to the farthest nonblank cell in the direction of the arrow.|CTRL+ARROW|  
|Extend the selection one row in the direction of the arrow (excluding child table links).|SHIFT+UP/DOWN ARROW|  
|Extend the selection to farthest nonblank row in the direction of the arrow (excluding child table links).|CTRL+SHIFT+ UP/DOWN ARROW|  
|Move to the upper-left cell.|CTRL+HOME|  
|Move to the lower-right cell.|CTRL+END|  
|Extend the selection to the top row.|CTRL+SHIFT+HOME|  
|Extend the selection to the bottom row.|CTRL+SHIFT+END|  
|Select the current row (excluding child table links).|SHIFT+SPACEBAR|  
|Select the entire grid (excluding child table links).|CTRL+A|  
|Display the parent row when in a child table.|CTRL+PAGE DOWN|  
|Hide the parent row when in a child table.|CTRL+PAGE UP|  
|Extend the selection down one screen (excluding child table links).|SHIFT+PAGE DOWN|  
|Extend the selection up one screen (excluding child table links).|SHIFT+PAGE UP|  
|Call the <xref:System.Windows.Forms.DataGrid.EndEdit%2A> method for the current row.|CTRL+ENTER|  
|Enter a <xref:System.DBNull.Value?displayProperty=nameWithType> value into a cell when in edit mode.|CTRL+0|  
  
## See Also  
 [DataGrid Control Overview](../../../../docs/framework/winforms/controls/datagrid-control-overview-windows-forms.md)  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)
