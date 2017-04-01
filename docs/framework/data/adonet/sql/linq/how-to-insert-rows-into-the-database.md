---
title: "How to: Insert Rows Into the Database | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 44d99680-69c7-4879-a732-f6771b334211
caps.latest.revision: 3
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# How to: Insert Rows Into the Database
You insert rows into a database by adding objects to the associated [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Table%601> collection and then submitting the changes to the database. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates your changes into the appropriate SQL `INSERT` commands.  
  
> [!NOTE]
>  You can override [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] default methods for `Insert`, `Update`, and `Delete` database operations. For more information, see [Customizing Insert, Update, and Delete Operations](../../../../../../docs/framework/data/adonet/sql/linq/customizing-insert-update-and-delete-operations.md).  
>   
>  Developers using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] can use the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to develop stored procedures for the same purpose.  
  
 The following steps assume that a valid <xref:System.Data.Linq.DataContext> connects you to the Northwind database. For more information, see [How to: Connect to a Database](../../../../../../docs/framework/data/adonet/sql/linq/how-to-connect-to-a-database.md).  
  
### To insert a row into the database  
  
1.  Create a new object that includes the column data to be submitted.  
  
2.  Add the new object to the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] `Table` collection associated with the target table in the database.  
  
3.  Submit the change to the database.  
  
## Example  
 The following code example creates a new object of type `Order` and populates it with appropriate values. It then adds the new object to the `Order` collection. Finally, it submits the change to the database as a new row in the `Orders` table.  
  
 [!code-csharp[System.Data.Linq.Table#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.table/cs/program.cs#1)]
 [!code-vb[System.Data.Linq.Table#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.table/vb/module1.vb#1)]  
  
## See Also  
 [How to: Manage Change Conflicts](../../../../../../docs/framework/data/adonet/sql/linq/how-to-manage-change-conflicts.md)   
 [DataContext Methods (O/R Designer)](http://msdn.microsoft.com/library/c149f4e5-3b61-4c33-892e-3e26d47f3eeb)   
 [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](../Topic/How%20to:%20Assign%20stored%20procedures%20to%20perform%20updates,%20inserts,%20and%20deletes%20\(O-R%20Designer\).md)   
 [Making and Submitting Data Changes](../../../../../../docs/framework/data/adonet/sql/linq/making-and-submitting-data-changes.md)