// <snippet1>
// This program lists all the public constructors
// of the System.String class.
using System;
using System.Reflection;

class ListMembers
{
    public static void Main()
    {
        Type t = typeof(System.String);
        Console.WriteLine($"Listing all the public constructors of the {t} type");
        // Constructors.
        ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine("//Constructors");
        PrintMembers(ci);
    }

    public static void PrintMembers(MemberInfo[] ms)
    {
        foreach (MemberInfo m in ms)
        {
            Console.WriteLine($"{"     "}{m}");
        }
        Console.WriteLine();
    }
}
// </snippet1>
