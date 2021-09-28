---
description: "Learn more about: Data Type Mappings in ADO.NET"
title: "Data Type Mappings"
ms.date: "03/30/2017"
ms.assetid: d4afab94-ada6-4c77-a73c-41f17bae6b5a
---
# Data Type Mappings in ADO.NET

The .NET Framework is based on the common type system, which defines how types are declared, used, and managed in the runtime. It consists of both value types and reference types, which all derive from the <xref:System.Object> base type. When working with a data source, the data type is inferred from the data provider if it is not explicitly specified. For example, a <xref:System.Data.DataSet> object is independent of any specific data source. Data in a `DataSet` is retrieved from a data source, and changes are persisted back to the data source by using a `DataAdapter`. This means that when a `DataAdapter` fills a <xref:System.Data.DataTable> in a `DataSet` with values from a data source, the resulting data types of the columns in the `DataTable` are .NET Framework types, instead of types specific to the .NET Framework data provider that is used to connect to the data source.  
  
 Likewise, when a `DataReader` returns a value from a data source, the resulting value is stored in a local variable that has a .NET Framework type. For both the `Fill` operations of the `DataAdapter` and the `Get` methods of the `DataReader`, the .NET Framework type is inferred from the value returned from the .NET Framework data provider.  
  
 Instead of relying on the inferred data type, you can use the typed accessor methods of the `DataReader` when you know the specific type of the value being returned. Typed accessor methods give you better performance by returning a value as a specific .NET Framework type, which eliminates the need for additional type conversion.  
  
> [!NOTE]
> Null values for .NET Framework data provider data types are represented by `DBNull.Value`.  
  
## In This Section  

 [SQL Server Data Type Mappings](sql-server-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.SqlClient>.  
  
 [OLE DB Data Type Mappings](ole-db-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.OleDb>.  
  
 [ODBC Data Type Mappings](odbc-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.Odbc>.  
  
 [Oracle Data Type Mappings](oracle-data-type-mappings.md)  
 Lists inferred data type mappings and data accessor methods for <xref:System.Data.OracleClient>.  
  
 [Floating-Point Numbers](floating-point-numbers.md)  
 Describes issues that developers frequently encounter when working with floating-point numbers.  
  
## See also

- [SQL Server Data Types and ADO.NET](./sql/sql-server-data-types.md)
- [Configuring Parameters and Parameter Data Types](configuring-parameters-and-parameter-data-types.md)
- [Retrieving Database Schema Information](retrieving-database-schema-information.md)
- [Common Type System](../../../standard/base-types/common-type-system.md)
- [Converting Types](/previous-versions/visualstudio/visual-studio-2008/t8s7t9bf(v=vs.90))
- [ADO.NET Overview](ado-net-overview.md)
