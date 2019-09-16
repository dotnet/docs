---
title: "Connecting to a Data Source in ADO.NET"
ms.date: "03/30/2017"
ms.assetid: 9abc3f92-1be3-4e1a-b360-762dc689650e
---
# Connecting to a Data Source in ADO.NET
In ADO.NET you use a **Connection** object to connect to a specific data source by supplying necessary authentication information in a connection string. The **Connection** object you use depends on the type of data source.  
  
 Each .NET Framework data provider included with the .NET Framework has a <xref:System.Data.Common.DbConnection> object: the .NET Framework Data Provider for OLE DB includes an <xref:System.Data.OleDb.OleDbConnection> object, the .NET Framework Data Provider for SQL Server includes a <xref:System.Data.SqlClient.SqlConnection> object, the .NET Framework Data Provider for ODBC includes an <xref:System.Data.Odbc.OdbcConnection> object, and the .NET Framework Data Provider for Oracle includes an <xref:System.Data.OracleClient.OracleConnection> object.  
  
## In This Section  
 [Establishing the Connection](establishing-the-connection.md)  
 Describes how to use a **Connection** object to establish a connection to a data source.  
  
 [Connection Events](connection-events.md)  
 Describes how to use an **InfoMessage** event to retrieve informational messages from a data source.  
  
## See also

- [Connection Strings](connection-strings.md)
- [Connection Pooling](connection-pooling.md)
- [Commands and Parameters](commands-and-parameters.md)
- [DataAdapters and DataReaders](dataadapters-and-datareaders.md)
- [Transactions and Concurrency](transactions-and-concurrency.md)
- [ADO.NET Overview](ado-net-overview.md)
