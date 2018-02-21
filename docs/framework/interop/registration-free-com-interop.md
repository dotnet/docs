---
title: "Registration-Free COM Interop"
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
  - "assemblies [.NET Framework], interop"
  - "COM interop, registration-free COM interop"
  - "registration-free COM interop"
  - "manifests [.NET Framework]"
  - "registration-free activation"
  - "object activation"
  - "registration-free COM interop, about registration-free COM interop"
ms.assetid: 90f308b9-82dc-414a-bce1-77e0155e56bd
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Registration-Free COM Interop
Registration-free COM interop activates a component without using the Windows registry to store assembly information. Instead of registering a component on a computer during deployment, you create Win32-style manifest files at design time that contain information about binding and activation. These manifest files, rather than registry keys, direct the activation of an object.  
  
 Using registration-free activation for your assemblies instead of registering them during deployment offers two advantages:  
  
-   You can control which DLL version is activated when more than one version is installed on a computer.  
  
-   End users can use XCOPY or FTP to copy your application to an appropriate directory on their computer. The application can then be run from that directory.  
  
 This section describes the two types of manifests needed for registration-free COM interop: application and component manifests. These manifests are XML files. An application manifest, which is created by an application developer, contains metadata that describes assemblies and assembly dependencies. A component manifest, created by a component developer, contains information otherwise located in the Windows registry.  
  
### Requirements for registration-free COM interop  
  
1.  Support for registration-free COM interop varies slightly depending on the type of library assembly; specifically, whether the assembly is unmanaged (COM side-by-side) or managed (.NET-based). The following table shows the operating system and .NET Framework version requirements for each assembly type.  
  
    |Assembly type|Operating system|.NET Framework version|  
    |-------------------|----------------------|----------------------------|  
    |COM side-by-side|Microsoft Windows XP|Not required.|  
    |.NET-based|Windows XP with SP2|NET Framework version 1.1 or later.|  
  
     The Windows Server 2003 family also supports registration-free COM interop for .NET-based assemblies.  
  
     For a .NET-based class to be compatible with registry-free activation from COM, the class must have a default constructor and must be public.  
  
### Configuring COM components for registration-free activation  
  
1.  For a COM component to participate in registration-free activation, it must be deployed as a side-by-side assembly. Side-by-side assemblies are unmanaged assemblies.  For more information, see [Using Side-by-side Assemblies](https://msdn.microsoft.com/library/windows/desktop/aa376618.aspx).  
  
     To use COM side-by-side assemblies, a .NET-based application developer must provide an application manifest, which contains the binding and activation information. Support for unmanaged side-by-side assemblies is built into the Windows XP operating system. The COM runtime, supported by the operating system, scans an application manifest for activation information when the component being activated is not in the registry.  
  
     Registration-free activation is optional for COM components installed on Windows XP. For detailed instructions on adding a side-by-side assembly to an application, see [Using Side-by-side Assemblies](https://msdn.microsoft.com/library/windows/desktop/aa376618.aspx).  
  
    > [!NOTE]
    >  Side-by-side execution is a .NET Framework feature that enables multiple versions of the runtime, and multiple versions of applications and components that use a version of the runtime, to run on the same computer at the same time. Side-by-side execution and side-by-side assemblies are different mechanisms for providing side-by-side functionality.  
  
## See Also  
 [How to: Configure .NET Framework-Based COM Components for Registration-Free Activation](../../../docs/framework/interop/configure-net-framework-based-com-components-for-reg.md)
