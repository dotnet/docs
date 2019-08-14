---
title: "How to: Add Columns to the Windows Forms ListView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "ListView control [Windows Forms], adding column headers"
  - "columns [Windows Forms], adding to ListView controls"
ms.assetid: 5b1a8b4d-587e-479a-95c1-f9b90884f13a
---
# How to: Add Columns to the Windows Forms ListView Control Using the Designer

The Windows Forms <xref:System.Windows.Forms.ListView> control can display multiple columns for each list item when in the **Details** view. You can use the columns to display several types of information about each list item. For example, a list of files could display the file name, file type, size, and date the file was last modified. For information on populating the columns once they are created, see [How to: Display Subitems in Columns with the Windows Forms ListView Control](how-to-display-subitems-in-columns-with-the-windows-forms-listview-control.md).

The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ListView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).


### To add columns in the designer

1. In the **Properties** window, set the control's <xref:System.Windows.Forms.ListView.View%2A> property to <xref:System.Windows.Forms.View.Details>.

2. In the **Properties** window, click the **Ellipsis** button (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) next to the <xref:System.Windows.Forms.ListView.Columns%2A> property.

     The **ColumnHeader Collection Editor** appears.

3. Use the **Add** button to add new columns. You can then select the column header and set its text (the caption of the column), text alignment, and width.

## See also

- [ListView Control Overview](listview-control-overview-windows-forms.md)
- [How to: Add and Remove Items with the Windows Forms ListView Control](how-to-add-and-remove-items-with-the-windows-forms-listview-control.md)
- [How to: Display Subitems in Columns with the Windows Forms ListView Control](how-to-display-subitems-in-columns-with-the-windows-forms-listview-control.md)
- [How to: Display Icons for the Windows Forms ListView Control](how-to-display-icons-for-the-windows-forms-listview-control.md)
- [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](add-custom-information-to-a-treeview-or-listview-control-wf.md)
