---
title: "How to: Bind Objects to Windows Forms DataGridView Controls"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], object binding"
  - "data grids [Windows Forms], object binding"
  - "object binding [Windows Forms], DataGridView control"
ms.assetid: cb8f29fa-577e-4e2b-883f-3a01c6189b9c
---
# How to: Bind Objects to Windows Forms DataGridView Controls
The following code example demonstrates how to bind a collection of objects to a <xref:System.Windows.Forms.DataGridView> control so that each object displays as a separate row. This example also illustrates how to display a property with an enumeration type in a <xref:System.Windows.Forms.DataGridViewComboBoxColumn> so that the combo box drop-down list contains the enumeration values.  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridView._CollectionBound#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView._CollectionBound/CS/collectionbound.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridView._CollectionBound#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView._CollectionBound/VB/collectionbound.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- [Displaying Data in the Windows Forms DataGridView Control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [How to: Access Objects Bound to Windows Forms DataGridView Rows](how-to-access-objects-bound-to-windows-forms-datagridview-rows.md)
