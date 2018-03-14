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
        if (myComparer.Compare(x, y) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
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

        // Create a hash table using the default comparer.
        Hashtable myHT1 = new Hashtable(3);
        myHT1.Add("FIRST", "Hello");
        myHT1.Add("SECOND", "World");
        myHT1.Add("THIRD", "!");

        // Create a hash table using the specified IEqualityComparer that uses
        // the CaseInsensitiveComparer.DefaultInvariant to determine equality.
        Hashtable myHT2 = new Hashtable(3, new myCultureComparer());
        myHT2.Add("FIRST", "Hello");
        myHT2.Add("SECOND", "World");
        myHT2.Add("THIRD", "!");

        // Create a hash table using an IEqualityComparer that is based on
        // the Turkish culture (tr-TR) where "I" is not the uppercase
        // version of "i".
        CultureInfo myCul = new CultureInfo("tr-TR");
        Hashtable myHT3 = new Hashtable(3, new myCultureComparer(myCul));
        myHT3.Add("FIRST", "Hello");
        myHT3.Add("SECOND", "World");
        myHT3.Add("THIRD", "!");

        // Search for a key in each hash table.
        Console.WriteLine("first is in myHT1: {0}", myHT1.ContainsKey("first"));
        Console.WriteLine("first is in myHT2: {0}", myHT2.ContainsKey("first"));
        Console.WriteLine("first is in myHT3: {0}", myHT3.ContainsKey("first"));

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

