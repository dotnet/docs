//<Snippet1>
using System;
using System.Reflection;

[assembly:AssemblyVersion("1.1.0.0")]

class Example
{
    static void Main()
    {
        Console.WriteLine("The version of the currently executing assembly is: {0}",
            typeof(Example).Assembly.GetName().Version);

        Console.WriteLine("The version of mscorlib.dll is: {0}",
            typeof(String).Assembly.GetName().Version);
    }
}

/* This example produces output similar to the following:

The version of the currently executing assembly is: 1.1.0.0
The version of mscorlib.dll is: 2.0.0.0
 */
//</Snippet1>
