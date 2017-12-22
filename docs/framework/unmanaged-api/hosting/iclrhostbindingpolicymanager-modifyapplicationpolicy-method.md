---
title: "ICLRHostBindingPolicyManager::ModifyApplicationPolicy Method"
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
  - "ICLRHostBindingPolicyManager.ModifyApplicationPolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostBindingPolicyManager::ModifyApplicationPolicy"
helpviewer_keywords: 
  - "ICLRHostBindingPolicyManager::ModifyApplicationPolicy method [.NET Framework hosting]"
  - "ModifyApplicationPolicy method [.NET Framework hosting]"
ms.assetid: d82d633e-cce6-427c-8b02-8227e34e12ba
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRHostBindingPolicyManager::ModifyApplicationPolicy Method
Modifies the binding policy for the specified assembly, and creates a new version of the policy.  
  
## Syntax  
  
```  
HRESULT  ModifyApplicationPolicy (  
    [in] LPCWSTR     pwzSourceAssemblyIdentity,   
    [in] LPCWSTR     pwzTargetAssemblyIdentity,  
    [in] BYTE       *pbApplicationPolicy,  
    [in] DWORD       cbAppPolicySize,  
    [in] DWORD       dwPolicyModifyFlags,  
    [out, size_is(*pcbNewAppPolicySize)] BYTE *pbNewApplicationPolicy,   
    [in, out] DWORD *pcbNewAppPolicySize  
);  
```  
  
#### Parameters  
 `pwzSourceAssemblyIdentity`  
 [in] The identity of the assembly to modify.  
  
 `pwzTargetAssemblyIdentity`  
 [in] The new identity of the modified assembly.  
  
 `pbApplicationPolicy`  
 [in] A pointer to a buffer that contains the binding policy data for the assembly to modify.  
  
 `cbAppPolicySize`  
 [in] The size of the binding policy to be replaced.  
  
 `dwPolicyModifyFlags`  
 [in] A logical OR combination of [EHostBindingPolicyModifyFlags](../../../../docs/framework/unmanaged-api/hosting/ehostbindingpolicymodifyflags-enumeration.md) values, indicating control of redirection.  
  
 `pbNewApplicationPolicy`  
 [out] A pointer to a buffer that contains the new binding policy data.  
  
 `pcbNewAppPolicySize`  
 [in, out] A pointer to the size of the new binding policy buffer.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The policy was modified successfully.|  
|E_INVALIDARG|`pwzSourceAssemblyIdentity` or `pwzTargetAssemblyIdentity` was a null reference.|  
|ERROR_INSUFFICIENT_BUFFER|`pbNewApplicationPolicy` is too small.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The `ModifyApplicationPolicy` method can be called twice. The first call should supply a null value for the `pbNewApplicationPolicy` parameter. This call will return with the necessary value for `pcbNewAppPolicySize`. The second call should supply this value for `pcbNewAppPolicySize`, and point to a buffer of that size for `pbNewApplicationPolicy`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRHostBindingPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-interface.md)
