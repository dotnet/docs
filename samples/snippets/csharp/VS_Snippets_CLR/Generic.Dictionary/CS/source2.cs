using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys.
        //
        Dictionary<string, string> myDictionary =
            new Dictionary<string, string>();

        // Add some elements to the dictionary. There are no
        // duplicate keys, but some of the values are duplicates.
        myDictionary.Add("txt", "notepad.exe");
        myDictionary.Add("bmp", "paint.exe");
        myDictionary.Add("dib", "paint.exe");
        myDictionary.Add("rtf", "wordpad.exe");

        //<Snippet11>
        foreach( KeyValuePair<string, string> kvp in myDictionary )
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet11>
    }
}

