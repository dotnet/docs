---
title: "Establishing the Connection"
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
ms.assetid: 3af512f3-87d9-4005-9e2f-abb1060ff43f
caps.latest.revision: 7
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Establishing the Connection
To connect to Microsoft SQL Server, use the <xref:System.Data.SqlClient.SqlConnection> object of the .NET Framework Data Provider for SQL Server. To connect to an OLE DB data source, use the <xref:System.Data.OleDb.OleDbConnection> object of the .NET Framework Data Provider for OLE DB. To connect to an ODBC data source, use the <xref:System.Data.Odbc.OdbcConnection> object of the .NET Framework Data Provider for ODBC. To connect to an Oracle data source, use the <xref:System.Data.OracleClient.OracleConnection> object of the .NET Framework Data Provider for Oracle. For securely storing and retrieving connection strings, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
## Closing Connections  
 We recommend that you always close the connection when you are finished using it, so that the connection can be returned to the pool. The `Using` block in Visual Basic or C# automatically disposes of the connection when the code exits the block, even in the case of an unhandled exception. See [using Statement](~/docs/csharp/language-reference/keywords/using-statement.md) and [Using Statement](~/docs/visual-basic/language-reference/statements/using-statement.md) for more information.  
  
 You can also use the `Close` or `Dispose` methods of the connection object for the provider that you are using. Connections that are not explicitly closed might not be added or returned to the pool. For example, a connection that has gone out of scope but that has not been explicitly closed will only be returned to the connection pool if the maximum pool size has been reached and the connection is still valid. For more information, see [OLE DB, ODBC, and Oracle Connection Pooling](../../../../docs/framework/data/adonet/ole-db-odbc-and-oracle-connection-pooling.md).  
  
> [!NOTE]
>  Do not call `Close` or `Dispose` on a **Connection**, a **DataReader**, or any other managed object in the `Finalize` method of your class. In a finalizer, only release unmanaged resources that your class owns directly. If your class does not own any unmanaged resources, do not include a `Finalize` method in your class definition. For more information, see [Garbage Collection](../../../../docs/standard/garbage-collection/index.md).  
  
> [!NOTE]
>  Login and logout events will not be raised on the server when a connection is fetched from or returned to the connection pool, because the connection is not actually closed when it is returned to the connection pool. For more information, see [SQL Server Connection Pooling (ADO.NET)](../../../../docs/framework/data/adonet/sql-server-connection-pooling.md).  
  
## Connecting to SQL Server  
 The .NET Framework Data Provider for SQL Server supports a connection string format that is similar to the OLE DB (ADO) connection string format. For valid string format names and values, see the <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A> property of the <xref:System.Data.SqlClient.SqlConnection> object. You can also use the <xref:System.Data.SqlClient.SqlConnectionStringBuilder> class to create syntactically valid connection strings at run time. For more information, see [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md).  
  
 The following code example demonstrates how to create and open a connection to a SQL Server database.  
  
```vb  
' Assumes connectionString is a valid connection string.  
Using connection As New SqlConnection(connectionString)  
    connection.Open()  
    ' Do work here.  
End Using  
```  
  
```csharp  
// Assumes connectionString is a valid connection string.  
using (SqlConnection connection = new SqlConnection(connectionString))  
{  
    connection.Open();  
    // Do work here.  
}  
```  
  
### Integrated Security and ASP.NET  
 SQL Server integrated security (also known as trusted connections) helps to provide protection when connecting to SQL Server as it does not expose a user ID and password in the connection string and is the recommended method for authenticating a connection. Integrated security uses the current security identity, or token, of the executing process. For desktop applications, this is typically the identity of the currently logged-on user.  
  
 The security identity for ASP.NET applications can be set to one of several different options. To better understand the security identity that an ASP.NET application uses when connecting to SQL Server, see [ASP.NET Impersonation](http://msdn.microsoft.com/library/a0cb3024-562f-4184-9d3c-095504787d3d), [ASP.NET Authentication](http://msdn.microsoft.com/library/fc10b0ef-4ce4-4a7f-9174-886325221ee1), and [How to: Access SQL Server Using Windows Integrated Security](http://msdn.microsoft.com/library/683f9c9f-4375-4de6-8111-943c4423fde5).  
  
## Connecting to an OLE DB Data Source  
 The .NET Framework Data Provider for OLE DB provides connectivity to data sources exposed using OLE DB (through SQLOLEDB, the OLE DB Provider for SQL Server), using the **OleDbConnection** object.  
  
 For the .NET Framework Data Provider for OLE DB, the connection string format is identical to the connection string format used in ADO, with the following exceptions:  
  
-   The **Provider** keyword is required.  
  
-   The **URL**, **Remote Provider**, and **Remote Server** keywords are not supported.  
  
 For more information about OLE DB connection strings, see the <xref:System.Data.OleDb.OleDbConnection.ConnectionString%2A> topic. You can also use the <xref:System.Data.OleDb.OleDbConnectionStringBuilder> to create connection strings at run time.  
  
> [!NOTE]
>  The **OleDbConnection** object does not support setting or retrieving dynamic properties specific to an OLE DB provider. Only properties that can be passed in the connection string for the OLE DB provider are supported.  
  
 The following code example demonstrates how to create and open a connection to an OLE DB data source.  
  
```vb  
' Assumes connectionString is a valid connection string.  
Using connection As New OleDbConnection(connectionString)  
    connection.Open()  
    ' Do work here.  
End Using  
```  
  
```csharp  
// Assumes connectionString is a valid connection string.  
using (OleDbConnection connection =   
  new OleDbConnection(connectionString))  
{  
    connection.Open();  
    // Do work here.  
}  
```  
  
## Do Not Use Universal Data Link Files  
 It is possible to supply connection information for an **OleDbConnection** in a Universal Data Link (UDL) file; however you should avoid doing so. UDL files are not encrypted, and expose connection string information in clear text. Because a UDL file is an external file-based resource to your application, it cannot be secured using the .NET Framework.  
  
## Connecting to an ODBC Data Source  
 The .NET Framework Data Provider for ODBC provides connectivity to data sources exposed using ODBC using the **OdbcConnection** object.  
  
 For the .NET Framework Data Provider for ODBC, the connection string format is designed to match the ODBC connection string format as closely as possible. You may also supply an ODBC data source name (DSN). For more detail on the **OdbcConnection** , see the <xref:System.Data.Odbc.OdbcConnection>.  
  
 The following code example demonstrates how to create and open a connection to an ODBC data source.  
  
```vb  
' Assumes connectionString is a valid connection string.  
Using connection As New OdbcConnection(connectionString)  
    connection.Open()  
    ' Do work here.  
End Using  
```  
  
```csharp  
// Assumes connectionString is a valid connection string.  
using (OdbcConnection connection =   
  new OdbcConnection(connectionString))  
{  
    connection.Open();  
    // Do work here.  
}  
```  
  
## Connecting to an Oracle Data Source  
 The .NET Framework Data Provider for Oracle provides connectivity to Oracle data sources using the **OracleConnection** object.  
  
 For the .NET Framework Data Provider for Oracle, the connection string format is designed to match the OLE DB Provider for Oracle (MSDAORA) connection string format as closely as possible. For more detail on the **OracleConnection**, see the <xref:System.Data.OracleClient.OracleConnection>.  
  
 The following code example demonstrates how to create and open a connection to an Oracle data source.  
  
```vb  
' Assumes connectionString is a valid connection string.  
Using connection As New OracleConnection(connectionString)  
    connection.Open()  
    ' Do work here.  
End Using  
```  
  
```csharp  
// Assumes connectionString is a valid connection string.  
using (OracleConnection connection =   
  new OracleConnection(connectionString))  
{  
    connection.Open();  
    // Do work here.  
}  
OracleConnection nwindConn = new OracleConnection("Data Source=MyOracleServer;Integrated Security=yes;");  
nwindConn.Open();  
```  
  
## See Also  
 [Connecting to a Data Source](../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 [Connection Strings](../../../../docs/framework/data/adonet/connection-strings.md)  
 [OLE DB, ODBC, and Oracle Connection Pooling](../../../../docs/framework/data/adonet/ole-db-odbc-and-oracle-connection-pooling.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
