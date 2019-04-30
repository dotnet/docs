---
title: "Set Operations (Visual Basic)"
ms.date: 07/20/2015
ms.assetid: 2b06e822-e030-438f-9db7-ee402bd3a706
---
# Set Operations (Visual Basic)
Set operations in LINQ refer to query operations that produce a result set that is based on the presence or absence of equivalent elements within the same or separate collections (or sets).  
  
 The standard query operator methods that perform set operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|Distinct|Removes duplicate values from a collection.|`Distinct`|<xref:System.Linq.Enumerable.Distinct%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Distinct%2A?displayProperty=nameWithType>|  
|Except|Returns the set difference, which means the elements of one collection that do not appear in a second collection.|Not applicable.|<xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Except%2A?displayProperty=nameWithType>|  
|Intersect|Returns the set intersection, which means elements that appear in each of two collections.|Not applicable.|<xref:System.Linq.Enumerable.Intersect%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Intersect%2A?displayProperty=nameWithType>|  
|Union|Returns the set union, which means unique elements that appear in either of two collections.|Not applicable.|<xref:System.Linq.Enumerable.Union%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Union%2A?displayProperty=nameWithType>|  
  
## Comparison of Set Operations  
  
### Distinct  
 The following illustration depicts the behavior of the <xref:System.Linq.Enumerable.Distinct%2A?displayProperty=nameWithType> method on a sequence of characters. The returned sequence contains the unique elements from the input sequence.  
  
 ![Graphic showing the behavior of Distinct&#40;&#41;.](./media/set-operations/distinct-method-behavior.png)  
  
### Except  
 The following illustration depicts the behavior of <xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType>. The returned sequence contains only the elements from the first input sequence that are not in the second input sequence.  
  
 ![Graphic showing the action of Except&#40;&#41;.](./media/set-operations/except-behavior-graphic.png "Shows the behavior of Except.")  
  
### Intersect  
 The following illustration depicts the behavior of <xref:System.Linq.Enumerable.Intersect%2A?displayProperty=nameWithType>. The returned sequence contains the elements that are common to both of the input sequences.  
  
 ![Graphic showing the intersection of two sequences.](./media/set-operations/intersection-two-sequences.png)    
### Union  
 The following illustration depicts a union operation on two sequences of characters. The returned sequence contains the unique elements from both input sequences.  
  
 ![Graphic showing the union of two sequences.](./media/set-operations/union-operation-two-sequences.png)    
## Query Expression Syntax Example  
 The following example uses the `Distinct` clause in a LINQ query to return the unique numbers from a list of integers.  
  
 [!code-vb[CsLINQSetOps#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQSetOps/VB/setops.vb#1)]  
  
## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)
- [Distinct Clause](../../../../visual-basic/language-reference/queries/distinct-clause.md)
- [How to: Combine and Compare String Collections (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-combine-and-compare-string-collections-linq.md)
- [How to: Find the Set Difference Between Two Lists (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-the-set-difference-between-two-lists-linq.md)
