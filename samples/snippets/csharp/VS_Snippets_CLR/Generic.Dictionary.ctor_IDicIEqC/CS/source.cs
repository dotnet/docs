// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new sorted dictionary of strings, with string 
        // keys and a case-insensitive comparer.
        SortedDictionary<string, string> openWith = 
                new SortedDictionary<string, string>(
                    StringComparer.CurrentCultureIgnoreCase);
        
        // Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe");
        openWith.Add("Bmp", "paint.exe");
        openWith.Add("DIB", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");
        
        // Create a Dictionary of strings with string keys and a
        // case-insensitive equality comparer, and initialize it
        // with the contents of the sorted dictionary.
        Dictionary<string, string> copy = 
                new Dictionary<string, string>(openWith, 
                    StringComparer.CurrentCultureIgnoreCase);

        // List the contents of the copy.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in copy )
        {
            Console.WriteLine("Key = {0}, Value = {1}", 
               kvp.Key, kvp.Value);
        }
    }
}

/* This code example produces the following output:

Key = Bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>



