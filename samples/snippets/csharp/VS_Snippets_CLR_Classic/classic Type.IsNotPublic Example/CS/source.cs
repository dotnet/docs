// <Snippet1>
using System;
using System.IO;
using System.Reflection;

class Example
{ 
    public static void Main()
    { 
        // Get the Type and MemberInfo.
        Type t = Type.GetType("System.IO.File");
        MemberInfo[] members = t.GetMembers();
        // Get and display the DeclaringType method.
        Console.WriteLine("\nThere are {0} members in {1}.",
                          members.Length, t.FullName);
        Console.WriteLine("Is {0} non-public? {1}",
                          t.FullName, t.IsNotPublic);
    }
}
// The example displays output like the following:
//       There are 60 members in System.IO.File.
//       Is System.IO.File non-public? False
// </Snippet1>

// <Snippet2>
public class A 
{
    public class B { }
    private class C { }
}
// </Snippet2>

