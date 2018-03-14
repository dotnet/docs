// System.Reflection.Emit.TypeBuilder.DefineNestedType(string, TypeAttributes, Type, Type[])
// System.Reflection.Emit.TypeBuilder.DefineMethodOverride(MethodInfo, MethodInfo)
// System.Reflection.Emit.TypeBuilder.DefineMethod(string, MethodAttributes,Type,Type[])

/*
   The following program demonstrates the 'DefineNestedType', 'DefineMethodOverride' and
   'DefineMethod' methods of 'TypeBuilder' class. It builds an assembly by defining
   'MyHelloWorld' type. 'MyHelloWorld' class has a nested class 'MyNestedClass' which extends 
   'Example' and implements 'IMyInterface' interface. Then it creates and instance of
   'MyNestedClass' type and calls the 'HelloMethod' using 'IMyInterface' object and
   results are displayed to the console.
*/
// <Snippet1>
// <Snippet2>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

public interface IMyInterface
{
   String HelloMethod(String parameter);
}

public class Example
{
   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      Type myNestedClassType = CreateCallee(Thread.GetDomain());
      // Cretae an instance of 'MyNestedClass'.
      IMyInterface myInterface =
         (IMyInterface)Activator.CreateInstance(myNestedClassType);
      Console.WriteLine(myInterface.HelloMethod("Bill"));
   }

   // Create the callee transient dynamic assembly.
   private static Type CreateCallee(AppDomain myAppDomain)
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "Example";
      // Create the callee dynamic assembly.
      AssemblyBuilder myAssembly =
         myAppDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run);
      // Create a dynamic module in the callee assembly.
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");
      // Define a public class named "MyHelloWorld".
      TypeBuilder myHelloWorldType =
         myModule.DefineType("MyHelloWorld", TypeAttributes.Public);
      // Define a public nested class named 'MyNestedClass'.
      TypeBuilder myNestedClassType =
         myHelloWorldType.DefineNestedType("MyNestedClass",
            TypeAttributes.NestedPublic, typeof(Example),
            new Type[]{typeof(IMyInterface)});
      // Implement 'IMyInterface' interface.
      myNestedClassType.AddInterfaceImplementation(typeof(IMyInterface));
      // Define 'HelloMethod' of 'IMyInterface'.
      MethodBuilder myHelloMethod =
         myNestedClassType.DefineMethod("HelloMethod",
            MethodAttributes.Public | MethodAttributes.Virtual,
            typeof(String), new Type[]{typeof(String)});
      // Generate IL for 'GetGreeting' method.
      ILGenerator myMethodIL = myHelloMethod.GetILGenerator();
      myMethodIL.Emit(OpCodes.Ldstr, "Hi! ");
      myMethodIL.Emit(OpCodes.Ldarg_1);
      MethodInfo infoMethod =
         typeof(String).GetMethod("Concat",new Type[]{typeof(string),typeof(string)});
      myMethodIL.Emit(OpCodes.Call, infoMethod);
      myMethodIL.Emit(OpCodes.Ret);

      MethodInfo myHelloMethodInfo =
         typeof(IMyInterface).GetMethod("HelloMethod");
      // Implement 'HelloMethod' of 'IMyInterface'.
      myNestedClassType.DefineMethodOverride(myHelloMethod, myHelloMethodInfo);
      // Create 'MyHelloWorld' type.
      Type myType = myHelloWorldType.CreateType();
      // Create 'MyNestedClass' type.
      return myNestedClassType.CreateType();
   }
}
// </Snippet2>
// </Snippet1>