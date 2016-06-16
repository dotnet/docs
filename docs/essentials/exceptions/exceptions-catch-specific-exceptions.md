# How to use specific exceptions in a Catch block

When an exception occurs, it is passed up the stack and each catch block is given the opportunity to handle it. The order of catch statements is important. Put catch blocks targeted to specific exceptions before a general exception catch block or the compiler might issue an error. The proper catch block is determined by matching the type of the exception to the name of the exception specified in the catch block. If there is no specific catch block, the exception is caught by a general catch block, if one exists.

The following code example uses a try/catch block to catch an [InvalidCastException](https://msdn.microsoft.com/library/system.invalidcastexception). The sample creates a class called `Employee` with a single property, employee level (`Emlevel`). A method, `PromoteEmployee`, takes an object and increments the employee level. An **InvalidCastException** occurs when a [DateTime](https://msdn.microsoft.com/library/system.datetime) instance is passed to the `PromoteEmployee` method.

## Example

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

Visual Basic
```
Imports System

Public Class Employee
    'Create employee level property.
    Public Property Emlevel As Integer
        Get
            Return emlevelValue
        End Get
        Set
            emlevelValue = Value
        End Set
    End Property

    Private emlevelValue As Integer = 0
End Class

Public Class Ex13
    Public Shared Sub PromoteEmployee(emp As Object)
        'Cast object to Employee.
        Dim e As Employee = CType(emp, Employee)
        ' Increment employee level.
        e.Emlevel = e.Emlevel + 1
    End Sub

    Public Shared Sub Main()
        Try
            Dim o As Object = New Employee()
            Dim newyears As New DateTime(2001, 1, 1)
            'Promote the new employee.
            PromoteEmployee(o)
            'Promote DateTime; results in InvalidCastException as newyears is not an employee instance.
            PromoteEmployee(newyears)
        Catch e As InvalidCastException
            Console.WriteLine("Error passing data to PromoteEmployee method. " + e.Message)
        End Try
    End Sub
End Class
```

The common language runtime catches exceptions that are not caught by a catch block. Depending on how the runtime is configured, either a debug dialog box appears, or the program stops executing and a dialog box with exception information appears. For information about debugging, see [Debugging and Profiling Applications](https://msdn.microsoft.com/library/7fe0dd2y).
