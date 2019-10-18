---
title: "Let Clause (Visual Basic)"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QueryLet"
helpviewer_keywords: 
  - "queries [Visual Basic], Let"
  - "Let clause [Visual Basic]"
  - "Let statement [Visual Basic]"
ms.assetid: 981aa516-16eb-4c53-b1f1-5aa3e82f316e
---
# Let Clause (Visual Basic)
Computes a value and assigns it to a new variable within the query.  
  
## Syntax  
  
```vb  
Let variable = expression [, ...]  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`variable`|Required. An alias that can be used to reference the results of the supplied expression.|  
|`expression`|Required. An expression that will be evaluated and assigned to the specified variable.|  
  
## Remarks  
 The `Let` clause enables you to compute values for each query result and reference them by using an alias. The alias can be used in other clauses, such as the `Where` clause. The `Let` clause enables you to create a query statement that is easier to read because you can specify an alias for an expression clause included in the query and substitute the alias each time the expression clause is used.  
  
 You can include any number of `variable` and `expression` assignments in the `Let` clause. Separate each assignment with a comma (,).  
  
## Example  
 The following code example uses the `Let` clause to compute a 10 percent discount on products.  
  
 [!code-vb[VbSimpleQuerySamples#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#16)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](../../../visual-basic/language-reference/queries/index.md)
- [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)
- [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)
- [Where Clause](../../../visual-basic/language-reference/queries/where-clause.md)
