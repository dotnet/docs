---
title: "How to: Add and Remove Items with the Windows Forms ListView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "ListView control [Windows Forms], populating"
  - "ListView control [Windows Forms], adding list items"
ms.assetid: 217611ee-fd11-4d39-9a54-a37c3e781be1
---
# How to: Add and Remove Items with the Windows Forms ListView Control Using the Designer

The process of adding an item to a Windows Forms <xref:System.Windows.Forms.ListView> control consists primarily of specifying the item and assigning properties to it. Adding or removing list items can be done at any time.

The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ListView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To add or remove items using the designer

1. Select the <xref:System.Windows.Forms.ListView> control.

2. In the **Properties** window, click the **Ellipsis** (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) button next to the <xref:System.Windows.Forms.ListView.Items%2A> property.

     The **ListViewItem Collection Editor** appears.

3. To add an item, click the **Add** button. You can then set properties of the new item, such as the <xref:System.Windows.Forms.ListView.Text%2A> and <xref:System.Windows.Forms.ListViewItem.ImageIndex%2A> properties.

4. To remove an item, select it and click the **Remove** button.

## See also

- [ListView Control Overview](listview-control-overview-windows-forms.md)
- [How to: Add Columns to the Windows Forms ListView Control](how-to-add-columns-to-the-windows-forms-listview-control.md)
- [How to: Display Subitems in Columns with the Windows Forms ListView Control](how-to-display-subitems-in-columns-with-the-windows-forms-listview-control.md)
- [How to: Display Icons for the Windows Forms ListView Control](how-to-display-icons-for-the-windows-forms-listview-control.md)
- [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](add-custom-information-to-a-treeview-or-listview-control-wf.md)
- [How to: Group Items in a Windows Forms ListView Control](how-to-group-items-in-a-windows-forms-listview-control.md)
