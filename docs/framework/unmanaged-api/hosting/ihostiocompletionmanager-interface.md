---
title: "IHostIoCompletionManager Interface"
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
  - "IHostIoCompletionManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostIoCompletionManager"
helpviewer_keywords: 
  - "IHostIoCompletionManager interface [.NET Framework hosting]"
ms.assetid: c28d1983-83f7-46e2-990f-dbb9dc07c818
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostIoCompletionManager Interface
Provides methods that allow the common language runtime (CLR) to interact with I/O completion ports provided by the host.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Bind Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-bind-method.md)|Binds a handle to an I/O completion port.|  
|[CloseIoCompletionPort Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-closeiocompletionport-method.md)|Closes a port that was created through an earlier call to `CreateIoCompletionPort`.|  
|[CreateIoCompletionPort Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-createiocompletionport-method.md)|Requests that the host create a new I/O completion port.|  
|[GetAvailableThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-getavailablethreads-method.md)|Gets the number of I/O completion threads that are not currently processing requests.|  
|[GetHostOverlappedSize Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-gethostoverlappedsize-method.md)|Gets the size of any custom data the host intends to append to I/O requests.|  
|[GetMaxThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-getmaxthreads-method.md)|Gets the maximum number of threads that the host can allot to service I/O requests.|  
|[GetMinThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-getminthreads-method.md)|Gets the minimum number of threads that the host provides to service I/O requests.|  
|[InitializeHostOverlapped Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-initializehostoverlapped-method.md)|Provides the host with an opportunity to initialize any custom data about an I/O request.|  
|[SetCLRIoCompletionManager Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-setclriocompletionmanager-method.md)|Provides the host with an interface pointer to an [ICLRIoCompletionManager](../../../../docs/framework/unmanaged-api/hosting/iclriocompletionmanager-interface.md) instance implemented by the CLR.|  
|[SetMaxThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-setmaxthreads-method.md)|Sets the maximum number of threads that the host allots to service I/O requests.|  
|[SetMinThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostiocompletionmanager-setminthreads-method.md)|Sets the minimum number of threads that the host should allot to I/O completion.|  
  
## Remarks  
 `IHostIoCompletionManager` corresponds to the `ICLRIoCompletionManager` interface implemented by the CLR. The CLR calls the methods of `IHostIoCompletionManager` to bind handles to the ports that the host provides, and the host calls the methods of `ICLRIoCompletionManager` to report the completion of I/O requests.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
