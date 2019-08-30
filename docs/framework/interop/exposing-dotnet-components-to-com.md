---
title: "Exposing .NET components to COM"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "exposing .NET Framework components to COM"
  - "interoperation with unmanaged code, exposing .NET Framework components"
  - "COM interop, exposing COM components"
ms.assetid: e42a65f7-1e61-411f-b09a-aca1bbce24c6
author: "rpetrusha"
ms.author: "ronpet"
---
# Exposing .NET components to COM

Writing a .NET type and consuming that type from unmanaged code are distinct activities for developers. This section describes several tips for writing managed code that interoperates with COM clients:

- [Qualifying .NET types for interoperation](../../standard/native-interop/qualify-net-types-for-interoperation.md).

     All managed types, methods, properties, fields, and events that you want to expose to COM must be public. Types must have a public parameterless constructor, which is the only constructor that can be invoked through COM.

- [Applying interop attributes](../../standard/native-interop/apply-interop-attributes.md).

     Custom attributes within managed code can enhance the interoperability of a component.

- [Packaging an assembly for COM](../../../docs/framework/interop/packaging-an-assembly-for-com.md).

     COM developers might require that you summarize the steps involved in referencing and deploying your assemblies.

 Additionally, this section identifies the tasks related to consuming a managed type from a COM client.

## To consume a managed type from COM

1. [Register assemblies with COM](../../../docs/framework/interop/registering-assemblies-with-com.md).

     Types in an assembly (and type libraries) must be registered at design time. If an installer does not register the assembly, instruct COM developers to use Regasm.exe.

2. [Reference .NET types from COM](../../../docs/framework/interop/how-to-reference-net-types-from-com.md).

     COM developers can reference types in an assembly using the same tools and techniques they use today.

3. [Call a .NET object](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/8hw8h46b(v=vs.100)).

     COM developers can call methods on the .NET object the same way they call methods on any unmanaged type. For example, the COM **CoCreateInstance** API activates .NET objects.

4. [Deploy an application for COM access](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/c2850st8(v=vs.100)).

     A strong-named assembly can be installed in the global assembly cache and requires a signature from its publisher. Assemblies that are not strong named must be installed in the application directory of the client.

## See also

- [Interoperating with Unmanaged Code](../../../docs/framework/interop/index.md)
- [COM Interop Sample: COM Client and .NET Server](../../../docs/framework/interop/com-interop-sample-com-client-and-net-server.md)
