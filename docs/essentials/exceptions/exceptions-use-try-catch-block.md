# How to use the try/catch block to catch exceptions

Place the sections of code that might throw exceptions in a **try** block and place code that handles exceptions in a **catch** block. The **catch** block is a series of statements beginning with the keyword **catch**, followed by an exception type and an action to be taken.

> [!NOTE] Almost any line of code can cause an exception, particularly exceptions that are thrown by the common language runtime itself, such as [OutOfMemoryException](http://dotnet.github.io/api/System.OutOfMemoryException.html). Most applications don't have to deal with these exceptions, but you should be aware of this possibility when writing libraries to be used by others. For suggestions on when to set code in a Try block, see [Best Practices for Handling Exceptions](exceptions-best-practices.md).

The following code example uses a **try**/**catch** block to catch a possible exception. The `Main` method contains a **try** block with a [StreamReader](http://dotnet.github.io/api/System.IO.StreamReader.html) statement that opens a data file called `data.txt` and writes a string from the file. Following the **try** block is a **catch** block that catches any exception that results from the **try** block.

## Example

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
	    sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: '{0}'", e);
        }
    }
}
```

This example illustrates a basic **catch** statement that catches any exception. In general, though, it's good programming practice to catch a specific type of exception rather than use a basic **catch** statement. For more information about catching specific exceptions, see [Using Specific Exceptions in a Catch Block](exceptions-catch-specific-exceptions.md).
