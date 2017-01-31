---
title: "System.Resources namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b4ececd5-deb2-467e-a2ac-19bcd832c486
caps.latest.revision: 5
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.Resources namespaces for UWP apps
The `System.Resources` namespace contains classes and interfaces that enable developers to create, store, and manage various culture-specific resources used in an application.  
  
 This topic displays the types in the `System.Resources` namespace that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.Resources namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Resources.MissingManifestResourceException>|The exception that is thrown if the main assembly does not contain the resources for the neutral culture, and they are required because of a missing appropriate satellite assembly.|  
|<xref:System.Resources.NeutralResourcesLanguageAttribute>|Informs the ResourceManager of the default culture of an application. This class cannot be inherited.|  
|<xref:System.Resources.ResourceManager>|Provides convenient access to culture-specific resources at run time.|  
|<xref:System.Resources.SatelliteContractVersionAttribute>|Instructs the ResourceManager to ask for a particular version of a satellite assembly to simplify updates of the main assembly of an application.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)