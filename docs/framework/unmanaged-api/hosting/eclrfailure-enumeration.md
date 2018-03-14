---
title: "EClrFailure Enumeration"
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
  - "EClrFailure"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EClrFailure"
helpviewer_keywords: 
  - "EClrFailure enumeration [.NET Framework hosting]"
ms.assetid: 37b95cce-9bfb-4ecf-a00b-33dcba782c67
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EClrFailure Enumeration
Describes the set of failures for which a host can set policy actions.  
  
## Syntax  
  
```  
typedef enum {  
    FAIL_NonCriticalResource,  
    FAIL_CriticalResource,  
    FAIL_FatalRuntime,  
    FAIL_OrphanedLock  
    FAIL_StackOverflow  
    FAIL_AccessViolation  
    FAIL_CodeContract  
} EClrFailure;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`FAIL_NonCriticalResource`|A failure occurred during an attempt to allocate a resource (such as a thread, a block of memory, or a lock) in a non-critical region of code.|  
|`FAIL_CriticalResource`|A failure occurred during an attempt to allocate a resource (such as a thread, a block of memory, or a lock) in a critical region of code.|  
|`FAIL_FatalRuntime`|The common language runtime (CLR) is no longer able to run managed code in the process. Henceforth, calls to any hosting functions return an HRESULT value of HOST_E_CLRNOTAVAILABLE.|  
|`FAIL_OrphanedLock`|A thread has failed to release a lock upon returning from an <xref:System.AppDomain> object. The host cannot set this failure to cause a thread to abort.|  
|`FAIL_StackOverflow`|A stack overflow has occurred.|  
|`FAIL_AccessViolation`|An attempt was made to read or write protected memory. Not supported in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].|  
|`FAIL_CodeContract`|A code contract failure occurred. See [Code Contracts](../../../../docs/framework/debug-trace-profile/code-contracts.md).|  
  
## Remarks  
 See the [ICLRPolicyManager::SetActionOnFailure](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setactiononfailure-method.md) method for a list of [EPolicyAction](../../../../docs/framework/unmanaged-api/hosting/epolicyaction-enumeration.md) values the host can use to specify the policy actions for failure conditions. For more information about critical and non-critical regions of code, see [EClrOperation](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md)  
 [SetActionOnFailure Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setactiononfailure-method.md)  
 [IHostPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostpolicymanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
