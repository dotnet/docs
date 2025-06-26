---
description: "Learn more about: ICLRPolicyManager::SetActionOnFailure Method"
title: "ICLRPolicyManager::SetActionOnFailure Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRPolicyManager.SetActionOnFailure"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager::SetActionOnFailure"
helpviewer_keywords: 
  - "SetActionOnFailure method [.NET Framework hosting]"
  - "ICLRPolicyManager::SetActionOnFailure method [.NET Framework hosting]"
ms.assetid: 4664033f-db97-4388-b988-2ec470796e58
topic_type: 
  - "apiref"
---
# ICLRPolicyManager::SetActionOnFailure Method

Specifies the policy action the common language runtime (CLR) should take when the specified failure occurs.  
  
## Syntax  
  
```cpp  
HRESULT SetActionOnFailure (  
    [in] EClrFailure   failure,  
    [in] EPolicyAction action  
);  
```  
  
## Parameters  

 `failure`  
 [in] One of the [EClrFailure](eclrfailure-enumeration.md) values, indicating the type of failure for which to take action.  
  
 `action`  
 [in] One of the [EPolicyAction](epolicyaction-enumeration.md) values, indicating the action to be taken when a failure occurs. For a list of supported values, see the Remarks section.  
  
## Return Value  
  
| HRESULT                | Description                                                                                                                                                                                 |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| S_OK                   | `SetActionOnFailure` returned successfully.                                                                                                                                                 |
| HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                  |
| HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
| HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
| HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
| E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
| E_INVALIDARG           | A policy action cannot be set for the specified operation, or an invalid policy action was specified for the operation.                                                                     |
  
## Remarks  

 By default, the CLR throws an exception when it fails to allocate a resource such as memory. `SetActionOnFailure` allows the host to override this behavior by specifying the policy action to take upon failure. The following table shows the combinations of [EClrFailure](eclrfailure-enumeration.md) (columns) and [EPolicyAction](epolicyaction-enumeration.md) (rows) values that are supported.
  
|                            | `FAIL_NonCriticalResource` | `FAIL_CriticalResource` | `FAIL_FatalRuntime` | `FAIL_OrphanedLock` | `FAIL_StackOverflow` | `FAIL_AccessViolation` | `FAIL_CodeContract` |
| -------------------------- | -------------------------- | ----------------------- | ------------------- | ------------------- | -------------------- | ---------------------- | ------------------- |
| **`eNoAction`**            | X                          | X                       |                     |                     |                      | N/A                    |                     |
| **`eThrowException`**      | X                          | X                       |                     |                     |                      | N/A                    |                     |
| **`eAbortThread`**         | X                          | X                       |                     |                     |                      | N/A                    | X                   |
| **`eRudeAbortThread`**     | X                          | X                       |                     |                     |                      | N/A                    | X                   |
| **`eUnloadAppDomain`**     | X                          | X                       |                     | X                   |                      | N/A                    | X                   |
| **`eRudeUnloadAppDomain`** | X                          | X                       |                     | X                   | X                    | N/A                    | X                   |
| **`eExitProcess`**         | X                          | X                       |                     | X                   | X                    | N/A                    | X                   |
| **`eFastExitProcess`**     | X                          | X                       |                     | X                   | X                    | N/A                    |                     |
| **`eRudeExitProcess`**     | X                          | X                       | X                   | X                   | X                    | N/A                    |                     |
| **`eDisableRuntime`**      | X                          | X                       | X                   | X                   | X                    | N/A                    |                     |
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
