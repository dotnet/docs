---
title: "CLR Integration Security in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 489fe096-fd1d-42de-8438-bf7aed46aea2
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CLR Integration Security in SQL Server
Microsoft SQL Server provides the integration of the common language runtime (CLR) component of the .NET Framework. CLR integration allows you to write stored procedures, triggers, user-defined types, user-defined functions, user-defined aggregates, and streaming table-valued functions, using any .NET Framework language, such as Microsoft Visual Basic .NET or Microsoft Visual C#.  
  
 The CLR supports a security model called code access security (CAS) for managed code. In this model, permissions are granted to assemblies based on evidence supplied by the code in metadata. SQL Server integrates the user-based security model of SQL Server with the code access-based security model of the CLR.  
  
## External Resources  
 For more information on CLR integration with SQL Server, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Code Access Security](http://msdn.microsoft.com/library/23a20143-241d-4fe5-9d9f-3933fd594c03)|Contains topics describing CAS in the .NET Framework.|  
|[CLR Integration Security](http://go.microsoft.com/fwlink/?LinkId=59998)|Discusses the security model for managed code executing inside of SQL Server.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [SQL Server Common Language Runtime Integration](../../../../../docs/framework/data/adonet/sql/sql-server-common-language-runtime-integration.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
