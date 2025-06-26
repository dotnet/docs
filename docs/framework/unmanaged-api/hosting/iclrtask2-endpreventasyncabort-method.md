---
description: "Learn more about: ICLRTask2::EndPreventAsyncAbort Method"
title: "ICLRTask2::EndPreventAsyncAbort Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask2.EndPreventAsyncAbort"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask2::EndPreventAsyncAbort"
helpviewer_keywords: 
  - "EndPreventAsyncAbort method [.NET Framework hosting]"
  - "ICLRTask2::EndPreventAsyncAbort method [.NET Framework hosting]"
ms.assetid: d8013659-e3df-44b3-814f-a6b534ce62f8
topic_type: 
  - "apiref"
---
# ICLRTask2::EndPreventAsyncAbort Method

Allows new or pending thread abort requests to result in thread aborts on the current thread.  
  
## Syntax  
  
```cpp  
HRESULT EndPreventAsyncAbort();  
```  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|HOST_E_INVALIDOPERATION|The method was called on a thread which is not the current thread.|  
  
## Remarks  

 Calling this method decrements the delay-thread-abort counter for the current thread by one.  
  
 Calls to [ICLRTask2::BeginPreventAsyncAbort](iclrtask2-beginpreventasyncabort-method.md) and `EndPreventAsyncAbort` can be nested. As long as the counter is greater than zero, thread aborts for the current thread are delayed.  
  
 The functionality that is exposed by this feature is used internally by the virtual machine (VM). Misuse of these methods may cause unspecified behavior in the VM. For example, calling `EndPreventAsyncAbort` without first calling `BeginPreventAsyncAbort` could set the counter to zero when the VM has previously incremented it. Similarly, the internal counter is not checked for overflow. If it exceeds its integral limit because it is incremented by both the host and the VM, the resulting behavior is unspecified.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [BeginPreventAsyncAbort Method](iclrtask2-beginpreventasyncabort-method.md)
- [ICLRTask2 Interface](iclrtask2-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
