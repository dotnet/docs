# How to use Finally blocks

When an exception occurs, execution stops and control is given to the closest exception handler. This often means that lines of code you expect to always be called are not executed. Some resource cleanup, such as closing a file, must always be executed even if an exception is thrown. To accomplish this, you can use a Finally block. A Finally block is always executed, regardless of whether an exception is thrown.

The following code example uses a Try/Catch block to catch an [ArgumentOutOfRangeException](https://msdn.microsoft.com/library/system.argumentoutofrangeexception). The `Main` method creates two arrays and attempts to copy one to the other. The action generates an **ArgumentOutOfRangeException** and the error is written to the console. The Finally block executes regardless of the outcome of the copy action.

## Example

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

Visual Basic
```
Imports System

Class ArgumentOutOfRangeExample
    Public Shared Sub Main()
        Dim array1() As Integer = {0, 0}
        Dim array2() As Integer = {0, 0}

        Try
            Array.Copy(array1, array2 , -1)
        Catch e As ArgumentOutOfRangeException
            Console.WriteLine("Error: {0}", e)
        Finally
            Console.WriteLine("This statement is always executed.")
        End Try
    End Sub
End Class
```
