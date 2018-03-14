---
title: "How to: Get and Set the Current Cell in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], getting current cell"
  - "DataGridView control [Windows Forms], setting current cell"
  - "cells [Windows Forms], getting and setting current"
ms.assetid: b0e41e57-493a-4bd0-9376-a6f76723540c
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Get and Set the Current Cell in the Windows Forms DataGridView Control
Interaction with the <xref:System.Windows.Forms.DataGridView> often requires that you programmatically discover which cell is currently active. You may also need to change the current cell. You can perform these tasks with the <xref:System.Windows.Forms.DataGridView.CurrentCell%2A> property.  
  
> [!NOTE]
>  You cannot set the current cell in a row or column that has its <xref:System.Windows.Forms.DataGridViewBand.Visible%2A> property set to `false`.  
  
 Depending on the <xref:System.Windows.Forms.DataGridView> control's selection mode, changing the current cell can change the selection. For more information, see [Selection Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/selection-modes-in-the-windows-forms-datagridview-control.md).  
  
### To get the current cell programmatically  
  
-   Use the <xref:System.Windows.Forms.DataGridView> control's <xref:System.Windows.Forms.DataGridView.CurrentCell%2A> property.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#080](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#080)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#080](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#080)]  
  
### To set the current cell programmatically  
  
-   Set the <xref:System.Windows.Forms.DataGridView.CurrentCell%2A> property of the <xref:System.Windows.Forms.DataGridView> control. In the following code example, the current cell is set to row 0, column 1.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#085](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#085)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#085](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#085)]  
  
## Compiling the Code  
 This example requires:  
  
-   <xref:System.Windows.Forms.Button> controls named `getCurrentCellButton` and `setCurrentCellButton`. In [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], you must attach the <xref:System.Windows.Forms.Control.Click> events for each button to the associated event handler in the example code.  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
-   References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.CurrentCell%2A?displayProperty=nameWithType>  
 [Basic Column, Row, and Cell Features in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/basic-column-row-and-cell-features-wf-datagridview-control.md)  
 [Selection Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/selection-modes-in-the-windows-forms-datagridview-control.md)
