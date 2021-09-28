---
description: "Learn more about: Quantifier Operations (Visual Basic)"
title: "Quantifier Operations"
ms.date: 07/20/2015
ms.assetid: ae1a2b73-503c-4f4b-a3fd-31b5adbee67c
---
# Quantifier Operations (Visual Basic)

Quantifier operations return a <xref:System.Boolean> value that indicates whether some or all of the elements in a sequence satisfy a condition.  
  
 The following illustration depicts two different quantifier operations on two different source sequences. The first operation asks if one or more of the elements are the character 'A', and the result is `true`. The second operation asks if all the elements are the character 'A', and the result is `true`.  
  
 ![LINQ Quantifier Operations](./media/quantifier-operations/linq-quantifier-operations.png)  
  
 The standard query operator methods that perform quantifier operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|All|Determines whether all the elements in a sequence satisfy a condition.|`Aggregate … In … Into All(…)`|<xref:System.Linq.Enumerable.All%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.All%2A?displayProperty=nameWithType>|  
|Any|Determines whether any elements in a sequence satisfy a condition.|`Aggregate … In … Into Any()`|<xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Any%2A?displayProperty=nameWithType>|  
|Contains|Determines whether a sequence contains a specified element.|Not applicable.|<xref:System.Linq.Enumerable.Contains%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Contains%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Examples  

 These examples use the `Aggregate` clause in Visual Basic as part of the filtering condition in a LINQ query.  
  
 The following example uses the `Aggregate` clause and the <xref:System.Linq.Enumerable.All%2A> extension method to return from a collection those people whose pets are all older than a specified age.  
  
 [!code-vb[CsLINQAnyAll#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAnyAll/VB/AnyAll.vb#1)]  
  
 The next example uses the `Aggregate` clause and the <xref:System.Linq.Enumerable.Any%2A> extension method to return from a collection those people who have at least one pet that is older than a specified age.  
  
 [!code-vb[CsLINQAnyAll#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAnyAll/VB/AnyAll.vb#2)]  
  
## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md)
- [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md)
- [How to: Query for Sentences that Contain a Specified Set of Words (LINQ) (Visual Basic)](how-to-query-for-sentences-that-contain-a-specified-set-of-words.md)
