---
title: "Exposing .NET Framework Components to COM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "exposing .NET Framework components to COM"
  - "interoperation with unmanaged code, exposing .NET Framework components"
  - "COM interop, exposing COM components"
ms.assetid: e42a65f7-1e61-411f-b09a-aca1bbce24c6
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exposing .NET Framework Components to COM
Writing a .NET type and consuming that type from unmanaged code are distinct activities for developers. This section describes several tips for writing managed code that interoperates with COM clients:  
  
-   [Qualifying .NET types for interoperation](../../../docs/framework/interop/qualifying-net-types-for-interoperation.md).  
  
     All managed types, methods, properties, fields, and events that you want to expose to COM must be public. Types must have a public default constructor, which is the only constructor that can be invoked through COM.  
  
-   [Applying interop attributes](../../../docs/framework/interop/applying-interop-attributes.md).  
  
     Custom attributes within managed code can enhance the interoperability of a component.  
  
-   [Packaging an assembly for COM](../../../docs/framework/interop/packaging-an-assembly-for-com.md).  
  
     COM developers might require that you summarize the steps involved in referencing and deploying your assemblies.  
  
 Additionally, this section identifies the tasks related to consuming a managed type from a COM client.  
  
#### To consume a managed type from COM  
  
1.  [Register assemblies with COM](../../../docs/framework/interop/registering-assemblies-with-com.md).  
  
     Types in an assembly (and type libraries) must be registered at design time. If an installer does not register the assembly, instruct COM developers to use Regasm.exe.  
  
2.  [Reference .NET types from COM](../../../docs/framework/interop/how-to-reference-net-types-from-com.md).  
  
     COM developers can reference types in an assembly using the same tools and techniques they use today.  
  
3.  [Call a .NET object](https://msdn.microsoft.com/library/40c9626c-aea6-4bad-b8f0-c1de462efd33(v=vs.100)).  
  
     COM developers can call methods on the .NET object the same way they call methods on any unmanaged type. For example, the COM **CoCreateInstance** API activates .NET objects.  
  
4.  [Deploy an application for COM access](https://msdn.microsoft.com/library/fb63564c-c1b9-4655-a094-a235625882ce(v=vs.100)).  
  
     A strong-named assembly can be installed in the global assembly cache and requires a signature from its publisher. Assemblies that are not strong named must be installed in the application directory of the client.  
  
## See Also  
 [Interoperating with Unmanaged Code](../../../docs/framework/interop/index.md)  
 [COM Interop Sample: COM Client and .NET Server](../../../docs/framework/interop/com-interop-sample-com-client-and-net-server.md)
