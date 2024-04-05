---
title: System.Exception class
description: Learn about the System.Exception class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
  - FSharp
---
# System.Exception class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Exception> class is the base class for all exceptions. When an error occurs, either the system or the currently executing application reports it by throwing an exception that contains information about the error. After an exception is thrown, it is handled by the application or by the default exception handler.

## Errors and exceptions

Run-time errors can occur for a variety of reasons. However, not all errors should be handled as exceptions in your code. Here are some categories of errors that can occur at run time and the appropriate ways to respond to them.

- **Usage errors.** A usage error represents an error in program logic that can result in an exception. However, the error should be addressed not through exception handling but by modifying the faulty code. For example, the override of the <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method in the following example assumes that the `obj` argument must always be non-null.

  :::code language="csharp" source="./snippets/System/Exception/Overview/csharp/usageerrors1.cs" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/usageerrors1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Exception/Overview/vb/usageerrors1.vb" id="Snippet4":::

  The <xref:System.NullReferenceException> exception that results when `obj` is `null` can be eliminated by modifying the source code to explicitly test for null before calling the <xref:System.Object.Equals%2A?displayProperty=nameWithType> override and then re-compiling. The following example contains the corrected source code that handles a `null` argument.

  :::code language="csharp" source="./snippets/System/Exception/Overview/csharp/usageerrors2.cs" interactive="try-dotnet" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/usageerrors2.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Exception/Overview/vb/usageerrors2.vb" id="Snippet5":::

  Instead of using exception handling for usage errors, you can use the <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> method to identify usage errors in debug builds, and the <xref:System.Diagnostics.Trace.Assert%2A?displayProperty=nameWithType> method to identify usage errors in both debug and release builds. For more information, see [Assertions in Managed Code](/visualstudio/debugger/assertions-in-managed-code).

- **Program errors.** A program error is a run-time error that cannot necessarily be avoided by writing bug-free code.

  In some cases, a program error may reflect an expected or routine error condition. In this case, you may want to avoid using exception handling to deal with the program error and instead retry the operation. For example, if the user is expected to input a date in a particular format, you can parse the date string by calling the <xref:System.DateTime.TryParseExact%2A?displayProperty=nameWithType> method, which returns a <xref:System.Boolean> value that indicates whether the parse operation succeeded, instead of using the <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method, which throws a <xref:System.FormatException> exception if the date string cannot be converted to a <xref:System.DateTime> value. Similarly, if a user tries to open a file that does not exist, you can first call the <xref:System.IO.File.Exists%2A?displayProperty=nameWithType> method to check whether the file exists and, if it does not, prompt the user whether they want to create it.

  In other cases, a program error reflects an unexpected error condition that can be handled in your code. For example, even if you've checked to ensure that a file exists, it may be deleted before you can open it, or it may be corrupted. In that case, trying to open the file by instantiating a <xref:System.IO.StreamReader> object or calling the <xref:System.IO.File.Open%2A> method may throw a <xref:System.IO.FileNotFoundException> exception. In these cases, you should use exception handling to recover from the error.

- **System failures.** A system failure is a run-time error that cannot be handled programmatically in a meaningful way. For example, any method can throw an <xref:System.OutOfMemoryException> exception if the common language runtime is unable to allocate additional memory. Ordinarily, system failures are not handled by using exception handling. Instead, you may be able to use an event such as <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType> and call the <xref:System.Environment.FailFast%2A?displayProperty=nameWithType> method to log exception information and notify the user of the failure before the application terminates.

## Try/catch blocks

The common language runtime provides an exception handling model that is based on the representation of exceptions as objects, and the separation of program code and exception handling code into `try` blocks and `catch` blocks. There can be one or more `catch` blocks, each designed to handle a particular type of exception, or one block designed to catch a more specific exception than another block.

If an application handles exceptions that occur during the execution of a block of application code, the code must be placed within a `try` statement and is called a `try` block. Application code that handles exceptions thrown by a `try` block is placed within a `catch` statement and is called a `catch` block. Zero or more `catch` blocks are associated with a `try` block, and each `catch` block includes a type filter that determines the types of exceptions it handles.

When an exception occurs in a `try` block, the system searches the associated `catch` blocks in the order they appear in application code, until it locates a `catch` block that handles the exception. A `catch` block handles an exception of type `T` if the type filter of the catch block specifies `T` or any type that `T` derives from. The system stops searching after it finds the first `catch` block that handles the exception. For this reason, in application code, a `catch` block that handles a type must be specified before a `catch` block that handles its base types, as demonstrated in the example that follows this section. A catch block that handles `System.Exception` is specified last.

If none of the `catch` blocks associated with the current `try` block handle the exception, and the current `try` block is nested within other `try` blocks in the current call, the `catch` blocks associated with the next enclosing `try` block are searched. If no `catch` block for the exception is found, the system searches previous nesting levels in the current call. If no `catch` block for the exception is found in the current call, the exception is passed up the call stack, and the previous stack frame is searched for a `catch` block that handles the exception. The search of the call stack continues until the exception is handled or until no more frames exist on the call stack. If the top of the call stack is reached without finding a `catch` block that handles the exception, the default exception handler handles it and the application terminates.

### F# try..with expression

F# does not use `catch` blocks. Instead, a raised exception is pattern matched using a single `with` block. As this is an expression, rather than a statement, all paths must return the same type. To learn more, see [The try...with Expression](../../fsharp/language-reference/exception-handling/the-try-with-expression.md).

## Exception type features

Exception types support the following features:

- Human-readable text that describes the error. When an exception occurs, the runtime makes a text message available to inform the user of the nature of the error and to suggest action to resolve the problem. This text message is held in the <xref:System.Exception.Message> property of the exception object. During the creation of the exception object, you can pass a text string to the constructor to describe the details of that particular exception. If no error message argument is supplied to the constructor, the default error message is used. For more information, see the <xref:System.Exception.Message> property.

- The state of the call stack when the exception was thrown. The <xref:System.Exception.StackTrace> property carries a stack trace that can be used to determine where the error occurs in the code. The stack trace lists all the called methods and the line numbers in the source file where the calls are made.

## Exception class properties

The <xref:System.Exception> class includes a number of properties that help identify the code location, the type, the help file, and the reason for the exception: <xref:System.Exception.StackTrace%2A>, <xref:System.Exception.InnerException%2A>, <xref:System.Exception.Message%2A>, <xref:System.Exception.HelpLink%2A>, <xref:System.Exception.HResult%2A>, <xref:System.Exception.Source%2A>, <xref:System.Exception.TargetSite%2A>, and <xref:System.Exception.Data%2A>.

When a causal relationship exists between two or more exceptions, the <xref:System.Exception.InnerException> property maintains this information. The outer exception is thrown in response to this inner exception. The code that handles the outer exception can use the information from the earlier inner exception to handle the error more appropriately. Supplementary information about the exception can be stored as a collection of key/value pairs in the <xref:System.Exception.Data> property.

The error message string that is passed to the constructor during the creation of the exception object should be localized and can be supplied from a resource file by using the <xref:System.Resources.ResourceManager> class. For more information about localized resources, see the [Creating Satellite Assemblies](/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps) and [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps) topics.

To provide the user with extensive information about why the exception occurred, the <xref:System.Exception.HelpLink> property can hold a URL (or URN) to a help file.

The <xref:System.Exception> class uses the HRESULT `COR_E_EXCEPTION`, which has the value 0x80131500.

For a list of initial property values for an instance of the <xref:System.Exception> class, see the <xref:System.Exception.%23ctor%2A> constructors.

## Performance considerations

Throwing or handling an exception consumes a significant amount of system resources and execution time. Throw exceptions only to handle truly extraordinary conditions, not to handle predictable events or flow control. For example, in some cases, such as when you're developing a class library, it's reasonable to throw an exception if a method argument is invalid, because you expect your method to be called with valid parameters. An invalid method argument, if it is not the result of a usage error, means that something extraordinary has occurred. Conversely, do not throw an exception if user input is invalid, because you can expect users to occasionally enter invalid data. Instead, provide a retry mechanism so users can enter valid input. Nor should you use exceptions to handle usage errors. Instead, use [assertions](/visualstudio/debugger/assertions-in-managed-code) to identify and correct usage errors.

In addition, do not throw an exception when a return code is sufficient; do not convert a return code to an exception; and do not routinely catch an exception, ignore it, and then continue processing.

## Re-throw an exception

In many cases, an exception handler simply wants to pass the exception on to the caller. This most often occurs in:

- A class library that in turn wraps calls to methods in the .NET class library or other class libraries.

- An application or library that encounters a fatal exception. The exception handler can log the exception and then re-throw the exception.

The recommended way to re-throw an exception is to simply use the [throw](/dotnet/csharp/language-reference/keywords/throw) statement in C#, the [reraise](../../fsharp/language-reference/exception-handling/the-raise-function.md#reraising-an-exception) function in F#, and the [Throw](../../visual-basic/language-reference/statements/throw-statement.md) statement in Visual Basic without including an expression. This ensures that all call stack information is preserved when the exception is propagated to the caller. The following example illustrates this. A string extension method, `FindOccurrences`, wraps one or more calls to <xref:System.String.IndexOf%28System.String%2CSystem.Int32%29?displayProperty=nameWithType> without validating its arguments beforehand.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/rethrow1.cs" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/rethrow1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/rethrow1.vb" id="Snippet6":::

A caller then calls `FindOccurrences` twice. In the second call to `FindOccurrences`, the caller passes a `null` as the search string, which causes the <xref:System.String.IndexOf%28System.String%2CSystem.Int32%29?displayProperty=nameWithType> method to throw an <xref:System.ArgumentNullException> exception. This exception is handled by the `FindOccurrences` method and passed back to the caller. Because the throw statement is used with no expression, the output from the example shows that the call stack is preserved.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/rethrow1.cs" id="Snippet7":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/rethrow1.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/rethrow1.vb" id="Snippet7":::

In contrast, if the exception is re-thrown by using this statement:

```csharp
throw e;
```

```vb
Throw e
```

```fsharp
raise e
```

...then the full call stack is not preserved, and the example would generate the following output:

```output
'a' occurs at the following character positions: 4, 7, 15

An exception (ArgumentNullException) occurred.
Message:
   Value cannot be null.
Parameter name: value

Stack Trace:
      at Library.FindOccurrences(String s, String f)
   at Example.Main()
```

A slightly more cumbersome alternative is to throw a new exception, and to preserve the original exception's call stack information in an inner exception. The caller can then use the new exception's <xref:System.Exception.InnerException> property to retrieve stack frame and other information about the original exception. In this case, the throw statement is:

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/rethrow3.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/rethrow3.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/rethrow3.vb" id="Snippet8":::

The user code that handles the exception has to know that the <xref:System.Exception.InnerException> property contains information about the original exception, as the following exception handler illustrates.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/rethrow3.cs" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/rethrow3.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/rethrow3.vb" id="Snippet9":::

## Choose standard exceptions

When you have to throw an exception, you can often use an existing exception type in .NET instead of implementing a custom exception. You should use a standard exception type under these two conditions:

- You're throwing an exception that is caused by a usage error (that is, by an error in program logic made by the developer who is calling your method). Typically, you would throw an exception such as <xref:System.ArgumentException>, <xref:System.ArgumentNullException>, <xref:System.InvalidOperationException>, or <xref:System.NotSupportedException>. The string you supply to the exception object's constructor when instantiating the exception object should describe the error so that the developer can fix it. For more information, see the <xref:System.Exception.Message> property.

- You're handling an error that can be communicated to the caller with an existing .NET exception. You should throw the most derived exception possible. For example, if a method requires an argument to be a valid member of an enumeration type, you should throw an <xref:System.ComponentModel.InvalidEnumArgumentException> (the most derived class) rather than an <xref:System.ArgumentException>.

The following table lists common exception types and the conditions under which you would throw them.

|Exception|Condition|
|---------------|---------------|
|<xref:System.ArgumentException>|A non-null argument that is passed to a method is invalid.|
|<xref:System.ArgumentNullException>|An argument that is passed to a method is `null`.|
|<xref:System.ArgumentOutOfRangeException>|An argument is outside the range of valid values.|
|<xref:System.IO.DirectoryNotFoundException>|Part of a directory path is not valid.|
|<xref:System.DivideByZeroException>|The denominator in an integer or <xref:System.Decimal> division operation is zero.|
|<xref:System.IO.DriveNotFoundException>|A drive is unavailable or does not exist.|
|<xref:System.IO.FileNotFoundException>|A file does not exist.|
|<xref:System.FormatException>|A value is not in an appropriate format to be converted from a string by a conversion method such as `Parse`.|
|<xref:System.IndexOutOfRangeException>|An index is outside the bounds of an array or collection.|
|<xref:System.InvalidOperationException>|A method call is invalid in an object's current state.|
|<xref:System.Collections.Generic.KeyNotFoundException>|The specified key for accessing a member in a collection cannot be found.|
|<xref:System.NotImplementedException>|A method or operation is not implemented.|
|<xref:System.NotSupportedException>|A method or operation is not supported.|
|<xref:System.ObjectDisposedException>|An operation is performed on an object that has been disposed.|
|<xref:System.OverflowException>|An arithmetic, casting, or conversion operation results in an overflow.|
|<xref:System.IO.PathTooLongException>|A path or file name exceeds the maximum system-defined length.|
|<xref:System.PlatformNotSupportedException>|The operation is not supported on the current platform.|
|<xref:System.RankException>|An array with the wrong number of dimensions is passed to a method.|
|<xref:System.TimeoutException>|The time interval allotted to an operation has expired.|
|<xref:System.UriFormatException>|An invalid Uniform Resource Identifier (URI) is used.|

## Implement custom exceptions

In the following cases, using an existing .NET exception to handle an error condition is not adequate:

- When the exception reflects a unique program error that cannot be mapped to an existing .NET exception.

- When the exception requires handling that is different from the handling that is appropriate for an existing .NET exception, or the exception must be disambiguated from a similar exception. For example, if you throw an <xref:System.ArgumentOutOfRangeException> exception when parsing the numeric representation of a string that is out of range of the target integral type, you would not want to use the same exception for an error that results from the caller not supplying the appropriate constrained values when calling the method.

The <xref:System.Exception> class is the base class of all exceptions in .NET. Many derived classes rely on the inherited behavior of the members of the <xref:System.Exception> class; they do not override the members of <xref:System.Exception>, nor do they define any unique members.

To define your own exception class:

1. Define a class that inherits from <xref:System.Exception>. If necessary, define any unique members needed by your class to provide additional information about the exception. For example, the <xref:System.ArgumentException> class includes a <xref:System.ArgumentException.ParamName> property that specifies the name of the parameter whose argument caused the exception, and the <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> property includes a <xref:System.Text.RegularExpressions.RegexMatchTimeoutException.MatchTimeout> property that indicates the time-out interval.

2. If necessary, override any inherited members whose functionality you want to change or modify. Note that most existing derived classes of <xref:System.Exception> do not override the behavior of inherited members.

3. Determine whether your custom exception object is serializable. Serialization enables you to save information about the exception and permits exception information to be shared by a server and a client proxy in a remoting context. To make the exception object serializable, mark it with the <xref:System.SerializableAttribute> attribute.

4. Define the constructors of your exception class. Typically, exception classes have one or more of the following constructors:

   - <xref:System.Exception.%23ctor>, which uses default values to initialize the properties of a new exception object.

   - <xref:System.Exception.%23ctor%28System.String%29>, which initializes a new exception object with a specified error message.

   - <xref:System.Exception.%23ctor%28System.String%2CSystem.Exception%29>, which initializes a new exception object with a specified error message and inner exception.

   - <xref:System.Exception.%23ctor%28System.Runtime.Serialization.SerializationInfo%2CSystem.Runtime.Serialization.StreamingContext%29>, which is a `protected` constructor that initializes a new exception object from serialized data. You should implement this constructor if you've chosen to make your exception object serializable.

The following example illustrates the use of a custom exception class. It defines a `NotPrimeException` exception that is thrown when a client tries to retrieve a sequence of prime numbers by specifying a starting number that is not prime. The exception defines a new property, `NonPrime`, that returns the non-prime number that caused the exception. Besides implementing a protected parameterless constructor and a constructor with <xref:System.Runtime.Serialization.SerializationInfo> and <xref:System.Runtime.Serialization.StreamingContext> parameters for serialization, the `NotPrimeException` class defines three additional constructors to support the `NonPrime` property. Each constructor calls a base class constructor in addition to preserving the value of the non-prime number. The `NotPrimeException` class is also marked with the <xref:System.SerializableAttribute> attribute.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/notprimeexception.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/notprimeexception.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/notprimeexception.vb" id="Snippet1":::

The `PrimeNumberGenerator` class shown in the following example uses the Sieve of Eratosthenes to calculate the sequence of prime numbers from 2 to a limit specified by the client in the call to its class constructor. The `GetPrimesFrom` method returns all prime numbers that are greater than or equal to a specified lower limit, but throws a `NotPrimeException` if that lower limit is not a prime number.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/primenumbergenerator.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/primenumbergenerator.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/primenumbergenerator.vb" id="Snippet2":::

The following example makes two calls to the `GetPrimesFrom` method with non-prime numbers, one of which crosses application domain boundaries. In both cases, the exception is thrown and successfully handled in client code.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/example.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/example.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/example.vb" id="Snippet3":::

## Examples

The following example demonstrates a `catch` (`with` in F#) block that is defined to handle <xref:System.ArithmeticException> errors. This `catch` block also catches <xref:System.DivideByZeroException> errors, because <xref:System.DivideByZeroException> derives from <xref:System.ArithmeticException> and there is no `catch` block explicitly defined for <xref:System.DivideByZeroException> errors.

:::code language="csharp" source="./snippets/System/Exception/Overview/csharp/catchexception.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Exception/Overview/fsharp/catchexception.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Exception/Overview/vb/catchexception.vb" id="Snippet1":::
