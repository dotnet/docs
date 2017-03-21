using System;
using System.Collections;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys,
        // and access it using the IDictionary interface.
        //
        IDictionary openWith = new Dictionary<string, string>();

        // Add some elements to the dictionary. There are no 
        // duplicate keys, but some of the values are duplicates.
        // IDictionary.Add throws an exception if incorrect types
        // are supplied for key or value.
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");
        try
        {
            openWith.Add(42, new Example());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("An exception was caught for " + 
                "IDictionary.Add. Exception message:\n\t{0}\n",
                ex.Message);
        }

        // The Add method throws an exception if the new key is 
        // already in the dictionary.
        try
        {
            openWith.Add("txt", "winword.exe");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("An element with Key = \"txt\" already exists.");
        }

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

        // The indexer returns null if the key is of the wrong data 
        // type.
        Console.WriteLine("The indexer returns null" 
            + " if the key is of the wrong type:");
        Console.WriteLine("For key = 2, value = {0}.", 
            openWith[2]);

        // The indexer throws an exception when setting a value
        // if the key is of the wrong data type.
        try
        {
            openWith[2] = "This does not get added.";
        }
        catch (ArgumentException)
        {
            Console.WriteLine("A key of the wrong type was specified" 
                + " when assigning to the indexer.");
        }

        // Unlike the default Item property on the Dictionary class
        // itself, IDictionary.Item does not throw an exception
        // if the requested key is not in the dictionary.
        Console.WriteLine("For key = \"tif\", value = {0}.", 
            openWith["tif"]);

        // Contains can be used to test keys before inserting 
        // them.
        if (!openWith.Contains("ht"))
        {
            openWith.Add("ht", "hypertrm.exe");
            Console.WriteLine("Value added for key = \"ht\": {0}", 
                openWith["ht"]);
        }

        // IDictionary.Contains returns false if the wrong data
        // type is supplied.
        Console.WriteLine("openWith.Contains(29.7) returns {0}",
            openWith.Contains(29.7));

        // When you use foreach to enumerate dictionary elements
        // with the IDictionary interface, the elements are retrieved
        // as DictionaryEntry objects instead of KeyValuePair objects.
        Console.WriteLine();
        foreach( DictionaryEntry de in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}", 
                de.Key, de.Value);
        }

        // To get the values alone, use the Values property.
        ICollection icoll = openWith.Values;

        // The elements of the collection are strongly typed
        // with the type that was specified for dictionary values,
        // even though the ICollection interface is not strongly
        // typed.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Value = {0}", s);
        }

        // To get the keys alone, use the Keys property.
        icoll = openWith.Keys;

        // The elements of the collection are strongly typed
        // with the type that was specified for dictionary keys,
        // even though the ICollection interface is not strongly
        // typed.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Key = {0}", s);
        }

        // Use the Remove method to remove a key/value pair. No
        // exception is thrown if the wrong data type is supplied.
        Console.WriteLine("\nRemove(\"dib\")");
        openWith.Remove("dib");

        if (!openWith.Contains("dib"))
        {
            Console.WriteLine("Key \"dib\" is not found.");
        }
    }
}

/* This code example produces the following output:

An exception was caught for IDictionary.Add. Exception message:
        The value "42" is not of type "System.String" and cannot be used in this generic collection.
Parameter name: key

An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
The indexer returns null if the key is of the wrong type:
For key = 2, value = .
A key of the wrong type was specified when assigning to the indexer.
For key = "tif", value = .
Value added for key = "ht": hypertrm.exe
openWith.Contains(29.7) returns False

Key = txt, Value = notepad.exe
Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = winword.exe
Key = doc, Value = winword.exe
Key = ht, Value = hypertrm.exe

Value = notepad.exe
Value = paint.exe
Value = paint.exe
Value = winword.exe
Value = winword.exe
Value = hypertrm.exe

Key = txt
Key = bmp
Key = dib
Key = rtf
Key = doc
Key = ht

Remove("dib")
Key "dib" is not found.
 */