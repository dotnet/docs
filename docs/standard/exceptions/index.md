---
title: "Handling and Throwing Exceptions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
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
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Handling and throwing exceptions in .NET

Applications must be able to handle errors that occur during execution in a consistent manner. .NET provides a model for notifying applications of errors in a uniform way: .NET operations indicate failure by throwing exceptions.

## Exceptions

An exception is any error condition or unexpected behavior that is encountered by an executing program. Exceptions can be thrown because of a fault in your code or in code that you call (such as a shared library), unavailable operating system resources, unexpected conditions that the runtime encounters (such as code that cannot be verified), and so on. Your application can recover from some of these conditions, but not from others. Although you can recover from most application exceptions, you cannot recover from most runtime exceptions.

In .NET, an exception is an object that inherits from the <xref:System.Exception?displayProperty=nameWithType> class. An exception is thrown from an area of code where a problem has occurred. The exception is passed up the stack until the application handles it or the program terminates.

## Exceptions vs. traditional error-handling methods

Traditionally, a language's error-handling model relied on either the language's unique way of detecting errors and locating handlers for them, or on the error-handling mechanism provided by the operating system. The way .NET implements exception handling provides the following advantages:

- Exception throwing and handling works the same for .NET programming languages.

- Does not require any particular language syntax for handling exceptions, but allows each language to define its own syntax.

- Exceptions can be thrown across process and even machine boundaries.

- Exception-handling code can be added to an application to increase program reliability.

Exceptions offer advantages over other methods of error notification, such as return codes. Failures do not go unnoticed because if an exception is thrown and you don't handle it, the runtime terminates your application. Invalid values do not continue to propagate through the system as a result of code that fails to check for a failure return code. 

## Common Exceptions

The following table lists some common exceptions with examples of what can cause them.

| Exception type | Base type | Description | Example |
| -------------- | --------- | ----------- | ------- |
| <xref:System.Exception> | <xref:System.Object> | Base class for all exceptions. | None (use a derived class of this exception). |
| <xref:System.IndexOutOfRangeException> | <xref:System.Exception> | Thrown by the runtime only when an array is indexed improperly. | Indexing an array outside its valid range: `arr[arr.Length+1]` |
| <xref:System.NullReferenceException> | <xref:System.Exception> | Thrown by the runtime only when a null object is referenced. | `object o = null; o.ToString();` |
| <xref:System.InvalidOperationException> | <xref:System.Exception> | Thrown by methods when in an invalid state. | Calling `Enumerator.GetNext()` after removing an Item from the underlying collection. |
| <xref:System.ArgumentException> | <xref:System.Exception> | Base class for all argument exceptions. | None (use a derived class of this exception). |
| <xref:System.ArgumentNullException> | <xref:System.Exception> | Thrown by methods that do not allow an argument to be null. | `String s = null; "Calculate".IndexOf (s);` |
| <xref:System.ArgumentOutOfRangeException> | <xref:System.Exception> | Thrown by methods that verify that arguments are in a given range. | `String s = "string"; s.Substring(s.Length+1);` |

## See Also

* [Exception Class and Properties](exception-class-and-properties.md)
* [How to: Use the Try-Catch Block to Catch Exceptions](how-to-use-the-try-catch-block-to-catch-exceptions.md)
* [How to: Use Specific Exceptions in a Catch Block](how-to-use-specific-exceptions-in-a-catch-block.md)
* [How to: Explicitly Throw Exceptions](how-to-explicitly-throw-exceptions.md)
* [How to: Create User-Defined Exceptions](how-to-create-user-defined-exceptions.md)
* [Using User-Filtered Exception Handlers](using-user-filtered-exception-handlers.md)
* [How to: Use Finally Blocks](how-to-use-finally-blocks.md)
* [Handling COM Interop Exceptions](handling-com-interop-exceptions.md)
* [Best Practices for Exceptions](best-practices-for-exceptions.md)

To learn more about how exceptions work in .NET, see [What Every Dev needs to Know About Exceptions in the Runtime](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/exceptions.md).
