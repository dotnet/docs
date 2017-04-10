---
title: "Exception Handling Fundamentals | Microsoft Docs"
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
  - "runtime, exceptions"
  - "exceptions, examples"
  - "common language runtime, exceptions"
ms.assetid: e865d48c-b862-4448-833e-09fcd48adf6b
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# Exception Handling Fundamentals
The common language runtime supports an exception handling model based on the concepts of exception objects and protected blocks of code. The runtime creates an object to represent an exception when it occurs. You can also create your own exception classes by deriving classes from the appropriate base exception.  
  
 All languages that use the runtime handle exceptions in a similar manner. Each language uses a form of try/catch/finally structured exception handling. This section provides several examples of basic exception handling.  
  
## In This Section  
 How to: Use the Try/Catch Block to Catch Exceptions  
 Describes how to use the try/catch block to handle exceptions.  
  
 [How to: Use Specific Exceptions in a Catch Block](../../../docs/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block.md)  
 Describes how to catch specific exceptions.  
  
 [How to: Explicitly Throw Exceptions](../../../docs/standard/exceptions/how-to-explicitly-throw-exceptions.md)  
 Describes how to throw exceptions and how to catch exceptions and then throw them again.  
  
 [How to: Create User-Defined Exceptions](../../../docs/standard/exceptions/how-to-create-user-defined-exceptions.md)  
 Describes how to create your own exception classes.  
  
 [Using User-Filtered Handlers](../../../docs/standard/exceptions/using-user-filtered-exception-handlers.md)  
 Describes how to set up filtered exceptions.  
  
 [How to: Use a Finally Block](../../../docs/standard/exceptions/how-to-use-finally-blocks.md)  
 Explains how to use the finally statement in an exception block.  
  
## Related Sections  
 [Exceptions](../../../docs/standard/exceptions/index.md)  
 Provides an overview of common language runtime exceptions.  
  
 [Exception Class and Properties](../../../docs/standard/exceptions/exception-class-and-properties.md)  
 Describes the elements of an exception object.