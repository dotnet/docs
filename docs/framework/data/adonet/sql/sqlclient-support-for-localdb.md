---
title: "SqlClient Support for LocalDB"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cf796898-5575-46f2-ae6e-21e5aa8c4123
caps.latest.revision: 14
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SqlClient Support for LocalDB
Beginning in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] code name Denali, a lightweight version of [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)], called LocalDB, will be available. This topic discusses how to connect to a LocalDB database.  
  
## Remarks  
 For more information about LocalDB, including how to install LocalDB and configure your LocalDB instance, see [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] Books Online.  
  
 To summarize what you can do with LocalDB:  
  
-   Create and start LocalDB instances with sqllocaldb.exe or your app.config file.  
  
-   Use sqlcmd.exe to add and modify databases in a LocalDB instance. For example, `sqlcmd -S (localdb)\myinst`.  
  
-   Use the `AttachDBFilename` connection string keyword to add a database to your LocalDB instance. When using `AttachDBFilename`, if you do not specify the name of the database with the `Database` connection string keyword, the database will be removed from the LocalDB instance when the application closes.  
  
-   Specify a LocalDB instance in your connection string. For example, your instance name is `myInstance`, the connection string would include:  
  
    ```  
    server=(localdb)\\myInstance  
    ```  
  
 `User Instance=True` is not allowed when connecting to a LocalDB database.  
  
 You can download LocalDB from [Microsoft SQL Server 2012 Feature Pack](http://www.microsoft.com/download/en/details.aspx?id=29065). If you will use sqlcmd.exe to modify data in your LocalDB instance, you will need sqlcmd from [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] 2012, which you can also get from the [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] 2012 Feature Pack.  
  
## Programmatically Create a Named Instance  
 An application can create a named instance and specify a database as follows:  
  
-   Specify the LocalDB instances to create in the app.config file, as follows.  The version number of the instance should be the same as the version number of your LocalDB installation.  
  
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
  
-   Specify the name of the instance using the `server` connection string keyword.  The instance name specified in the `server` connection string keyword must match the name specified in the app.config file.  
  
-   Use the `AttachDBFilename` connection string keyword to specify the .MDF file.  
  
## See Also  
 [SQL Server Features and ADO.NET](../../../../../docs/framework/data/adonet/sql/sql-server-features-and-adonet.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
