---
title: "Standard Query Operators in LINQ to Entities Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7fa55a9b-6219-473d-b1e5-2884a32dcdff
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Standard Query Operators in LINQ to Entities Queries
In a query, you specify the information that you want to retrieve from the data source. A query can also specify how that information should be sorted, grouped, and shaped before it is returned. LINQ provides a set of standard query methods that you can use in a query. Most of these methods operate on sequences; in this context, a sequence is an object whose type implements the <xref:System.Collections.Generic.IEnumerable%601> interface or the <xref:System.Linq.IQueryable%601> interface. The standard query operators query functionality includes filtering, projection, aggregation, sorting, grouping, paging, and more. Some of the more frequently used standard query operators have dedicated keyword syntax so that they can be called by using query expression syntax. A query expression is a different, more readable way to express a query than the method-based equivalent. Query expression clauses are translated into calls to the query methods at compile time. For a list of standard query operators that have equivalent query expression clauses, see [Standard Query Operators Overview](http://msdn.microsoft.com/library/24cda21e-8af8-4632-b519-c404a839b9b2).  
  
 Not all of the standard query operators are supported in [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries. For more information, see [Supported and Unsupported LINQ Methods (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities.md). This topic provides information about the standard query operators that is specific to [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)]. For more information about known issues in [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)] queries, see [Known Issues and Considerations in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/known-issues-and-considerations-in-linq-to-entities.md).  
  
## Projection and Filtering Methods  
 *Projection* refers to transforming the elements of a result set into a desired form. For example, you can project a subset of the properties you need from each object in the result set, you can project a property and perform a mathematical calculation on it, or you can project the entire object from the result set. The projection methods are `Select` and `SelectMany`.  
  
 *Filtering* refers to the operation of restricting the result set to contain only those elements that match a specified condition. The filtering method is `Where`.  
  
 Most overloads of the projection and filtering methods are supported in [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)], with the exception of those that accept a positional argument.  
  
## Join Methods  
 Joining is an important operation in queries that target data sources that have no navigable relationships to each other. A join of two data sources is the association of objects in one data source with objects in the other data source that share a common attribute or property. The join methods are `Join` and `GroupJoin`.  
  
 Most overloads of the join methods are supported, with the exception of those that use a <xref:System.Collections.Generic.IEqualityComparer%601>. This is because the comparer cannot be translated to the data source.  
  
## Set Methods  
 Set operations in LINQ are query operations that base their result sets on the presence or absence of equivalent elements within the same or in another collection (or set). The set methods are `All`, `Any`, `Concat`, `Contains`, `DefaultIfEmpty`, `Distinct`, `EqualAll`, `Except`, `Intersect`, and `Union`.  
  
 Most overloads of the set methods are supported in [!INCLUDE[linq_entities](../../../../../../includes/linq-entities-md.md)], though there are some differences in behavior compared to LINQ to Objects. However, set methods that use an <xref:System.Collections.Generic.IEqualityComparer%601> are not supported because the comparer cannot be translated to the data source.  
  
## Ordering Methods  
 Ordering, or sorting, refers to the ordering the elements of a result set based on one or more attributes. By specifying more than one sort criterion, you can break ties within a group.  
  
 Most overloads of the ordering methods are supported, with the exception of those that use an <xref:System.Collections.Generic.IComparer%601>. This is because the comparer cannot be translated to the data source. The ordering methods are `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`, and `Reverse`.  
  
 Because the query is executed on the data source, the ordering behavior may differ from queries executed in the CLR. This is because ordering options, such as case ordering, kanji ordering, and null ordering, can be set in the data source. Depending on the data source, these ordering options might produce different results than in the CLR.  
  
 If you specify the same key selector in more than one ordering operation, a duplicate ordering will be produced. This is not valid and an exception will be thrown.  
  
## Grouping Methods  
 Grouping refers to placing data into groups so that the elements in each group share a common attribute. The grouping method is `GroupBy`.  
  
 Most overloads of the grouping methods are supported, with the exception of those that use an <xref:System.Collections.Generic.IEqualityComparer%601>. This is because the comparer cannot be translated to the data source.  
  
 The grouping methods are mapped to the data source using a distinct sub-query for the key selector. The key selector comparison sub-query is executed by using the semantics of the data source, including issues related to comparing `null` values.  
  
## Aggregate Methods  
 An aggregation operation computes a single value from a collection of values. For example, calculating the average daily temperature from a month's worth of daily temperature values is an aggregation operation. The aggregate methods are `Aggregate`, `Average`, `Count`, `LongCount`, `Max`, `Min`, and `Sum`.  
  
 Most overloads of the aggregate methods are supported. For behavior related to null values, the aggregate methods use the data source semantics. The behavior of the aggregation methods when null values are involved might be different, depending on which back-end data source is being used. Aggregate method behavior using the semantics of the data source might also be different from what is expected from CLR methods. For example, the default behavior for the `Sum` method on SQL Server is to ignore any null values instead of throwing an exception.  
  
 Any exceptions that result from aggregation, such as an overflow from the `Sum` function, are thrown as data source exceptions or Entity Framework exceptions during the materialization of the query results.  
  
 For those methods that involve a calculation over a sequence, such as `Sum` or `Average`, the actual calculation is performed on the server. As a result, type conversions and loss of precision might occur on the server, and the results might differ from what is expected using CLR semantics.  
  
 The default behavior of the aggregate methods for null/non-null values is shown in the following table:  
  
|Method|No data|All null values|Some null values|No null values|  
|------------|-------------|---------------------|----------------------|--------------------|  
|`Average`|Returns null.|Returns null.|Returns the average of the non-null values in a sequence.|Computes the average of a sequence of numeric values.|  
|`Count`|Returns 0|Returns the number of null values in the sequence.|Returns the number of null and non-null values in the sequence.|Returns the number of elements in the sequence.|  
|`Max`|Returns null.|Returns null.|Returns the maximum non-null value in a sequence.|Returns the maximum value in a sequence.|  
|`Min`|Returns null.|Returns null.|Returns the minimum non-null value in a sequence.|Returns the minimum value in a sequence.|  
|`Sum`|Returns null.|Returns null.|Returns the sum of the non-null value in a sequence.|Computes the sum of a sequence of numeric values.|  
  
## Type Methods  
 The two LINQ methods that deal with type conversion and testing are both supported in the context of the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)]. This means that the only supported types are types that map to the appropriate [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)] type. For a list of these types, see [Conceptual Model Types (CSDL)](http://msdn.microsoft.com/library/987b995f-e429-4569-9559-b4146744def4). The type methods are `Convert` and `OfType`.  
  
 `OfType` is supported for entity types. `Convert` is supported for conceptual model primitive types.  The C# `is` and `as` methods are also supported.  
  
## Paging Methods  
 Paging operations return a single, specific element from a sequence. The element methods are `ElementAt`, `First`, `FirstOrDefault`, `Last`, `LastOrDefault`, `Single`, `Skip`, `Take`, `TakeWhile`.  
  
 A number of the paging methods are not supported, due either to the inability to map functions to the data source or to the lack of implicit ordering of sets on the data source. Methods that return a default value are restricted to conceptual model primitive types and reference types with null defaults. Paging methods that are executed on an empty sequence will return null.  
  
## See Also  
 [Supported and Unsupported LINQ Methods (LINQ to Entities)](../../../../../../docs/framework/data/adonet/ef/language-reference/supported-and-unsupported-linq-methods-linq-to-entities.md)  
 [Standard Query Operators Overview](http://msdn.microsoft.com/library/24cda21e-8af8-4632-b519-c404a839b9b2)
