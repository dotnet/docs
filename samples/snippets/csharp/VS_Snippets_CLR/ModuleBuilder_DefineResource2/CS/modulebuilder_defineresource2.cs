// System.Reflection.Emit.ModuleBuilder.DefineResource(String,String,ResourceAttributes)
/*
The following example demonstrates the 'DefineResource(String,String,ResourceAttributes)' 
method of 'ModuleBuilder' class.
A dynamic assembly with a module in it is created in 'CodeGenerator' class.
Then a managed resource is defined in the module using the 'DefineResource' method.
*/
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;

   public class CodeGenerator
   {
      public CodeGenerator()
      {
         // Get the current application domain for the current thread.
         AppDomain currentDomain = AppDomain.CurrentDomain;

         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";

         // Define 'TempAssembly' assembly in the current application domain.
         AssemblyBuilder myAssemblyBuilder = 
            currentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         // Define 'TempModule' module in 'TempAssembly' assembly.
         ModuleBuilder myModuleBuilder = 
            myAssemblyBuilder.DefineDynamicModule("TempModule",
                                              "TempModule.netmodule",true);
         // Define the managed embedded resource, 'MyResource' in 'TempModule'
         // with the specified attribute.
         IResourceWriter writer = 
               myModuleBuilder.DefineResource("MyResource.resource",
                            "Description",ResourceAttributes.Public);
         // Add resources to the resource writer.
         writer.AddResource("String 1", "First String");
         writer.AddResource("String 2", "Second String");
         writer.AddResource("String 3", "Third String");
         myAssemblyBuilder.Save("MyAssembly.dll");

      }
   }

   public class CallerClass
   {
      public static void Main()
      {
         CodeGenerator myGenerator = new CodeGenerator();
         Console.WriteLine("A resource named 'MyResource.resource'"
                +" has been created and can be viewed  in the 'MyAssembly.dll'");
      }
   }
// </Snippet1>