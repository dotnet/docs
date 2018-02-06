---
title: "Enabling Cross-Database Access in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 10663fb6-434c-4c81-8178-ec894b9cf895
caps.latest.revision: 10
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Enabling Cross-Database Access in SQL Server
Cross-database ownership chaining occurs when a procedure in one database depends on objects in another database. A cross-database ownership chain works in the same way as ownership chaining within a single database, except that an unbroken ownership chain requires that all the object owners are mapped to the same login account. If the source object in the source database and the target objects in the target databases are owned by the same login account, SQL Server does not check permissions on the target objects.  
  
## Off By Default  
 Ownership chaining across databases is turned off by default. Microsoft recommends that you disable cross-database ownership chaining because it exposes you to the following security risks:  
  
-   Database owners and members of the `db_ddladmin` or the `db_owners` database roles can create objects that are owned by other users. These objects can potentially target objects in other databases. This means that if you enable cross-database ownership chaining, you must fully trust these users with data in all databases.  
  
-   Users with CREATE DATABASE permission can create new databases and attach existing databases. If cross-database ownership chaining is enabled, these users can access objects in other databases that they might not have privileges in from the newly created or attached databases that they create.  
  
## Enabling Cross-database Ownership Chaining  
 Cross-database ownership chaining should only be enabled in environments where you can fully trust highly-privileged users. It can be configured during setup for all databases, or selectively for specific databases using the [!INCLUDE[tsql](../../../../../includes/tsql-md.md)] commands `sp_configure` and `ALTER DATABASE`.  
  
 To selectively configure cross-database ownership chaining, use `sp_configure` to turn it off for the server. Then use the ALTER DATABASE command with SET DB_CHAINING ON to configure cross-database ownership chaining for only the databases that require it.  
  
 The following sample turns on cross-database ownership chaining for all databases:  
  
```  
EXECUTE sp_configure 'show advanced', 1;  
RECONFIGURE;  
EXECUTE sp_configure 'cross db ownership chaining', 1;  
RECONFIGURE;  
```  
  
 The following sample turns on cross-database ownership chaining for specific databases:  
  
```  
ALTER DATABASE Database1 SET DB_CHAINING ON;  
ALTER DATABASE Database2 SET DB_CHAINING ON;  
```  
  
### Dynamic SQL  
 Cross-database ownership chaining does not work in cases where dynamically created SQL statements are executed unless the same user exists in both databases. You can work around this in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] by creating a stored procedure that accesses data in another database and signing the procedure with a certificate that exists in both databases. This gives users access to the database resources used by the procedure without granting them database access or permissions.  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Extending Database Impersonation by Using EXECUTE AS](http://msdn.microsoft.com/library/ms188304\(SQL.105\).aspx) and [Cross DB Ownership Chaining Option](http://msdn.microsoft.com/library/ms188694.aspx)[!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] Books Online.|Topics describe how to configure cross-database ownership chaining for an instance of [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)  
 [Managing Permissions with Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/managing-permissions-with-stored-procedures-in-sql-server.md)  
 [Writing Secure Dynamic SQL in SQL Server](../../../../../docs/framework/data/adonet/sql/writing-secure-dynamic-sql-in-sql-server.md)  
 [Signing Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/signing-stored-procedures-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
