---
description: "Learn more about: Skip While Clause (Visual Basic)"
title: "Skip While Clause"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.QuerySkipWhile"
helpviewer_keywords: 
  - "Skip While statement [Visual Basic]"
  - "Skip While clause [Visual Basic]"
  - "queries [Visual Basic], Skip While"
ms.assetid: 5dee8350-7520-4f1a-b00d-590cacd572d6
---
# Skip While Clause (Visual Basic)

Bypasses elements in a collection as long as a specified condition is `true` and then returns the remaining elements.  
  
## Syntax  
  
```vb  
Skip While expression  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`expression`|Required. An expression that represents a condition to test elements for. The expression must return a `Boolean` value or a functional equivalent, such as an `Integer` to be evaluated as a `Boolean`.|  
  
## Remarks  

 The `Skip While` clause bypasses elements from the beginning of a query result until the supplied `expression` returns `false`. After `expression` returns `false`, the query returns all the remaining elements. The `expression` is ignored for the remaining results.  
  
 The `Skip While` clause differs from the `Where` clause in that the `Where` clause can be used to exclude all elements from a query that do not meet a particular condition. The `Skip While` clause excludes elements only until the first time that the condition is not satisfied. The `Skip While` clause is most useful when you are working with an ordered query result.  
  
 You can bypass a specific number of results from the beginning of a query result by using the `Skip` clause.  
  
## Example  

 The following code example uses the `Skip While` clause to bypass results until the first customer from the United States is found.  
  
 [!code-vb[VbSimpleQuerySamples#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#3)]  
  
## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
- [Skip Clause](skip-clause.md)
- [Take While Clause](take-while-clause.md)
- [Where Clause](where-clause.md)
