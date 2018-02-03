---
title: "How to: Set the Sizing Modes of the Windows Forms DataGridView Control"
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
  - "data grids [Windows Forms], setting sizing modes"
  - "DataGridView control [Windows Forms], sizing modes"
ms.assetid: e9ad15e6-b4bb-44aa-a767-3738e9db1651
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Sizing Modes of the Windows Forms DataGridView Control
The following procedures demonstrate some common scenarios that customize or combine the sizing options available for the <xref:System.Windows.Forms.DataGridView> control and for specific columns in a control.  
  
### To create a fixed-width column  
  
-   Set the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.None>, the <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A> property to <xref:System.Windows.Forms.DataGridViewTriState.False>, the <xref:System.Windows.Forms.DataGridViewColumn.ReadOnly%2A> property to `true`, and the <xref:System.Windows.Forms.DataGridViewColumn.Width%2A> property to an appropriate value.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewSizingScenarios#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/CS/sizingscenarios.cs#10)]
     [!code-vb[System.Windows.Forms.DataGridViewSizingScenarios#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/vb/sizingscenarios.vb#10)]  
  
### To create a column that adjusts its size to fit its content  
  
-   Set the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property to a content-based sizing mode.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewSizingScenarios#20](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/CS/sizingscenarios.cs#20)]
     [!code-vb[System.Windows.Forms.DataGridViewSizingScenarios#20](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/vb/sizingscenarios.vb#20)]  
  
### To create fill-mode columns for values of varying size and importance  
  
-   Set the <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A?displayProperty=nameWithType> property to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill> to set the sizing mode for all columns that do not override this value. Set the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> properties of the columns to values that are proportional to their average content widths. Set the <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> properties of important columns to ensure partial content display.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewSizingScenarios#30](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/CS/sizingscenarios.cs#30)]
     [!code-vb[System.Windows.Forms.DataGridViewSizingScenarios#30](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/vb/sizingscenarios.vb#30)]  
  
## Example  
 The following complete code example provides a demonstration application that can help you understand the sizing options described in this topic.  
  
 [!code-csharp[System.Windows.Forms.DataGridViewSizingScenarios#00](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/CS/sizingscenarios.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewSizingScenarios#00](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewSizingScenarios/vb/sizingscenarios.vb#00)]  
  
 To use this demonstration application:  
  
-   Change the size of the form. Observe how the fill-mode columns change their widths while retaining the proportions indicated by the <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> property values. Observe how a column's <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> prevents it from changing when the form is too small.  
  
-   Change the column sizes by dragging the column dividers with the mouse. Observe how some columns cannot be resized, and how resizable columns cannot be made narrower than their minimum widths.  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode>  
 <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.ReadOnly%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.Width%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A?displayProperty=nameWithType>
