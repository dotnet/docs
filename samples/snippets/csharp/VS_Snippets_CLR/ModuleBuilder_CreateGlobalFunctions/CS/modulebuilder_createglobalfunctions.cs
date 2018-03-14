// System.Reflection.Emit.ModuleBuilder.DefineGlobalMethod(String,MethodAttributes,Type,Type[])
// System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions

/*
   The following example demonstrates the 'DefineGlobalMethod(String,MethodAttributes,Type,Type[])'
   and 'CreateGlobalFunctions' methods of 'ModuleBuilder' class. 
   A dynamic assembly with a module in it is created in 'CodeGenerator' class. Then a global method 
   is created in the module using the 'DefineGlobalMethod' method. The global method is called from
   the 'CallerClass'.
*/

   using System;
   using System.Reflection;
   using System.Reflection.Emit;

   public class CodeGenerator
   {
      ModuleBuilder myModuleBuilder =null;
      AssemblyBuilder myAssemblyBuilder = null;

      public CodeGenerator()
      {
// <Snippet1>
// <Snippet2>
         AppDomain currentDomain;
         AssemblyName myAssemblyName;
         MethodBuilder myMethodBuilder=null;
         ILGenerator myILGenerator;

         // Get the current application domain for the current thread.
         currentDomain = AppDomain.CurrentDomain;
         myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";
         
         // Define a dynamic assembly in the 'currentDomain'.
         myAssemblyBuilder = 
            currentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         // Define a dynamic module in "TempAssembly" assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");

         // Define a global method in the 'TempModule' module.
         myMethodBuilder = myModuleBuilder.DefineGlobalMethod
              ("MyMethod1",MethodAttributes.Static|MethodAttributes.Public,
                    null,null);
         myILGenerator = myMethodBuilder.GetILGenerator();
         myILGenerator.EmitWriteLine("Hello World from global method.");
         myILGenerator.Emit(OpCodes.Ret);
         // Fix up the 'TempModule' module .
         myModuleBuilder.CreateGlobalFunctions();
// </Snippet2>
// </Snippet1>
      }
      
      public AssemblyBuilder MyAssembly
      {
         get
         {
            return this.myAssemblyBuilder;
         }
      }
   }
   public class CallerClass
   {
      public static void Main()
      {
         CodeGenerator myGenerator = new CodeGenerator();
         AssemblyBuilder myAssembly = myGenerator.MyAssembly;
         ModuleBuilder myBuilder = myAssembly.GetDynamicModule("TempModule");
         Console.WriteLine("Invoking the global method...");
         MethodInfo myMethodInfo = myBuilder.GetMethod("MyMethod1");
         myMethodInfo.Invoke(null, null);
      }
   }

