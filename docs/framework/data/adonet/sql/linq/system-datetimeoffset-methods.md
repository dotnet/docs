---
description: "Learn more about: System.DateTimeOffset Methods"
title: "System.DateTimeOffset Methods"
ms.date: "03/30/2017"
ms.assetid: 25b3e5c0-7603-4a70-b3e5-2149e3da69a2
---
# System.DateTimeOffset Methods

Once mapped in the object model or external mapping file, LINQ to SQL allows you to call most of the <xref:System.DateTimeOffset?displayProperty=nameWithType> methods, operators, and properties from within your LINQ to SQL queries.  
  
 The only methods not supported are those inherited from <xref:System.Object?displayProperty=nameWithType> that do not make sense in the context of LINQ to SQL queries, such as: `Finalize`, `GetHashCode`, `GetType`, and `MemberwiseClone`. These methods are not supported because LINQ to SQL cannot translate them for execution on the SQL Server.  
  
> [!NOTE]
> The common language runtime (CLR) <xref:System.DateTimeOffset?displayProperty=nameWithType> structure, and the ability to map it to a SQL `DATETIMEOFFSET` column with LINQ to SQL, requires the .NET Framework 3.5 SP1 or beyond. The SQL `DATETIMEOFFSET` column is only available in Microsoft SQL Server 2008 and beyond.  
  
## SQLMethods Date and Time Methods  

 In addition to the methods offered by the <xref:System.DateTimeOffset> structure, LINQ to SQL offers the following methods from the <xref:System.Data.Linq.SqlClient.SqlMethods?displayProperty=nameWithType> class for working with date and time:

- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffDay%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMillisecond%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffNanosecond%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffHour%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMinute%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffSecond%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMicrosecond%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffMonth%2A>
- <xref:System.Data.Linq.SqlClient.SqlMethods.DateDiffYear%2A>
  
## See also

- [Query Concepts](query-concepts.md)
- [Creating the Object Model](creating-the-object-model.md)
- [SQL-CLR Type Mapping](sql-clr-type-mapping.md)
