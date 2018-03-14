---
title: "How to: Freeze Columns in the Windows Forms DataGridView Control"
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
helpviewer_keywords: 
  - "columns [Windows Forms], freezing"
  - "DataGridView control [Windows Forms], freezing columns"
  - "DataGridView control [Windows Forms], columns always in view"
ms.assetid: 2ef8b1de-782e-4867-af8d-58171ab5c106
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Freeze Columns in the Windows Forms DataGridView Control
When users view data displayed in a Windows Forms <xref:System.Windows.Forms.DataGridView> control, they sometimes need to refer to a single column or set of columns frequently. For example, when displaying a table of customer information that contains many columns, it is useful to display the customer name at all times while enabling other columns to scroll outside the visible region.  
  
 To achieve this behavior, you can freeze columns in the control. When you freeze a column, all the columns to its left (or to its right in right-to-left language scripts) are frozen as well. Frozen columns remain in place while all other columns can scroll.  
  
> [!NOTE]
>  If column reordering is enabled, the frozen columns are treated as a group distinct from the unfrozen columns. Users can reposition columns in either group, but they cannot move a column from one group to the other.  
  
 The <xref:System.Windows.Forms.DataGridViewColumn.Frozen%2A> property of a column determines whether the column is always visible within the grid.  
  
 There is support for this task in Visual Studio.  Also see [How to: Freeze Columns in the Windows Forms DataGridView Control Using the Designer](http://msdn.microsoft.com/library/717ss6s6\(v=vs.110\)).  
  
### To freeze a column programmatically  
  
-   Set the <xref:System.Windows.Forms.DataGridViewColumn.Frozen%2A?displayProperty=nameWithType> property to `true`.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#061](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#061)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#061](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#061)]  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1` that contains a column named `AddToCartButton`.  
  
-   References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridViewColumn.Frozen%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView>  
 [Basic Column, Row, and Cell Features in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/basic-column-row-and-cell-features-wf-datagridview-control.md)  
 [How to: Enable Column Reordering in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-enable-column-reordering-in-the-windows-forms-datagridview-control.md)
