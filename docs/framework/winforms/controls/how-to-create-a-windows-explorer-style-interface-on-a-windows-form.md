---
title: "How to: Create a Windows Explorer–Style Interface on a Windows Form"
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
  - "Windows Explorer [Windows Forms], creating with Windows Forms"
  - "SplitContainer control [Windows Forms], Explorer-style interface"
  - "forms [Windows Forms], Windows Explorer type"
ms.assetid: 9a3d5f4f-5dda-4350-9ad5-57ce5976dc47
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Windows Explorer–Style Interface on a Windows Form
Windows Explorer is a common user-interface choice for applications because of its ready familiarity.  
  
 Windows Explorer is, essentially, a <xref:System.Windows.Forms.TreeView> control and a <xref:System.Windows.Forms.ListView> control on separate panels. The panels are made resizable by a splitter. This arrangement of controls is very effective for displaying and browsing information.  
  
 The following steps show how to arrange controls in a Windows Explorer-like form. They do not show how to add the file-browsing functionality of the Windows Explorer application.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create a Windows Explorer-style Windows Form  
  
1.  Create a new Windows Application project. For details, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  From the **Toolbox**:  
  
    1.  Drag a <xref:System.Windows.Forms.SplitContainer> control onto your form.  
  
    2.  Drag a <xref:System.Windows.Forms.TreeView> control into **SplitterPanel1** (the panel of the <xref:System.Windows.Forms.SplitContainer> control marked **Panel1**).  
  
    3.  Drag a <xref:System.Windows.Forms.ListView> control into **SplitterPanel2** (the panel of the <xref:System.Windows.Forms.SplitContainer> control marked **Panel2**).  
  
3.  Select all three controls by pressing the CTRL key and clicking them in turn. When you select the <xref:System.Windows.Forms.SplitContainer> control, click the splitter bar, rather than the panels.  
  
    > [!NOTE]
    >  Do not use the **Select All** command on the **Edit** menu. If you do so, the property needed in the next step will not appear in the **Properties** window.  
  
4.  In the **Properties** window, set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.  
  
5.  Press F5 to run the application.  
  
     The form displays a two-part user interface, similar to that of the Windows Explorer.  
  
    > [!NOTE]
    >  When you drag the splitter, the panels resize themselves.  
  
## See Also  
 <xref:System.Windows.Forms.SplitContainer>  
 [How to: Create a Multipane User Interface with Windows Forms](../../../../docs/framework/winforms/controls/how-to-create-a-multipane-user-interface-with-windows-forms.md)  
 [How to: Define Resize and Positioning Behavior in a Split Window](../../../../docs/framework/winforms/controls/how-to-define-resize-and-positioning-behavior-in-a-split-window.md)  
 [How to: Split a Window Horizontally](../../../../docs/framework/winforms/controls/how-to-split-a-window-horizontally.md)  
 [SplitContainer Control](../../../../docs/framework/winforms/controls/splitcontainer-control-windows-forms.md)
