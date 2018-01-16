---
title: "Aggregate Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3bcff826-ca90-41b3-a791-04d6ff0e5085
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Aggregate Canonical Functions

Aggregates are expressions that reduce a series of input values into, for example, a single value. Aggregates are normally used in conjunction with the GROUP BY clause of the SELECT expression, and there are constraints on where they can be used.

The following table shows the aggregate [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.

| Function | Description |
| -------- | ----------- |
| `Avg(expression)` | Returns the average of the non-null values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, and `Decimal`.<br><br>**Return Value**<br><br>The type of `expression`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_AVG](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_avg)] [!code-sql[DP EntityServices Concepts#EDM_AVG](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_avg)] |
| `BigCount(expression)` | Returns the size of the aggregate including null and duplicate values.<br><br>**Arguments**<br><br>Any type.<br><br>**Return Value**<br><br>An `Int64`.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_BIGCOUNT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_bigcount)] [!code-sql[DP EntityServices Concepts#EDM_BIGCOUNT](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_bigcount)] |
| `Count(expression)` | Returns the size of the aggregate including null and duplicate values.<br><br>**Arguments**<br><br>Any type.<br><br>**Return Value**<br><br>An `Int32`.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_COUNT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_count)] [!code-sql[DP EntityServices Concepts#EDM_COUNT](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_count)] |
| `Max(expression)` | Returns the maximum of the non-null values.<br><br>**Arguments**<br><br>A `Byte`, `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, `Decimal`, `DateTime`, `DateTimeOffset`, `Time`, `String`, `Binary`.<br><br>**Return Value**<br><br>The type of `expression`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_MAX](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_max)] [!code-sql[DP EntityServices Concepts#EDM_MAX](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_max)] |
| `Min(expression)` | Returns the minimum of the non-null values.<br><br>**Arguments**<br><br>A `Byte`, `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, `Decimal`, `DateTime`, `DateTimeOffset`, `Time`, `String`, `Binary`.<br><br>**Return Value**<br><br>The type of `expression`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_MIN](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_min)] [!code-sql[DP EntityServices Concepts#EDM_MIN](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_min)] |
| `StDev(expression)` | Returns the standard deviation of the non-null values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, `Decimal`.<br><br>**Return Value**<br><br>A `Double`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_STDEV](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_stdev)] [!code-sql[DP EntityServices Concepts#EDM_STDEV](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_stdev)] |
| `StDevP(expression)` | Returns the standard deviation for the population of all values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, `Decimal`.<br><br>**Return Value**<br><br>A `Double`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_STDEVP](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_stdevp)] [!code-sql[DP EntityServices Concepts#EDM_STDEVP](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_stdevp)] |
| `Sum(expression)` | Returns the sum of the non-null values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, `Decimal`.<br><br>**Return Value**<br><br>A `Double`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_SUM](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_sum)] [!code-sql[DP EntityServices Concepts#EDM_SUM](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_sum)] |
| `Var(expression)` | Returns the variance of all non-null values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, `Decimal`.<br><br>**Return Value**<br><br>A `Double`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_VAR](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_var)] [!code-sql[DP EntityServices Concepts#EDM_VAR](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_var)] |
| `VarP(expression)` | Returns the variance for the population of all non-null values.<br><br>**Arguments**<br><br>An `Int32`, `Int64`, `Double`, `Decimal`.<br><br>**Return Value**<br><br>A `Double`. `Null`, if all input values are `null` values.<br><br>**Example**[!code-csharp[DP EntityServices Concepts#EDM_VARP](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_varp)] [!code-sql[DP EntityServices Concepts#EDM_VARP](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_varp)] |

Equivalent functionality is available in the Microsoft SQL Client Managed Provider. For more information, see [SqlClient for Entity Framework Functions](../../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).

## Collection-based aggregates

Collection-based aggregates (collection functions) operate on collections and return a value. For example if ORDERS is a collection of all orders, you can calculate the earliest ship date with the following expression:

```sql
min(select value o.ShipDate from LOB.Orders as o)
```

Expressions inside collection-based aggregates are evaluated within the current ambient name-resolution scope.

## Group-based aggregates

Group-based aggregates are calculated over a group as defined by the GROUP BY clause. For each group in the result, a separate aggregate is calculated by using the elements in each group as input to the aggregate calculation. When a group-by clause is used in a select expression, only grouping expression names, aggregates, or constant expressions can be present in the projection or order-by clause.

The following example calculates the average quantity ordered for each product:

```sql
select p, avg(ol.Quantity) from LOB.OrderLines as ol 
  group by ol.Product as p
```

It's possible to have a group-based aggregate without an explicit group-by clause in the SELECT expression. In this case, all elements are treated as a single group. This is equivalent of specifying a grouping based on a constant. Take, for example, the following expression:

```sql
select avg(ol.Quantity) from LOB.OrderLines as ol
```

This is equivalent to the following:

```sql
select avg(ol.Quantity) from LOB.OrderLines as ol group by 1
```

Expressions inside the group-based aggregate are evaluated within the name-resolution scope that would be visible to the WHERE clause expression.

As in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], group-based aggregates can also specify an ALL or DISTINCT modifier. If the DISTINCT modifier is specified, duplicates are eliminated from the aggregate input collection, before the aggregate is computed. If the ALL modifier is specified (or if no modifier is specified), no duplicate elimination is performed.  

## See also

[Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
