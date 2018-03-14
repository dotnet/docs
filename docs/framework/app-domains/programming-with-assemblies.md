---
title: "Programming with Assemblies"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
ms.assetid: 25918b15-701d-42c7-95fc-c290d08648d6
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Programming with Assemblies
Assemblies are the building blocks of the .NET Framework; they form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions. An assembly provides the common language runtime with the information it needs to be aware of type implementations. It is a collection of types and resources that are built to work together and form a logical unit of functionality. To the runtime, a type does not exist outside the context of an assembly.  
  
 This section describes how to create modules, create assemblies from modules, create a key pair and sign an assembly with a strong name, and install an assembly into the global assembly cache. In addition, this section describes how to use the [MSIL Disassembler (Ildasm.exe)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md) to view assembly manifest information.  
  
> [!NOTE]
>  Starting with the .NET Framework version 2.0, the runtime will not load an assembly that was compiled with a version of the .NET Framework that has a higher version number than the currently loaded runtime. This applies to the combination of the major and minor components of the version number.  
  
## In This Section  
 [Creating Assemblies](../../../docs/framework/app-domains/create-assemblies.md)  
 Provides an overview of single-file and multifile assemblies.  
  
 [Assembly Names](../../../docs/framework/app-domains/assembly-names.md)  
 Provides an overview of assembly naming.  
  
 [How to: Determine an Assembly's Fully Qualified Name](../../../docs/framework/app-domains/how-to-determine-assembly-fully-qualified-name.md)  
 Describes how to determine the fully qualified name of an assembly.  
  
 [Running Intranet Applications in Full Trust](../../../docs/framework/app-domains/running-intranet-applications-in-full-trust.md)  
 Describes how to specify legacy security policy for full-trust assemblies on an intranet share.  
  
 [Assembly Location](../../../docs/framework/app-domains/assembly-location.md)  
 Provides an overview of where to locate assemblies.  
  
 [How to: Build a Single-File Assembly](../../../docs/framework/app-domains/how-to-build-a-single-file-assembly.md)  
 Describes how to create a single-file assembly.  
  
 [Multifile Assemblies](../../../docs/framework/app-domains/multifile-assemblies.md)  
 Describes reasons for creating multifile assemblies.  
  
 [How to: Build a Multifile Assembly](../../../docs/framework/app-domains/how-to-build-a-multifile-assembly.md)  
 Describes how to create a multifile assembly.  
  
 [Setting Assembly Attributes](../../../docs/framework/app-domains/set-assembly-attributes.md)  
 Describes assembly attributes and how to set them.  
  
 [Creating and Using Strong-Named Assemblies](../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md)  
 Describes how and why you sign an assembly with a strong name, and includes how-to topics.  
  
 [Delay Signing an Assembly](../../../docs/framework/app-domains/delay-sign-assembly.md)  
 Describes how to delay-sign an assembly.  
  
 [Working with Assemblies and the Global Assembly Cache](../../../docs/framework/app-domains/working-with-assemblies-and-the-gac.md)  
 Describes how and why you add assemblies to the global assembly cache, and includes how-to topics.  
  
 [How to: View Assembly Contents](../../../docs/framework/app-domains/how-to-view-assembly-contents.md)  
 Describes how to use the MSIL Disassembler (Ildasm.exe) to view assembly contents.  
  
 [Type Forwarding in the Common Language Runtime](../../../docs/framework/app-domains/type-forwarding-in-the-common-language-runtime.md)  
 Describes how to use type forwarding to move a type into a different assembly without breaking existing applications.  
  
## Reference  
 <xref:System.Reflection.Assembly>  
 The .NET Framework class that represents an assembly.  
  
## Related Sections  
 [How to: Obtain Type and Member Information from an Assembly](../../../docs/framework/app-domains/how-to-obtain-type-and-member-information-from-an-assembly.md)  
 Describes how to programmatically obtain type and other information from an assembly.  
  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 Provides a conceptual overview of common language runtime assemblies.  
  
 [Assembly Versioning](../../../docs/framework/app-domains/assembly-versioning.md)  
 Provides an overview of assembly binding and of the <xref:System.Reflection.AssemblyVersionAttribute> and <xref:System.Reflection.AssemblyInformationalVersionAttribute> attributes.  
  
 [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)  
 Describes how the runtime determines which assembly to use to fulfill a binding request.  
  
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)  
 Describes how to use the **Reflection** class to obtain information about an assembly.
