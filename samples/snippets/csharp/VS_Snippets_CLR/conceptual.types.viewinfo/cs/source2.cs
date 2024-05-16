// <snippet2>
using System;
using System.IO;
using System.Reflection;

class MyMemberInfo
{
    public static void Main()
    {
        Console.WriteLine ("\nReflection.MemberInfo");
        // Gets the Type and MemberInfo.
        Type myType = Type.GetType("System.IO.File");
        MemberInfo[] myMemberInfoArray = myType.GetMembers();
        // Gets and displays the DeclaringType method.
        Console.WriteLine("\nThere are {0} members in {1}.",
            myMemberInfoArray.Length, myType.FullName);
        Console.WriteLine("{0}.", myType.FullName);
        if (myType.IsPublic)
        {
            Console.WriteLine("{0} is public.", myType.FullName);
        }
    }
}
// </snippet2>
