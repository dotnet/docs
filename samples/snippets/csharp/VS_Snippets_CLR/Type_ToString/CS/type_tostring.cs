// <Snippet1>	
using System;

namespace MyNamespace
{
    class MyClass
    {
    }
}

public class Example
{
    public static void Main()
    {
         Type myType = typeof(MyNamespace.MyClass);
         Console.WriteLine("Displaying information about {0}:", myType); 
         // Get the namespace of the myClass class.
         Console.WriteLine("   Namespace: {0}.", myType.Namespace);
         // Get the name of the module.
         Console.WriteLine("   Module: {0}.", myType.Module);
         // Get the fully qualified type name.
         Console.WriteLine("   Fully qualified name: {0}.", myType.ToString());
    }
}
// The example displays the following output:
//    Displaying information about MyNamespace.MyClass:
//       Namespace: MyNamespace.
//       Module: type_tostring.exe.
//       Fully qualified name: MyNamespace.MyClass.
// </Snippet1>				

