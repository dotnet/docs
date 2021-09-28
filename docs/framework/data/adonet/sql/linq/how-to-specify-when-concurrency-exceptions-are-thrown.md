---
description: "Learn more about: How to: Specify When Concurrency Exceptions are Thrown"
title: "How to: Specify When Concurrency Exceptions are Thrown"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 344ae068-ff63-4a2e-8b00-af22e143675f
---
# How to: Specify When Concurrency Exceptions are Thrown

In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], a <xref:System.Data.Linq.ChangeConflictException> exception is thrown when objects do not update because of optimistic concurrency conflicts. For more information, see [Optimistic Concurrency: Overview](optimistic-concurrency-overview.md).  
  
 Before you submit your changes to the database, you can specify when concurrency exceptions should be thrown:  
  
- Throw the exception at the first failure (<xref:System.Data.Linq.ConflictMode.FailOnFirstConflict>).  
  
- Finish all update tries, accumulate all failures, and report the accumulated failures in the exception (<xref:System.Data.Linq.ConflictMode.ContinueOnConflict>).  
  
 When thrown, the <xref:System.Data.Linq.ChangeConflictException> exception provides access to a <xref:System.Data.Linq.ChangeConflictCollection> collection. This collection provides details for each conflict (mapped to a single failed update try), including access to the <xref:System.Data.Linq.ObjectChangeConflict.MemberConflicts%2A> collection. Each member conflict maps to a single member in the update that failed the concurrency check.  
  
## Example  

 The following code shows examples of both values.  
  
 [!code-csharp[System.Data.Linq.ConflictModeEnumeration#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.conflictmodeenumeration/cs/program.cs#1)]
 [!code-vb[System.Data.Linq.ConflictModeEnumeration#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.conflictmodeenumeration/vb/module1.vb#1)]  
  
## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
- [Making and Submitting Data Changes](making-and-submitting-data-changes.md)
