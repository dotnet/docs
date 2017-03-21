using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;

public class MyAssemblyResource
{
   internal static void Main()
   {
      AssemblyBuilder myAssembly = CreateAssembly("MyEmitTestAssembly");

      // Defines a standalone managed resource for this assembly.
      IResourceWriter myResourceWriter = myAssembly.DefineResource("myResourceFile",
         "A sample Resource File", "MyAssemblyResource.resources", 
         ResourceAttributes.Private);

      myResourceWriter.AddResource("AddResource Test", "Testing for the added resource");

      myAssembly.Save(myAssembly.GetName().Name + ".dll");

      // Defines an unmanaged resource file for this assembly.
      myAssembly.DefineUnmanagedResource(new byte[]{01, 00, 01});
   }

   private static AssemblyBuilder CreateAssembly(string name)
   {
      AssemblyName aName = new AssemblyName(name);
      AssemblyBuilder myAssembly = 
         AppDomain.CurrentDomain.DefineDynamicAssembly(aName,
            AssemblyBuilderAccess.Save);

      // Define a dynamic module.
      ModuleBuilder myModule = 
         myAssembly.DefineDynamicModule(aName.Name, aName.Name + ".dll");

      // Define a public class named "EmitClass" in the assembly.
      TypeBuilder myEmitClass = myModule.DefineType("EmitClass", TypeAttributes.Public);

      // Define the Display method.
      MethodBuilder myMethod = myEmitClass.DefineMethod("Display",
         MethodAttributes.Public, typeof(String), null);

      // Generate IL for Display method.
      ILGenerator methodIL = myMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldstr, "Display method gets called.");
      methodIL.Emit(OpCodes.Ret);

      myEmitClass.CreateType();

      return(myAssembly);
   }
}