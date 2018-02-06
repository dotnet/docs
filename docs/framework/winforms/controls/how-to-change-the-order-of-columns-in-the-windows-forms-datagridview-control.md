---
title: "How to: Change the Order of Columns in the Windows Forms DataGridView Control"
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
  - "columns [Windows Forms], changing order"
  - "DataGridView control [Windows Forms], column order"
  - "data grids [Windows Forms], changing column order"
ms.assetid: 5e9ac3bc-b0f0-48cb-a3d5-b005af905395
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Order of Columns in the Windows Forms DataGridView Control
When you use a <xref:System.Windows.Forms.DataGridView> to display data from a data source, the columns in the data source's schema sometimes do not appear in the order you would like to display them. You can change the displayed order of the columns by using the <xref:System.Windows.Forms.DataGridViewColumn.DisplayIndex%2A> property of the <xref:System.Windows.Forms.DataGridViewColumn> class.  
  
 The following code example repositions some of the columns automatically generated when binding to the Customers table in the Northwind sample database. For more information about how to bind the <xref:System.Windows.Forms.DataGridView> control to a database table, see [How to: Bind Data to the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control.md).  
  
 There is support for this task in Visual Studio.  Also see [How to: Change the Order of Columns in the Windows Forms DataGridView Control Using the Designer](http://msdn.microsoft.com/library/hb1dk7ax\(v=vs.110\))  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewMisc#040](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#040)]
 [!code-vb[System.Windows.Forms.DataGridViewMisc#040](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#040)]  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.DataGridView> control named `customersDataGridView` that is bound to a table with the indicated column names, such as the `Customers` table in the Northwind sample database.  
  
-   References to the <xref:System?displayProperty=nameWithType>, <xref:System.Windows.Forms?displayProperty=nameWithType>, <xref:System.Data?displayProperty=nameWithType>, and <xref:System.Xml?displayProperty=nameWithType> assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 <xref:System.Windows.Forms.DataGridViewColumn.DisplayIndex%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.Visible%2A?displayProperty=nameWithType>  
 [Displaying Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/displaying-data-in-the-windows-forms-datagridview-control.md)  
 [How to: Bind Data to the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control.md)
