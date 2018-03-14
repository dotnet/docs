// The following code example creates SortedList instances using different
// constructors and demonstrates the differences in the behavior of the
// SortedList instances.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

public class SamplesSortedList
{

    public static void Main()
    {

        // Create a SortedList using the default comparer.
        SortedList mySL1 = new SortedList();
        Console.WriteLine("mySL1 (default):");
        mySL1.Add("FIRST", "Hello");
        mySL1.Add("SECOND", "World");
        mySL1.Add("THIRD", "!");
        try
        {
            mySL1.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL1);

        // Create a SortedList using the specified case-insensitive comparer.
        SortedList mySL2 = new SortedList(new CaseInsensitiveComparer());
        Console.WriteLine("mySL2 (case-insensitive comparer):");
        mySL2.Add("FIRST", "Hello");
        mySL2.Add("SECOND", "World");
        mySL2.Add("THIRD", "!");
        try
        {
            mySL2.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL2);

        // Create a SortedList using the specified CaseInsensitiveComparer,
        // which is based on the Turkish culture (tr-TR), where "I" is not
        // the uppercase version of "i".
        CultureInfo myCul = new CultureInfo("tr-TR");
        SortedList mySL3 = new SortedList(new CaseInsensitiveComparer(myCul));
        Console.WriteLine(
            "mySL3 (case-insensitive comparer, Turkish culture):");

        mySL3.Add("FIRST", "Hello");
        mySL3.Add("SECOND", "World");
        mySL3.Add("THIRD", "!");
        try
        {
            mySL3.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL3);

        // Create a SortedList using the
        // StringComparer.InvariantCultureIgnoreCase value.
        SortedList mySL4 = new SortedList(
            StringComparer.InvariantCultureIgnoreCase);

        Console.WriteLine("mySL4 (InvariantCultureIgnoreCase):");
        mySL4.Add("FIRST", "Hello");
        mySL4.Add("SECOND", "World");
        mySL4.Add("THIRD", "!");
        try
        {
            mySL4.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL4);

    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("        -KEY-   -VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine("        {0,-6}: {1}",
                myList.GetKey(i), myList.GetByIndex(i));
        }
        Console.WriteLine();
    }
}


/* 
This code produces the following output.
Results vary depending on the system's culture settings.

mySL1 (default):
        -KEY-   -VALUE-
        first : Ola!
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL2 (case-insensitive comparer):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL3 (case-insensitive comparer, Turkish culture):
        -KEY-   -VALUE-
        FIRST : Hello
        first : Ola!
        SECOND: World
        THIRD : !

mySL4 (InvariantCultureIgnoreCase):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

*/

// </Snippet1>

