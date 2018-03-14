//<snippet8>
using System;
using System.Reflection;

class Asminfo1
{
    public static void Main()
    {
        Console.WriteLine ("\nReflection.MemberInfo");

        // Get the Type and MemberInfo.
        // Insert the fully qualified class name inside the quotation marks in the
        // following statement.
        Type MyType = Type.GetType("System.IO.BinaryReader");
        MemberInfo[] Mymemberinfoarray = MyType.GetMembers(BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Static |
            BindingFlags.Instance | BindingFlags.DeclaredOnly);

        // Get and display the DeclaringType method.
        Console.Write("\nThere are {0} documentable members in ", Mymemberinfoarray.Length);
        Console.Write("{0}.", MyType.FullName);

        foreach (MemberInfo Mymemberinfo in Mymemberinfoarray)
        {
            Console.Write("\n" + Mymemberinfo.Name);
        }
    }
}
//</snippet8>
