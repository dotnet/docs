---
title: "How to: Attach a Shortcut Menu to a TreeNode Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "shortcut menus [Windows Forms], attaching to TreeNodes"
  - "TreeNode [Windows Forms], attaching a shortcut menu using Designer"
ms.assetid: 8e45e184-1313-4f8f-90ff-2cd5789b2268
---
# How to: Attach a Shortcut Menu to a TreeNode Using the Designer
The Windows Forms <xref:System.Windows.Forms.TreeView> control displays a hierarchy of nodes, similar to the files and folders displayed in the left pane of the Windows Explorer feature in Windows operating systems. By setting the <xref:System.Windows.Forms.Control.ContextMenuStrip%2A> property, you can provide context-sensitive operations to the user when they right-click the <xref:System.Windows.Forms.TreeView> control. By associating a <xref:System.Windows.Forms.ContextMenuStrip> component with individual <xref:System.Windows.Forms.TreeNode> items, you can add a customized level of shortcut menu functionality to your <xref:System.Windows.Forms.TreeView> controls.

### To associate a shortcut menu with a TreeNode at design time

1. Add a <xref:System.Windows.Forms.TreeView> control to your form, and then add nodes to the <xref:System.Windows.Forms.TreeView> as needed. For more information, see [How to: Add and Remove Nodes with the Windows Forms TreeView Control](how-to-add-and-remove-nodes-with-the-windows-forms-treeview-control.md).

2. Add a <xref:System.Windows.Forms.ContextMenuStrip> component to your form, and then add menu items to the shortcut menu that represent node-level operations you wish to make available at run time. For more information, see [How to: Add Menu Items to a ContextMenuStrip](how-to-add-menu-items-to-a-contextmenustrip.md).

3. Reopen the **TreeNodeEditor** dialog box for the <xref:System.Windows.Forms.TreeView> control, select the node to edit, and set its <xref:System.Windows.Forms.ContextMenuStrip> property to the shortcut menu that you added.

4. When this property is set, the shortcut menu will be displayed when you right-click the node.

     Additionally, you will want to write code to handle the <xref:System.Windows.Forms.ToolStripItem.Click> events for these menu items.

## See also

- [TreeView Control](treeview-control-windows-forms.md)
- [TreeView Control Overview](treeview-control-overview-windows-forms.md)
- [ContextMenuStrip Control](contextmenustrip-control.md)
