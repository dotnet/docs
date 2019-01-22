---
title: "ICLRHostBindingPolicyManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRHostBindingPolicyManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostBindingPolicyManager"
helpviewer_keywords: 
  - "ICLRHostBindingPolicyManager interface [.NET Framework hosting]"
ms.assetid: f9da168b-366b-4b2b-bdb9-330b6bad5a6b
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRHostBindingPolicyManager Interface
Provides methods for the host to evaluate current binding policy and communicate policy changes for a specified assembly.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EvaluatePolicy Method](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-evaluatepolicy-method.md)|Evaluates binding policy on behalf of the host.|  
|[ModifyApplicationPolicy Method](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-modifyapplicationpolicy-method.md)|Modifies the binding policy for the specified assembly, and creates a new version of the policy.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [IHostAssemblyStore Interface](../../../../docs/framework/unmanaged-api/hosting/ihostassemblystore-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
