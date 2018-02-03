---
title: "Data Encryption in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 83b992f7-b351-4678-b4b9-f4ffd58134cc
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Data Encryption in SQL Server
SQL Server provides functions to encrypt and decrypt data using a certificate, asymmetric key, or symmetric key. It manages all of these in an internal certificate store. The store uses an encryption hierarchy that secures certificates and keys at one level with the layer above it in the hierarchy. This feature area of SQL Server is called Secret Storage.  
  
 The fastest mode of encryption supported by the encryption functions is symmetric key encryption. This mode is suitable for handling large volumes of data. The symmetric keys can be encrypted by certificates, passwords or other symmetric keys.  
  
## Keys and Algorithms  
 SQL Server supports several symmetric key encryption algorithms, including DES, Triple DES, RC2, RC4, 128-bit RC4, DESX, 128-bit AES, 192-bit AES, and 256-bit AES. The algorithms are implemented using the Windows Crypto API.  
  
 Within the scope of a database connection, SQL Server can maintain multiple open symmetric keys. An open key is retrieved from the store and is available for decrypting data. When a piece of data is decrypted, there is no need to specify the symmetric key to use. Each encrypted value contains the key identifier (key GUID) of the key used to encrypt it. The engine matches the encrypted byte stream to an open symmetric key, if the correct key has been decrypted and is open. This key is then used to perform decryption and return the data. If the correct key is not open, NULL is returned.  
  
 For an example that shows how to work with encrypted data in a database, see [How to: Encrypt a Column of Data](http://go.microsoft.com/fwlink/?LinkID=128559) in SQL Server Books Online.  
  
## External Resources  
 For more information on data encryption, see the following resources.  
  
|||  
|-|-|  
|[SQL Server Encryption](http://msdn.microsoft.com/library/bb510663.aspx) in SQL Server Books Online|Provides an overview of encryption in SQL Serve. This topic includes links to additional topics and how-to's.|  
|[Encryption Hierarchy](http://msdn.microsoft.com/library/ms189586.aspx) and [Encryption How-to Topics](http://msdn.microsoft.com/library/aa337557.aspx) in SQL Server Books Online|Provides an overview of encryption in SQL Server. This topic provides links to additional topics and how-to's.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [Authentication in SQL Server](../../../../../docs/framework/data/adonet/sql/authentication-in-sql-server.md)  
 [Server and Database Roles in SQL Server](../../../../../docs/framework/data/adonet/sql/server-and-database-roles-in-sql-server.md)  
 [Ownership and User-Schema Separation in SQL Server](../../../../../docs/framework/data/adonet/sql/ownership-and-user-schema-separation-in-sql-server.md)  
 [Authorization and Permissions in SQL Server](../../../../../docs/framework/data/adonet/sql/authorization-and-permissions-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
