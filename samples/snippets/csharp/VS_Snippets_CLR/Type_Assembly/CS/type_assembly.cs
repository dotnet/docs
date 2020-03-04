// <Snippet1>
using System;

class MyAssemblyClass
{
    public static void Main()
    {
        Type objType = typeof(Array);

        // Print the assembly full name.
        Console.WriteLine($"Assembly full name:\n   {objType.Assembly.FullName}.");

        // Print the assembly qualified name.
        Console.WriteLine($"Assembly qualified name:\n   {objType.AssemblyQualifiedName}.");
    }
}
// The example displays the following output if run under the .NET Framework 4.5:
//    Assembly full name:
//       mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
//    Assembly qualified name:
//       System.Array, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
// </Snippet1>
