---
title: "How to: Register Primary Interop Assemblies"
description: Register primary interop assemblies using the Assembly Registration Tool (Regasm.exe), and read about other issues related to interop assemblies.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "registering primary interop assemblies"
  - "primary interop assemblies, registering"
ms.assetid: 4b2fcf8a-429d-43ce-8334-e026040be8bb
---
# How to: Register Primary Interop Assemblies

Classes can be marshaled only by COM interop and are always marshaled as interfaces. In some cases the interface used to marshal the class is known as the class interface. For information about overriding the class interface with an interface of your choice, see [COM Callable Wrapper](../../standard/native-interop/com-callable-wrapper.md).

 Although any developer who wants to use COM types from a .NET Framework application can generate an interop assembly, doing so creates a problem. Each time a developer imports and signs a COM type library, that developer creates a set of unique types that are incompatible with those imported and signed by another developer. The solution to this type incompatibility problem is for each developer to obtain the vendor-supplied and signed primary interop assembly.

 If you plan to expose third-party COM types to other applications, always use the primary interop assembly provided by the same publisher as the type library it defines. In addition to providing guaranteed type compatibility, primary interop assemblies are often customized by the vendor to enhance interoperability.

 Even if you do not plan to expose third-party COM types, using the primary interop assembly can ease the task of interoperating with COM components. However, this strategy provides no insulation from changes a vendor might make to types defined in a primary interop assembly. When your application requires such insulation, generate your own interop assembly instead of using the primary interop assembly.

 You must register all acquired primary interop assemblies on your development computer before you can reference them with Visual Studio. Visual Studio looks for and uses a primary interop assembly the first time that you reference a type from a COM type library. If Visual Studio cannot locate the primary interop assembly associated with the type library, it prompts you to acquire it or offers to create an interop assembly instead. Likewise, the [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md) also uses the registry to locate primary interop assemblies.

 Although it is not necessary to register primary interop assemblies unless you plan to use Visual Studio, registration provides two advantages:

- A registered primary interop assembly is clearly marked under the registry key of the original type library. Registration is the best way for you to locate a primary interop assembly on your computer.

- You can avoid accidentally generating and using a new interop assembly if, at some time in the future, you do use Visual Studio to reference a type for which you have an unregistered primary interop assembly.

Use the [Assembly Registration Tool (Regasm.exe)](../tools/regasm-exe-assembly-registration-tool.md) to register a primary interop assembly.

## To register a primary interop assembly

1. At the command prompt, type:

     **regasm** *assemblyname*

     In this command, *assemblyname* is the file name of the assembly that is registered. Regasm.exe adds an entry for the primary interop assembly under the same registry key as the original type library.

## Example

 The following example registers the `CompanyA.UtilLib.dll` primary interop assembly.

```console
regasm CompanyA.UtilLib.dll
```

## See also

- [Programming with Primary Interop Assemblies](/previous-versions/dotnet/netframework-4.0/baxfadst(v=vs.100))
- [Locating Primary Interop Assemblies](/previous-versions/dotnet/netframework-4.0/y06sxw56(v=vs.100))
- [Redistributing Primary Interop Assemblies](/previous-versions/dotnet/netframework-4.0/w0dt2w20(v=vs.100))
