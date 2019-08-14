---
title: "How to: Change the Type of a Windows Forms DataGridView Column Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms, columns"
  - "columns [Windows Forms], types"
  - "DataGridView control [Windows Forms], changing column type"
  - "data [Windows Forms], displaying"
ms.assetid: 7f994d45-600d-4190-a187-35803214b40c
---
# How to: Change the Type of a Windows Forms DataGridView Column Using the Designer
Sometimes you will want to change the type of a column that has already been added to a Windows Forms <xref:System.Windows.Forms.DataGridView> control. For example, you may want to modify the types of some of the columns that are generated automatically when you bind the control to a data source. This is useful when the table you display has columns containing foreign keys to rows in a related table. In this case, you may want to replace the text box columns that display these foreign keys with combo box columns that display more meaningful values from the related table.

 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To change the type of a column using the designer

1. Click the smart tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Edit Columns**.

2. Select a column from the **Selected Columns** list.

3. In the **Column Properties** grid, set the `ColumnType` property to the new column type.

    > [!NOTE]
    >  The `ColumnType` property is a design-time-only property that indicates the class representing the column type. It is not an actual property defined in a column class.

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewColumn>
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
