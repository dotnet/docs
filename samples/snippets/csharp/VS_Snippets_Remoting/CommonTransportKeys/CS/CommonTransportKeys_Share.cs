/*
   Supporting file: Common  
*/

using System;

public class Foo : MarshalByRefObject
{
    // Print the string value.
    public void PrintString(String str)
    {  
        Console.WriteLine("\n" + str);
    }
}