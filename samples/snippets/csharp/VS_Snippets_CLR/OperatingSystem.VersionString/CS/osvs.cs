//<snippet1>
// This example demonstrates the VersionString property.
using System;

class Sample 
{
    public static void Main() 
    {
    OperatingSystem os = Environment.OSVersion;
// Display the value of OperatingSystem.VersionString. By default, this is
// the same value as OperatingSystem.ToString.
    Console.WriteLine("This operating system is {0}", os.VersionString);
    }
}
/*
This example produces the following results:

This operating system is Microsoft Windows NT 5.1.2600.0 Service Pack 1
*/
//</snippet1>