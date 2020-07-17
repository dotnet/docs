---
title: "How to: Retrieve Information As Read-Only"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: fb09e298-0b53-47e5-97fb-ab318bcd4fad
---
# How to: Retrieve Information As Read-Only
When you do not intend to change the data, you can increase the performance of queries by seeking read-only results.  
  
 You implement read-only processing by setting <xref:System.Data.Linq.DataContext.ObjectTrackingEnabled%2A> to `false`.  
  
> [!NOTE]
> When <xref:System.Data.Linq.DataContext.ObjectTrackingEnabled%2A> is set to `false`, <xref:System.Data.Linq.DataContext.DeferredLoadingEnabled%2A> is implicitly set to `false`.  
  
## Example  
 The following code retrieves a read-only collection of employee hire dates.  
  
 [!code-csharp[DLinqQuerying#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQuerying/cs/Program.cs#2)]
 [!code-vb[DLinqQuerying#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQuerying/vb/Module1.vb#2)]  
  
## See also

- [Query Concepts](query-concepts.md)
- [Querying the Database](querying-the-database.md)
- [Deferred versus Immediate Loading](deferred-versus-immediate-loading.md)
