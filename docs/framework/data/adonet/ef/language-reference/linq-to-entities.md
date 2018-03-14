---
title: "LINQ to Entities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 641f9b68-9046-47a1-abb0-1c8eaeda0e2d
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LINQ to Entities
LINQ to Entities provides Language-Integrated Query (LINQ) support that enables developers to write queries against the Entity Framework conceptual model using Visual Basic or Visual C#. Queries against the Entity Framework are represented by command tree queries, which execute against the object context. LINQ to Entities converts Language-Integrated Queries (LINQ) queries to command tree queries, executes the queries against the Entity Framework, and returns objects that can be used by both the Entity Framework and LINQ. The following is the process for creating and executing a LINQ to Entities query:  
  
1.  Construct an <xref:System.Data.Objects.ObjectQuery%601> instance from <xref:System.Data.Objects.ObjectContext>.  
  
2.  Compose a LINQ to Entities query in C# or Visual Basic by using the <xref:System.Data.Objects.ObjectQuery%601> instance.  
  
3.  Convert LINQ standard query operators and expressions to command trees.  
  
4.  Execute the query, in command tree representation, against the data source. Any exceptions thrown on the data source during execution are passed directly up to the client.  
  
5.  Return query results back to the client.  
  
## Constructing an ObjectQuery Instance  
 The <xref:System.Data.Objects.ObjectQuery%601> generic class represents a query that returns a collection of zero or more typed entities. An object query is typically constructed from an existing object context, instead of being manually constructed, and always belongs to that object context. This context provides the connection and metadata information that is required to compose and execute the query. The <xref:System.Data.Objects.ObjectQuery%601> generic class implements the <xref:System.Linq.IQueryable%601> generic interface, whose builder methods enable LINQ queries to be incrementally built. You can also let the compiler infer the type of entities by using the C# `var` keyword (`Dim` in Visual Basic, with local type inference enabled).  
  
## Composing the Queries  
 Instances of the <xref:System.Data.Objects.ObjectQuery%601> generic class, which implements the generic <xref:System.Linq.IQueryable%601> interface, serve as the data source for LINQ to Entities queries. In a query, you specify exactly the information that you want to retrieve from the data source. A query can also specify how that information should be sorted, grouped, and shaped before it is returned. In LINQ, a query is stored in a variable. This query variable takes no action and returns no data; it only stores the query information. After you create a query you must execute that query to retrieve any data.  
  
 LINQ to Entities queries can be composed in two different syntaxes: query expression syntax and method-based query syntax. Query expression syntax and method-based query syntax are new in C# 3.0 and Visual Basic 9.0.  
  
 For more information, see [Queries in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/queries-in-linq-to-entities.md).  
  
## Query Conversion  
 To execute a LINQ to Entities query against the Entity Framework, the LINQ query must be converted to a command tree representation that can be executed against the Entity Framework.  
  
 LINQ to Entities queries are comprised of LINQ standard query operators (such as <xref:System.Linq.Queryable.Select%2A>, <xref:System.Linq.Queryable.Where%2A>, and <xref:System.Linq.Queryable.GroupBy%2A>) and expressions (x > 10, Contact.LastName, and so on). LINQ operators are not defined by a class, but rather are methods on a class. In LINQ, expressions can contain anything allowed by types within the <xref:System.Linq.Expressions> namespace and, by extension, anything that can be represented in a lambda function. This is a superset of the expressions that are allowed by the Entity Framework, which are by definition restricted to operations allowed on the database, and supported by <xref:System.Data.Objects.ObjectQuery%601>.  
  
 In the Entity Framework, both operators and expressions are represented by a single type hierarchy, which are then placed in a command tree. The command tree is used by the Entity Framework to execute the query. If the LINQ query cannot be expressed as a command tree, an exception will be thrown when the query is being converted. The conversion of LINQ to Entities queries involves two sub-conversions: the conversion of the standard query operators, and the conversion of the expressions.  
  
 There are a number of LINQ standard query operators that do not have a valid translation in LINQ to Entities. Attempts to use these operators will result in an exception at query translation time. For a list of supported LINQ to Entities operators, see [Supported and Unsupported LINQ Methods (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities.md).  
  
 For more information about using the standard query operators in LINQ to Entities, see [Standard Query Operators in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/standard-query-operators-in-linq-to-entities-queries.md).  
  
 In general, expressions in LINQ to Entities are evaluated on the server, so the behavior of the expression should not be expected to follow CLR semantics. For more information, see [Expressions in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/expressions-in-linq-to-entities-queries.md).  
  
 For information about how CLR method calls are mapped to canonical functions in the data source, see [CLR Method to Canonical Function Mapping](../../../../../../docs/framework/data/adonet/ef/language-reference/clr-method-to-canonical-function-mapping.md).  
  
 For information about how to call canonical, database, and custom functions from within [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries, see [Calling Functions in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/calling-functions-in-linq-to-entities-queries.md).  
  
## Query Execution  
 After the LINQ query is created by the user, it is converted to a representation that is compatible with the Entity Framework (in the form of command trees), which is then executed against the data source. At query execution time, all query expressions (or components of the query) are evaluated on the client or on the server. This includes expressions that are used in result materialization or entity projections. For more information, see [Query Execution](../../../../../../docs/framework/data/adonet/ef/language-reference/query-execution.md). For information on how to improve performance by compiling a query once and then executing it several times with different parameters, see [Compiled Queries  (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/compiled-queries-linq-to-entities.md).  
  
## Materialization  
 Materialization is the process of returning query results back to the client as CLR types. In LINQ to Entities, query results data records are never returned; there is always a backing CLR type, defined by the user or by the Entity Framework, or generated by the compiler (anonymous types). All object materialization is performed by the Entity Framework. Any errors that result from an inability to map between the Entity Framework and the CLR will cause exceptions to be thrown during object materialization.  
  
 Query results are usually returned as one of the following:  
  
-   A collection of zero or more typed entity objects or a projection of complex types defined in the conceptual model.  
  
-   CLR types that are supported by the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)].  
  
-   Inline collections.  
  
-   Anonymous types.  
  
 For more information, see [Query Results](../../../../../../docs/framework/data/adonet/ef/language-reference/query-results.md).  
  
## In This Section  
 [Queries in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/queries-in-linq-to-entities.md)  
  
 [Expressions in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/expressions-in-linq-to-entities-queries.md)  
  
 [Calling Functions in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/calling-functions-in-linq-to-entities-queries.md)  
  
 [Compiled Queries  (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/compiled-queries-linq-to-entities.md)  
  
 [Query Execution](../../../../../../docs/framework/data/adonet/ef/language-reference/query-execution.md)  
  
 [Query Results](../../../../../../docs/framework/data/adonet/ef/language-reference/query-results.md)  
  
 [Standard Query Operators in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/standard-query-operators-in-linq-to-entities-queries.md)  
  
 [CLR Method to Canonical Function Mapping](../../../../../../docs/framework/data/adonet/ef/language-reference/clr-method-to-canonical-function-mapping.md)  
  
 [Supported and Unsupported LINQ Methods (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities.md)  
  
 [Known Issues and Considerations in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/known-issues-and-considerations-in-linq-to-entities.md)  
  
## See Also  
 [Known Issues and Considerations in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/known-issues-and-considerations-in-linq-to-entities.md)  
 [LINQ (Language-Integrated Query)](http://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)  
 [LINQ and ADO.NET](../../../../../../docs/framework/data/adonet/linq-and-ado-net.md)  
 [ADO.NET Entity Framework](../../../../../../docs/framework/data/adonet/ef/index.md)
