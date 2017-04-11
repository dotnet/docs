// System.Reflection.Emit.MethodBuilder

/*
   This program demonstrates 'MethodBuilder' class. A dynamic class 'myTypeBuilder'
   is created in which a constructor 'myConstructorBuilder' and a method 'myMethodBuilder'
   are created dynamically. Their IL's are generated. The Non-Public methods of the class
   are printed on the console. The attributes and signature of 'MyDynamicMethod' are displayed
   on the console using 'Attributes' and 'Signature' properties of the 'MethodBuilder' class.
*/

// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public class MethodBuilderClass
{
   public static void Main()
   {
      try
      {
         // Get the current AppDomain.
         AppDomain myAppDomain = AppDomain.CurrentDomain;
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "MyDynamicAssembly";

         // Create the dynamic assembly and set its access mode to 'Save'.
         AssemblyBuilder myAssemblyBuilder = myAppDomain.DefineDynamicAssembly(
                        myAssemblyName, AssemblyBuilderAccess.Save);
         // Create a dynamic module 'myModuleBuilder'.
         ModuleBuilder myModuleBuilder =
              myAssemblyBuilder.DefineDynamicModule("MyDynamicModule", true);
         // Define a public class 'MyDynamicClass'.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("MyDynamicClass",
                                                 TypeAttributes.Public);
         // Define a public string field named 'myField'.
         FieldBuilder myField = myTypeBuilder.DefineField("MyDynamicField",
                        typeof(String), FieldAttributes.Public);
         
         // Define the dynamic method 'MyDynamicMethod'.
         MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("MyDynamicMethod",
                              MethodAttributes.Private, typeof(int), new Type[] {});
         // Generate the IL for 'myMethodBuilder'.
         ILGenerator myMethodIL = myMethodBuilder.GetILGenerator();
         // Emit the necessary opcodes.
         myMethodIL.Emit(OpCodes.Ldarg_0);
         myMethodIL.Emit(OpCodes.Ldfld, myField);
         myMethodIL.Emit(OpCodes.Ret);

         // Create 'myTypeBuilder' class.
         Type myType1 = myTypeBuilder.CreateType();

         // Get the method information of 'myTypeBuilder'.
         MethodInfo[] myInfo = myType1.GetMethods(BindingFlags.NonPublic |
                                                BindingFlags.Instance);
         // Print non-public methods present of 'myType1'.
         Console.WriteLine("\nThe Non-Public methods present in 'myType1' are:\n");
         for(int i = 0; i < myInfo.Length; i++)
         {
            Console.WriteLine(myInfo[i].Name);
         }
         // Print the 'Attribute', 'Signature' of 'myMethodBuilder'.
         Console.WriteLine("\nThe Attribute of 'MyDynamicMethod' is :{0}" ,
                                    myMethodBuilder.Attributes);
         Console.WriteLine("\nThe Signature of 'MyDynamicMethod' is : \n"
                                    + myMethodBuilder.Signature);
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception :{0}", e.Message);
      }
   }
}
// </Snippet1>