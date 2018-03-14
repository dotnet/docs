---
title: "Reliability"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "SQL Server [.NET Framework]"
  - "managed code, reliability"
  - "reliability [.NET Framework]"
  - "writing reliable code"
  - "code, reliability"
ms.assetid: 294aa306-0afe-4cbe-b397-86ba9f1860f8
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Reliability
It is important that code executing in server environments such as SQL Server protect against asynchronous exceptions. Reliability, as discussed here, is not specific to SQL Server but to writing reliable code for any host executing in a .NET Framework version 2.0 environment. However, SQL Server is the first service making extensive use of the new reliability features of version 2.0, so it is used as an example.  
  
 Code running in SQL Server must deal with more stringent reliability guidelines than other server environments. This is due to SQL Server’s steady operation at the edge of resource consumption.  <xref:System.OutOfMemoryException> and <xref:System.Threading.ThreadAbortException> exceptions are not uncommon in the SQL Server environment. These guidelines in general are focused less on reliability and more on allowing fully trusted managed code to fail gracefully in the face of <xref:System.AppDomain>-level recycling, which is the primary way the server maintains consistency and availability.  
  
## In This Section  
 [SQL Server Programming and Host Protection Attributes](../../../docs/framework/performance/sql-server-programming-and-host-protection-attributes.md)  
 Describes how the <xref:System.Security.Permissions.HostProtectionAttribute> attribute is used by SQL Server to restrict the execution of managed code.  
  
 [Reliability Best Practices](../../../docs/framework/performance/reliability-best-practices.md)  
 Provides guidelines for writing code that meets reliability requirements.  
  
 [Constrained Execution Regions](../../../docs/framework/performance/constrained-execution-regions.md)  
 Describes the function and behavior of constrained execution regions (CERs).  
  
## Reference  
 <xref:System.Security.Permissions.HostProtectionAttribute>  
  
 <xref:System.Security.Permissions.HostProtectionResource>
