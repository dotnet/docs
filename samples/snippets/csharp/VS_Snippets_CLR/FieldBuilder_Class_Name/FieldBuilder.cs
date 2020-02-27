using System;
using System.Reflection;
using System.Reflection.Emit;

public class FieldBuilder_Sample
{
   private static Type CreateType()
   {
      // Create an assembly.
      AssemblyName assemName = new AssemblyName();
      assemName.Name = "DynamicAssembly";
      AssemblyBuilder assemBuilder =
                     AssemblyBuilder.DefineDynamicAssembly(assemName, AssemblyBuilderAccess.Run);
      // Create a dynamic module in Dynamic Assembly.
      ModuleBuilder modBuilder = assemBuilder.DefineDynamicModule("DynamicModule");
      // Define a public class named "DynamicClass" in the assembly.
      TypeBuilder typBuilder = modBuilder.DefineType("DynamicClass", TypeAttributes.Public);

      // Define a private String field named "DynamicField" in the type.
      FieldBuilder fldBuilder = typBuilder.DefineField("DynamicField",
          typeof(string), FieldAttributes.Private | FieldAttributes.Static);
      // Create the constructor.
      Type[] constructorArgs = { typeof(String) };
      ConstructorBuilder constructor = typBuilder.DefineConstructor(
         MethodAttributes.Public, CallingConventions.Standard, constructorArgs);
      ILGenerator constructorIL = constructor.GetILGenerator();
      constructorIL.Emit(OpCodes.Ldarg_0);
      ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
      constructorIL.Emit(OpCodes.Call, superConstructor);
      constructorIL.Emit(OpCodes.Ldarg_0);
      constructorIL.Emit(OpCodes.Ldarg_1);
      constructorIL.Emit(OpCodes.Stfld, fldBuilder);
      constructorIL.Emit(OpCodes.Ret);

      // Create the DynamicMethod method.
      MethodBuilder methBuilder= typBuilder.DefineMethod("DynamicMethod",
                           MethodAttributes.Public,typeof(String),null);
      ILGenerator methodIL = methBuilder.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldfld, fldBuilder);
      methodIL.Emit(OpCodes.Ret);

      Console.WriteLine($"Name               : {fldBuilder.Name}");
      Console.WriteLine($"DeclaringType      : {fldBuilder.DeclaringType}");
      Console.WriteLine($"Type               : {fldBuilder.FieldType}");
      return typBuilder.CreateType();
   }

   public static void Main()
   {
      Type dynType = CreateType();
      try
      {
         // Create an instance of the "HelloWorld" class.
         Object helloWorld = Activator.CreateInstance(dynType, new Object[] { "HelloWorld" });
         // Invoke the "DynamicMethod" method of the "DynamicClass" class.
         Object obj  = dynType.InvokeMember("DynamicMethod",
                        BindingFlags.InvokeMethod, null, helloWorld, null);
         Console.WriteLine($"DynamicClass.DynamicMethod returned: \"{obj}\"");
      }
      catch(MethodAccessException e)
      {
         Console.WriteLine($"{e.GetType().Name}: {e.Message}");
      }
  }
}