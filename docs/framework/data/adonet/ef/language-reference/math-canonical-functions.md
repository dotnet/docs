---
title: "Math Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6f6cddc6-b561-4ebe-84b6-841ef5b4113b
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Math Canonical Functions
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] includes math canonical functions.  
  
 The following table shows the math [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.  
  
|Function|Description|  
|--------------|-----------------|  
|`Abs(` `value` `)`|Returns the absolute value of `value`.<br /><br /> **Arguments**<br /><br /> An `Int16`, `Int32`, `Int64`, `Byte`, `Single`, `Double`, and `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> `Abs(-2)`|  
|`Ceiling(` `value` `)`|Returns the smallest integer that is not less than `value`.<br /><br /> **Arguments**<br /><br /> A `Single`, `Double`, and `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#EDM_CEILING](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_ceiling)]
 [!code-sql[DP EntityServices Concepts#EDM_CEILING](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_ceiling)]|  
|`Floor(` `value` `)`|Returns the largest integer that is not greater than `value`.<br /><br /> **Arguments**<br /><br /> A `Single`, `Double`, and `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> [!code-csharp[DP EntityServices Concepts#EDM_FLOOR](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/entitysql.cs#edm_floor)]
 [!code-sql[DP EntityServices Concepts#EDM_FLOOR](../../../../../../samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#edm_floor)]|  
|`Power(` `value`, `exponent``)`|Returns the result of the specified `value` to the specified `exponent`.<br /><br /> **Arguments**<br /><br /> `value`: An `Int32, Int64, Double`, or `Decimal`.<br /><br /> `exponent`: An `Int64``, Double`, or `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> `Power(748.58,2)`|  
|`Round(` `value` `)`|Returns the integer portion of `value`, rounded to the nearest integer.<br /><br /> **Arguments**<br /><br /> A `Single`, `Double`, and `Decimal`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> `Round(748.58)`|  
|`Round(` `value`, `digits``)`|Returns the `value`, rounded to the nearest specified `digits`.<br /><br /> **Arguments**<br /><br /> `value`: `Double` or `Decimal`.<br /><br /> `digits`: `Int16` or `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> `Round(748.58,1)`|  
|`Truncate(` `value`, `digits``)`|Returns the `value`, truncated to the nearest specified `digits`.<br /><br /> **Arguments**<br /><br /> `value`: `Double` or `Decimal`.<br /><br /> `digits`: `Int16` or `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `value`.<br /><br /> **Example**<br /><br /> `Truncate(748.58,1)`|  
  
 These functions will return `null` if given `null` input.  
  
 Equivalent functionality is available in the Microsoft SQL Client Managed Provider. For more information, see [SqlClient for Entity Framework Functions](../../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).  
  
## See Also  
 [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
