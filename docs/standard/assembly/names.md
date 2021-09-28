---
title: "Assembly names"
description: Learn about .NET assembly names and their impact on assembly scope and use by an application, and learn about the FullName property.
ms.date: "08/19/2019"
helpviewer_keywords:
  - "names [.NET], assemblies"
  - "assemblies [.NET], names"
ms.assetid: 8f8c2c90-f15d-400e-87e7-a757e4f04d0e
---
# Assembly names

An assembly's name is stored in metadata and has a significant impact on the assembly's scope and use by an application. A strong-named assembly has a fully qualified name that includes the assembly's name, culture, public key, version number, and, optionally, processor architecture. Use the <xref:System.Reflection.Assembly.FullName%2A> property to obtain the fully qualified name, frequently referred to as the display name, for loaded assemblies.

The runtime uses the name information to locate the assembly and differentiate it from other assemblies with the same name. For example, a strong-named assembly called `myTypes` could have the following fully qualified name:

```
myTypes, Version=1.0.1234.0, Culture=en-US, PublicKeyToken=b77a5c561934e089c, ProcessorArchitecture=msil
```

In this example, the fully qualified name indicates that the `myTypes` assembly has a strong name with a public key token, has the culture value for United States English, and has a version number of 1.0.1234.0. Its processor architecture is `msil`, which means that it will be just-in-time (JIT)-compiled to 32-bit code or 64-bit code depending on the operating system and processor.

> [!TIP]
> The `ProcessorArchitecture` information allows processor-specific versions of assemblies. You can create versions of an assembly whose identity differs only by processor architecture, for example 32-bit and 64-bit processor-specific versions. Processor architecture is not required for strong names. For more information, see <xref:System.Reflection.AssemblyName.ProcessorArchitecture%2A?displayProperty=nameWithType>.

 Code that requests types in an assembly must use a fully qualified assembly name. This is called fully qualified binding. Partial binding, which specifies only an assembly name, is not permitted when referencing assemblies in .NET Framework.

 All assembly references to assemblies that make up .NET Framework must also contain the fully qualified name of the assembly. For example, a reference to the System.Data .NET Framework assembly for version 1.0 would include:

```
System.data, version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
```

The version corresponds to the version number of all .NET Framework assemblies that shipped with .NET Framework version 1.0. For .NET Framework assemblies, the culture value is always neutral, and the public key is the same as shown in the above example.

 For example, to add an assembly reference in a configuration file to set up a trace listener, you would include the fully qualified name of the system .NET Framework assembly:

```xml
<add name="myListener" type="System.Diagnostics.TextWriterTraceListener, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="c:\myListener.log" />
```

> [!NOTE]
> The runtime treats assembly names as case-insensitive when binding to an assembly, but preserves whatever case is used in an assembly name. Several tools in the Windows SDK handle assembly names as case-sensitive. For best results, manage assembly names as though they were case-sensitive.

## Name application components

 The runtime does not consider the file name when determining an assembly's identity. The assembly identity, which consists of the assembly name, version, culture, and strong name, must be clear to the runtime.

 For example, if you have an assembly called *myAssembly.exe* that references an assembly called *myAssembly.dll*, binding occurs correctly if you execute *myAssembly.exe*. However, if another application executes *myAssembly.exe* using the method <xref:System.AppDomain.ExecuteAssembly%2A?displayProperty=nameWithType>, the runtime determines that `myAssembly` is already loaded when *myAssembly.exe* requests binding to `myAssembly`. In this case, *myAssembly.dll* is never loaded. Because *myAssembly.exe* does not contain the requested type, a <xref:System.TypeLoadException> occurs.

 To avoid this problem, make sure the assemblies that make up your application do not have the same assembly name or place assemblies with the same name in different directories.

> [!NOTE]
> In .NET Framework, if you put a strong-named assembly in the global assembly cache, the assembly's file name must match the assembly name, not including the file name extension, such as *.exe* or *.dll*. For example, if the file name of an assembly is *myAssembly.dll*, the assembly name must be `myAssembly`. Private assemblies deployed only in the root application directory can have an assembly name that is different from the file name.

## See also

- [How to: Determine an assembly's fully qualified name](find-fully-qualified-name.md)
- [Create assemblies](create.md)
- [Strong-named assemblies](strong-named.md)
- [Global assembly cache](../../framework/app-domains/gac.md)
- [How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)
