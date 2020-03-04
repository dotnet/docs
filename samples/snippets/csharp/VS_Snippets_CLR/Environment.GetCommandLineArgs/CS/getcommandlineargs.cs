//<snippet1>
using System;

class Sample 
{
    public static void Main() 
    {
        Console.WriteLine();
        //  Invoke this sample with an arbitrary set of command line arguments.
        string[] arguments = Environment.GetCommandLineArgs();
        Console.WriteLine("GetCommandLineArgs: {0}", string.Join(", ", arguments));
    }
}
/*
This example produces output like the following:
    
    C:\>GetCommandLineArgs ARBITRARY TEXT
    
      GetCommandLineArgs: GetCommandLineArgs, ARBITRARY, TEXT
*/
// </snippet1>
