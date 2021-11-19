---
description: "Learn more about: Mathematical Functions"
title: "Mathematical Functions"
ms.topic: reference
ms.date: "03/30/2017"
ms.assetid: b040c7cb-156d-40f2-9152-61065b18148c
---
# Mathematical Functions

The .NET Framework Data Provider for SQL Server (SqlClient) provides math functions that perform calculations on input values that are provided as arguments, and return a numeric value result. These functions are in the SqlServer namespace, which is available when you use SqlClient. A provider's namespace property allows the Entity Framework to discover which prefix is used by this provider for specific constructs, such as types and functions. The following table describes the SqlClient math functions.  
  
## ABS(expression)

Performs the absolute value function.

**Arguments**

`expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.

**Return Value**

The absolute value of the specified expression.

**Example**

`SqlServer.ABS(-2)`

## ACOS(expression)

Returns the arccosine value of the specified expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.ACOS(.9)`

## ASIN(expression)

Returns the arcsine value of the specified expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.ASIN(.9)`

## ATAN(expression)

Returns the arctangent value of the specified numeric expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.ATAN(9)`

## ATN2(expression, expression)

Returns the angle, in radians, whose tangent is between the two specified numeric expressions.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.ATN2(9, 8)`

## CEILING(expression)

Converts the specified expression to the smallest integer that is greater than or equal to it.

**Arguments**

`expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.

**Return Value**

An `Int32`, `Int64`, `Double`, or `Decimal`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_CEILING](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_ceiling)]

## COS(expression)

Calculates the trigonometric cosine of the specified angle in radians.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.COS(45)`

## COT(expression)

Calculates the trigonometric cotangent of the specified angle in radians.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.COT(60)`
  
## DEGREES(radians)

Returns the corresponding angle in degrees.

**Arguments**

`expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.

**Return Value**

An `Int32`, `Int64`, `Double`, or `Decimal`.

**Example**

`SqlServer.DEGREES(3.1)`

## EXP(expression)

Calculates the exponential value of a specified numeric expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example** `SqlServer.EXP(1)`

## FLOOR(expression)

Converts the specified expression to the largest integer less than or equal to it.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

[!code-sql[DP EntityServices Concepts#SQLSERVER_FLOOR](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_floor)]

## LOG(expression)

Calculates the natural logarithm of the specified `float` expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.LOG(100)`

## LOG10(expression)

Returns the base-10 logarithm of the specified `Double` expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.LOG10(100)`

## PI()

Returns the constant value of pi as a `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.PI()`

## POWER(numeric_expression, power_expression)

Calculates the value of a specified expression to a specified power.

**Arguments**

| Parameter | Type |
|--|--|
|`numeric_expression`| `Int32`, `Int64`, `Double`, or `Decimal`.|
|`power_expression`| A `Double` that represents the power to which to raise the `numeric_expression`.|

**Return Value**

The value of the specified `numeric_expression` to the specified `power_expression`.

**Example**

`SqlServer.POWER(2,7)`

## RADIANS(expression)

Converts degrees to radians.

**Arguments**

`expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.

**Return Value**

An `Int32`, `Int64`, `Double`, or `Decimal`.

**Example**

`SqlServer.RADIANS(360.0)`

## RAND([seed])

Returns a random value from 0 through 1.

**Arguments**

The seed value as an `Int32`. If the seed is not specified, the SQL Server Database Engine assigns a seed value at random. For a specified seed value, the result returned is always the same.

**Return Value**

A random `Double` value from 0 through 1.

**Example**

`SqlServer.RAND()`
  
## ROUND(numeric_expression, length[,function])

Returns a numeric expression, rounded to the specified length or precision.

**Arguments**

| Parameter | Type |
|--|--|
|`numeric_expression`| `Int32`, `Int64`, `Double`, or `Decimal`.|
|`length`| An `Int32` that represents the precision to which `numeric_expression` is to be rounded. When `length` is a positive number, `numeric_expression` is rounded to the number of decimal positions specified by `length`. When `length` is a negative number, `numeric_expression` is rounded on the left side of the decimal point, as specified by `length`.|
|`function` | Optional. An `Int32` that represents the type of operation to perform. When `function` is omitted or has a value of 0 (default), `numeric_expression` is rounded. When a value other than 0 is specified, `numeric_expression` is truncated. |

**Return Value**

The value of the specified `numeric_expression` to the specified `power_expression`.

**Example**

`SqlServer.ROUND(748.58, -3)`

## SIGN(expression)

Returns the positive (+1), zero (0), or negative (-1) sign of the specified expression.

**Arguments**

`expression`: `Int32`, `Int64`, `Double`, or `Decimal`

**Return Value**

An `Int32`, `Int64`, `Double`, or `Decimal`.

**Example**

`SqlServer.SIGN(-10)`

## SIN(expression)

Calculates the trigonometric sine of the specified angle in radians, and returns a `Double` expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example** `SqlServer.SIN(20)`

## SQRT(expression)

Returns the square root of the specified expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example** `SqlServer.SQRT(3600)`

## SQUARE(expression)

Returns the square of the specified expression.

**Arguments**

`expression`: A `Double`.

**Return Value**

A `Double`.

**Example**

`SqlServer.SQUARE(25)`

## TAN(expression)

Calculates the tangent of a specified expression.

**Arguments**

`expression`: `Double`

**Return Value**

`Double`

**Example**

`SqlServer.TAN(45.0)`
  
## See also

- [Mathematical Functions (Transact-SQL)](/sql/t-sql/functions/mathematical-functions-transact-sql)
- [SqlClient for Entity Framework Functions](sqlclient-for-ef-functions.md)
