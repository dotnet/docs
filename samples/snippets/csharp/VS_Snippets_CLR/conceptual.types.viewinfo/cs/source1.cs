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
        Console.WriteLine("Listing all the public constructors of the {0} type", t);
        // Constructors.
        ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine("//Constructors");
        PrintMembers(ci);
    }

    public static void PrintMembers(MemberInfo[] ms)
    {
        foreach (MemberInfo m in ms)
        {
            Console.WriteLine("{0}{1}", "     ", m);
        }
        Console.WriteLine();
    }
}
// </snippet1>
