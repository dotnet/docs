---
title: "Guidelines for Creating Components for Side-by-Side Execution"
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
  - "side-by-side execution, multiple application versions"
  - "side-by-side execution, multiple component versions"
ms.assetid: 5c540161-6e40-42e9-be92-6175aee2c46a
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Guidelines for Creating Components for Side-by-Side Execution
Follow these general guidelines to create managed applications or components designed for side-by-side execution:  
  
-   Bind type identity to a particular version of a file.  
  
     The common language runtime binds type identity to a particular file version by using strong-named assemblies. To create an application or component for side-by-side execution, you must give all assemblies a strong name. This creates precise type identity and ensures that any type resolution is directed to the correct file. A strong-named assembly contains version, culture, and publisher information that the runtime uses to locate the correct file to fulfill a binding request.  
  
-   Use version-aware storage.  
  
     The runtime uses the global assembly cache to provide version-aware storage. The global assembly cache is a version-aware directory structure installed on every computer that uses the .NET Framework. Assemblies installed in the global assembly cache are not overwritten when a new version of that assembly is installed.  
  
-   Create an application or component that runs in isolation.  
  
     An application or component that runs in isolation must manage resources to avoid conflicts when two instances of the application or component are running simultaneously. The application or component must also use a version-specific file structure.  
  
## Application and Component Isolation  
 One key to successfully designing an application or component for side-by-side execution is isolation. The application or component must manage all resources, particularly file I/O, in an isolated manner. Follow these guidelines to make sure your application or component runs in isolation:  
  
-   Write to the registry in a version-specific way. Store values in hives or keys that indicate the version, and do not share information or state across versions of a component. This prevents two applications or components running at the same time from overwriting information.  
  
-   Make named kernel objects version-specific so that a race condition does not occur. For example, a race condition occurs when two semaphores from two versions of the same application wait on each other.  
  
-   Make file and directory names version-aware. This means that file structures should rely on version information.  
  
-   Create user accounts and groups in a version-specific manner. User accounts and groups created by an application should be identified by version. Do not share user accounts and groups between versions of an application.  
  
## Installing and Uninstalling Versions  
 When designing an application for side-by-side execution, follow these guidelines concerning installing and uninstalling versions:  
  
-   Do not delete information from the registry that may be needed by other applications running under a different version of the .NET Framework.  
  
-   Do not replace information in the registry that may be needed by other applications running under a different version of the .NET Framework.  
  
-   Do not unregister COM components that may be needed by other applications running under a different version of the .NET Framework.  
  
-   Do not change **InprocServer32** or other registry entries for a COM server that was already registered.  
  
-   Do not delete user accounts or groups that may be needed by other applications running under a different version of the .NET Framework.  
  
-   Do not add anything to the registry that contains an unversioned path.  
  
## File Version Number and Assembly Version Number  
 File version is a Win32 version resource that is not used by the runtime. In general, you update the file version even for an in-place update. Two identical files can have different file version information, and two different files can have the same file version information.  
  
 The assembly version is used by the runtime for assembly binding. Two identical assemblies with different version numbers are treated as two different assemblies by the runtime.  
  
 The [Global Assembly Cache tool (Gacutil.exe)](../../../docs/framework/tools/gacutil-exe-gac-tool.md) allows you to replace an assembly when only the file version number is newer. The installer generally does not install over an assembly unless the assembly version number is greater.  
  
## See Also  
 [Side-by-Side Execution](../../../docs/framework/deployment/side-by-side-execution.md)  
 [How to: Enable and Disable Automatic Binding Redirection](../../../docs/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection.md)
