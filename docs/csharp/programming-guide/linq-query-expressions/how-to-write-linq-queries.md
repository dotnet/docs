---
title: "How to: Write LINQ Queries in C# | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "query expressions [LINQ in C#], writing queries"
  - "queries [LINQ in C#], writing"
  - "writing LINQ queries"
ms.assetid: 45e47fcc-cfa1-4b72-b161-d038ae87bd23
caps.latest.revision: 25
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Write LINQ Queries in C#
This topic shows the three ways in which you can write a [!INCLUDE[vbteclinq](../../../csharp/includes/vbteclinq_md.md)] query in C#:  
  
1.  Use query syntax.  
  
2.  Use method syntax.  
  
3.  Use a combination of query syntax and method syntax.  
  
 The following examples demonstrate some simple [!INCLUDE[vbteclinq](../../../csharp/includes/vbteclinq_md.md)] queries by using each approach listed previously. In general, the rule is to use (1) whenever possible, and use (2) and (3) whenever necessary.  
  
> [!NOTE]
>  These queries operate on simple in-memory collections; however, the basic syntax is identical to that used in [!INCLUDE[vbtecdlinq](../../../csharp/includes/vbtecdlinq_md.md)] and [!INCLUDE[sqltecxlinq](../../../csharp/programming-guide/concepts/linq/includes/sqltecxlinq_md.md)].  
  
## Example  
  
## Query Syntax  
 The recommended way to write most queries is to use *query syntax* to create *query expressions*. The following example shows three query expressions. The first query expression demonstrates how to filter or restrict results by applying conditions with a `where` clause. It returns all elements in the source sequence whose values are greater than 7 or less than 3. The second expression demonstrates how to order the returned results. The third expression demonstrates how to group results according to a key. This query returns two groups based on the first letter of the word.  
  
 [!code-cs[csProgGuideLINQ#5](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-write-linq-queries_1.cs)]  
  
 Note that the type of the queries is <xref:System.Collections.Generic.IEnumerable%601>. All of these queries could be written using `var` as shown in the following example:  
  
 `var query = from num in numbers...`  
  
 In each previous example, the queries do not actually execute until you iterate over the query variable in a `foreach` statement. For more information, see [Introduction to LINQ Queries (C#)](../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
## Example  
  
## Method Syntax  
 Some query operations must be expressed as a method call. The most common such methods are those that return singleton numeric values, such as <xref:System.Linq.Enumerable.Sum%2A>, <xref:System.Linq.Enumerable.Max%2A>, <xref:System.Linq.Enumerable.Min%2A>, <xref:System.Linq.Enumerable.Average%2A>, and so on. These methods must always be called last in any query because they represent only a single value and cannot serve as the source for an additional query operation. The following example shows a method call in a query expression:  
  
 [!code-cs[csProgGuideLINQ#6](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-write-linq-queries_2.cs)]  
  
## Example  
 If the method has parameters, these are provided in the form of a [lambda](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md) expression, as shown in the following example:  
  
 [!code-cs[csProgGuideLINQ#7](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-write-linq-queries_3.cs)]  
  
 In the previous queries, only Query #4 executes immediately. This is because it returns a single value, and not a generic <xref:System.Collections.Generic.IEnumerable%601> collection. The method itself has to use `foreach` in order to compute its value.  
  
 Each of the previous queries can be written by using implicit typing with [var](../../../csharp/language-reference/keywords/var.md), as shown in the following example:  
  
 [!code-cs[csProgGuideLINQ#8](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-write-linq-queries_4.cs)]  
  
## Example  
  
## Mixed Query and Method Syntax  
 This example shows how to use method syntax on the results of a query clause. Just enclose the query expression in parentheses, and then apply the dot operator and call the method. In the following example, query #7 returns a count of the numbers whose value is between 3 and 7. In general, however, it is better to use a second variable to store the result of the method call. In this manner, the query is less likely to be confused with the results of the query.  
  
 [!code-cs[csProgGuideLINQ#9](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-write-linq-queries_5.cs)]  
  
 Because Query #7 returns a single value and not a collection, the query executes immediately.  
  
 The previous query can be written by using implicit typing with `var`, as follows:  
  
```  
var numCount = (from num in numbers...  
```  
  
 It can be written in method syntax as follows:  
  
```  
var numCount = numbers.Where(n => n < 3 || n > 7).Count();  
```  
  
 It can be written by using explicit typing, as follows:  
  
```  
int numCount = numbers.Where(n => n < 3 || n > 7).Count();  
```  
  
## See Also  
 [LINQ (Language-Integrated Query)](../Topic/LINQ%20\(Language-Integrated%20Query\).md)   
 [Walkthrough: Writing Queries in C#](../../../csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq.md)   
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [where clause](../../../csharp/language-reference/keywords/where-clause.md)