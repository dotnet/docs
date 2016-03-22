# How to create user-defined exceptions

If you want users to be able to programmatically distinguish between some error conditions, you can create your own user-defined exceptions. The .NET Framework provides a hierarchy of exception classes ultimately derived from the base class [Exception](https://msdn.microsoft.com/library/system.exception). Each of these classes defines a specific exception, so in many cases you only have to catch the exception. You can also create your own exception classes by deriving from the **Exception** class.

When creating your own exceptions, it is good coding practice to end the class name of the user-defined exception with the word "Exception." It is also good practice to implement the three recommended common constructors, as shown in the following example.

> [!NOTE] In situations where you are using remoting, you must ensure that the metadata for any user-defined exceptions is available at the server (callee) and to the client (the proxy object or caller). For example, code calling a method in a separate application domain must be able to find the assembly containing an exception thrown by a remote call. For more information, see [Best Practices for Handling Exceptions](exceptions-best-practices.md).

In the following example, a new exception class, `EmployeeListNotFoundException`, is derived from **Exception**. Three constructors are defined in the class, each taking different parameters.

## Example

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

C++
```
using namespace System;

public ref class EmployeeListNotFoundException : Exception
{
public:
    EmployeeListNotFoundException()
    {
    }

    EmployeeListNotFoundException(String^ message)
        : Exception(message)
    {
    }

    EmployeeListNotFoundException(String^ message, Exception^ inner)
        : Exception(message, inner)
    {
    }
};
```

Visual Basic
```
Imports System

Public Class EmployeeListNotFoundException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class
```
