---
title: "How to: Group Items in a Windows Forms ListView Control Using the Designer"
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
  - "ListView control [Windows Forms], grouping items"
  - "grouping"
  - "groups [Windows Forms], in Windows Forms controls"
ms.assetid: 8b615000-69d9-4c64-acaf-b54fa09b69e3
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Group Items in a Windows Forms ListView Control Using the Designer
The grouping feature of the <xref:System.Windows.Forms.ListView> control enables you to display related sets of items in groups. These groups are separated on the screen by horizontal group headers that contain the group titles. You can use <xref:System.Windows.Forms.ListView> groups to make navigating large lists easier by grouping items alphabetically, by date, or by any other logical grouping. The following image shows some grouped items.  
  
 ![ListView Groups](../../../../docs/framework/winforms/controls/media/listviewgroups.gif "ListViewGroups")  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ListView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
 To enable grouping, you must first create one or more <xref:System.Windows.Forms.ListViewGroup> objects either in the designer or programmatically. Once a group has been defined, you can assign items to it.  
  
> [!NOTE]
>  <xref:System.Windows.Forms.ListView> groups are available only on [!INCLUDE[WinXpFamily](../../../../includes/winxpfamily-md.md)] when your application calls the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method. On earlier operating systems, any code relating to groups has no effect and the groups will not appear. For more information, see <xref:System.Windows.Forms.ListView.Groups%2A?displayProperty=nameWithType>.  
>   
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add or remove groups in the designer  
  
1.  In the **Properties** window, click the **Ellipsis** (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button next to the <xref:System.Windows.Forms.ListView.Groups%2A> property.  
  
     The **ListViewGroup Collection Editor** appears.  
  
2.  To add a group, click the **Add** button. You can then set properties of the new group, such as the <xref:System.Windows.Forms.ListViewGroup.Header%2A> and <xref:System.Windows.Forms.ListViewGroup.HeaderAlignment%2A> properties. To remove a group, select it and click the **Remove** button.  
  
### To assign items to groups in the designer  
  
1.  In the **Properties** window, click the **Ellipsis** (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button next to the <xref:System.Windows.Forms.ListView.Items%2A> property.  
  
     The **ListViewItem Collection Editor** appears.  
  
2.  To add a new item, click the **Add** button. You can then set properties of the new item, such as the <xref:System.Windows.Forms.ListViewItem.Text%2A> and <xref:System.Windows.Forms.ListViewItem.ImageIndex%2A> properties.  
  
3.  Select the <xref:System.Windows.Forms.ListViewItem.Group%2A> property and choose a group from the drop-down list.  
  
## See Also  
 <xref:System.Windows.Forms.ListView>  
 <xref:System.Windows.Forms.ListView.Groups%2A>  
 <xref:System.Windows.Forms.ListViewGroup>  
 [ListView Control](../../../../docs/framework/winforms/controls/listview-control-windows-forms.md)  
 [ListView Control Overview](../../../../docs/framework/winforms/controls/listview-control-overview-windows-forms.md)  
 [Windows XP Features and Windows Forms Controls](http://msdn.microsoft.com/library/bc7fab94-fce9-4bf1-a8ad-a5837c91c3c0)  
 [How to: Add and Remove Items with the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-add-and-remove-items-with-the-windows-forms-listview-control.md)
