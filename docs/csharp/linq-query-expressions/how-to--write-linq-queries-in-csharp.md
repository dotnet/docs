---
title: "How to: Write LINQ Queries in C#"
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
This topic shows the three ways in which you can write a [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query in C#:  
  
1.  Use query syntax.  
  
2.  Use method syntax.  
  
3.  Use a combination of query syntax and method syntax.  
  
 The following examples demonstrate some simple [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries by using each approach listed previously. In general, the rule is to use (1) whenever possible, and use (2) and (3) whenever necessary.  
  
> [!NOTE]
>  These queries operate on simple in-memory collections; however, the basic syntax is identical to that used in [!INCLUDE[vbtecdlinq](../keywords/includes/vbtecdlinq_md.md)] and [!INCLUDE[sqltecxlinq](../linq/includes/sqltecxlinq_md.md)].  
  
## Example  
  
## Query Syntax  
 The recommended way to write most queries is to use *query syntax* to create *query expressions*. The following example shows three query expressions. The first query expression demonstrates how to filter or restrict results by applying conditions with a `where` clause. It returns all elements in the source sequence whose values are greater than 7 or less than 3. The second expression demonstrates how to order the returned results. The third expression demonstrates how to group results according to a key. This query returns two groups based on the first letter of the word.  
  
 [!code[csProgGuideLINQ#5](../arrays/codesnippet/CSharp/how-to--write-linq-queries-in-csharp_1.cs)]  
  
 Note that the type of the queries is <xref:System.Collections.Generic.IEnumerable`1>. All of these queries could be written using `var` as shown in the following example:  
  
 `var query = from num in numbers...`  
  
 In each previous example, the queries do not actually execute until you iterate over the query variable in a `foreach` statement. For more information, see [Introduction to LINQ Queries (C#)](../linq/introduction-to-linq-queries--csharp-.md).  
  
## Example  
  
## Method Syntax  
 Some query operations must be expressed as a method call. The most common such methods are those that return singleton numeric values, such as <xref:System.Linq.Enumerable.Sum*>, <xref:System.Linq.Enumerable.Max*>, <xref:System.Linq.Enumerable.Min*>, <xref:System.Linq.Enumerable.Average*>, and so on. These methods must always be called last in any query because they represent only a single value and cannot serve as the source for an additional query operation. The following example shows a method call in a query expression:  
  
 [!code[csProgGuideLINQ#6](../arrays/codesnippet/CSharp/how-to--write-linq-queries-in-csharp_2.cs)]  
  
## Example  
 If the method has parameters, these are provided in the form of a [lambda](../statements-expressions-operators/lambda-expressions--csharp-programming-guide-.md) expression, as shown in the following example:  
  
 [!code[csProgGuideLINQ#7](../arrays/codesnippet/CSharp/how-to--write-linq-queries-in-csharp_3.cs)]  
  
 In the previous queries, only Query #4 executes immediately. This is because it returns a single value, and not a generic <xref:System.Collections.Generic.IEnumerable`1> collection. The method itself has to use `foreach` in order to compute its value.  
  
 Each of the previous queries can be written by using implicit typing with [var](../keywords/var--csharp-reference-.md), as shown in the following example:  
  
 [!code[csProgGuideLINQ#8](../arrays/codesnippet/CSharp/how-to--write-linq-queries-in-csharp_4.cs)]  
  
## Example  
  
## Mixed Query and Method Syntax  
 This example shows how to use method syntax on the results of a query clause. Just enclose the query expression in parentheses, and then apply the dot operator and call the method. In the following example, query #7 returns a count of the numbers whose value is between 3 and 7. In general, however, it is better to use a second variable to store the result of the method call. In this manner, the query is less likely to be confused with the results of the query.  
  
 [!code[csProgGuideLINQ#9](../arrays/codesnippet/CSharp/how-to--write-linq-queries-in-csharp_5.cs)]  
  
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
 [Walkthrough: Writing Queries in C#](../linq/walkthrough--writing-queries-in-csharp--linq-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [where clause](../keywords/where-clause--csharp-reference-.md)