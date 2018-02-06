---
title: "Date and Time Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 971762d0-663b-4b64-8c61-352a8e6d3949
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Date and Time Functions
The .NET Framework Data Provider for SQL Server (SqlClient) provides date and time functions that perform operations on a `System.DateTime` input value and return a `string`, numeric, or `System.DateTime` value result. These functions are in the SqlServer namespace, which is available when you use SqlClient. A provider's namespace property allows the Entity Framework to discover which prefix is used by this provider for specific constructs, such as types and functions.The following table shows the SqlClient date and time functions.  
  
|Function|Description|  
|--------------|-----------------|  
|`DATEADD(` `datepart`, `number`, `date``)`|Returns a new `DateTime` value that is based on adding an interval to the specified date.<br /><br /> **Arguments**<br /><br /> `datepart`: A `String` that represents the part of the date on which to return a new value.<br /><br /> `number`: The `Int32`, `Int64`, `Decimal`, or `Double` value used to increment `datepart`.<br /><br /> `date:` An expression that returns a `DateTime`, or `DateTimeOffset`, or `Time` with precision = [0-7], or a character string in a date format.<br /><br /> **Return Value**<br /><br /> A new `DateTime`, or `DateTimeOffset`, or `Time` value with precision = [0-7].<br /><br /> **Example**<br /><br /> `SqlServer.DATEADD('day', 22, cast('6/9/2006' as DateTime))`|  
|`DATEDIFF(` `datepart`, `startdate`, `enddate``)`|Returns the number of date and time boundaries crossed between two specified dates.<br /><br /> **Arguments**<br /><br /> `datepart`: A `String` that represents the part of the date to calculate the difference.<br /><br /> `startdate`: A starting date for the calculation is an expression that returns a `DateTime`, or `DateTimeOffset`, or `Time` value with precision = [0-7], or a character string in a date format.<br /><br /> `enddate:` An ending date for the calculation is an expression that returns a `DateTime`, or `DateTimeOffset`, or `Time` value with precision = [0-7], or a character string in a date format.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `SqlServer.DATEDIFF('day', cast('6/9/2006' as DateTime),`<br /><br /> `cast('6/20/2006' as DateTime))`|  
|`DATENAME(` `datepart`, `date``)`|Returns a character string representing the specified datepart of the specified date.<br /><br /> **Arguments**<br /><br /> `datepart`: A `String` that represents the part of the date on which to return a new value.<br /><br /> `date`: An expression that returns a `DateTime,` or `DateTimeOffset`, or `Time` value with precision = [0-7], or a character string in a date format.<br /><br /> **Return Value**<br /><br /> The character string representing the specified datepart of the specified date.<br /><br /> **Example**<br /><br /> `SqlServer.DATENAME('year', cast('6/9/2006' as DateTime))`|  
|`DATEPART(` `datepart`, `date``)`|Returns an integer that represents the specified datepart of the specified date.<br /><br /> **Arguments**<br /><br /> `datepart`: A `String` that represents the part of the date on which to return a new value.<br /><br /> `date`: An expression that returns a `DateTime,` or `DateTimeOffset,` or `Time` value with precision = [0-7], or a character string in a date format.<br /><br /> **Return Value**<br /><br /> The specified datepart of the specified date, as an `Int32`.<br /><br /> **Example**<br /><br /> `SqlServer.DATEPART('year', cast('6/9/2006' as DateTime))`|  
|`DAY(` `date` `)`|Rreturns the day of the specified date as an integer.<br /><br /> **Arguments**<br /><br /> `date`:An expression of type `DateTime` or `DateTimeOffset` with precision = 0-7.<br /><br /> **Return Value**<br /><br /> The day of the specified date as an `Int32`.<br /><br /> **Example**<br /><br /> `SqlServer.DAY(cast('6/9/2006' as DateTime))`|  
|`GETDATE()`|Produces the current date and time in SQL Server internal format for datetime values.<br /><br /> **Return Value**<br /><br /> The current system date and time as a `DateTime` with a precision of 3.<br /><br /> **Example**<br /><br /> `SqlServer.GETDATE()`|  
|`GETUTCDATE()`|Produces the datetime value in UTC (Coordinated Universal Time or Greenwich Mean Time) format.<br /><br /> **Return Value**<br /><br /> The `DateTime` value with a precision of 3 in UTC format.<br /><br /> **Example**<br /><br /> `SqlServer.GETUTCDATE()`|  
|`MONTH(` `date` `)`|Returns the month of the specified date as an integer.<br /><br /> **Arguments**<br /><br /> `date`:An expression of type `DateTime` or `DateTimeOffset` with precision = 0-7.<br /><br /> **Return Value**<br /><br /> The month of the specified date as an `Int32`.<br /><br /> **Example**<br /><br /> `SqlServer.MONTH(cast('6/9/2006' as DateTime))`|  
|`YEAR(` `date` `)`|Returns the year of the specified date as an integer.<br /><br /> **Arguments**<br /><br /> `date`:An expression of type `DateTime` or `DateTimeOffset` with precision = 0-7.<br /><br /> **Return Value**<br /><br /> The year of the specified date as an `Int32`.<br /><br /> **Example**<br /><br /> `SqlServer.YEAR(cast('6/9/2006' as DateTime))`|  
|`SYSDATETIME()`|Returns a `DateTime` value with a precision of 7.<br /><br /> **Return Value**<br /><br /> A `DateTime` value with a precision of 7.<br /><br /> **Example**<br /><br /> `SqlServer.SYSDATETIME()`|  
|`SYSUTCDATE()`|Produces the datetime value in UTC (Coordinated Universal Time or Greenwich Mean Time) format.<br /><br /> **Return Value**<br /><br /> The `DateTime` value with precision = 7 in UTC format.<br /><br /> **Example**<br /><br /> `SqlServer.SYSUTCDATE()`|  
|`SYSDATETIMEOFFSET()`|Returns a `DateTimeOffset` with a precision of 7.<br /><br /> **Return Value**<br /><br /> A `DateTimeOffset` value with precision of 7 in UTC format.<br /><br /> **Example**<br /><br /> `SqlServer.SYSDATETIMEOFFSET()`|  
  
 For more information about the date and time functions that SqlClient supports, see the documentation for the SQL Server version that you specified in the SqlClient provider manifest:  
  
|SQL Server 2000|SQL Server 2005|SQL Server 2008|  
|---------------------|---------------------|---------------------|  
|[Date and Time Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115908)|[Date and Time Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=115909)|[Date and Time Functions (Transact-SQL)](http://go.microsoft.com/fwlink/?LinkId=98360)|  
  
## See Also  
 [SqlClient for Entity Framework Functions](../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md)
