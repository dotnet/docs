// System.Reflection.Emit.PropertyBuilder.SetGetMethod
// System.Reflection.Emit.PropertyBuilder.SetSetMethod
// System.Reflection.Emit.PropertyBuilder.AddOtherMethod
// System.Reflection.Emit.PropertyBuilder

/*
   This following program demonstrates methods 'SetGetMethod','SetSetMethod' and
   'AddOtherMethod' of class 'PropertyBuilder'.

   A dynamic assembly is generated with  a class having a property 'Greeting'.
   Its 'get' and 'set' method are created by returning and setting a string respectively.
   This property value is reset with default string using othermethod.
 */

// <Snippet4>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

public class App
{
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      // Create the "HelloWorld" type in an assembly with mode 'RunAndSave'.
      Type helloWorldType = CreateCallee(Thread.GetDomain(), AssemblyBuilderAccess.RunAndSave);

      // Create an instance of the "HelloWorld" class.
      Object helloWorld = Activator.CreateInstance(helloWorldType, new object[] { "HelloWorld" });
      Object returnValue = helloWorldType.InvokeMember("Greeting",
                     BindingFlags.Default |BindingFlags.GetProperty
                     ,null, helloWorld, null);
      Console.WriteLine("HelloWorld.GetGreeting returned: \"" + returnValue + "\"");

      // Set 'Greeting' property with 'NewMessage!!!'.
      helloWorldType.InvokeMember("Greeting",
                  BindingFlags.Default |BindingFlags.SetProperty
                  ,null, helloWorld, new object [] {"New Message !!!"});
      returnValue = helloWorldType.InvokeMember("Greeting",
                  BindingFlags.Default |BindingFlags.GetProperty
                  ,null, helloWorld, null);
      Console.WriteLine("After Set operation HelloWorld.GetGreeting returned: \"" + returnValue + "\"");

      // Reset 'Greeting' property to 'Default String'.
      helloWorldType.InvokeMember("reset_Greeting",
                              BindingFlags.Default |BindingFlags.InvokeMethod
                              ,null, helloWorld, null);
      returnValue = helloWorldType.InvokeMember("Greeting",
                              BindingFlags.Default |BindingFlags.GetProperty
                              ,null, helloWorld, null);
      Console.WriteLine("After Reset operation HelloWorld.GetGreeting returned: \"" + returnValue + "\"");

      AssemblyBuilder myAssembly = (AssemblyBuilder) helloWorldType.Assembly;
      // Save to disk.
      myAssembly.Save("EmittedAssembly.dll");
   }

   // Create the callee transient dynamic assembly.
   private static Type CreateCallee(AppDomain myAppDomain, AssemblyBuilderAccess access)
   {
      // Create a simple name for the callee assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";
      // Create the callee dynamic assembly.
      AssemblyBuilder myAssemblyBuilder =
                     myAppDomain.DefineDynamicAssembly(myAssemblyName, access);
      // Create a dynamic module named "EmittedModule" in the callee assembly.
      ModuleBuilder myModule;
      if (access == AssemblyBuilderAccess.Run)
      {
         myModule = myAssemblyBuilder.DefineDynamicModule("EmittedModule");
      }
      else
      {
         myModule = myAssemblyBuilder.DefineDynamicModule("EmittedModule", "EmittedModule.mod");
      }
// <Snippet2>
      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldTypeBuilder = myModule.DefineType("HelloWorld", TypeAttributes.Public);
      // Define a private String field named "m_greeting" in "HelloWorld" class.
      FieldBuilder greetingFieldBuilder = helloWorldTypeBuilder.DefineField("m_greeting",
                                                typeof(String), FieldAttributes.Private);
      // Create constructor args and define constructor.
      Type[] constructorArgs = { typeof(String) };
      ConstructorBuilder constructor = helloWorldTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, constructorArgs);

      // Generate IL code for the method.The constructor stores its argument in the private field.
      ILGenerator constructorIL = constructor.GetILGenerator();
      constructorIL.Emit(OpCodes.Ldarg_0);
      constructorIL.Emit(OpCodes.Ldarg_1);
      constructorIL.Emit(OpCodes.Stfld, greetingFieldBuilder);
      constructorIL.Emit(OpCodes.Ret);
// <Snippet1>
      // Define property Greeting.
      PropertyBuilder greetingPropertyBuilder = helloWorldTypeBuilder.DefineProperty(
                               "Greeting",PropertyAttributes.None,typeof(string),null);

      // Define the 'get_Greeting' method.
      MethodBuilder getGreetingMethod = helloWorldTypeBuilder.DefineMethod("get_Greeting",
         MethodAttributes.Public|MethodAttributes.HideBySig|MethodAttributes.SpecialName,
         typeof(String),null);
      // Generate IL code for 'get_Greeting' method.
      ILGenerator methodIL = getGreetingMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldfld, greetingFieldBuilder);
      methodIL.Emit(OpCodes.Ret);
      greetingPropertyBuilder.SetGetMethod(getGreetingMethod);
// </Snippet1>

      // Define the set_Greeting method.
      Type[] methodArgs = {typeof(string)};
      MethodBuilder setGreetingMethod = helloWorldTypeBuilder.DefineMethod("set_Greeting",
         MethodAttributes.Public|MethodAttributes.HideBySig|MethodAttributes.SpecialName,
         typeof(void), methodArgs);
      // Generate IL code for set_Greeting method.
      methodIL = setGreetingMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldarg_1);
      methodIL.Emit(OpCodes.Stfld,greetingFieldBuilder);
      methodIL.Emit(OpCodes.Ret);
      greetingPropertyBuilder.SetSetMethod(setGreetingMethod);
// </Snippet2>
// <Snippet3>
      // Define the reset_Greeting method.
      MethodBuilder otherGreetingMethod = helloWorldTypeBuilder.DefineMethod("reset_Greeting",
         MethodAttributes.Public|MethodAttributes.HideBySig,
         typeof(void), null);
      // Generate IL code for reset_Greeting method.
      methodIL = otherGreetingMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldstr,"Default String.");
      methodIL.Emit(OpCodes.Stfld, greetingFieldBuilder);
      methodIL.Emit(OpCodes.Ret);
      greetingPropertyBuilder.AddOtherMethod(otherGreetingMethod);
// </Snippet3>
      // Create the class HelloWorld.
      return(helloWorldTypeBuilder.CreateType());
   }
}
// </Snippet4>
