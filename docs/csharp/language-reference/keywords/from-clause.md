---
title: "from clause (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "from_CSharpKeyword"
  - "from"
helpviewer_keywords: 
  - "from clause [C#]"
  - "from keyword [C#]"
ms.assetid: 1aefd18c-1314-47f8-99ec-9bcefb09e699
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
---
# from clause (C# Reference)
A query expression must begin with a `from` clause. Additionally, a query expression can contain sub-queries, which also begin with a `from` clause. The `from` clause specifies the following:  
  
-   The data source on which the query or sub-query will be run.  
  
-   A local *range variable* that represents each element in the source sequence.  
  
 Both the range variable and the data source are strongly typed. The data source referenced in the `from` clause must have a type of <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, or a derived type such as <xref:System.Linq.IQueryable%601>.  
  
 In the following example, `numbers` is the data source and `num` is the range variable. Note that both variables are strongly typed even through the [var](../../../csharp/language-reference/keywords/var.md) keyword is used.  
  
 [!code-csharp[cscsrefQueryKeywords#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/from-clause_1.cs)]  
  
## The Range Variable  
 The compiler infers the type of the range variable when the data source implements <xref:System.Collections.Generic.IEnumerable%601>. For example, if the source has a type of `IEnumerable<Customer>`, then the range variable is inferred to be `Customer`. The only time that you must specify the type explicitly is when the source is a non-generic `IEnumerable` type such as <xref:System.Collections.ArrayList>. For more information, see [How to: Query an ArrayList with LINQ](../../programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md).  
  
 In the previous example `num` is inferred to be of type `int`. Because the range variable is strongly typed, you can call methods on it or use it in other operations. For example, instead of writing `select num`, you could write `select num.ToString()` to cause the query expression to return a sequence of strings instead of integers. Or you could write `select n + 10` to cause the expression to return the sequence 14, 11, 13, 12, 10. For more information, see [select clause](../../../csharp/language-reference/keywords/select-clause.md).  
  
 The range variable is like an iteration variable in a [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statement except for one very important difference: a range variable never actually stores data from the source. It just a syntactic convenience that enables the query to describe what will occur when the query is executed. For more information, see [Introduction to LINQ Queries (C#)](../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
## Compound from Clauses  
 In some cases, each element in the source sequence may itself be either a sequence or contain a sequence. For example, your data source may be an `IEnumerable<Student>` where each student object in the sequence contains a list of test scores. To access the inner list within each `Student` element, you can use compound `from` clauses. The technique is like using nested [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statements. You can add [where](../../../csharp/language-reference/keywords/partial-method.md) or [orderby](../../../csharp/language-reference/keywords/orderby-clause.md) clauses to either `from` clause to filter the results. The following example shows a sequence of `Student` objects, each of which contains an inner `List` of integers representing test scores. To access the inner list, use a compound `from` clause. You can insert clauses between the two `from` clauses if necessary.  
  
 [!code-csharp[cscsrefQueryKeywords#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/from-clause_2.cs)]  
  
## Using Multiple from Clauses to Perform Joins  
 A compound `from` clause is used to access inner collections in a single data source. However, a query can also contain multiple `from` clauses that generate supplemental queries from independent data sources. This technique enables you to perform certain types of join operations that are not possible by using the [join clause](../../../csharp/language-reference/keywords/join-clause.md).  
  
 The following example shows how two `from` clauses can be used to form a complete cross join of two data sources.  
  
 [!code-csharp[cscsrefQueryKeywords#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/from-clause_3.cs)]  
  
 For more information about join operations that use multiple `from` clauses, see [How to: Perform Custom Join Operations](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-custom-join-operations.md).  
  
## See Also  
 [Query Keywords (LINQ)](../../../csharp/language-reference/keywords/query-keywords.md)  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)
