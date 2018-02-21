---
title: "CLR User-Defined Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9f70e0b0-3a0d-4eb1-b914-07a5d0c167c2
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CLR User-Defined Types
Microsoft SQL Server provides support for user-defined types (UDTs) implemented with the Microsoft .NET Framework common language runtime (CLR). The CLR is integrated into SQL Server, and this mechanism enables you to extend the type system of the database. UDTs provide user extensibility of the SQL Server data type system, and also the ability to define complex structured types.  
  
 UDTs can provide two key benefits from an application architecture perspective:  
  
-   Strong encapsulation (both in the client and the server) between the internal state and the external behaviors.  
  
-   Deep integration with other related server features. Once you define your own UDT, you can use it in all contexts where you can use a system type in SQL Server, including column definitions, and as variables, parameters, function results, cursors, triggers, and replication.  
  
 For more detailed information, see the version of SQL Server Books Online for the version of SQL Server you are using.  
  
 **SQL Server Books Online**  
  
1.  [CLR User-Defined Types](http://go.microsoft.com/fwlink/?LinkId=98366)  
  
## See Also  
 [Creating SQL Server 2005 Objects In Managed Code](http://msdn.microsoft.com/library/5358a825-e19b-49aa-8214-674ce5fed1da)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
