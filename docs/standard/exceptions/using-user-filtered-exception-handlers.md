---
title: "Using User-Filtered Exception Handlers"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "user-filtered exceptions"
  - "exceptions, user-filtered"
ms.assetid: aa80d155-060d-41b4-a636-1ceb424afee8
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Using User-Filtered Exception Handlers
Currently, Visual Basic supports user-filtered exceptions. User-filtered exception handlers catch and handle exceptions based on requirements you define for the exception. These handlers use the **Catch** statement with the **When** keyword.  
  
 This technique is useful when a particular exception object corresponds to multiple errors. In this case, the object typically has a property that contains the specific error code associated with the error. You can use the error code property in the expression to select only the particular error you want to handle in that **Catch** clause.  
  
 The following Visual Basic example illustrates the **Catch/When** statement.  
  
```  
Try  
      'Try statements.  
   Catch When Err = VBErr_ClassLoadException  
      'Catch statements.  
End Try  
```  
  
 The expression of the user-filtered clause is not restricted in any way. If an exception occurs during execution of the user-filtered expression, that exception is discarded and the filter expression is considered to have evaluated to false. In this case, the common language runtime continues the search for a handler for the current exception.  
  
## Combining the Specific Exception and the User-Filtered Clauses  
 A catch statement can contain both the specific exception and the user-filtered clauses. The runtime tests the specific exception first. If the specific exception succeeds, the runtime executes the user filter. The generic filter can contain a reference to the variable declared in the class filter. Note that the order of the two filter clauses cannot be reversed.  
  
 The following Visual Basic example shows the specific exception `ClassLoadException` in the **Catch** statement as well as the user-filtered clause using the **When** keyword.  
  
```  
Try  
      'Try statements.  
   Catch cle As ClassLoadException When cle.IsRecoverable()  
      'Catch statements.  
End Try  
```  

## See Also
[Exceptions](index.md)
