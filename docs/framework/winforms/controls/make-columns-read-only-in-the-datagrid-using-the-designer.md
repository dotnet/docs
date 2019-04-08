---
title: "How to: Make Columns Read-Only in the Windows Forms DataGridView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Forms, columns"
  - "DataGridView control [Windows Forms], read-only columns"
  - "data [Windows Forms], displaying"
  - "columns [Windows Forms], read-only"
ms.assetid: b4ef7a75-ab33-4ee3-b2cf-201530e454e9
---
# How to: Make Columns Read-Only in the Windows Forms DataGridView Control Using the Designer
By default, users can modify text and numerical data displayed in the Windows Forms <xref:System.Windows.Forms.DataGridView> control. If you want to display data that is not meant for modification, you must make the columns that contain the data read-only. For information about how to make the control entirely read-only, see [How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control Using the Designer](prevent-row-addition-and-deletion-in-the-datagrid-using-the-designer.md).  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
### To make a column read-only by using the designer  
  
1.  Click the smart tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Edit Columns**.  
  
2.  Select a column from the **Selected Columns** list.  
  
3.  In the **Column Properties** grid, set the <xref:System.Windows.Forms.DataGridViewColumn.ReadOnly%2A> property to `true`.  
  
    > [!NOTE]
    >  You can also make a column read-only when you add it by selecting the **Read Only** check box in the **Add Column** dialog box.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewColumn.ReadOnly%2A?displayProperty=nameWithType>
- [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](add-and-remove-columns-in-the-datagrid-using-the-designer.md)
- [How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control Using the Designer](prevent-row-addition-and-deletion-in-the-datagrid-using-the-designer.md)
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
