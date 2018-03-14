---
title: "Customizing Permissions with Impersonation in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dc733d09-1d6d-4af0-9c4b-8d24504860f1
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Customizing Permissions with Impersonation in SQL Server
Many applications use stored procedures to access data, relying on ownership chaining to restrict access to base tables. You can grant EXECUTE permissions on stored procedures, revoking or denying permissions on the base tables. SQL Server does not check the permissions of the caller if the stored procedure and tables have the same owner. However, ownership chaining doesn't work if objects have different owners or in the case of dynamic SQL.  
  
 You can use the EXECUTE AS clause in a stored procedure when the caller doesn't have permissions on the referenced database objects. The effect of the EXECUTE AS clause is that the execution context is switched to the proxy user. All code, as well as any calls to nested stored procedures or triggers, executes under the security context of the proxy user. Execution context is reverted to the original caller only after execution of the procedure or when a REVERT statement is issued.  
  
## Context Switching with the EXECUTE AS Statement  
 The Transact-SQL EXECUTE AS statement allows you to switch the execution context of a statement by impersonating another login or database user. This is a useful technique for testing queries and procedures as another user.  
  
```  
EXECUTE AS LOGIN = 'loginName';  
EXECUTE AS USER = 'userName';  
```  
  
 You must have IMPERSONATE permissions on the login or user you are impersonating. This permission is implied for `sysadmin` for all databases, and `db_owner` role members in databases that they own.  
  
## Granting Permissions with the EXECUTE AS Clause  
 You can use the EXECUTE AS clause in the definition header of a stored procedure, trigger, or user-defined function (except for inline table-valued functions). This causes the procedure to execute in the context of the user name or keyword specified in the EXECUTE AS clause. You can create a proxy user in the database that is not mapped to a login, granting it only the necessary permissions on the objects accessed by the procedure. Only the proxy user specified in the EXECUTE AS clause must have permissions on all objects accessed by the module.  
  
> [!NOTE]
>  Some actions, such as TRUNCATE TABLE, do not have grantable permissions. By incorporating the statement within a procedure and specifying a proxy user who has ALTER TABLE permissions, you can extend the permissions to truncate the table to callers who have only EXECUTE permissions on the procedure.  
  
 The context specified in the EXECUTE AS clause is valid for the duration of the procedure, including nested procedures and triggers. Context reverts to the caller when execution is complete or the REVERT statement is issued.  
  
 There are three steps involved in using the EXECUTE AS clause in a procedure.  
  
1.  Create a proxy user in the database that is not mapped to a login. This is not required, but it helps when managing permissions.  
  
```  
CREATE USER proxyUser WITHOUT LOGIN  
```  
  
1.  Grant the proxy user the necessary permissions.  
  
2.  Add the EXECUTE AS clause to the stored procedure or user-defined function.  
  
```  
CREATE PROCEDURE [procName] WITH EXECUTE AS 'proxyUser' AS ...  
```  
  
> [!NOTE]
>  Applications that require auditing can break because the original security context of the caller is not retained. Built-in functions that return the identity of the current user, such as SESSION_USER, USER, or USER_NAME, return the user associated with the EXECUTE AS clause, not the original caller.  
  
### Using EXECUTE AS with REVERT  
 You can use the Transact-SQL REVERT statement to revert to the original execution context.  
  
 The optional clause, WITH NO REVERT COOKIE = @variableName, allows you switch the execution context back to the caller if the @variableName variable contains the correct value. This allows you to switch the execution context back to the caller in environments where connection pooling is used. Because the value of @variableName is known only to the caller of the EXECUTE AS statement, the caller can guarantee that the execution context cannot be changed by the end user that invokes the application. When the connection is closed, it is returned to the pool. For more information on connection pooling in ADO.NET, see [SQL Server Connection Pooling (ADO.NET)](../../../../../docs/framework/data/adonet/sql-server-connection-pooling.md).  
  
### Specifying the Execution Context  
 In addition to specifying a user, you can also use EXECUTE AS with any of the following keywords.  
  
-   CALLER. Executing as CALLER is the default; if no other option is specified, then the procedure executes in the security context of the caller.  
  
-   OWNER. Executing as OWNER executes the procedure in the context of the procedure owner. If the procedure is created in a schema owned by `dbo` or the database owner, the procedure will execute with unrestricted permissions.  
  
-   SELF. Executing as SELF executes in the security context of the creator of the stored procedure. This is equivalent to executing as a specified user, where the specified user is the person creating or altering the procedure.  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Context Switching](http://msdn.microsoft.com/library/ms188268.aspx) in SQL Server Books Online|Contains links to topics describing how to use the EXECUTE AS clause.|  
|[Using EXECUTE AS to Create Custom Permission Sets](http://msdn.microsoft.com/library/ms190384.aspx) and [Using EXECUTE AS in Modules](http://msdn.microsoft.com/library/ms178106.aspx) in SQL Server Books Online|Topics describe how to use the EXECUTE AS clause.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [Managing Permissions with Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/managing-permissions-with-stored-procedures-in-sql-server.md)  
 [Writing Secure Dynamic SQL in SQL Server](../../../../../docs/framework/data/adonet/sql/writing-secure-dynamic-sql-in-sql-server.md)  
 [Signing Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/signing-stored-procedures-in-sql-server.md)  
 [Modifying Data with Stored Procedures](../../../../../docs/framework/data/adonet/modifying-data-with-stored-procedures.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
