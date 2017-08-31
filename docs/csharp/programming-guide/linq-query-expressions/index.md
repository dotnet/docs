---
title: "LINQ Query Expressions (C# Programming Guide) | Microsoft Docs"
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
  - "expressions [C#], LINQ query expressions"
  - "queries [LINQ in C#], query expressions"
  - "LINQ [C#], query expressions"
  - "query expressions [LINQ in C#]"
  - "C# Language, LINQ query expressions"
ms.assetid: 40638f19-fb46-4d26-a2d9-a383b48f5ed4
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# LINQ Query Expressions (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

[!INCLUDE[vbteclinqext](../../../includes/vbteclinqext-md.md)] is the name for a set of technologies based on the integration of query capabilities directly into the C# language (also in Visual Basic and potentially any other .NET language). With [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)], a query is now a first-class language construct, just like classes, methods, events and so on.  
  
 For a developer who writes queries, the most visible "language-integrated" part of [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] is the query expression. Query expressions are written in a declarative *query syntax* introduced in C# 3.0. By using query syntax, you can perform even complex filtering, ordering, and grouping operations on data sources with a minimum of code. You use the same basic query expression patterns to query and transform data in SQL databases, [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] Datasets, XML documents and streams, and .NET collections.  
  
 The following example shows the complete query operation. The complete operation includes creating a data source, defining the query expression, and executing the query in a `foreach` statement.  
  
 [!code-csharp[csProgGuideLINQ#11](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#11)]  
  
 For more information about the basics of [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] in C#, see [Getting Started with LINQ in C#](../../../csharp/programming-guide/concepts/linq/getting-started-with-linq.md).  
  
## Query Expression Overview  
  
-   Query expressions can be used to query and to transform data from any [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)]-enabled data source. For example, a single query can retrieve data from a SQL database, and produce an XML stream as output.  
  
-   Query expressions are easy to master because they use many familiar C# language constructs. For more information, see [Getting Started with LINQ in C#](../../../csharp/programming-guide/concepts/linq/getting-started-with-linq.md).  
  
-   The variables in a query expression are all strongly typed, although in many cases you do not have to provide the type explicitly because the compiler can infer it. For more information, see [Type Relationships in LINQ Query Operations](../../../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md).  
  
-   A query is not executed until you iterate over the query variable in a `foreach` statement. For more information, see [Introduction to LINQ Queries (C#)](../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
-   At compile time, query expressions are converted to Standard Query Operator method calls according to the rules set forth in the C# specification. Any query that can be expressed by using query syntax can also be expressed by using method syntax. However, in most cases query syntax is more readable and concise. For more information, see [C# Language Specification](../../../csharp/language-reference/language-specification.md) and [Standard Query Operators Overview](../Topic/Standard%20Query%20Operators%20Overview.md).  
  
-   As a rule when you write [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] queries, we recommend that you use query syntax whenever possible and method syntax whenever necessary. There is no semantic or performance difference between the two different forms. Query expressions are often more readable than equivalent expressions written in method syntax.  
  
-   Some query operations, such as <xref:System.Linq.Enumerable.Count%2A> or <xref:System.Linq.Enumerable.Max%2A>, have no equivalent query expression clause and must therefore be expressed as a method call. Method syntax can be combined with query syntax in various ways. For more information, see [Query Syntax and Method Syntax in LINQ](../../../csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md).  
  
-   Query expressions can be compiled to expression trees or to delegates, depending on the type that the query is applied to. <xref:System.Collections.Generic.IEnumerable%601> queries are compiled to delegates. <xref:System.Linq.IQueryable> and <xref:System.Linq.IQueryable%601> queries are compiled to expression trees. For more information, see [Expression Trees](../Topic/Expression%20Trees%20\(C%23%20and%20Visual%20Basic\).md).  
  
 The following table lists topics that provide additional information about queries and code examples for common tasks.  
  
|Topic|Description|  
|-----------|-----------------|  
|[Query Expression Basics](../../../csharp/programming-guide/linq-query-expressions/query-expression-basics.md)|Introduces fundamental query concepts and provides examples of C# query syntax.|  
|[How to: Write LINQ Queries in C#](../../../csharp/programming-guide/linq-query-expressions/how-to-write-linq-queries.md)|Provides examples of several basic types of query expressions.|  
|[How to: Handle Exceptions in Query Expressions](../../../csharp/programming-guide/linq-query-expressions/how-to-handle-exceptions-in-query-expressions.md)|How and when to move potential exception-throwing code outside a query expression.|  
|[How to: Populate Object Collections from Multiple Sources (LINQ)](../Topic/How%20to:%20Populate%20Object%20Collections%20from%20Multiple%20Sources%20\(LINQ\).md)|How to use the `select` statement to merge data from different sources into a new type.|  
|[How to: Group Query Results](../../../csharp/programming-guide/linq-query-expressions/how-to-group-query-results.md)|Shows different ways to use the `group` clause.|  
|[How to: Create a Nested Group](../../../csharp/programming-guide/linq-query-expressions/how-to-create-a-nested-group.md)|Shows how to create nested groups.|  
|[How to: Perform a Subquery on a Grouping Operation](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-a-subquery-on-a-grouping-operation.md)|Shows how to use a sub-expression in a query as a data source for a new query.|  
|[How to: Group Results by Contiguous Keys](../../../csharp/programming-guide/linq-query-expressions/how-to-group-results-by-contiguous-keys.md)|Shows how to implement a thread-safe standard query operator that can perform grouping operations on streaming data sources.|  
|[How to: Dynamically Specify Predicate Filters at Runtime](../../../csharp/programming-guide/linq-query-expressions/how-to-dynamically-specify-predicate-filters-at-runtime.md)|Shows how to supply an arbitrary number of values to use in equality comparisons in a `where` clause.|  
|[How to: Store the Results of a Query in Memory](../../../csharp/programming-guide/linq-query-expressions/how-to-store-the-results-of-a-query-in-memory.md)|Illustrates how to materialize and store query results without necessarily using a `foreach` loop.|  
|[How to: Return a Query from a Method](../../../csharp/programming-guide/linq-query-expressions/how-to-return-a-query-from-a-method.md)|Shows how to return query variables from methods, and how to pass them to methods as input parameters.|  
|[How to: Perform Custom Join Operations](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-custom-join-operations.md)|Shows how to perform join operations based on any kind of predicate function.|  
|[How to: Join by Using Composite Keys](../../../csharp/programming-guide/linq-query-expressions/how-to-join-by-using-composite-keys.md)|Shows how to join two sources based on more than one matching key.|  
|[How to: Order the Results of a Join Clause](../../../csharp/programming-guide/linq-query-expressions/how-to-order-the-results-of-a-join-clause.md)|Shows how to order a sequence that is produced by a join operation.|  
|[How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md)|Shows how to perform an inner join in [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)].|  
|[How to: Perform Grouped Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-grouped-joins.md)|Shows how to produce a grouped join in [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)].|  
|[How to: Perform Left Outer Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-left-outer-joins.md)|Shows how to produce a left outer join in [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)].|  
|[How to: Handle Null Values in Query Expressions](../../../csharp/programming-guide/linq-query-expressions/how-to-handle-null-values-in-query-expressions.md)|Shows how to handle null values in [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] queries.|  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [LINQ (Language-Integrated Query)](../Topic/LINQ%20\(Language-Integrated%20Query\).md)   
 [Walkthrough: Writing Queries in C#](../../../csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq.md)   
 [Basic LINQ Query Operations](../../../csharp/programming-guide/concepts/linq/basic-linq-query-operations.md)   
 [Query Syntax and Method Syntax in LINQ](../../../csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md)   
 [Standard Query Operators Overview](../Topic/Standard%20Query%20Operators%20Overview.md)   
 [Query Keywords (LINQ)](../../../csharp/language-reference/keywords/query-keywords.md)   
 [How Linq to Objects Queries Work](http://go.microsoft.com/fwlink/?LinkId=112389)   
 [Reading and Writing Queries](http://go.microsoft.com/fwlink/?LinkId=112391)   
 [What is a collection?](http://go.microsoft.com/fwlink/?LinkId=112394)   
 [Link to Everything: A List of LINQ Providers](http://go.microsoft.com/fwlink/?LinkId=112411)