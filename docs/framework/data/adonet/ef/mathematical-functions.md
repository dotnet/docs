---
title: "Mathematical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b040c7cb-156d-40f2-9152-61065b18148c
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Mathematical Functions
The .NET Framework Data Provider for SQL Server (SqlClient) provides math functions that perform calculations on input values that are provided as arguments, and return a numeric value result. These functions are in the SqlServer namespace, which is available when you use SqlClient. A provider's namespace property allows the Entity Framework to discover which prefix is used by this provider for specific constructs, such as types and functions.The following table describes the SqlClient math functions.  
  
|Function|Description|  
|--------------|-----------------|  
|`ABS(` `expression` `)`|Performs the absolute value function.<br /><br /> **Arguments**<br /><br /> `expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Return Value**<br /><br /> The absolute value of the specified expression.<br /><br /> **Example**<br /><br /> `SqlServer.ABS(-2)`|  
|`ACOS(` `expression` `)`|Returns the arccosine value of the specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.ACOS(.9)`|  
|`ASIN(` `expression` `)`|Returns the arcsine value of the specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.ASIN(.9)`|  
|`ATAN(` `expression` `)`|Returns the arctangent value of the specified numeric expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.ATAN(9)`|  
|`ATN2(` `expression`, `expression``)`|Returns the angle, in radians, whose tangent is between the two specified numeric expressions.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.ATN2(9, 8)`|  
|`CEILING(` `expression` `)`|Converts the specified expression to the smallest integer that is greater than or equal to it.<br /><br /> **Arguments**<br /><br /> `expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Return Value**<br /><br /> An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_CEILING](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_ceiling)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_CEILING](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_ceiling)]|  
|`COS(` `expression` `)`|Calculates the trigonometric cosine of the specified angle in radians.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.COS(45)`|  
|`COT(` `expression` `)`|Calculates the trigonometric cotangent of the specified angle in radians.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.COT(60)`|  
|`DEGREES(` `radians` `)`|Returns the corresponding angle in degrees.<br /><br /> **Arguments**<br /><br /> `expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Return Value**<br /><br /> An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Example**<br /><br /> `SqlServer.DEGREES(3.1)`|  
|`EXP(` `expression` `)`|Calculates the exponential value of a specified numeric expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.EXP(1)`|  
|`FLOOR(` `expression` `)`|Converts the specified expression to the largest integer less than or equal to it.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#SQLSERVER_FLOOR](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#sqlserver_floor)]
 [!code-sql[DP EntityServices Concepts#SQLSERVER_FLOOR](../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#sqlserver_floor)]|  
|`LOG(` `expression` `)`|Calculates the natural logarithm of the specified `float` expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.LOG(100)`|  
|`LOG10(` `expression` `)`|Returns the base-10 logarithm of the specified `Double` expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.LOG10(100)`|  
|`PI()`|Returns the constant value of pi as a `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.PI()`|  
|`POWER(` `numeric_expression, power_expression` `)`|Calculates the value of a specified expression to a specified power.<br /><br /> **Arguments**<br /><br /> `numeric_expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> `power_expression`: A `Double` that represents the power to which to raise the `numeric_expression`.<br /><br /> **Return Value**<br /><br /> The value of the specified `numeric_expression` to the specified `power_expression`.<br /><br /> **Example**<br /><br /> `SqlServer.POWER(2,7)`|  
|`RADIANS(` `expression` `)`|Converts degrees to radians.<br /><br /> **Arguments**<br /><br /> `expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Return Value**<br /><br /> An `Int32`, `Int64`,<br /><br /> `Double`, or<br /><br /> `Decimal`.<br /><br /> **Example**<br /><br /> `SqlServer.RADIANS(360.0)`|  
|`RAND(`[seed]`)`|Returns a random value from 0 through 1.<br /><br /> **Arguments**<br /><br /> Retruns the seed value as an `Int32`. If the seed is not specified, the SQL Server Database Engine assigns a seed value at random. For a specified seed value, the result returned is always the same.<br /><br /> **Return Value**<br /><br /> A random `Double` value from 0 through 1.<br /><br /> **Example**<br /><br /> `SqlServer.RAND()`|  
|`ROUND(` `numeric_expression, length` [ ,`function` ]`)`|Returns a numeric expression, rounded to the specified length or precision.<br /><br /> **Arguments**<br /><br /> `numeric_expression`: An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> `length`: An `Int32` that represents the precision to which `numeric_expression` is to be rounded. When `length` is a positive number, `numeric_expression` is rounded to the number of decimal positions specified by `length`. When `length` is a negative number, `numeric_expression` is rounded on the left side of the decimal point, as specified by `length`.<br /><br /> `function`:(optional) An `Int32` that represents the type of operation to perform. When function is omitted or has a value of 0 (default), `numeric_expression` is rounded. When a value other than 0 is specified, `numeric_expression` is truncated.<br /><br /> **Return Value**<br /><br /> The value of the specified `numeric_expression` to the specified `power_expression`.<br /><br /> **Example**<br /><br /> `SqlServer.ROUND(748.58, -3)`|  
|`SIGN(` `expression` `)`|Returns the positive (+1), zero (0), or negative (-1) sign of the specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: `Int32`, `Int64`, `Double`, or `Decimal`<br /><br /> **Return Value**<br /><br /> An `Int32`, `Int64`, `Double`, or `Decimal`.<br /><br /> **Example**<br /><br /> `SqlServer.SIGN(-10)`|  
|`SIN(` `expression` `)`|Calculates the trigonometric sine of the specified angle in radians, and returns a `Double` expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.SIN(20)`|  
|`SQRT(` `expression` `)`|Returns the square root of the specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.SQRT(3600)`|  
|`SQUARE(` `expression` `)`|Returns the square of the specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Double`.<br /><br /> **Return Value**<br /><br /> A `Double`.<br /><br /> **Example**<br /><br /> `SqlServer.SQUARE(25)`|  
|`TAN(` `expression` `)`|Calculates the tangent of a specified expression.<br /><br /> **Arguments**<br /><br /> `expression`: `Double`<br /><br /> **Return Value**<br /><br /> `Double`<br /><br /> **Example**<br /><br /> `SqlServer.TAN(45.0)`|  
  
 For more information about the mathematical functions that SqlClient supports, see the documentation for the SQL Server version that you specified in the SqlClient provider manifest:  
  
|SQL Server 2000|SQL Server 2005|SQL Server 2008|  
|---------------------|---------------------|---------------------|  
|[Mathematical Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115913)|[Mathematical Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115911)|[Mathematical Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115912)|  
  
## See Also  
 [SqlClient for Entity Framework Functions](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md)
