---
title: "Creating and Throwing Exceptions"
description: Learn about creating and throwing exceptions. Exceptions are used to indicate that an error has occurred while running a program.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "catching exceptions [C#]"
  - "throwing exceptions [C#]"
  - "exceptions [C#], creating"
  - "exceptions [C#], throwing"
---
# Creating and Throwing Exceptions

Exceptions are used to indicate that an error has occurred while running the program. Exception objects that describe an error are created and then *thrown* with the [`throw`](../../language-reference/keywords/throw.md) keyword. The runtime then searches for the most compatible exception handler.

Programmers should throw exceptions when one or more of the following conditions are true:

- The method can't complete its defined functionality. For example, if a parameter to a method has an invalid value:

  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="CantComplete":::

- An inappropriate call to an object is made, based on the object state. One example might be trying to write to a read-only file. In cases where an object state doesn't allow an operation, throw an instance of <xref:System.InvalidOperationException> or an object based on a derivation of this class. The following code is an example of a method that throws an <xref:System.InvalidOperationException> object:

  :::code language="csharp" source="snippets/exceptions/ProgramLog.cs" ID="ProgramLog":::

- When an argument to a method causes an exception. In this case, the original exception should be caught and an <xref:System.ArgumentException> instance should be created. The original exception should be passed to the constructor of the <xref:System.ArgumentException> as the <xref:System.Exception.InnerException%2A> parameter:

  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="InvalidArg":::

Exceptions contain a property named <xref:System.Exception.StackTrace%2A>. This string contains the name of the methods on the current call stack, together with the file name and line number where the exception was thrown for each method. A <xref:System.Exception.StackTrace%2A> object is created automatically by the common language runtime (CLR) from the point of the `throw` statement, so that exceptions must be thrown from the point where the stack trace should begin.

All exceptions contain a property named <xref:System.Exception.Message%2A>. This string should be set to explain the reason for the exception. Information that is sensitive to security shouldn't be put in the message text. In addition to <xref:System.Exception.Message%2A>, <xref:System.ArgumentException> contains a property named <xref:System.ArgumentException.ParamName%2A> that should be set to the name of the argument that caused the exception to be thrown. In a property setter, <xref:System.ArgumentException.ParamName%2A> should be set to `value`.

Public and protected methods throw exceptions whenever they can't complete their intended functions. The exception class thrown is the most specific exception available that fits the error conditions. These exceptions should be documented as part of the class functionality, and derived classes or updates to the original class should retain the same behavior for backward compatibility.

## Things to Avoid When Throwing Exceptions

The following list identifies practices to avoid when throwing exceptions:

- Don't use exceptions to change the flow of a program as part of ordinary execution. Use exceptions to report and handle error conditions.
- Exceptions shouldn't be returned as a return value or parameter instead of being thrown.
- Don't throw <xref:System.Exception?displayProperty=nameWithType>, <xref:System.SystemException?displayProperty=nameWithType>, <xref:System.NullReferenceException?displayProperty=nameWithType>, or <xref:System.IndexOutOfRangeException?displayProperty=nameWithType> intentionally from your own source code.
- Don't create exceptions that can be thrown in debug mode but not release mode. To identify run-time errors during the development phase, use Debug Assert instead.

## Defining Exception Classes

Programs can throw a predefined exception class in the <xref:System> namespace (except where previously noted), or create their own exception classes by deriving from <xref:System.Exception>. The derived classes should define at least four constructors: one parameterless constructor, one that sets the message property, and one that sets both the <xref:System.Exception.Message%2A> and <xref:System.Exception.InnerException%2A> properties. The fourth constructor is used to serialize the exception. New exception classes should be serializable. For example:

:::code language="csharp" source="snippets/exceptions/InvalidDepartmentException.cs" ID="DefineExceptionClass":::

Add new properties to the exception class when the data they provide is useful to resolving the exception. If new properties are added to the derived exception class, `ToString()` should be overridden to return the added information.

## C# Language Specification

For more information, see [Exceptions](~/_csharpstandard/standard/exceptions.md) and [The throw statement](~/_csharpstandard/standard/statements.md#13106-the-throw-statement) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [Exception Hierarchy](../../../standard/exceptions/index.md)
