using System.Reflection.Emit;
using System.Reflection;
using System;

internal class Reflection
{
    // <SaveAssembly>
    public void CreateAndSaveAssembly(string assemblyPath)
    {
        AssemblyBuilder ab = AssemblyBuilder.DefinePersistedAssembly(
            new AssemblyName("MyAssembly"),
            typeof(object).Assembly
            );
        TypeBuilder tb = ab.DefineDynamicModule("MyModule")
            .DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);

        MethodBuilder mb = tb.DefineMethod(
            "SumMethod",
            MethodAttributes.Public | MethodAttributes.Static,
            typeof(int), [typeof(int), typeof(int)]
            );
        ILGenerator il = mb.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);

        tb.CreateType();
        ab.Save(assemblyPath); // or could save to a Stream
    }

    public void UseAssembly(string assemblyPath)
    {
        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        Type type = assembly.GetType("MyType");
        MethodInfo method = type.GetMethod("SumMethod");
        Console.WriteLine(method.Invoke(null, [5, 10]));
    }
    // </SaveAssembly>
}
