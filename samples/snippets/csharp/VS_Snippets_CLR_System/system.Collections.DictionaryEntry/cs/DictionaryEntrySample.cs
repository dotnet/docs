//<snippet00>
// A simple example for the DictionaryEntry structure.
using System;
using System.Collections;

class Example
{
    public static void Main()
    {
        // Create a new hash table.
        //
        Hashtable openWith = new Hashtable();

        // Add some elements to the hash table. There are no 
        // duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");

        // When you use foreach to enumerate hash table elements,
        // the elements are retrieved as DictionaryEntry objects.
        Console.WriteLine();
        // <snippet01>
        foreach (DictionaryEntry de in openWith)
        {
            Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
        }
        // </snippet01>
    }
}

/* This code example produces output similar to the following:

Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
Key = dib, Value = paint.exe
Key = bmp, Value = paint.exe
 */
//</snippet00>