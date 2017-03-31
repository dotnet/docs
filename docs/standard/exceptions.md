---
title: Handling and throwing exceptions in .NET
description: Understand how to use exceptions in .NET
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: bf116df6-0042-46bf-be13-b69864816210
---

# Handling and throwing exceptions in .NET

Applications must be able to handle errors that occur during execution in a consistent manner. .NET provides a model for notifying applications of errors in a uniform way: .NET operations indicate failure by throwing exceptions.

## Exceptions

An exception is any error condition or unexpected behavior that is encountered by an executing program. Exceptions can be thrown because of a fault in your code or in code that you call (such as a shared library), unavailable operating system resources, unexpected conditions that the runtime encounters (such as code that cannot be verified), and so on. Your application can recover from some of these conditions, but not from others. Although you can recover from most application exceptions, you cannot recover from most runtime exceptions.

In .NET, an exception is an object that inherits from the [System.Exception](xref:System.Exception) class. An exception is thrown from an area of code where a problem has occurred. The exception is passed up the stack until the application handles it or the program terminates.

## Exceptions vs. traditional error-handling methods

Traditionally, a language's error-handling model relied on either the language's unique way of detecting errors and locating handlers for them, or on the error-handling mechanism provided by the operating system. The way .NET implements exception handling provides the following advantages:

- Exception throwing and handling works the same for .NET programming languages.

- Does not require any particular language syntax for handling exceptions, but allows each language to define its own syntax.

- Exceptions can be thrown across process and even machine boundaries.

- Exception-handling code can be added to an application to increase program reliability.

Exceptions offer advantages over other methods of error notification, such as return codes. Failures do not go unnoticed because if an exception is thrown and you don't handle it, the runtime terminates your application. Invalid values do not continue to propagate through the system as a result of code that fails to check for a failure return code. 

## Exception class and properties

The @System.Exception class is the base class from which exceptions inherit. For example, the @System.InvalidCastException class hierarchy is as follows:

```
Object
  Exception
    SystemException
       InvalidCastException
```

The @System.Exception class has the following properties that help make understanding an exception easier.

| Property Name | Description |
| ------------- | ----------- |
| @System.Exception.Data | An @System.Collections.IDictionary that holds arbitrary data in key-value pairs. |
| @System.Exception.HelpLink | Can hold a URL (or URN) to a help file that provides extensive information about the cause of an exception. |
| @System.Exception.InnerException | This property can be used to create and preserve a series of exceptions during exception handling. You can use it to create a new exception that contains previously caught exceptions. The original exception can be captured by the second exception in the @System.Exception.InnerException property, allowing code that handles the second exception to examine the additional information. For example, suppose you have a method that receives an argument that's improperly formatted.  The code tries to read the argument, but an exception is thrown. The method catches the exception and throws a @System.FormatException. To improve the caller's ability to determine the reason an exception is thrown, it is sometimes desirable for a method to catch an exception thrown by a helper routine and then throw an exception more indicative of the error that has occurred. A new and more meaningful exception can be created, where the inner exception reference can be set to the original exception. This more meaningful exception can then be thrown to the caller. Note that with this functionality, you can create a series of linked exceptions that ends with the exception that was thrown first. |
| @System.Exception.Message | Provides details about the cause of an exception.
| @System.Exception.Source | Gets or sets the name of the application or the object that causes the error. |
| @System.Exception.StackTrace | Contains a stack trace that can be used to determine where an error occurred. The stack trace includes the source file name and program line number if debugging information is available. |

Most of the classes that inherit from @System.Exception do not implement additional members or provide additional functionality; they simply inherit from @System.Exception. Therefore, the most important information for an exception can be found in the hierarchy of exception classes, the exception name, and the information contained in the exception.

It is recommended to throw and catch only objects that derive from @System.Exception, but you can throw any object that derives from the @System.Object class as an exception. Note that not all languages support throwing and catching objects that do not derive from @System.Exception.

## Common Exceptions

The following table lists some common exceptions with examples of what can cause them.

| Exception type | Base type | Description | Example |
| -------------- | --------- | ----------- | ------- |
| @System.Exception | @System.Object | Base class for all exceptions. | None (use a derived class of this exception). |
| @System.IndexOutOfRangeException | @System.Exception | Thrown by the runtime only when an array is indexed improperly. | Indexing an array outside its valid range: `arr[arr.Length+1]` |
| @System.NullReferenceException | @System.Exception | Thrown by the runtime only when a null object is referenced. | `object o = null; o.ToString();` |
| @System.InvalidOperationException | @System.Exception | Thrown by methods when in an invalid state. | Calling `Enumerator.GetNext()` after removing an Item from the underlying collection. |
| @System.ArgumentException | @System.Exception | Base class for all argument exceptions. | None (use a derived class of this exception). |
| @System.ArgumentNullException | @System.Exception | Thrown by methods that do not allow an argument to be null. | `String s = null; "Calculate".IndexOf (s);` |
| @System.ArgumentOutOfRangeException | @System.Exception | Thrown by methods that verify that arguments are in a given range. | `String s = "string"; s.Substring(s.Length+1);` |

## How to use the try/catch block to catch exceptions

Place the sections of code that might throw exceptions in a `try` block and place code that handles exceptions in a `catch` block. The `catch` block is a series of statements beginning with the keyword `catch`, followed by an exception type and an action to be taken.

The following code example uses a `try`/`catch` block to catch a possible exception. The `Main` method contains a `try` block with a @System.IO.StreamReader statement that opens a data file called `data.txt` and writes a string from the file. Following the `try` block is a `catch` block that catches any exception that results from the `try` block.

C#
```
using System;
using System.IO;

public class ProcessFile
{
    public static void Main()
    {
        try
        {
            StreamReader sr = File.OpenText("data.txt");
            Console.WriteLine("The first line of this file is {0}", sr.ReadLine());
            sr.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: '{0}'", e);
        }
    }
}
```

The common language runtime catches exceptions that are not caught by a catch block. Depending on how the runtime is configured, a debug dialog box appears, or the program stops executing and a dialog box with exception information appears, or an error is printed out to STDERR.

> [!NOTE] 
> Almost any line of code can cause an exception, particularly exceptions that are thrown by the common language runtime itself, such as @System.OutOfMemoryException. Most applications don't have to deal with these exceptions, but you should be aware of this possibility when writing libraries to be used by others. For suggestions on when to set code in a Try block, see [Best Practices for Exceptions](#best-practices-for-exceptions).
 
## How to use specific exceptions in a Catch block

The preceding code example illustrates a basic `catch` statement that catches any exception. In general, though, it's good programming practice to catch a specific type of exception rather than use a basic `catch` statement.

When an exception occurs, it is passed up the stack and each catch block is given the opportunity to handle it. The order of catch statements is important. Put catch blocks targeted to specific exceptions before a general exception catch block or the compiler might issue an error. The proper catch block is determined by matching the type of the exception to the name of the exception specified in the catch block. If there is no specific catch block, the exception is caught by a general catch block, if one exists.

The following code example uses a `try`/`catch` block to catch an @System.InvalidCastException. The sample creates a class called `Employee` with a single property, employee level (`Emlevel`). A method, `PromoteEmployee`, takes an object and increments the employee level. An @System.InvalidCastException occurs when a @System.DateTime instance is passed to the `PromoteEmployee` method.

C#
```
using System;

public class Employee
{
    //Create employee level property.
    public int Emlevel
    {
        get
        {
            return(emlevel);
        }
        set
        {
            emlevel = value;
        }
    }

    private int emlevel = 0;
}

public class Ex13
{
    public static void PromoteEmployee(Object emp)
    {
        //Cast object to Employee.
        Employee e = (Employee) emp;
        // Increment employee level.
        e.Emlevel = e.Emlevel + 1;
    }

    public static void Main()
    {
        try
        {
            Object o = new Employee();
            DateTime newyears = new DateTime(2001, 1, 1);
            //Promote the new employee.
            PromoteEmployee(o);
            //Promote DateTime; results in InvalidCastException as newyears is not an employee instance.
            PromoteEmployee(newyears);
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine("Error passing data to PromoteEmployee method. " + e.Message);
        }
    }
}
```

## How to use finally blocks

When an exception occurs, execution stops and control is given to the appropriate exception handler. This often means that lines of code you expect to be executed are bypassed. Some resource cleanup, such as closing a file, needs to be done even if an exception is thrown. To do this, you can use a `finally` block. A `finally` block always executes, regardless of whether an exception is thrown.

The following code example uses a `try`/`catch` block to catch an @System.ArgumentOutOfRangeException. The `Main` method creates two arrays and attempts to copy one to the other. The action generates an @System.ArgumentOutOfRangeException and the error is written to the console. The `finally` block executes regardless of the outcome of the copy action.

C#
```
using System;

class ArgumentOutOfRangeExample
{
    public static void Main()
    {
        int[] array1 = {0, 0};
        int[] array2 = {0, 0};

        try
        {
            Array.Copy(array1, array2, -1);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Error: {0}", e);
        }
        finally
        {
            Console.WriteLine("This statement is always executed.");
        }
    }
}
```

## How to explicitly throw exceptions

You can explicitly throw an exception using the `throw` statement. You can also throw a caught exception again using the `throw` statement. It is good coding practice to add information to an exception that is re-thrown to provide more information when debugging.

The following code example uses a `try`/`catch` block to catch a possible @System.IO.FileNotFoundException. Following the `try` block is a `catch` block that catches the @System.IO.FileNotFoundException and writes a message to the console if the data file is not found. The next statement is the `throw` statement that throws a new @System.IO.FileNotFoundException and adds text information to the exception.

C#
```
using System;
using System.IO;

public class ProcessFile
{
   public static void Main()
      {
      FileStream fs = null;
      try   
      {
         //Opens a text tile.
         fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
         StreamReader sr = new StreamReader(fs);
         string line;

         //A value is read from the file and output to the console.
         line = sr.ReadLine();
         Console.WriteLine(line);
      }
      catch(FileNotFoundException e)
      {
         Console.WriteLine("[Data File Missing] {0}", e);
         throw new FileNotFoundException(@"[data.txt not in c:\temp directory]",e);
      }
      finally
      {
         if (fs != null)
            fs.Dispose();
      }
   }
}
```

## How to create user-defined exceptions

.NET provides a hierarchy of exception classes ultimately derived from the base class @System.Exception. However, if none of the predefined exceptions meets your needs, you can create your own exception classes by deriving from the @System.Exception class.

When creating your own exceptions, end the class name of the user-defined exception with the word "Exception," and implement the three common constructors, as shown in the following example. The example defines a new exception class named `EmployeeListNotFoundException`. The class is derived from @System.Exception and includes three constructors.

C#
```
using System;

public class EmployeeListNotFoundException: Exception
{
    public EmployeeListNotFoundException()
    {
    }

    public EmployeeListNotFoundException(string message)
        : base(message)
    {
    }

    public EmployeeListNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
```

> [!NOTE]
> In situations where you are using remoting, you must ensure that the metadata for any user-defined exceptions is available at the server (callee) and to the client (the proxy object or caller). For more information, see [Best practices for exceptions](#best-practices-for-exceptions).

## Best practices for exceptions

A well-designed app handles exceptions and errors to prevent app crashes. This section describes best practices for handling and creating exceptions.

### Use try/catch/finally blocks

Use `try`/`catch`/`finally` blocks around code that can potentially generate an exception. 

In `catch` blocks, always order exceptions from the most specific to the least specific.

Use a `finally` block to clean up resources, whether you can recover or not.

### Handle common conditions without throwing exceptions

For conditions that are likely to occur but might trigger an exception, consider handling them in a way that will avoid the exception. For example, if you try to close a connection that is already closed, you'll get an `InvalidOperationException`. You can avoid that by using an `if` statement to check the connection state before trying to close it.

C#
```
if (conn.State != ConnectionState.Closed)
{
    conn.Close();
}
```

If you don't check connection state before closing, you can catch the `InvalidOperationException` exception.

C#
```
try
{
    conn.Close();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.GetType().FullName);
    Console.WriteLine(ex.Message);
}
```

The method to choose depends on how often you expect the event to occur.

- Use exception handling if the event doesn't occur very often, that is, if the event is truly exceptional and indicates an error (such as an unexpected end-of-file). When you use exception handling, less code is executed in normal conditions.

- Check for error conditions in code if the event happens routinely and could be considered part of normal execution. When you check for common error conditions, less code is executed because you avoid exceptions.

### Design classes so that exceptions can be avoided

A class can provide methods or properties that enable you to avoid making a call that would trigger an exception. For example, a @System.IO.FileStream class provides methods that help determine whether the end of the file has been reached. These can be used to avoid the exception that is thrown if you read past the end of the file. The following example shows how to read to the end of a file without triggering an exception.

C#
```
class FileRead
{
    public void ReadAll(FileStream fileToRead)
    {
        // This if statement is optional
        // as it is very unlikely that
        // the stream would ever be null.
        if (fileToRead == null)
        {
            throw new System.ArgumentNullException();
        }

        int b;

        // Set the stream position to the beginning of the file.
        fileToRead.Seek(0, SeekOrigin.Begin);

        // Read each byte to the end of the file.
        for (int i = 0; i < fileToRead.Length; i++)
        {
            b = fileToRead.ReadByte();
            Console.Write(b.ToString());
            // Or do something else with the byte.
        }
    }
}
```

Another way to avoid exceptions is to return null for extremely common error cases instead of throwing an exception. An extremely common error case can be considered normal flow of control. By returning null in these cases, you minimize the performance impact to an app.

### Throw exceptions instead of returning an error code

Exceptions ensure that failures do not go unnoticed because calling code didn't check a return code. 

### Use the predefined .NET exception types

Introduce a new exception class only when a predefined one doesn't apply. For example:

- Throw an @System.InvalidOperationException exception if a property set or method call is not appropriate given the object's current state.

- Throw an @System.ArgumentException exception or one of the predefined classes that derive from @System.ArgumentException if invalid parameters are passed.

### End exception class names with the word `Exception`

When a custom exception is necessary, name it appropriately and derive it from the @System.Exception class. For example:

C#
```
public class MyFileNotFoundException : Exception
{
}
```

### Include three constructors in custom exception classes

Use at least the three common constructors when creating your own exception classes: the default constructor, a constructor that takes a string message, and a constructor that takes a string message and an inner exception.

- @System.Exception.%23ctor, which uses default values.

- @System.Exception.%23ctor(System.String), which accepts a string message.

- @System.Exception.%23ctor(System.String,System.Exception), which accepts a string message and an inner exception.

For an example, see [How to: Create User-Defined Exceptions](#how-to-create-user-defined-exceptions).

### Ensure that exception data is available when code executes remotely

When you create user-defined exceptions, ensure that the metadata for the exceptions is available to code that is executing remotely. 

For example, on .NET runtimes that implement App Domains, exceptions may occur across App domains. Suppose App Domain A creates App Domain B, which executes code that throws an exception. For App Domain A to properly catch and handle the exception, it must be able to find the assembly that contains the exception thrown by App Domain B. If App Domain B throws an exception that is contained in an assembly under its application base, but not under App Domain A's application base, App Domain A will not be able to find the exception, and the common language runtime will throw a @System.IO.FileNotFoundException exception. To avoid this situation, you can deploy the assembly that contains the exception information in two ways:

- Put the assembly into a common application base shared by both app domains.

	\- or -

- If the domains do not share a common application base, sign the assembly that contains the exception information with a strong name and deploy the assembly into the global assembly cache.

### Include a localized description string in every exception

The error message that the user sees is derived from the description string of the exception that was thrown, and not from the name of the exception class.

### Use grammatically correct error messages

Write clear sentences and include ending punctuation. Each sentence in a description string of an exception should end in a period. For example, "The log table has overflowed.” would be an appropriate description string.

### In custom exceptions, provide additional properties as needed

Provide additional properties for an exception (in addition to the description string) only when there's a programmatic scenario where the additional information is useful. For example, the @System.IO.FileNotFoundException provides the @System.IO.FileNotFoundException.FileName property.

### Place throw statements so that the stack trace will be helpful

The stack trace begins at the statement where the exception is thrown and ends at the `catch` statement that catches the exception.

### Use exception builder methods

It is common for a class to throw the same exception from different places in its implementation. To avoid excessive code, use helper methods that create the exception and return it. For example:

C#
```
class FileReader
{
    private string fileName;

    public FileReader(string path)
    {
        fileName = path;
    }

    public byte[] Read(int bytes)
    {
        byte[] results = FileUtils.ReadFromFile(fileName, bytes);
        if (results == null)
        {
            throw NewFileIOException();
        }
        return results;
    }

    FileReaderException NewFileIOException()
    {
        string description = "My NewFileIOException Description";

        return new FileReaderException(description);
    }
}

```

In some cases, it's more appropriate to use the exception's constructor to build the exception. An example is a global exception class such as @System.ArgumentException, 

### Clean up intermediate results when throwing an exception

Callers should be able to assume that there are no side effects when an exception is thrown from a method. For example, if you have code that transfers money by withdrawing from one account and depositing in another account, and an exception is thrown while executing the deposit, you don't want the withdrawal to remain in effect.

C#
```
public void TransferFunds(Account from, Account to, decimal amount)
{
    from.Withdrawal(amount);
    // If the deposit fails, the withdrawal shouldn't remain in effect. 
    to.Deposit(amount);
}
```

One way to handle this situation is to catch any exceptions thrown by the deposit transaction and roll back the withdrawal.

C#
```
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
        throw
    }
}
```

This example illustrates the use of `throw` to re-throw the original exception, which can make it easier for callers to see the real cause of the problem without having to examine the @System.Exception.InnerException property. An alternative is to throw a new exception and include the original exception as the inner exception:

C#
```
catch (Exception ex)
{
    from.RollbackTransaction(withdrawalTrxID);
    throw new Exception("Withdrawal failed", ex);
}
```

## See Also

To learn more about how exceptions work in .NET, see [What Every Dev needs to Know About Exceptions in the Runtime](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/exceptions.md).
