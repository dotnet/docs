---
title: "Granting Row-Level Permissions in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a55aaa12-34ab-41cd-9dec-fd255b29258c
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Granting Row-Level Permissions in SQL Server
In some scenarios, there is a requirement to control access to data at a more granular level than what simply granting, revoking, or denying permissions provides. For example, a hospital database application may require individual Doctors to be restricted to accessing information related to only their patients. Similar requirements exist in many environments, including finance, law, government, and military applications. To help address these scenarios, SQL Server 2016 provides a [Row-Level Security](https://msdn.microsoft.com/library/dn765131.aspx) feature that simplifies and centralizes row-level access logic in a security policy. For earlier versions of SQL Server, similar functionality can be achieved by using views to enact row-level filtering.  
  
## Implementing Row-level Filtering  
 Row-level filtering is used for applications storing information in a single table like in the hospital example above. To implement row-level filtering each row has a column that defines a differentiating parameter, such as a user name, label or other identifier. You create either a security policy or a view on the table, which filters the rows that the user can access. You then create parameterized stored procedures, which control the types of queries the user can execute.  
  
 The following example describes how to configure row-level filtering based on a user or login name:  
  
-   Create the table, adding a column to store the name.  
  
-   Enable row-level filtering:  
  
    -   If you are using SQL Server 2016 or higher, or [Azure SQL Database](https://docs.microsoft.com/azure/sql-database/), create a security policy that adds a predicate on the table restricting the rows returned to those that match either the current database user (using the CURRENT_USER() built-in function) or the current login name (using the SUSER_SNAME() built-in function):  
  
        ```tsql  
        CREATE SCHEMA Security  
        GO  
  
        CREATE FUNCTION Security.userAccessPredicate(@UserName sysname)  
        	RETURNS TABLE  
        	WITH SCHEMABINDING  
        AS  
        	RETURN SELECT 1 AS accessResult  
        	WHERE @UserName = SUSER_SNAME()  
        GO  
  
        CREATE SECURITY POLICY Security.userAccessPolicy  
        	ADD FILTER PREDICATE Security.userAccessPredicate(UserName) ON dbo.MyTable,  
        	ADD BLOCK PREDICATE Security.userAccessPredicate(UserName) ON dbo.MyTable  
        GO  
        ```  
  
    -   If you are using a version of SQL Server prior to 2016, you can achieve similar functionality using a view:  
  
        ```tsql  
        CREATE VIEW vw_MyTable  
        AS  
        	RETURN SELECT * FROM MyTable  
        	WHERE UserName = SUSER_SNAME()  
        GO  
        ```  
  
-   Create stored procedures to select, insert, update, and delete data. If the filtering is enacted by a security policy, the stored procedures should perform these operations on the base table directly; otherwise, if the filtering is enacted by a view, the stored procedures should instead operate against the view. The security policy or view will automatically filter the rows returned or modified by user queries, and the stored procedure will provide a harder security boundary to prevent users with direct query access from successfully running queries that can infer the existence of filtered data.  
  
-   For stored procedures that insert data, capture the user name using the same function specified in the security policy or view, and insert that value into the UserName column.  
  
-   Deny all permissions on the tables (and views, if applicable) to the `public` role. Users will not be able to inherit permissions from other database roles, because the filter predicate is based on user or login names, not on roles.  
  
-   Grant EXECUTE on the stored procedures to database roles. Users can only access data through the stored procedures provided.  
  
## External Resources  
 For more information, see the following resource.  
  
|||  
|-|-|  
|[Implementing Row- and Cell-Level Security in Classified Databases Using SQL Server 2005](http://go.microsoft.com/fwlink/?LinkId=98227) on the SQL Server TechCenter site.|Describes how to use row- and cell-level security to meet classified database security requirements.|  
  
## See Also  
 [Row-Level Security](https://msdn.microsoft.com/library/dn765131.aspx)  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [Managing Permissions with Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/managing-permissions-with-stored-procedures-in-sql-server.md)  
 [Writing Secure Dynamic SQL in SQL Server](../../../../../docs/framework/data/adonet/sql/writing-secure-dynamic-sql-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
