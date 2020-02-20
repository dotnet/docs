---
title: "Partitioning Data"
ms.date: 07/20/2015
ms.assetid: 69c59379-b66e-422c-b324-5b5c07760ef7
---
# Partitioning Data (Visual Basic)
Partitioning in LINQ refers to the operation of dividing an input sequence into two sections, without rearranging the elements, and then returning one of the sections.  
  
 The following illustration shows the results of three different partitioning operations on a sequence of characters. The first operation returns the first three elements in the sequence. The second operation skips the first three elements and returns the remaining elements. The third operation skips the first two elements in the sequence and returns the next three elements.  
  
 ![Illustration that shows three LINQ partitioning operations.](./media/partitioning-data/linq-partitioning-operations.png)  
  
 The standard query operator methods that partition sequences are listed in the following section.  
  
## Operators  
  
|Operator Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-------------------|-----------------|------------------------------------------|----------------------|  
|Skip|Skips elements up to a specified position in a sequence.|`Skip`|<xref:System.Linq.Enumerable.Skip%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Skip%2A?displayProperty=nameWithType>|  
|SkipWhile|Skips elements based on a predicate function until an element does not satisfy the condition.|`Skip While`|<xref:System.Linq.Enumerable.SkipWhile%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.SkipWhile%2A?displayProperty=nameWithType>|  
|Take|Takes elements up to a specified position in a sequence.|`Take`|<xref:System.Linq.Enumerable.Take%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Take%2A?displayProperty=nameWithType>|  
|TakeWhile|Takes elements based on a predicate function until an element does not satisfy the condition.|`Take While`|<xref:System.Linq.Enumerable.TakeWhile%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.TakeWhile%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Examples  
  
### Skip  
 The following code example uses the `Skip` clause in Visual Basic to skip over the first four strings in an array of strings before returning the remaining strings in the array.  
  
 [!code-vb[CsLINQPartitioning#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQPartitioning/VB/Partitioning.vb#1)]  
  
### SkipWhile  
 The following code example uses the `Skip While` clause in Visual Basic to skip over the strings in an array while the first letter of the string is "a". The remaining strings in the array are returned.  
  
 [!code-vb[CsLINQPartitioning#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQPartitioning/VB/Partitioning.vb#2)]  
  
### Take  
 The following code example uses the `Take` clause in Visual Basic to return the first two strings in an array of strings.  
  
 [!code-vb[CsLINQPartitioning#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQPartitioning/VB/Partitioning.vb#3)]  
  
### TakeWhile  
 The following code example uses the `Take While` clause in Visual Basic to return strings from an array while the length of the string is five or less.  
  
 [!code-vb[CsLINQPartitioning#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQPartitioning/VB/Partitioning.vb#4)]  
  
## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)
- [Skip Clause](../../../../visual-basic/language-reference/queries/skip-clause.md)
- [Skip While Clause](../../../../visual-basic/language-reference/queries/skip-while-clause.md)
- [Take Clause](../../../../visual-basic/language-reference/queries/take-clause.md)
- [Take While Clause](../../../../visual-basic/language-reference/queries/take-while-clause.md)
