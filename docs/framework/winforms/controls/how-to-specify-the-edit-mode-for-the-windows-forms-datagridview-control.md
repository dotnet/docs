---
title: "How to: Specify the Edit Mode for the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], edit mode"
  - "data grids [Windows Forms], edit mode"
ms.assetid: 93e117e8-94c4-411b-ba31-645e475ed85c
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Specify the Edit Mode for the Windows Forms DataGridView Control
By default, users can edit the contents of the current <xref:System.Windows.Forms.DataGridView> text box cell by typing in it or pressing F2. This puts the cell in edit mode if all of the following conditions are met:  
  
-   The underlying data source supports editing.  
  
-   The <xref:System.Windows.Forms.DataGridView> control is enabled.  
  
-   The <xref:System.Windows.Forms.DataGridView.EditMode%2A> property value is not <xref:System.Windows.Forms.DataGridViewEditMode.EditProgrammatically>.  
  
-   The `ReadOnly` properties of the cell, row, column, and control are all set to `false`.  
  
 In edit mode, the user can change the cell value and press ENTER to commit the change or ESC to revert the cell to its original value.  
  
 You can configure a <xref:System.Windows.Forms.DataGridView> control so that a cell enters edit mode as soon as it becomes the current cell. The behavior of the ENTER and ESC keys is unchanged in this case, but the cell remains in edit mode after the value is committed or reverted. You can also configure the control so that cells enter edit mode only when users type in the cell or only when users press F2. Finally, you can prevent cells from entering edit mode except when you call the <xref:System.Windows.Forms.DataGridView.BeginEdit%2A> method.  
  
### To change the edit mode of a DataGridView control  
  
-   Set the <xref:System.Windows.Forms.DataGridView.EditMode%2A?displayProperty=nameWithType> property to the appropriate <xref:System.Windows.Forms.DataGridViewEditMode> enumeration.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#067](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#067)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#067](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#067)]  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
-   References to the <xref:System> and <xref:System.Windows.Forms> assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.EditMode%2A?displayProperty=nameWithType>  
 [Data Entry in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-entry-in-the-windows-forms-datagridview-control.md)
