---
title: System.Reflection.Emit.AssemblyBuilder class
description: Learn about the System.Reflection.Emit.AssemblyBuilder class.
ms.date: 12/31/2023
---
# System.Reflection.Emit.AssemblyBuilder class

[!INCLUDE [context](includes/context.md)]

A dynamic assembly is an assembly that is created using the Reflection Emit APIs. A dynamic assembly can reference types defined in another dynamic or static assembly. You can use <xref:System.Reflection.Emit.AssemblyBuilder> to generate dynamic assemblies in memory and execute their code during the same application run. In .NET 9.0 we added new fully managed implementation for reflection emit that allows you save the asembly into a file. In .NET Framework, you can do both, run the dynamic assembly and save the assemblies to files. The dynamic assembly created for saving is called a *persistable* assembly, while the regular memory-only assembly is called *transient*. In .NET Framework, a dynamic assembly can consist of one or more dynamic modules. In .NET Core and .NET 5+, a dynamic assembly can only consist of one dynamic module.

The way of creating <xref:System.Reflection.Emit.AssemblyBuilder> instance differs for each implementation, but further steps for defining a module/type/method/enum etc., and writing IL are quite similar:

## Runnable dynamic assemblies in .NET Core

To get a runnable <xref:System.Reflection.Emit.AssemblyBuilder> object, use the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method.
Dynamic assemblies can be created using one of the following access modes:

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.Run?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code.

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code and is automatically reclaimed by garbage collector.

The access mode must be specified by providing the appropriate <xref:System.Reflection.Emit.AssemblyBuilderAccess> value in the call to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method when the dynamic assembly is defined and cannot be changed later. The runtime uses the access mode of a dynamic assembly to optimize the assembly's internal representation.

The following example demonstrates how to create and run assembly:

```cs
public void CreateAndRunAssembly(string assemblyPath)
{
    AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);
    ModuleBuilder mob = ab.DefineDynamicModule("MyModule");
    TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder mb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
    ILGenerator il = mb.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Ret);

    Type type = tb.CreateType();
    
    MethodInfo method = type.GetMethod("SumMethod");
    Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
}
```

## Persistable dynamic assemblies in .NET Core

The `AssemblyBuilder.Save` API was not ported to .NET core because of technical difficulties like the implementation heavily depend on windows specific native code that also not ported into .NET Core. When .NET Core developers can only run the generated assemblies it was very difficult to debug in-memory assemblies without having an option to save an assembly. Saving the assembly to a file allows generated assemblies to be verified with tools such as ILVerify, or decompiled and manually examined with tools such as ILSpy. Furthermore, the saved assembly can be shared or loaded directly which can be used to decrease application startup time.

In .NET 9.0 we are adding fully managed new `Reflection.Emit` implementation that supports saving. This implementation has no dependency from existing runtime specific `Reflection.Emit` implementation, i.e. now we have two different implementations in .NET Core. The assemblies generated with new managed implementation can be saved, to run the assembly user should save it into a memory stream or a file first, then load it back.  

For creating a new persistable `AssemblyBuilder` instance you should use the new static factory method `AssemblyBuilder.DefinePersistedAssembly`:

```cs
public static DefinePersistedAssembly(AssemblyName name, Assembly coreAssembly,
                                             IEnumerable<CustomAttributeBuilder>? assemblyAttributes = null);
```

The `coreAssembly` passed to the method used for resolving base runtime types and can be used for resolving reference assemblies versioning.

- if `Reflection.Emit` is used to generate assembly that targets specific TFM, the reference assemblies for the given TFM should be opened using `MetadataLoadContext` and the value of [MetadataLoadContext.CoreAssembly](https://learn.microsoft.com/dotnet/api/system.reflection.metadataloadcontext.coreassembly) property should be used as the coreAssembly. It allows the generator to run on one .NET runtime version and target a different .NET runtime version.

- If `Reflection.Emit` is used to generate an assembly that is only going to be executed on the same runtime version as the runtime version that the compiler is running on (typically in-proc), the core assembly can be `typeof(object).Assembly`. The reference assemblies are not necessary in this case.

The following example demonstrates how to create and save an assembly to a stream and run it:

```cs
public void CreateSaveAndRunAssembly(string assemblyPath)
{
    AssemblyBuilder ab = AssemblyBuilder.DefinePersistedAssembly(new AssemblyName("MyAssembly"), typeof(object).Assembly);
    ModuleBuilder mob = ab.DefineDynamicModule("MyModule");
    TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder meb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
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
```

> [!NOTE]
> The metadata tokens for all members are populated on `Save(...)` operation, do not use the tokens of generated type and its members before saving as they will have default values or throw. It is safe to use tokens for types that are referenced, not generated.
> Some APIs that are not improtant for emitting assembly are not implemented, for example `GetCustomAttributes()` is not implemented, with the runtime implementation you were able to use those APIs after creating the type, for persisted `AssemblyBuilder` they would throw `NotSupportedException` or `NotImplementedException`. If you have a scenario that needs those APIs implemented file an issue in the [repo](https://github.com/dotnet/runtime).

For an alternative way to generate assembly files, see <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder>.

## Persistable dynamic assemblies in .NET Framework

In .NET Framework, dynamic assemblies and modules can be saved to files. To support this feature, the <xref:System.Reflection.Emit.AssemblyBuilderAccess> enumeration declares two additional fields: <xref:System.Reflection.Emit.AssemblyBuilderAccess.Save> and <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave>.

The dynamic modules in the persistable dynamic assembly are saved when the dynamic assembly is saved using the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A> method. To generate an executable, the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method must be called to identify the method that is the entry point to the assembly. Assemblies are saved as DLLs by default, unless the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method requests the generation of a console application or a Windows-based application.

The following example demonstrates how to create and save and run assembly using .NET Framework:

```cs
public void CreateRunAndSaveAssembly(string assemblyPath)
{
    AssemblyBuilder ab = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName("MyAssembly"), AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder mob = ab.DefineDynamicModule("MyAssembly.dll");
    TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder meb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
    ILGenerator il = meb.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Ret);

    Type type = tb.CreateType();

    MethodInfo method = type.GetMethod("SumMethod");
    Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
    ab.Save("MyAssembly.dll");
}
```

Some methods on the base <xref:System.Reflection.Assembly> class, such as `GetModules` and `GetLoadedModules`, will not work correctly when called from <xref:System.Reflection.Emit.AssemblyBuilder> objects. You can load the defined dynamic assembly and call the methods on the loaded assembly. For example, to ensure that resource modules are included in the returned module list, call `GetModules` on the loaded <xref:System.Reflection.Assembly> object. If a dynamic assembly contains more than one dynamic module, the assembly's manifest file name should match the module's name that is specified as the first argument to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicModule%2A> method.

The signing of a dynamic assembly using <xref:System.Reflection.AssemblyName.KeyPair%2A> is not effective until the assembly is saved to disk. So, strong names will not work with transient dynamic assemblies.

Dynamic assemblies can reference types defined in another assembly. A transient dynamic assembly can safely reference types defined in another transient dynamic assembly, a persistable dynamic assembly, or a static assembly. However, the common language runtime does not allow a persistable dynamic module to reference a type defined in a transient dynamic module. This is because when the persisted dynamic module is loaded after being saved to disk, the runtime cannot resolve the references to types defined in the transient dynamic module.

### Restrictions on emitting to remote application domains in .NET Framework

Some scenarios require a dynamic assembly to be created and executed in a remote application domain. Reflection emit does not allow a dynamic assembly to be emitted directly to a remote application domain. The solution is to emit the dynamic assembly in the current application domain, save the emitted dynamic assembly to disk, and then load the dynamic assembly into the remote application domain. The remoting and application domains are supported only in .NET Framework.
