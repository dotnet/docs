---
title: "SQL Server Data Types and ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 81b43550-23e8-43bb-b460-7eb8ac825c33
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL Server Data Types and ADO.NET
SQL Server and the .NET Framework are based on different type systems, which can result in potential data loss. To preserve data integrity, the .NET Framework Data Provider for SQL Server (<xref:System.Data.SqlClient>) provides typed accessor methods for working with SQL Server data. You can use the enumerations in the <xref:System.Data.SqlDbType> classes to specify <xref:System.Data.SqlClient.SqlParameter> data types.  
  
 For more information and a table that that describes the data type mappings between SQL Server and .NET Framework data types, see [SQL Server Data Type Mappings](../../../../../docs/framework/data/adonet/sql-server-data-type-mappings.md).  
  
 SQL Server 2008 introduces new data types that are designed to meet business needs to work with date and time, structured, semi-structured, and unstructured data. These are documented in SQL Server 2008 Books Online.  
  
 The SQL Server data types that are available for use in your application depends on the version of SQL Server that you are using. For more information, see the relevant version of SQL Server Books Online in the following table.  
  
 **SQL Server Books Online**  
  
1.  [Data Types (Database Engine)](http://go.microsoft.com/fwlink/?LinkID=107468)  
  
## In This Section  
 [SqlTypes and the DataSet](../../../../../docs/framework/data/adonet/sql/sqltypes-and-the-dataset.md)  
 Describes type support for `SqlTypes` in the `DataSet`.  
  
 [Handling Null Values](../../../../../docs/framework/data/adonet/sql/handling-null-values.md)  
 Demonstrates how to work with null values and three-valued logic.  
  
 [Comparing GUID and uniqueidentifier Values](../../../../../docs/framework/data/adonet/sql/comparing-guid-and-uniqueidentifier-values.md)  
 Demonstrates how to work with GUID and uniqueidentifier values in SQL Server and the .NET Framework.  
  
 [Date and Time Data](../../../../../docs/framework/data/adonet/sql/date-and-time-data.md)  
 Describes how to use the new date and time data types introduced in SQL Server 2008.  
  
 [Large UDTs](../../../../../docs/framework/data/adonet/sql/large-udts.md)  
 Demonstrates how to retrieve data from large value UDTs introduced in SQL Server 2008.  
  
 [XML Data in SQL Server](../../../../../docs/framework/data/adonet/sql/xml-data-in-sql-server.md)  
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
  
## See Also  
 [SQL Server Data Type Mappings](../../../../../docs/framework/data/adonet/sql-server-data-type-mappings.md)  
 [Configuring Parameters and Parameter Data Types](../../../../../docs/framework/data/adonet/configuring-parameters-and-parameter-data-types.md)  
 [Table-Valued Parameters](../../../../../docs/framework/data/adonet/sql/table-valued-parameters.md)  
 [SQL Server Binary and Large-Value Data](../../../../../docs/framework/data/adonet/sql/sql-server-binary-and-large-value-data.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
