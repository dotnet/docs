---
description: "Learn more about: SqlClient Support for LocalDB"
title: "SqlClient Support for LocalDB"
ms.date: "10/23/2026"
ai-usage: ai-assisted
ms.assetid: cf796898-5575-46f2-ae6e-21e5aa8c4123
---
# SqlClient Support for LocalDB

Use the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package to connect to LocalDB, a lightweight version of SQL Server available on Windows. Use Windows integrated authentication for the examples in this article.
  
## Remarks
  
 To summarize what you can do with LocalDB:  
  
- Create and start LocalDB instances with `SqlLocalDB.exe`.
  
- Use sqlcmd.exe to add and modify databases in a LocalDB instance. For example, `sqlcmd -S (localdb)\myinst`.  
  
- Use the `AttachDBFilename` connection string keyword to add a database to your LocalDB instance. When using `AttachDBFilename`, if you do not specify the name of the database with the `Database` connection string keyword, the database will be removed from the LocalDB instance when the application closes.  
  
- Specify a LocalDB instance in your connection string. For example, your instance name is `myInstance`, the connection string would include:  
  
    `Server=(localdb)\myInstance;Database=<database>;Integrated Security=true;Encrypt=true`
  
 `User Instance=True` is not allowed when connecting to a LocalDB database.  
  
For information about installing LocalDB, see [SQL Server Express LocalDB](/sql/database-engine/configure-windows/sql-server-express-localdb).
  
## Programmatically Create a Named Instance  

Microsoft.Data.SqlClient on modern .NET doesn't use the .NET Framework `system.data.localdb` configuration section. Create and start the instance before your application opens a connection:

```console
SqlLocalDB.exe create myInstance
SqlLocalDB.exe start myInstance
```

Specify the same instance name in the `Server` connection-string keyword. To attach an existing database file, set `AttachDBFilename` to the file's full path and set `Database` to the database name.

For local development with a LocalDB instance that doesn't have a trusted server certificate, use `Encrypt=true;TrustServerCertificate=true`. This setting encrypts the connection but skips server certificate validation. For remote production connections, use `Encrypt=true;TrustServerCertificate=false` and configure a server certificate that the client trusts and that matches the server name. For more information, see [Encryption and certificate validation in Microsoft.Data.SqlClient](/sql/connect/ado-net/encryption-and-certificate-validation).
  
## See also

- [SQL Server Features and ADO.NET](sql-server-features-and-adonet.md)
- [ADO.NET Overview](../ado-net-overview.md)
