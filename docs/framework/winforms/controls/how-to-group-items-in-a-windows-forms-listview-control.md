---
title: "How to: Group Items in a Windows Forms ListView Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ListView control [Windows Forms], grouping items"
  - "lists [Windows Forms], grouping items"
  - "grouping"
  - "list views [Windows Forms], grouping items"
  - "groups"
  - "groups [Windows Forms], in Windows Forms controls"
ms.assetid: 610416a1-8da4-436c-af19-5f19e654769b
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Group Items in a Windows Forms ListView Control
With the grouping feature of the <xref:System.Windows.Forms.ListView> control, you can display related sets of items in groups. These groups are separated on the screen by horizontal group headers that contain the group titles. You can use <xref:System.Windows.Forms.ListView> groups to make navigating large lists easier by grouping items alphabetically, by date, or by any other logical grouping. The following image shows some grouped items.  
  
 ![ListView Groups](../../../../docs/framework/winforms/controls/media/listviewgroups.gif "ListViewGroups")  
ListView grouped items  
  
 To enable grouping, you must first create one or more groups either in the designer or programmatically. After a group has been defined, you can assign <xref:System.Windows.Forms.ListView> items to groups. You can also move items from one group to another programmatically.  
  
> [!NOTE]
>  <xref:System.Windows.Forms.ListView> groups are available only on [!INCLUDE[WinXpFamily](../../../../includes/winxpfamily-md.md)] when your application calls the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method. On earlier operating systems, any code relating to groups has no effect and the groups will not appear. For more information, see <xref:System.Windows.Forms.ListView.Groups%2A?displayProperty=nameWithType>.  
  
### To add groups  
  
1.  Use the <xref:System.Windows.Forms.ListViewGroupCollection.Add%2A> method of the <xref:System.Windows.Forms.ListView.Groups%2A> collection.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#21](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#21)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#21](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#21)]  
  
### To remove groups  
  
1.  Use the <xref:System.Windows.Forms.ListViewGroupCollection.RemoveAt%2A> or <xref:System.Windows.Forms.ListViewGroupCollection.Clear%2A> method of the <xref:System.Windows.Forms.ListView.Groups%2A> collection.  
  
     The <xref:System.Windows.Forms.ListViewGroupCollection.RemoveAt%2A> method removes a single group; the <xref:System.Windows.Forms.ListViewGroupCollection.Clear%2A> method removes all groups from the list.  
  
    > [!NOTE]
    >  Removing a group does not remove the items within that group.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#22](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#22)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#22](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#22)]  
  
### To assign items to groups or move items between groups  
  
1.  Set the <xref:System.Windows.Forms.ListViewItem.Group%2A?displayProperty=nameWithType> property of individual items.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#23](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#23)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#23](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#23)]  
  
## See Also  
 <xref:System.Windows.Forms.ListView>  
 <xref:System.Windows.Forms.ListView.Groups%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.ListViewGroup>  
 [ListView Control](../../../../docs/framework/winforms/controls/listview-control-windows-forms.md)  
 [ListView Control Overview](../../../../docs/framework/winforms/controls/listview-control-overview-windows-forms.md)  
 [Windows XP Features and Windows Forms Controls](http://msdn.microsoft.com/library/bc7fab94-fce9-4bf1-a8ad-a5837c91c3c0)  
 [How to: Add and Remove Items with the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-add-and-remove-items-with-the-windows-forms-listview-control.md)
