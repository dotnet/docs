---
title: "IHostThreadPoolManager::QueueUserWorkItem Method"
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
  - "IHostThreadPoolManager.QueueUserWorkItem"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostThreadPoolManager::QueueUserWorkItem"
helpviewer_keywords: 
  - "IHostThreadPoolManager::QueueUserWorkItem method [.NET Framework hosting]"
  - "QueueUserWorkItem method [.NET Framework hosting]"
ms.assetid: 41602053-8670-4827-9d61-cbfcba509b9c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostThreadPoolManager::QueueUserWorkItem Method
Queues a function for execution, and specifies an object containing data to be used by that function. The function executes when a thread becomes available.  
  
## Syntax  
  
```  
HRESULT QueueUserWorkItem (  
    [in] LPTHREAD_START_ROUTINE Function,  
    [in] PVOID Context,  
    [in] ULONG Flags  
);  
```  
  
#### Parameters  
 `Function`  
 [in] A function pointer that represents the function to execute.  
  
 `Context`  
 [in] An object that contains data to be used by `Function`.  
  
 `Flags`  
 [in] One of the flags values, as defined for the Win32 `QueueUserWorkItem` method, that control execution.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`QueueUserWorkItem` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `QueueUserWorkItem` queues a work item to a worker thread in the thread pool. Its signature and parameter types are identical to those of the corresponding Win32 function, which has the same name. For more information, see the Windows Platform documentation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A>  
 <xref:System.Threading.ThreadPool>  
 [IHostThreadPoolManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostthreadpoolmanager-interface.md)
