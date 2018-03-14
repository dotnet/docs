// <Snippet1>
using System;
using System.Reflection;
 
class membertypesenum 
{
    public static int Main(string[] args) 
    {
        Console.WriteLine ("\nReflection.MemberTypes");
        MemberTypes Mymembertypes;
 
        // Get the type of a chosen class.
        Type Mytype = Type.GetType
            ("System.Reflection.ReflectionTypeLoadException");
 
        // Get the MemberInfo array.
        MemberInfo[] Mymembersinfoarray = Mytype.GetMembers();
 
        // Get and display the name and the MemberType for each member.
        foreach (MemberInfo Mymemberinfo in Mymembersinfoarray) 
        { 
            Mymembertypes = Mymemberinfo.MemberType; 
            Console.WriteLine("The member {0} of {1} is a {2}.", Mymemberinfo.Name, Mytype, Mymembertypes.ToString());
        }
        return 0;
    }
}
// </Snippet1>

