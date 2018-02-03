---
title: "ICLRDomainManager::SetPropertiesForDefaultAppDomain Method"
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
  - "ICLRDomainManager.SetPropertiesForDefaultAppDomain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDomainManager::SetPropertiesForDefaultAppDomain"
helpviewer_keywords: 
  - "ICLRDomainManager::SetPropertiesForDefaultAppDomain method [.NET Framework hosting]"
  - "SetPropertiesForDefaultAppDomain method [.NET Framework hosting]"
ms.assetid: 43e61c4b-c435-45ec-9ef6-c68403aa4200
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDomainManager::SetPropertiesForDefaultAppDomain Method
Sets properties that will be used to initialize the default application domain.  
  
## Syntax  
  
```  
HRESULT SetPropertiesForDefaultAppDomain(  
    [in] DWORD nProperties,  
    [in] LPCWSTR *pwszPropertyNames,  
    [in] LPCWSTR *pwszPropertyValues  
);  
```  
  
#### Parameters  
 `nProperties`  
 [in] The number of entries in `pwszPropertyNames` and `pwszPropertyValues`.  
  
 `pwszPropertyNames`  
 [in] An array of property names, or null if there are no properties. Currently, the only property name that is recognized by this method is "PARTIAL_TRUST_VISIBLE_ASSEMBLIES".  
  
 `pwszPropertyValues`  
 [in] An array of property values, or null if there are no properties.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|HRESULT_FROM_WIN32(ERROR_UNKNOWN_PROPERTY)|`pwszPropertyNames` includes a property name that is not recognized by this method.|  
  
## Remarks  
 The property value for "PARTIAL_TRUST_VISIBLE_ASSEMBLIES" is a list of assemblies that have the conditional <xref:System.Security.AllowPartiallyTrustedCallersAttribute> (APTCA) attribute with the <xref:System.Security.PartialTrustVisibilityLevel.NotVisibleByDefault?displayProperty=nameWithType> flag, which are to be made visible to partially trusted callers in the default application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)  
 [ICLRDomainManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdomainmanager-interface.md)
