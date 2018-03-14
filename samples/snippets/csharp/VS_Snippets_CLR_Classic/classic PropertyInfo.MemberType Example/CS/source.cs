// <Snippet1>
using System;
using System.Reflection;
 
class Mypropertyinfo
{
    public static int Main()
    {
        Console.WriteLine("\nReflection.PropertyInfo");
  
        // Get the type and PropertyInfo.
        Type MyType = Type.GetType("System.Reflection.MemberInfo");
        PropertyInfo Mypropertyinfo = MyType.GetProperty("Name");
  
        // Read and display the MemberType property.
        Console.Write("\nMemberType = " + Mypropertyinfo.MemberType.ToString());
  
        return 0;
    }
}
// </Snippet1>

