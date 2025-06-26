---
description: "Learn more about: ICLRIoCompletionManager Interface"
title: "ICLRIoCompletionManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRIoCompletionManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRIoCompletionManager"
helpviewer_keywords: 
  - "ICLRIoCompletionManager interface [.NET Framework hosting]"
ms.assetid: c6c3ace6-e5e7-4450-8cc5-a9a48208c493
topic_type: 
  - "apiref"
---
# ICLRIoCompletionManager Interface

Implements a callback method that allows the host to notify the common language runtime (CLR) of the status of specified I/O requests.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[OnComplete Method](iclriocompletionmanager-oncomplete-method.md)|Notifies the CLR of the status of an I/O request that was made by using a call to the [IHostIoCompletionManager::Bind](ihostiocompletionmanager-bind-method.md) method.|  
  
## Remarks  

 The host implements the I/O completion abstraction by using the [IHostIoCompletionManager](ihostiocompletionmanager-interface.md) interface. The CLR makes I/O requests through this interface, and the host notifies the runtime of the outcome of such requests by using the `ICLRIoCompletionManager` interface.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
- [IHostThreadPoolManager Interface](ihostthreadpoolmanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
