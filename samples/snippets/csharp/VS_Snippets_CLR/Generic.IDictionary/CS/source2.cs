using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys.
        //
        Dictionary<int, string> exDictionary = new Dictionary<int, string>();

        // Add some elements to the dictionary. There are no
        // duplicate keys, but some of the values are duplicates.
        exDictionary.Add(0, "notepad.exe");
        exDictionary.Add(1, "paint.exe");
        exDictionary.Add(2, "paint.exe");
        exDictionary.Add(3, "wordpad.exe");
        IDictionary<int, string> myDictionary = exDictionary;
        // <Snippet11>
        foreach (KeyValuePair<int, string> kvp in myDictionary)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        // </Snippet11>
    }
}

