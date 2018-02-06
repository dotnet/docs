---
title: "How to: Submit Changes to the Database"
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
ms.assetid: c7cba174-9d40-491d-b32c-f2d73b7e9eab
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Submit Changes to the Database
Regardless of how many changes you make to your objects, changes are made only to in-memory replicas. You have made no changes to the actual data in the database. Your changes are not transmitted to the server until you explicitly call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> on the <xref:System.Data.Linq.DataContext>.  
  
 When you make this call, the <xref:System.Data.Linq.DataContext> tries to translate your changes into equivalent SQL commands. You can use your own custom logic to override these actions, but the order of submission is orchestrated by a service of the <xref:System.Data.Linq.DataContext> known as the *change processor*. The sequence of events is as follows:  
  
1.  When you call <xref:System.Data.Linq.DataContext.SubmitChanges%2A>, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] examines the set of known objects to determine whether new instances have been attached to them. If they have, these new instances are added to the set of tracked objects.  
  
2.  All objects that have pending changes are ordered into a sequence of objects based on the dependencies between them. Objects whose changes depend on other objects are sequenced after their dependencies.  
  
3.  Immediately before any actual changes are transmitted, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] starts a transaction to encapsulate the series of individual commands.  
  
4.  The changes to the objects are translated one by one to SQL commands and sent to the server.  
  
 At this point, any errors detected by the database cause the submission process to stop, and an exception is raised. All changes to the database are rolled back as if no submissions ever occurred. The <xref:System.Data.Linq.DataContext> still has a full recording of all changes. You can therefore try to correct the problem and call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> again, as in the code example that follows.  
  
## Example  
 When the transaction around the submission is completed successfully, the <xref:System.Data.Linq.DataContext> accepts the changes to the objects by ignoring the change-tracking information.  
  
 [!code-csharp[DLinqSubmittingChanges#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#1)]
 [!code-vb[DLinqSubmittingChanges#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#1)]  
  
## See Also  
 [How to: Detect and Resolve Conflicting Submissions](../../../../../../docs/framework/data/adonet/sql/linq/how-to-detect-and-resolve-conflicting-submissions.md)  
 [How to: Manage Change Conflicts](../../../../../../docs/framework/data/adonet/sql/linq/how-to-manage-change-conflicts.md)  
 [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md)  
 [Making and Submitting Data Changes](../../../../../../docs/framework/data/adonet/sql/linq/making-and-submitting-data-changes.md)
