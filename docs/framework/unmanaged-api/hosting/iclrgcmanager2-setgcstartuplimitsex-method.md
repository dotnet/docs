---
title: "ICLRGCManager2::SetGCStartupLimitsEx Method"
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
  - "ICLRGCManager2.SetGCStartupLimitsEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRGCManager2::SetCLRGCStartupLimitsEx"
helpviewer_keywords: 
  - "ICLRGCManager2::SetGCStartupLimitsEx method [.NET Framework hosting]"
  - "SetGCStartupLimitsEx method, ICLRGCManager2 interface [.NET Framework hosting]"
ms.assetid: 6c3a08a9-5d65-48d4-8bbf-2a86ed7d356a
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRGCManager2::SetGCStartupLimitsEx Method
Sets the size of a garbage collection segment and the maximum size of the garbage collection system's generation 0.  
  
## Syntax  
  
```  
HRESULT SetGCStartupLimitsEx (  
    [in] SIZE_T SegmentSize,   
    [in] SIZE_T MaxGen0Size  
);  
```  
  
#### Parameters  
 `SegmentSize`  
 [in] The specified size of a garbage collection segment.  
  
 The minimum segment size is 4 MB. Segments can be increased in increments of 1 MB or larger.  
  
 `MaxGen0Size`  
 [in] The specified maximum size for generation 0.  
  
 The minimum generation 0 size is 64 KB.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`SetGCStartupLimitsEx` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The values that `SetGCStartupLimitsEx` sets can be specified only before the host is started. Later calls to `SetGCStartupLimitsEx` are ignored.  
  
 To set either parameter without affecting the other, specify 0 (zero) for the parameter you don't want to change.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Automatic Memory Management](../../../../docs/standard/automatic-memory-management.md)  
 [Garbage Collection](../../../../docs/standard/garbage-collection/index.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)  
 [ICLRGCManager2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-interface.md)
