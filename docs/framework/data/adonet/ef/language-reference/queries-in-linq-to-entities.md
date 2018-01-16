---
title: "Queries in LINQ to Entities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c015a609-29eb-4e95-abb1-2ca721c6e2ad
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Queries in LINQ to Entities
A query is an expression that retrieves data from a data source. Queries are usually expressed in a specialized query language, such as SQL for relational databases and XQuery for XML. Therefore, developers have had to learn a new query language for each type of data source or data format that they query. Language-Integrated Query (LINQ) offers a simpler, consistent model for working with data across various kinds of data sources and formats. In a LINQ query, you always work with programming objects.  
  
 A LINQ query operation consists of three actions: obtain the data source or sources, create the query, and execute the query.  
  
 Data sources that implement the <xref:System.Collections.Generic.IEnumerable%601> generic interface or the <xref:System.Linq.IQueryable%601> generic interface can be queried through LINQ. Instances of the generic <xref:System.Data.Objects.ObjectQuery%601> class, which implements the generic <xref:System.Linq.IQueryable%601> interface, serve as the data source for [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries. The <xref:System.Data.Objects.ObjectQuery%601> generic class represents a query that returns a collection of zero or more typed objects. You can also let the compiler infer the type of an entity by using the C# keyword `var` (Dim in Visual Basic).  
  
 In the query, you specify exactly the information that you want to retrieve from the data source. A query can also specify how that information should be sorted, grouped, and shaped before it is returned. In LINQ, a query is stored in a variable. If the query returns a sequence of values, the query variable itself must be a queryable type. This query variable takes no action and returns no data; it only stores the query information. After you create a query you must execute that query to retrieve any data.  
  
## Query Syntax  
 [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries can be composed in two different syntaxes: query expression syntax and method-based query syntax. Query expression syntax is new in C# 3.0 and Visual Basic 9.0, and it consists of a set of clauses written in a declarative syntax similar to Transact-SQL or XQuery. However, the [!INCLUDE[dnprdnshort](../../../../../../includes/dnprdnshort-md.md)] common language runtime (CLR) cannot read the query expression syntax itself. Therefore, at compile time, query expressions are translated to something that the CLR does understand: method calls. These methods are known as the *standard query operators*. As a developer, you have the option of calling them directly by using method syntax, instead of using query syntax. For more information, see [Query Syntax and Method Syntax in LINQ](~/docs/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md).  
  
### Query Expression Syntax  
 Query expressions are a declarative query syntax. This syntax enables a developer to write queries in a high-level language that is formatted similar to Transact-SQL. By using query expression syntax, you can perform even complex filtering, ordering, and grouping operations on data sources with minimal code. For more information, [Basic Query Operations (Visual Basic)](~/docs/visual-basic/programming-guide/concepts/linq/basic-query-operations.md). For examples that demonstrate how to use the query expression syntax, see the following topics:  
  
-   [Query Expression Syntax Examples: Projection](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-projection.md)  
  
-   [Query Expression Syntax Examples: Filtering](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-filtering.md)  
  
-   [Query Expression Syntax Examples: Ordering](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-ordering.md)  
  
-   [Query Expression Syntax Examples: Aggregate Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-aggregate-operators.md)  
  
-   [Query Expression Syntax Examples: Partitioning](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-partitioning.md)  
  
-   [Query Expression Syntax Examples: Join Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-join-operators.md)  
  
-   [Query Expression Syntax Examples: Element Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-element-operators.md)  
  
-   [Query Expression Syntax Examples: Grouping](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-grouping.md)  
  
-   [Query Expression Syntax Examples: Navigating Relationships](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-navigating-relationships.md)  
  
### Method-Based Query Syntax  
 Another way to compose [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries is by using method-based queries. The method-based query syntax is a sequence of direct method calls to LINQ operator methods, passing lambda expressions as the parameters. For more information, see [Lambda Expressions](~/docs/csharp/programming-guide/statements-expressions-operators/lambda-expressions.md). For examples that demonstrate how to use method-based syntax, see the following topics:  
  
-   [Method-Based Query Syntax Examples: Projection](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-projection.md)  
  
-   [Method-Based Query Syntax Examples: Filtering](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-filtering.md)  
  
-   [Method-Based Query Syntax Examples: Ordering](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-ordering.md)  
  
-   [Method-Based Query Syntax Examples: Aggregate Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-aggregate-operators.md)  
  
-   [Method-Based Query Syntax Examples: Partitioning](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-partitioning.md)  
  
-   [Method-Based Query Syntax Examples: Conversion](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-conversion.md)  
  
-   [Method-Based Query Syntax Examples: Join Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-join-operators.md)  
  
-   [Method-Based Query Syntax Examples: Element Operators](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-element-operators.md)  
  
-   [Method-Based Query Syntax Examples: Grouping](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-grouping.md)  
  
-   [Method-Based Query Syntax Examples: Navigating Relationships](../../../../../../docs/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-navigating-relationships.md)  
  
## See Also  
 [LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/linq-to-entities.md)  
 [Getting Started with LINQ in C#](~/docs/csharp/programming-guide/concepts/linq/getting-started-with-linq.md)  
 [Getting Started with LINQ in Visual Basic](~/docs/visual-basic/programming-guide/concepts/linq/getting-started-with-linq.md)  
 [Entity Framework Merge Options and Compiled Queries](http://go.microsoft.com/fwlink/?LinkId=199591)
