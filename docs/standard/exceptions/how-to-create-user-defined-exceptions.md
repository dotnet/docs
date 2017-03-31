---
title: "How to: Create User-Defined Exceptions | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "user-defined exceptions"
  - "exceptions, examples"
  - "exceptions, user-defined"
ms.assetid: 25819a5a-f915-4fc8-b924-a76915674e04
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# How to: Create User-Defined Exceptions
If you want users to be able to programmatically distinguish between some error conditions, you can create your own user-defined exceptions. The .NET Framework provides a hierarchy of exception classes ultimately derived from the base class <xref:System.Exception>. Each of these classes defines a specific exception, so in many cases you only have to catch the exception. You can also create your own exception classes by deriving from the <xref:System.Exception> class.  
  
 When creating your own exceptions, it is good coding practice to end the class name of the user-defined exception with the word "Exception." It is also good practice to implement the three recommended common constructors, as shown in the following example.  
  
> [!NOTE]
>  In situations where you are using remoting, you must ensure that the metadata for any user-defined exceptions is available at the server (callee) and to the client (the proxy object or caller). For example, code calling a method in a separate application domain must be able to find the assembly containing an exception thrown by a remote call. For more information, see [Best Practices for Handling Exceptions](../../../docs/standard/exceptions/best-practices-for-exceptions.md).  
  
 In the following example, a new exception class, `EmployeeListNotFoundException`, is derived from <xref:System.Exception>. Three constructors are defined in the class, each taking different parameters.  
  
## Example  
 [!code-cpp[dg_exceptionDesign#14](../../../samples/snippets/cpp/VS_Snippets_CLR/dg_exceptionDesign/cpp/example2.cpp#14)]
 [!code-csharp[dg_exceptionDesign#14](../../../samples/snippets/csharp/VS_Snippets_CLR/dg_exceptionDesign/cs/example2.cs#14)]
 [!code-vb[dg_exceptionDesign#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/dg_exceptionDesign/vb/example2.vb#14)]  
  
## See Also  
    
 [How to: Use Specific Exceptions in a Catch Block](../../../docs/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block.md)   
 [Best Practices for Exceptions](../../../docs/standard/exceptions/best-practices-for-exceptions.md)   
 [Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)