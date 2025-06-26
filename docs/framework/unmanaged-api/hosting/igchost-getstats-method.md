---
description: "Learn more about: IGCHost::GetStats Method"
title: "IGCHost::GetStats Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCHost.GetStats"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetStats"
helpviewer_keywords: 
  - "GetStats method, IGCHost interface [.NET Framework hosting]"
  - "IGCHost::GetStats method [.NET Framework hosting]"
ms.assetid: c4ae022c-46ac-4f19-9ddd-09b955f19412
topic_type: 
  - "apiref"
---
# IGCHost::GetStats Method

Gets the statistics for the current state of the garbage collection system.  
  
## Syntax  
  
```cpp  
HRESULT GetStats (  
    [in, out] COR_GC_STATS *pStats  
);  
```  
  
## Parameters  

 `pStats`  
 [in, out] A pointer to a [COR_GC_STATS](cor-gc-stats-structure.md) structure that contains the statistics for the current state of the garbage collection system.  
  
## Remarks  

 The statistics can be used by a smart allocation system to help the garbage collection system operate. For example, the allocation system may determine, after reviewing the statistics, that it needs to add more memory or force a collection.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCHost Interface](igchost-interface.md)
