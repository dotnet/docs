---
title: "How to: Add and Remove Items with the Windows Forms ListView Control"
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
  - "ListView control [Windows Forms], populating"
  - "list views [Windows Forms], adding list items"
  - "ListView control [Windows Forms], adding list items"
ms.assetid: 1b35a80a-edd8-495f-a807-a28c4aae52c6
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add and Remove Items with the Windows Forms ListView Control
The process of adding an item to a Windows Forms <xref:System.Windows.Forms.ListView> control consists primarily of specifying the item and assigning properties to it. Adding or removing list items can be done at any time.  
  
### To add items programmatically  
  
1.  Use the <xref:System.Windows.Forms.ListView.ListViewItemCollection.Add%2A> method of the <xref:System.Windows.Forms.ListView.Items%2A> property.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#11](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#11)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#11](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#11)]  
  
### To remove items programmatically  
  
1.  Use the <xref:System.Windows.Forms.ListView.ListViewItemCollection.RemoveAt%2A> or <xref:System.Windows.Forms.ListView.ListViewItemCollection.Clear%2A> method of the <xref:System.Windows.Forms.ListView.Items%2A> property. The <xref:System.Windows.Forms.ListView.ListViewItemCollection.RemoveAt%2A> method removes a single item; the <xref:System.Windows.Forms.ListView.ListViewItemCollection.Clear%2A> method removes all items from the list.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#12](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#12)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#12](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#12)]  
  
## See Also  
 <xref:System.Windows.Forms.ListView>  
 [ListView Control](../../../../docs/framework/winforms/controls/listview-control-windows-forms.md)  
 [ListView Control Overview](../../../../docs/framework/winforms/controls/listview-control-overview-windows-forms.md)
