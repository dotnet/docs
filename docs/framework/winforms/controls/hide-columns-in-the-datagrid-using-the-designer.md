---
title: "How to: Hide Columns in the Windows Forms DataGridView Control Using the Designer"
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
  - "Windows Forms, columns"
  - "columns [Windows Forms], hiding"
  - "DataGridView control [Windows Forms], column hiding"
  - "data [Windows Forms], displaying"
ms.assetid: a81c38e6-2527-426a-bcb1-be691403be04
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Hide Columns in the Windows Forms DataGridView Control Using the Designer
Sometimes you will want to display only some of the columns that are available in a Windows Forms <xref:System.Windows.Forms.DataGridView> control. For example, you may want to show an employee salary column to users with management credentials while hiding it from other users. Alternately, you may want to bind the control to a data source that contains many columns, only some of which you want to display. In this case, you will typically remove the columns you are not interested in displaying rather than hiding them. For more information, see [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](../../../../docs/framework/winforms/controls/add-and-remove-columns-in-the-datagrid-using-the-designer.md).  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To hide a column using the designer  
  
1.  Click the smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Edit Columns**.  
  
2.  Select a column from the **Selected Columns** list.  
  
3.  In the **Column Properties** grid, set the <xref:System.Windows.Forms.DataGridViewColumn.Visible%2A> property to `false`.  
  
    > [!NOTE]
    >  You can also hide a column when adding it by clearing the **Visible** check box in the **Add Column** dialog box.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewColumn.Visible%2A?displayProperty=nameWithType>  
 [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](../../../../docs/framework/winforms/controls/add-and-remove-columns-in-the-datagrid-using-the-designer.md)  
 [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa)  
 [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)
