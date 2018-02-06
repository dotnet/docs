---
title: "How to: Add Columns to the Windows Forms ListView Control"
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
  - "ListView control [Windows Forms], adding column headers"
  - "columns [Windows Forms], adding to ListView controls"
  - "list views [Windows Forms], adding columns"
ms.assetid: 79174274-12ee-4a5d-80db-6ec02976d010
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Columns to the Windows Forms ListView Control
In the Details view, the <xref:System.Windows.Forms.ListView> control can display multiple columns for each list item. You can use the columns to display to the user several types of information about each list item. For example, a list of files could display the file name, file type, size, and date the file was last modified. For information about populating the columns after they are created, see [How to: Display Subitems in Columns with the Windows Forms ListView Control](../../../../docs/framework/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control.md).  
  
### To add columns programmatically  
  
1.  Set the control's <xref:System.Windows.Forms.ListView.View%2A> property to <xref:System.Windows.Forms.View.Details>.  
  
2.  Use the <xref:System.Windows.Forms.ListView.ColumnHeaderCollection.Add%2A> method of the list view's <xref:System.Windows.Forms.ListView.Columns%2A> property.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#31](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#31)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#31](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#31)]  
  
## See Also  
 <xref:System.Windows.Forms.ListView>  
 [ListView Control](../../../../docs/framework/winforms/controls/listview-control-windows-forms.md)  
 [ListView Control Overview](../../../../docs/framework/winforms/controls/listview-control-overview-windows-forms.md)
