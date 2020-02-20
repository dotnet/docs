---
title: "IGCHost::GetThreadStats Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCHost.GetThreadStats"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetThreadStats"
helpviewer_keywords: 
  - "IGCHost::GetThreadStats method [.NET Framework hosting]"
  - "GetThreadStats method [.NET Framework hosting]"
ms.assetid: 826baa9b-9218-4736-a509-7ab193b125a0
topic_type: 
  - "apiref"
---
# IGCHost::GetThreadStats Method
Gets the per-thread statistics for garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadStats (  
    [in] DWORD *pFiberCookie,  
    [in, out] COR_GC_THREAD_STATS *pStats  
);  
```  
  
## Parameters  
 `pFiberCookie`  
 [in] A pointer to a fiber cookie that specifies the thread for which to retrieve the statistics.  
  
 `pStats`  
 [in, out] A pointer to a [COR_GC_THREAD_STATS](../../../../docs/framework/unmanaged-api/hosting/cor-gc-thread-stats-structure.md) structure that contains the garbage collection statistics for the specified thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCHost Interface](../../../../docs/framework/unmanaged-api/hosting/igchost-interface.md)
