---
title: "SQL Server Common Language Runtime Integration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c7a324c4-160d-44c2-b593-641af06eca61
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL Server Common Language Runtime Integration
SQL Server 2005 introduced the integration of the common language runtime (CLR) component of the .NET Framework for Microsoft Windows. This means that you can write stored procedures, triggers, user-defined types, user-defined functions, user-defined aggregates, and streaming table-valued functions, using any .NET Framework language, including Microsoft Visual Basic .NET and Microsoft Visual C#. The <xref:Microsoft.SqlServer.Server> namespace contains a set of new application programming interfaces (APIs) so that managed code can interact with the Microsoft SQL Server environment.  
  
 This section describes features and behaviors that are specific to SQL Server common language runtime (CLR) integration and the SQL Server in-process specific extensions to ADO.NET.  
  
 This section is meant to provide only enough information to get started programming with SQL Server CLR integration, and is not meant to be comprehensive. For more detailed information, see the version of SQL Server Books Online for the version of SQL Server you are using.  
  
 **SQL Server Books Online**  
  
1.  [Common Language Runtime (CLR) Integration Programming Concepts](http://go.microsoft.com/fwlink/?LinkId=115240)  
  
## In This Section  
 [Introduction to SQL Server CLR Integration](../../../../../docs/framework/data/adonet/sql/introduction-to-sql-server-clr-integration.md)  
 Provides an introduction to SQL Server CLR integration. Provides links to additional topics.  
  
 [CLR User-Defined Functions](../../../../../docs/framework/data/adonet/sql/clr-user-defined-functions.md)  
 Describes how to implement and use the various types of CLR functions: table-valued, scalar, and user-defined aggregate functions.  
  
 [CLR User-Defined Types](../../../../../docs/framework/data/adonet/sql/clr-user-defined-types.md)  
 Describes how to implement and use CLR user-defined types. Provides links to additional topics.  
  
 [CLR Stored Procedures](../../../../../docs/framework/data/adonet/sql/clr-stored-procedures.md)  
 Describes how to implement and use CLR stored procedures. Provides links to additional topics.  
  
 [CLR Triggers](../../../../../docs/framework/data/adonet/sql/clr-triggers.md)  
 Describes how to implement and use CLR triggers. Provides links to additional topics.  
  
 [The Context Connection](../../../../../docs/framework/data/adonet/sql/the-context-connection.md)  
 Describes the context connection.  
  
 [SQL Server In-Process-Specific Behavior of ADO.NET](../../../../../docs/framework/data/adonet/sql/sql-server-in-process-specific-behavior-of-adonet.md)  
 Describes the SQL Server in-process specific extensions to ADO.NET, and the context connection. Provides links to additional topics.  
  
## See Also  
 [SQL Server and ADO.NET](../../../../../docs/framework/data/adonet/sql/index.md)  
 [Creating SQL Server 2005 Objects In Managed Code](http://msdn.microsoft.com/library/5358a825-e19b-49aa-8214-674ce5fed1da)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
