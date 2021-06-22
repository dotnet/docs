---
description: "Learn more about: Securing ADO.NET applications"
title: "Securing Applications"
ms.date: "03/30/2017"
ms.assetid: 005a1d43-6ee5-471e-ad98-1d30a44d49d5
---
# Securing ADO.NET applications

Writing a secure ADO.NET application involves more than avoiding common coding pitfalls such as not validating user input. An application that accesses data has many potential points of failure that an attacker can exploit to retrieve, manipulate, or destroy sensitive data. It is therefore important to understand all aspects of security, from the process of threat modeling during the design phase of your application, to its eventual deployment and ongoing maintenance.  
  
The .NET Framework provides many useful classes, services, and tools for securing and administering database applications. The common language runtime (CLR) provides a type-safe environment for code to run in, with code access security (CAS) to restrict further the permissions of managed code. Following secure data access coding practices limits the damage that can be inflicted by a potential attacker.  
  
Writing secure code does not guard against self-inflicted security holes when working with unmanaged resources such as databases. Most server databases, such as SQL Server, have their own security systems, which enhance security when implemented correctly. However, even a data source with a robust security system can be victimized in an attack if it is not configured appropriately.  
  
## In this section

 [Security Overview](security-overview.md)  
 Provides recommendations for designing secure ADO.NET applications.  
  
 [Secure Data Access](secure-data-access.md)  
 Describes how to work with data from a secured data source.  
  
 [Secure Client Applications](secure-client-applications.md)  
 Describes security considerations for client applications.  
  
 [Code Access Security and ADO.NET](code-access-security.md)  
 Describes how CAS can help protect ADO.NET code. Also discusses how to work with partial trust.  
  
 [Privacy and Data Security](privacy-and-data-security.md)  
 Describes encryption options for ADO.NET applications.  
  
## Related sections

 [DataSet and DataTable security guidance](dataset-datatable-dataview/security-guidance.md)  
 Provides security guidance for <xref:System.Data.DataSet> and <xref:System.Data.DataTable>.

 [SQL Server Security](/previous-versions/dotnet/framework/data/adonet/sql/sql-server-security)  
 Describes SQL Server security features from a developer's perspective.  
  
 [Security Considerations](./ef/security-considerations.md)  
 Describes security for Entity Framework applications.  
  
 [Security](../../../standard/security/index.md)  
 Contains links to articles describing all aspects of security in .NET.  
  
 [Security Tools](/previous-versions/visualstudio/visual-studio-2008/7w3fd0wb(v=vs.90))  
 .NET Framework tools for securing and administering security policy.  
  
 [Resources for Creating Secure Applications](/previous-versions/visualstudio/visual-studio-2010/ms165101(v=vs.100))  
 Provides links to articles for creating secure applications.  
  
 [Security Bibliography](/visualstudio/ide/securing-applications)  
 Provides links to external resources available online and in print.  
  
## See also

- [ADO.NET](index.md)
- [ADO.NET Overview](ado-net-overview.md)
