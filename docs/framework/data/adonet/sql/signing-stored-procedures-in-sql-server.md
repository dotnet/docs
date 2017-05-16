---
title: "Signing Stored Procedures in SQL Server | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eeed752c-0084-48e5-9dca-381353007a0d
caps.latest.revision: 6
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# Signing Stored Procedures in SQL Server
You can sign a stored procedure with a certificate or an asymmetric key. This is designed for scenarios when permissions cannot be inherited through ownership chaining or when the ownership chain is broken, such as dynamic SQL. You then create a user mapped to the certificate, granting the certificate user permissions on the objects the stored procedure needs to access.  
  
 When the stored procedure is executed, SQL Server combines the permissions of the certificate user with those of the caller. Unlike the EXECUTE AS clause, it does not change the execution context of the procedure. Built-in functions that return login and user names return the name of the caller, not the certificate user name.  
  
 A digital signature is a data digest encrypted with the private key of the signer. The private key ensures that the digital signature is unique to its bearer or owner. You can sign stored procedures, functions, or triggers.  
  
> [!NOTE]
>  You can create a certificate in the master database to grant server-level permissions.  
  
## Creating Certificates  
 When you sign a stored procedure with a certificate, a data digest consisting of the encrypted hash of the stored procedure code is created using the private key. At run time, the data digest is decrypted with the public key and compared with the hash value of the stored procedure. Modifying the stored procedure invalidates the hash value so that the digital signature no longer matches. This prevents someone who does not have access to the private key from changing the stored procedure code. Therefore you must re-sign the procedure each time you modify it.  
  
 There are four steps involved in signing a module:  
  
1.  Create a certificate using the Transact-SQL `CREATE CERTIFICATE [certificateName]` statement. This statement has several options for setting a start and end date and a password. The default expiration date is one year  
  
2.  Create a database user associated with that certificate using the Transact-SQL `CREATE USER [userName] FROM CERTIFICATE [certificateName]` statement. This user exists in the database only and is not associated with a login.  
  
3.  Grant the certificate user the required permissions on the database objects.  
  
> [!NOTE]
>  A certificate cannot grant permissions to a user that has had permissions revoked using the DENY statement. DENY always takes precedence over GRANT, preventing the caller from inheriting permissions granted to the certificate user.  
  
1.  Sign the procedure with the certificate using the Transact-SQL `ADD SIGNATURE TO [procedureName] BY CERTIFICATE [certificateName]` statement.  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Module Signing](http://go.microsoft.com/fwlink/?LinkId=98590) in SQL Server Books Online|Describes module signing, providing a sample scenario and links to the relevant Transact-SQL topics.|  
|[Signing Stored Procedures with a Certificate](http://msdn.microsoft.com/library/bb283630.aspx) in SQL Server Books Online|Provides a tutorial for signing a stored procedure with a certificate.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)   
 [Overview of SQL Server Security](../../../../../docs/framework/data/adonet/sql/overview-of-sql-server-security.md)   
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)   
 [Managing Permissions with Stored Procedures in SQL Server](../../../../../docs/framework/data/adonet/sql/managing-permissions-with-stored-procedures-in-sql-server.md)   
 [Writing Secure Dynamic SQL in SQL Server](../../../../../docs/framework/data/adonet/sql/writing-secure-dynamic-sql-in-sql-server.md)   
 [Customizing Permissions with Impersonation in SQL Server](../../../../../docs/framework/data/adonet/sql/customizing-permissions-with-impersonation-in-sql-server.md)   
 [Modifying Data with Stored Procedures](../../../../../docs/framework/data/adonet/modifying-data-with-stored-procedures.md)   
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)