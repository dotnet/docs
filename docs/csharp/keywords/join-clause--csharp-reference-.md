---
title: "join clause (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "join"
  - "join_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "join clause [C#]"
  - "join keyword [C#]"
ms.assetid: 76e9df84-092c-41a6-9537-c3f1cbd7f0fb
caps.latest.revision: 29
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
# join clause (C# Reference)
The `join` clause is useful for associating elements from different source sequences that have no direct relationship in the object model. The only requirement is that the elements in each source share some value that can be compared for equality. For example, a food distributor might have a list of suppliers of a certain product, and a list of buyers. A `join` clause can be used, for example, to create a list of the suppliers and buyers of that product who are all in the same specified region.  
  
 A `join` clause takes two source sequences as input. The elements in each sequence must either be or contain a property that can be compared to a corresponding property in the other sequence. The `join` clause compares the specified keys for equality by using the special `equals` keyword. All joins performed by the `join` clause are equijoins. The shape of the output of a `join` clause depends on the specific type of join you are performing. The following are three most common join types:  
  
-   Inner join  
  
-   Group join  
  
-   Left outer join  
  
## Inner Join  
 The following example shows a simple inner equijoin. This query produces a flat sequence of "product name / category" pairs. The same category string will appear in multiple elements. If an element from `categories` has no matching `products`, that category will not appear in the results.  
  
 [!code[cscsrefQueryKeywords#24](../classes-and-structs/codesnippet/CSharp/join-clause--csharp-reference-_1.cs)]  
  
 For more information, see [How to: Perform Inner Joins](../linq-query-expressions/how-to--perform-inner-joins--csharp-programming-guide-.md).  
  
## Group Join  
 A `join` clause with an `into` expression is called a group join.  
  
 [!code[cscsrefQueryKeywords#25](../classes-and-structs/codesnippet/CSharp/join-clause--csharp-reference-_2.cs)]  
  
 A group join produces a hierarchical result sequence, which associates elements in the left source sequence with one or more matching elements in the right side source sequence. A group join has no equivalent in relational terms; it is essentially a sequence of object arrays.  
  
 If no elements from the right source sequence are found to match an element in the left source, the `join` clause will produce an empty array for that item. Therefore, the group join is still basically an inner-equijoin except that the result sequence is organized into groups.  
  
 If you just select the results of a group join, you can access the items, but you cannot identify the key that they match on. Therefore, it is generally more useful to select the results of the group join into a new type that also has the key name, as shown in the previous example.  
  
 You can also, of course, use the result of a group join as the generator of another subquery:  
  
 [!code[cscsrefQueryKeywords#26](../classes-and-structs/codesnippet/CSharp/join-clause--csharp-reference-_3.cs)]  
  
 For more information, see [How to: Perform Grouped Joins](../linq-query-expressions/how-to--perform-grouped-joins--csharp-programming-guide-.md).  
  
## Left Outer Join  
 In a left outer join, all the elements in the left source sequence are returned, even if no matching elements are in the right sequence. To perform a left outer join in [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)], use the `DefaultIfEmpty` method in combination with a group join to specify a default right-side element to produce if a left-side element has no matches. You can use `null` as the default value for any reference type, or you can specify a user-defined default type. In the following example, a user-defined default type is shown:  
  
 [!code[cscsrefQueryKeywords#27](../classes-and-structs/codesnippet/CSharp/join-clause--csharp-reference-_4.cs)]  
  
 For more information, see [How to: Perform Left Outer Joins](../linq-query-expressions/how-to--perform-left-outer-joins--csharp-programming-guide-.md).  
  
## The equals operator  
 A `join` clause performs an equijoin. In other words, you can only base matches on the equality of two keys. Other types of comparisons such as "greater than" or "not equals" are not supported. To make clear that all joins are equijoins, the `join` clause uses the `equals` keyword instead of the `==` operator. The `equals` keyword can only be used in a `join` clause and it differs from the `==` operator in one important way. With `equals`, the left key consumes the outer source sequence, and the right key consumes the inner source. The outer source is only in scope on the left side of `equals` and the inner source sequence is only in scope on the right side.  
  
## Non-Equijoins  
 You can perform non-equijoins, cross joins, and other custom join operations by using multiple `from` clauses to introduce new sequences independently into a query. For more information, see [How to: Perform Custom Join Operations](../linq-query-expressions/how-to--perform-custom-join-operations--csharp-programming-guide-.md).  
  
## Joins on object collections vs. relational tables  
 In a [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query expression, join operations are performed on object collections. Object collections cannot be "joined" in exactly the same way as two relational tables. In [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)], explicit `join` clauses are only required when two source sequences are not tied by any relationship. When working with [!INCLUDE[vbtecdlinq](../keywords/includes/vbtecdlinq_md.md)], foreign key tables are represented in the object model as properties of the primary table. For example, in the Northwind database, the Customer table has a foreign key relationship with the Orders table. When you map the tables to the object model, the Customer class has an Orders property that contains the collection of Orders associated with that Customer. In effect, the join has already been done for you.  
  
 For more information about querying across related tables in the context of [!INCLUDE[vbtecdlinq](../keywords/includes/vbtecdlinq_md.md)], see [How to: Map Database Relationships](../Topic/How%20to:%20Map%20Database%20Relationships.md).  
  
## Composite Keys  
 You can test for equality of multiple values by using a composite key. For more information, see [How to: Join by Using Composite Keys](../linq-query-expressions/how-to--join-by-using-composite-keys--csharp-programming-guide-.md). Composite keys can be also used in a `group` clause.  
  
## Example  
 The following example compares the results of an inner join, a group join, and a left outer join on the same data sources by using the same matching keys. Some extra code is added to these examples to clarify the results in the console display.  
  
 [!code[cscsrefQueryKeywords#23](../classes-and-structs/codesnippet/CSharp/join-clause--csharp-reference-_5.cs)]  
  
## Remarks  
 A `join` clause that is not followed by `into` is translated into a <xref:System.Linq.Enumerable.Join*> method call. A `join` clause that is followed by `into` is translated to a <xref:System.Linq.Enumerable.GroupJoin*> method call.  
  
## See Also  
 [Query Keywords (LINQ)](../keywords/query-keywords--csharp-reference-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [Join Operations](../Topic/Join%20Operations.md)   
 [group clause](../keywords/group-clause--csharp-reference-.md)   
 [How to: Perform Left Outer Joins](../linq-query-expressions/how-to--perform-left-outer-joins--csharp-programming-guide-.md)   
 [How to: Perform Inner Joins](../linq-query-expressions/how-to--perform-inner-joins--csharp-programming-guide-.md)   
 [How to: Perform Grouped Joins](../linq-query-expressions/how-to--perform-grouped-joins--csharp-programming-guide-.md)   
 [How to: Order the Results of a Join Clause](../linq-query-expressions/how-to--order-the-results-of-a-join-clause--csharp-programming-guide-.md)   
 [How to: Join by Using Composite Keys](../linq-query-expressions/how-to--join-by-using-composite-keys--csharp-programming-guide-.md)   
 [How to: Install Sample Databases](../Topic/How%20to:%20Install%20Sample%20Databases.md)