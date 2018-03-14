// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys and
        // an initial capacity of 4.
        Dictionary<string, string> openWith = 
                               new Dictionary<string, string>(4);
        
        // Add 4 elements to the dictionary. 
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");
        
        // List the contents of the dictionary.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", 
               kvp.Key, kvp.Value);
        }
    }
}

/* This code example produces the following output:

Key = txt, Value = notepad.exe
Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = wordpad.exe
 */
//</Snippet1>



