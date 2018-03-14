// System.Reflection.Emit.ConstructorBuilder.AddDeclarativeSecurity()
// System.Reflection.Emit.ConstructorBuilder.Attributes
// System.Reflection.Emit.ConstructorBuilder.DeclaringType
// System.Reflection.Emit.ConstructorBuilder.DefineParameter()

/* The following program demonstrates the 'AddDeclarativeSecurity',
   'DefineParameter' methods, and  'Attributes', 'DeclaringType' properties
   of the ConstructorBuilder class. Create the assembly in the current domain
   with dynamic module in the assembly. Constructor  builder is used in
   conjunction with the 'TypeBuilder' class to create constructor at run time.
   Add declarative security to the constructor. Display the 'Attributes',
   'DeclaringType' and 'DefineParameter'.
*/

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Security;

internal class MyConstructorBuilder
{
   Type myType1;
   ModuleBuilder myModuleBuilder=null;
   AssemblyBuilder myAssemblyBuilder = null;

   internal MyConstructorBuilder()
   {
// <Snippet1>
// <Snippet2>
// <Snippet3>
      MethodBuilder myMethodBuilder=null;

      AppDomain myCurrentDomain = AppDomain.CurrentDomain;
      // Create assembly in current CurrentDomain
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "TempAssembly";
      // Create a dynamic assembly
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
         (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");
      FieldInfo myFieldInfo =
         myModuleBuilder.DefineUninitializedData("myField",2,FieldAttributes.Public);
      // Create a type in the module
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
      FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting",
         typeof(String), FieldAttributes.Public);
      Type[] myConstructorArgs = { typeof(String) };
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      PermissionSet myPset = new PermissionSet(PermissionState.Unrestricted);
      // Add declarative security to the constructor.
      Console.WriteLine("Adding declarative security to the constructor.....");
      Console.WriteLine("The Security action to be taken is \"DENY\" and" +
         " Permission set is \"UNRESTRICTED\".");
      myConstructor.AddDeclarativeSecurity(SecurityAction.Deny,myPset);
// </Snippet3>
      MethodAttributes myMethodAttributes = myConstructor.Attributes;
      Type myAttributeType = typeof(MethodAttributes);
      int myAttribValue = (int) myMethodAttributes;
      if(! myAttributeType.IsEnum)
      {
         Console.WriteLine("This is not an Enum");
      }
      FieldInfo[] myFieldInfo1 = myAttributeType.GetFields(BindingFlags.Public | BindingFlags.Static);
      Console.WriteLine("The Field info names of the Attributes for the constructor are:");
      for (int i = 0; i < myFieldInfo1.Length; i++)
      {
         int myFieldValue = (Int32)myFieldInfo1[i].GetValue(null);
         if ((myFieldValue & myAttribValue) == myFieldValue)
         {
            Console.WriteLine("   " + myFieldInfo1[i].Name);
         }
      }

      Type myType2 = myConstructor.DeclaringType;
      Console.WriteLine("The declaring type is : "+myType2.ToString());
// </Snippet2>
      ParameterBuilder myParameterBuilder1 =
         myConstructor.DefineParameter(1,  ParameterAttributes.Out, "My Parameter Name1");
      Console.WriteLine("The name of the parameter is : " +
         myParameterBuilder1.Name);
      if(myParameterBuilder1.IsIn)
         Console.WriteLine(myParameterBuilder1.Name +" is Input parameter.");
      else
         Console.WriteLine(myParameterBuilder1.Name +" is not Input Parameter.");
      ParameterBuilder myParameterBuilder2 =
         myConstructor.DefineParameter(1, ParameterAttributes.In, "My Parameter Name2");
      Console.WriteLine("The Parameter name is : " +
         myParameterBuilder2.Name);
      if(myParameterBuilder2.IsIn)
         Console.WriteLine(myParameterBuilder2.Name +" is Input parameter.");
      else
         Console.WriteLine(myParameterBuilder2.Name + " is not Input Parameter.");
// </Snippet1>
      // Generate MSIL for the method, call its base class constructor and store the arguments
      // in the private field.
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
      // Generate MSIL for the method.
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