---
description: "Learn more about: SqlClient Support for LocalDB"
title: "SqlClient Support for LocalDB"
ms.date: "03/30/2017"
ms.assetid: cf796898-5575-46f2-ae6e-21e5aa8c4123
---
# SqlClient Support for LocalDB

This article discusses how to connect to a LocalDB database. LocalDB is a lightweight version of SQL Server.
  
## Remarks
  
 To summarize what you can do with LocalDB:  
  
- Create and start LocalDB instances with sqllocaldb.exe or your app.config file.  
  
- Use sqlcmd.exe to add and modify databases in a LocalDB instance. For example, `sqlcmd -S (localdb)\myinst`.  
  
- Use the `AttachDBFilename` connection string keyword to add a database to your LocalDB instance. When using `AttachDBFilename`, if you do not specify the name of the database with the `Database` connection string keyword, the database will be removed from the LocalDB instance when the application closes.  
  
- Specify a LocalDB instance in your connection string. For example, your instance name is `myInstance`, the connection string would include:  
  
    `server=(localdb)\\myInstance`  
  
 `User Instance=True` is not allowed when connecting to a LocalDB database.  
  
For information about installing LocalDB, see [SQL Server Express LocalDB](/sql/database-engine/configure-windows/sql-server-express-localdb).
  
## Programmatically Create a Named Instance  

 An application can create a named instance and specify a database as follows:  
  
- Specify the LocalDB instances to create in the app.config file, as follows.  The version number of the instance should be the same as the version number of your LocalDB installation.  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
      <configSections>  
        <section  
        name="system.data.localdb"  
        type="System.Data.LocalDBConfigurationSection,System.Data,Version=4.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089"/>  
      </configSections>  
      <system.data.localdb>  
        <localdbinstances>  
          <add name="myInstance" version="11.0" />  
        </localdbinstances>  
      </system.data.localdb>  
    </configuration>  
    ```  
  
- Specify the name of the instance using the `server` connection string keyword.  The instance name specified in the `server` connection string keyword must match the name specified in the app.config file.  
  
- Use the `AttachDBFilename` connection string keyword to specify the .MDF file.  
  
## See also

- [SQL Server Features and ADO.NET](sql-server-features-and-adonet.md)
- [ADO.NET Overview](../ado-net-overview.md)
