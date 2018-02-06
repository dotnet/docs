---
title: "IAppDomainSetup Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "IAppDomainSetup"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAppDomainSetup"
helpviewer_keywords: 
  - "IAppDomainSetup interface [.NET Framework hosting]"
ms.assetid: 1844da85-c031-40bf-bea4-1a3d12a36c8c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAppDomainSetup Interface
Provides properties that allow the host to configure an <xref:System.AppDomain?displayProperty=nameWithType> type before calling the [ICorRuntimeHost::CreateDomainEx](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomainex-method.md) method to create it.  
  
## Properties  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.AppDomainSetup.ApplicationBase%2A>|Gets or sets the name of the directory that contains the application.|  
|<xref:System.AppDomainSetup.ApplicationName%2A>|Gets or sets the name of the application.|  
|<xref:System.AppDomainSetup.CachePath%2A>|Gets or sets the name of an area specific to the application where files are shadow-copied.|  
|<xref:System.AppDomainSetup.ConfigurationFile%2A>|Gets or sets the name of the configuration file for an application.|  
|<xref:System.AppDomainSetup.DynamicBase%2A>|Gets or sets the name of the directory where dynamically generated files are stored and accessed.|  
|<xref:System.AppDomainSetup.LicenseFile%2A>|Gets or sets the path to the license file that is associated with this domain.|  
|<xref:System.AppDomainSetup.PrivateBinPath%2A>|Gets or sets the list of directories combined with the <xref:System.AppDomainSetup.ApplicationBase%2A> directory to probe for private assemblies.|  
|<xref:System.AppDomainSetup.PrivateBinPathProbe%2A>|Gets or sets a string value that includes or excludes <xref:System.AppDomainSetup.ApplicationBase%2A> from the search path for the application.|  
|<xref:System.AppDomainSetup.ShadowCopyDirectories%2A>|Gets or sets the names of the directories that contain assemblies to be shadow-copied.|  
|<xref:System.AppDomainSetup.ShadowCopyFiles%2A>|Gets or sets a string that indicates whether shadow-copying is turned on or off. Valid values are "true" or "false".|  
  
## Remarks  
 The `IAppDomainSetup` interface corresponds to the managed <xref:System.IAppDomainSetup> interface, which the <xref:System.AppDomainSetup> type implements. See <xref:System.IAppDomainSetup?displayProperty=nameWithType> for detailed descriptions of its properties.  
  
 `IAppDomainSetup` represents assembly binding information that can be added to an <xref:System.AppDomain> instance before its creation. For example, a host can set the <xref:System.AppDomainSetup.ApplicationBase%2A> property to establish a root directory, which the common language runtime (CLR) probes for managed assemblies.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 <xref:System.AppDomain>  
 <xref:System.AppDomainSetup>  
 <xref:System.IAppDomainSetup>  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
