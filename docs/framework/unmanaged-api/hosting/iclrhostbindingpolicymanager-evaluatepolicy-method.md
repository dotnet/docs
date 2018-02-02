---
title: "ICLRHostBindingPolicyManager::EvaluatePolicy Method"
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
  - "ICLRHostBindingPolicyManager.EvaluatePolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostBindingPolicyManager::EvaluatePolicy"
helpviewer_keywords: 
  - "ICLRHostBindingPolicyManager::EvaluatePolicy method [.NET Framework hosting]"
  - "EvaluatePolicy method [.NET Framework hosting]"
ms.assetid: 3a3a9446-7a4e-4836-9b27-5c536c15993d
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRHostBindingPolicyManager::EvaluatePolicy Method
Evaluates binding policy on behalf of the host.  
  
## Syntax  
  
```  
HRESULT EvaluatePolicy (  
    [in] LPCWSTR     pwzReferenceIdentity,  
    [in] BYTE       *pbApplicationPolicy,  
    [in] DWORD       cbAppPolicySize,  
    [out, size_is(*pcchPostPolicyReferenceIdentity)] LPWSTR pwzPostPolicyReferenceIdentity,  
    [in, out] DWORD *pcchPostPolicyReferenceIdentity,  
    [out] DWORD     *pdwPoliciesApplied  
);  
```  
  
#### Parameters  
 `pwzReferenceIdentity`  
 [in] A reference to the assembly before the policy evaluation.  
  
 `pbApplicationPolicy`  
 [in] A pointer to a buffer that contains the policy data.  
  
 `cbAppPolicySize`  
 [in] The size of the `pbApplicationPolicy` buffer.  
  
 `pwzPostPolicyReferenceIdentity`  
 [out] A reference to the assembly after the evaluation of the new policy data.  
  
 `pcchPostPolicyReferenceIdentity`  
 [in, out] A pointer to the size of the assembly identity reference buffer after the evaluation of the new policy data.  
  
 `pdwPoliciesApplied`  
 [out] A pointer to a logical OR combination of [EBindPolicyLevels](../../../../docs/framework/unmanaged-api/hosting/ebindpolicylevels-enumeration.md) values, indicating which policies have been applied.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The evaluation completed successfully.|  
|E_INVALIDARG|Either `pwzReferenceIdentity` or `pbApplicationPolicy` is a null reference.|  
|ERROR_INSUFFICIENT_BUFFER|`cbAppPolicySize` is too small.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The `EvaluatePolicy` method allows the host to influence binding policy to maintain host-specific assembly versioning requirements. The policy engine itself remains inside the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRHostBindingPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-interface.md)
