---
description: "Learn more about: How to: Call Database Functions"
title: "How to: Call Database Functions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 79038efa-15bf-464a-83e2-35fe145252ce
---
# How to: Call Database Functions

The <xref:System.Data.Objects.SqlClient.SqlFunctions> class contains methods that expose SQL Server functions to use in LINQ to Entities queries. When you use <xref:System.Data.Objects.SqlClient.SqlFunctions> methods in LINQ to Entities queries, the corresponding database functions are executed in the database.  
  
> [!NOTE]
> Database functions that perform a calculation on a set of values and return a single value (also known as aggregate database functions) can be directly invoked. Other canonical functions can only be called as part of a LINQ to Entities query. To call an aggregate function directly, you must pass an <xref:System.Data.Objects.ObjectQuery%601> to the function. For more information, see the second example below.  
  
> [!NOTE]
> The methods in the <xref:System.Data.Objects.SqlClient.SqlFunctions> class are specific to SQL Server functions. Similar classes that expose database functions may be available through other providers.  
  
## Example 1

 The following example uses the [AdventureWorks Sales Model](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks). The example executes a LINQ to Entities query that uses the <xref:System.Data.Objects.SqlClient.SqlFunctions.CharIndex%2A> method to return all contacts whose last name starts with "Si":  
  
 [!code-csharp[DP L2E CanonicalAndStoreFunctions#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp l2e canonicalandstorefunctions/cs/program.cs#3)]
 [!code-vb[DP L2E CanonicalAndStoreFunctions#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp l2e canonicalandstorefunctions/vb/module1.vb#3)]  
  
## Example 2  

 The following example uses the [AdventureWorks Sales Model](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks). The example calls the aggregate <xref:System.Data.Objects.SqlClient.SqlFunctions.ChecksumAggregate%2A> method directly. Note that an <xref:System.Data.Objects.ObjectQuery%601> is passed to the function, which allows it to be called without being part of a LINQ to Entities query.  
  
 [!code-csharp[DP L2E CanonicalAndStoreFunctions#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp l2e canonicalandstorefunctions/cs/program.cs#4)]
 [!code-vb[DP L2E CanonicalAndStoreFunctions#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp l2e canonicalandstorefunctions/vb/module1.vb#4)]  
  
## See also

- [Calling Functions in LINQ to Entities Queries](calling-functions-in-linq-to-entities-queries.md)
- [Queries in LINQ to Entities](queries-in-linq-to-entities.md)
