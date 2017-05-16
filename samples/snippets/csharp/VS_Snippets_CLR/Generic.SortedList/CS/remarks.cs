using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new sorted list of strings, with string
        // keys.
        SortedList<int, string> mySortedList =
            new SortedList<int, string>();

        // Add some elements to the list. There are no 
        // duplicate keys, but some of the values are duplicates.
        mySortedList.Add(0, "notepad.exe");
        mySortedList.Add(1, "paint.exe");
        mySortedList.Add(2, "paint.exe");
        mySortedList.Add(3, "wordpad.exe");

        //<Snippet11>
        string v = mySortedList.Values[3];
        //</Snippet11>

        Console.WriteLine("Value at index 3: {0}", v);

        //<Snippet12>
        foreach( KeyValuePair<int, string> kvp in mySortedList )
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet12>
    }
}