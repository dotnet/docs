---
title: "How to: Bracket Data Submissions by Using Transactions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 94044a31-de90-479b-935a-8159b4ae5c5a
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Bracket Data Submissions by Using Transactions
You can use <xref:System.Transactions.TransactionScope> to bracket your submissions to the database. For more information, see [Transaction Support](../../../../../../docs/framework/data/adonet/sql/linq/transaction-support.md).  
  
## Example  
 The following code encloses the database submission in a <xref:System.Transactions.TransactionScope>.  
  
 [!code-csharp[DLinqSubmittingChanges#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#3)]
 [!code-vb[DLinqSubmittingChanges#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#3)]  
  
## See Also  
 [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md)  
 [Making and Submitting Data Changes](../../../../../../docs/framework/data/adonet/sql/linq/making-and-submitting-data-changes.md)  
 [Transaction Support](../../../../../../docs/framework/data/adonet/sql/linq/transaction-support.md)
