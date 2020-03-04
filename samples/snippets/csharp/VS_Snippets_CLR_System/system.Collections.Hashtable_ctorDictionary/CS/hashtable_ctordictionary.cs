// The following code example creates hash tables using different Hashtable
// constructors and demonstrates the differences in the behavior of the hash
// tables, even if each one contains the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

class myCultureComparer : IEqualityComparer
{
    public CaseInsensitiveComparer myComparer;

    public myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer.DefaultInvariant;
    }

    public myCultureComparer(CultureInfo myCulture)
    {
        myComparer = new CaseInsensitiveComparer(myCulture);
    }

    public new bool Equals(object x, object y)
    {
        return myComparer.Compare(x, y) == 0;
    }

    public int GetHashCode(object obj)
    {
        // Compare the hash code for the lowercase versions of the strings.
        return obj.ToString().ToLower().GetHashCode();
    }
}

public class SamplesHashtable
{

    public static void Main()
    {

        // Create the dictionary.
        var mySL = new SortedList();
        mySL.Add("FIRST", "Hello");
        mySL.Add("SECOND", "World");
        mySL.Add("THIRD", "!");

        // Create a hash table using the default comparer.
        var myHT1 = new Hashtable(mySL);

        // Create a hash table using the specified IEqualityComparer that uses
        // the CaseInsensitiveComparer.DefaultInvariant to determine equality.
        var myHT2 = new Hashtable(mySL, new myCultureComparer());

        // Create a hash table using an IEqualityComparer that is based on
        // the Turkish culture (tr-TR) where "I" is not the uppercase
        // version of "i".
        var myCul = new CultureInfo("tr-TR");
        var myHT3 = new Hashtable(mySL, new myCultureComparer(myCul));

        // Search for a key in each hash table.
        Console.WriteLine($"first is in myHT1: {myHT1.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT2: {myHT2.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT3: {myHT3.ContainsKey("first")}");
    }
}


/* 
This code produces the following output. 
Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: False

*/

// </Snippet1>
