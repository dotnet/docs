---
title: Write LINQ queries in C#
description: How to write queries.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 30703f79-cf3a-4d02-b892-c95d58a1d9ed
---

# Write LINQ queries in C#

This topic shows the three ways in which you can write a LINQ query in C#:  
  
1.  Use query syntax.  
  
2.  Use method syntax.  
  
3.  Use a combination of query syntax and method syntax.  
  
 The following examples demonstrate some simple LINQ queries by using each approach listed previously. In general, the rule is to use (1) whenever possible, and use (2) and (3) whenever necessary.  
  
> [!NOTE]
>  These queries operate on simple in-memory collections; however, the basic syntax is identical to that used in LINQ to Entities and LINQ to XML.  
  
## Example  
  
## Query syntax  
 The recommended way to write most queries is to use *query syntax* to create *query expressions*. The following example shows three query expressions. The first query expression demonstrates how to filter or restrict results by applying conditions with a `where` clause. It returns all elements in the source sequence whose values are greater than 7 or less than 3. The second expression demonstrates how to order the returned results. The third expression demonstrates how to group results according to a key. This query returns two groups based on the first letter of the word.  
  
 [!code-csharp[csProgGuideLINQ#5](../../../samples/snippets/csharp/concepts/linq/how-to-write-linq-queries_1.cs)]  
  
 Note that the type of the queries is <xref:System.Collections.Generic.IEnumerable%601>. All of these queries could be written using `var` as shown in the following example:  
  
 `var query = from num in numbers...`  
  
 In each previous example, the queries do not actually execute until you iterate over the query variable in a `foreach` statement or other statement. For more information, see [Introduction to LINQ Queries](../programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
## Example  
  
## Method syntax  
 Some query operations must be expressed as a method call. The most common such methods are those that return singleton numeric values, such as <xref:System.Linq.Enumerable.Sum%2A>, <xref:System.Linq.Enumerable.Max%2A>, <xref:System.Linq.Enumerable.Min%2A>, <xref:System.Linq.Enumerable.Average%2A>, and so on. These methods must always be called last in any query because they represent only a single value and cannot serve as the source for an additional query operation. The following example shows a method call in a query expression:  
  
 [!code-csharp[csProgGuideLINQ#6](../../../samples/snippets/csharp/concepts/linq/how-to-write-linq-queries_2.cs)]  
  
## Example  
 If the method has  Action or Func parameters, these are provided in the form of a [lambda](../programming-guide/statements-expressions-operators/lambda-expressions.md) expression, as shown in the following example:  
  
 [!code-csharp[csProgGuideLINQ#7](../../../samples/snippets/csharp/concepts/linq/how-to-write-linq-queries_3.cs)]  
  
 In the previous queries, only Query #4 executes immediately. This is because it returns a single value, and not a generic <xref:System.Collections.Generic.IEnumerable%601> collection. The method itself has to use `foreach` in order to compute its value.  
  
 Each of the previous queries can be written by using implicit typing with [var](../language-reference/keywords/var.md), as shown in the following example:  
  
 [!code-csharp[csProgGuideLINQ#8](../../../samples/snippets/csharp/concepts/linq/how-to-write-linq-queries_4.cs)]  
  
## Example  
  
## Mixed query and method syntax  
 This example shows how to use method syntax on the results of a query clause. Just enclose the query expression in parentheses, and then apply the dot operator and call the method. In the following example, query #7 returns a count of the numbers whose value is between 3 and 7. In general, however, it is better to use a second variable to store the result of the method call. In this manner, the query is less likely to be confused with the results of the query.  
  
 [!code-csharp[csProgGuideLINQ#9](../../../samples/snippets/csharp/concepts/linq/how-to-write-linq-queries_5.cs)]  
  
 Because Query #7 returns a single value and not a collection, the query executes immediately.  
  
 The previous query can be written by using implicit typing with `var`, as follows:  
  
```csharp  
var numCount = (from num in numbers...  
```  
  
 It can be written in method syntax as follows:  
  
```csharp  
var numCount = numbers.Where(n => n < 3 || n > 7).Count();  
```  
  
 It can be written by using explicit typing, as follows:  
  
```csharp  
int numCount = numbers.Where(n => n < 3 || n > 7).Count();  
```  
  
## See Also  
  [Walkthrough: Writing Queries in C#](../programming-guide/concepts/linq/walkthrough-writing-queries-linq.md)   
 [LINQ Query Expressions](index.md)  
 [where clause](../language-reference/keywords/where-clause.md)
