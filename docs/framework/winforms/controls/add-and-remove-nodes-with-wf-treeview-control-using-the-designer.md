---
title: "How to: Add and Remove Nodes with the Windows Forms TreeView Control Using the Designer"
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
  - "examples [Windows Forms], TreeView control"
  - "TreeView control [Windows Forms], removing nodes"
  - "tree nodes in TreeView control"
  - "TreeView control [Windows Forms], adding nodes"
ms.assetid: 35bf1750-045e-4ec5-97cb-b47b0dbdaa2c
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add and Remove Nodes with the Windows Forms TreeView Control Using the Designer
Because the Windows Forms <xref:System.Windows.Forms.TreeView> control displays nodes in a hierarchical manner, when adding a node you must pay attention to what its parent node is.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.TreeView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add or remove nodes in the designer  
  
1.  Select the <xref:System.Windows.Forms.TreeView> control.  
  
2.  In the **Properties** window, click the **Ellipsis** (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button next to the <xref:System.Windows.Forms.TreeView.Nodes%2A> property.  
  
     The **TreeNode Editor** appears.  
  
3.  To add nodes, a root node must exist; if one does not exist, you must first add a root by clicking the **Add Root** button. You can then add child nodes by selecting the root or any other node and clicking the **Add Child** button.  
  
4.  To delete nodes, select the node to delete and then click the **Delete** button.  
  
## See Also  
 [TreeView Control](../../../../docs/framework/winforms/controls/treeview-control-windows-forms.md)  
 [TreeView Control Overview](../../../../docs/framework/winforms/controls/treeview-control-overview-windows-forms.md)  
 [How to: Set Icons for the Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-set-icons-for-the-windows-forms-treeview-control.md)  
 [How to: Iterate Through All Nodes of a Windows Forms TreeView Control](../../../../docs/framework/winforms/controls/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control.md)  
 [How to: Determine Which TreeView Node Was Clicked](../../../../docs/framework/winforms/controls/how-to-determine-which-treeview-node-was-clicked-windows-forms.md)  
 [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](../../../../docs/framework/winforms/controls/add-custom-information-to-a-treeview-or-listview-control-wf.md)
