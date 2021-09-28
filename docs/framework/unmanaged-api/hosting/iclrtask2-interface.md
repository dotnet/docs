---
description: "Learn more about: ICLRTask2 Interface"
title: "ICLRTask2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTask2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTask2"
helpviewer_keywords: 
  - "ICLRTask2 interface [.NET Framework hosting]"
ms.assetid: b5a22ebc-0582-49de-91f9-97a3d9789290
topic_type: 
  - "apiref"
---
# ICLRTask2 Interface

Provides all the functionality of the [ICLRTask](iclrtask-interface.md) interface; in addition, provides methods that allow thread aborts to be delayed on the current thread.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginPreventAsyncAbort Method](iclrtask2-beginpreventasyncabort-method.md)|Delays new thread abort requests on the current thread.|  
|[EndPreventAsyncAbort Method](iclrtask2-endpreventasyncabort-method.md)|Allows new or pending thread abort requests to result in thread aborts on the current thread.|  
  
## Remarks  

 The `ICLRTask2` interface inherits the `ICLRTask` interface and adds methods that allow the host to delay thread aborts, to protect a region of code that must not fail. Calling `BeginPreventAsyncAbort` increments the delay-thread-abort counter for the current thread, and calling `EndPreventAsyncAbort` decrements it. Calls to `BeginPreventAsyncAbort` and `EndPreventAsyncAbort` can be nested. As long as the counter is greater than zero, thread aborts for the current thread are delayed.  
  
 If calls to `BeginPreventAsyncAbort` and `EndPreventAsyncAbort` are not paired, it is possible to reach a state in which thread aborts cannot be delivered to the current thread.  
  
 The delay is not honored for a thread that aborts itself.  
  
 The functionality that is exposed by this feature is used internally by the virtual machine (VM). Misuse of these methods may cause unspecified behavior in the VM. For example, calling `EndPreventAsyncAbort` without first calling `BeginPreventAsyncAbort` could set the counter to zero when the VM has previously incremented it. Similarly, the internal counter is not checked for overflow. If it exceeds its integral limit because it is incremented by both the host and the VM, the resulting behavior is unspecified.  
  
 For information about members inherited from `ICLRTask` and about the other uses of this interface, see the [ICLRTask](iclrtask-interface.md) interface.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
