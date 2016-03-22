# Handling and throwing exceptions

Applications must be able to handle errors that occur during execution in a consistent manner. The common language runtime provides a model for notifying applications of errors in a uniform way. All .NET Framework operations indicate failure by throwing exceptions.

## Changes for .NET Core
Exception handling for .NET Core works the same as .NET Framework with the following exceptions.
- You no longer should (or can) add a serialization constructor.
- The SystemException and ApplicationException classes have been removed.

## Exceptions in the .NET Framework

An exception is any error condition or unexpected behavior that is encountered by an executing program. Exceptions can be raised because of a fault in your code or in code that you call (such as a shared library), unavailable operating system resources, unexpected conditions the common language runtime encounters (such as code that cannot be verified), and so on. Your application can recover from some of these conditions, but not from others. Although you can recover from most application exceptions, you cannot recover from most runtime exceptions.

In the .NET Framework, an exception is an object that inherits from the [System.Exception](https://msdn.microsoft.com/en-us/library/system.exception) class. An exception is thrown from an area of code where a problem has occurred. The exception is passed up the stack until the application handles it or the program terminates.

## Exceptions vs. traditional error-handling methods

Traditionally, a language's error-handling model relied on either the language's unique way of detecting errors and locating handlers for them, or on the error-handling mechanism provided by the operating system. The runtime implements exception handling with the following features:

- Handles exceptions without regard for the language that generates the exception or the language that handles the exception.

- Does not require any particular language syntax for handling exceptions, but allows each language to define its own syntax.

- Allows exceptions to be thrown across process and even machine boundaries.

Exceptions offer several advantages over other methods of error notification, such as return codes. Failures do not go unnoticed. Invalid values do not continue to propagate through the system. You do not have to check return codes. Finally, exception-handling code can be easily added to increase program reliability.

Because execution threads routinely traverse managed and unmanaged blocks of code, the runtime can throw or catch exceptions in either managed or unmanaged code. Unmanaged code can include both C++-style SEH Exceptions and COM-based HRESULTS.

## How the runtime manages exceptions

The runtime uses an exception-handling model based on exception objects and protected blocks of code. An [Exception](https://msdn.microsoft.com/en-us/library/system.exception) object is created to represent an exception when it occurs.

The runtime creates an exception information table for each executable. Each method of the executable has an associated array of exception-handling information (which can be empty) in the exception information table. Each entry in the array describes a protected block of code, any exception filters associated with that code, and any exception handlers (**catch** statements). This exception table is extremely efficient and does not cause any performance penalty in processor time or in memory use when an exception does not occur. You use resources only when an exception occurs.

The exception information table represents four types of exception handlers for protected blocks:

- A **finally** handler that executes whenever the block exits, whether that occurs by normal control flow or by an unhandled exception.

- A fault handler that must execute if an exception occurs, but does not execute on completion of normal control flow.

- A type-filtered handler that handles any exception of a specified class or any of its derived classes.

- A user-filtered handler that runs user-specified code to determine whether the exception should be handled by the associated handler or should be passed to the next protected block.

Each language implements these exception handlers according to its specifications. For example, Visual Basic provides access to the user-filtered handler through a variable comparison (using the **When** keyword) in the **catch** statement; C# does not implement the user-filtered handler.

When an exception occurs, the runtime begins a two-step process:

1. The runtime searches the array for the first protected block that does the following:

  - Protects a region that includes the currently executing instruction.

  - Contains an exception handler or contains a filter that handles the exception.

1. If a match occurs, the runtime creates an Exception object that describes the exception. The runtime then executes all **finally** or **fault** statements between the statement where the exception occurred and the statement that handles the exception. Note that the order of exception handlers is important; the innermost exception handler is evaluated first. Also note that exception handlers can access the local variables and local memory of the routine that catches the exception, but any intermediate values at the time the exception is thrown are lost.

  If no match occurs in the current method, the runtime searches each caller of the current method, and it continues this path all the way up the stack. If no caller has a match, the runtime lets the debugger access the exception. If the debugger does not attach to the exception, the runtime raises the [AppDomain.UnhandledException](https://msdn.microsoft.com/en-us/library/system.appdomain.unhandledexception) event. If there are no listeners for this event, the runtime dumps a stack trace and ends the application.

## Filtering runtime exceptions

You can filter the exceptions you catch and handle either by type or by some user-defined criteria.

Type-filtered handlers manage a particular type of exception (or classes derived from it). The following example shows a type-filtered handler that is designed to catch a specific exception, in this case, the [FileNotFoundException](https://msdn.microsoft.com/en-us/library/system.io.filenotfoundexception).

## Example

C#
```C#
catch (FileNotFoundException e)
{
    Console.WriteLine("[Data File Missing] {0}", e);
}
```

Visual Basic
```VB
Catch e As FileNotFoundException
    Console.WriteLine("[Data File Missing] {0}", e)
```

C++
```VC
catch (FileNotFoundException^ e)
{
    Console::WriteLine("[Data File Missing] {0}", e);
}
```

User-filtered exception handlers catch and handle exceptions based on requirements you define for the exception. For more information about filtering exceptions in this way, see Using Specific Exceptions in a Catch Block.

## Related topics

| Title | Description |
| ----- | ----------- |
| Exception Class and Properties | Describes the elements of an exception object. |
| Exception Hierarchy | Describes the exceptions that most exceptions derive from. |
| Exception Handling Fundamentals | Explains how to handle exceptions using catch, throw, and finally statements. |
| Best Practices for Exceptions | Describes suggested methods for handling exceptions. |
| Handling COM Interop Exceptions | Describes how to handle exceptions thrown and caught in unmanaged code. |
| How to Map HRESULTs and Exceptions | Describes the mapping of exceptions between managed and unmanaged code. |
