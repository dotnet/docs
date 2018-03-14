---
title: "Global Assembly Cache"
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
  - "GAC (global assembly cache)"
  - "ACLs [.NET Framework]"
  - "global assembly cache"
  - "cache [.NET Framework], global assembly cache"
  - "global assembly cache, about"
  - "access control lists [.NET Framework]"
ms.assetid: cf5eacd0-d3ec-4879-b6da-5fd5e4372202
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Global Assembly Cache
Each computer where the Common Language Runtime is installed has a machine-wide code cache called the Global Assembly Cache. The Global Assembly Cache stores assemblies specifically designated to be shared by several applications on the computer.  
  
 You should share assemblies by installing them into the Global Assembly Cache only when you need to. As a general guideline, keep assembly dependencies private, and locate assemblies in the application directory unless sharing an assembly is explicitly required. In addition, it is not necessary to install assemblies into the Global Assembly Cache to make them accessible to COM interop or unmanaged code.  
  
> [!NOTE]
>  There are scenarios where you explicitly do not want to install an assembly into the Global Assembly Cache. If you place one of the assemblies that make up an application in the Global Assembly Cache, you can no longer replicate or install the application by using the **xcopy** command to copy the application directory. You must move the assembly in the Global Assembly Cache as well.  
  
 There are two ways to deploy an assembly into the Global Assembly Cache:  
  
-   Use an installer designed to work with the Global Assembly Cache. This is the preferred option for installing assemblies into the Global Assembly Cache.  
  
-   Use a developer tool called the [Global Assembly Cache tool (Gacutil.exe)](../../../docs/framework/tools/gacutil-exe-gac-tool.md), provided by the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)].  
  
    > [!NOTE]
    >  In deployment scenarios, use Windows Installer to install assemblies into the Global Assembly Cache. Use the Global Assembly Cache tool only in development scenarios, because it does not provide assembly reference counting and other features provided when using the Windows Installer.  
  
 Starting with the .NET Framework 4, the default location for the Global Assembly Cache is **%windir%\Microsoft.NET\assembly**. In earlier versions of the .NET Framework, the default location is **%windir%\assembly**.  
  
 Administrators often protect the systemroot directory using an access control list (ACL) to control write and execute access. Because the Global Assembly Cache is installed in a subdirectory of the systemroot directory, it inherits that directory's ACL. It is recommended that only users with Administrator privileges be allowed to delete files from the Global Assembly Cache.  
  
 Assemblies deployed in the Global Assembly Cache must have a strong name. When an assembly is added to the Global Assembly Cache, integrity checks are performed on all files that make up the assembly. The cache performs these integrity checks to ensure that an assembly has not been tampered with, for example, when a file has changed but the manifest does not reflect the change.  
  
## See Also  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 [Working with Assemblies and the Global Assembly Cache](../../../docs/framework/app-domains/working-with-assemblies-and-the-gac.md)  
 [Strong-Named Assemblies](../../../docs/framework/app-domains/strong-named-assemblies.md)
