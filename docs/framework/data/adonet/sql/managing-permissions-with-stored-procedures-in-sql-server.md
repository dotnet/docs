---
title: "Managing Permissions with Stored Procedures in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 08fa34e8-2ffa-470d-ba62-e511a5f8558e
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Managing Permissions with Stored Procedures in SQL Server
One method of creating multiple lines of defense around your database is to implement all data access using stored procedures or user-defined functions. You revoke or deny all permissions to underlying objects, such as tables, and grant EXECUTE permissions on stored procedures. This effectively creates a security perimeter around your data and database objects.  
  
## Stored Procedure Benefits  
 Stored procedures have the following benefits:  
  
-   Data logic and business rules can be encapsulated so that users can access data and objects only in ways that developers and database administrators intend.  
  
-   Parameterized stored procedures that validate all user input can be used to thwart SQL injection attacks. If you use dynamic SQL, be sure to parameterize your commands, and never include parameter values directly into a query string.  
  
-   Ad hoc queries and data modifications can be disallowed. This prevents users from maliciously or inadvertently destroying data or executing queries that impair performance on the server or the network.  
  
-   Errors can be handled in procedure code without being passed directly to client applications. This prevents error messages from being returned that could aid in a probing attack. Log errors and handle them on the server.  
  
-   Stored procedures can be written once, and accessed by many applications.  
  
-   Client applications do not need to know anything about the underlying data structures. Stored procedure code can be changed without requiring changes in client applications as long as the changes do not affect parameter lists or returned data types.  
  
-   Stored procedures can reduce network traffic by combining multiple operations into one procedure call.  
  
## Stored Procedure Execution  
 Stored procedures take advantage of ownership chaining to provide access to data so that users do not need to have explicit permission to access database objects. An ownership chain exists when objects that access each other sequentially are owned by the same user. For example, a stored procedure can call other stored procedures, or a stored procedure can access multiple tables. If all objects in the chain of execution have the same owner, then SQL Server only checks the EXECUTE permission for the caller, not the caller's permissions on other objects. Therefore you need to grant only EXECUTE permissions on stored procedures; you can revoke or deny all permissions on the underlying tables.  
  
## Best Practices  
 Simply writing stored procedures isn't enough to adequately secure your application. You should also consider the following potential security holes.  
  
-   Grant EXECUTE permissions on the stored procedures for database roles you want to be able to access the data.  
  
-   Revoke or deny all permissions to the underlying tables for all roles and users in the database, including the `public` role. All users inherit permissions from public. Therefore denying permissions to `public` means that only owners and `sysadmin` members have access; all other users will be unable to inherit permissions from membership in other roles.  
  
-   Do not add users or roles to the `sysadmin` or `db_owner` roles. System administrators and database owners can access all database objects.  
  
-   Disable the `guest` account. This will prevent anonymous users from connecting to the database. The guest account is disabled by default in new databases.  
  
-   Implement error handling and log errors.  
  
-   Create parameterized stored procedures that validate all user input. Treat all user input as untrusted.  
  
-   Avoid dynamic SQL unless absolutely necessary. Use the Transact-SQL QUOTENAME() function to delimit a string value and escape any occurrence of the delimiter in the input string.  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Stored Procedures](http://msdn.microsoft.com/library/ms190782.aspx) and [SQL Injection](http://go.microsoft.com/fwlink/?LinkId=98234) in SQL Server Books Online|Topics describe how to create stored procedures and how SQL Injection works.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [Writing Secure Dynamic SQL in SQL Server](../../../../../docs/framework/data/adonet/sql/writing-secure-dynamic-sql-in-sql-server.md)  
 [Signing Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/signing-stored-procedures-in-sql-server.md)  
 [Customizing Permissions with Impersonation in SQL Server](../../../../../docs/framework/data/adonet/sql/customizing-permissions-with-impersonation-in-sql-server.md)  
 [Modifying Data with Stored Procedures](../../../../../docs/framework/data/adonet/modifying-data-with-stored-procedures.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
