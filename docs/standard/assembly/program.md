---
title: "Program with assemblies"
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
ms.assetid: 25918b15-701d-42c7-95fc-c290d08648d6
author: "rpetrusha"
ms.author: "ronpet"
---
# Program with assemblies
Assemblies are the building blocks of the .NET Framework; they form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions. An assembly provides the common language runtime with the information it needs to be aware of type implementations. It is a collection of types and resources that are built to work together and form a logical unit of functionality. To the runtime, a type does not exist outside the context of an assembly.  
  
 This section describes how to create modules, create assemblies from modules, create a key pair and sign an assembly with a strong name, and install an assembly into the global assembly cache. In addition, this section describes how to use the [MSIL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) to view assembly manifest information.  
  
> [!NOTE]
>  Starting with the .NET Framework version 2.0, the runtime will not load an assembly that was compiled with a version of the .NET Framework that has a higher version number than the currently loaded runtime. This applies to the combination of the major and minor components of the version number.  
  
## In this section  
 [Create assemblies](create.md)  
 Provides an overview of single-file and multifile assemblies.  
  
 [Assembly names](names.md)  
 Provides an overview of assembly naming.  
  
 [How to: Determine an assembly's fully qualified name](find-fully-qualified-name.md)  
 Describes how to determine the fully qualified name of an assembly.  
  
 [Run intranet applications in full trust](../../framework/app-domains/running-intranet-applications-in-full-trust.md)  
 Describes how to specify legacy security policy for full-trust assemblies on an intranet share.  
  
 [Assembly location](location.md)  
 Provides an overview of where to locate assemblies.  
  
 [How to: Build a single-file assembly](build-single-file.md)  
 Describes how to create a single-file assembly.  
  
 [Multifile assemblies](multifile.md)  
 Describes reasons for creating multifile assemblies.  
  
 [How to: Build a multifile assembly](build-multifile.md)  
 Describes how to create a multifile assembly.  
  
 [Set assembly attributes](set-attributes.md)  
 Describes assembly attributes and how to set them.  
  
 [Create and use strong-named assemblies](create-use-strong-named.md)  
 Describes how and why you sign an assembly with a strong name, and includes how-to topics.  
  
 [Delay-sign an assembly](delay-sign.md)  
 Describes how to delay-sign an assembly.  
  
 [Work with assemblies and the global assembly cache](../../framework/app-domains/working-with-assemblies-and-the-gac.md)  
 Describes how and why you add assemblies to the global assembly cache, and includes how-to topics.  
  
 [How to: View assembly contents](view-contents.md)  
 Describes how to use the MSIL Disassembler (Ildasm.exe) to view assembly contents.  
  
 [Type forwarding in the common language runtime](type-forwarding.md)  
 Describes how to use type forwarding to move a type into a different assembly without breaking existing applications.  
  
## Reference  
 <xref:System.Reflection.Assembly>  
 The .NET Framework class that represents an assembly.  
  
## Related sections  
 [How to: Obtain type and member information from an assembly](get-type-member-information.md)  
 Describes how to programmatically obtain type and other information from an assembly.  
  
 [Assemblies in .NET](index.md)  
 Provides a conceptual overview of common language runtime assemblies.  
  
 [Assembly versioning](versioning.md)  
 Provides an overview of assembly binding and of the <xref:System.Reflection.AssemblyVersionAttribute> and <xref:System.Reflection.AssemblyInformationalVersionAttribute> attributes.  
  
 [How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)  
 Describes how the runtime determines which assembly to use to fulfill a binding request.  
  
 [Reflection](../../framework/reflection-and-codedom/reflection.md)   
 Describes how to use the **Reflection** class to obtain information about an assembly.
