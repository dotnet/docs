// System.Reflection.Emit.ConstructorBuilder.SetImplementationFlags()

/* The following program demonstrates the 'SetImplementationFlags'
   method of ConstructorBuilder class. It creates an assembly in the
   current domain with a dynamic module in the assembly. Constructor 
   builder is used in conjunction with the 'TypeBuilder' class to create
   constructor at run time. It then sets the method implementation flags
   for the constructor and displays the same.
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
      try
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
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", true);
         FieldInfo myFieldInfo2 =
            myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public);
         // Create a type in the module.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
         FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting", 
            typeof(String), FieldAttributes.Public);
         Type[] myConstructorArgs = { typeof(String) };
         // Define a constructor of the dynamic class.
         ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
            MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
         // Set the method implementation flags for the constructor.
         myConstructor.SetImplementationFlags(MethodImplAttributes.PreserveSig | MethodImplAttributes.Runtime);
         // Get the method implementation flags for the constructor.
         MethodImplAttributes myMethodAttributes = myConstructor.GetMethodImplementationFlags();
         Type myAttributeType = typeof(MethodImplAttributes);
         int myAttribValue = (int) myMethodAttributes;
         if(! myAttributeType.IsEnum)
         {
            Console.WriteLine("This is not an Enum");
         }
         // Display the field info names of the retrieved method implementation flags.
         FieldInfo[] myFieldInfo = myAttributeType.GetFields(BindingFlags.Public | BindingFlags.Static);
         Console.WriteLine("The Field info names of the MethodImplAttributes for the constructor are:");
         for (int i = 0; i < myFieldInfo.Length; i++)
         {
            int myFieldValue = (Int32)myFieldInfo[i].GetValue(null);
            if ((myFieldValue & myAttribValue) == myFieldValue)
            {
               Console.WriteLine("   " + myFieldInfo[i].Name);
            }
         }
// </Snippet1>
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
      catch(InvalidOperationException ex)
      {
         Console.WriteLine("The following exception has occured : "+ex.Message);
      }
      catch(Exception ex)
      {
         Console.WriteLine("The following exception has occured : "+ex.Message);
      }
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