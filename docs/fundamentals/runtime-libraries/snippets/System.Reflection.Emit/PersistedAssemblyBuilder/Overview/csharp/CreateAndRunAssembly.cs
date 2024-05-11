using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;
using System.Runtime.InteropServices;

public class CreatePersistedAssemblyExample
{
    public static void Main()
    {
        CreateSaveAndRunAssembly();
        CreatePersistedAssemblyBuilderCoreAssemblyWithMetadataLoadContext(RuntimeEnvironment.GetRuntimeDirectory());
    }
    // <Snippet1>
    public static void CreateSaveAndRunAssembly()
    {
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
        ModuleBuilder mob = ab.DefineDynamicModule("MyModule");
        TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
        MethodBuilder meb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                             typeof(int), new Type[] { typeof(int), typeof(int) });
        ILGenerator il = meb.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);

        tb.CreateType();

        using var stream = new MemoryStream();
        ab.Save(stream);  // or pass filename to save into a file
        stream.Seek(0, SeekOrigin.Begin);
        Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(stream);
        MethodInfo method = assembly.GetType("MyType").GetMethod("SumMethod");
        Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
    }
    // </Snippet1>
    // <Snippet2>
    public static void CreatePersistedAssemblyBuilderCoreAssemblyWithMetadataLoadContext(string refAssembliesPath)
    {
        PathAssemblyResolver resolver = new PathAssemblyResolver(Directory.GetFiles(refAssembliesPath, "*.dll"));
        using MetadataLoadContext context = new MetadataLoadContext(resolver);
        Assembly coreAssembly = context.CoreAssembly;
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyDynamicAssembly"), coreAssembly);
        TypeBuilder typeBuilder = ab.DefineDynamicModule("MyModule").DefineType("Test", TypeAttributes.Public);
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("Method", MethodAttributes.Public, coreAssembly.GetType(typeof(int).FullName), Type.EmptyTypes);
        // .. add members and save the assembly
    }
    // </Snippet2>
}
