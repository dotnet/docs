---
description: "Learn more about: ICLRAssemblyIdentityManager::GetBindingIdentityFromFile Method"
title: "ICLRAssemblyIdentityManager::GetBindingIdentityFromFile Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAssemblyIdentityManager.GetBindingIdentityFromFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyIdentityManager::GetBindingIdentityFromFile"
helpviewer_keywords: 
  - "GetBindingIdentityFromFile method [.NET Framework hosting]"
  - "ICLRAssemblyIdentityManager::GetBindingIdentifyFromFile method [.NET Framework hosting]"
ms.assetid: 7797562d-7b4c-4bd9-8b93-f35e0e2869e4
topic_type: 
  - "apiref"
---
# ICLRAssemblyIdentityManager::GetBindingIdentityFromFile Method

Gets the assembly identity binding data for the assembly at the specified file path.  
  
## Syntax  
  
```cpp  
HRESULT GetBindingIdentityFromFile(  
    [in] LPCWSTR     pwzFilePath,  
    [in] DWORD       dwFlags,  
    [out, size_is(*pcchBufferSize)] LPWSTR pwzBuffer,  
    [in, out] DWORD *pcchBufferSize  
);  
```  
  
## Parameters  

 `pwzFilePath`  
 [in] The path to the file to be evaluated.  
  
 `dwFlags`  
 [in] A value of the [ECLRAssemblyIdentityFlags](eclrassemblyidentityflags-enumeration.md) enumeration that indicates an assembly's identity type. Provided for future extensibility. CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT is the only value that the common language runtime (CLR) version 2.0 supports.  
  
 `pwzBuffer`  
 [out] A buffer containing the opaque assembly identity data.  
  
 `pcchBufferSize`  
 [in, out] A pointer to the size of `pwzBuffer`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method returned successfully.|  
|E_INVALIDARG|The supplied `pwzFilePath` is null.|  
|ERROR_INSUFFICIENT_BUFFER|The size of `pwzBuffer` is too small.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  

 `GetBindingIdentityFromFile` is typically called twice. The first call supplies a null value for `pwzBuffer`, and the method returns the appropriate size in `pcchBufferSize`. The second call supplies an appropriately allocated buffer, and the method returns with the actual buffer data upon completion.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [ICLRHostBindingPolicyManager Interface](iclrhostbindingpolicymanager-interface.md)
