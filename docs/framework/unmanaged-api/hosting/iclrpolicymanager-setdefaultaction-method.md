---
title: "ICLRPolicyManager::SetDefaultAction Method"
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
  - "ICLRPolicyManager.SetDefaultAction"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager::SetDefaultAction"
helpviewer_keywords: 
  - "SetDefaultAction method [.NET Framework hosting]"
  - "ICLRPolicyManager::SetDefaultAction method [.NET Framework hosting]"
ms.assetid: f9411e7a-27df-451f-9f6c-d643d6a7a7ce
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRPolicyManager::SetDefaultAction Method
Specifies the policy action the common language runtime (CLR) should take when the specified operation occurs.  
  
## Syntax  
  
```  
HRESULT SetDefaultAction (  
    [in] EClrOperation operation,  
    [in] EPolicyAction action  
);  
```  
  
#### Parameters  
 `operation`  
 [in] One of the [EClrOperation](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md) values, indicating the action for which CLR behavior should be customized.  
  
 `action`  
 [in] One of the [EPolicyAction](../../../../docs/framework/unmanaged-api/hosting/epolicyaction-enumeration.md) values, indicating the policy action the CLR should take when `operation` occurs.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetDefaultAction` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_INVALIDARG|An invalid `action` was specified for the `operation`, or an invalid value was supplied for `operation`.|  
  
## Remarks  
 Not all policy action values can be specified as the default behavior for CLR operations. `SetDefaultAction` can typically be used only to escalate behavior. For example, a host can specify that thread aborts be turned into rude thread aborts, but cannot specify the opposite. The table below describes the valid `action` values for each possible `operation` value.  
  
|Value for `operation`|Valid values for `action`|  
|---------------------------|-------------------------------|  
|OPR_ThreadAbort|-   eAbortThread<br />-   eRudeAbortThread<br />-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
|OPR_ThreadRudeAbortInNonCriticalRegion<br /><br /> OPR_ThreadRudeAbortInCriticalRegion|-   eRudeAbortThread<br />-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
|OPR_AppDomainUnload|-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
|OPR_AppDomainRudeUnload|-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
|OPR_ProcessExit|-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
|OPR_FinalizerRun|-   eNoAction<br />-   eAbortThread<br />-   eRudeAbortThread<br />-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [EClrOperation Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md)  
 [EPolicyAction Enumeration](../../../../docs/framework/unmanaged-api/hosting/epolicyaction-enumeration.md)  
 [ICLRPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md)
