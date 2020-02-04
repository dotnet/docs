---
title: "Aggregate Functions (SqlClient for Entity Framework)"
ms.date: "03/30/2017"
ms.assetid: 03303f01-b591-4efc-9875-f9c608edff0b
---
# Aggregate Functions (SqlClient for Entity Framework)
The .NET Framework Data Provider for SQL Server (SqlClient) provides aggregate functions. Aggregate functions perform calculations on a set of input values and return a value. These functions are in the SqlServer namespace, which is available when you use SqlClient. A provider's namespace property allows the Entity Framework to discover which prefix is used by this provider for specific constructs, such as types and functions.  
  
 The following are the SqlClient aggregate functions.  

## AVG(expression)

Returns the average of the values in a collection. Null values are ignored.

**Arguments**

An `Int32`, `Int64`, `Double`, and `Decimal`.

**Return Value**

The type of `expression`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_AVG](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_avg)]

## CHECKSUM_AGG(collection)
 
 Returns the checksum of the values in a collection. Null values are ignored.
 
 **Arguments**
 
 A Collection(`Int32`).
 
 **Return Value**
 
 An `Int32`.
 
 **Example**
 
[!code-sql[DP EntityServices Concepts#SQLSERVER_CHECKSUM](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_checksum)]
   
## COUNT(expression)

Returns the number of items in a collection as an `Int32`.

**Arguments**

A Collection\<T>, where T is one of the following types:

|   |   |   |   |
|---|---|---|---|
|`Boolean`|`Double`|`DateTime`|`DateTimeOffset`|
|`Time`|`String`|`Binary`|`Guid` (not returned in SQL Server 2000)|

**Return Value**

An `Int32`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_COUNT](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_count)]
 
## COUNT_BIG(expression)
 
Returns the number of items in a collection as a `bigint`.
 
 **Arguments**
 
 A Collection(T), where T is one of the following types:
 
 |   |   |   |   |
|---|---|---|---|
|`Boolean`|`Double`|`DateTime`|`DateTimeOffset`|
|`Time`|`String`|`Binary`|`Guid` (not returned in SQL Server 2000)|

**Return Value**

An `Int64`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_COUNTBIG](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_countbig)]

## MAX(expression)

Returns the maximum value the collection.

**Arguments**

A Collection(T), where T is one of the following types: 

|   |   |   |   |
|---|---|---|---|
|`Boolean`|`Double`|`DateTime`|`DateTimeOffset`|
|`Time`|`String`|`Binary`||

**Return Value**

The type of `expression`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_MAX](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_max)]

## MIN(expression)

Returns the minimum value in a collection.

**Arguments**

A Collection(T), where T is one of the following types: 

|   |   |   |   |
|---|---|---|---|
|`Boolean`|`Double`|`DateTime`|`DateTimeOffset`|
|`Time`|`String`|`Binary`||

**Return Value**

The type of `expression`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_MIN](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_min)]

## STDEV(expression)

Returns the statistical standard deviation of all values in the specified expression.

**Arguments**

A Collection(`Double`).

**Return Value**

A `Double`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_STDEV](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_stdev)]

## STDEVP(expression)

Returns the statistical standard deviation for the population for all values in the specified expression.

**Arguments**

A Collection(`Double`).

**Return Value**

A `Double`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_STDEVP](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_stdevp)]

## SUM(expression)

Returns the sum of all the values in the collection.

**Arguments**

A Collection(T) where T is one of the following types: `Int32`, `Int64`, `Double`, `Decimal`.

**Return Value**

The type of `expression`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_SUM](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_sum)]

## VAR(expression)

Returns the statistical variance of all values in the specified expression.

**Arguments**

A Collection(`Double`).

**Return Value**

A `Double`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_VAR](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_var)]

## VARP(expression)

Returns the statistical variance for the population for all values in the specified expression.

**Arguments**

A Collection(`Double`).

**Return Value**

A `Double`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_VARP](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_varp)] 
  
## See also

- [Aggregate Functions (Transact-SQL)](/sql/t-sql/functions/aggregate-functions-transact-sql)
- [Entity SQL Language](./language-reference/entity-sql-language.md)
- [Aggregate Canonical Functions](./language-reference/aggregate-canonical-functions.md)
