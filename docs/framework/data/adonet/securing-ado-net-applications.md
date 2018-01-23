---
title: "Securing ADO.NET Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 005a1d43-6ee5-471e-ad98-1d30a44d49d5
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Securing ADO.NET Applications
Writing a secure ADO.NET application involves more than avoiding common coding pitfalls such as not validating user input. An application that accesses data has many potential points of failure that an attacker can exploit to retrieve, manipulate, or destroy sensitive data. It is therefore important to understand all aspects of security, from the process of threat modeling during the design phase of your application, to its eventual deployment and ongoing maintenance.  
  
 The .NET Framework provides many useful classes, services, and tools for securing and administering database applications. The common language runtime (CLR) provides a type-safe environment for code to run in, with code access security (CAS) to restrict further the permissions of managed code. Following secure data access coding practices limits the damage that can be inflicted by a potential attacker.  
  
 Writing secure code does not guard against self-inflicted security holes when working with unmanaged resources such as databases. Most server databases, such as SQL Server, have their own security systems, which enhance security when implemented correctly. However, even a data source with a robust security system can be victimized in an attack if it is not configured appropriately.  
  
## In This Section  
 [Security Overview](../../../../docs/framework/data/adonet/security-overview.md)  
 Provides recommendations for designing secure ADO.NET applications.  
  
 [Secure Data Access](../../../../docs/framework/data/adonet/secure-data-access.md)  
 Describes how to work with data from a secured data source.  
  
 [Secure Client Applications](../../../../docs/framework/data/adonet/secure-client-applications.md)  
 Describes security considerations for client applications.  
  
 [Code Access Security and ADO.NET](../../../../docs/framework/data/adonet/code-access-security.md)  
 Describes how CAS can help protect ADO.NET code. Also discusses how to work with partial trust.  
  
 [Privacy and Data Security](../../../../docs/framework/data/adonet/privacy-and-data-security.md)  
 Describes encryption options for ADO.NET applications.  
  
## Related Sections  
 [SQL Server Security](../../../../docs/framework/data/adonet/sql/sql-server-security.md)  
 Describes SQL Server security features from a developer's perspective.  
  
 [Security Considerations](../../../../docs/framework/data/adonet/ef/security-considerations.md)  
 Describes security for Entity Framework applications.  
  
 [Security](../../../../docs/standard/security/index.md)  
 Contains links to topics describing all aspects of security in the .NET Framework.  
  
 [Security Tools](http://msdn.microsoft.com/library/2a3eb98a-2de6-4fba-b41c-01a74d354c11)  
 .NET Framework tools for securing and administering security policy.  
  
 [Resources for Creating Secure Applications](http://msdn.microsoft.com/library/0ebf5f69-76f2-498a-a2df-83cf3443e132)  
 Provides links to topics for creating secure applications.  
  
 [Security Bibliography](/visualstudio/ide/security-bibliography)  
 Provides links to external resources available online and in print.  
  
## See Also  
 [ADO.NET](../../../../docs/framework/data/adonet/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
