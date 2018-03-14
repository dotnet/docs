// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new Dictionary of strings, with string keys and
        // a case-insensitive equality comparer for the current 
        // culture.
        Dictionary<string, string> openWith = 
            new Dictionary<string, string>
                (StringComparer.CurrentCultureIgnoreCase);
        
        // Add some elements to the dictionary. 
        openWith.Add("txt", "notepad.exe");
        openWith.Add("Bmp", "paint.exe");
        openWith.Add("DIB", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");
        
        // List the contents of the Dictionary.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, 
                kvp.Value);
        }

        // Create a SortedDictionary of strings with string keys and a 
        // case-insensitive equality comparer for the current culture,
        // and initialize it with the contents of the Dictionary.
        SortedDictionary<string, string> copy = 
                    new SortedDictionary<string, string>(openWith, 
                        StringComparer.CurrentCultureIgnoreCase);

        // List the sorted contents of the copy.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in copy )
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, 
                kvp.Value);
        }
    }
}

/* This code example produces the following output:

Key = txt, Value = notepad.exe
Key = Bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe

Key = Bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>



