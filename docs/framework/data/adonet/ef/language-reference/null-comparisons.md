---
title: "Null Comparisons"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: ef88af8c-8dfe-4556-8b56-81df960a900b
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Null Comparisons
A `null` value in the data source indicates that the value is unknown. In [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries, you can check for null values so that certain calculations or comparisons are only performed on rows that have valid, or non-null, data. CLR null semantics, however, may differ from the null semantics of the data source. Most databases use a version of three-valued logic to handle null comparisons. That is, a comparison against a null value does not evaluate to `true` or `false`, it evaluates to `unknown`. Often this is an implementation of ANSI nulls, but this is not always the case.  
  
 By default in SQL Server, the null-equals-null comparison returns a null value. In the following example, the rows where `ShipDate` is null are excluded from the result set, and the [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] statement would return 0 rows.  
  
```  
-- Find order details and orders with no ship date.  
SELECT h.SalesOrderID  
FROM Sales.SalesOrderHeader h  
JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID  
WHERE h.ShipDate IS Null  
```  
  
 This is very different from the CLR null semantics, where the null-equals-null comparison returns true.  
  
 The following LINQ query is expressed in the CLR, but it is executed in the data source. Because there is no guarantee that CLR semantics will be honored at the data source, the expected behavior is indeterminate.  
  
 [!code-csharp[DP L2E Conceptual Examples#JoinOnNull](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#joinonnull)]
 [!code-vb[DP L2E Conceptual Examples#JoinOnNull](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#joinonnull)]  
  
## Key Selectors  
 A *key selector* is a function used in the standard query operators to extract a key from an element. In the key selector function, an expression can be compared with a constant. CLR null semantics are exhibited if an expression is compared to a null constant or if two null constants are compared. Store null semantics are exhibited if two columns with null values in the data source are compared. Key selectors are found in many of the grouping and ordering standard query operators, such as <xref:System.Linq.Queryable.GroupBy%2A>, and are used to select keys by which to order or group the query results.  
  
## Null Property on a Null Object  
 In the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)], the properties of a null object are null. When you attempt to reference a property of a null object in the CLR, you will receive a <xref:System.NullReferenceException>. When a LINQ query involves a property of a null object, this can result in inconsistent behavior.  
  
 For example, in the following query, the cast to `NewProduct` is done in the command tree layer, which might result in the `Introduced` property being null. If the database defined null comparisons such that the <xref:System.DateTime> comparison evaluates to true, the row will be included.  
  
 [!code-csharp[DP L2E Conceptual Examples#CastResultsIsNull](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DP L2E Conceptual Examples/CS/Program.cs#castresultsisnull)]
 [!code-vb[DP L2E Conceptual Examples#CastResultsIsNull](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP L2E Conceptual Examples/VB/Module1.vb#castresultsisnull)]  
  
## Passing Null Collections to Aggregate Functions  
 In [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)], when you pass a collection that supports `IQueryable` to an aggregate function, aggregate operations are performed at the database. There might be differences in the results of a query that was performed in-memory and a query that was performed at the database. With an in-memory query, if there are no matches, the query returns zero. At the database, the same query returns `null`. If a `null` value is passed to a LINQ aggregate function, an exception will be thrown. To accept possible `null` values, cast the types and the properties of the types that receive query results to nullable types.  
  
## See Also  
 [Expressions in LINQ to Entities Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/expressions-in-linq-to-entities-queries.md)
