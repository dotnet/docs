---
title: "SQL Server Compact and LINQ to SQL"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 59022359-a5a2-4c42-9a6a-5c0259c3ad17
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL Server Compact and LINQ to SQL
SQL Server Compact is the default database installed with Visual Studio. For more information, see [PAVE OVER Using SQL Server Compact (Visual Studio)](http://msdn.microsoft.com/library/13320dd1-94e5-4077-bf76-8df253695ccc).  
  
 This topic outlines the key differences in usage, configuration, feature sets, and scope of [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] support.  
  
## Characteristics of SQL Server Compact in Relation to LINQ to SQL  
 By default, SQL Server Compact is installed for all [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] editions, and is therefore available on the development computer for use with [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. But deployment of an application that uses SQL Server Compact and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] differs from that for a [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] application. SQL Server Compact is not a part of the .NET Framework, and therefore must be packaged with the application or downloaded separately from the Microsoft site.  
  
 Note the following characteristics:  
  
-   SQL Server Compact is packaged as a DLL that can be used against database files (.sdf extension) directly.  
  
-   SQL Server Compact runs in the same process as the client application. The efficiency of communication with SQL Server Compact can therefore be significantly higher than communicating with [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)]. On the other hand, SQL Server Compact does require interoperability between managed and unmanaged code with its attendant costs.  
  
-   The size of the SQL Server Compact DLL is small. This feature reduces the overall application size.  
  
-   The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] runtime and the SQLMetal command-line tool support SQL Server Compact.  
  
-   The [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] does not support SQL Server Compact.  
  
## Feature Set  
 The SQL Server Compact feature set is much simpler than the feature set of [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] in the following ways that can affect [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] applications :  
  
-   SQL Server Compact does not support stored procedures or views.  
  
-   SQL Server Compact supports only a subset of data types and SQL functions.  
  
-   SQL Server Compact supports only a subset of SQL constructs.  
  
-   SQL Server Compact provides only a minimal optimizer. It is possible that some queries might time out.  
  
-   SQL Server Compact does not support partial trust.  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)
