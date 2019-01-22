---
title: "Math Canonical Functions"
ms.date: "03/30/2017"
ms.assetid: 6f6cddc6-b561-4ebe-84b6-841ef5b4113b
---
# Math Canonical Functions

Entity SQL includes the following math canonical functions:
  
## Abs(value)

Returns the absolute value of `value`.

**Arguments**

An `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, and `Decimal`.

**Return Value**

The type of `value`.

**Example**

`Abs(-2)`

## Ceiling(value)

Returns the smallest integer that is not less than `value`.

**Arguments**

A `Single`, `Double`, and `Decimal`.

**Return Value**

The type of `value`.

**Example**

[!code-csharp[DP EntityServices Concepts#EDM_CEILING](~/samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_ceiling)]
[!code-sql[DP EntityServices Concepts#EDM_CEILING](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_ceiling)]

## Floor(value)

Returns the largest integer that is not greater than `value`.

**Arguments**

A `Single`, `Double`, and `Decimal`.

**Return Value**

The type of `value`.

**Example**

[!code-csharp[DP EntityServices Concepts#EDM_FLOOR](~/samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_floor)]
[!code-sql[DP EntityServices Concepts#EDM_FLOOR](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_floor)]

## Power(value, exponent)

Returns the result of the specified `value` to the specified `exponent`.

**Arguments**

|  |  |
|--|--|
|`value` | An `Int32, Int64, Double`, or `Decimal`. |
|`exponent` | An `Int64`, `Double`, or `Decimal`. |

**Return Value**

The type of `value`.

**Example**

`Power(748.58,2)`

## Round(value)

Returns the integer portion of `value`, rounded to the nearest integer.

**Arguments**

A `Single`, `Double`, and `Decimal`.

**Return Value**

The type of `value`.

**Example**

`Round(748.58)`

## Round(value, digits)

Returns the `value`, rounded to the nearest specified `digits`.

**Arguments**

|  |  |
|--|--|
|`value`|`Double` or `Decimal`.|
|`digits`|`Int16` or `Int32`.|

**Return Value**

The type of `value`.

**Example**

`Round(748.58,1)`

## Truncate(value, digits)

Returns the `value`, truncated to the nearest specified `digits`.

**Arguments**

|  |  |
|--|--|
|`value`|`Double` or `Decimal`.|
|`digits`|`Int16` or `Int32`.|

**Return Value**

The type of `value`.

**Example**

`Truncate(748.58,1)`  
  
 These functions will return `null` if given `null` input.  
  
 Equivalent functionality is available in the Microsoft SQL Client Managed Provider. For more information, see [SqlClient for Entity Framework Functions](../../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).  
  
## See also
- [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
