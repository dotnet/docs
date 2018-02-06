---
title: "ICLRAssemblyIdentityManager::GetReferencedAssembliesFromFile Method"
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
  - "ICLRAssemblyIdentityManager.GetReferencedAssembliesFromFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyIdentityManager::GetReferencedAssembliesFromFile"
helpviewer_keywords: 
  - "ICLRAssemblyIdentityManager::GetReferenceAssembliesFromFile method [.NET Framework hosting]"
  - "GetReferenceAssembliesFromFile method [.NET Framework hosting]"
ms.assetid: eed63d31-d977-4c7d-9443-f9d37a2a7d81
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRAssemblyIdentityManager::GetReferencedAssembliesFromFile Method
Gets an [ICLRReferenceAssemblyEnum](../../../../docs/framework/unmanaged-api/hosting/iclrreferenceassemblyenum-interface.md) instance that contains a list of assemblies referenced by the assembly at the specified file path.  
  
## Syntax  
  
```  
HRESULT GetReferencedAssembliesFromFile (  
    [in]  LPCWSTR pwzFilePath,  
    [in]  DWORD   dwFlags,  
    [in]  ICLRAssemblyReferenceList   *pExcludeAssembliesList,  
    [out] ICLRReferenceAssemblyEnum  **ppReferenceEnum  
);  
```  
  
#### Parameters  
 `pwzFilePath`  
 [in] The path to the assembly to be evaluated.  
  
 `dwFlags`  
 [in] Provided for future extensibility. CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT is the only value that the current version of the common language runtime (CLR) supports.  
  
 `pExcludeAssembliesList`  
 [in] A pointer to an [ICLRAssemblyReferenceList](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md) object that represents assemblies that should be excluded from `ppReferenceEnum`.  
  
 `ppReferenceEnum`  
 [out] A pointer to the address of an `ICLRReferenceAssemblyEnum` object that contains assembly identity data for the assemblies referenced by the assembly at `pwzFilePath`, excluding the assemblies represented by `pExcludeAssembliesList`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The caller can choose to exclude a set of known assembly references from the returned list. This set is defined by the `pExcludeAssembliesList` parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [ICLRAssemblyReferenceList Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyreferencelist-interface.md)  
 [ICLRReferenceAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/hosting/iclrreferenceassemblyenum-interface.md)
