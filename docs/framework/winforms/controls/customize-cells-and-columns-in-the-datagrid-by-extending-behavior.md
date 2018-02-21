---
title: "How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance"
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
  - "DataGridView control [Windows Forms], cell customization"
  - "columns [Windows Forms], customizing in DataGridView control"
  - "cells [Windows Forms], customizing in DataGridView control"
ms.assetid: 9b7dc7b6-5ce6-4566-9949-902f74f17a81
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance
The <xref:System.Windows.Forms.DataGridView> control provides a number of ways to customize its appearance and behavior using properties, events, and companion classes. Occasionally, you may have requirements for your cells that go beyond what these features can provide. You can create your own custom <xref:System.Windows.Forms.DataGridViewCell> class to provide extended functionality.  
  
 You create a custom <xref:System.Windows.Forms.DataGridViewCell> class by deriving from the <xref:System.Windows.Forms.DataGridViewCell> base class or one of its derived classes. Although you can display any type of cell in any type of column, you will typically also create a custom <xref:System.Windows.Forms.DataGridViewColumn> class specialized for displaying your cell type. Column classes derive from <xref:System.Windows.Forms.DataGridViewColumn> or one of its derived types.  
  
 In the following code example, you will create a custom cell class called `DataGridViewRolloverCell` that detects when the mouse enters and leaves the cell boundaries. While the mouse is within the cell's bounds, an inset rectangle is drawn. This new type derives from <xref:System.Windows.Forms.DataGridViewTextBoxCell> and behaves in all other respects as its base class. The companion column class is called `DataGridViewRolloverColumn`.  
  
 To use these classes, create a form containing a <xref:System.Windows.Forms.DataGridView> control, add one or more `DataGridViewRolloverColumn` objects to the <xref:System.Windows.Forms.DataGridView.Columns%2A> collection, and populate the control with rows containing values.  
  
> [!NOTE]
>  This example will not work correctly if you add empty rows. Empty rows are created, for example, when you add rows to the control by setting the <xref:System.Windows.Forms.DataGridView.RowCount%2A> property. This is because the rows added in this case are automatically shared, which means that `DataGridViewRolloverCell` objects are not instantiated until you click on individual cells, thereby causing the associated rows to become unshared.  
  
 Because this type of cell customization requires unshared rows, it is not appropriate for use with large data sets. For more information about row sharing, see [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md).  
  
> [!NOTE]
>  When you derive from <xref:System.Windows.Forms.DataGridViewCell> or <xref:System.Windows.Forms.DataGridViewColumn> and add new properties to the derived class, be sure to override the `Clone` method to copy the new properties during cloning operations. You should also call the base class's `Clone` method so that the properties of the base class are copied to the new cell or column.  
  
### To customize cells and columns in the DataGridView control  
  
1.  Derive a new cell class, called `DataGridViewRolloverCell`, from the <xref:System.Windows.Forms.DataGridViewTextBoxCell> type.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#201](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#201)]
     [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#201](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#201)]  
    [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#202](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#202)]
    [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#202](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#202)]  
  
2.  Override the <xref:System.Windows.Forms.DataGridViewTextBoxCell.Paint%2A> method in the `DataGridViewRolloverCell` class. In the override, first call the base class implementation, which handles the hosted text box functionality. Then use the control's <xref:System.Windows.Forms.Control.PointToClient%2A> method to transform the cursor position (in screen coordinates) to the <xref:System.Windows.Forms.DataGridView> client area's coordinates. If the mouse coordinates fall within the bounds of the cell, draw the inset rectangle.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#210](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#210)]
     [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#210](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#210)]  
  
3.  Override the <xref:System.Windows.Forms.DataGridViewCell.OnMouseEnter%2A> and <xref:System.Windows.Forms.DataGridViewCell.OnMouseLeave%2A> methods in the `DataGridViewRolloverCell` class to force cells to repaint themselves when the mouse pointer enters or leaves them.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#220](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#220)]
     [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#220](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#220)]  
  
4.  Derive a new class, called `DataGridViewRolloverCellColumn`, from the <xref:System.Windows.Forms.DataGridViewColumn> type. In the constructor, assign a new `DataGridViewRolloverCell` object to its <xref:System.Windows.Forms.DataGridViewColumn.CellTemplate%2A> property.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#300](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#300)]
     [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#300](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#300)]  
  
## Example  
 The complete code example includes a small test form that demonstrates the behavior of the custom cell type.  
  
 [!code-csharp[System.Windows.Forms.DataGridViewRolloverCell#000](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/CS/rollovercell.cs#000)]
 [!code-vb[System.Windows.Forms.DataGridViewRolloverCell#000](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewRolloverCell/VB/rollovercell.vb#000)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Windows.Forms, and System.Drawing assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewCell>  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 [Customizing the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customizing-the-windows-forms-datagridview-control.md)  
 [DataGridView Control Architecture](../../../../docs/framework/winforms/controls/datagridview-control-architecture-windows-forms.md)  
 [Column Types in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control.md)  
 [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md)
