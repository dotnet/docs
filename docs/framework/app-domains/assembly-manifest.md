---
title: "Assembly Manifest"
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
  - "assembly manifest"
  - "dynamic assemblies, assembly manifest"
  - "metadata, assembly manifest"
  - "culture, assembly manifest"
  - "assemblies [.NET Framework], metadata"
ms.assetid: 8e40fab9-549d-4731-aec2-ffa47a382de0
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Assembly Manifest
Every assembly, whether static or dynamic, contains a collection of data that describes how the elements in the assembly relate to each other. The assembly manifest contains this assembly metadata. An assembly manifest contains all the metadata needed to specify the assembly's version requirements and security identity, and all metadata needed to define the scope of the assembly and resolve references to resources and classes. The assembly manifest can be stored in either a PE file (an .exe or .dll) with Microsoft intermediate language (MSIL) code or in a standalone PE file that contains only assembly manifest information.  
  
 The following illustration shows the different ways the manifest can be stored.  
  
 ![A single&#45;file assembly](../../../docs/framework/app-domains/media/assemblytypes.gif "assemblytypes")  
Types of assemblies  
  
 For an assembly with one associated file, the manifest is incorporated into the PE file to form a single-file assembly. You can create a multifile assembly with a standalone manifest file or with the manifest incorporated into one of the PE files in the assembly.  
  
 Each assembly's manifest performs the following functions:  
  
-   Enumerates the files that make up the assembly.  
  
-   Governs how references to the assembly's types and resources map to the files that contain their declarations and implementations.  
  
-   Enumerates other assemblies on which the assembly depends.  
  
-   Provides a level of indirection between consumers of the assembly and the assembly's implementation details.  
  
-   Renders the assembly self-describing.  
  
## Assembly Manifest Contents  
 The following table shows the information contained in the assembly manifest. The first four items—the assembly name, version number, culture, and strong name information—make up the assembly's identity.  
  
|Information|Description|  
|-----------------|-----------------|  
|Assembly name|A text string specifying the assembly's name.|  
|Version number|A major and minor version number, and a revision and build number. The common language runtime uses these numbers to enforce version policy.|  
|Culture|Information on the culture or language the assembly supports. This information should be used only to designate an assembly as a satellite assembly containing culture- or language-specific information. (An assembly with culture information is automatically assumed to be a satellite assembly.)|  
|Strong name information|The public key from the publisher if the assembly has been given a strong name.|  
|List of all files in the assembly|A hash of each file contained in the assembly and a file name. Note that all files that make up the assembly must be in the same directory as the file containing the assembly manifest.|  
|Type reference information|Information used by the runtime to map a type reference to the file that contains its declaration and implementation. This is used for types that are exported from the assembly.|  
|Information on referenced assemblies|A list of other assemblies that are statically referenced by the assembly. Each reference includes the dependent assembly's name, assembly metadata (version, culture, operating system, and so on), and public key, if the assembly is strong named.|  
  
 You can add or change some information in the assembly manifest by using assembly attributes in your code. You can change version information and informational attributes, including Trademark, Copyright, Product, Company, and Informational Version. For a complete list of assembly attributes, see [Setting Assembly Attributes](../../../docs/framework/app-domains/set-assembly-attributes.md).  
  
## See Also  
 [Assembly Contents](../../../docs/framework/app-domains/assembly-contents.md)  
 [Assembly Versioning](../../../docs/framework/app-domains/assembly-versioning.md)  
 [Creating Satellite Assemblies](../../../docs/framework/resources/creating-satellite-assemblies-for-desktop-apps.md)  
 [Strong-Named Assemblies](../../../docs/framework/app-domains/strong-named-assemblies.md)
