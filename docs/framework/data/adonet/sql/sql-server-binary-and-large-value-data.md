---
description: "Learn more about: SQL Server Binary and Large-Value Data"
title: "SQL Server Binary and Large-Value Data"
ms.date: "03/30/2017"
ms.assetid: e00827b3-7511-4b2d-91d7-851ca86cc6b5
---
# SQL Server Binary and Large-Value Data

SQL Server provides the `max` specifier, which expands the storage capacity of the `varchar`, `nvarchar`, and `varbinary` data types. `varchar(max)`, `nvarchar(max)`, and `varbinary(max)` are collectively called *large-value data types*. You can use the large-value data types to store up to 2^31-1 bytes of data.  
  
 SQL Server 2008 introduces the FILESTREAM attribute, which is not a data type, but rather an attribute that can be defined on a column, allowing large-value data to be stored on the file system instead of in the database.  
  
## In This Section  

 [Modifying Large-Value (max) Data in ADO.NET](modifying-large-value-max-data.md)  
 Describes how to work with the large-value data types.  
  
 [FILESTREAM Data](filestream-data.md)  
 Describes how to work with large-value data stored in SQL Server 2008 with the FILESTREAM attribute.  
  
## See also

- [SQL Server Data Types and ADO.NET](sql-server-data-types.md)
- [SQL Server Data Operations in ADO.NET](sql-server-data-operations.md)
- [Retrieving and Modifying Data in ADO.NET](../retrieving-and-modifying-data.md)
- [ADO.NET Overview](../ado-net-overview.md)
