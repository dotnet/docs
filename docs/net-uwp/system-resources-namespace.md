---
title: "System.Resources namespace | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 92b67e45-7520-4765-8638-90ff8afd1f03
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Resources namespace
The `System.Resources` namespace contains classes and interfaces that enable developers to create, store, and manage various culture-specific resources used in an application.  
  
 This topic displays the types in the `System.Resources` namespace that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Resources namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Resources.MissingManifestResourceException>|The exception that is thrown if the main assembly does not contain the resources for the neutral culture, and they are required because of a missing appropriate satellite assembly.|  
|<xref:System.Resources.NeutralResourcesLanguageAttribute>|Informs the ResourceManager of the default culture of an application. This class cannot be inherited.|  
|<xref:System.Resources.ResourceManager>|Provides convenient access to culture-specific resources at run time.|  
|<xref:System.Resources.SatelliteContractVersionAttribute>|Instructs the ResourceManager to ask for a particular version of a satellite assembly to simplify updates of the main assembly of an application.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)