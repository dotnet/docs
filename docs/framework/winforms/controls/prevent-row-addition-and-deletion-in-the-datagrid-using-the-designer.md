---
title: "How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "DataGridView control [Windows Forms], preventing row addition or deletion"
ms.assetid: a17722bd-9400-41e6-8dcc-c9c151f0a749
---
# How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control Using the Designer
Sometimes you will want to prevent users from entering new rows of data or deleting existing rows in your <xref:System.Windows.Forms.DataGridView> control. New rows are entered in the special row for new records at the bottom of the control. When you disable row addition, the row for new records is not displayed. You can then make the control entirely read-only by disabling row deletion and cell editing.

 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

## To prevent row addition and deletion

- Click the smart tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then clear the **Enable Adding** and **Enable Deleting** check boxes.

    > [!NOTE]
    >  To make the control entirely read-only, clear the **Enable Editing** check box as well.

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.AllowUserToAddRows%2A?displayProperty=nameWithType>
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
