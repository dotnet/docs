//<Snippet1>
using System;
class TestFullName 
{
public static void Main() 
    {
    Type t = typeof(Array);
    Console.WriteLine("The full name of the Array type is {0}.", t.FullName);
    }
} 

/* This example produces the following output:

The full name of the Array type is System.Array.
 */
//</Snippet1>