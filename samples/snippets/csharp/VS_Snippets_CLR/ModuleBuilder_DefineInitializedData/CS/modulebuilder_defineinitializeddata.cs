// System.Reflection.Emit.ModuleBuilder.DefineInitializedData

/*
The following example demonstrates the 'DefineInitializedData' method of 
'ModuleBuilder' class.
A dynamic assembly with a module in it is created in 'CodeGenerator' class. 
A initialized data field is created using  'DefineInitializedData'
method for creating the initialized data.
*/

using System;
using System.Reflection;
using System.Reflection.Emit;

   public class CodeGenerator
   {
      ModuleBuilder myModuleBuilder ;
      AssemblyBuilder myAssemblyBuilder;

      public CodeGenerator()
      {
// <Snippet1>
         AppDomain currentDomain;
         AssemblyName myAssemblyName;

         // Get the current application domain for the current thread.
         currentDomain = AppDomain.CurrentDomain;
         myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";

         // Define a dynamic assembly in the 'currentDomain'.
         myAssemblyBuilder = 
            currentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.Run);

         // Define a dynamic module in "TempAssembly" assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");

         // Define the initialized data field in the .sdata section of the PE file.
         FieldBuilder myFieldBuilder = 
             myModuleBuilder.DefineInitializedData("MyField",new byte[]{01,00,01},
                        FieldAttributes.Static|FieldAttributes.Public);
          myModuleBuilder.CreateGlobalFunctions();
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
         FieldInfo myInfo = myBuilder.GetField("MyField");
         Console.WriteLine("The name of the initialized data field is :"+myInfo.Name);
         Console.WriteLine("The object having the field value is :"
                                                                   +myInfo.GetValue(myBuilder));
      }
   }
