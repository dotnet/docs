// System.Reflection.Emit.EnumBuilder.TypeToken
// System.Reflection.Emit.EnumBuilder.UnderlyingField
// System.Reflection.Emit.EnumBuilder.UnderlyingSystemType
// System.Reflection.Emit.EnumBuilder.GUID

/* The following program demonstrates 'TypeToken', 'UnderlyingField',
   'UnderlyingSystemType' and ''GUID' properties of
   'System.Reflection.Emit.EnumBuilder' class. This example defines
   a class 'MyEnumBuilderSample'. The main function calls the CreateCalle
   method in which the 'EnumBuilder' class and its fields are constructed.
   The output of the 'EnumBuilder' properties are displayed on the console
   in the main method. */

// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>

using System;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MyEnumBuilderSample
{
   static AssemblyBuilder myAssemblyBuilder;
   static ModuleBuilder myModuleBuilder;
   static EnumBuilder myEnumBuilder;
   
   public static void Main()
   {
      try
      {
         CreateCallee(Thread.GetDomain(), AssemblyBuilderAccess.Save);
         Type[] myTypeArray = myModuleBuilder.GetTypes();
         foreach(Type myType in myTypeArray)
         {
            Console.WriteLine("Enum Builder defined in the module builder is: " 
               + myType.Name);
         }

         Console.WriteLine("Enum TypeToken is :" +  
                                       myEnumBuilder.TypeToken.ToString());
         Console.WriteLine("Enum UnderLyingField is :" +  
                                    myEnumBuilder.UnderlyingField.ToString());
         Console.WriteLine("Enum UnderLyingSystemType is :" +  
                              myEnumBuilder.UnderlyingSystemType.ToString());
         Console.WriteLine("Enum GUID is :" + myEnumBuilder.GUID.ToString());
         myAssemblyBuilder.Save("EmittedAssembly.dll");
      }
      catch(NotSupportedException ex)
      {
         Console.WriteLine("The following is the exception is raised: " + ex.Message);
      }
      catch(Exception e)
      {
         Console.WriteLine("The following is the exception raised: " + e.Message);
      }
   }

   private static void CreateCallee(AppDomain myAppDomain, AssemblyBuilderAccess access)
   {
      // Create a name for the assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";

      // Create the dynamic assembly.
      myAssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, 
                                             AssemblyBuilderAccess.Save);
      // Create a dynamic module.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule", 
                                                         "EmittedModule.mod");
      // Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder.DefineEnum("MyNamespace.MyEnum", 
                                 TypeAttributes.Public, typeof(Int32));

      FieldBuilder myFieldBuilder1 = myEnumBuilder.DefineLiteral("FieldOne", 1);
      FieldBuilder myFieldBuilder2 = myEnumBuilder.DefineLiteral("FieldTwo", 2);

      myEnumBuilder.CreateType();
   }
}
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>