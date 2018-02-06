---
title: "How to: Set Alternating Row Styles for the Windows Forms DataGridView Control Using the Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ledger-like formats"
  - "DataGridView control [Windows Forms], row style alternation"
  - "Windows Forms, rows"
  - "rows [Windows Forms], alternating"
  - "data [Windows Forms], displaying"
ms.assetid: 02373442-bf94-4470-9f8a-e44c4a9d5b88
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set Alternating Row Styles for the Windows Forms DataGridView Control Using the Designer
Tabular data is often presented in a ledger-like format where alternating rows have different background colors. This format makes it easier for users to tell which cells are in each row, especially with wide tables that have many columns.  
  
 With the <xref:System.Windows.Forms.DataGridView> control, you can specify complete style information for alternating rows. You can use style characteristics like foreground color and font, in addition to background color, to differentiate alternating rows. For more information, see [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md).  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### Define styles for alternating rows  
  
1.  Select the <xref:System.Windows.Forms.DataGridView> control in the designer.  
  
2.  In the **Properties** window, click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) next to the <xref:System.Windows.Forms.DataGridView.AlternatingRowsDefaultCellStyle%2A> property.  
  
3.  In the **CellStyle Builder** dialog box, define the style by setting the properties, and use the **Preview** pane to confirm your choices. The styles you specify are used for every other row displayed in the control, starting with the second one.  
  
4.  To define styles for the remaining rows, repeat steps 2 and 3 using the <xref:System.Windows.Forms.DataGridView.RowsDefaultCellStyle%2A> property.  
  
    > [!NOTE]
    >  Cells are displayed using styles inherited from multiple properties. For more information about style inheritance, see [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md)  
 [Basic Formatting and Styling in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/basic-formatting-and-styling-in-the-windows-forms-datagridview-control.md)  
 [Using the Designer with the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/using-the-designer-with-the-windows-forms-datagridview-control.md)  
 [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa)  
 [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)
