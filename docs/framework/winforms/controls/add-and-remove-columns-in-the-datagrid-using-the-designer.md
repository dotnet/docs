---
title: "How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vs.DataGridViewAddColumnDialog"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], adding columns"
  - "DataGridView control [Windows Forms], removing columns"
ms.assetid: 9e709f35-0a8c-4e7e-b4c4-bacb7a834077
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer
The Windows Forms <xref:System.Windows.Forms.DataGridView> control must contain columns in order to display data. If you plan to populate the control manually, you must add the columns yourself. Alternately, you can bind the control to a data source, which generates and populates the columns automatically. If the data source contains more columns than you want to display, you can remove the unwanted columns.  
  
 The following procedures require a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add a column using the designer  
  
1.  Click the smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Add Column**.  
  
2.  In the **Add Column** dialog box, choose the **Databound Column** option and select a column from the data source, or choose the **Unbound Column** option and define the column using the fields provided.  
  
3.  Click the **Add** button to add the column, causing it to appear in the designer if the existing columns do not already fill the control display area.  
  
    > [!NOTE]
    >  You can modify column properties in the **Edit Columns** dialog box, which you can access from the control's smart tag.  
  
### To remove a column using the designer  
  
1.  Choose **Edit Columns** from the control's smart tag.  
  
2.  Select a column from the **Selected Columns** list.  
  
3.  Click the **Remove** button to delete the column, causing it to disappear from the designer.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa)  
 [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)
