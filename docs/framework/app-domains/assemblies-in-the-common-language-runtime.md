---
title: "Assemblies in the Common Language Runtime"
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
  - "dynamic assemblies"
  - "security [.NET Framework], boundaries"
  - "boundaries of assemblies"
  - "assemblies [.NET Framework], about"
  - "assemblies [.NET Framework], boundaries"
  - "reference scope boundaries"
  - "assemblies [.NET Framework]"
  - "version boundaries"
  - "type boundaries"
ms.assetid: 2cfebe19-7436-49f1-bd99-3c4019f0b676
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Assemblies in the Common Language Runtime
Assemblies are the building blocks of .NET Framework applications; they form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions. An assembly is a collection of types and resources that are built to work together and form a logical unit of functionality. An assembly provides the common language runtime with the information it needs to be aware of type implementations. To the runtime, a type does not exist outside the context of an assembly.  
  
 An assembly performs the following functions:  
  
-   It contains code that the common language runtime executes. Microsoft intermediate language (MSIL) code in a portable executable (PE) file will not be executed if it does not have an associated assembly manifest. Note that each assembly can have only one entry point (that is, `DllMain`, `WinMain`, or `Main`).  
  
-   It forms a security boundary. An assembly is the unit at which permissions are requested and granted. For more information about security boundaries as they apply to assemblies, see [Assembly Security Considerations](../../../docs/framework/app-domains/assembly-security-considerations.md).  
  
-   It forms a type boundary. Every type's identity includes the name of the assembly in which it resides. A type called `MyType` that is loaded in the scope of one assembly is not the same as a type called `MyType` that is loaded in the scope of another assembly.  
  
-   It forms a reference scope boundary. The assembly's manifest contains assembly metadata that is used for resolving types and satisfying resource requests. It specifies the types and resources that are exposed outside the assembly. The manifest also enumerates other assemblies on which it depends.  
  
-   It forms a version boundary. The assembly is the smallest versionable unit in the common language runtime; all types and resources in the same assembly are versioned as a unit. The assembly's manifest describes the version dependencies you specify for any dependent assemblies. For more information about versioning, see [Assembly Versioning](../../../docs/framework/app-domains/assembly-versioning.md).  
  
-   It forms a deployment unit. When an application starts, only the assemblies that the application initially calls must be present. Other assemblies, such as localization resources or assemblies containing utility classes, can be retrieved on demand. This allows applications to be kept simple and thin when first downloaded. For more information about deploying assemblies, see [Deploying Applications](../../../docs/framework/deployment/index.md).  
  
-   It is the unit at which side-by-side execution is supported. For more information about running multiple versions of an assembly, see [Assemblies and Side-by-Side Execution](../../../docs/framework/app-domains/assemblies-and-side-by-side-execution.md).  
  
 Assemblies can be static or dynamic. Static assemblies can include .NET Framework types (interfaces and classes), as well as resources for the assembly (bitmaps, JPEG files, resource files, and so on). Static assemblies are stored on disk in portable executable (PE) files. You can also use the .NET Framework to create dynamic assemblies, which are run directly from memory and are not saved to disk before execution. You can save dynamic assemblies to disk after they have executed.  
  
 There are several ways to create assemblies. You can use development tools, such as Visual Studio, that you have used in the past to create .dll or .exe files. You can use tools provided in the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] to create assemblies with modules created in other development environments. You can also use common language runtime APIs, such as <xref:System.Reflection.Emit?displayProperty=nameWithType>, to create dynamic assemblies.  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Assembly Contents](../../../docs/framework/app-domains/assembly-contents.md)|Describes the elements that make up an assembly.|  
|[Assembly Manifest](../../../docs/framework/app-domains/assembly-manifest.md)|Describes the data in the assembly manifest, and how it is stored in assemblies.|  
|[Global Assembly Cache](../../../docs/framework/app-domains/gac.md)|Describes the global assembly cache and how it is used with assemblies.|  
|[Strong-Named Assemblies](../../../docs/framework/app-domains/strong-named-assemblies.md)|Describes the characteristics of strong-named assemblies.|  
|[Assembly Security Considerations](../../../docs/framework/app-domains/assembly-security-considerations.md)|Discusses how security works with assemblies.|  
|[Assembly Versioning](../../../docs/framework/app-domains/assembly-versioning.md)|Provides an overview of the .NET Framework versioning policy.|  
|[Assembly Placement](../../../docs/framework/app-domains/assembly-placement.md)|Discusses where to locate assemblies.|  
|[Assemblies and Side-by-Side Execution](../../../docs/framework/app-domains/assemblies-and-side-by-side-execution.md)|Provides an overview of using multiple versions of the runtime or of an assembly simultaneously.|  
|[Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)|Describes how to create, sign, and set attributes on assemblies.|  
|[Emitting Dynamic Methods and Assemblies](../../../docs/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)|Describes how to create dynamic assemblies.|  
|[How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)|Describes how the .NET Framework resolves assembly references at run time.|  
  
## Reference  
 <xref:System.Reflection.Assembly?displayProperty=nameWithType>
