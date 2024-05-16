// <snippet3>
// This code displays information about the GetValue method of FieldInfo.
using System;
using System.Reflection;

class MyMethodInfo
{
    public static int Main()
    {
        Console.WriteLine("Reflection.MethodInfo");
        // Gets and displays the Type.
        Type myType = Type.GetType("System.Reflection.FieldInfo");
        // Specifies the member for which you want type information.
        MethodInfo myMethodInfo = myType.GetMethod("GetValue");
        Console.WriteLine(myType.FullName + "." + myMethodInfo.Name);
        // Gets and displays the MemberType property.
        MemberTypes myMemberTypes = myMethodInfo.MemberType;
        if (MemberTypes.Constructor == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type All");
        }
        else if (MemberTypes.Custom == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type Custom");
        }
        else if (MemberTypes.Event == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type Event");
        }
        else if (MemberTypes.Field == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type Field");
        }
        else if (MemberTypes.Method == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type Method");
        }
        else if (MemberTypes.Property == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type Property");
        }
        else if (MemberTypes.TypeInfo == myMemberTypes)
        {
            Console.WriteLine("MemberType is of type TypeInfo");
        }
        return 0;
    }
}
// </snippet3>
