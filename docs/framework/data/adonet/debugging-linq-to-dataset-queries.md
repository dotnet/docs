---
title: "Debugging LINQ to DataSet Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f4c54015-8ce2-4c5c-8d18-7038144cc66d
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Debugging LINQ to DataSet Queries
[!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] supports the debugging of [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] code. However, there are some differences between debugging [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] code and non-[!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] managed code. Most debugging features work with [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] statements, including stepping, setting breakpoints, and viewing results that are shown in debugger windows. However, deferred query execution in has some side effects that you should consider while debugging [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] code and there are some limitations to using Edit and Continue. This topic discusses aspects of debugging that are unique to [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] compared to non-[!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] managed code.  
  
## Viewing Results  
 You can view the result of a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] statement by using DataTips, the Watch window, and the QuickWatch dialog box. By using a source window, you can pause the pointer on a query in the source window and a DataTip will appear. You can copy a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] variable and paste it into the Watch window or the QuickWatch dialog box. In [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)], a query is not evaluated when it is created or declared, but only when the query is executed. This is called *deferred execution*. Therefore, the query variable does not have a value until it is evaluated. For more information, see [Queries in LINQ to DataSet](../../../../docs/framework/data/adonet/queries-in-linq-to-dataset.md).  
  
 The debugger must evaluate a query to display the query results. This implicit evaluation occurs when you view a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query result in the debugger, and it has some effects you should consider. Each evaluation of the query takes time. Expanding the results node takes time. For some queries, repeated evaluation might cause a noticeable performance penalty. Evaluating a query can also cause side effects, which are changes to the value of data or the state of your program. Not all queries have side effects. To determine whether a query can be safely evaluated without side effects, you must understand the code that implements the query. For more information, see [Side Effects and Expressions](http://msdn.microsoft.com/library/e1f8a6ea-9e19-481d-b6bd-df120ad3bf4e).  
  
## Edit and Continue  
 Edit and Continue does not support changes to [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries. If you add, remove, or change a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] statement during a debugging session, a dialog box appears that tells you the change is not supported by Edit and Continue. At that point, you can either undo the changes or stop the debugging session and restart a new session with the edited code.  
  
 In addition, Edit and Continue does not support changing the type or the value of a variable that is used in a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] statement. Again, you can either undo the changes or stop and restart the debugging session.  
  
 In Visual C# in Visual Studio, you cannot use Edit and Continue on any code in a method that contains a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query.  
  
 In Visual Basic in Visual Studio, you can use Edit and Continue on non-[!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] code, even in a method that contains a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query. You can add or remove code before the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] statement, even if the changes affect line number of the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query. Your Visual Basic debugging experience for non-[!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] code remains the same as it was before [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] was introduced. You cannot change, add, or remove a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, however, unless you stop debugging to apply the changes.  
  
## See Also  
 [Debugging Managed Code](/visualstudio/debugger/debugging-managed-code)  
 [Programming Guide](../../../../docs/framework/data/adonet/programming-guide-linq-to-dataset.md)
