---
title: "IHostThreadPoolManager Interface"
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
  - "IHostThreadPoolManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager"
helpviewer_keywords: 
  - "IHostThreadPoolManager interface [.NET Framework hosting]"
ms.assetid: c3a2cd90-7c4e-4374-bb87-b41befb8344f
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostThreadPoolManager Interface
Provides methods that enable the common language runtime (CLR) to configure the thread pool and to queue work items to the thread pool.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetAvailableThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-getavailablethreads-method.md)|Gets the number of threads in the thread pool that are not currently processing work items.|  
|[GetMaxThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-getmaxthreads-method.md)|Gets the maximum number of threads that the host maintains concurrently in the thread pool.|  
|[GetMinThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-getminthreads-method.md)|Gets the minimum number of idle threads that the host maintains in anticipation of requests.|  
|[QueueUserWorkItem Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-queueuserworkitem-method.md)|Queues a function for execution, and provides an object containing data to be used by the function.|  
|[SetMaxThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-setmaxthreads-method.md)|Sets the maximum number of threads that the host can maintain in the thread pool.|  
|[SetMinThreads Method](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-setminthreads-method.md)|Sets the minimum number of idle threads that the host must maintain in anticipation of requests.|  
  
## Remarks  
 The host is not required to configure the thread pool by using the values specified in calls to the `SetMaxThreads` and `SetMinThreads` methods. In this case, the host should return an HRESULT value of E_NOTIMPL from these methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading>  
 <xref:System.Threading.ThreadPool>  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
