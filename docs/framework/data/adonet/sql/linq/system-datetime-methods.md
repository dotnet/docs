---
description: "Learn more about: System.DateTime Methods"
title: "System.DateTime Methods"
ms.date: "03/30/2017"
ms.assetid: 4f80700c-e83f-4ab6-af0f-1c9a606e1133
---
# System.DateTime Methods

The following LINQ to SQL-supported methods, operators, and properties are available to use in LINQ to SQL queries. When a method, operator or property is unsupported, LINQ to SQL cannot translate the member for execution on the SQL Server. You may use these members in your code, however, they must be evaluated before the query is translated to Transact-SQL or after the results have been retrieved from the database.

## Supported System.DateTime Members

 Once mapped in the object model or external mapping file, LINQ to SQL allows you to call the following <xref:System.DateTime?displayProperty=nameWithType> members inside LINQ to SQL queries.

|Supported <xref:System.DateTime> Methods|Supported <xref:System.DateTime> Operators|Supported <xref:System.DateTime> Properties|
|-|-|-|
|<xref:System.DateTime.Add*>|<xref:System.DateTime.op_Addition*>|<xref:System.DateTime.Date*>|
|<xref:System.DateTime.AddDays*>|<xref:System.DateTime.op_Equality*>|<xref:System.DateTime.Day*>|
|<xref:System.DateTime.AddHours*>|<xref:System.DateTime.op_GreaterThan*>|<xref:System.DateTime.DayOfWeek*>|
|<xref:System.DateTime.AddMilliseconds*>|<xref:System.DateTime.op_GreaterThanOrEqual*>|<xref:System.DateTime.DayOfYear*>|
|<xref:System.DateTime.AddMinutes*>|<xref:System.DateTime.op_Inequality*>|<xref:System.DateTime.Hour*>|
|<xref:System.DateTime.AddMonths*>|<xref:System.DateTime.op_LessThan*>|<xref:System.DateTime.Millisecond*>|
|<xref:System.DateTime.AddSeconds*>|<xref:System.DateTime.op_LessThanOrEqual*>|<xref:System.DateTime.Minute*>|
|<xref:System.DateTime.AddTicks*>|<xref:System.DateTime.op_Subtraction*>|<xref:System.DateTime.Month*>|
|<xref:System.DateTime.AddYears*>||<xref:System.DateTime.Now*>|
|<xref:System.DateTime.Compare*>||<xref:System.DateTime.Second*>|
|<xref:System.DateTime.CompareTo%28System.DateTime%29>||<xref:System.DateTime.TimeOfDay*>|
|<xref:System.DateTime.Equals%28System.DateTime%29>||<xref:System.DateTime.Today>|
|||<xref:System.DateTime.Year*>|

## Members Not Supported by LINQ to SQL

 The following members are not supported inside LINQ to SQL queries:

- <xref:System.DateTime.IsDaylightSavingTime*>
- <xref:System.DateTime.IsLeapYear*>
- <xref:System.DateTime.DaysInMonth*>
- <xref:System.DateTime.ToBinary*>
- <xref:System.DateTime.ToFileTime*>
- <xref:System.DateTime.ToFileTimeUtc*>
- <xref:System.DateTime.ToLongDateString*>
- <xref:System.DateTime.ToLongTimeString*>
- <xref:System.DateTime.ToOADate*>
- <xref:System.DateTime.ToShortDateString*>
- <xref:System.DateTime.ToShortTimeString*>
- <xref:System.DateTime.ToUniversalTime*>
- <xref:System.DateTime.FromBinary*>
- <xref:System.DateTime.UtcNow*>
- <xref:System.DateTime.FromFileTime*>
- <xref:System.DateTime.FromFileTimeUtc*>
- <xref:System.DateTime.FromOADate*>
- <xref:System.DateTime.GetDateTimeFormats*>

## Method Translation Example

 All methods supported by LINQ to SQL are translated to Transact-SQL before they are sent to   SQL Server. For example, consider the following pattern.

 `(dateTime1 - dateTime2).{Days, Hours, Milliseconds, Minutes, Months, Seconds, Years}`

 When it is recognized, it is translated into a direct call to the SQL Server `DATEDIFF` function, as follows:

 `DATEDIFF({DatePart}, @dateTime1, @dateTime2)`

## SQLMethods Date and Time Methods

 In addition to the methods offered by the <xref:System.DateTime> structure, LINQ to SQL offers the following methods from the <xref:System.Data.Linq.SqlClient.SqlMethods?displayProperty=nameWithType> class for working with date and time:

- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffDay*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMillisecond*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffNanosecond*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffHour*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMinute*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffSecond*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMicrosecond*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMonth*>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffYear*>

## See also

- [Query Concepts](query-concepts.md)
- [Creating the Object Model](creating-the-object-model.md)
- [SQL-CLR Type Mapping](sql-clr-type-mapping.md)
- [Data Types and Functions](data-types-and-functions.md)
