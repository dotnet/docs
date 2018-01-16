---
title: "Asynchronous Operations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e7d32c3c-bf78-4bfc-a357-c9e82e4a4b3c
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Asynchronous Operations
Some database operations, such as command executions, can take significant time to complete. In such a case, single-threaded applications must block other operations and wait for the command to finish before they can continue their own operations. In contrast, being able to assign the long-running operation to a background thread allows the foreground thread to remain active throughout the operation. In a Windows application, for example, delegating the long-running operation to a background thread allows the user interface thread to remain responsive while the operation is executing.  
  
 The .NET Framework provides several standard asynchronous design patterns that developers can use to take advantage of background threads and free the user interface or high-priority threads to complete other operations. ADO.NET supports these same design patterns in its <xref:System.Data.SqlClient.SqlCommand> class. Specifically, the <xref:System.Data.SqlClient.SqlCommand.BeginExecuteNonQuery%2A>, <xref:System.Data.SqlClient.SqlCommand.BeginExecuteReader%2A>, and <xref:System.Data.SqlClient.SqlCommand.BeginExecuteXmlReader%2A> methods, paired with the <xref:System.Data.SqlClient.SqlCommand.EndExecuteNonQuery%2A>, <xref:System.Data.SqlClient.SqlCommand.EndExecuteReader%2A>, and <xref:System.Data.SqlClient.SqlCommand.EndExecuteXmlReader%2A> methods, provide the asynchronous support.  
  
> [!NOTE]
>  Asynchronous programming is a core feature of the .NET Framework, and ADO.NET takes full advantage of the standard design patterns. For more information about the different asynchronous techniques available to developers, see [Calling Synchronous Methods Asynchronously](../../../../../docs/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md).  
  
 Although using asynchronous techniques with ADO.NET features does not add any special considerations, it is likely that more developers will use asynchronous features in ADO.NET than in other areas of the .NET Framework. It is important to be aware of the benefits and pitfalls of creating multithreaded applications. The examples that follow in this section point out several important issues that developers will need to take into account when building applications that incorporate multithreaded functionality.  
  
## In This Section  
 [Windows Applications Using Callbacks](../../../../../docs/framework/data/adonet/sql/windows-applications-using-callbacks.md)  
 Provides an example demonstrating how to execute an asynchronous command safely, correctly handling interaction with a form and its contents from a separate thread.  
  
 [ASP.NET Applications Using Wait Handles](../../../../../docs/framework/data/adonet/sql/aspnet-apps-using-wait-handles.md)  
 Provides an example demonstrating how to execute multiple concurrent commands from an ASP.NET page, using Wait handles to manage the operation at completion of all the commands.  
  
 [Polling in Console Applications](../../../../../docs/framework/data/adonet/sql/polling-in-console-applications.md)  
 Provides an example demonstrating the use of polling to wait for the completion of an asynchronous command execution from a console application. This technique is also valid in a class library or other application without a user interface.  
  
## See Also  
 [SQL Server and ADO.NET](../../../../../docs/framework/data/adonet/sql/index.md)  
 [Calling Synchronous Methods Asynchronously](../../../../../docs/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
