---
title: "Data Type Mappings in ADO.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d4afab94-ada6-4c77-a73c-41f17bae6b5a
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Data Type Mappings in ADO.NET
The .NET Framework is based on the common type system, which defines how types are declared, used, and managed in the runtime. It consists of both value types and reference types, which all derive from the <xref:System.Object> base type. When working with a data source, the data type is inferred from the data provider if it is not explicitly specified. For example, a <xref:System.Data.DataSet> object is independent of any specific data source. Data in a `DataSet` is retrieved from a data source, and changes are persisted back to the data source by using a `DataAdapter`. This means that when a `DataAdapter` fills a <xref:System.Data.DataTable> in a `DataSet` with values from a data source, the resulting data types of the columns in the `DataTable` are [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types, instead of types specific to the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider that is used to connect to the data source.  
  
 Likewise, when a `DataReader` returns a value from a data source, the resulting value is stored in a local variable that has a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type. For both the `Fill` operations of the `DataAdapter` and the `Get` methods of the `DataReader`, the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type is inferred from the value returned from the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider.  
  
 Instead of relying on the inferred data type, you can use the typed accessor methods of the `DataReader` when you know the specific type of the value being returned. Typed accessor methods give you better performance by returning a value as a specific [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type, which eliminates the need for additional type conversion.  
  
> [!NOTE]
>  Null values for [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider data types are represented by `DBNull.Value`.  
  
## In This Section  
 [SQL Server Data Type Mappings](../../../../docs/framework/data/adonet/sql-server-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.SqlClient>.  
  
 [OLE DB Data Type Mappings](../../../../docs/framework/data/adonet/ole-db-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.OleDb>.  
  
 [ODBC Data Type Mappings](../../../../docs/framework/data/adonet/odbc-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.Odbc>.  
  
 [Oracle Data Type Mappings](../../../../docs/framework/data/adonet/oracle-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.OracleClient>.  
  
 [Floating-Point Numbers](../../../../docs/framework/data/adonet/floating-point-numbers.md)  
 Describes issues that developers frequently encounter when working with floating-point numbers.  
  
## See Also  
 [SQL Server Data Types and ADO.NET](../../../../docs/framework/data/adonet/sql/sql-server-data-types.md)  
 [Configuring Parameters and Parameter Data Types](../../../../docs/framework/data/adonet/configuring-parameters-and-parameter-data-types.md)  
 [Retrieving Database Schema Information](../../../../docs/framework/data/adonet/retrieving-database-schema-information.md)  
 [Common Type System](../../../../docs/standard/base-types/common-type-system.md)  
 [Converting Types](http://msdn.microsoft.com/library/6038316e-bdaf-4f55-8006-407f591ce156)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
