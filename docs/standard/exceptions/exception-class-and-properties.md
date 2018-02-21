---
title: "Exception Class and Properties"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
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
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Exception class and properties

The <xref:System.Exception> class is the base class from which exceptions inherit. For example, the <xref:System.InvalidCastException> class hierarchy is as follows:

```
Object
  Exception
    SystemException
       InvalidCastException
```

The <xref:System.Exception> class has the following properties that help make understanding an exception easier.

| Property Name | Description |
| ------------- | ----------- |
| <xref:System.Exception.Data> | An <xref:System.Collections.IDictionary> that holds arbitrary data in key-value pairs. |
| <xref:System.Exception.HelpLink> | Can hold a URL (or URN) to a help file that provides extensive information about the cause of an exception. |
| <xref:System.Exception.InnerException> | This property can be used to create and preserve a series of exceptions during exception handling. You can use it to create a new exception that contains previously caught exceptions. The original exception can be captured by the second exception in the <xref:System.Exception.InnerException> property, allowing code that handles the second exception to examine the additional information. For example, suppose you have a method that receives an argument that's improperly formatted.  The code tries to read the argument, but an exception is thrown. The method catches the exception and throws a <xref:System.FormatException>. To improve the caller's ability to determine the reason an exception is thrown, it is sometimes desirable for a method to catch an exception thrown by a helper routine and then throw an exception more indicative of the error that has occurred. A new and more meaningful exception can be created, where the inner exception reference can be set to the original exception. This more meaningful exception can then be thrown to the caller. Note that with this functionality, you can create a series of linked exceptions that ends with the exception that was thrown first. |
| <xref:System.Exception.Message> | Provides details about the cause of an exception.
| <xref:System.Exception.Source> | Gets or sets the name of the application or the object that causes the error. |
| <xref:System.Exception.StackTrace>| Contains a stack trace that can be used to determine where an error occurred. The stack trace includes the source file name and program line number if debugging information is available. |

Most of the classes that inherit from <xref:System.Exception> do not implement additional members or provide additional functionality; they simply inherit from <xref:System.Exception>. Therefore, the most important information for an exception can be found in the hierarchy of exception classes, the exception name, and the information contained in the exception.

We recommend that you throw and catch only objects that derive from <xref:System.Exception>, but you can throw any object that derives from the <xref:System.Object> class as an exception. Note that not all languages support throwing and catching objects that do not derive from <xref:System.Exception>.
  
## See Also  
[Exceptions](index.md)
