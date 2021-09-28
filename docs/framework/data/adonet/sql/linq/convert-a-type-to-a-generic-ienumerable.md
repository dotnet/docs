---
description: "Learn more about: Convert a Type to a Generic IEnumerable"
title: "Convert a Type to a Generic IEnumerable"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 64774fb5-7447-4296-ad3b-8a94346f99a1
---
# Convert a Type to a Generic IEnumerable

Use <xref:System.Linq.Enumerable.AsEnumerable%2A> to return the argument typed as a generic `IEnumerable`.  
  
## Example  

 In this example, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] (using the default generic `Query`) would try to convert the query to SQL and execute it on the server. But the `where` clause references a user-defined client-side method (`isValidProduct`), which cannot be converted to SQL.  
  
 The solution is to specify the client-side generic <xref:System.Collections.Generic.IEnumerable%601> implementation of `where` to replace the generic <xref:System.Linq.IQueryable%601>. You do this by invoking the <xref:System.Linq.Enumerable.AsEnumerable%2A> operator.  
  
 [!code-csharp[DLinqQueryExamples#46](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#46)]
 [!code-vb[DLinqQueryExamples#46](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#46)]  
  
## See also

- [Query Examples](query-examples.md)
