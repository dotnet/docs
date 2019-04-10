---
title: "How to: Set the Selection Mode of the Windows Forms DataGridView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "selection [Windows Forms], modes in DataGridView control"
  - "DataGridView control [Windows Forms], selection mode"
  - "data grids [Windows Forms], selection mode"
ms.assetid: 2f241643-7f82-4583-8757-03494f63b465
---
# How to: Set the Selection Mode of the Windows Forms DataGridView Control
The following code example demonstrates how to configure a <xref:System.Windows.Forms.DataGridView> control so that clicking anywhere within a row automatically selects the entire row, and so that only one row at a time can be selected.  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewMisc#065](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#065)]
 [!code-vb[System.Windows.Forms.DataGridViewMisc#065](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#065)]  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
-   References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.MultiSelect%2A>
- <xref:System.Windows.Forms.DataGridView.SelectionMode%2A>
- <xref:System.Windows.Forms.DataGridViewSelectionMode>
- [Selection and Clipboard Use with the Windows Forms DataGridView Control](selection-and-clipboard-use-with-the-windows-forms-datagridview-control.md)
- [Selection Modes in the Windows Forms DataGridView Control](selection-modes-in-the-windows-forms-datagridview-control.md)
