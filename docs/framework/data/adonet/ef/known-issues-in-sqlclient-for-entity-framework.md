---
title: "Known Issues in SqlClient for Entity Framework"
ms.date: "03/30/2017"
ms.assetid: 48fe4912-4d0f-46b6-be96-3a42c54780f6
---
# Known Issues in SqlClient for Entity Framework
This section describes known issues related to the .NET Framework Data Provider for SQL Server (SqlClient).  
  
## Trailing Spaces in String Functions  
 SQL Server ignores trailing spaces in string values. Therefore, passing trailing spaces in the string can lead to unpredictable results, even failures.  
  
 If you have to have trailing spaces in your string, you should consider appending a white space character at the end, so that SQL Server does not trim the string. If the trailing spaces are not required, they should be trimmed before they are passed down the query pipeline.  
  
## RIGHT Function  
 If a non-`null` value is passed as a first argument and 0 is passed as a second argument to `RIGHT(nvarchar(max)`, 0`)` or `RIGHT(varchar(max)`, 0`)`, a `NULL` value will be returned instead of an `empty` string.  
  
## CROSS and OUTER APPLY Operators  
 CROSS and OUTER APPLY operators were introduced in SQL Server 2005. In some cases the query pipeline might produce a Transact-SQL statement that contains CROSS APPLY and/or OUTER APPLY operators. Because some backend providers, including versions of SQL Server earlier than SQL Server 2005, do not support these operators, such queries cannot be executed on these backend providers.  
  
 The following are some typical scenarios that might lead to the presence of CROSS APPLY and/or OUTER APPLY operators in the output query:  
  
- A correlated subquery with paging.  
  
- An `AnyElement` over a correlated sub-query, or over a collection produced by navigation.  
  
- LINQ queries that use grouping methods that accept an element selector.  
  
- A query in which a CROSS APPLY or an OUTER APPLY is explicitly specified  
  
- A query that has a DEREF construct over a REF construct.  
  
## SKIP Operator  
 If you are using SQL Server 2000, using SKIP with ORDER BY on non-key columns might return incorrect results. More than the specified number of rows might be skipped if the non-key column has duplicate data in it. This is due to how SKIP is translated for SQL Server 2000. For example, in the following query, more than five rows might be skipped if `E.NonKeyColumn` has duplicate values:  
  
```  
SELECT [E] FROM Container.EntitySet AS [E] ORDER BY [E].[NonKeyColumn] DESC SKIP 5L  
```  
  
## Targeting the Correct SQL Server Version  
 The Entity Framework targets the Transact-SQL query based on the SQL Server version that is specified in the `ProviderManifestToken` attribute of the Schema element in the storage model (.ssdl) file. This version might differ from the version of the actual SQL Server you are connected to. For example, if you are using SQL Server 2005, but your `ProviderManifestToken` attribute is set to 2008, the generated Transact-SQL query might not execute on the server. For example, a query that uses the new date time types that were introduced in SQL Server 2008 will not execute on earlier versions of the SQL Server. If you are using SQL Server 2005, but your `ProviderManifestToken` attribute is set to 2000, the generated Transact-SQL query might be less optimized, or you might get an exception that says that the query is not supported. For more information, see the CROSS and OUTER APPLY Operators section, earlier in this topic.  
  
 Certain database behaviors depend on the compatibility level set to the database. If your `ProviderManifestToken` attribute is set to 2005 and your SQL Server version is 2005, but the compatibility level of a database is set to "80" (SQL Server 2000), the generated Transact-SQL will be targeting SQL Server 2005, but might not execute as expected due to the compatibility level setting. For example, you might lose ordering information if a column name in the ORDER BY list matches a column name in the selector.  
  
## Nested Queries in Projection  
 Nested queries in a projection clause might get translated into Cartesian product queries on the server. On some back-end servers, including SLQ Server, this can cause the TempDB table to get quite large. This can decrease server performance.  
  
 The following is an example of  a nested query in a projection clause:  
  
```  
SELECT c, (SELECT c, (SELECT c FROM AdventureWorksModel.Vendor AS c  ) As Inner2 FROM AdventureWorksModel.JobCandidate AS c  ) As Inner1 FROM AdventureWorksModel.EmployeeDepartmentHistory AS c  
```  
  
## Server Generated GUID Identity Values  
 The Entity Framework supports server-generated GUID type identity values, but the provider must support returning the server-generated identity value after a row was inserted. Starting with SQL Server 2005, you can return the server-generated GUID type in a SQL Server database through the [OUTPUT clause](https://go.microsoft.com/fwlink/?LinkId=169400) .  
  
## See also

- [SqlClient for the Entity Framework](sqlclient-for-the-entity-framework.md)
- [Known Issues and Considerations in LINQ to Entities](./language-reference/known-issues-and-considerations-in-linq-to-entities.md)
