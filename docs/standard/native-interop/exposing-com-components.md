---
title: "Expose COM components to .NET"
description: Know the process of exposing COM components to .NET. COM components are valuable in managed code as middle-tier business applications or isolated functionality.
ms.date: 07/08/2026
ai-usage: ai-assisted
helpviewer_keywords: 
  - "exposing COM components to .NET"
  - "interoperation with unmanaged code, exposing COM components"
  - "COM interop, exposing COM components"
ms.assetid: e78b14f1-e487-43cd-9c6d-1a07483f1730
---
# Expose COM components to .NET

> [!NOTE]
> This article describes .NET Framework COM interop guidance that uses legacy tools and deployment models, such as primary interop assemblies, the global assembly cache, and registry-based COM registration. For modern .NET, use [COM source generation](comwrappers-source-generation.md) or the <xref:System.Runtime.InteropServices.ComWrappers> API. For more information, see [COM interop](cominterop.md).

This section summarizes the process needed to expose an existing COM component to managed code. For details about writing COM servers that tightly integrate with .NET, see [Design Considerations for Interoperation](/previous-versions/dotnet/netframework-4.0/61aax4kh(v=vs.100)).
  
 Existing COM components are valuable resources in managed code as middle-tier business applications or as isolated functionality. An ideal component has a primary interop assembly and conforms tightly to the programming standards imposed by COM.  
  
## Expose COM components to .NET  
  
1. [Import a type library as an assembly](importing-a-type-library-as-an-assembly.md).  
  
     The common language runtime requires metadata for all types, including COM types. There are several ways to obtain an assembly containing COM types imported as metadata.  
  
2. [Use COM types in managed Code](/previous-versions/dotnet/netframework-4.0/3y76b69k(v=vs.100)).  
  
     You can inspect COM types, activate instances, and invoke methods on the COM object the same way you do for any managed type.  
  
3. [Compile an interop project](compiling-an-interop-project.md).  
  
     The Windows SDK provides compilers for several languages compliant with the Common Language Specification (CLS), including Visual Basic, C#, and C++.  
  
4. [Deploy an interop application](deploying-an-interop-application.md).  
  
     For .NET Framework, interop applications are often deployed as [strong-named](../../standard/assembly/strong-named.md), signed assemblies in the global assembly cache.  
  
## See also

- [Interoperating with Unmanaged Code](index.md)
- [Design Considerations for Interoperation](/previous-versions/dotnet/netframework-4.0/61aax4kh(v=vs.100))
- [COM Interop Sample: .NET Client and COM Server](com-interop-sample-net-client-and-com-server.md)
- [Language Independence and Language-Independent Components](../../standard/language-independence.md)
- [Gacutil.exe (Global Assembly Cache Tool)](../../framework/tools/gacutil-exe-gac-tool.md)
