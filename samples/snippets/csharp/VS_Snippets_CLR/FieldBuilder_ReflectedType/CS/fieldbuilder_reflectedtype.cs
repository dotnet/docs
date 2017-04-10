// System.Reflection.Emit.FieldBuilder.ReflectedType
// System.Reflection.Emit.FieldBuilder.Attributes

/*
   The following example demonstrates 'ReflectedType' and 'Attributes'
   properties of 'FieldBuilder' class.A new class 'MyClass' is created.
   A  Field and a method are defined in the class.In the constructor of the class
   the field is initialized.Method of the class gets the value of the Field.
   An instance of the class is created and method is invoked.
*/
// <Snippet1>
using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

public class FieldBuilder_Sample
{
   private static Type CreateType(AppDomain currentDomain)
   {


      // Create an assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "DynamicAssembly";
      AssemblyBuilder myAssembly =
         currentDomain.DefineDynamicAssembly(myAssemblyName,AssemblyBuilderAccess.Run);
      // Create a dynamic module in Dynamic Assembly.
      ModuleBuilder myModuleBuilder=myAssembly.DefineDynamicModule("MyModule");
      // Define a public class named "MyClass" in the assembly.
      TypeBuilder myTypeBuilder= myModuleBuilder.DefineType("MyClass",TypeAttributes.Public);

      // Define a private String field named "MyField" in the type.
      FieldBuilder myFieldBuilder= myTypeBuilder.DefineField("MyField",
         typeof(string),FieldAttributes.Private|FieldAttributes.Static);
      // Create the constructor.
      Type[] constructorArgs = { typeof(String) };
      ConstructorBuilder myConstructor = myTypeBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, constructorArgs);
      ILGenerator constructorIL = myConstructor.GetILGenerator();
      constructorIL.Emit(OpCodes.Ldarg_0);
      ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
      constructorIL.Emit(OpCodes.Call, superConstructor);
      constructorIL.Emit(OpCodes.Ldarg_0);
      constructorIL.Emit(OpCodes.Ldarg_1);
      constructorIL.Emit(OpCodes.Stfld, myFieldBuilder);
      constructorIL.Emit(OpCodes.Ret);

      // Create the MyMethod method.
      MethodBuilder myMethodBuilder= myTypeBuilder.DefineMethod("MyMethod",
         MethodAttributes.Public,typeof(String),null);
      ILGenerator methodIL = myMethodBuilder.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldfld, myFieldBuilder);
      methodIL.Emit(OpCodes.Ret);
      if (myFieldBuilder.Attributes.Equals(FieldAttributes.Static))
      {
            Console.WriteLine("Field attribute defined as Static");
      }
      else if(myFieldBuilder.Attributes.Equals(FieldAttributes.Static|FieldAttributes.Private))
      {
         Console.WriteLine("Field attributes are Static and Private");
      }
      Console.WriteLine("ReflectedType of Field is: " + myFieldBuilder.ReflectedType);

      return myTypeBuilder.CreateType();
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      Type myType = CreateType(Thread.GetDomain());
      // Create an instance of the "HelloWorld" class.
      Object helloWorld = Activator.CreateInstance(myType, new Object[] { "HelloWorld" });
      // Invoke the "MyMethod"  of the "MyClass".
      Object myObject  = myType.InvokeMember("MyMethod",
         BindingFlags.InvokeMethod, null, helloWorld, null);
      Console.WriteLine("MyClass.MyMethod returned: \"" + myObject + "\"");
   }
}
// </Snippet1>