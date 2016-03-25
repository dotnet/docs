# Handling and throwing exceptions

Applications must be able to handle errors that occur during execution in a consistent manner. The common language runtime (CLR) provides a model for notifying applications of errors in a uniform way. All .NET Core operations indicate failure by throwing exceptions.

## Changes for .NET Core
Exception handling for .NET Core works the same as .NET Framework with the following exceptions.
- You no longer should (or can) add a serialization constructor.
- The **SystemException** and **ApplicationException** classes have been removed.

## Exceptions in .NET Core

An exception is any error condition or unexpected behavior that is encountered by an executing program. Exceptions can be raised because of a fault in your code or in code that you call (such as a shared library), unavailable operating system resources, unexpected conditions the CLR encounters (such as code that cannot be verified), and so on. Your application can recover from some of these conditions, but not from others. Although you can recover from most application exceptions, you cannot recover from most runtime exceptions.

In .NET Core, an exception is an object that inherits from the [System.Exception](http://dotnet.github.io/api/System.Exception.html) class. An exception is thrown from an area of code where a problem has occurred. The exception is passed up the stack until the application handles it or the program terminates.

## Exceptions vs. traditional error-handling methods

Traditionally, a language's error-handling model relied on either the language's unique way of detecting errors and locating handlers for them, or on the error-handling mechanism provided by the operating system. The CLR implements exception handling with the following features:

- Handles exceptions without regard for the language that generates the exception or the language that handles the exception.

- Does not require any particular language syntax for handling exceptions, but allows each language to define its own syntax.

- Allows exceptions to be thrown across process and even machine boundaries.

Exceptions offer several advantages over other methods of error notification, such as return codes. Failures do not go unnoticed. Invalid values do not continue to propagate through the system. You do not have to check return codes. Finally, exception-handling code can be easily added to increase program reliability.

Because execution threads routinely traverse managed and unmanaged blocks of code, the runtime can throw or catch exceptions in either managed or unmanaged code. Unmanaged code can include both C++-style SEH Exceptions and COM-based HRESULTS.

## How the runtime manages exceptions

The runtime uses an exception-handling model based on exception objects and protected blocks of code. An [Exception](http://dotnet.github.io/api/System.Exception.html) object is created to represent an exception when it occurs.

The runtime creates an exception information table for each executable. Each method of the executable has an associated array of exception-handling information (which can be empty) in the exception information table. Each entry in the array describes a protected block of code, any exception filters associated with that code, and any exception handlers (**catch** statements). This exception table is extremely efficient and does not cause any performance penalty in processor time or in memory use when an exception does not occur. You use resources only when an exception occurs.

The exception information table represents four types of exception handlers for protected blocks:

- A **finally** handler that executes whenever the block exits, whether that occurs by normal control flow or by an unhandled exception.

- A fault handler that must execute if an exception occurs, but does not execute on completion of normal control flow.

- A type-filtered handler that handles any exception of a specified class or any of its derived classes.

- A user-filtered handler that runs user-specified code to determine whether the exception should be handled by the associated handler or should be passed to the next protected block.

Each language implements these exception handlers according to its specifications. When an exception occurs, the runtime begins a two-step process:

1. The runtime searches the array for the first protected block that does the following:

  - Protects a region that includes the currently executing instruction.

  - Contains an exception handler or contains a filter that handles the exception.

1. If a match occurs, the runtime creates an **Exception** object that describes the exception. The runtime then executes all **finally** or **fault** statements between the statement where the exception occurred and the statement that handles the exception. Note that the order of exception handlers is important; the innermost exception handler is evaluated first. Also note that exception handlers can access the local variables and local memory of the routine that catches the exception, but any intermediate values at the time the exception is thrown are lost.

  If no match occurs in the current method, the runtime searches each caller of the current method, and it continues this path all the way up the stack. If no caller has a match, the runtime lets the debugger access the exception.

## Filtering runtime exceptions

You can filter the exceptions you catch and handle either by type or by some user-defined criteria.

Type-filtered handlers manage a particular type of exception (or classes derived from it). The following example shows a type-filtered handler that is designed to catch a specific exception, in this case, the [FileNotFoundException](http://dotnet.github.io/api/System.IO.FileNotFoundException.html).

## Example

C#
```C#
catch (FileNotFoundException e)
{
    Console.WriteLine("[Data File Missing] {0}", e);
}
```

User-filtered exception handlers catch and handle exceptions based on requirements you define for the exception. For more information about filtering exceptions in this way, see [Using Specific Exceptions in a Catch Block](exceptions-catch-specific-exceptions.md).

## Related topics

| Title | Description |
| ----- | ----------- |
| [Exception class and properties](exceptions-properties.md) | Describes the elements of an exception object. |
| [Exception hierarchy](exceptions-hierarchy.md) | Describes the exceptions that most exceptions derive from. |
| [How to use the try/catch block to catch exceptions](exceptions-use-try-catch-block.md) | Describes how to place sections of code that might throw exceptions in a Try block and then add code that handles exceptions in a Catch block. |
| [How to use specific exceptions in a catch block](exceptions-catch-specific-exceptions.md) | Describes how put catch blocks targeted to specific exceptions before a general exception catch block to help avoid the compiler issuing an error. |
| [How to explicitly throw exceptions](exceptions-throw-exceptions.md) | Describes how to throw an exception using the **throw** statement. |
| [How to create user-defined exceptions](exceptions-create-user-defined.md) | Describes how to create your own user-defined exceptions to programmatically distinguish between certain error conditions. |
| [How to use finally blocks](exceptions-use-finally-blocks.md) | Describes how to use a Finally block to do resource cleanup, such as when lines of code you expect to always be called, such as closing a file, are interrupted by an exception. |
| [Best practices for exceptions](exceptions-best-practices.md) | Describes suggested methods for handling exceptions. |
