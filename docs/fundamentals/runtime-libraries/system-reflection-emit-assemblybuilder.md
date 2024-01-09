---
title: System.Reflection.Emit.AssemblyBuilder class
description: Learn about the System.Reflection.Emit.AssemblyBuilder class.
ms.date: 12/31/2023
---
# System.Reflection.Emit.AssemblyBuilder class

[!INCLUDE [context](includes/context.md)]

A dynamic assembly is an assembly that is created using the Reflection Emit APIs. You can use <xref:System.Reflection.Emit.AssemblyBuilder> to generate dynamic assemblies in memory and execute their code during the same application run. A dynamic assembly can reference types defined in another dynamic or static assembly.

To get an <xref:System.Reflection.Emit.AssemblyBuilder> object, use the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method.

Dynamic assemblies can be created using one of the following access modes:

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.Run?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code.

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code and is automatically reclaimed by garbage collector.

The access mode must be specified by providing the appropriate <xref:System.Reflection.Emit.AssemblyBuilderAccess> value in the call to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method when the dynamic assembly is defined and cannot be changed later. The runtime uses the access mode of a dynamic assembly to optimize the assembly's internal representation.

In .NET Framework, you can save dynamic assemblies to files. This feature is not available in .NET Core and .NET 5 and later versions. For an alternative way to generate assembly files, see <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder>.

In .NET Framework, a dynamic assembly can consist of one or more dynamic modules. If a dynamic assembly contains more than one dynamic module, the assembly's manifest file name should match the module's name that is specified as the first argument to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicModule%2A> method. In .NET Core and .NET 5+, a dynamic assembly can only consist of one dynamic module.

## Persistable dynamic assemblies in .NET Framework

In .NET Framework, dynamic assemblies and modules can be saved to files. To support this feature, the <xref:System.Reflection.Emit.AssemblyBuilderAccess> enumeration declares two additional fields: <xref:System.Reflection.Emit.AssemblyBuilderAccess.Save> and <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave>. The dynamic assembly created using one of these access modes is called a *persistable* assembly, while the regular memory-only assembly is called *transient*.

The dynamic modules in the persistable dynamic assembly are saved when the dynamic assembly is saved using the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A> method. To generate an executable, the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method must be called to identify the method that is the entry point to the assembly. Assemblies are saved as DLLs by default, unless the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method requests the generation of a console application or a Windows-based application.

Some methods on the base <xref:System.Reflection.Assembly> class, such as `GetModules` and `GetLoadedModules`, will not work correctly when called from <xref:System.Reflection.Emit.AssemblyBuilder> objects. You can load the defined dynamic assembly and call the methods on the loaded assembly. For example, to ensure that resource modules are included in the returned module list, call `GetModules` on the loaded <xref:System.Reflection.Assembly> object.

The signing of a dynamic assembly using <xref:System.Reflection.AssemblyName.KeyPair%2A> is not effective until the assembly is saved to disk. So, strong names will not work with transient dynamic assemblies.

Dynamic assemblies can reference types defined in another assembly. A transient dynamic assembly can safely reference types defined in another transient dynamic assembly, a persistable dynamic assembly, or a static assembly. However, the common language runtime does not allow a persistable dynamic module to reference a type defined in a transient dynamic module. This is because when the persisted dynamic module is loaded after being saved to disk, the runtime cannot resolve the references to types defined in the transient dynamic module.

### Restrictions on emitting to remote application domains in .NET Framework

Some scenarios require a dynamic assembly to be created and executed in a remote application domain. Reflection emit does not allow a dynamic assembly to be emitted directly to a remote application domain. The solution is to emit the dynamic assembly in the current application domain, save the emitted dynamic assembly to disk, and then load the dynamic assembly into the remote application domain. The remoting and application domains are supported only in .NET Framework.
