---
description: "Learn more about: How to: Detect and Resolve Conflicting Submissions"
title: "How to: Detect and Resolve Conflicting Submissions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 91e27206-01fb-4c7a-8afc-1383a6ac5067
---
# How to: Detect and Resolve Conflicting Submissions

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides many resources for detecting and resolving conflicts that stem from multi-user changes to the database. For more information, see [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md).  
  
## Example  

 The following example shows a `try`/`catch` block that catches a <xref:System.Data.Linq.ChangeConflictException> exception. Entity and member information for each conflict is displayed in the console window.  
  
> [!NOTE]
> You must include the `using System.Reflection` directive (`Imports System.Reflection` in Visual Basic) to support the information retrieval. For more information, see <xref:System.Reflection>.  
  
 [!code-csharp[DLinqSubmittingChanges#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#2)]
 [!code-vb[DLinqSubmittingChanges#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#2)]  
  
## See also

- [Making and Submitting Data Changes](making-and-submitting-data-changes.md)
- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
