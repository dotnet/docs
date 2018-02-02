---
title: "How to: Change the Type of a Windows Forms DataGridView Column Using the Designer"
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
  - "columns [Windows Forms], types"
  - "DataGridView control [Windows Forms], changing column type"
  - "data [Windows Forms], displaying"
ms.assetid: 7f994d45-600d-4190-a187-35803214b40c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Type of a Windows Forms DataGridView Column Using the Designer
Sometimes you will want to change the type of a column that has already been added to a Windows Forms <xref:System.Windows.Forms.DataGridView> control. For example, you may want to modify the types of some of the columns that are generated automatically when you bind the control to a data source. This is useful when the table you display has columns containing foreign keys to rows in a related table. In this case, you may want to replace the text box columns that display these foreign keys with combo box columns that display more meaningful values from the related table.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To change the type of a column using the designer  
  
1.  Click the smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Edit Columns**.  
  
2.  Select a column from the **Selected Columns** list.  
  
3.  In the **Column Properties** grid, set the `ColumnType` property to the new column type.  
  
    > [!NOTE]
    >  The `ColumnType` property is a design-time-only property that indicates the class representing the column type. It is not an actual property defined in a column class.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa)  
 [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)
