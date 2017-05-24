---
title: "Emitting Dynamic Methods and Assemblies | Microsoft Docs"
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
  - "reflection emit"
  - "dynamic assemblies"
  - "metadata, emit interfaces"
  - "reflection emit, overview"
  - "assemblies [.NET Framework], emitting dynamic assemblies"
ms.assetid: 8e8e2631-62fd-40e7-a8ee-0039b06749bc
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Emitting Dynamic Methods and Assemblies
This section describes a set of managed types in the <xref:System.Reflection.Emit> namespace that allow a compiler or tool to emit metadata and Microsoft intermediate language (MSIL) at run time and optionally generate a portable executable (PE) file on disk. Script engines and compilers are the primary users of this namespace. In this section, the functionality provided by the <xref:System.Reflection.Emit> namespace is referred to as reflection emit.  
  
 Reflection emit provides the following capabilities:  
  
-   Define lightweight global methods at run time, using the <xref:System.Reflection.Emit.DynamicMethod> class, and execute them using delegates.  
  
-   Define assemblies at run time and then run them and/or save them to disk.  
  
-   Define assemblies at run time, run them, and then unload them and allow garbage collection to reclaim their resources.  
  
-   Define modules in new assemblies at run time and then run and/or save them to disk.  
  
-   Define types in modules at run time, create instances of these types, and invoke their methods.  
  
-   Define symbolic information for defined modules that can be used by tools such as debuggers and code profilers.  
  
 In addition to the managed types in the <xref:System.Reflection.Emit> namespace, there are unmanaged metadata interfaces which are described in the [Metadata Interfaces](../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md) reference documentation. Managed reflection emit provides stronger semantic error checking and a higher level of abstraction of the metadata than the unmanaged metadata interfaces.  
  
 Another useful resource for working with metadata and MSIL is the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics" and "Partition III: CIL Instruction Set". The documentation is available online on [MSDN](http://go.microsoft.com/fwlink/?LinkID=65555) and at the [Ecma Web site](http://go.microsoft.com/fwlink/?LinkId=116487).  
  
## In This Section  
 [Security Issues in Reflection Emit](../../../docs/framework/reflection-and-codedom/security-issues-in-reflection-emit.md)  
 Describes security issues related to creating dynamic assemblies using reflection emit.  
  
## Reference  
 <xref:System.Reflection.Emit.OpCodes>  
 Catalogs the MSIL instruction codes you can use to build method bodies.  
  
 <xref:System.Reflection.Emit>  
 Contains managed classes used to emit dynamic methods, assemblies, and types.  
  
 <xref:System.Type>  
 Describes the <xref:System.Type> class, which represents types in managed reflection and reflection emit, and which is key to the use of these technologies.  
  
 <xref:System.Reflection>  
 Contains managed classes used to explore metadata and managed code.  
  
## Related Sections  
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)  
 Explains how to explore metadata and managed code.  
  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 Provides an overview of assemblies in the .NET Framework.