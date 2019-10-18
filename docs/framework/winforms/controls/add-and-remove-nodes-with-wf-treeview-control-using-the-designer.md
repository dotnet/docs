---
title: "How to: Add and Remove Nodes with the Windows Forms TreeView Control Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "examples [Windows Forms], TreeView control"
  - "TreeView control [Windows Forms], removing nodes"
  - "tree nodes in TreeView control"
  - "TreeView control [Windows Forms], adding nodes"
ms.assetid: 35bf1750-045e-4ec5-97cb-b47b0dbdaa2c
---
# How to: Add and Remove Nodes with the Windows Forms TreeView Control Using the Designer

Because the Windows Forms <xref:System.Windows.Forms.TreeView> control displays nodes in a hierarchical manner, when adding a node you must pay attention to what its parent node is.

The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.TreeView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To add or remove nodes in the designer

1. Select the <xref:System.Windows.Forms.TreeView> control.

2. In the **Properties** window, click the **Ellipsis** (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) button next to the <xref:System.Windows.Forms.TreeView.Nodes%2A> property.

     The **TreeNode Editor** appears.

3. To add nodes, a root node must exist; if one does not exist, you must first add a root by clicking the **Add Root** button. You can then add child nodes by selecting the root or any other node and clicking the **Add Child** button.

4. To delete nodes, select the node to delete and then click the **Delete** button.

## See also

- [TreeView Control](treeview-control-windows-forms.md)
- [TreeView Control Overview](treeview-control-overview-windows-forms.md)
- [How to: Set Icons for the Windows Forms TreeView Control](how-to-set-icons-for-the-windows-forms-treeview-control.md)
- [How to: Iterate Through All Nodes of a Windows Forms TreeView Control](how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control.md)
- [How to: Determine Which TreeView Node Was Clicked](how-to-determine-which-treeview-node-was-clicked-windows-forms.md)
- [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](add-custom-information-to-a-treeview-or-listview-control-wf.md)
