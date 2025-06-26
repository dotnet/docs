---
description: "Learn more about: ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference Method"
title: "ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAssemblyIdentityManager.GetProbingAssembliesFromReference"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference"
helpviewer_keywords: 
  - "ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference method [.NET Framework hosting]"
  - "GetProbingAssembliesFromReference method [.NET Framework hosting]"
ms.assetid: aec05744-e8d4-44c6-b4a8-e583229ac34e
topic_type: 
  - "apiref"
---
# ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference Method

Gets an [ICLRProbingAssemblyEnum](iclrprobingassemblyenum-interface.md) enumerator for the assembly identities referenced by the assembly with the specified identity type.  
  
## Syntax  
  
```cpp  
HRESULT GetProbingAssembliesFromReference (  
    [in] DWORD   dwMachineType,  
    [in] DWORD   dwFlags,  
    [in] LPCWSTR pwzReferenceIdentity,  
    [out] ICLRProbingAssemblyEnum **ppProbingAssemblyEnum  
);  
```  
  
## Parameters  

 `dwMachineType`  
 [in] A valid value that specifies the processor architecture, as defined in WinNT.h.  
  
 `dwFlags`  
 [in] Provided for future extensibility. CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT is the only value that the current version of the common language runtime (CLR) supports.  
  
 `pwzReferenceIdentity`  
 [in] An opaque assembly binding identity, typically returned from a call to the [ICLRAssemblyIdentityManager::GetBindingIdentityFromFile](iclrassemblyidentitymanager-getbindingidentityfromfile-method.md) or [ICLRAssemblyIdentityManager::GetBindingIdentityFromStream](iclrassemblyidentitymanager-getbindingidentityfromstream-method.md) method.  
  
 `ppProbingAssemblyEnum`  
 [out] An interface pointer to an `ICLRProbingAssemblyEnum` enumerator that contains references to the assemblies referenced by the assembly identified by `pwzReferenceIdentity`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
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
- [ICLRProbingAssemblyEnum Interface](iclrprobingassemblyenum-interface.md)
