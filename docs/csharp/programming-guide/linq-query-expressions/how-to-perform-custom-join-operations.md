---
title: "How to: Perform Custom Join Operations (C# Programming Guide) | Microsoft Docs"
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
  - "custom joins [C#]"
  - "joins [C#], custom"
  - "query expressions [LINQ in C#], joins"
  - "queries [LINQ in C#], joins"
ms.assetid: a05e2ab1-410d-4a1d-8ada-af93539682c9
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Perform Custom Join Operations (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

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
  
 [!code-csharp[csProgGuideLINQ#64](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#64)]  
  
## Example  
 In the following example, the query must join two sequences based on matching keys that, in the case of the inner (right side) sequence, cannot be obtained prior to the join clause itself. If this join were performed with a `join` clause, then the `Split` method would have to be called for each element. The use of multiple `from` clauses enables the query to avoid the overhead of the repeated method call. However, since `join` is optimized, in this particular case it might still be faster than using multiple `from` clauses. The results will vary depending primarily on how expensive the method call is.  
  
 [!code-csharp[csProgGuideLINQ#13](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#13)]  
  
## Compiling the Code  
  
-   Create a [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] console application project that targets [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] 3.5 or later. By default, the project has a reference to System.Core.dll and a `using` directive for the System.Linq namespace.  
  
-   Replace the `Program` class with the code in the previous example.  
  
-   Follow the instructions in [How to: Join Content from Dissimilar Files (LINQ)](../Topic/How%20to:%20Join%20Content%20from%20Dissimilar%20Files%20\(LINQ\).md) to set up the data files, scores.csv and names.csv.  
  
-   Press F5 to compile and run the program.  
  
-   Press any key to exit the console window.  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [join clause](../../../csharp/language-reference/keywords/join-clause.md)   
 [Join Operations](../Topic/Join%20Operations.md)   
 [How to: Order the Results of a Join Clause](../../../csharp/programming-guide/linq-query-expressions/how-to-order-the-results-of-a-join-clause.md)