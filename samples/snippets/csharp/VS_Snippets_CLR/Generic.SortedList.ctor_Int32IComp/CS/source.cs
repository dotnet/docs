// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new sorted list of strings, with string keys, an
        // initial capacity of 5, and a case-insensitive comparer.
        SortedList<string, string> openWith = 
                      new SortedList<string, string>(5, 
                          StringComparer.CurrentCultureIgnoreCase);
        
        // Add 4 elements to the list. 
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("DIB", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");

        // Try to add a fifth element with a key that is the same 
        // except for case; this would be allowed with the default
        // comparer.
        try
        {
            openWith.Add("BMP", "paint.exe");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("\nBMP is already in the sorted list.");
        }
        
        // List the contents of the sorted list.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, 
                kvp.Value);
        }
    }
}

/* This code example produces the following output:

BMP is already in the sorted list.

Key = bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>



