---
title: "Creating and Throwing Exceptions"
description: Learn about creating and throwing exceptions. Exceptions are used to indicate that an error has occurred while running a program.
ms.date: 09/28/2023
helpviewer_keywords:
  - "catching exceptions [C#]"
  - "throwing exceptions [C#]"
  - "exceptions [C#], creating"
  - "exceptions [C#], throwing"
---
# Create and throw exceptions

Exceptions are used to indicate that an error has occurred while running the program. Exception objects that describe an error are created and then *thrown* with the [`throw` statement or expression](../../language-reference/statements/exception-handling-statements.md#the-throw-statement). The runtime then searches for the most compatible exception handler.

Programmers should throw exceptions when one or more of the following conditions are true:

- The method can't complete its defined functionality. For example, if a parameter to a method has an invalid value:

  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="CantComplete":::

- An inappropriate call to an object is made, based on the object state. One example might be trying to write to a read-only file. In cases where an object state doesn't allow an operation, throw an instance of <xref:System.InvalidOperationException> or an object based on a derivation of this class. The following code is an example of a method that throws an <xref:System.InvalidOperationException> object:

  :::code language="csharp" source="snippets/exceptions/ProgramLog.cs" ID="ProgramLog":::

- When an argument to a method causes an exception. In this case, the original exception should be caught and an <xref:System.ArgumentException> instance should be created. The original exception should be passed to the constructor of the <xref:System.ArgumentException> as the <xref:System.Exception.InnerException%2A> parameter:

  :::code language="csharp" source="snippets/exceptions/Program.cs" ID="InvalidArg":::

> [!NOTE]
> The example above is for illustrative purposes. Index validating via exceptions is in most cases bad practice. Exceptions should be reserved to guard against exceptional program conditions, not for argument checking as above.

Exceptions contain a property named <xref:System.Exception.StackTrace%2A>. This string contains the name of the methods on the current call stack, together with the file name and line number where the exception was thrown for each method. A <xref:System.Exception.StackTrace%2A> object is created automatically by the common language runtime (CLR) from the point of the `throw` statement, so that exceptions must be thrown from the point where the stack trace should begin.

All exceptions contain a property named <xref:System.Exception.Message%2A>. This string should be set to explain the reason for the exception. Information that is sensitive to security shouldn't be put in the message text. In addition to <xref:System.Exception.Message%2A>, <xref:System.ArgumentException> contains a property named <xref:System.ArgumentException.ParamName%2A> that should be set to the name of the argument that caused the exception to be thrown. In a property setter, <xref:System.ArgumentException.ParamName%2A> should be set to `value`.

Public and protected methods throw exceptions whenever they can't complete their intended functions. The exception class thrown is the most specific exception available that fits the error conditions. These exceptions should be documented as part of the class functionality, and derived classes or updates to the original class should retain the same behavior for backward compatibility.

## Things to avoid when throwing exceptions

The following list identifies practices to avoid when throwing exceptions:

- Don't use exceptions to change the flow of a program as part of ordinary execution. Use exceptions to report and handle error conditions.
- Exceptions shouldn't be returned as a return value or parameter instead of being thrown.
- Don't throw <xref:System.Exception?displayProperty=nameWithType>, <xref:System.SystemException?displayProperty=nameWithType>, <xref:System.NullReferenceException?displayProperty=nameWithType>, or <xref:System.IndexOutOfRangeException?displayProperty=nameWithType> intentionally from your own source code.
- Don't create exceptions that can be thrown in debug mode but not release mode. To identify run-time errors during the development phase, use Debug Assert instead.

## Throw exceptions from task-returning methods

Methods that return <xref:System.Threading.Tasks.Task%601> objects have some special considerations when it comes to exceptions. Exceptions that are thrown outside of the async state machine, that is, before `await` is called, emerge synchronously from the method, just like a non task-returning method. However, exceptions that are thrown within the async state machine are stored in the task and don't emerge until, for example, the task is awaited. For more information about stored exceptions, see [Asynchronous exceptions](../../asynchronous-programming/index.md#asynchronous-exceptions).

We recommend that you validate arguments and throw any corresponding arguments, such as <xref:System.ArgumentException>, <xref:System.ArgumentNullException>, and <xref:System.ObjectDisposedException>, before entering the asynchronous part of your methods. That is, these exceptions should emerge synchronously. The following code snippet shows an example where the <xref:System.ArgumentException> exceptions emerge synchronously, whereas the <xref:System.InvalidOperationException> is stored in the returned task.

```csharp
public static Task<Toast> ToastBreadAsync(int slices, int toastTime)
{
    if (slices < 1 || slices > 4)
        throw new ArgumentException("You must specify between 1 and 4 slices of bread.", nameof(slices));
    if (toastTime < 1)
        throw new ArgumentException("Toast time is too short.", nameof(toastTime));

    return ToastBreadAsyncCore(slices, toastTime);
}

private static async Task<Toast> ToastBreadAsyncCore(int slices, int time)
{
    for (int slice = 0; slice < slices; slice++)
    {
        Console.WriteLine("Putting a slice of bread in the toaster");
    }
    // Start toasting.
    await Task.Delay(time);
    if (time > 2000)
        throw new InvalidOperationException("The toaster is on fire!");

    return new Toast();
}
```

## Define exception classes

Programs can throw a predefined exception class in the <xref:System> namespace (except where previously noted), or create their own exception classes by deriving from <xref:System.Exception>. The derived classes should define at least three constructors: one parameterless constructor, one that sets the message property, and one that sets both the <xref:System.Exception.Message%2A> and <xref:System.Exception.InnerException%2A> properties. For example:

:::code language="csharp" source="snippets/exceptions/InvalidDepartmentException.cs" ID="DefineExceptionClass":::

Add new properties to the exception class when the data they provide is useful to resolving the exception. If new properties are added to the derived exception class, `ToString()` should be overridden to return the added information.

## C# language specification

For more information, see [Exceptions](~/_csharpstandard/standard/exceptions.md) and [The throw statement](~/_csharpstandard/standard/statements.md#13106-the-throw-statement) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [Exception Hierarchy](../../../standard/exceptions/index.md)
