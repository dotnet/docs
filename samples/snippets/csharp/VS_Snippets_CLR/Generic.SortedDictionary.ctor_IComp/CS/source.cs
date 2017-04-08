// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new SortedDictionary of strings, with string keys 
        // and a case-insensitive comparer for the current culture.
        SortedDictionary<string, string> openWith = 
                      new SortedDictionary<string, string>( 
                          StringComparer.CurrentCultureIgnoreCase);
        
        // Add some elements to the dictionary.
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
            Console.WriteLine("\nBMP is already in the dictionary.");
        }
        
        // List the contents of the sorted dictionary.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, 
                kvp.Value);
        }
    }
}

/* This code example produces the following output:

BMP is already in the dictionary.

Key = bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>



