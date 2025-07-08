// <snippet4>
// This program lists all the members of the
// System.IO.BufferedStream class.
using System;
using System.IO;
using System.Reflection;

class ListMembers
{
    public static void Main()
    {
        // Specifies the class.
        Type t = typeof(System.IO.BufferedStream);
        Console.WriteLine($"Listing all the members (public and non public) of the {t} type");

        // Lists static fields first.
        FieldInfo[] fi = t.GetFields(BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("// Static Fields");
        PrintMembers(fi);

        // Static properties.
        PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("// Static Properties");
        PrintMembers(pi);

        // Static events.
        EventInfo[] ei = t.GetEvents(BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("// Static Events");
        PrintMembers(ei);

        // Static methods.
        MethodInfo[] mi = t.GetMethods (BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("// Static Methods");
        PrintMembers(mi);

        // Constructors.
        ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
            BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("// Constructors");
        PrintMembers(ci);

        // Instance fields.
        fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
            BindingFlags.Public);
        Console.WriteLine("// Instance Fields");
        PrintMembers(fi);

        // Instance properties.
        pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
            BindingFlags.Public);
        Console.WriteLine ("// Instance Properties");
        PrintMembers(pi);

        // Instance events.
        ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
            BindingFlags.Public);
        Console.WriteLine("// Instance Events");
        PrintMembers(ei);

        // Instance methods.
        mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
            | BindingFlags.Public);
        Console.WriteLine("// Instance Methods");
        PrintMembers(mi);

        Console.WriteLine("\r\nPress ENTER to exit.");
        Console.Read();
    }

    public static void PrintMembers (MemberInfo [] ms)
    {
        foreach (MemberInfo m in ms)
        {
            Console.WriteLine ("{0}{1}", "     ", m);
        }
        Console.WriteLine();
    }
}
// </snippet4>
