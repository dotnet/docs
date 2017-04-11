// System.Reflection.Emit.EnumBuilder.Assembly
// System.Reflection.Emit.EnumBuilder.AssemblyQualifiedName
// System.Reflection.Emit.EnumBuilder.Module
// System.Reflection.Emit.EnumBuilder.Name
// System.Reflection.Emit.EnumBuilder.Namespace

/* The following program demonstrates 'Assembly', 'AssemblyQualifiedName',
   'Module', 'Name' and 'Namespace' properties of
   'System.Reflection.Emit.EnumBuilder' class. This example defines a
   class 'MyEnumBuilderSample'. The main function calls the CreateCalle
   method in which the 'EnumBuilder' class and its fields are constructed.
   The output of the 'EnumBuilder' properties are displayed on the console
   in the main method. */

// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>

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

         Console.WriteLine("Properties of EnumBuilder : ");
         Console.WriteLine("Enum Assembly is :" +  myEnumBuilder.Assembly.ToString());
         Console.WriteLine("Enum AssemblyQualifiedName is :" +  
                                 myEnumBuilder.AssemblyQualifiedName.ToString());
         Console.WriteLine("Enum Module is :" +  myEnumBuilder.Module.ToString());
         Console.WriteLine("Enum Name is :" +  myEnumBuilder.Name.ToString());
         Console.WriteLine("Enum NameSpace is :" +  myEnumBuilder.Namespace);
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
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>