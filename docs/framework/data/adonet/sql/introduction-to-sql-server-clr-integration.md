---
title: "Introduction to SQL Server CLR Integration"
description: CLR integration with SQL Server supports stored procedures, triggers, user-defined functions, user-defined types, and user-defined aggregates in managed code.
ms.date: "03/30/2017"
ms.assetid: 551d2290-ed80-49be-b377-44b32444da1c
---
# Introduction to SQL Server CLR Integration

The common language runtime (CLR) is the heart of the Microsoft .NET Framework and provides the execution environment for all .NET Framework code. Code that runs within the CLR is referred to as managed code. The CLR provides various functions and services required for program execution, including just-in-time (JIT) compilation, allocating and managing memory, enforcing type safety, exception handling, thread management, and security.  
  
 With the CLR hosted in Microsoft SQL Server (called CLR integration), you can author stored procedures, triggers, user-defined functions, user-defined types, and user-defined aggregates in managed code. Because managed code compiles to native code prior to execution, you can achieve significant performance increases in some scenarios.  
  
 Managed code uses Code Access Security (CAS), code links, and application domains to prevent assemblies from performing certain operations. SQL Server uses CAS to help secure the managed code and prevent compromise of the operating system or database server.  
  
 This section is meant to provide only enough information to get started programming with SQL Server CLR integration, and is not meant to be comprehensive. For more detailed information, see [Common Language Runtime (CLR) Integration Overview](/sql/relational-databases/clr-integration/common-language-runtime-integration-overview).
  
## Enabling CLR Integration  

 The common language runtime (CLR) integration feature is off by default in Microsoft SQL Server, and must be enabled in order to use objects that are implemented using CLR integration. To enable CLR integration using Transact-SQL, use the `clr enabled` option of the `sp_configure` stored procedure as shown:  
  
```sql  
sp_configure 'clr enabled', 1  
GO  
RECONFIGURE  
GO  
```  
  
 You can disable CLR integration by setting the `clr enabled` option to 0. When you disable CLR integration, SQL Server stops executing all CLR routines and unloads all application domains.  
  
 For more detailed information, see [Enabling CLR Integration](/sql/relational-databases/clr-integration/clr-integration-enabling).
  
## Deploying a CLR Assembly  

 Once the CLR methods have been tested and verified on the test server, they can be distributed to production servers using a deployment script. The deployment script can be generated manually, or by using SQL Server Management Studio. For more detailed information, see the version of SQL Server documentation for the version of SQL Server you are using.  
  
 **SQL Server documentation**  
  
1. [Deploying CLR Database Objects](/sql/relational-databases/clr-integration/deploying-clr-database-objects)  
  
## CLR Integration Security  

 The security model of the Microsoft SQL Server integration with the Microsoft .NET Framework common language runtime (CLR) manages and secures access between different types of CLR and non-CLR objects running within SQL Server. These objects may be called by a Transact-SQL statement or another CLR object running in the server.  
  
 For more detailed information, see [CLR Integration Security](/sql/relational-databases/clr-integration/security/clr-integration-security).
  
## Debugging a CLR Assembly  

 Microsoft SQL Server provides support for debugging Transact-SQL and common language runtime (CLR) objects in the database. Debugging works across languages: users can step seamlessly into CLR objects from Transact-SQL, and vice versa.  
  
 For more detailed information, see [Debugging CLR Database Objects](/sql/relational-databases/clr-integration/debugging-clr-database-objects).
  
## See also

- [Code Access Security and ADO.NET](../code-access-security.md)
- [ADO.NET Overview](../ado-net-overview.md)
