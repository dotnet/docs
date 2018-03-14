//<snippet1>
// This example demonstrates the OperatingSystem.ServicePack property.
using System;

class Sample 
{
    public static void Main() 
    {
    OperatingSystem os = Environment.OSVersion;
    String sp = os.ServicePack;
    Console.WriteLine("Service pack version = \"{0}\"", sp);
    }
}
/*
This example produces the following results:

Service pack version = "Service Pack 1"

*/
//</snippet1>