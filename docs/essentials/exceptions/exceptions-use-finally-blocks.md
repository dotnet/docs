# How to use finally blocks

When an exception occurs, execution stops and control is given to the closest exception handler. This often means that lines of code you expect to always be called are not executed. Some resource cleanup, such as closing a file, needs to be done even if an exception is thrown. To do this, you can use a Finally block. A Finally block always executes, regardless of whether an exception is thrown.

The following code example uses a **try**/**catch** block to catch an [ArgumentOutOfRangeException](http://dotnet.github.io/api/System.ArgumentOutOfRangeException.html). The `Main` method creates two arrays and attempts to copy one to the other. The action generates an **ArgumentOutOfRangeException** and the error is written to the console. The **finally** block executes regardless of the outcome of the copy action.

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
