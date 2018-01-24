---
title: "System Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b7c71b58-09e6-44ce-a3e5-a0fdb892fb86
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# System Functions
The .NET Framework Data Provider for SQL Server (SqlClient) provides the following system functions:  
  
|Function|Description|  
|--------------|-----------------|  
|`CHECKSUM (` `value`, [`value`, [`value`]]`)`|Returns the checksum value. `CHECKSUM` is intended for use in building hash indexes.<br /><br /> **Arguments**<br /><br /> `value`: A `Boolean`, `Byte`, `Int16`, `Int32`, `Int64`, `Single`, `Decimal`, `Double`, `DateTime`, `String`, `Binary`, or `Guid`. You can specify one, two or three values.<br /><br /> **Return Value**<br /><br /> The absolute value of the specified expression.<br /><br /> **Example**<br /><br /> `SqlServer.CHECKSUM(10,100,1000.0)`|  
|`CURRENT_TIMESTAMP ()`|Produces the current date and time in SQL Server internal format for `DateTime` values with a precision of 7 in SQL Server 2008 and a precision of 3 in SQL Server 2005.<br /><br /> **Return Value**<br /><br /> The current system date and time as a `DateTime`.<br /><br /> **Example**<br /><br /> `SqlServer.CURRENT_TIMESTAMP()`|  
|`CURRENT_ USER` `()`|Returns the name of the current user.<br /><br /> **Return Value**<br /><br /> An ASCII `String`.<br /><br /> **Example**<br /><br /> `SqlServer.CURRENT_USER()`|  
|`DATALENGTH` `(` `expression` `)`|Returns the number of bytes used to represent any expression.<br /><br /> **Arguments**<br /><br /> `expression`: A `Boolean`, `Byte`, `Int16`, `Int32`, `Int64`, `Single`, `Decimal`, `Double`, `DateTime`, `Time`, `DateTimeOffset`, `String`, `Binary`, or `Guid`.<br /><br /> **Return Value**<br /><br /> The size of properties as an `Int32`.<br /><br /> **Example**<br /><br /> `SELECT VALUE SqlServer.DATALENGTH(P.Name)FROM`<br /><br /> `AdventureWorksEntities.Product AS P`|  
|`HOST_NAME()`|Returns the workstation name.<br /><br /> **Return Value**<br /><br /> A Unicode `String`.<br /><br /> **Example**<br /><br /> `SqlServer.HOST_NAME()`|  
|`ISDATE(` `expression` `)`|Determines whether an input expression is a valid date.<br /><br /> **Arguments**<br /><br /> `expression`: A `Boolean`, `Byte`, `Int16`, `Int32`, `Int64`, `Single`, `Decimal`, `Double`, `DateTime`, `Time`, `DateTimeOffset`, `String`, `Binary`, or `Guid`.<br /><br /> **Return Value**<br /><br /> An `Int32`. One (1) if the input expression is a valid date. Zero (0) otherwise.<br /><br /> **Example**<br /><br /> `SqlServer.ISDATE('1/1/2006')`|  
|`ISNUMERIC(` `expression` `)`|Determines whether an expression is a valid numeric type.<br /><br /> **Arguments**<br /><br /> `expression`: A `Boolean`, `Byte`, `Int16`, `Int32`, `Int64`, `Single`, `Decimal`, `Double`, `DateTime`, `Time`, `DateTimeOffset`, `String`, `Binary`, or `Guid`.<br /><br /> **Return Value**<br /><br /> An `Int32`. One (1) if the input expression is a valid date. Zero (0) otherwise.<br /><br /> **Example**<br /><br /> `SqlServer.ISNUMERIC('21')`|  
|`NEWID()`|Creates a unique value of type Guid.<br /><br /> **Return Value**<br /><br /> A `Guid`.<br /><br /> **Example**<br /><br /> `SqlServer.NEWID()`|  
|`USER_NAME(` `id` `)`|Returns a database user name from a specified identification number.<br /><br /> **Arguments**<br /><br /> `expression`: An `Int32` identification number associated with a database user.<br /><br /> **Return Value**<br /><br /> A Unicode `String`.<br /><br /> **Example**<br /><br /> `SqlServer.USER_NAME(0)`|  
  
 For more information about the string functions that SqlClient supports, see the documentation for the SQL Server version that you specified in the SqlClient provider manifest:  
  
|SQL Server 2000|SQL Server 2005|SQL Server 2008|  
|---------------------|---------------------|---------------------|  
|[System Functions Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115918)|[System Functions Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115917)|[System Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115919)|  
  
## See Also  
 [Entity SQL Language](../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)  
 [SqlClient for Entity Framework Functions](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md)
