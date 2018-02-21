---
title: "Creating and Throwing Exceptions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "catching exceptions [C#]"
  - "throwing exceptions [C#]"
  - "exceptions [C#], creating"
  - "exceptions [C#], throwing"
ms.assetid: 6bbba495-a115-4c6d-90cc-1f4d7b5f39e2
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
---
# Creating and Throwing Exceptions (C# Programming Guide)
Exceptions are used to indicate that an error has occurred while running the program. Exception objects that describe an error are created and then *thrown* with the [throw](../../../csharp/language-reference/keywords/throw.md) keyword. The runtime then searches for the most compatible exception handler.  
  
 Programmers should throw exceptions when one or more of the following conditions are true:  
  
-   The method cannot complete its defined functionality.  
  
     For example, if a parameter to a method has an invalid value:  
  
     [!code-csharp[csProgGuideExceptions#12](../../../csharp/programming-guide/exceptions/codesnippet/CSharp/creating-and-throwing-exceptions_1.cs)]  
  
-   An inappropriate call to an object is made, based on the object state.  
  
     One example might be trying to write to a read-only file. In cases where an object state does not allow an operation, throw an instance of <xref:System.InvalidOperationException> or an object based on a derivation of this class. This is an example of a method that throws an <xref:System.InvalidOperationException> object:  
  
     [!code-csharp[csProgGuideExceptions#13](../../../csharp/programming-guide/exceptions/codesnippet/CSharp/creating-and-throwing-exceptions_2.cs)]  
  
-   When an argument to a method causes an exception.  
  
     In this case, the original exception should be caught and an <xref:System.ArgumentException> instance should be created. The original exception should be passed to the constructor of the <xref:System.ArgumentException> as the <xref:System.Exception.InnerException%2A> parameter:  
  
     [!code-csharp[csProgGuideExceptions#14](../../../csharp/programming-guide/exceptions/codesnippet/CSharp/creating-and-throwing-exceptions_3.cs)]  
  
 Exceptions contain a property named <xref:System.Exception.StackTrace%2A>. This string contains the name of the methods on the current call stack, together with the file name and line number where the exception was thrown for each method. A <xref:System.Exception.StackTrace%2A> object is created automatically by the common language runtime (CLR) from the point of the `throw` statement, so that exceptions must be thrown from the point where the stack trace should begin.  
  
 All exceptions contain a property named <xref:System.Exception.Message%2A>. This string should be set to explain the reason for the exception. Note that information that is sensitive to security should not be put in the message text. In addition to <xref:System.Exception.Message%2A>, <xref:System.ArgumentException> contains a property named <xref:System.ArgumentException.ParamName%2A> that should be set to the name of the argument that caused the exception to be thrown. In the case of a property setter, <xref:System.ArgumentException.ParamName%2A> should be set to `value`.  
  
 Public and protected methods members should throw exceptions whenever they cannot complete their intended functions. The exception class that is thrown should be the most specific exception available that fits the error conditions. These exceptions should be documented as part of the class functionality, and derived classes or updates to the original class should retain the same behavior for backward compatibility.  
  
## Things to Avoid When Throwing Exceptions  
 The following list identifies practices to avoid when throwing exceptions:  
  
-   Exceptions should not be used to change the flow of a program as part of ordinary execution. Exceptions should only be used to report and handle error conditions.  
  
-   Exceptions should not be returned as a return value or parameter instead of being thrown.  
  
-   Do not throw <xref:System.Exception?displayProperty=nameWithType>, <xref:System.SystemException?displayProperty=nameWithType>, <xref:System.NullReferenceException?displayProperty=nameWithType>, or <xref:System.IndexOutOfRangeException?displayProperty=nameWithType> intentionally from your own source code.  
  
-   Do not create exceptions that can be thrown in debug mode but not release mode. To identify run-time errors during the development phase, use Debug Assert instead.  
  
## Defining Exception Classes  
 Programs can throw a predefined exception class in the <xref:System> namespace (except where previously noted), or create their own exception classes by deriving from <xref:System.Exception>. The derived classes should define at least four constructors: one default constructor, one that sets the message property, and one that sets both the <xref:System.Exception.Message%2A> and <xref:System.Exception.InnerException%2A> properties. The fourth constructor is used to serialize the exception. New exception classes should be serializable. For example:  
  
 [!code-csharp[csProgGuideExceptions#15](../../../csharp/programming-guide/exceptions/codesnippet/CSharp/creating-and-throwing-exceptions_4.cs)]  
  
 New properties should only be added to the exception class when the data they provide is useful to resolving the exception. If new properties are added to the derived exception class, `ToString()` should be overridden to return the added information.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Exceptions and Exception Handling](../../../csharp/programming-guide/exceptions/index.md)  
 [Exception Hierarchy](http://msdn.microsoft.com/library/f7d68675-be06-40fb-a555-05f0c5a6f66b)  
 [Exception Handling](../../../csharp/programming-guide/exceptions/exception-handling.md)
