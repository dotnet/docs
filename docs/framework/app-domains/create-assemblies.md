---
title: "Creating Assemblies"
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
  - "assemblies [.NET Framework], multifile"
  - "single-file assemblies"
  - "assemblies [.NET Framework], creating"
  - "multifile assemblies"
ms.assetid: 54832ee9-dca8-4c8b-913c-c0b9d265e9a4
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating Assemblies
You can create single-file or multifile assemblies using an IDE, such as [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)], or the compilers and tools provided by the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)]. The simplest assembly is a single file that has a simple name and is loaded into a single application domain. This assembly cannot be referenced by other assemblies outside the application directory and does not undergo version checking. To uninstall the application made up of the assembly, you simply delete the directory where it resides. For many developers, an assembly with these features is all that is needed to deploy an application.  
  
 You can create a multifile assembly from several code modules and resource files. You can also create an assembly that can be shared by multiple applications. A shared assembly must have a strong name and can be deployed in the global assembly cache.  
  
 You have several options when grouping code modules and resources into assemblies, depending on the following factors:  
  
-   Versioning  
  
     Group modules that should have the same version information.  
  
-   Deployment  
  
     Group code modules and resources that support your model of deployment.  
  
-   Reuse  
  
     Group modules if they can be logically used together for some purpose. For example, an assembly consisting of types and classes used infrequently for program maintenance can be put in the same assembly. In addition, types that you intend to share with multiple applications should be grouped into an assembly and the assembly should be signed with a strong name.  
  
-   Security  
  
     Group modules containing types that require the same security permissions.  
  
-   Scoping  
  
     Group modules containing types whose visibility should be restricted to the same assembly.  
  
 Special considerations must be made when making common language runtime assemblies available to unmanaged COM applications. For more information about working with unmanaged code, see [Exposing .NET Framework Components to COM](../../../docs/framework/interop/exposing-dotnet-components-to-com.md).  
  
## See Also  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)  
 [Assembly Versioning](../../../docs/framework/app-domains/assembly-versioning.md)  
 [How to: Build a Single-File Assembly](../../../docs/framework/app-domains/how-to-build-a-single-file-assembly.md)  
 [How to: Build a Multifile Assembly](../../../docs/framework/app-domains/how-to-build-a-multifile-assembly.md)  
 [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)  
 [Multifile Assemblies](../../../docs/framework/app-domains/multifile-assemblies.md)
