---
title: "CLR Integration Security in SQL Server"
ms.date: "03/30/2017"
ms.assetid: 489fe096-fd1d-42de-8438-bf7aed46aea2
---
# CLR Integration Security in SQL Server
Microsoft SQL Server provides the integration of the common language runtime (CLR) component of the .NET Framework. CLR integration allows you to write stored procedures, triggers, user-defined types, user-defined functions, user-defined aggregates, and streaming table-valued functions, using any .NET Framework language, such as Microsoft Visual Basic .NET or Microsoft Visual C#.  
  
 The CLR supports a security model called code access security (CAS) for managed code. In this model, permissions are granted to assemblies based on evidence supplied by the code in metadata. SQL Server integrates the user-based security model of SQL Server with the code access-based security model of the CLR.  
  
## External Resources  
 For more information on CLR integration with SQL Server, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Code Access Security](../../../../../docs/framework/misc/code-access-security.md)|Contains topics describing CAS in the .NET Framework.|  
|[CLR Integration Security](/sql/relational-databases/clr-integration/security/clr-integration-security)|Discusses the security model for managed code executing inside of SQL Server.|  
  
## See also
- [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)
- [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)
- [SQL Server Common Language Runtime Integration](../../../../../docs/framework/data/adonet/sql/sql-server-common-language-runtime-integration.md)
- [ADO.NET Overview](../../../../../docs/framework/data/adonet/ado-net-overview.md)
