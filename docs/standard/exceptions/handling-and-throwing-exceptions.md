---
title: "Handling and Throwing Exceptions | Microsoft Docs"
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
  - "exceptions [.NET Framework], handling"
  - "runtime, exceptions"
  - "filtering exceptions"
  - "errors [.NET Framework], exceptions"
  - "exceptions [.NET Framework], throwing"
  - "exceptions [.NET Framework]"
  - "common language runtime, exceptions"
ms.assetid: f99a1d29-a2a8-47af-9707-9909f9010735
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# Handling and Throwing Exceptions
<a name="top"></a> Applications must be able to handle errors that occur during execution in a consistent manner. The common language runtime provides a model for notifying applications of errors in a uniform way. All .NET Framework operations indicate failure by throwing exceptions.  
  
 This topic contains the following sections:  
  
-   [Exceptions in the .NET Framework](#exceptions_in_the_net_framework)  
  
-   [Exceptions vs. Traditional Error-Handling Methods](#exceptions_vs_traditional_errorhandling_methods)  
  
-   [How the Runtime Manages Exceptions](#how_the_runtime_manages_exceptions)  
  
-   [Filtering Runtime Exceptions](#filtering_runtime_exceptions)  
  
-   [Related Topics](#related_topics)  
  
-   [Reference](#reference)  
  
<a name="exceptions_in_the_net_framework"></a>   
## Exceptions in the .NET Framework  
 An exception is any error condition or unexpected behavior that is encountered by an executing program. Exceptions can be raised because of a fault in your code or in code that you call (such as a shared library), unavailable operating system resources, unexpected conditions the common language runtime encounters (such as code that cannot be verified), and so on. Your application can recover from some of these conditions, but not from others. Although you can recover from most application exceptions, you cannot recover from most runtime exceptions.  
  
 In the .NET Framework, an exception is an object that inherits from the <xref:System.Exception?displayProperty=fullName> class. An exception is thrown from an area of code where a problem has occurred. The exception is passed up the stack until the application handles it or the program terminates.  
  
 [Back to top](#top)  
  
<a name="exceptions_vs_traditional_errorhandling_methods"></a>   
## Exceptions vs. Traditional Error-Handling Methods  
 Traditionally, a language's error-handling model relied on either the language's unique way of detecting errors and locating handlers for them, or on the error-handling mechanism provided by the operating system. The runtime implements exception handling with the following features:  
  
-   Handles exceptions without regard for the language that generates the exception or the language that handles the exception.  
  
-   Does not require any particular language syntax for handling exceptions, but allows each language to define its own syntax.  
  
-   Allows exceptions to be thrown across process and even machine boundaries.  
  
 Exceptions offer several advantages over other methods of error notification, such as return codes. Failures do not go unnoticed. Invalid values do not continue to propagate through the system. You do not have to check return codes. Exception-handling code can be easily added to increase program reliability. Finally, the runtime's exception handling is faster than Windows-based C++ error handling.  
  
 Because execution threads routinely traverse managed and unmanaged blocks of code, the runtime can throw or catch exceptions in either managed or unmanaged code. Unmanaged code can include both C++-style SEH Exceptions and COM-based HRESULTS.  
  
<a name="how_the_runtime_manages_exceptions"></a>   
## How the Runtime Manages Exceptions  
 The runtime uses an exception-handling model based on exception objects and protected blocks of code. An <xref:System.Exception> object is created to represent an exception when it occurs.  
  
 The runtime creates an exception information table for each executable. Each method of the executable has an associated array of exception-handling information (which can be empty) in the exception information table. Each entry in the array describes a protected block of code, any exception filters associated with that code, and any exception handlers (`catch` statements). This exception table is extremely efficient and does not cause any performance penalty in processor time or in memory use when an exception does not occur. You use resources only when an exception occurs.  
  
 The exception information table represents four types of exception handlers for protected blocks:  
  
-   A `finally` handler that executes whenever the block exits, whether that occurs by normal control flow or by an unhandled exception.  
  
-   A fault handler that must execute if an exception occurs, but does not execute on completion of normal control flow.  
  
-   A type-filtered handler that handles any exception of a specified class or any of its derived classes.  
  
-   A user-filtered handler that runs user-specified code to determine whether the exception should be handled by the associated handler or should be passed to the next protected block.  
  
 Each language implements these exception handlers according to its specifications. For example, Visual Basic provides access to the user-filtered handler through a variable comparison (using the `When` keyword) in the `catch` statement; C# does not implement the user-filtered handler.  
  
 When an exception occurs, the runtime begins a two-step process:  
  
1.  The runtime searches the array for the first protected block that does the following:  
  
    -   Protects a region that includes the currently executing instruction.  
  
    -   Contains an exception handler or contains a filter that handles the exception.  
  
2.  If a match occurs, the runtime creates an <xref:System.Exception> object that describes the exception. The runtime then executes all `finally` or fault statements between the statement where the exception occurred and the statement that handles the exception. Note that the order of exception handlers is important; the innermost exception handler is evaluated first. Also note that exception handlers can access the local variables and local memory of the routine that catches the exception, but any intermediate values at the time the exception is thrown are lost.  
  
     If no match occurs in the current method, the runtime searches each caller of the current method, and it continues this path all the way up the stack. If no caller has a match, the runtime lets the debugger access the exception. If the debugger does not attach to the exception, the runtime raises the <xref:System.AppDomain.UnhandledException?displayProperty=fullName> event. If there are no listeners for this event, the runtime dumps a stack trace and ends the application.  
  
 [Back to top](#top)  
  
<a name="filtering_runtime_exceptions"></a>   
## Filtering Runtime Exceptions  
 You can filter the exceptions you catch and handle either by type or by some user-defined criteria.  
  
 Type-filtered handlers manage a particular type of exception (or classes derived from it). The following example shows a type-filtered handler that is designed to catch a specific exception, in this case, the <xref:System.IO.FileNotFoundException>.  
  
 [!code-cpp[CatchException#5](../../../samples/snippets/cpp/VS_Snippets_CLR/CatchException/CPP/catchexception3.cpp#5)]
 [!code-csharp[CatchException#5](../../../samples/snippets/csharp/VS_Snippets_CLR/CatchException/CS/catchexception3.cs#5)]
 [!code-vb[CatchException#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CatchException/VB/catchexception3.vb#5)]  
  
 User-filtered exception handlers catch and handle exceptions based on requirements you define for the exception. For more information about filtering exceptions in this way, see [Using Specific Exceptions in a Catch Block](../../../docs/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block.md).  
  
 [Back to top](#top)  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Exception Class and Properties](../../../docs/standard/exceptions/exception-class-and-properties.md)|Describes the elements of an exception object.|  
|[Exception Hierarchy](../../../docs/standard/exceptions/exception-hierarchy.md)|Describes the exceptions that most exceptions derive from.|  
|[Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)|Explains how to handle exceptions using catch, throw, and finally statements.|  
|[Best Practices for Exceptions](../../../docs/standard/exceptions/best-practices-for-exceptions.md)|Describes suggested methods for handling exceptions.|  
|[Handling COM Interop Exceptions](../../../docs/standard/exceptions/handling-com-interop-exceptions.md)|Describes how to handle exceptions thrown and caught in unmanaged code.|  
|[How to: Map HRESULTs and Exceptions](../../../docs/framework/interop/how-to-map-hresults-and-exceptions.md)|Describes the mapping of exceptions between managed and unmanaged code.|  
  
<a name="reference"></a>   
## Reference  
 <xref:System.Exception?displayProperty=fullName>  
  
 <xref:System.ApplicationException?displayProperty=fullName>  
  
 <xref:System.SystemException?displayProperty=fullName>