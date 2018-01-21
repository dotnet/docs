---
title: "CLR Stored Procedures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fd7eea9b-218a-4988-8c9a-8abcc6031c66
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CLR Stored Procedures
Stored procedures are routines that cannot be used in scalar expressions. They can return tabular results and messages to the client, invoke data definition language (DDL) and data manipulation language (DML) statements, and return output parameters.  
  
> [!NOTE]
>  Microsoft Visual Basic does not support output parameters in the same way that Microsoft Visual C# does. You must specify to pass the parameter by reference and apply the \<Out()> attribute to represent an output parameter, as in the following:  
  
```  
Public Shared Sub ExecuteToClient( <Out()> ByRef number As Integer)  
```  
  
 For more detailed information, see the version of SQL Server Books Online for the version of SQL Server you are using.  
  
 **SQL Server Books Online**  
  
1.  [CLR Stored Procedures](http://go.microsoft.com/fwlink/?LinkId=115400)  
  
## See Also  
 [Creating SQL Server 2005 Objects In Managed Code](http://msdn.microsoft.com/library/5358a825-e19b-49aa-8214-674ce5fed1da)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
