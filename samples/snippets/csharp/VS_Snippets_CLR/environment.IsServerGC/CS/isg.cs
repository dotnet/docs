//<snippet1>
using System;
using System.Runtime;

class Sample 
{
    public static void Main() 
    {
    string result;

    if (GCSettings.IsServerGC == true)
        result = "server";
    else 
        result = "workstation";
    Console.WriteLine("The {0} garbage collector is running.", result);
    }
}
// The example displays output like the following:
//      The workstation garbage collector is running.
//</snippet1>