---
title: "Exception Class and Properties | Microsoft Docs"
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
---
# Exception class and properties

The @System.Exception class is the base class from which exceptions inherit. For example, the @System.InvalidCastException class hierarchy is as follows:

```
Object
  Exception
    SystemException
       InvalidCastException
```

The @System.Exception class has the following properties that help make understanding an exception easier.

| Property Name | Description |
| ------------- | ----------- |
| @System.Exception.Data | An @System.Collections.IDictionary that holds arbitrary data in key-value pairs. |
| @System.Exception.HelpLink | Can hold a URL (or URN) to a help file that provides extensive information about the cause of an exception. |
| @System.Exception.InnerException | This property can be used to create and preserve a series of exceptions during exception handling. You can use it to create a new exception that contains previously caught exceptions. The original exception can be captured by the second exception in the @System.Exception.InnerException property, allowing code that handles the second exception to examine the additional information. For example, suppose you have a method that receives an argument that's improperly formatted.  The code tries to read the argument, but an exception is thrown. The method catches the exception and throws a @System.FormatException. To improve the caller's ability to determine the reason an exception is thrown, it is sometimes desirable for a method to catch an exception thrown by a helper routine and then throw an exception more indicative of the error that has occurred. A new and more meaningful exception can be created, where the inner exception reference can be set to the original exception. This more meaningful exception can then be thrown to the caller. Note that with this functionality, you can create a series of linked exceptions that ends with the exception that was thrown first. |
| @System.Exception.Message | Provides details about the cause of an exception.
| @System.Exception.Source | Gets or sets the name of the application or the object that causes the error. |
| @System.Exception.StackTrace | Contains a stack trace that can be used to determine where an error occurred. The stack trace includes the source file name and program line number if debugging information is available. |

Most of the classes that inherit from @System.Exception do not implement additional members or provide additional functionality; they simply inherit from @System.Exception. Therefore, the most important information for an exception can be found in the hierarchy of exception classes, the exception name, and the information contained in the exception.

It is recommended to throw and catch only objects that derive from @System.Exception, but you can throw any object that derives from the @System.Object class as an exception. Note that not all languages support throwing and catching objects that do not derive from @System.Exception.
  
## See Also  
[Exceptions](index.md)