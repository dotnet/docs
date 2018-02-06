---
title: "How to: Add ToolTips to Individual Cells in a Windows Forms DataGridView Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "tooltips [Windows Forms], adding to data grids"
  - "DataGridView control [Windows Forms], adding tooltips"
  - "data grids [Windows Forms], adding tooltips"
ms.assetid: 2a81f9de-d58b-4ea8-bc0b-8d93c2f4cf78
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add ToolTips to Individual Cells in a Windows Forms DataGridView Control
By default, ToolTips are used to display the values of <xref:System.Windows.Forms.DataGridView> cells that are too small to show their entire contents. You can override this behavior, however, to set ToolTip-text values for individual cells. This is useful to display to users additional information about a cell or to provide to users an alternate description of the cell contents. For example, if you have a row that displays status icons, you may want to provide text explanations using ToolTips.  
  
 You can also disable the display of cell-level ToolTips by setting the <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A?displayProperty=nameWithType> property to `false`.  
  
### To add a ToolTip to a cell  
  
-   Set the <xref:System.Windows.Forms.DataGridViewCell.ToolTipText%2A?displayProperty=nameWithType> property.  
  
     [!code-cpp[System.Windows.Forms.DataGridViewCell.ToolTipText#1](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCell.ToolTipText/cpp/datagridviewcell.tooltiptext.cpp#1)]
     [!code-csharp[System.Windows.Forms.DataGridViewCell.ToolTipText#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCell.ToolTipText/CS/datagridviewcell.tooltiptext.cs#1)]
     [!code-vb[System.Windows.Forms.DataGridViewCell.ToolTipText#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCell.ToolTipText/VB/datagridviewcell.tooltiptext.vb#1)]  
  
## Compiling the Code  
  
-   This example requires:  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1` that contains a column named `Rating` for displaying string values of one through four asterisk ("*") symbols. The <xref:System.Windows.Forms.DataGridView.CellFormatting> event of the control must be associated with the event handler method shown in the example.  
  
-   References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## Robust Programming  
 When you bind the <xref:System.Windows.Forms.DataGridView> control to an external data source or provide your own data source by implementing virtual mode, you might encounter performance issues. To avoid a performance penalty when working with large amounts of data, handle the <xref:System.Windows.Forms.DataGridView.CellToolTipTextNeeded> event rather than setting the <xref:System.Windows.Forms.DataGridViewCell.ToolTipText%2A> property of multiple cells. When you handle this event, getting the value of a cell <xref:System.Windows.Forms.DataGridViewCell.ToolTipText%2A> property raises the event and returns the value of the <xref:System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs.ToolTipText%2A?displayProperty=nameWithType> property as specified in the event handler.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.CellToolTipTextNeeded?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewCell>  
 <xref:System.Windows.Forms.DataGridViewCell.ToolTipText%2A?displayProperty=nameWithType>  
 [Programming with Cells, Rows, and Columns in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/programming-with-cells-rows-and-columns-in-the-datagrid.md)
