// <Snippet1>
using System;
using System.Reflection;

class MyAssemblyClass
{
    public static void Main()
    {
        Type objType = typeof(System.Array);
                    
        // Print the full assembly name.
        Console.WriteLine ("Full assembly name:\n   {0}.", 
                           objType.Assembly.FullName.ToString()); 

        // Print the qualified assembly name.
        Console.WriteLine ("Qualified assembly name:\n   {0}.", 
                           objType.AssemblyQualifiedName.ToString()); 
    }
}
// The example displays the following output if run under the .NET Framework 4.5:
//    Full assembly name:
//       mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
//    Qualified assembly name:
//       System.Array, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
// </Snippet1>
