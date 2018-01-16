---
title: "Aggregate Functions (SqlClient for Entity Framework)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 03303f01-b591-4efc-9875-f9c608edff0b
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Aggregate Functions (SqlClient for Entity Framework)
The .NET Framework Data Provider for SQL Server (SqlClient) provides aggregate functions. Aggregate functions perform calculations on a set of input values and return a value. These functions are in the SqlServer namespace, which is available when you use SqlClient. A provider's namespace property allows the Entity Framework to discover which prefix is used by this provider for specific constructs, such as types and functions.  
  
 The following table shows the SqlClient aggregate functions.  
  
|Function|Description|  
|--------------|-----------------|  
|`AVG(` `expression` `)`|Returns the average of the values in a collection.<br /><br /> Null values are ignored.<br /><br /> **Arguments**<br /><br /> An `Int32`, `Int64`, `Double`, and `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_AVG](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_avg)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_AVG](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_avg)]|  
|`CHECKSUM_AGG(` `collection` `)`|Returns the checksum of the values in a collection.<br /><br /> Null values are ignored.<br /><br /> **Arguments**<br /><br /> A Collection (`Int32`).<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_CHECKSUM](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_checksum)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_CHECKSUM](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_checksum)]|  
|`COUNT(` `expression` `)`|Returns the number of items in a collection as an `Int32`.<br /><br /> **Arguments**<br /><br /> A Collection (T) where T is one of the following types:<br /><br /> `Guid` (not returned in SQL Server 2000),<br /><br /> `Boolean`, `Double`, `DateTime`, `DateTimeOffset`, `Time`, `String`, or `Binary`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_COUNT](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_count)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_COUNT](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_count)]|  
|`COUNT_BIG(` `expression` `)`|Returns the number of items in a collection as a `bigint`.<br /><br /> **Arguments**<br /><br /> A Collection (T) where T is one of the following types:<br /><br /> `Guid` (not returned in SQL Server 2000), `Boolean`, `Double`, `DateTime`, `DateTimeOffset`, `Time`, `String`, or `Binary`.<br /><br /> **Return Value**<br /><br /> An `Int64`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_COUNTBIG](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_countbig)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_COUNTBIG](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_countbig)]|  
|`MAX(` `expression` `)`|Returns the maximum value the collection.<br /><br /> **Arguments**<br /><br /> A Collection (T) where T is one of the following types: `Byte`, `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, `Decimal`, `DateTime`, `DateTimeOffset`, `Time`, `String`, `Binary`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_MAX](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_max)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_MAX](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_max)]|  
|`MIN(` `expression` `)`|Returns the minimum value in a collection.<br /><br /> **Arguments**<br /><br /> A Collection (T) where T is one of the following types: `Byte`, `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, `Decimal`, `DateTime`, `DateTimeOffset`, `Time`, `String`,<br /><br /> `Binary`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_MIN](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_min)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_MIN](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_min)]|  
|`STDEV(` `expression` `)`|Returns the statistical standard deviation of all values in the specified expression.<br /><br /> **Arguments**<br /><br /> A Collection (`Double`).<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_STDEV](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_stdev)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_STDEV](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_stdev)]|  
|`STDEVP(` `expression` `)`|Returns the statistical standard deviation for the population for all values in the specified expression.<br /><br /> **Arguments**<br /><br /> A Collection (`Double`).<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_STDEVP](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_stdevp)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_STDEVP](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_stdevp)]|  
|`SUM(` `expression` `)`|Returns the sum of all the values in the collection.<br /><br /> **Arguments**<br /><br /> A Collection (T) where T is one of the following types: `Int32`, `Int64`, `Double`, `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_SUM](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_sum)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_SUM](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_sum)]|  
|`VAR(` `expression` `)`|Returns the statistical variance of all values in the specified expression.<br /><br /> **Arguments**<br /><br /> A Collection (`Double`).<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_VAR](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_var)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_VAR](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_var)]|  
|`VARP(` `expression` `)`|Returns the statistical variance for the population for all values in the specified expression.<br /><br /> **Arguments**<br /><br /> A Collection (`Double`).<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_VARP](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_varp)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_VARP](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_varp)]|  
  
 For more information about the aggregate functions that SqlClient supports, see the documentation for the SQL Server version that you specified in the SqlClient provider manifest:  
  
|SQL Server 2000|SQL Server 2005|SQL Server 2008|  
|---------------------|---------------------|---------------------|  
|[Aggregate Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115906)|[Aggregate Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkID=115903)|[Aggregate Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115907)|  
  
## See Also  
 [Entity SQL Language](../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)  
 [Aggregate Canonical Functions](../../../../../docs/framework/data/adonet/ef/language-reference/aggregate-canonical-functions.md)
