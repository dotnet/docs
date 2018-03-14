//<snippet1>
// This example demonstrates the 
//     Environment.ProcessorCount property.
using System;

class Sample 
{
    public static void Main() 
    {
    Console.WriteLine("The number of processors " +
        "on this computer is {0}.", 
        Environment.ProcessorCount);
    }
}
/*
This example produces the following results:

The number of processors on this computer is 1.
*/
//</snippet1>