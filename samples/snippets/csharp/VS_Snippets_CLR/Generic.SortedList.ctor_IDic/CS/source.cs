// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new Dictionary of strings, with string keys.
        //
        Dictionary<string, string> openWith = 
                                  new Dictionary<string, string>();
        
        // Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");
        
        // Create a SortedList of strings with string keys, 
        // and initialize it with the contents of the Dictionary.
        SortedList<string, string> copy = 
                  new SortedList<string, string>(openWith);

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

Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>



