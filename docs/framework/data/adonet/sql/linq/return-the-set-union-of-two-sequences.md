---
title: "Return the Set Union of Two Sequences"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 8b8bd3cb-86d4-4a3b-9906-61f68726dd1f
---
# Return the Set Union of Two Sequences
Use the <xref:System.Linq.Queryable.Union%2A> operator to return the set union of two sequences.  
  
## Example  
 This example uses <xref:System.Linq.Queryable.Union%2A> to return a sequence of all countries/regions in which there are either `Customers` or `Employees`.  
  
 [!code-csharp[DLinqQueryExamples#43](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#43)]
 [!code-vb[DLinqQueryExamples#43](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#43)]  
  
 In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the <xref:System.Linq.Queryable.Union%2A> operator is defined for multisets as the unordered concatenation of the multisets (effectively the result of the [`UNION ALL`](https://docs.microsoft.com/sql/t-sql/language-elements/set-operators-union-transact-sql) clause in SQL).

For more info and examples, see <xref:System.Linq.Queryable.Union%2A?displayProperty=nameWithType>.
  
## See also

- [Query Examples](query-examples.md)
- [Standard Query Operator Translation](standard-query-operator-translation.md)
