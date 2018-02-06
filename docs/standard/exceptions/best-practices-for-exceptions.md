---
title: "Best Practices for Exceptions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "exceptions, best practices"
ms.assetid: f06da765-235b-427a-bfb6-47cd219af539
caps.latest.revision: 28
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Best practices for exceptions

A well-designed app handles exceptions and errors to prevent app crashes. This section describes best practices for handling and creating exceptions.

## Use try/catch/finally blocks

Use `try`/`catch`/`finally` blocks around code that can potentially generate an exception. 

In `catch` blocks, always order exceptions from the most specific to the least specific.

Use a `finally` block to clean up resources, whether you can recover or not.

## Handle common conditions without throwing exceptions

For conditions that are likely to occur but might trigger an exception, consider handling them in a way that will avoid the exception. For example, if you try to close a connection that is already closed, you'll get an `InvalidOperationException`. You can avoid that by using an `if` statement to check the connection state before trying to close it.

[!code-cpp[Conceptual.Exception.Handling#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#2)]
[!code-csharp[Conceptual.Exception.Handling#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#2)]
[!code-vb[Conceptual.Exception.Handling#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#2)]  

If you don't check connection state before closing, you can catch the `InvalidOperationException` exception.

[!code-cpp[Conceptual.Exception.Handling#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#3)]
[!code-csharp[Conceptual.Exception.Handling#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#3)]
[!code-vb[Conceptual.Exception.Handling#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#3)]  

The method to choose depends on how often you expect the event to occur.

- Use exception handling if the event doesn't occur very often, that is, if the event is truly exceptional and indicates an error (such as an unexpected end-of-file). When you use exception handling, less code is executed in normal conditions.

- Check for error conditions in code if the event happens routinely and could be considered part of normal execution. When you check for common error conditions, less code is executed because you avoid exceptions.

## Design classes so that exceptions can be avoided

A class can provide methods or properties that enable you to avoid making a call that would trigger an exception. For example, a <xref:System.IO.FileStream> class provides methods that help determine whether the end of the file has been reached. These can be used to avoid the exception that is thrown if you read past the end of the file. The following example shows how to read to the end of a file without triggering an exception.

[!code-cpp[Conceptual.Exception.Handling#5](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#5)]
[!code-csharp[Conceptual.Exception.Handling#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#5)]
[!code-vb[Conceptual.Exception.Handling#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#5)]  

Another way to avoid exceptions is to return null for extremely common error cases instead of throwing an exception. An extremely common error case can be considered normal flow of control. By returning null in these cases, you minimize the performance impact to an app.

## Throw exceptions instead of returning an error code

Exceptions ensure that failures do not go unnoticed because calling code didn't check a return code. 

## Use the predefined .NET exception types

Introduce a new exception class only when a predefined one doesn't apply. For example:

- Throw an <xref:System.InvalidOperationException> exception if a property set or method call is not appropriate given the object's current state.

- Throw an <xref:System.ArgumentException> exception or one of the predefined classes that derive from <xref:System.ArgumentException> if invalid parameters are passed.

## End exception class names with the word `Exception`

When a custom exception is necessary, name it appropriately and derive it from the <xref:System.Exception> class. For example:

[!code-cpp[Conceptual.Exception.Handling#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#4)]
[!code-csharp[Conceptual.Exception.Handling#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#4)]
[!code-vb[Conceptual.Exception.Handling#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#4)]  

## Include three constructors in custom exception classes

Use at least the three common constructors when creating your own exception classes: the default constructor, a constructor that takes a string message, and a constructor that takes a string message and an inner exception.

* <xref:System.Exception.%23ctor>, which uses default values.
  
* <xref:System.Exception.%23ctor%28System.String%29>, which accepts a string message.  
  
* <xref:System.Exception.%23ctor%28System.String%2CSystem.Exception%29>, which accepts a string message and an inner exception.  
  
For an example, see [How to: Create User-Defined Exceptions](how-to-create-user-defined-exceptions.md).

## Ensure that exception data is available when code executes remotely

When you create user-defined exceptions, ensure that the metadata for the exceptions is available to code that is executing remotely. 

For example, on .NET implementations that support App Domains, exceptions may occur across App domains. Suppose App Domain A creates App Domain B, which executes code that throws an exception. For App Domain A to properly catch and handle the exception, it must be able to find the assembly that contains the exception thrown by App Domain B. If App Domain B throws an exception that is contained in an assembly under its application base, but not under App Domain A's application base, App Domain A will not be able to find the exception, and the common language runtime will throw a <xref:System.IO.FileNotFoundException> exception. To avoid this situation, you can deploy the assembly that contains the exception information in two ways:

- Put the assembly into a common application base shared by both app domains.

	\- or -

- If the domains do not share a common application base, sign the assembly that contains the exception information with a strong name and deploy the assembly into the global assembly cache.

## Include a localized description string in every exception

The error message that the user sees is derived from the description string of the exception that was thrown, and not from the name of the exception class.

## Use grammatically correct error messages

Write clear sentences and include ending punctuation. Each sentence in a description string of an exception should end in a period. For example, "The log table has overflowed." would be an appropriate description string.

## In custom exceptions, provide additional properties as needed

Provide additional properties for an exception (in addition to the description string) only when there's a programmatic scenario where the additional information is useful. For example, the <xref:System.IO.FileNotFoundException> provides the <xref:System.IO.FileNotFoundException.FileName> property.

## Place throw statements so that the stack trace will be helpful

The stack trace begins at the statement where the exception is thrown and ends at the `catch` statement that catches the exception.

## Use exception builder methods

It is common for a class to throw the same exception from different places in its implementation. To avoid excessive code, use helper methods that create the exception and return it. For example:

[!code-cpp[Conceptual.Exception.Handling#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.exception.handling/cpp/source.cpp#6)]
[!code-csharp[Conceptual.Exception.Handling#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.exception.handling/cs/source.cs#6)]
[!code-vb[Conceptual.Exception.Handling#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.exception.handling/vb/source.vb#6)]  
  
In some cases, it's more appropriate to use the exception's constructor to build the exception. An example is a global exception class such as <xref:System.ArgumentException>.

## Clean up intermediate results when throwing an exception

Callers should be able to assume that there are no side effects when an exception is thrown from a method. For example, if you have code that transfers money by withdrawing from one account and depositing in another account, and an exception is thrown while executing the deposit, you don't want the withdrawal to remain in effect.

```csharp
public void TransferFunds(Account from, Account to, decimal amount)
{
    from.Withdrawal(amount);
    // If the deposit fails, the withdrawal shouldn't remain in effect. 
    to.Deposit(amount);
}
```

One way to handle this situation is to catch any exceptions thrown by the deposit transaction and roll back the withdrawal.

```csharp
private static void TransferFunds(Account from, Account to, decimal amount)
{
    string withdrawalTrxID = from.Withdrawal(amount);
    try
    {
        to.Deposit(amount);
    }
    catch
    {
        from.RollbackTransaction(withdrawalTrxID);
        throw;
    }
}
```

This example illustrates the use of `throw` to re-throw the original exception, which can make it easier for callers to see the real cause of the problem without having to examine the <xref:System.Exception.InnerException> property. An alternative is to throw a new exception and include the original exception as the inner exception:

```csharp
catch (Exception ex)
{
    from.RollbackTransaction(withdrawalTrxID);
    throw new Exception("Withdrawal failed", ex);
}
```

## See Also  
[Exceptions](index.md)
