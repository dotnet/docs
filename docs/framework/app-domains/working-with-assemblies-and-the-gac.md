---
title: "Working with Assemblies and the Global Assembly Cache"
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
  - "assemblies [.NET Framework], global assembly cache"
  - "global assembly cache, benefits"
  - "ACLs [.NET Framework]"
  - "GAC (global assembly cache), benefits"
  - "access control lists [.NET Framework]"
ms.assetid: 8a18e5c2-d41d-49ef-abcb-7c27e2469433
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Working with Assemblies and the Global Assembly Cache
If you intend to share an assembly among several applications, you can install it into the global assembly cache. Each computer where the common language runtime is installed has this machine-wide code cache. The global assembly cache stores assemblies specifically designated to be shared by several applications on the computer. An assembly must have a strong name to be installed in the global assembly cache.  
  
> [!NOTE]
>  Assemblies placed in the global assembly cache must have the same assembly name and file name (not including the file name extension). For example, an assembly with the assembly name of myAssembly must have a file name of either myAssembly.exe or myAssembly.dll.  
  
 You should share assemblies by installing them into the global assembly cache only when necessary. As a general guideline, keep assembly dependencies private and locate assemblies in the application directory unless sharing an assembly is explicitly required. In addition, you do not have to install assemblies into the global assembly cache to make them accessible to COM interop or unmanaged code.  
  
 There are several reasons why you might want to install an assembly into the global assembly cache:  
  
-   Shared location.  
  
     Assemblies that should be used by applications can be put in the global assembly cache. For example, if all applications should use an assembly located in the global assembly cache, a version policy statement can be added to the Machine.config file that redirects references to the assembly.  
  
-   File security.  
  
     Administrators often protect the systemroot directory using an Access Control List (ACL) to control write and execute access. Because the global assembly cache is installed in the systemroot directory, it inherits that directory's ACL. It is recommended that only users with Administrator privileges be allowed to delete files from the global assembly cache.  
  
-   Side-by-side versioning.  
  
     Multiple copies of assemblies with the same name but different version information can be maintained in the global assembly cache.  
  
-   Additional search location.  
  
     The common language runtime checks the global assembly cache for an assembly that matches the assembly request before probing or using the codebase information in a configuration file.  
  
 Note that there are scenarios where you explicitly do not want to install an assembly into the global assembly cache. If you place one of the assemblies that make up an application into the global assembly cache, you can no longer replicate or install the application by using XCOPY to copy the application directory. In this case, you must also move the assembly into the global assembly cache.  
  
## In This Section  
 [How to: Install an Assembly into the Global Assembly Cache](../../../docs/framework/app-domains/how-to-install-an-assembly-into-the-gac.md)  
 Describes the ways to install an assembly into the global assembly cache.  
  
 [How to: View the Contents of the Global Assembly Cache](../../../docs/framework/app-domains/how-to-view-the-contents-of-the-gac.md)  
 Explains how to use the [Gacutil.exe (Global Assembly Cache Tool)](../../../docs/framework/tools/gacutil-exe-gac-tool.md) to view the contents of the global assembly cache.  
  
 [How to: Remove an Assembly from the Global Assembly Cache](../../../docs/framework/app-domains/how-to-remove-an-assembly-from-the-gac.md)  
 Explains how to use the [Gacutil.exe (Global Assembly Cache Tool)](../../../docs/framework/tools/gacutil-exe-gac-tool.md) to remove an assembly from the global assembly cache.  
  
 [Using Serviced Components with the Global Assembly Cache](../../../docs/framework/app-domains/use-serviced-components-with-the-gac.md)  
 Explains why serviced components (managed COM+ components) should be placed in the global assembly cache.  
  
## Related Sections  
 [Creating Assemblies](../../../docs/framework/app-domains/create-assemblies.md)  
 Provides an overview of creating assemblies.  
  
 [Global Assembly Cache](../../../docs/framework/app-domains/gac.md)  
 Describes the global assembly cache.  
  
 [How to: View Assembly Contents](../../../docs/framework/app-domains/how-to-view-assembly-contents.md)  
 Explains how to use the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md) to view Microsoft intermediate language (MSIL) information in an assembly.  
  
 [How the Runtime Locates Assemblies](../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)  
 Describes how the common language runtime locates and loads the assemblies that make up your application.  
  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)  
 Describes assemblies, the building blocks of managed applications.
