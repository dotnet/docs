//<snippet5>
using System;

class Example
{
    public static void Main()
    {
        Compare();
        CompareOrdinal();
        Console.Write("CompareTo: ");
        CompareTo();
        Console.Write("Equals: "); 
        Equals1();
        Equals2();
        StartsWith();
        EndsWith();
        IndexOf();
        LastIndexOf();
    }
                                                                             
    public static void Compare()
    {
        //<snippet6>
        string string1 = "Hello World!";
        Console.WriteLine(String.Compare(string1, "Hello World?"));
        //</snippet6>
    }

    public static void CompareOrdinal()
    {
        //<snippet7>
        string string1 = "Hello World!";
        Console.WriteLine(String.CompareOrdinal(string1, "hello world!"));
        //</snippet7>
    }

    public static void CompareTo()
    {
        //<snippet8>
        string string1 = "Hello World";
        string string2 = "Hello World!";
        int MyInt = string1.CompareTo(string2);
        Console.WriteLine( MyInt );
        //</snippet8>
    }

    public static void Equals1()
    {
        //<snippet9>
        string string1 = "Hello World";
        Console.WriteLine(string1.Equals("Hello World"));
        //</snippet9>
    }

    public static void Equals2()
    {
        //<snippet10>
        string string1 = "Hello World";
        string string2 = "Hello World";
        Console.WriteLine(String.Equals(string1, string2));
        //</snippet10>
    }

    public static void StartsWith()
    {
        //<snippet11>
        string string1 = "Hello World";
        Console.WriteLine(string1.StartsWith("Hello"));
        //</snippet11>
    }

    public static void EndsWith()
    {
        //<snippet12>
        string string1 = "Hello World";
        Console.WriteLine(string1.EndsWith("Hello"));
        //</snippet12>
    }

    public static void IndexOf()
    {
        //<snippet13>
        string string1 = "Hello World";
        Console.WriteLine(string1.IndexOf('l'));
        //</snippet13>
    }

    public static void LastIndexOf()
    {
        //<snippet14>
        string string1 = "Hello World";
        Console.WriteLine(string1.LastIndexOf('l'));
        //</snippet14>
    }
}
//</snippet5>
