---
title: "Default Functionality in the Windows Forms DataGridView Control"
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
  - "data grids [Windows Forms], default functionality in DataGridView control"
  - "DataGridView control [Windows Forms], default functionality"
ms.assetid: 4405f697-cad1-4839-9bcd-8ddb09d9f00e
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Default Functionality in the Windows Forms DataGridView Control
The Windows Forms <xref:System.Windows.Forms.DataGridView> control provides users with a significant amount of default functionality.  
  
## Default Functionality  
 By default, a <xref:System.Windows.Forms.DataGridView> control:  
  
-   Automatically displays column headers and row headers that remain visible as the table scrolls vertically.  
  
-   Has a row header that contains a selection indicator for the current row.  
  
-   Has a selection rectangle in the first cell.  
  
-   Has columns that can be automatically resized when the user double-clicks the column dividers.  
  
-   Automatically supports visual styles on Windows XP and the Windows Server 2003 family when the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method is called from the application's `Main` method.  
  
 Additionally, the contents of a <xref:System.Windows.Forms.DataGridView> control can be edited by default:  
  
-   If the user double-clicks or presses F2 in a cell, the control automatically puts the cell into edit mode and updates the contents of the cell as the user types.  
  
-   If the user scrolls to the end of the grid, the user will see that a row for adding new records is present. When the user clicks this row, a new row is added to the <xref:System.Windows.Forms.DataGridView> control, with default values. When the user presses ESC, this new row disappears.  
  
-   If the user clicks a row header, the whole row is selected.  
  
 When you bind a <xref:System.Windows.Forms.DataGridView> control to a data source by setting its <xref:System.Windows.Forms.DataGridView.DataSource%2A> property, the control:  
  
-   Automatically uses the names of the data source's columns as the column header text.  
  
-   Is populated with the contents of the data source. <xref:System.Windows.Forms.DataGridView> columns are automatically created for each column in the data source.  
  
-   Creates a row for each visible row in the table.  
  
-   Automatically sorts the rows based on the underlying data when the user clicks a column header.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)
