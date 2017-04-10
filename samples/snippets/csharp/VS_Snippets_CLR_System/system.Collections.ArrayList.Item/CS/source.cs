//<Snippet1>
using System;
using System.Collections;

public class Example
{
    public static void Main()
    {
        // Create an empty ArrayList, and add some elements.
        ArrayList stringList = new ArrayList();

        stringList.Add("a");
        stringList.Add("abc");
        stringList.Add("abcdef");
        stringList.Add("abcdefg");

        // The Item property is an indexer, so the property name is
        // not required.
        Console.WriteLine("Element {0} is \"{1}\"", 2, stringList[2]);

        // Assigning a value to the property changes the value of
        // the indexed element.
        stringList[2] = "abcd";
        Console.WriteLine("Element {0} is \"{1}\"", 2, stringList[2]);

        // Accessing an element outside the current element count
        // causes an exception. 
        Console.WriteLine("Number of elements in the list: {0}", 
            stringList.Count);
        try
        {
            Console.WriteLine("Element {0} is \"{1}\"", 
                stringList.Count, stringList[stringList.Count]);
        }
        catch(ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine("stringList({0}) is out of range.", 
                stringList.Count);
        }

        // You cannot use the Item property to add new elements.
        try
        {
            stringList[stringList.Count] = "42";
        }
        catch(ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine("stringList({0}) is out of range.", 
                stringList.Count);
        }

        Console.WriteLine();
        for (int i = 0; i < stringList.Count; i++)
        {
            Console.WriteLine("Element {0} is \"{1}\"", i, 
                stringList[i]);
        }

        Console.WriteLine();
        foreach (object o in stringList)
        {
            Console.WriteLine(o);
        }
    }
}
/*
 This code example produces the following output:

Element 2 is "abcdef"
Element 2 is "abcd"
Number of elements in the list: 4
stringList(4) is out of range.
stringList(4) is out of range.

Element 0 is "a"
Element 1 is "abc"
Element 2 is "abcd"
Element 3 is "abcdefg"

a
abc
abcd
abcdefg
 */
//</Snippet1>



