//<snippet1>
// Sample for the Environment.GetLogicalDrives method
using System;

class Sample 
{
    public static void Main() 
    {
    Console.WriteLine();
    String[] drives = Environment.GetLogicalDrives();
    Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));
    }
}
/*
This example produces the following results:

GetLogicalDrives: A:\, C:\, D:\
*/
//</snippet1>