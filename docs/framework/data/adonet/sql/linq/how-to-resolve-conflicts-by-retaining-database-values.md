---
title: "How to: Resolve Conflicts by Retaining Database Values"
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
ms.assetid: b475cf72-9e64-4f6e-99c1-af7737bc85ef
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Resolve Conflicts by Retaining Database Values
To reconcile differences between expected and actual database values before you try to resubmit your changes, you can use <xref:System.Data.Linq.RefreshMode.OverwriteCurrentValues> to retain the values found in the database. The current values in the object model are then overwritten. For more information, see [Optimistic Concurrency: Overview](../../../../../../docs/framework/data/adonet/sql/linq/optimistic-concurrency-overview.md).  
  
> [!NOTE]
>  In all cases, the record on the client is first refreshed by retrieving the updated data from the database. This action makes sure that the next update try will not fail on the same concurrency checks.  
  
## Example  
 In this scenario, a <xref:System.Data.Linq.ChangeConflictException> exception is thrown when User1 tries to submit changes, because User2 has in the meantime changed the Assistant and Department columns. The following table shows the situation.  
  
||Manager|Assistant|Department|  
|------|-------------|---------------|----------------|  
|Original database state when queried by User1 and User2.|Alfreds|Maria|Sales|  
|User1 prepares to submit these changes.|Alfred||Marketing|  
|User2 has already submitted these changes.||Mary|Service|  
  
 User1 decides to resolve this conflict by having the newer database values overwrite the current values in the object model.  
  
 When User1 resolves the conflict by using <xref:System.Data.Linq.RefreshMode.OverwriteCurrentValues>, the result in the database is as follows in the table:  
  
||Manager|Assistant|Department|  
|------|-------------|---------------|----------------|  
|New state after conflict resolution.|Alfreds<br /><br /> (original)|Mary<br /><br /> (from User2)|Service<br /><br /> (from User2)|  
  
 The following example code shows how to overwrite current values in the object model with the database values. (No inspection or custom handling of individual member conflicts occurs.)  
  
 [!code-csharp[System.Data.Linq.RefreshMode#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.refreshmode/cs/program.cs#1)]
 [!code-vb[System.Data.Linq.RefreshMode#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.refreshmode/vb/module1.vb#1)]  
  
## See Also  
 [How to: Manage Change Conflicts](../../../../../../docs/framework/data/adonet/sql/linq/how-to-manage-change-conflicts.md)
