---
title: "Security in LINQ to SQL"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d49787f7-414e-4c71-aa33-80a5895536b1
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Security in LINQ to SQL
Security risks are always present when you connect to a database. Although LINQ to SQL may include some new ways to work with data in SQL Server, it does not provide any additional security mechanisms.  
  
## Access Control and Authentication  
 LINQ to SQL does not have its own user model or authentication mechanisms. Use SQL Server Security to control access to the database, database tables, views, and stored procedures that are mapped to your object model. Grant the minimally required access to users and require strong passwords for user authentication.  
  
## Mapping and Schema Information  
 SQL-CLR type mapping and database schema information in your object model or external mapping file is available for all with access to those files in the file system. Assume that schema information will be available to all who can access the object model or external mapping file.To prevent more widespread access to schema information, use file security mechanisms to secure source files and mapping files.  
  
## Connection Strings  
 Using passwords in connection strings should be avoided whenever possible. Not only is a connection string a security risk in its own right, but the connection string may also be added in clear text to the object model or external mapping file when using the Object Relational Designer or SQLMetal command-line tool. Anyone with access to the object model or external mapping file via the file system could see the connection password (if it is included in the connection string).  
  
 To minimize such risks, use integrated security to make a trusted connection with [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)]. By using this approach, you do not have to store a password in the connection string. For more information, see [SQL Server Security](../../../../../../docs/framework/data/adonet/sql/sql-server-security.md).  
  
 In the absence of integrated security, a clear-text password will be needed in the connection string. The best way to help secure your connection string, in increasing order of risk, is as follows:  
  
-   Use integrated security.  
  
-   Secure connection strings with passwords and minimize passing around connection strings.  
  
-   Use a <xref:System.Data.SqlClient.SqlConnection?displayProperty=nameWithType> class instead of a connection string since it limits the duration of exposure. The LINQ to SQL <xref:System.Data.Linq.DataContext?displayProperty=nameWithType> class can be instantiated using a <xref:System.Data.SqlClient.SqlConnection>.  
  
-   Minimize lifetimes and touch points for all connection strings.  
  
## See Also  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)  
 [Frequently Asked Questions](../../../../../../docs/framework/data/adonet/sql/linq/frequently-asked-questions.md)
