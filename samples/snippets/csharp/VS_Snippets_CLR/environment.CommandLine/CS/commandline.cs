//<snippet1>
using System;

class Example
{
    public static void Main() 
    {
       Console.WriteLine();
       //  Invoke this sample with an arbitrary set of command line arguments.
       Console.WriteLine("CommandLine: {0}", Environment.CommandLine);
    }
}
// The example displays output like the following:
//       C:\>env0 ARBITRARY TEXT
//       
//       CommandLine: env0 ARBITRARY TEXT
//</snippet1>