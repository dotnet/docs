---
title: "ListView Control Overview (Windows Forms)"
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
  - "ListView"
helpviewer_keywords: 
  - "lists"
  - "ListView control [Windows Forms], about ListView control"
  - "list views"
ms.assetid: c9ef56c1-3bb1-4101-9f4e-e95e720f2756
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ListView Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ListView> control displays a list of items with icons. You can use a list view to create a user interface like the right pane of Windows Explorer. The control has four view modes: LargeIcon, SmallIcon, List, and Details.  
  
## What You Can Do with the ListView Control  
  
> [!NOTE]
>  An additional view mode, Tile, is only available on Windows XP and the Windows Server 2003 operating system. For more information, see [How to: Enable Tile View in a Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-enable-tile-view-in-a-windows-forms-listview-control.md).  
  
 The LargeIcon mode displays large icons next to the item text; the items appear in multiple columns if the control is large enough. The SmallIcon mode is the same except that it displays small icons. The List mode displays small icons but is always in a single column. The Details mode displays items in multiple columns. For details, see [How to: Add Columns to the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-add-columns-to-the-windows-forms-listview-control.md). The view mode is determined by the <xref:System.Windows.Forms.ListView.View%2A> property. All of the view modes can display images from image lists. For details, see [How to: Display Icons for the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-display-icons-for-the-windows-forms-listview-control.md).  
  
 The following table lists some of the <xref:System.Windows.Forms.ListView> members and the views they are valid in.  
  
|ListView member|View|  
|---------------------|----------|  
|<xref:System.Windows.Forms.ListView.Alignment%2A> property|<xref:System.Windows.Forms.View.SmallIcon> or <xref:System.Windows.Forms.View.LargeIcon>|  
|<xref:System.Windows.Forms.ListView.AutoArrange%2A> property|<xref:System.Windows.Forms.View.SmallIcon> or <xref:System.Windows.Forms.View.LargeIcon>|  
|<xref:System.Windows.Forms.ListView.AutoResizeColumn%2A> method|<xref:System.Windows.Forms.View.Details>|  
|<xref:System.Windows.Forms.ListView.Columns%2A> property|<xref:System.Windows.Forms.View.Details> or <xref:System.Windows.Forms.View.Tile>|  
|<xref:System.Windows.Forms.ListView.DrawSubItem> event|<xref:System.Windows.Forms.View.Details>|  
|<xref:System.Windows.Forms.ListView.FindItemWithText%2A> method|<xref:System.Windows.Forms.View.Details>, <xref:System.Windows.Forms.View.List>, or <xref:System.Windows.Forms.View.Tile>|  
|<xref:System.Windows.Forms.ListView.FindNearestItem%2A> method|<xref:System.Windows.Forms.View.SmallIcon> or <xref:System.Windows.Forms.View.LargeIcon>|  
|<xref:System.Windows.Forms.ListView.GetItemAt%2A> method|<xref:System.Windows.Forms.View.Details> or <xref:System.Windows.Forms.View.Tile>|  
|<xref:System.Windows.Forms.ListView.Groups%2A> property|All views except <xref:System.Windows.Forms.View.List>|  
|<xref:System.Windows.Forms.ListView.HeaderStyle%2A> property|<xref:System.Windows.Forms.View.Details>.|  
|<xref:System.Windows.Forms.ListView.InsertionMark%2A> property|<xref:System.Windows.Forms.View.LargeIcon>, <xref:System.Windows.Forms.View.SmallIcon>, or <xref:System.Windows.Forms.View.Tile>|  
  
 The key property of the <xref:System.Windows.Forms.ListView> control is <xref:System.Windows.Forms.ListView.Items%2A>, which contains the items displayed by the control. The <xref:System.Windows.Forms.ListView.SelectedItems%2A> property contains a collection of the items currently selected in the control. The user can select multiple items, for example to drag and drop several items at a time to another control, if the <xref:System.Windows.Forms.ListView.MultiSelect%2A> property is set to `true`. The <xref:System.Windows.Forms.ListView> control can display check boxes next to the items, if the <xref:System.Windows.Forms.ListView.CheckBoxes%2A> property is set to `true`.  
  
 The <xref:System.Windows.Forms.ListView.Activation%2A> property determines what type of action the user must take to activate an item in the list: the options are <xref:System.Windows.Forms.ItemActivation.Standard>, <xref:System.Windows.Forms.ItemActivation.OneClick>, and <xref:System.Windows.Forms.ItemActivation.TwoClick>. <xref:System.Windows.Forms.ItemActivation.OneClick> activation requires a single click to activate the item. <xref:System.Windows.Forms.ItemActivation.TwoClick> activation requires the user to double-click to activate the item; a single click changes the color of the item text. <xref:System.Windows.Forms.ItemActivation.Standard> activation requires the user to double-click to activate an item, but the item does not change appearance.  
  
 The <xref:System.Windows.Forms.ListView> control also supports the visual styles and other features available on the Windows XP platform, including grouping, tile view, and insertion marks. For more information, see [Windows XP Features and Windows Forms Controls](http://msdn.microsoft.com/library/bc7fab94-fce9-4bf1-a8ad-a5837c91c3c0).  
  
## See Also  
 <xref:System.Windows.Forms.ListView>  
 [ListView Control](../../../../docs/framework/winforms/controls/listview-control-windows-forms.md)  
 [How to: Add and Remove Items with the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-add-and-remove-items-with-the-windows-forms-listview-control.md)  
 [How to: Add Columns to the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-add-columns-to-the-windows-forms-listview-control.md)  
 [How to: Display Icons for the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-display-icons-for-the-windows-forms-listview-control.md)  
 [How to: Display Subitems in Columns with the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control.md)  
 [How to: Select an Item in the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-select-an-item-in-the-windows-forms-listview-control.md)  
 [How to: Group Items in a Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-group-items-in-a-windows-forms-listview-control.md)  
 [How to: Display an Insertion Mark in a Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-display-an-insertion-mark-in-a-windows-forms-listview-control.md)  
 [How to: Add Search Capabilities to a ListView Control](../../../../docs/framework/winforms/controls/how-to-add-search-capabilities-to-a-listview-control.md)  
 [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](../../../../docs/framework/winforms/controls/add-custom-information-to-a-treeview-or-listview-control-wf.md)  
 [How to: Create a Multipane User Interface with Windows Forms](../../../../docs/framework/winforms/controls/how-to-create-a-multipane-user-interface-with-windows-forms.md)
