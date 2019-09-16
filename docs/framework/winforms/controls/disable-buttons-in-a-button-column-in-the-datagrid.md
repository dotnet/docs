---
title: "How to: Disable Buttons in a Button Column in the Windows Forms DataGridView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data grids [Windows Forms], disabling buttons"
  - "buttons [Windows Forms], disabling in button columns"
  - "DataGridView control [Windows Forms], disabling button cells"
ms.assetid: 5c344d01-013a-4a6b-8f8d-62ec9321d81e
---
# How to: Disable Buttons in a Button Column in the Windows Forms DataGridView Control
The <xref:System.Windows.Forms.DataGridView> control includes the <xref:System.Windows.Forms.DataGridViewButtonCell> class for displaying cells with a user interface (UI) like a button. However, <xref:System.Windows.Forms.DataGridViewButtonCell> does not provide a way to disable the appearance of the button displayed by the cell.  
  
 The following code example demonstrates how to customize the <xref:System.Windows.Forms.DataGridViewButtonCell> class to display buttons that can appear disabled. The example defines a new cell type, `DataGridViewDisableButtonCell`, that derives from <xref:System.Windows.Forms.DataGridViewButtonCell>. This cell type provides a new `Enabled` property that can be set to `false` to draw a disabled button in the cell. The example also defines a new column type, `DataGridViewDisableButtonColumn`, that displays `DataGridViewDisableButtonCell` objects. To demonstrate this new cell and column type, the current value of each <xref:System.Windows.Forms.DataGridViewCheckBoxCell> in the parent <xref:System.Windows.Forms.DataGridView> determines whether the `Enabled` property of the `DataGridViewDisableButtonCell` in the same row is `true` or `false`.  
  
> [!NOTE]
> When you derive from <xref:System.Windows.Forms.DataGridViewCell> or <xref:System.Windows.Forms.DataGridViewColumn> and add new properties to the derived class, be sure to override the `Clone` method to copy the new properties during cloning operations. You should also call the base class's `Clone` method so that the properties of the base class are copied to the new cell or column.  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridView.DisabledButtons#0](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.DisabledButtons/CS/form1.cs#0)]
 [!code-vb[System.Windows.Forms.DataGridView.DisabledButtons#0](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.DisabledButtons/VB/form1.vb#0)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing, System.Windows.Forms and System.Windows.Forms.VisualStyles assemblies.  
  
## See also

- [Customizing the Windows Forms DataGridView Control](customizing-the-windows-forms-datagridview-control.md)
- [DataGridView Control Architecture](datagridview-control-architecture-windows-forms.md)
- [Column Types in the Windows Forms DataGridView Control](column-types-in-the-windows-forms-datagridview-control.md)
