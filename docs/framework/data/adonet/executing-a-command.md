---
title: "Executing a Command"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 40494916-c25a-4cb8-8f7c-fcb8d378464e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Executing a Command
Each .NET Framework data provider included with the .NET Framework has its own command object that inherits from <xref:System.Data.Common.DbCommand>. The .NET Framework Data Provider for OLE DB includes an <xref:System.Data.OleDb.OleDbCommand> object, the .NET Framework Data Provider for SQL Server includes a <xref:System.Data.SqlClient.SqlCommand> object, the .NET Framework Data Provider for ODBC includes an <xref:System.Data.Odbc.OdbcCommand> object, and the .NET Framework Data Provider for Oracle includes an <xref:System.Data.OracleClient.OracleCommand> object. Each of these objects exposes methods for executing commands based on the type of command and desired return value, as described in the following table.  
  
|Command|Return Value|  
|-------------|------------------|  
|`ExecuteReader`|Returns a `DataReader` object.|  
|`ExecuteScalar`|Returns a single scalar value.|  
|`ExecuteNonQuery`|Executes a command that does not return any rows.|  
|`ExecuteXMLReader`|Returns an <xref:System.Xml.XmlReader>. Available for a `SqlCommand` object only.|  
  
 Each strongly typed command object also supports a <xref:System.Data.CommandType> enumeration that specifies how a command string is interpreted, as described in the following table.  
  
|CommandType|Description|  
|-----------------|-----------------|  
|`Text`|An SQL command defining the statements to be executed at the data source.|  
|`StoredProcedure`|The name of the stored procedure. You can use the `Parameters` property of a command to access input and output parameters and return values, regardless of which `Execute` method is called. When using `ExecuteReader`, return values and output parameters will not be accessible until the `DataReader` is closed.|  
|`TableDirect`|The name of a table.|  
  
## Example  
 The following code example demonstrates how to create a <xref:System.Data.SqlClient.SqlCommand> object to execute a stored procedure by setting its properties. A <xref:System.Data.SqlClient.SqlParameter> object is used to specify the input parameter to the stored procedure. The command is executed using the <xref:System.Data.SqlClient.SqlCommand.ExecuteReader%2A> method, and the output from the <xref:System.Data.SqlClient.SqlDataReader> is displayed in the console window.  
  
 [!code-csharp[DataWorks SqlClient.StoredProcedure#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlClient.StoredProcedure/CS/source.cs#1)]
 [!code-vb[DataWorks SqlClient.StoredProcedure#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlClient.StoredProcedure/VB/source.vb#1)]  
  
### Troubleshooting Commands  
 The .NET Framework Data Provider for SQL Server adds performance counters to enable you to detect intermittent problems related to failed command executions. For more information see [Performance Counters](../../../../docs/framework/data/adonet/performance-counters.md).  
  
## See Also  
 [Commands and Parameters](../../../../docs/framework/data/adonet/commands-and-parameters.md)  
 [DataAdapters and DataReaders](../../../../docs/framework/data/adonet/dataadapters-and-datareaders.md)  
 [Working with DataReaders](http://msdn.microsoft.com/library/126a966a-d08d-4d22-a19f-f432908b2b54)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
