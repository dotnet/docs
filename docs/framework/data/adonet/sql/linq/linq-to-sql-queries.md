---
description: "Learn more about: LINQ to SQL Queries"
title: "LINQ to SQL Queries"
ms.date: "03/30/2017"
ms.assetid: f4897aaa-7f44-4c20-a471-b948c2971aae
---
# LINQ to SQL Queries

You define [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] queries by using the same syntax as you would in LINQ. The only difference is that the objects referenced in your queries are mapped to elements in a database. For more information, see [Introduction to LINQ Queries (C#)](../../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates the queries you write into equivalent SQL queries and sends them to the server for processing. More specifically, your application uses the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] API to request query execution. The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provider then transforms the query into SQL text and delegates execution to the ADO provider. The ADO provider returns query results as a `DataReader`. The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provider translates the ADO results to an <xref:System.Linq.IQueryable> collection of user objects.  
  
> [!NOTE]
> Most methods and operators on .NET Framework built-in types have direct translations to SQL. Those that LINQ cannot translate generate run-time exceptions. For more information, see [SQL-CLR Type Mapping](sql-clr-type-mapping.md).  
  
 The following table shows the similarities and differences between LINQ and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] query items.  
  
|Item|LINQ Query|[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] Query|  
|----------|----------------|----------------------------------------------------------------------|  
|Return type of the local variable that holds the query (for queries that return sequences)|Generic `IEnumerable`|Generic `IQueryable`|  
|Specifying the data source|Uses the `From` (Visual Basic) or `from` (C#) clause|Same|  
|Filtering|Uses the `Where`/`where` clause|Same|  
|Grouping|Uses the `Group…By`/`groupby` clause|Same|  
|Selecting (Projecting)|Uses the `Select`/`select` clause|Same|  
|Deferred versus immediate execution|See [Introduction to LINQ Queries (C#)](../../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)|Same|  
|Implementing joins|Uses the `Join`/`join` clause|Can use the `Join`/`join` clause, but more effectively uses the <xref:System.Data.Linq.Mapping.AssociationAttribute> attribute. For more information, see [Querying Across Relationships](querying-across-relationships.md).|  
|Remote versus local execution||For more information, see [Remote vs. Local Execution](remote-vs-local-execution.md).|  
|Streaming versus cached querying|Not applicable in a local memory scenario||  
  
## See also

- [Introduction to LINQ Queries (C#)](../../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)
- [Basic LINQ Query Operations](../../../../../csharp/programming-guide/concepts/linq/basic-linq-query-operations.md)
- [Type Relationships in LINQ Query Operations](../../../../../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md)
- [Query Concepts](query-concepts.md)
