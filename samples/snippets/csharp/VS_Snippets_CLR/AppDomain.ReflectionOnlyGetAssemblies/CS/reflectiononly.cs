//<Snippet1>
using System;
using System.Reflection;
using System.Timers;

public class Example
{
    public static void Main()
    {
        // Get the assembly display name for System.dll, the assembly 
        // that contains System.Timers.Timer. Note that this causes
        // System.dll to be loaded into the execution context.
        //
        string displayName = typeof(Timer).Assembly.FullName;

        // Load System.dll into the reflection-only context. Note that 
        // if you obtain the display name (for example, by running this
        // example program), and enter it as a literal string in the 
        // preceding line of code, you can load System.dll into the 
        // reflection-only context without loading it into the execution 
        // context.
        Assembly.ReflectionOnlyLoad(displayName);

        // Display the assemblies loaded into the execution and 
        // reflection-only contexts. System.dll appears in both contexts.
        //
        Console.WriteLine("------------- Execution Context --------------");
        foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            Console.WriteLine("\t{0}", a.GetName());
        }
        Console.WriteLine("------------- Reflection-only Context --------------");
        foreach (Assembly a in AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies())
        {
            Console.WriteLine("\t{0}", a.GetName());
        }
    }
}
//</Snippet1>