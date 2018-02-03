---
title: "Running Intranet Applications in Full Trust"
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
  - "full trust, running intranet applications in"
  - "intranet applications, running in full trust"
  - "running intranet applications in full trust"
ms.assetid: ee13c0a8-ab02-49f7-b8fb-9eab16c6c4f0
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Running Intranet Applications in Full Trust
Starting with the .NET Framework version 3.5 Service Pack 1 (SP1), applications and their library assemblies can be run as full-trust assemblies from a network share. <xref:System.Security.SecurityZone.MyComputer> zone evidence is automatically added to assemblies that are loaded from a share on the intranet. This evidence gives those assemblies the same grant set (which is typically full trust) as the assemblies that reside on the computer. This functionality does not apply to ClickOnce applications or to applications that are designed to run on a host.  
  
## Rules for Library Assemblies  
 The following rules apply to assemblies that are loaded by an executable on a network share:  
  
-   Library assemblies must reside in the same folder as the executable assembly. Assemblies that reside in a subfolder or are referenced on a different path are not given the full-trust grant set.  
  
-   If the executable delay-loads an assembly, it must use the same path that was used to start the executable. For example, if the share \\\\*network-computer*\\*share* is mapped to a drive letter and the executable is run from that path, assemblies that are loaded by the executable by using the network path will not be granted full trust. To delay-load an assembly in the <xref:System.Security.SecurityZone.MyComputer> zone, the executable must use the drive letter path.  
  
## Restoring the Former Intranet Policy  
 In earlier versions of the .NET Framework, shared assemblies were granted <xref:System.Security.SecurityZone.Intranet> zone evidence. You had to specify code access security policy to grant full trust to an assembly on a share.  
  
 This new behavior is the default for intranet assemblies. You can return to the earlier behavior of providing <xref:System.Security.SecurityZone.Intranet> evidence by setting a registry key that applies to all applications on the computer. This process is different for 32-bit and 64-bit computers:  
  
-   On 32-bit computers, create a subkey under the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework key in the system registry. Use the key name LegacyMyComputerZone with a DWORD value of 1.  
  
-   On 64-bit computers, create a subkey under the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework key in the system registry. Use the key name LegacyMyComputerZone with a DWORD value of 1. Create the same subkey under the HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\\.NETFramework key.  
  
## See Also  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)
