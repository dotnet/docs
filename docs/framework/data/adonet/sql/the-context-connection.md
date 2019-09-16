---
title: "The Context Connection"
ms.date: "03/30/2017"
ms.assetid: e443ca86-9243-4234-a822-ed10a53a9de0
---
# The Context Connection
The problem of internal data access is a fairly common scenario. That is, you wish to access the same server on which your common language runtime (CLR) stored procedure or function is executing. One option is to create a connection using <xref:System.Data.SqlClient.SqlConnection>, specify a connection string that points to the local server, and open the connection. This requires specifying credentials for logging in. The connection is in a different database session than the stored procedure or function, it may have different `SET` options, it is in a separate transaction, it does not see your temporary tables, and so on. If your managed stored procedure or function code is executing in the SQL Server process, it is because someone connected to that server and executed a SQL statement to invoke it. You probably want the stored procedure or function to execute in the context of that connection, along with its transaction, `SET` options, and so on. This is called the context connection.  
  
 The context connection lets you execute Transact-SQL statements in the same context that your code was invoked in the first place. For more detailed information, see the version of SQL Server Books Online for the version of SQL Server you are using.  
  
 **SQL Server Books Online**  
  
1. [The Context Connection](https://go.microsoft.com/fwlink/?LinkId=115395)  
  
## See also

- [ADO.NET Overview](../ado-net-overview.md)
