// System.Reflection.Emit.ConstructorBuilder.GetModule()
// System.Reflection.Emit.ConstructorBuilder.GetToken()
// System.Reflection.Emit.ConstructorBuilder.GetMethodImplementationFlags()
// System.Reflection.Emit.ConstructorBuilder.GetParameters()

/* The following program demonstrates the 'GetModule','GetToken',
   'GetMethodImplementationFlags' and 'GetParameters'
   methods of 'ConstructorBuilder' class.  Create the assembly
   in the current domain with dynamic module in the assembly. Constructor
   builder is used in conjunction with the 'TypeBuilder' class to create
   constructor at run time. Set a custom attribute using a custom attribute
   builder and displays module name, Token id and parameter info of this class.
*/

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using System.Security.Permissions;

internal class MyConstructorBuilder
{
   Type myType1;
   ModuleBuilder myModuleBuilder=null;
   AssemblyBuilder myAssemblyBuilder = null;

   internal MyConstructorBuilder()
   {
// <Snippet1>
// <Snippet3>

      MethodBuilder myMethodBuilder = null;
      AppDomain myCurrentDomain = AppDomain.CurrentDomain;
      // Create assembly in current CurrentDomain.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "TempAssembly";
      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
                                    (myAssemblyName, AssemblyBuilderAccess.Run);
      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule");
      // Create a type in the module.
      TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("TempClass",TypeAttributes.Public);
      FieldBuilder myGreetingField = myTypeBuilder.DefineField("Greeting",
         typeof(String), FieldAttributes.Public);
      Type[] myConstructorArgs = { typeof(String) };
// <Snippet2>
// <Snippet4>
      // Define a constructor of the dynamic class.
      ConstructorBuilder myConstructorBuilder = myTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, myConstructorArgs);
      // Get a reference to the module that contains this constructor.
      Module myModule = myConstructorBuilder.GetModule();
      Console.WriteLine("Module Name : " + myModule.Name);
      // Get the 'MethodToken' that represents the token for this constructor.
      MethodToken myMethodToken = myConstructorBuilder.GetToken();
      Console.WriteLine("Constructor Token is : " + myMethodToken.Token);
      // Get the method implementation flags for this constructor.
      MethodImplAttributes myMethodImplAttributes = myConstructorBuilder.GetMethodImplementationFlags();
      Console.WriteLine("MethodImplAttributes : "  + myMethodImplAttributes);
// </Snippet3>
// </Snippet2>
// </Snippet1>
      // Generate IL for the method, call its base class constructor and store the arguments
      // in the private field.
      ILGenerator myILGenerator3 = myConstructorBuilder.GetILGenerator();
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

      // Get the parameters of this constructor.
      ParameterInfo[] myParameterInfo = myConstructorBuilder.GetParameters();
      for(int i =0 ; i < myParameterInfo.Length; i++)
      {
         Console.WriteLine("Declaration type : " + myParameterInfo[i].Member.DeclaringType);
      }
// </Snippet4>
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
      MyConstructorBuilder myConstructorBuilder1 = new MyConstructorBuilder();
      Type myTypeProperty = myConstructorBuilder1.MyTypeProperty;
      if (null != myTypeProperty)
      {
         Object[] myObject = {"Hello"};
         object myObject1 = Activator.CreateInstance(myTypeProperty,myObject,null);
         MethodInfo myMethodInfo = myTypeProperty.GetMethod("HelloWorld");

         if (null != myMethodInfo)
         {
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
