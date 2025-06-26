---
description: "Learn more about: ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList Method"
title: "ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAssemblyIdentityManager.GetCLRAssemblyReferenceList"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList"
helpviewer_keywords: 
  - "GetClrAssemblyReferenceList method [.NET Framework hosting]"
  - "ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList method [.NET Framework hosting]"
ms.assetid: cb5ffae5-287b-4a87-9ca8-7ce3ae0601b7
topic_type: 
  - "apiref"
---
# ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList Method

Gets an interface pointer to an [ICLRAssemblyReferenceList](iclrassemblyreferencelist-interface.md) instance from the supplied list of partial assembly identities.  
  
## Syntax  
  
```cpp  
HRESULT  GetCLRAssemblyReferenceList (  
    [in] LPCWSTR *ppwzAssemblyReferences,  
    [in] DWORD    dwNumOfReferences,  
    [out] ICLRAssemblyReferenceList **ppReferenceList  
);  
```  
  
## Parameters  

 `ppwzAssemblyReferences`  
 [in] An array of null-terminated strings in the form "name, property=value..." that specify a list of partial assembly identities.  
  
 `dwNumOfReferences`  
 [in] The number of items in `ppwzAssemblyReferences`.  
  
 `ppReferenceList`  
 [out] An interface pointer to an `ICLRAssemblyReferenceList` object that contains the assembly identity data for the list of assemblies specified in `ppwzAssemblyReferences`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
