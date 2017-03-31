---
title: "Best Practices for Exceptions | Microsoft Docs"
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
  - "exceptions, best practices"
ms.assetid: f06da765-235b-427a-bfb6-47cd219af539
caps.latest.revision: 28
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# Best Practices for Exceptions
A well-designed app handles exceptions and errors to prevent app crashes. This article describes best practices for handling and creating exceptions.  
  
## Handling exceptions  
 The following list contains some general guidelines for handling exceptions in your app.  
  
-   Use exception handling code (`try`/`catch` blocks) appropriately. You can also programmatically check for a condition that is likely to occur without using exception handling.  
  
     **Programmatic checks**. The following example uses an `if` statement to check whether a connection is closed. If it isn't, the example closes the connection instead of throwing an exception.  
  
     [!code-cpp[Conceptual.Exception.Handling#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#2)]
     [!code-csharp[Conceptual.Exception.Handling#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#2)]
     [!code-vb[Conceptual.Exception.Handling#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#2)]  
  
     **Exception handling**. The following example uses a `try`/`catch` block to check the connection and to throw an exception if the connection is not closed.  
  
     [!code-cpp[Conceptual.Exception.Handling#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#3)]
     [!code-csharp[Conceptual.Exception.Handling#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#3)]
     [!code-vb[Conceptual.Exception.Handling#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#3)]  
  
     The method you choose depends on how often you expect the event to occur.  
  
    -   Use exception handling if the event doesn't occur very often, that is, if the event is truly exceptional and indicates an error (such as an unexpected end-of-file). When you use exception handling, less code is executed in normal conditions.  
  
    -   Use the programmatic method to check for errors if the event happens routinely and could be considered part of normal execution. When you check for errors programmatically, more code is executed if an exception occurs.  
  
-   Use `try`/`catch` blocks around code that can potentially generate an exception, and use a `finally` block to clean up resources, if necessary. This way, the `try` statement generates the exception, the `catch` statement handles the exception, and the `finally` statement closes or deallocates resources whether or not an exception occurs.  
  
-   In `catch` blocks, always order exceptions from the most specific to the least specific. This technique handles the specific exception before it is passed to a more general `catch` block.  
  
## Creating and raising exceptions  
 The following list contains guidelines for creating your own exceptions and when they should be raised.  For a more details, see [Design Guidelines for Exceptions](../../../docs/standard/design-guidelines/exceptions.md).  
  
-   Design classes so that an exception is never thrown in normal use. For example, a <xref:System.IO.FileStream> class provides methods that help determine whether the end of the file has been reached. This avoids the exception that is thrown if you read past the end of the file. The following example shows how to read to the end of the file.  
  
     [!code-cpp[Conceptual.Exception.Handling#5](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#5)]
     [!code-csharp[Conceptual.Exception.Handling#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#5)]
     [!code-vb[Conceptual.Exception.Handling#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#5)]  
  
-   Throw exceptions instead of returning an error code or HRESULT.  
  
-   Return null for extremely common error cases instead of throwing an exception. An extremely common error case can be considered normal flow of control. By returning null in these cases, you minimize the performance impact to an app.  
  
-   In most cases, use the predefined .NET Framework exception types. Introduce a new exception class only when a predefined one doesn't apply.  
  
-   Throw an <xref:System.InvalidOperationException> exception if a property set or method call is not appropriate given the object's current state.  
  
-   Throw an <xref:System.ArgumentException> exception or a class derived from <xref:System.ArgumentException> if invalid parameters are passed.  
  
-   For most apps, derive custom exceptions from the <xref:System.Exception> class.  Deriving from the <xref:System.ApplicationException> class doesn't add significant value.  
  
-   End exception class names with the word "Exception". For example:  
  
     [!code-cpp[Conceptual.Exception.Handling#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#4)]
     [!code-csharp[Conceptual.Exception.Handling#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#4)]
     [!code-vb[Conceptual.Exception.Handling#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#4)]  
  
-   In C# and C++, use at least the three common constructors when creating your own exception classes: the default constructor, a constructor that takes a string message, and a constructor that takes a string message and an inner exception. For an example, see [How to: Create User-Defined Exceptions](../../../docs/standard/exceptions/how-to-create-user-defined-exceptions.md).  
  
    1.  <xref:System.Exception.%23ctor> , which uses default vales.  
  
    2.  <xref:System.Exception.%23ctor%28System.String%29>, which accepts a string message.  
  
    3.  <xref:System.Exception.%23ctor%28System.String%2CSystem.Exception%29>, which accepts a string message and an inner exception.  
  
-   When you create user-defined exceptions, you must ensure that the metadata for the exceptions is available to code that is executing remotely, including when exceptions occur across app domains. For example, suppose App Domain A creates App Domain B, which executes code that throws an exception. For App Domain A to properly catch and handle the exception, it must be able to find the assembly that contains the exception thrown by App Domain B. If App Domain B throws an exception that is contained in an assembly under its application base, but not under App Domain A's application base, App Domain A will not be able to find the exception, and the common language runtime will throw a <xref:System.IO.FileNotFoundException> exception. To avoid this situation, you can deploy the assembly that contains the exception information in two ways:  
  
    -   Put the assembly into a common application base shared by both app domains.  
  
         \- or -  
  
    -   If the domains do not share a common application base, sign the assembly that contains the exception information with a strong name and deploy the assembly into the global assembly cache.  
  
-   Include a localized description string in every exception. The error message that the user sees is derived from the description string of the exception that was thrown, and not from the exception class.  
  
-   Use grammatically correct error messages, including ending punctuation. Each sentence in a description string of an exception should end in a period. For example, "The log table has overflowed.” would be an appropriate description string.  
  
-   Provide <xref:System.Exception> properties for programmatic access. Provide additional properties for an exception (in addition to the description string) only when there's a programmatic scenario where the additional information is useful. For example, the <xref:System.IO.FileNotFoundException> provides the <xref:System.IO.FileNotFoundException.FileName%2A> property.  
  
-   The stack trace begins at the statement where the exception is thrown and ends at the `catch` statement that catches the exception. Be aware of this fact when deciding where to place a `throw` statement.  
  
-   Use exception builder methods. It is common for a class to throw the same exception from different places in its implementation. To avoid excessive code, use helper methods that create the exception and return it. For example:  
  
     [!code-cpp[Conceptual.Exception.Handling#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#6)]
     [!code-csharp[Conceptual.Exception.Handling#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#6)]
     [!code-vb[Conceptual.Exception.Handling#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#6)]  
  
     Alternatively, use the exception's constructor to build the exception. This is more appropriate for global exception classes such as <xref:System.ArgumentException>.  
  
-   Clean up intermediate results when throwing an exception. Callers should be able to assume that there are no side effects when an exception is thrown from a method.  
  
## See Also  
 [Exceptions](../../../docs/standard/exceptions/index.md)