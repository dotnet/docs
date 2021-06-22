---
description: "Learn more about: SQL Server Data Types and ADO.NET"
title: "SQL Server Data Types and ADO.NET"
titleSuffix: ""
ms.date: "03/30/2017"
ms.assetid: 81b43550-23e8-43bb-b460-7eb8ac825c33
---
# SQL Server Data Types and ADO.NET

SQL Server and the .NET Framework are based on different type systems, which can result in potential data loss. To preserve data integrity, the .NET Framework Data Provider for SQL Server (<xref:System.Data.SqlClient>) provides typed accessor methods for working with SQL Server data. You can use the enumerations in the <xref:System.Data.SqlDbType> classes to specify <xref:System.Data.SqlClient.SqlParameter> data types.  
  
 For more information and a table that describes the data type mappings between SQL Server and .NET Framework data types, see [SQL Server Data Type Mappings](../sql-server-data-type-mappings.md).  
  
 SQL Server 2008 introduces new data types that are designed to meet business needs to work with date and time, structured, semi-structured, and unstructured data. These are documented in SQL Server 2008 Books Online.  
  
 The SQL Server data types that are available for use in your application depends on the version of SQL Server that you are using. For more information, see [Data Types (Transact-SQL)](/sql/t-sql/data-types/data-types-transact-sql).
  
## In This Section  

 [SqlTypes and the DataSet](sqltypes-and-the-dataset.md)  
 Describes type support for `SqlTypes` in the `DataSet`.  
  
 [Handling Null Values](handling-null-values.md)  
 Demonstrates how to work with null values and three-valued logic.  
  
 [Comparing GUID and uniqueidentifier Values](comparing-guid-and-uniqueidentifier-values.md)  
 Demonstrates how to work with GUID and uniqueidentifier values in SQL Server and the .NET Framework.  
  
 [Date and Time Data](date-and-time-data.md)  
 Describes how to use the new date and time data types introduced in SQL Server 2008.  
  
 [Large UDTs](large-udts.md)  
 Demonstrates how to retrieve data from large value UDTs introduced in SQL Server 2008.  
  
 [XML Data in SQL Server](xml-data-in-sql-server.md)  
 Describes how to work with XML data retrieved from SQL Server.  
  
## Reference  

 <xref:System.Data.DataSet>  
 Describes the `DataSet` class and all of its members.  
  
 <xref:System.Data.SqlTypes>  
 Describes the `SqlTypes` namespace and all of its members.  
  
 <xref:System.Data.SqlDbType>  
 Describes the `SqlDbType` enumeration and all of its members.  
  
 <xref:System.Data.DbType>  
 Describes the `DbType` enumeration and all of its members.  
  
## See also

- [SQL Server Data Type Mappings](../sql-server-data-type-mappings.md)
- [Configuring Parameters and Parameter Data Types](../configuring-parameters-and-parameter-data-types.md)
- [Table-Valued Parameters](table-valued-parameters.md)
- [SQL Server Binary and Large-Value Data](sql-server-binary-and-large-value-data.md)
- [ADO.NET Overview](../ado-net-overview.md)
