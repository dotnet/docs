// <Snippet1>
using System;
using System.Reflection;

class Mymethodinfo
{
    public static int Main()
    {
        Console.WriteLine ("\nReflection.MethodInfo");
  
        // Get the Type and MethodInfo.
        Type MyType = Type.GetType("System.Reflection.FieldInfo");
        MethodInfo Mymethodinfo = MyType.GetMethod("GetValue");
        Console.Write ("\n" + MyType.FullName + "." + Mymethodinfo.Name);
  
        // Get and display the ReturnType.
        Console.Write ("\nReturnType = {0}", Mymethodinfo.ReturnType);
        return 0;
    }
}
// </Snippet1>

