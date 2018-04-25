---
title: "Exposing COM Components to the .NET Framework"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "exposing COM components to .NET Framework"
  - "interoperation with unmanaged code, exposing COM components"
  - "COM interop, exposing COM components"
ms.assetid: e78b14f1-e487-43cd-9c6d-1a07483f1730
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exposing COM Components to the .NET Framework
This section summarizes the process needed to expose an existing COM component to managed code. For details about writing COM servers that tightly integrate with the .NET Framework, see [Design Considerations for Interoperation](https://msdn.microsoft.com/library/b59637f6-fe35-40d6-ae72-901e7a707689(v=vs.100)).
  
 Existing COM components are valuable resources in managed code as middle-tier business applications or as isolated functionality. An ideal component has a primary interop assembly and conforms tightly to the programming standards imposed by COM.  
  
#### To expose COM components to the .NET Framework  
  
1.  [Import a type library as an assembly](importing-a-type-library-as-an-assembly.md).  
  
     The common language runtime requires metadata for all types, including COM types. There are several ways to obtain an assembly containing COM types imported as metadata.  
  
2.  [Create COM types in managed Code](https://msdn.microsoft.com/library/1a95a8ca-c8b8-4464-90b0-5ee1a1135b66(v=vs.100)).  
  
     You can inspect COM types, activate instances, and invoke methods on the COM object the same way you do for any managed type.  
  
3.  [Compile an interop project](compiling-an-interop-project.md).  
  
     The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] provides compilers for several languages compliant with the Common Language Specification (CLS), including [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], C#, and C++.  
  
4.  [Deploy an interop application](deploying-an-interop-application.md).  
  
     Interop applications are best deployed as [strong-named](../app-domains/strong-named-assemblies.md), signed assemblies in the global assembly cache.  
  
## See Also  
 [Interoperating with Unmanaged Code](index.md)  
 [Design Considerations for Interoperation](https://msdn.microsoft.com/library/b59637f6-fe35-40d6-ae72-901e7a707689(v=vs.100))  
 [COM Interop Sample: .NET Client and COM Server](com-interop-sample-net-client-and-com-server.md)  
 [Language Independence and Language-Independent Components](../../standard/language-independence-and-language-independent-components.md)  
 [Gacutil.exe (Global Assembly Cache Tool)](../tools/gacutil-exe-gac-tool.md)
