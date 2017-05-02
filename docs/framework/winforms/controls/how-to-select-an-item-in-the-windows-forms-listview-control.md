---
title: "How to: Select an Item in the Windows Forms ListView Control | Microsoft Docs"
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
  - "jsharp"
helpviewer_keywords: 
  - "lists, selecting items"
  - "ListView control [Windows Forms], selecting items"
  - "selection, in list views"
  - "list views, selecting items"
ms.assetid: ddea918e-1ddf-47f4-bd09-1e9b4c9d0c39
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# How to: Select an Item in the Windows Forms ListView Control
This example demonstrates how to programmatically select an item in a Windows Forms <xref:System.Windows.Forms.ListView> control. Selecting an item programmatically does not automatically change the focus to the <xref:System.Windows.Forms.ListView> control. For this reason, you will typically also want to set the item as focused when selecting an item.  
  
## Example  
 [!code-csharp[System.Windows.Forms.ListView.Misc#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListView.Misc/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.ListView.Misc#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListView.Misc/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.ListView> control named `listView1` that contains at least one item.  
  
-   References to the <xref:System?displayProperty=fullName> and <xref:System.Windows.Forms?displayProperty=fullName> namespaces.  
  
## See Also  
 <xref:System.Windows.Forms.ListView>   
 <xref:System.Windows.Forms.ListViewItem.Selected%2A?displayProperty=fullName>