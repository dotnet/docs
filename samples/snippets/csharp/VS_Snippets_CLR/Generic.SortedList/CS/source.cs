//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        //<Snippet2>
        // Create a new sorted list of strings, with string
        // keys.
        SortedList<string, string> openWith = 
            new SortedList<string, string>();

        // Add some elements to the list. There are no 
        // duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");

        // The Add method throws an exception if the new key is 
        // already in the list.
        try
        {
            openWith.Add("txt", "winword.exe");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("An element with Key = \"txt\" already exists.");
        }
        //</Snippet2>

        //<Snippet3>
        // The Item property is another name for the indexer, so you 
        // can omit its name when accessing elements. 
        Console.WriteLine("For key = \"rtf\", value = {0}.", 
            openWith["rtf"]);

        // The indexer can be used to change the value associated
        // with a key.
        openWith["rtf"] = "winword.exe";
        Console.WriteLine("For key = \"rtf\", value = {0}.", 
            openWith["rtf"]);

        // If a key does not exist, setting the indexer for that key
        // adds a new key/value pair.
        openWith["doc"] = "winword.exe";
        //</Snippet3>

        //<Snippet4>
        // The indexer throws an exception if the requested key is
        // not in the list.
        try
        {
            Console.WriteLine("For key = \"tif\", value = {0}.", 
                openWith["tif"]);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Key = \"tif\" is not found.");
        }
        //</Snippet4>

        //<Snippet5>
        // When a program often has to try keys that turn out not to
        // be in the list, TryGetValue can be a more efficient 
        // way to retrieve values.
        string value = "";
        if (openWith.TryGetValue("tif", out value))
        {
            Console.WriteLine("For key = \"tif\", value = {0}.", value);
        }
        else
        {
            Console.WriteLine("Key = \"tif\" is not found.");
        }
        //</Snippet5>

        //<Snippet6>
        // ContainsKey can be used to test keys before inserting 
        // them.
        if (!openWith.ContainsKey("ht"))
        {
            openWith.Add("ht", "hypertrm.exe");
            Console.WriteLine("Value added for key = \"ht\": {0}", 
                openWith["ht"]);
        }
        //</Snippet6>

        //<Snippet7>
        // When you use foreach to enumerate list elements,
        // the elements are retrieved as KeyValuePair objects.
        Console.WriteLine();
        foreach( KeyValuePair<string, string> kvp in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", 
                kvp.Key, kvp.Value);
        }
        //</Snippet7>

        //<Snippet8>
        // To get the values alone, use the Values property.
        IList<string> ilistValues = openWith.Values;

        // The elements of the list are strongly typed with the 
        // type that was specified for the SorteList values.
        Console.WriteLine();
        foreach( string s in ilistValues )
        {
            Console.WriteLine("Value = {0}", s);
        }

        // The Values property is an efficient way to retrieve
        // values by index.
        Console.WriteLine("\nIndexed retrieval using the Values " +
            "property: Values[2] = {0}", openWith.Values[2]);
        //</Snippet8>

        //<Snippet9>
        // To get the keys alone, use the Keys property.
        IList<string> ilistKeys = openWith.Keys;

        // The elements of the list are strongly typed with the 
        // type that was specified for the SortedList keys.
        Console.WriteLine();
        foreach( string s in ilistKeys )
        {
            Console.WriteLine("Key = {0}", s);
        }

        // The Keys property is an efficient way to retrieve
        // keys by index.
        Console.WriteLine("\nIndexed retrieval using the Keys " +
            "property: Keys[2] = {0}", openWith.Keys[2]);
        //</Snippet9>

        //<Snippet10>
        // Use the Remove method to remove a key/value pair.
        Console.WriteLine("\nRemove(\"doc\")");
        openWith.Remove("doc");

        if (!openWith.ContainsKey("doc"))
        {
            Console.WriteLine("Key \"doc\" is not found.");
        }
        //</Snippet10>
    }
}

/* This code example produces the following output:

An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
Key = "tif" is not found.
Key = "tif" is not found.
Value added for key = "ht": hypertrm.exe

Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = doc, Value = winword.exe
Key = ht, Value = hypertrm.exe
Key = rtf, Value = winword.exe
Key = txt, Value = notepad.exe

Value = paint.exe
Value = paint.exe
Value = winword.exe
Value = hypertrm.exe
Value = winword.exe
Value = notepad.exe

Indexed retrieval using the Values property: Values[2] = winword.exe

Key = bmp
Key = dib
Key = doc
Key = ht
Key = rtf
Key = txt

Indexed retrieval using the Keys property: Keys[2] = doc

Remove("doc")
Key "doc" is not found.
 */
//</Snippet1>


