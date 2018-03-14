// <Snippet1>
using System;
using System.Reflection;
 
class MyMethodInfo
{
    public static int Main()
    {
        Console.WriteLine("Reflection.MethodInfo");
  
        // Get the Type and MethodInfo.
        Type MyType = Type.GetType("System.Reflection.FieldInfo");
        MethodInfo Mymethodinfo = MyType.GetMethod("GetValue");
        Console.WriteLine(MyType.FullName + "." + Mymethodinfo.Name);
  
        // Get and display the MemberType property.
        MemberTypes Mymembertypes = Mymethodinfo.MemberType;
      
 
        if (MemberTypes.Constructor == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type All.");
        }
        else if (MemberTypes.Custom == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type Custom.");
        }
        else if (MemberTypes.Event == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type Event.");
        }
        else if (MemberTypes.Field == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type Field.");
        }
        else if (MemberTypes.Method == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type Method.");
        }
        else if (MemberTypes.Property == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type Property.");
        }
        else if (MemberTypes.TypeInfo == Mymembertypes)
        {
            Console.WriteLine("MemberType is of type TypeInfo.");
        }
 
        return 0;
    }
}
// </Snippet1>

