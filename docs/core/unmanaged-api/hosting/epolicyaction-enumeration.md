---
description: "Learn more about: EPolicyAction Enumeration"
title: "EPolicyAction Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "EPolicyAction"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EPolicyAction"
helpviewer_keywords: 
  - "EPolicyAction enumeration [.NET Framework hosting]"
ms.assetid: 72dd76ba-239e-45ac-9ded-318fb07d6c6d
topic_type: 
  - "apiref"
---
# EPolicyAction Enumeration

Describes the policy actions the host can set for operations described by [EClrOperation](eclroperation-enumeration.md) and failures described by [EClrFailure](eclrfailure-enumeration.md).  
  
## Syntax  
  
```cpp  
typedef enum {  
    eNoAction,  
    eThrowException,  
    eAbortThread,  
    eRudeAbortThread,  
    eUnloadAppDomain,  
    eRudeUnloadAppDomain,  
    eExitProcess,  
    eFastExitProcess,  
    eRudeExitProcess,  
    eDisableRuntime  
} EPolicyAction;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eAbortThread`|Specifies that the common language runtime (CLR) should abort the thread gracefully. A graceful abort includes attempts to run all `finally` blocks, any `catch` blocks related to thread aborts, and finalizers.|  
|`eDisableRuntime`|Specifies that the CLR should enter a disabled state. No further managed code can be executed in the affected process, and threads are blocked from entering the CLR.|  
|`eExitProcess`|Specifies that the CLR should attempt a graceful exit of the process, including running finalizers and performing cleanup and logging operations.|  
|`eFastExitProcess`|Specifies that the CLR should exit the process immediately, without running finalizers or performing cleanup and logging operations. However, notification is sent to the debugger.|  
|`eNoAction`|Specifies that no action should be taken.|  
|`eRudeAbortThread`|Specifies that the CLR should perform a rude thread abort. Only those `catch` and `finally` blocks marked with <xref:System.EnterpriseServices.MustRunInClientContextAttribute> are executed.|  
|`eRudeExitProcess`|Specifies that the CLR should exit the process without running finalizers or logging operations.|  
|`eRudeUnloadAppDomain`|Specifies that the CLR should perform a rude unload of the <xref:System.AppDomain>. Only finalizers marked with <xref:System.EnterpriseServices.MustRunInClientContextAttribute> are executed. Similarly, all threads with this <xref:System.AppDomain> in their stack receive a `ThreadAbortException`, but only those `catch` and `finally` blocks marked with <xref:System.EnterpriseServices.MustRunInClientContextAttribute> are executed.|  
|`eThrowException`|Specifies that an exception appropriate to the condition, such as out-of-memory, buffer overflow, and so forth, should be thrown.|  
|`eUnloadAppDomain`|Specifies that the <xref:System.AppDomain> should be unloaded. The CLR attempts to run finalizers.|  
  
## Remarks  

 The host sets policy actions by calling methods of the [ICLRPolicyManager](iclrpolicymanager-interface.md) interface. For information about rude and graceful aborts, see the [EClrOperation](eclroperation-enumeration.md) enumeration.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
