// FxCop Exception:
// This sample generates FxCop violation SecureLateBindingMethods for 
// Activator.CreateInstance, Type.GetType, etc.. 
// The violation can be ignored, because:
//  - None of the dangerous methods appear in snippets.
//  - The types used are all dynamic types created in this example.
//  - No user input is passed to any member that calls a dangerous method.

// System.Reflection.Emit.TypeBuilder.DefineField()
// System.Reflection.Emit.TypeBuilder.DefineConstructor()
// System.Reflection.Emit.TypeBuilder.AddInterfaceImplementation()
// System.Reflection.Emit.TypeBuilder.BaseType
/* The following program demonstrates the property 'BaseType' and methods 
   'DefineField','DefineConstructor','AddInterfaceImplementation' of the
   class 'TypeBuilder'. 
   The program creates a dynamic assembly and a type within it called as 
   'HelloWorld' This defines a field and implements an interface.
*/
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Security.Permissions;

public class MyTypeBuilder
{
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main() 
   {
      Console.WriteLine("TypeBuilder Sample");
      Console.WriteLine("----------------------");
      // Create 'helloWorldType' .
      Type helloWorldType = CreateDynamicAssembly(Thread.GetDomain(),
                                       AssemblyBuilderAccess.RunAndSave);
      // Create an instance of 'HelloWorld' class.
      Object helloWorld = Activator.CreateInstance(helloWorldType,
                                       new Object[] { "Called HelloWorld" });
      // Invoke 'SayHello' method.
      helloWorldType.InvokeMember("SayHello",
                                BindingFlags.Default |BindingFlags.InvokeMethod 
                               ,null, helloWorld, null);
      // Get defined field in the class.
      Console.WriteLine("Defined Field: " + helloWorldType.GetField("myGreeting").Name);
      AssemblyBuilder myAssemblyBuilder = (AssemblyBuilder)helloWorldType.Assembly;
      myAssemblyBuilder.Save("EmittedAssembly.dll");
   }
   // Declare the interface.
   public interface IHello
   {
      void SayHello();
   }
  
   // Create the transient dynamic assembly.
   private static Type CreateDynamicAssembly(AppDomain myAppDomain, AssemblyBuilderAccess myAccess) 
   {
      // Create a simple name for assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";
      // Create the dynamic assembly.
      AssemblyBuilder myAssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, myAccess);
      // Create a dynamic module named 'CalleeModule' in the assembly.
      ModuleBuilder myModuleBuilder;
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule",
                                                          "EmittedModule.mod");
// <Snippet1>
// <Snippet4>
      // Define a public class named 'myHelloWorld' in the assembly.
      TypeBuilder helloWorldTypeBuilder = 
         myModuleBuilder.DefineType("HelloWorld", TypeAttributes.Public);

      // Get base type.
      Console.WriteLine("Base Type: " + helloWorldTypeBuilder.BaseType.Name);
// </Snippet4>
      // Define 'myGreetingField' field.
      FieldBuilder myGreetingField = 
         helloWorldTypeBuilder.DefineField("myGreeting", typeof(String), 
                                                FieldAttributes.Public);
// </Snippet1>
// <Snippet2>
      // Define the constructor.
      Type[] constructorArgs = { typeof(String) };
      ConstructorBuilder myConstructorBuilder = 
         helloWorldTypeBuilder.DefineConstructor(MethodAttributes.Public, 
                            CallingConventions.Standard, constructorArgs);
      // Generate IL for the method.The constructor stores its argument in the private field.
      ILGenerator myConstructorIL = myConstructorBuilder.GetILGenerator();
      myConstructorIL.Emit(OpCodes.Ldarg_0);
      myConstructorIL.Emit(OpCodes.Ldarg_1);
      myConstructorIL.Emit(OpCodes.Stfld, myGreetingField);
      myConstructorIL.Emit(OpCodes.Ret);
// </Snippet2>
// <Snippet3>
      // Mark the class as implementing 'IHello' interface.
      helloWorldTypeBuilder.AddInterfaceImplementation(typeof(IHello));
      MethodBuilder myMethodBuilder =
         helloWorldTypeBuilder.DefineMethod("SayHello",
                              MethodAttributes.Public|MethodAttributes.Virtual,
                              null,
                              null);
      // Generate IL for 'SayHello' method.
      ILGenerator myMethodIL = myMethodBuilder.GetILGenerator();
      myMethodIL.EmitWriteLine(myGreetingField);
      myMethodIL.Emit(OpCodes.Ret);
     MethodInfo sayHelloMethod = typeof(IHello).GetMethod("SayHello");
     helloWorldTypeBuilder.DefineMethodOverride(myMethodBuilder,sayHelloMethod);
// </Snippet3>
      return(helloWorldTypeBuilder.CreateType());
   }
}
