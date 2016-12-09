---
title: "How to: Perform Custom Join Operations (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "custom joins [C#]"
  - "joins [C#], custom"
  - "query expressions [LINQ in C#], joins"
  - "queries [LINQ in C#], joins"
ms.assetid: a05e2ab1-410d-4a1d-8ada-af93539682c9
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"

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
# How to: Perform Custom Join Operations (C# Programming Guide)
This example shows how to perform join operations that are not possible with the `join` clause. In a query expression, the `join` clause is limited to, and optimized for, equijoins, which are by far the most common type of join operation. When performing an equijoin, you will probably always get the best performance by using the `join` clause.  
  
 However, the `join` clause cannot be used in the following cases:  
  
-   When the join is predicated on an expression of inequality (a non-equijoin).  
  
-   When the join is predicated on more than one expression of equality or inequality.  
  
-   When you have to introduce a temporary range variable for the right side (inner) sequence before the join operation.  
  
 To perform joins that are not equijoins, you can use multiple `from` clauses to introduce each data source independently. You then apply a predicate expression in a `where` clause to the range variable for each source. The expression also can take the form of a method call.  
  
> [!NOTE]
>  Do not confuse this kind of custom join operation with the use of multiple `from` clauses to access inner collections. For more information, see [join clause](../../../csharp/language-reference/keywords/join-clause.md).  
  
## Example  
 The first method in the following example shows a simple cross join. Cross joins must be used with caution because they can produce very large result sets. However, they can be useful in some scenarios for creating source sequences against which additional queries are run.  
  
 The second method produces a sequence of all the products whose category ID is listed in the category list on the left side. Note the use of the `let` clause and the `Contains` method to create a temporary array. It also is possible to create the array before the query and eliminate the first `from` clause.  
  
 [!code-cs[csProgGuideLINQ#64](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-perform-custom-join-operations_1.cs)]  
  
## Example  
 In the following example, the query must join two sequences based on matching keys that, in the case of the inner (right side) sequence, cannot be obtained prior to the join clause itself. If this join were performed with a `join` clause, then the `Split` method would have to be called for each element. The use of multiple `from` clauses enables the query to avoid the overhead of the repeated method call. However, since `join` is optimized, in this particular case it might still be faster than using multiple `from` clauses. The results will vary depending primarily on how expensive the method call is.  
  
 [!code-cs[csProgGuideLINQ#13](../../../csharp/programming-guide/arrays/codesnippet/CSharp/how-to-perform-custom-join-operations_2.cs)]  
  
## Compiling the Code  
  
-   Create a [!INCLUDE[vs_current_short](../../../csharp/programming-guide/classes-and-structs/includes/vs_current_short_md.md)] console application project that targets [!INCLUDE[dnprdnshort](../../../csharp/getting-started/includes/dnprdnshort_md.md)] 3.5 or later. By default, the project has a reference to System.Core.dll and a `using` directive for the System.Linq namespace.  
  
-   Replace the `Program` class with the code in the previous example.  
  
-   Follow the instructions in [How to: Join Content from Dissimilar Files (LINQ)](http://msdn.microsoft.com/library/9ce5ce84-b38f-4e48-bf15-382e7a488f0b) to set up the data files, scores.csv and names.csv.  
  
-   Press F5 to compile and run the program.  
  
-   Press any key to exit the console window.  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [join clause](../../../csharp/language-reference/keywords/join-clause.md)   
 [Join Operations](http://msdn.microsoft.com/library/442d176d-028c-4beb-8d22-407d4ef89107)   
 [How to: Order the Results of a Join Clause](../../../csharp/programming-guide/linq-query-expressions/how-to-order-the-results-of-a-join-clause.md)