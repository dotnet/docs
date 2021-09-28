---
description: "Learn more about: How to: Retrieve Entity Conflict Information"
title: "How to: Retrieve Entity Conflict Information"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 9a02b608-e7bb-4041-a452-a7fed26fd008
---
# How to: Retrieve Entity Conflict Information

You can use objects of the <xref:System.Data.Linq.ObjectChangeConflict> class to provide information about conflicts revealed by <xref:System.Data.Linq.ChangeConflictException> exceptions. For more information, see [Optimistic Concurrency: Overview](optimistic-concurrency-overview.md).  
  
## Example  

 The following example iterates through a list of accumulated conflicts.  
  
 [!code-csharp[System.Data.Linq.ObjectChangeConflict#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.objectchangeconflict/cs/program.cs#1)]
 [!code-vb[System.Data.Linq.ObjectChangeConflict#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.objectchangeconflict/vb/module1.vb#1)]  
  
## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
