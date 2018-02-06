---
title: "Resizing Columns and Rows in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], sizing rows and columns"
  - "columns [Windows Forms], resizing in grids"
  - "data grids [Windows Forms], resizing columns and rows"
ms.assetid: 7532764d-e5c1-4943-a08b-6377a722d3b6
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Resizing Columns and Rows in the Windows Forms DataGridView Control
The `DataGridView` control provides numerous options for customizing the sizing behavior of its columns and rows. Typically, `DataGridView` cells do not resize based on their contents. Instead, they clip any display value that is larger than the cell. If the content can be displayed as a string, the cell displays it in a ToolTip.  
  
 By default, users can drag row, column, and header dividers with the mouse to show more information. Users can also double-click a divider to automatically resize the associated row, column, or header band based on its contents.  
  
 The `DataGridView` control provides properties, methods, and events that enable you to customize or disable all of these user-directed behaviors. Additionally, you can programmatically resize rows, columns, and headers to fit their contents, or you can configure them to automatically resize themselves whenever their contents change. You can also configure columns to automatically divide the available width of the control in proportions that you specify.  
  
## In This Section  
 [Sizing Options in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sizing-options-in-the-windows-forms-datagridview-control.md)  
 Describes the options for sizing rows, columns, and headers. Also provides details on sizing-related properties and methods, and describes common usage scenarios.  
  
 [Column Fill Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control.md)  
 Describes column fill mode in detail, and provides demonstration code that you can use to experiment with column fill mode and other modes.  
  
 [How to: Set the Sizing Modes of the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-the-sizing-modes-of-the-windows-forms-datagridview-control.md)  
 Describes how to configure the sizing modes for common purposes.  
  
 [How to: Programmatically Resize Cells to Fit Content in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/programmatically-resize-cells-to-fit-content-in-the-datagrid.md)  
 Provides demonstration code that you can use to experiment with programmatic resizing.  
  
 [How to: Automatically Resize Cells When Content Changes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/automatically-resize-cells-when-content-changes-in-the-datagrid.md)  
 Provides demonstration code that you can use to experiment with automatic sizing modes.  
  
## Reference  
 <xref:System.Windows.Forms.DataGridView>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridView> control.  
  
## See Also  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)
