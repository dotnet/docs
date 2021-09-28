---
title: "How to: Directly Execute SQL Queries"
description: Learn how to use ExecuteQuery to run a query and then convert the results directly into objects in cases where a LINQ to SQL query is insufficient.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: e491b9bf-741a-4296-9f51-76c25ddf6a82
---
# How to: Directly Execute SQL Queries

[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates the queries you write into parameterized SQL queries (in text form) and sends them to the SQL server for processing.  
  
 SQL cannot execute the variety of methods that might be locally available to your application. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] tries to convert these local methods to equivalent operations and functions that are available inside the SQL environment. Most methods and operators on .NET Framework built-in types have direct translations to SQL commands. Some can be produced from the functions that are available. Those that cannot be produced generate run-time exceptions. For more information, see [SQL-CLR Type Mapping](sql-clr-type-mapping.md).  
  
 In cases where a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] query is insufficient for a specialized task, you can use the <xref:System.Data.Linq.DataContext.ExecuteQuery%2A> method to execute a SQL query, and then convert the result of your query directly into objects.  
  
## Example 1

 In the following example, assume that the data for the `Customer` class is spread over two tables (customer1 and customer2). The query returns a sequence of `Customer` objects.  
  
 [!code-csharp[DLinqQuerying#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQuerying/cs/Program.cs#4)]
 [!code-vb[DLinqQuerying#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQuerying/vb/Module1.vb#4)]  
  
 As long as the column names in the tabular results match column properties of your entity class, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] creates your objects out of any SQL query.  
  
## Example 2  

 The <xref:System.Data.Linq.DataContext.ExecuteQuery%2A> method also allows for parameters. Use code such as the following to execute a parameterized query.  
  
 [!code-csharp[DLinqQuerying#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQuerying/cs/Program.cs#5)]
 [!code-vb[DLinqQuerying#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQuerying/vb/Module1.vb#5)]  
  
 The parameters are expressed in the query text by using the same curly notation used by `Console.WriteLine()` and `String.Format()`. In fact, `String.Format()` is actually called on the query string you provide, substituting the curly braced parameters with generated parameter names such as @p0, @p1 …, @p(n).  
  
## See also

- [Background Information](background-information.md)
- [Querying the Database](querying-the-database.md)
