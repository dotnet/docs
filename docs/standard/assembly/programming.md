---
title: "Programming with Assemblies"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
ms.assetid: 25918b15-701d-42c7-95fc-c290d08648d6
author: "rpetrusha"
ms.author: "ronpet"
---
# Programming with Assemblies
Assemblies are the building blocks of the .NET Framework; they form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions. An assembly provides the common language runtime with the information it needs to be aware of type implementations. It is a collection of types and resources that are built to work together and form a logical unit of functionality. To the runtime, a type does not exist outside the context of an assembly.  
  
 This section describes how to create modules, create assemblies from modules, create a key pair and sign an assembly with a strong name, and install an assembly into the global assembly cache. In addition, this section describes how to use the [MSIL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) to view assembly manifest information.  
  
> [!NOTE]
>  Starting with the .NET Framework version 2.0, the runtime will not load an assembly that was compiled with a version of the .NET Framework that has a higher version number than the currently loaded runtime. This applies to the combination of the major and minor components of the version number.  
  
## In This Section  
 [Creating Assemblies](create.md)  
 Provides an overview of single-file and multifile assemblies.  
  
 [Assembly Names](../../csharp/programming-guide/inside-a-program/names.md)  
 Provides an overview of assembly naming.  
  
 [How to: Determine an Assembly's Fully Qualified Name](find-fully-qualified-name.md)  
 Describes how to determine the fully qualified name of an assembly.  
  
 [Running Intranet Applications in Full Trust](../../framework/app-domains/running-intranet-applications-in-full-trust.md)  
 Describes how to specify legacy security policy for full-trust assemblies on an intranet share.  
  
 [Assembly Location](../../framework/configure-apps/location.md)  
 Provides an overview of where to locate assemblies.  
  
 [How to: Build a Single-File Assembly](build-single-file.md)  
 Describes how to create a single-file assembly.  
  
 [Multifile Assemblies](multifile.md)  
 Describes reasons for creating multifile assemblies.  
  
 [How to: Build a Multifile Assembly](build-multifile.md)  
 Describes how to create a multifile assembly.  
  
 [Setting Assembly Attributes](set-attributes.md)  
 Describes assembly attributes and how to set them.  
  
 [Creating and Using Strong-Named Assemblies](create-use-strong-named.md)  
 Describes how and why you sign an assembly with a strong name, and includes how-to topics.  
  
 [Delay Signing an Assembly](delay-sign.md)  
 Describes how to delay-sign an assembly.  
  
 [Working with Assemblies and the Global Assembly Cache](../../framework/app-domains/working-with-assemblies-and-the-gac.md)  
 Describes how and why you add assemblies to the global assembly cache, and includes how-to topics.  
  
 [How to: View Assembly Contents](view-contents.md)  
 Describes how to use the MSIL Disassembler (Ildasm.exe) to view assembly contents.  
  
 [Type Forwarding in the Common Language Runtime](type-forwarding.md)  
 Describes how to use type forwarding to move a type into a different assembly without breaking existing applications.  
  
## Reference  
 <xref:System.Reflection.Assembly>  
 The .NET Framework class that represents an assembly.  
  
## Related Sections  
 [How to: Obtain Type and Member Information from an Assembly](get-type-member-information.md)  
 Describes how to programmatically obtain type and other information from an assembly.  
  
 [Assemblies in the Common Language Runtime](assemblies-in-the-common-language-runtime.md)  
 Provides a conceptual overview of common language runtime assemblies.  
  
 [Assembly Versioning](versioning.md)  
 Provides an overview of assembly binding and of the <xref:System.Reflection.AssemblyVersionAttribute> and <xref:System.Reflection.AssemblyInformationalVersionAttribute> attributes.  
  
 [How the Runtime Locates Assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)  
 Describes how the runtime determines which assembly to use to fulfill a binding request.  
  
 [Reflection](../../csharp/programming-guide/concepts/attributes/reflection.md)  
 Describes how to use the **Reflection** class to obtain information about an assembly.
