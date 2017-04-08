---
title: "Exception Class and Properties | Microsoft Docs"
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
  - "exceptions, Exception class"
  - "Exception class"
ms.assetid: e2e1f8c4-e7b4-467d-9a66-13c90861221d
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# Exception Class and Properties
The <xref:System.Exception> class is the base class from which exceptions inherit. Most exception objects are instances of some derived class of **Exception**, but you can throw any object that derives from the <xref:System.Object> class as an exception. Note that not all languages support throwing and catching objects that do not derive from **Exception**. In almost all cases, it is recommended to throw and catch only **Exception** objects.  
  
 The **Exception** class has several properties that make understanding an exception easier. These properties include:  
  
-   The <xref:System.Exception.StackTrace%2A> property.  
  
     This property contains a stack trace that can be used to determine where an error occurred. The stack trace includes the source file name and program line number if debugging information is available.  
  
-   The <xref:System.Exception.InnerException%2A> property.  
  
     This property can be used to create and preserve a series of exceptions during exception handling. You can use this property to create a new exception that contains previously caught exceptions. The original exception can be captured by the second exception in the **InnerException** property, allowing code that handles the second exception to examine the additional information.  
  
     For example, suppose you have a method that reads a file and formats the data. The code tries to read from the file, but a FileException is thrown. The method catches the FileException and throws a BadFormatException. In this case, the FileException can be saved in the **InnerException** property of the BadFormatException.  
  
     To improve the caller's ability to determine the reason an exception is thrown, it is sometimes desirable for a method to catch an exception thrown by a helper routine and then throw an exception more indicative of the error that has occurred. A new and more meaningful exception can be created, where the inner exception reference can be set to the original exception. This more meaningful exception can then be thrown to the caller. Note that with this functionality, you can create a series of linked exceptions that ends with the exception that was thrown first.  
  
-   The <xref:System.Exception.Message%2A> property.  
  
     This property provides details about the cause of an exception. The **Message** is in the language specified by the <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=fullName> property of the thread that throws the exception.  
  
-   The <xref:System.Exception.HelpLink%2A> property.  
  
     This property can hold a URL (or URN) to a help file that provides extensive information about the cause of an exception.  
  
-   The <xref:System.Exception.Data%2A> property  
  
     This property is an IDictionary that can hold arbitrary data in key-value pairs.  
  
 Most of the classes that inherit from **Exception** do not implement additional members or provide additional functionality; they simply inherit from **Exception**. Therefore, the most important information for an exception can be found in the hierarchy of exceptions, the exception name, and the information contained in the exception.  
  
## See Also  
 [Exception Hierarchy](../../../docs/standard/exceptions/exception-hierarchy.md)   
 [Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)   
 [Best Practices for Exceptions](../../../docs/standard/exceptions/best-practices-for-exceptions.md)   
 [Exceptions](../../../docs/standard/exceptions/index.md)