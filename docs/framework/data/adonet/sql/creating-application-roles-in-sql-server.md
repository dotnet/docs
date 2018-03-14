---
title: "Creating Application Roles in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 27442435-dfb2-4062-8c59-e2960833a638
caps.latest.revision: 9
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Creating Application Roles in SQL Server
Application roles provide a way to assign permissions to an application instead of a database role or user. Users can connect to the database, activate the application role, and assume the permissions granted to the application. The permissions granted to the application role are in force for the duration of the connection.  
  
> [!IMPORTANT]
>  Application roles are activated when a client application supplies an application role name and a password in the connection string. They present a security vulnerability in a two-tier application because the password must be stored on the client computer. In a three-tier application, you can store the password so that it cannot be accessed by users of the application.  
  
## Application Role Features  
 Application roles have the following features:  
  
-   Unlike database roles, application roles contain no members.  
  
-   Application roles are activated when an application supplies the application role name and a password to the `sp_setapprole` system stored procedure.  
  
-   The password must be stored on the client computer and supplied at run time; an application role cannot be activated from inside of SQL Server.  
  
-   The password is not encrypted. The parameter password is stored as a one-way hash.  
  
-   Once activated, permissions acquired through the application role remain in effect for the duration of the connection.  
  
-   The application role inherits permissions granted to the `public` role.  
  
-   If a member of the `sysadmin` fixed server role activates an application role, the security context switches to that of the application role for the duration of the connection.  
  
-   If you create a `guest` account in a database that has an application role, you do not need to create a database user account for the application role or for any of the logins that invoke it. Application roles can directly access another database only if a `guest` account exists in the second database  
  
-   Built-in functions that return login names, such as SYSTEM_USER, return the name of the login that invoked the application role. Built-in functions that return database user names return the name of the application role.  
  
### The Principle of Least Privilege  
 Application roles should be granted only required permissions in case the password is compromised. Permissions to the `public` role should be revoked in any database using an application role. Disable the `guest` account in any database you do not want callers of the application role to have access to.  
  
### Application Role Enhancements  
 The execution context can be switched back to the original caller after activating an application role, removing the need to disable connection pooling. The `sp_setapprole` procedure has a new option that creates a cookie, which contains context information about the caller. You can revert the session by calling the `sp_unsetapprole` procedure, passing it the cookie.  
  
## Application Role Alternatives  
 Application roles depend on the security of a password, which presents a potential security vulnerability. Passwords may be exposed by being embedded in application code or saved on disk.  
  
 You may want to consider the following alternatives.  
  
-   Use context switching with the EXECUTE AS statement with its NO REVERT and WITH COOKIE clauses. You can create a user account in a database that is not mapped to a login. You then assign permissions to this account. Using EXECUTE AS with a login-less user is more secure because it is permission-based, not password-based. For more information, see [Customizing Permissions with Impersonation in SQL Server](../../../../../docs/framework/data/adonet/sql/customizing-permissions-with-impersonation-in-sql-server.md).  
  
-   Sign stored procedures with certificates, granting only permission to execute the procedures. For more information, see [Signing Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/signing-stored-procedures-in-sql-server.md).  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Application Roles](http://msdn.microsoft.com/library/ms190998.aspx) in SQL Server Books Online|Describes how to create and use application roles in SQL Server 2008.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
