---
title: "How to: Ensure the Selected Row in a Child Table Remains at the Correct Position"
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
  - "master-details view"
  - "row position [Windows Forms]"
  - "parent/child view [Windows Forms]"
  - "resetting child position"
  - "data binding [.NET Framework], row selection"
  - "caching [.NET Framework], child position"
  - "child position"
  - "master/details view [Windows Forms]"
  - "child tables row selection"
  - "current child position"
ms.assetid: c5fa2562-43a4-46fa-a604-52d8526a87bd
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Ensure the Selected Row in a Child Table Remains at the Correct Position
Oftentimes when you work with data binding in Windows Forms, you will display data in what is called a parent/child or master/details view. This refers to a data-binding scenario where data from the same source is displayed in two controls. Changing the selection in one control causes the data displayed in the second control to change. For example, the first control might contain a list of customers and the second a list of orders related to the selected customer in the first control.  
  
 Starting with the .NET Framework version 2.0, when you display data in a parent/child view you might have to take extra steps to make sure that the currently selected row in the child table is not reset to the first row of the table. In order to do this, you will have to cache the child table position and reset it after the parent table changes. Typically the child reset occurs the first time a field in a row of the parent table changes.  
  
### To Cache the Current Child Position  
  
1.  Declare an integer variable to store the child list position and a Boolean variable to store whether to cache the child position.  
  
     [!code-csharp[System.Windows.Forms.CurrencyManagerReset#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/CS/Form1.cs#4)]
     [!code-vb[System.Windows.Forms.CurrencyManagerReset#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/VB/Form1.vb#4)]  
  
2.  Handle the <xref:System.Windows.Forms.CurrencyManager.ListChanged> event for the binding's <xref:System.Windows.Forms.CurrencyManager> and check for a <xref:System.ComponentModel.ListChangedType> of <xref:System.ComponentModel.ListChangedType.Reset>.  
  
3.  Check the current position of the <xref:System.Windows.Forms.CurrencyManager>. If it is greater than first entry in the list (typically 0), save it to a variable.  
  
     [!code-csharp[System.Windows.Forms.CurrencyManagerReset#2](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.CurrencyManagerReset#2](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/VB/Form1.vb#2)]  
  
4.  Handle the parent list's <xref:System.Windows.Forms.BindingManagerBase.CurrentChanged> event for the parent currency manager. In the handler, set the Boolean value to indicate it is not a caching scenario. If the <xref:System.Windows.Forms.BindingManagerBase.CurrentChanged> occurs, the change to the parent is a list position change and not an item value change.  
  
     [!code-csharp[System.Windows.Forms.CurrencyManagerReset#5](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/CS/Form1.cs#5)]
     [!code-vb[System.Windows.Forms.CurrencyManagerReset#5](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/VB/Form1.vb#5)]  
  
### To Reset the Child Position  
  
1.  Handle the <xref:System.Windows.Forms.BindingManagerBase.PositionChanged> event for the child binding's <xref:System.Windows.Forms.CurrencyManager>.  
  
2.  Reset the child table position to the cached position saved in the previous procedure.  
  
     [!code-csharp[System.Windows.Forms.CurrencyManagerReset#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.CurrencyManagerReset#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/VB/Form1.vb#3)]  
  
## Example  
 The following example demonstrates how to save the current position on the <xref:System.Windows.Forms.CurrencyManager>.for a child table and reset the position after an edit is completed on the parent table. This example contains two <xref:System.Windows.Forms.DataGridView> controls bound to two tables in a <xref:System.Data.DataSet> using a <xref:System.Windows.Forms.BindingSource> component. A relation is established between the two tables and the relation is added to the <xref:System.Data.DataSet>. The position in the child table is initially set to the third row for demonstration purposes.  
  
 [!code-csharp[System.Windows.Forms.CurrencyManagerReset#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.CurrencyManagerReset#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.CurrencyManagerReset/VB/Form1.vb#1)]  
  
 To test the code example, perform the following steps:  
  
1.  Run the example.  
  
2.  Make sure the **Cache and reset position** check box is selected.  
  
3.  Click the **Clear parent field** button to cause a change in a field of the parent table. Notice that the selected row in the child table does not change.  
  
4.  Close and run the example again. You need to do this because the reset behavior occurs only on the first change in the parent row.  
  
5.  Clear the **Cache and reset position** check box.  
  
6.  Click the **Clear parent field** button. Notice that the selected row in the child table changes to the first row.  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Data, System.Drawing, System.Windows.Forms, and System.XML assemblies.  
  
 For information about how to build this example from the command line for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 [How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized](../../../docs/framework/winforms/multiple-controls-bound-to-data-source-synchronized.md)  
 [BindingSource Component](../../../docs/framework/winforms/controls/bindingsource-component.md)  
 [Data Binding and Windows Forms](../../../docs/framework/winforms/data-binding-and-windows-forms.md)
