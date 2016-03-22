# How to use the Try/Catch block to catch exceptions

Place the sections of code that might throw exceptions in a Try block and place code that handles exceptions in a Catch block. The Catch block is a series of statements beginning with the keyword **catch**, followed by an exception type and an action to be taken.

> [!NOTE] Almost any line of code can cause an exception, particularly exceptions that are thrown by the common language runtime itself, such as [OutOfMemoryException](https://msdn.microsoft.com/library/system.outofmemoryexception) and [StackOverflowException](https://msdn.microsoft.com/library/system.stackoverflowexception). Most applications do not have to deal with these exceptions, but you should be aware of this possibility when writing libraries to be used by others. For suggestions on when to set code in a try block, see Best Practices for Handling Exceptions.

The following code example uses a Try/Catch block to catch a possible exception. The `Main` method contains a Try block with a **StreamReader** statement that opens a data file called `data.txt` and writes a string from the file. Following the Try block is a Catch block that catches any exception that results from the Try block.

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

C++
```
using namespace System;
using namespace System::IO;

public ref class ProcessFile
{
public:
    static void Main()
    {
        try
        {
            StreamReader^ sr = File::OpenText("data.txt");
            Console::WriteLine("The first line of this file is {0}", sr->ReadLine());
	    sr->Close();
        }
        catch (Exception^ e)
        {
            Console::WriteLine("An error occurred: '{0}'", e);
        }
    }
};

int main()
{
    ProcessFile::Main();
}
```

Visual Basic
```
Imports System
Imports System.IO

Public Class ProcessFile
    Public Shared Sub Main()
        Try
            Dim sr As StreamReader = File.OpenText("data.txt")
            Console.WriteLine("The first line of this file is {0}", sr.ReadLine())
	    sr.Close()
        Catch e As Exception
            Console.WriteLine("An error occurred: '{0}'", e)
        End Try
    End Sub
End Class
```

This example illustrates a basic **catch** statement that will catch any exception. In general, it is good programming practice to catch a specific type of exception rather than use the basic **catch** statement. For more information about catching specific exceptions, see [Using Specific Exceptions in a Catch Block](exceptions-catch-specific-exceptions.md).
