// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public class A
{}

public class Example
{
   public static void Main()
   {
      AppDomain domain = AppDomain.CurrentDomain;
      AssemblyName assemName = new AssemblyName();
      assemName.Name = "TempAssembly";

      // Define a dynamic assembly in the current application domain.
      AssemblyBuilder assemBuilder = domain.DefineDynamicAssembly(assemName,
                                            AssemblyBuilderAccess.Run);

      // Define a dynamic module in this assembly.
      ModuleBuilder moduleBuilder = assemBuilder.DefineDynamicModule("TempModule");

      TypeBuilder b1 = moduleBuilder.DefineType("B", TypeAttributes.Public, typeof(A));
      Console.WriteLine(typeof(A).IsAssignableFrom(b1));
   }
}
// The example displays the following output:
//        True
// </Snippet1>

