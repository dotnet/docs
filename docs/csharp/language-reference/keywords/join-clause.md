---
title: "join clause (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "join"
  - "join_CSharpKeyword"
helpviewer_keywords: 
  - "join clause [C#]"
  - "join keyword [C#]"
ms.assetid: 76e9df84-092c-41a6-9537-c3f1cbd7f0fb
caps.latest.revision: 29
author: "BillWagner"
ms.author: "wiwagn"
---
# join clause (C# Reference)
The `join` clause is useful for associating elements from different source sequences that have no direct relationship in the object model. The only requirement is that the elements in each source share some value that can be compared for equality. For example, a food distributor might have a list of suppliers of a certain product, and a list of buyers. A `join` clause can be used, for example, to create a list of the suppliers and buyers of that product who are all in the same specified region.  
  
 A `join` clause takes two source sequences as input. The elements in each sequence must either be or contain a property that can be compared to a corresponding property in the other sequence. The `join` clause compares the specified keys for equality by using the special `equals` keyword. All joins performed by the `join` clause are equijoins. The shape of the output of a `join` clause depends on the specific type of join you are performing. The following are three most common join types:  
  
-   Inner join  
  
-   Group join  
  
-   Left outer join  
  
## Inner Join  
 The following example shows a simple inner equijoin. This query produces a flat sequence of "product name / category" pairs. The same category string will appear in multiple elements. If an element from `categories` has no matching `products`, that category will not appear in the results.  
  
 [!code-csharp[cscsrefQueryKeywords#24](../../../csharp/language-reference/keywords/codesnippet/CSharp/join-clause_1.cs)]  
  
 For more information, see [How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md).  
  
## Group Join  
 A `join` clause with an `into` expression is called a group join.  
  
 [!code-csharp[cscsrefQueryKeywords#25](../../../csharp/language-reference/keywords/codesnippet/CSharp/join-clause_2.cs)]  
  
 A group join produces a hierarchical result sequence, which associates elements in the left source sequence with one or more matching elements in the right side source sequence. A group join has no equivalent in relational terms; it is essentially a sequence of object arrays.  
  
 If no elements from the right source sequence are found to match an element in the left source, the `join` clause will produce an empty array for that item. Therefore, the group join is still basically an inner-equijoin except that the result sequence is organized into groups.  
  
 If you just select the results of a group join, you can access the items, but you cannot identify the key that they match on. Therefore, it is generally more useful to select the results of the group join into a new type that also has the key name, as shown in the previous example.  
  
 You can also, of course, use the result of a group join as the generator of another subquery:  
  
 [!code-csharp[cscsrefQueryKeywords#26](../../../csharp/language-reference/keywords/codesnippet/CSharp/join-clause_3.cs)]  
  
 For more information, see [How to: Perform Grouped Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-grouped-joins.md).  
  
## Left Outer Join  
 In a left outer join, all the elements in the left source sequence are returned, even if no matching elements are in the right sequence. To perform a left outer join in [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)], use the `DefaultIfEmpty` method in combination with a group join to specify a default right-side element to produce if a left-side element has no matches. You can use `null` as the default value for any reference type, or you can specify a user-defined default type. In the following example, a user-defined default type is shown:  
  
 [!code-csharp[cscsrefQueryKeywords#27](../../../csharp/language-reference/keywords/codesnippet/CSharp/join-clause_4.cs)]  
  
 For more information, see [How to: Perform Left Outer Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-left-outer-joins.md).  
  
## The equals operator  
 A `join` clause performs an equijoin. In other words, you can only base matches on the equality of two keys. Other types of comparisons such as "greater than" or "not equals" are not supported. To make clear that all joins are equijoins, the `join` clause uses the `equals` keyword instead of the `==` operator. The `equals` keyword can only be used in a `join` clause and it differs from the `==` operator in one important way. With `equals`, the left key consumes the outer source sequence, and the right key consumes the inner source. The outer source is only in scope on the left side of `equals` and the inner source sequence is only in scope on the right side.  
  
## Non-Equijoins  
 You can perform non-equijoins, cross joins, and other custom join operations by using multiple `from` clauses to introduce new sequences independently into a query. For more information, see [How to: Perform Custom Join Operations](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-custom-join-operations.md).  
  
## Joins on object collections vs. relational tables  
 In a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expression, join operations are performed on object collections. Object collections cannot be "joined" in exactly the same way as two relational tables. In [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)], explicit `join` clauses are only required when two source sequences are not tied by any relationship. When working with [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], foreign key tables are represented in the object model as properties of the primary table. For example, in the Northwind database, the Customer table has a foreign key relationship with the Orders table. When you map the tables to the object model, the Customer class has an Orders property that contains the collection of Orders associated with that Customer. In effect, the join has already been done for you.  
  
 For more information about querying across related tables in the context of [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], see [How to: Map Database Relationships](../../../framework/data/adonet/sql/linq/how-to-map-database-relationships.md).  
  
## Composite Keys  
 You can test for equality of multiple values by using a composite key. For more information, see [How to: Join by Using Composite Keys](../../../csharp/programming-guide/linq-query-expressions/how-to-join-by-using-composite-keys.md). Composite keys can be also used in a `group` clause.  
  
## Example  
 The following example compares the results of an inner join, a group join, and a left outer join on the same data sources by using the same matching keys. Some extra code is added to these examples to clarify the results in the console display.  
  
 [!code-csharp[cscsrefQueryKeywords#23](../../../csharp/language-reference/keywords/codesnippet/CSharp/join-clause_5.cs)]  
  
## Remarks  
 A `join` clause that is not followed by `into` is translated into a <xref:System.Linq.Enumerable.Join%2A> method call. A `join` clause that is followed by `into` is translated to a <xref:System.Linq.Enumerable.GroupJoin%2A> method call.  
  
## See Also  
 [Query Keywords (LINQ)](../../../csharp/language-reference/keywords/query-keywords.md)  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)  
 [Join Operations](../../programming-guide/concepts/linq/join-operations.md)  
 [group clause](../../../csharp/language-reference/keywords/group-clause.md)  
 [How to: Perform Left Outer Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-left-outer-joins.md)  
 [How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md)  
 [How to: Perform Grouped Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-grouped-joins.md)  
 [How to: Order the Results of a Join Clause](../../../csharp/programming-guide/linq-query-expressions/how-to-order-the-results-of-a-join-clause.md)  
 [How to: Join by Using Composite Keys](../../../csharp/programming-guide/linq-query-expressions/how-to-join-by-using-composite-keys.md)  
 [How to: Install Sample Databases](/visualstudio/data-tools/installing-database-systems-tools-and-samples)
