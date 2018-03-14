// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys, and
        // access it through the generic ICollection interface. The
        // generic ICollection interface views the dictionary as a
        // collection of KeyValuePair objects with the same type
        // arguments as the dictionary.
        //
        ICollection<KeyValuePair<String, String>> openWith =
            new Dictionary<String, String>();
        
        // Add some elements to the dictionary. When elements are 
        // added through the ICollection<T> interface, the keys
        // and values must be wrapped in KeyValuePair objects.
        //
        openWith.Add(new KeyValuePair<String,String>("txt", "notepad.exe"));
        openWith.Add(new KeyValuePair<String,String>("bmp", "paint.exe"));
        openWith.Add(new KeyValuePair<String,String>("dib", "paint.exe"));
        openWith.Add(new KeyValuePair<String,String>("rtf", "wordpad.exe"));
        
        Console.WriteLine();
        foreach( KeyValuePair<string, string> element in openWith )
        {
            Console.WriteLine("{0}, {1}", element.Key, element.Value);
        }
           
        // The Contains method also takes a KeyValuePair object.
        //
        Console.WriteLine(
            "\nContains(KeyValuePair(\"txt\", \"notepad.exe\")): {0}", 
            openWith.Contains(new KeyValuePair<String,String>("txt", "notepad.exe")));

        // The Remove method takes a KeyValuePair object.)
        //
        // Use the Remove method to remove a key/value pair.
        Console.WriteLine("\nRemove(new KeyValuePair(\"dib\", \"paint.exe\"))");
        openWith.Remove(new KeyValuePair<String,String>("dib", "paint.exe"));
        
        Console.WriteLine();
        foreach( KeyValuePair<string, string> element in openWith )
        {
            Console.WriteLine("{0}, {1}", element.Key, element.Value);
        }

        // Create an array of KeyValuePair objects and copy the 
        // contents of the dictionary to it. 
        // 
        KeyValuePair<string, string>[] copy = 
            new KeyValuePair<string, string>[openWith.Count];
        openWith.CopyTo(copy, 0);
    
        // List the contents of the array.
        //
        Console.WriteLine();
        foreach( KeyValuePair<string, string> element in copy )
        {
            Console.WriteLine("{0}, {1}", element.Key, element.Value);
        }
    }
}

/* This code example produces the following output:

txt, notepad.exe
bmp, paint.exe
dib, paint.exe
rtf, wordpad.exe

Contains(KeyValuePair("txt", "notepad.exe")): True

Remove(new KeyValuePair("dib", "paint.exe"))

txt, notepad.exe
bmp, paint.exe
rtf, wordpad.exe

txt, notepad.exe
bmp, paint.exe
rtf, wordpad.exe
 */
//</Snippet1>



