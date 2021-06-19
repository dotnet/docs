---
title: "Overview of SQL Server Security"
description: Learn about the SQL Server security architecture to understand which features and functionality counter known threats, and to anticipate future threats.
ms.date: "03/30/2017"
ms.assetid: ae66dd75-5c16-4cc0-9e12-774dd26d3fb9
---
# Overview of SQL Server Security

A defense-in-depth strategy, with overlapping layers of security, is the best way to counter security threats. SQL Server provides a security architecture that is designed to allow database administrators and developers to create secure database applications and counter threats. Each version of SQL Server has improved on previous versions of SQL Server with the introduction of new features and functionality. However, security does not ship in the box. Each application is unique in its security requirements. Developers need to understand which combination of features and functionality are most appropriate to counter known threats, and to anticipate threats that may arise in the future.  
  
 A SQL Server instance contains a hierarchical collection of entities, starting with the server. Each server contains multiple databases, and each database contains a collection of securable objects. Every SQL Server securable has associated *permissions* that can be granted to a *principal*, which is an individual, group or process granted access to SQL Server. The SQL Server security framework manages access to securable entities through *authentication* and *authorization*.  
  
- Authentication is the process of logging on to SQL Server by which a principal requests access by submitting credentials that the server evaluates. Authentication establishes the identity of the user or process being authenticated.  
  
- Authorization is the process of determining which securable resources a principal can access, and which operations are allowed for those resources.  
  
 The topics in this section cover SQL Server security fundamentals, providing links to the complete documentation in the SQL Server docs.
  
## In This Section  

 [Authentication in SQL Server](authentication-in-sql-server.md)  
 Describes logins and authentication in SQL Server and provides links to additional resources.  
  
 [Server and Database Roles in SQL Server](server-and-database-roles-in-sql-server.md)  
 Describes fixed server and database roles, custom database roles, and built-in accounts and provides links to additional resources.  
  
 [Ownership and User-Schema Separation in SQL Server](ownership-and-user-schema-separation-in-sql-server.md)  
 Describes object ownership and  user-schema separation and provides links to additional resources.  
  
 [Authorization and Permissions in SQL Server](authorization-and-permissions-in-sql-server.md)  
 Describes granting permissions using the principle of least privilege and provides links to additional resources.  
  
 [Data Encryption in SQL Server](data-encryption-in-sql-server.md)  
 Describes data encryption options in SQL Server and provides links to additional resources.  
  
 [CLR Integration Security in SQL Server](clr-integration-security-in-sql-server.md)  
 Provides links to CLR integration security resources.  
  
## See also

- [Securing ADO.NET Applications](../securing-ado-net-applications.md)
- [SQL Server Security](sql-server-security.md)
- [Application Security Scenarios in SQL Server](application-security-scenarios-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
