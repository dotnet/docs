---
description: "Learn more about: IHostIoCompletionManager::InitializeHostOverlapped Method"
title: "IHostIoCompletionManager::InitializeHostOverlapped Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostIoCompletionManager.InitializeHostOverlapped"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostIoCompletionManager::InitializeHostOverlapped"
helpviewer_keywords: 
  - "IHostIoCompletionManager::InitializeHostOverlapped method [.NET Framework hosting]"
  - "InitializeHostOverlapped method [.NET Framework hosting]"
ms.assetid: c35199bf-bc47-4901-b467-4e8a37644bbb
topic_type: 
  - "apiref"
---
# IHostIoCompletionManager::InitializeHostOverlapped Method

Provides the host with an opportunity to initialize any custom data to append to a Win32 `OVERLAPPED` structure that is used for asynchronous I/O requests.  
  
## Syntax  
  
```cpp  
HRESULT InitializeHostOverlapped (  
    [in] void* pvOverlapped  
);  
```  
  
## Parameters  

 `pvOverlapped`  
 [in] A pointer to the Win32 `OVERLAPPED` structure to be included with the I/O request.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`InitializeHostOverlapped` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to allocate the requested resource.|  
  
## Remarks  

 The Windows Platform functions use the `OVERLAPPED` structure to store state for asynchronous I/O requests. The CLR calls the `InitializeHostOverlapped` method to give the host the opportunity to append custom data to an `OVERLAPPED` instance.  
  
> [!IMPORTANT]
> To get to the beginning of their custom data block, hosts must set the offset to the size of the `OVERLAPPED` structure (`sizeof(OVERLAPPED)`).  
  
 A return value of E_OUTOFMEMORY indicates that the host has failed to initialize its custom data. In this case, the CLR reports an error and fails the call.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRIoCompletionManager Interface](iclriocompletionmanager-interface.md)
- [GetHostOverlappedSize Method](ihostiocompletionmanager-gethostoverlappedsize-method.md)
- [IHostIoCompletionManager Interface](ihostiocompletionmanager-interface.md)
