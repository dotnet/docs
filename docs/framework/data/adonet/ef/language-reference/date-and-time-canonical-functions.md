---
title: "Date and Time Canonical Functions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9628b74f-1585-436a-b385-8b02ed0cdd63
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Date and Time Canonical Functions
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] includes date and time canonical functions.  
  
## Remarks  
 The following table shows the date and time [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions. `datetime` is a <xref:System.DateTime> value.  
  
|Function|Description|  
|--------------|-----------------|  
|`AddNanoseconds(` `expression`, `number``)`|Adds the specified `number` of nanoseconds to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddMicroseconds(` `expression`, `number``)`|Adds the specified `number` of microseconds to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddMilliseconds(` `expression`, `number``)`|Adds the specified `number` of milliseconds to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddSeconds(` `expression`, `number``)`|Adds the specified `number` of seconds to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddMinutes(` `expression`, `number``)`|Adds the specified `number` of minutes to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddHours(` `expression`, `number``)`|Adds the specified `number` of hours to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime`, `DateTimeOffset`, or `Time`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddDays(` `expression`, `number``)`|Adds the specified `number` of days to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime` or `DateTimeOffset`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddMonths(` `expression`, `number``)`|Adds the specified `number` of months to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime` or `DateTimeOffset`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`AddYears(` `expression`, `number``)`|Adds the specified `number` of years to the `expression`.<br /><br /> **Arguments**<br /><br /> `expression`: `DateTime` or `DateTimeOffset`.<br /><br /> `number`: `Int32`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`CreateDateTime(` `year`, `month`, `day`, `hour`, `minute`, `second``)`|Returns a new `DateTime` value as the current date and time of the server in the server's time zone.<br /><br /> **Arguments**<br /><br /> `year`, `month`, `day`, `hour`, `minute`: `Int16` and `Int32`.<br /><br /> `second`: `Double`.<br /><br /> **Return Value**<br /><br /> A `DateTime`.|  
|`CreateDateTimeOffset(` `year`, `month`, `day`, `hour`, `minute`, `second`, `tzoffset``)`|Returns a new `DateTimeOffset` value as the current date and time of the server relative to the Coordinated Universal Time (UTC).<br /><br /> **Arguments**<br /><br /> `year`, `month`, `day`, `hour`, `minute`, `tzoffset`: `Int32`.<br /><br /> `second`: `Double`.<br /><br /> **Return Value**<br /><br /> A `DateTimeOffset`.|  
|`CreateTime(` `hour`, `minute`, `second``)`|Returns a new `Time` value as the current time.<br /><br /> **Arguments**<br /><br /> `hour` and `minute`: `Int32`.<br /><br /> `second`: `Double`.<br /><br /> **Return Value**<br /><br /> A `Time`.|  
|`CurrentDateTime()`|Returns a `DateTime` value as the current date and time of the server in the server's time zone.<br /><br /> **Return Value**<br /><br /> A `DateTime`.|  
|`CurrentDateTimeOffset()`|Returns the current date, time and offset as a `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> A `DateTimeOffset`.|  
|`CurrentUtcDateTime()`|Returns a <xref:System.DateTime> value as the current date and time of the server in the UTS time zone.<br /><br /> **Return Value**<br /><br /> A `DateTime`.|  
|`Day(` `expression` `)`|Returns the day portion of `expression` as an `Int32` between 1 and 31.<br /><br /> **Arguments**<br /><br /> A `DateTime` and `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 12.`<br /><br /> `Day(cast('03/12/1998' as DateTime))`|  
|`DayOfYear(` `expression` `)`|Returns the day portion of `expression` as an `Int32` between 1 and 366, where 366 is returned for the last day of a leap year.<br /><br /> **Arguments**<br /><br /> A `DateTime` or `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffNanoseconds(` `startExpression`, `endExpression``)`|Returns the difference, in nanoseconds, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffMilliseconds(` `startExpression`, `endExpression``)`|Returns the difference, in milliseconds, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffMicroseconds(` `startExpression`, `endExpression``)`|Returns the difference, in microseconds, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffSeconds(` `startExpression`, `endExpression``)`|Returns the difference, in seconds, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffMinutes(` `startExpression`, `endExpression``)`|Returns the difference, in minutes, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffHours(` `startExpression`, `endExpression``)`|Returns the difference, in hours, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime`, `DateTimeOffset`, or `Time`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffDays(` `startExpression`, `endExpression``)`|Returns the difference, in days, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime` or `DateTimeOffset`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffMonths(` `startExpression`, `endExpression``)`|Returns the difference, in months, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime` or `DateTimeOffset`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`DiffYears(` `startExpression`, `endExpression``)`|Returns the difference, in years, between `startExpression` and `endExpression`.<br /><br /> **Arguments**<br /><br /> `startExpression`, `endExpression`: `DateTime` or `DateTimeOffset`. **Note:**  `startExpression` and `endExpression` must be of the same type. <br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`GetTotalOffsetMinutes(` `datetimeoffset` `)`|Returns the number of minutes that the `datetimeoffset` is offset from GMT. This is generally between +780 and -780 (+ or - 13 hrs). **Note:**  This function is supported in SQL Server 2008 only. <br /><br /> **Arguments**<br /><br /> A `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`Hour (` `expression` `)`|Returns the hour portion of `expression` as an `Int32` between 0 and 23.<br /><br /> **Arguments**<br /><br /> A `DateTime, Time` and `DateTimeOffset`.<br /><br /> **Example**<br /><br /> `-- The following example returns 22.`<br /><br /> `Hour(cast('22:35:5' as DateTime))`|  
|`Millisecond(` `expression` `)`|Returns the milliseconds portion of `expression` as an `Int32` between 0 and 999.<br /><br /> **Arguments**<br /><br /> A `DateTime, Time` and `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.|  
|`Minute(` `expression` `)`|Returns the minute portion of `expression` as an `Int32` between 0 and 59.<br /><br /> **Arguments**<br /><br /> A `DateTime, Time` or `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 35`<br /><br /> `Minute(cast('22:35:5' as DateTime))`|  
|`Month` `(` `expression` `)`|Returns the month portion of `expression` as an `Int32` between 1 and 12.<br /><br /> **Arguments**<br /><br /> A `DateTime` or `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 3.`<br /><br /> `Month(cast('03/12/1998' as DateTime))`|  
|`Second(` `expression` `)`|Returns the seconds portion of `expression` as an `Int32` between 0 and 59.<br /><br /> **Arguments**<br /><br /> A `DateTime, Time` and `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 5`<br /><br /> `Second(cast('22:35:5' as DateTime))`|  
|`TruncateTime(` `expression` `)`|Returns the `expression`, with the time values truncated.<br /><br /> **Arguments**<br /><br /> A `DateTime` or `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> The type of `expression`.|  
|`Year(` `expression` `)`|Returns the year portion of `expression` as an `Int32``YYYY`.<br /><br /> **Arguments**<br /><br /> A `DateTime` and `DateTimeOffset`.<br /><br /> **Return Value**<br /><br /> An `Int32`.<br /><br /> **Example**<br /><br /> `-- The following example returns 1998.`<br /><br /> `Year(cast('03/12/1998' as DateTime))`|  
  
 These functions will return `null` if given `null` input.  
  
 Equivalent functionality is available in the Microsoft SQL Client Managed Provider. For more information, see [SqlClient for Entity Framework Functions](../../../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-functions.md).  
  
## See Also  
 [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
