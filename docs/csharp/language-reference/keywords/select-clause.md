---
title: "select clause (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "select_CSharpKeyword"
  - "select"
helpviewer_keywords: 
  - "select keyword [C#]"
  - "select clause [C#]"
ms.assetid: df01e266-5781-4aaa-80c4-67cf28ea093f
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# select clause (C# Reference)
In a query expression, the `select` clause specifies the type of values that will be produced when the query is executed. The result is based on the evaluation of all the previous clauses and on any expressions in the `select` clause itself. A query expression must terminate with either a `select` clause or a [group](../../../csharp/language-reference/keywords/group-clause.md) clause.  
  
 The following example shows a simple `select` clause in a query expression.  
  
 [!code-csharp[cscsrefQueryKeywords#8](../../../csharp/language-reference/keywords/codesnippet/CSharp/select-clause_1.cs)]  
  
 The type of the sequence produced by the `select` clause determines the type of the query variable `queryHighScores`. In the simplest case, the `select` clause just specifies the range variable. This causes the returned sequence to contain elements of the same type as the data source. For more information, see [Type Relationships in LINQ Query Operations](../../../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md). However, the `select` clause also provides a powerful mechanism for transforming (or *projecting*) source data into new types. For more information, see [Data Transformations with LINQ (C#)](../../../csharp/programming-guide/concepts/linq/data-transformations-with-linq.md).  
  
## Example  
 The following example shows all the different forms that a `select` clause may take. In each query, note the relationship between the `select` clause and the type of the *query variable* (`studentQuery1`, `studentQuery2`, and so on).  
  
 [!code-csharp[cscsrefQueryKeywords#9](../../../csharp/language-reference/keywords/codesnippet/CSharp/select-clause_2.cs)]  
  
 As shown in `studentQuery8` in the previous example, sometimes you might want the elements of the returned sequence to contain only a subset of the properties of the source elements. By keeping the returned sequence as small as possible you can reduce the memory requirements and increase the speed of the execution of the query. You can accomplish this by creating an anonymous type in the `select` clause and using an object initializer to initialize it with the appropriate properties from the source element. For an example of how to do this, see [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md).  
  
## Remarks  
 At compile time, the `select` clause is translated to a method call to the <xref:System.Linq.Enumerable.Select%2A> standard query operator.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [Query Keywords (LINQ)](../../../csharp/language-reference/keywords/query-keywords.md)  
 [from clause](../../../csharp/language-reference/keywords/from-clause.md)  
 [partial (Method) (C# Reference)](../../../csharp/language-reference/keywords/partial-method.md)  
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)  
 [Getting Started with LINQ in C#](../../../csharp/programming-guide/concepts/linq/getting-started-with-linq.md)
