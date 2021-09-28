---
description: "Learn more about: EClrFailure Enumeration"
title: "EClrFailure Enumeration"
ms.date: "03/30/2017"
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
---
# EClrFailure Enumeration

Describes the set of failures for which a host can set policy actions.  
  
## Syntax  
  
```cpp  
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
|`FAIL_AccessViolation`|An attempt was made to read or write protected memory. Not supported in the .NET Framework 4.|  
|`FAIL_CodeContract`|A code contract failure occurred. See [Code Contracts](../../debug-trace-profile/code-contracts.md).|  
  
## Remarks  

 See the [ICLRPolicyManager::SetActionOnFailure](iclrpolicymanager-setactiononfailure-method.md) method for a list of [EPolicyAction](epolicyaction-enumeration.md) values the host can use to specify the policy actions for failure conditions. For more information about critical and non-critical regions of code, see [EClrOperation](eclroperation-enumeration.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [SetActionOnFailure Method](iclrpolicymanager-setactiononfailure-method.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
