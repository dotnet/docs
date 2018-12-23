---
title: "CLR Stored Procedures"
ms.date: "03/30/2017"
ms.assetid: fd7eea9b-218a-4988-8c9a-8abcc6031c66
---
# CLR Stored Procedures
Stored procedures are routines that cannot be used in scalar expressions. They can return tabular results and messages to the client, invoke data definition language (DDL) and data manipulation language (DML) statements, and return output parameters.  
  
> [!NOTE]
>  Microsoft Visual Basic does not support output parameters in the same way that Microsoft Visual C# does. You must specify to pass the parameter by reference and apply the \<Out()> attribute to represent an output parameter, as in the following:  
  
```vb
Public Shared Sub ExecuteToClient( <Out()> ByRef number As Integer)  
```
  
For more detailed information, see the version of [SQL Server documentation](/sql) for the version of SQL Server you're using.
  
 **SQL Server documentation**

1. [CLR Stored Procedures](https://go.microsoft.com/fwlink/?LinkId=115400)  
  
## See Also  
 [Creating SQL Server 2005 Objects In Managed Code](https://msdn.microsoft.com/library/5358a825-e19b-49aa-8214-674ce5fed1da)  
 [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
