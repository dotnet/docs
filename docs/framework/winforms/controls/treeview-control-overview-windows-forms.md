---
title: "TreeView Control Overview (Windows Forms)"
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
  - "TreeView"
helpviewer_keywords: 
  - "TreeView control [Windows Forms], about TreeView control"
ms.assetid: 0ece823a-9508-478a-bbdb-7d7c3bae51d5
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TreeView Control Overview (Windows Forms)
With the Windows Forms <xref:System.Windows.Forms.TreeView> control, you can display a hierarchy of nodes to users, like the way files and folders are displayed in the left pane of the Windows Explorer feature of the Windows operating system. Each node in the tree view might contain other nodes, called *child nodes*. You can display parent nodes, or nodes that contain child nodes, as expanded or collapsed. You can also display a tree view with check boxes next to the nodes by setting the tree view's <xref:System.Windows.Forms.TreeView.CheckBoxes%2A> property to `true`. You can then programmatically select or clear nodes by setting the node's <xref:System.Windows.Forms.TreeNode.Checked%2A> property to `true` or `false`.  
  
## Key Properties  
 The key properties of the <xref:System.Windows.Forms.TreeView> control are <xref:System.Windows.Forms.TreeView.Nodes%2A> and <xref:System.Windows.Forms.TreeView.SelectedNode%2A>. The <xref:System.Windows.Forms.TreeView.Nodes%2A> property contains the list of top-level nodes in the tree view. The <xref:System.Windows.Forms.TreeView.SelectedNode%2A> property sets the currently selected node. You can display icons next to the nodes. The control uses images from the <xref:System.Windows.Forms.ImageList> named in the tree view's <xref:System.Windows.Forms.TreeView.ImageList%2A> property. The <xref:System.Windows.Forms.TreeView.ImageIndex%2A> property sets the default image for nodes in the tree view. For more information about displaying images, see [How to: Set Icons for the Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-set-icons-for-the-windows-forms-treeview-control.md). If you are using [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], you have access to a large library of standard images that you can use with the <xref:System.Windows.Forms.TreeView> control.  
  
## See Also  
 <xref:System.Windows.Forms.TreeView>  
 [TreeView Control](../../../../docs/framework/winforms/controls/treeview-control-windows-forms.md)  
 [How to: Set Icons for the Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-set-icons-for-the-windows-forms-treeview-control.md)  
 [How to: Add and Remove Nodes with the Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-add-and-remove-nodes-with-the-windows-forms-treeview-control.md)  
 [How to: Iterate Through All Nodes of a Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control.md)  
 [How to: Determine Which TreeView Node Was Clicked](../../../../docs/framework/winforms/controls/how-to-determine-which-treeview-node-was-clicked-windows-forms.md)  
 [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](../../../../docs/framework/winforms/controls/add-custom-information-to-a-treeview-or-listview-control-wf.md)
