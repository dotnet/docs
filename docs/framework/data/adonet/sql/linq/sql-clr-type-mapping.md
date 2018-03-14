---
title: "SQL-CLR Type Mapping"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4ed76327-54a7-414b-82a9-7579bfcec04b
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL-CLR Type Mapping
In LINQ to SQL, the data model of a relational database maps to an object model that is expressed in the programming language of your choice. When the application runs, LINQ to SQL translates the language-integrated queries in the object model into SQL and sends them to the database for execution. When the database returns the results, LINQ to SQL translates the results back to objects that you can work with in your own programming language.  
  
 In order to translate data between the object model and the database, a *type mapping* must be defined. LINQ to SQL uses a type mapping to match each common language runtime (CLR) type with a particular SQL Server type. You can define type mappings and other mapping information, such as database structure and table relationships, inside the object model with attribute-based mapping. Alternatively, you can specify the mapping information outside the object model with an external mapping file. For more information, see [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md) and [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md).  
  
 This topic discusses the following points:  
  
-   [Default Type Mapping](#DefaultTypeMapping)  
  
-   [Type Mapping Run-time Behavior Matrix](#BehaviorMatrix)  
  
-   [Behavior Differences Between CLR and SQL Execution](#BehaviorDiffs)  
  
-   [Enum Mapping](#EnumMapping)  
  
-   [Numeric Mapping](#NumericMapping)  
  
-   [Text and XML Mapping](#TextMapping)  
  
-   [Date and Time Mapping](#DateMapping)  
  
-   [Binary Mapping](#BinaryMapping)  
  
-   [Miscellaneous Mapping](#MiscMapping)  
  
<a name="DefaultTypeMapping"></a>   
## Default Type Mapping  
 You can create the object model or external mapping file automatically with the Object Relational Designer (O/R Designer) or the SQLMetal command-line tool. The default type mappings for these tools define which CLR types are chosen to map to columns inside the SQL Server database. For more information about using these tools, see [Creating the Object Model](../../../../../../docs/framework/data/adonet/sql/linq/creating-the-object-model.md).  
  
 You can also use the <xref:System.Data.Linq.DataContext.CreateDatabase%2A> method to create a SQL Server database based on the mapping information in the object model or external mapping file. The default type mappings for the <xref:System.Data.Linq.DataContext.CreateDatabase%2A> method define which type of SQL Server columns are created to map to the CLR types in the object model. For more information, see [How to: Dynamically Create a Database](../../../../../../docs/framework/data/adonet/sql/linq/how-to-dynamically-create-a-database.md).  
  
<a name="BehaviorMatrix"></a>   
## Type Mapping Run-time Behavior Matrix  
 The following diagram shows the expected run-time behavior of specific type mappings when data is retrieved from or saved to the database. With the exception of serialization, LINQ to SQL does not support mapping between any CLR or SQL Server data types that are not specified in this matrix. For more information on serialization support, see [Binary Serialization](#BinarySerialization).  
  
> [!NOTE]
>  Some type mappings may result in overflow or data loss exceptions while translating to or from the database.  
  
### Custom Type Mapping  
 With LINQ to SQL, you are not limited to the default type mappings used by the O/R Designer, SQLMetal, and the <xref:System.Data.Linq.DataContext.CreateDatabase%2A> method. You can create custom type mappings by explicitly specifying them in a DBML file. Then you can use that DBML file to create the object model code and mapping file. For more information, see [SQL-CLR Custom Type Mappings](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-custom-type-mappings.md).  
  
<a name="BehaviorDiffs"></a>   
## Behavior Differences Between CLR and SQL Execution  
 Because of differences in precision and execution between the CLR and SQL Server, you may receive different results or experience different behavior depending on where you perform your calculations. Calculations performed in LINQ to SQL queries are actually translated to Transact-SQL and then executed on the SQL Server database. Calculations performed outside LINQ to SQL queries are executed within the context of the CLR.  
  
 For example, the following are some differences in behavior between the CLR and SQL Server:  
  
-   SQL Server orders some data types differently than data of equivalent type in the CLR. For example, SQL Server data of type `UNIQUEIDENTIFIER` is ordered differently than CLR data of type <xref:System.Guid?displayProperty=nameWithType>.  
  
-   SQL Server handles some string comparison operations differently than the CLR. In SQL Server, string comparison behavior depends on the collation settings on the server. For more information, see [Working with Collations](http://go.microsoft.com/fwlink/?LinkId=115330) in the Microsoft SQL Server Books Online.  
  
-   SQL Server may return different values for some mapped functions than the CLR. For example, equality functions will differ because SQL Server considers two strings to be equal if they only differ in trailing white space; whereas the CLR considers them to be not equal.  
  
<a name="EnumMapping"></a>   
## Enum Mapping  
 LINQ to SQL supports mapping the CLR <xref:System.Enum?displayProperty=nameWithType> type to SQL Server types in two ways:  
  
-   Mapping to SQL numeric types (`TINYINT`, `SMALLINT`, `INT`, `BIGINT`)  
  
     When you map a CLR <xref:System.Enum?displayProperty=nameWithType> type to a SQL numeric type, you map the underlying integer value of the CLR <xref:System.Enum?displayProperty=nameWithType> to the value of the SQL Server database column. For example, if a <xref:System.Enum?displayProperty=nameWithType> named `DaysOfWeek` contains a member named `Tue` with an underlying integer value of 3, that member maps to a database value of 3.  
  
-   Mapping to SQL text types (`CHAR`, `NCHAR`, `VARCHAR`, `NVARCHAR`)  
  
     When you map a CLR <xref:System.Enum?displayProperty=nameWithType> type to a SQL text type, the SQL database value is mapped to the names of the CLR <xref:System.Enum?displayProperty=nameWithType> members. For example, if a <xref:System.Enum?displayProperty=nameWithType> named `DaysOfWeek` contains a member named `Tue` with an underlying integer value of 3, that member maps to a database value of `Tue`.  
  
> [!NOTE]
>  When mapping SQL text types to a CLR <xref:System.Enum?displayProperty=nameWithType>, include only the names of the <xref:System.Enum> members in the mapped SQL column. Other values are not supported in the <xref:System.Enum>-mapped SQL column.  
  
 The O/R Designer and SQLMetal command-line tool cannot automatically map a SQL type to a CLR <xref:System.Enum> class. You must explicitly configure this mapping by customizing a DBML file for use by the O/R Designer and SQLMetal. For more information about custom type mapping, see [SQL-CLR Custom Type Mappings](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-custom-type-mappings.md).  
  
 Because a SQL column intended for enumeration will be of the same type as other numeric and text columns; these tools will not recognize your intent and default to mapping as described in the following [Numeric Mapping](#NumericMapping) and [Text and XML Mapping](#TextMapping) sections. For more information about generating code with the DBML file, see [Code Generation in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/code-generation-in-linq-to-sql.md).  
  
 The <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method creates a SQL column of numeric type to map a CLR <xref:System.Enum?displayProperty=nameWithType> type.  
  
<a name="NumericMapping"></a>   
## Numeric Mapping  
 LINQ to SQL lets you map many CLR and SQL Server numeric types. The following table shows the CLR types that O/R Designer and SQLMetal select when building an object model or external mapping file based on your database.  
  
|SQL Server Type|Default CLR Type mapping used by O/R Designer and SQLMetal|  
|---------------------|-----------------------------------------------------------------|  
|`BIT`|<xref:System.Boolean?displayProperty=nameWithType>|  
|`TINYINT`|<xref:System.Int16?displayProperty=nameWithType>|  
|`INT`|<xref:System.Int32?displayProperty=nameWithType>|  
|`BIGINT`|<xref:System.Int64?displayProperty=nameWithType>|  
|`SMALLMONEY`|<xref:System.Decimal?displayProperty=nameWithType>|  
|`MONEY`|<xref:System.Decimal?displayProperty=nameWithType>|  
|`DECIMAL`|<xref:System.Decimal?displayProperty=nameWithType>|  
|`NUMERIC`|<xref:System.Decimal?displayProperty=nameWithType>|  
|`REAL/FLOAT(24)`|<xref:System.Single?displayProperty=nameWithType>|  
|`FLOAT/FLOAT(53)`|<xref:System.Double?displayProperty=nameWithType>|  
  
 The next table shows the default type mappings used by the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method to define which type of SQL columns are created to map to the CLR types defined in your object model or external mapping file.  
  
|CLR Type|Default SQL Server Type used by <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType>|  
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Boolean?displayProperty=nameWithType>|`BIT`|  
|<xref:System.Byte?displayProperty=nameWithType>|`TINYINT`|  
|<xref:System.Int16?displayProperty=nameWithType>|`SMALLINT`|  
|<xref:System.Int32?displayProperty=nameWithType>|`INT`|  
|<xref:System.Int64?displayProperty=nameWithType>|`BIGINT`|  
|<xref:System.SByte?displayProperty=nameWithType>|`SMALLINT`|  
|<xref:System.UInt16?displayProperty=nameWithType>|`INT`|  
|<xref:System.UInt32?displayProperty=nameWithType>|`BIGINT`|  
|<xref:System.UInt64?displayProperty=nameWithType>|`DECIMAL(20)`|  
|<xref:System.Decimal?displayProperty=nameWithType>|`DECIMAL(29,4)`|  
|<xref:System.Single?displayProperty=nameWithType>|`REAL`|  
|<xref:System.Double?displayProperty=nameWithType>|`FLOAT`|  
  
 There are many other numeric mappings you can choose, but some may result in overflow or data loss exceptions while translating to or from the database. For more information, see the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix).  
  
### Decimal and Money Types  
 The default precision of SQL Server `DECIMAL` type (18 decimal digits to the left and right of the decimal point) is much smaller than the precision of the CLR <!--zz <xref:System.Decima?displayProperty=nameWithType>l --> `Decimal` type that it is paired with by default. This can result in precision loss when you save data to the database. However, just the opposite can happen if the SQL Server `DECIMAL` type is configured with greater than 29 digits of precision. When a SQL Server `DECIMAL` type has been configured with a greater precision than the CLR <xref:System.Decimal?displayProperty=nameWithType>, precision loss can occur when retrieving data from the database.  
  
 The SQL Server `MONEY` and `SMALLMONEY` types, which are also paired with the CLR <xref:System.Decimal?displayProperty=nameWithType> type by default, have a much smaller precision, which can result in overflow or data loss exceptions when saving data to the database.  
  
<a name="TextMapping"></a>   
## Text and XML Mapping  
 There are also many text-based and XML types that you can map with LINQ to SQL. The following table shows the CLR types that O/R Designer and SQLMetal select when building an object model or external mapping file based on your database.  
  
|SQL Server Type|Default CLR Type mapping used by O/R Designer and SQLMetal|  
|---------------------|-----------------------------------------------------------------|  
|`CHAR`|<xref:System.String?displayProperty=nameWithType>|  
|`NCHAR`|<xref:System.String?displayProperty=nameWithType>|  
|`VARCHAR`|<xref:System.String?displayProperty=nameWithType>|  
|`NVARCHAR`|<xref:System.String?displayProperty=nameWithType>|  
|`TEXT`|<xref:System.String?displayProperty=nameWithType>|  
|`NTEXT`|<xref:System.String?displayProperty=nameWithType>|  
|`XML`|<xref:System.Xml.Linq.XElement?displayProperty=nameWithType>|  
  
 The next table shows the default type mappings used by the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method to define which type of SQL columns are created to map to the CLR types defined in your object model or external mapping file.  
  
|CLR Type|Default SQL Server Type used by <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType>|  
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Char?displayProperty=nameWithType>|`NCHAR(1)`|  
|<xref:System.String?displayProperty=nameWithType>|`NVARCHAR(4000)`|  
|<xref:System.Char?displayProperty=nameWithType>[]|`NVARCHAR(4000)`|  
|Custom type implementing `Parse()` and `ToString()`|`NVARCHAR(MAX)`|  
  
 There are many other text-based and XML mappings you can choose, but some may result in overflow or data loss exceptions while translating to or from the database. For more information, see the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix).  
  
### XML Types  
 The SQL Server `XML` data type is available starting in Microsoft SQL Server 2005. You can map the SQL Server `XML` data type to <xref:System.Xml.Linq.XElement>, <xref:System.Xml.Linq.XDocument>, or <xref:System.String>. If the column stores XML fragments that cannot be read into <xref:System.Xml.Linq.XElement>, the column must be mapped to <xref:System.String> to avoid run-time errors. XML fragments that must be mapped to <xref:System.String> include the following:  
  
-   A sequence of XML elements  
  
-   Attributes  
  
-   Public Identifiers (PI)  
  
-   Comments  
  
 Although you can map <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XDocument> to SQL Server as shown in the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix), the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method has no default SQL Server type mapping for these types.  
  
### Custom Types  
 If a class implements `Parse()` and `ToString()`, you can map the object to any SQL text type (`CHAR`, `NCHAR`, `VARCHAR`, `NVARCHAR`, `TEXT`, `NTEXT`, `XML`). The object is stored in the database by sending the value returned by `ToString()` to the mapped database column. The object is reconstructed by invoking `Parse()` on the string returned by the database.  
  
> [!NOTE]
>  LINQ to SQL does not support serialization by using <xref:System.Xml.Serialization.IXmlSerializable?displayProperty=nameWithType>.  
  
<a name="DateMapping"></a>   
## Date and Time Mapping  
 With LINQ to SQL, you can map many SQL Server date and time types. The following table shows the CLR types that O/R Designer and SQLMetal select when building an object model or external mapping file based on your database.  
  
|SQL Server Type|Default CLR Type mapping used by O/R Designer and SQLMetal|  
|---------------------|-----------------------------------------------------------------|  
|`SMALLDATETIME`|<xref:System.DateTime?displayProperty=nameWithType>|  
|`DATETIME`|<xref:System.DateTime?displayProperty=nameWithType>|  
|`DATETIME2`|<xref:System.DateTime?displayProperty=nameWithType>|  
|`DATETIMEOFFSET`|<xref:System.DateTimeOffset?displayProperty=nameWithType>|  
|`DATE`|<xref:System.DateTime?displayProperty=nameWithType>|  
|`TIME`|<xref:System.TimeSpan?displayProperty=nameWithType>|  
  
 The next table shows the default type mappings used by the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method to define which type of SQL columns are created to map to the CLR types defined in your object model or external mapping file.  
  
|CLR Type|Default SQL Server Type used by <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType>|  
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.DateTime?displayProperty=nameWithType>|`DATETIME`|  
|<xref:System.DateTimeOffset?displayProperty=nameWithType>|`DATETIMEOFFSET`|  
|<xref:System.TimeSpan?displayProperty=nameWithType>|`TIME`|  
  
 There are many other date and time mappings you can choose, but some may result in overflow or data loss exceptions while translating to or from the database. For more information, see the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix).  
  
> [!NOTE]
>  The SQL Server types `DATETIME2`, `DATETIMEOFFSET`, `DATE`, and `TIME` are available starting with Microsoft SQL Server 2008. LINQ to SQL supports mapping to these new types starting with the .NET Framework version 3.5 SP1.  
  
### System.Datetime  
 The range and precision of the CLR <xref:System.DateTime?displayProperty=nameWithType> type is greater than the range and precision of the SQL Server `DATETIME` type, which is the default type mapping for the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method. To help avoid exceptions related to dates outside the range of `DATETIME`, use `DATETIME2`, which is available starting with Microsoft SQL Server 2008. `DATETIME2` can match the range and precision of the CLR <xref:System.DateTime?displayProperty=nameWithType>.  
  
 SQL Server dates have no concept of <xref:System.TimeZone>, a feature that is richly supported in the CLR. <xref:System.TimeZone> values are saved as is to the database without <xref:System.TimeZone> conversion, regardless of the original <xref:System.DateTimeKind> information. When <xref:System.DateTime> values are retrieved from the database, their value is loaded as is into a <xref:System.DateTime> with a <xref:System.DateTimeKind> of <xref:System.DateTimeKind.Unspecified>. For more information about supported <xref:System.DateTime?displayProperty=nameWithType> methods, see [System.DateTime Methods](../../../../../../docs/framework/data/adonet/sql/linq/system-datetime-methods.md).  
  
### System.TimeSpan  
 Microsoft SQL Server 2008 and the .NET Framework 3.5 SP1 let you map the CLR <xref:System.TimeSpan?displayProperty=nameWithType> type to the SQL Server `TIME` type. However, there is a large difference between the range that the CLR <xref:System.TimeSpan?displayProperty=nameWithType> supports and what the SQL Server `TIME` type supports. Mapping values less than 0 or greater than 23:59:59.9999999 hours to the SQL `TIME` will result in overflow exceptions. For more information, see [System.TimeSpan Methods](../../../../../../docs/framework/data/adonet/sql/linq/system-timespan-methods.md).  
  
 In Microsoft SQL Server 2000 and SQL Server 2005, you cannot map database fields to <xref:System.TimeSpan>. However, operations on <xref:System.TimeSpan> are supported because <xref:System.TimeSpan> values can be returned from <xref:System.DateTime> subtraction or introduced into an expression as a literal or bound variable.  
  
<a name="BinaryMapping"></a>   
## Binary Mapping  
 There are many SQL Server types that can map to the CLR type <xref:System.Data.Linq.Binary?displayProperty=nameWithType>. The following table shows the SQL Server types that cause O/R Designer and SQLMetal to define a CLR <xref:System.Data.Linq.Binary?displayProperty=nameWithType> type when building an object model or external mapping file based on your database.  
  
|SQL Server Type|Default CLR Type mapping used by O/R Designer and SQLMetal|  
|---------------------|-----------------------------------------------------------------|  
|`BINARY(50)`|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
|`VARBINARY(50)`|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
|`VARBINARY(MAX)`|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
|`VARBINARY(MAX)` with the `FILESTREAM` attribute|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
|`IMAGE`|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
|`TIMESTAMP`|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|  
  
 The next table shows the default type mappings used by the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method to define which type of SQL columns are created to map to the CLR types defined in your object model or external mapping file.  
  
|CLR Type|Default SQL Server Type used by <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType>|  
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Data.Linq.Binary?displayProperty=nameWithType>|`VARBINARY(MAX)`|  
|<xref:System.Byte?displayProperty=nameWithType>|`VARBINARY(MAX)`|  
|<xref:System.Runtime.Serialization.ISerializable?displayProperty=nameWithType>|`VARBINARY(MAX)`|  
  
 There are many other binary mappings you can choose, but some may result in overflow or data loss exceptions while translating to or from the database. For more information, see the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix).  
  
### SQL Server FILESTREAM  
 The `FILESTREAM` attribute for `VARBINARY(MAX)` columns is available starting with Microsoft SQL Server 2008; you can map to it with LINQ to SQL starting with the .NET Framework version 3.5 SP1.  
  
 Although you can map `VARBINARY(MAX)` columns with the `FILESTREAM` attribute to <xref:System.Data.Linq.Binary> objects, the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method is unable to automatically create columns with the `FILESTREAM` attribute. For more information about `FILESTREAM`, see [FILESTREAM Overview](http://go.microsoft.com/fwlink/?LinkId=115291) on Microsoft SQL Server Books Online.  
  
<a name="BinarySerialization"></a>   
### Binary Serialization  
 If a class implements the <xref:System.Runtime.Serialization.ISerializable> interface, you can serialize an object to any SQL binary field (`BINARY`, `VARBINARY`, `IMAGE`). The object is serialized and deserialized according to how the <xref:System.Runtime.Serialization.ISerializable> interface is implemented. For more information, see [Binary Serialization](http://go.microsoft.com/fwlink/?LinkId=115581).  
  
<a name="MiscMapping"></a>   
## Miscellaneous Mapping  
 The following table shows the default type mappings for some miscellaneous types that have not yet been mentioned. The following table shows the CLR types that O/R Designer and SQLMetal select when building an object model or external mapping file based on your database.  
  
|SQL Server Type|Default CLR Type mapping used by O/R Designer and SQLMetal|  
|---------------------|-----------------------------------------------------------------|  
|`UNIQUEIDENTIFIER`|<xref:System.Guid?displayProperty=nameWithType>|  
|`SQL_VARIANT`|<xref:System.Object?displayProperty=nameWithType>|  
  
 The next table shows the default type mappings used by the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method to define which type of SQL columns are created to map to the CLR types defined in your object model or external mapping file.  
  
|CLR Type|Default SQL Server Type used by <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType>|  
|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Guid?displayProperty=nameWithType>|`UNIQUEIDENTIFIER`|  
|<xref:System.Object?displayProperty=nameWithType>|`SQL_VARIANT`|  
  
 LINQ to SQL does not support any other type mappings for these miscellaneous types.  For more information, see the [Type Mapping Run Time Behavior Matrix](#BehaviorMatrix).  
  
## See Also  
 [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md)  
 [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md)  
 [Data Types and Functions](../../../../../../docs/framework/data/adonet/sql/linq/data-types-and-functions.md)  
 [SQL-CLR Type Mismatches](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mismatches.md)
