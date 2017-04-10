// System.Reflection.Emit.ConstructorBuilder.SetSymCustomAttribute()

/* The following program demonstrates the 'SetSymCustomAttribute' method
   of ConstructorBuilder class. It creates an assembly in the current 
   domain with dynamic module in the assembly. Constructor builder is
   used in conjunction with the 'TypeBuilder' class to create constructor
   at run time. It then sets this constructor's custom attribute associated
   with symbolic information.
*/ 

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

internal class MyConstructorBuilder
{
   Type myType1;
   ModuleBuilder myModuleBuilder=null;
   AssemblyBuilder myAssemblyBuilder = null;

   internal MyConstructorBuilder()
   {
// <Snippet1>
      MethodBuilder myMethodBuilder = null;
      AppDomain myCurrentDomain = AppDomain.CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
               (myAssemblyName, AssemblyBuilderAccess.Run);
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule",true);
      FieldInfo myFieldInfo =
         myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public);
      // Create a type in the module.
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
      FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting", 
                                          typeof(String), FieldAttributes.Public);
      Type[] myConstructorArgs = { typeof(String) };
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
      MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      // Display the name of the constructor.
      Console.WriteLine("The constructor name is  : "+ myConstructor.Name);
      myConstructor.SetSymCustomAttribute("MySimAttribute", new byte[]{01,00,00});
// </Snippet1>
      // Generate the IL for the method and call its superclass constructor.
      ILGenerator myILGenerator3 = myConstructor.GetILGenerator();
      myILGenerator3.Emit(OpCodes.Ldarg_0);
      ConstructorInfo myConstructorInfo = typeof(Object).GetConstructor(new Type[0]);
      myILGenerator3.Emit(OpCodes.Call, myConstructorInfo);
      myILGenerator3.Emit(OpCodes.Ldarg_0);
      myILGenerator3.Emit(OpCodes.Ldarg_1);
      myILGenerator3.Emit(OpCodes.Stfld, myGreetingField);
      myILGenerator3.Emit(OpCodes.Ret);
      // Add a method to the type.
      myMethodBuilder = myTypeBuilder.DefineMethod
         ("HelloWorld",MethodAttributes.Public,null,null);
      // Generate IL for the method.
      ILGenerator myILGenerator2 = myMethodBuilder.GetILGenerator();
      myILGenerator2.EmitWriteLine("Hello World from global");
      myILGenerator2.Emit(OpCodes.Ret);
      myModuleBuilder.CreateGlobalFunctions();
      myType1 = myTypeBuilder.CreateType();
   }

   internal Type MyTypeProperty
   {
      get
      {
         return this.myType1;
      }
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      MyConstructorBuilder myConstructorBuilder = new MyConstructorBuilder();
      Type myType1 = myConstructorBuilder.MyTypeProperty;
      if (null != myType1)
      {
         Console.WriteLine("Instantiating the new type...");
         Object[] myObject = {"hello"};
         object myObject1 = Activator.CreateInstance(myType1,myObject,null);
         MethodInfo myMethodInfo = myType1.GetMethod("HelloWorld");
         if (null != myMethodInfo)
         {
            Console.WriteLine("Invoking dynamically created HelloWorld method...");
            myMethodInfo.Invoke(myObject1, null);
         }
         else
         {
            Console.WriteLine("Could not locate HelloWorld method");
         }
      }
      else
      {
         Console.WriteLine("Could not access Type.");
      }
   }
}