---
title: "Column Fill Mode in the Windows Forms DataGridView Control"
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
  - "data grids [Windows Forms], automatically resizing columns"
  - "DataGridView control [Windows Forms], column fill mode"
  - "data grids [Windows Forms], column fill mode"
ms.assetid: b4ef7411-ebf4-4e26-bb33-aecec90de80c
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Column Fill Mode in the Windows Forms DataGridView Control
In column fill mode, the <xref:System.Windows.Forms.DataGridView> control resizes its columns automatically so that they fill the width of the available display area. The control does not display the horizontal scroll bar except when it is necessary to keep the width of every column equal to or greater than its <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> property value.  
  
 The sizing behavior of each column depends on its <xref:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode%2A> property. The value of this property is inherited from the column's <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property or the control's <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A> property if the column value is <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet> (the default value).  
  
 Each column can have a different size mode, but any columns with a size mode of <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill> will share the display-area width that is not used by the other columns. This width is divided among the fill-mode columns in proportions relative to their <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> property values. For example, if two columns have <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values of 100 and 200, the first column will be half as wide as the second column.  
  
## User Resizing in Fill Mode  
 Unlike sizing modes that resize based on cell contents, fill mode does not prevent users from resizing columns that have <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A> property values of `true`. When a user resizes a fill-mode column, any fill-mode columns after the resized column (to the right if <xref:System.Windows.Forms.Control.RightToLeft%2A> is `false`; otherwise, to the left) are also resized to compensate for the change in the available width. If there are no fill-mode columns after the resized column, then all other fill-mode columns in the control are resized to compensate. If there are no other fill-mode columns in the control, the resize is ignored. If a column that is not in fill mode is resized, all fill-mode columns in the control change sizes to compensate.  
  
 After resizing a fill-mode column, the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values for all columns that changed are adjusted proportionally. For example, if four fill-mode columns have <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values of 100, resizing the second column to half its original width will result in <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values of 100, 50, 125, and 125. Resizing a column that is not in fill mode will not change any <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values because the fill-mode columns will simply resize to compensate while retaining the same proportions.  
  
## Content-Based FillWeight Adjustment  
 You can initialize <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values for fill-mode columns by using the <xref:System.Windows.Forms.DataGridView> automatic resizing methods, such as the <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A> method. This method first calculates the widths required by columns to display their contents. Next, the control adjusts the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values for all fill-mode columns so that their proportions match the proportions of the calculated widths. Finally, the control resizes the fill-mode columns using the new <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> proportions so that all columns in the control fill the available horizontal space.  
  
## Example  
  
### Description  
 By using appropriate values for the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A>, <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A>, <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A>, and <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A> properties, you can customize the column-sizing behaviors for many different scenarios.  
  
 The following demonstration code enables you to experiment with different values for the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A>, <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A>, and <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> properties of different columns. In this example, a <xref:System.Windows.Forms.DataGridView> control is bound to its own <xref:System.Windows.Forms.DataGridView.Columns%2A> collection, and one column is bound to each of the <xref:System.Windows.Forms.DataGridViewColumn.HeaderText%2A>, <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A>, <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A>, <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A>, and <xref:System.Windows.Forms.DataGridViewColumn.Width%2A> properties. Each of the columns is also represented by a row in the control, and changing values in a row will update the properties of the corresponding column so that you can see how the values interact.  
  
### Code  
 [!code-csharp[System.Windows.Forms.DataGridViewFillColumnsDemo#00](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewFillColumnsDemo/CS/fillcolumns.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewFillColumnsDemo#00](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewFillColumnsDemo/vb/fillcolumns.vb#00)]  
  
### Comments  
 To use this demonstration application:  
  
-   Change the size of the form. Observe how columns change their widths while retaining the proportions indicated by the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> property values.  
  
-   Change the column sizes by dragging the column dividers with the mouse. Observe how the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> values change.  
  
-   Change the <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> value for one column, then drag to resize the form. Observe how, when you make the form small enough, the <xref:System.Windows.Forms.DataGridViewColumn.Width%2A> values do not go below the <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> values.  
  
-   Change the <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> values for all columns to large numbers so that the combined values exceed the width of the control. Observe how the horizontal scroll bar appears.  
  
-   Change the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> values for some columns. Observe the effect when you resize columns or the form.  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode>  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 <xref:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode>  
 <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.Width%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.RightToLeft%2A?displayProperty=nameWithType>  
 [Resizing Columns and Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/resizing-columns-and-rows-in-the-windows-forms-datagridview-control.md)
