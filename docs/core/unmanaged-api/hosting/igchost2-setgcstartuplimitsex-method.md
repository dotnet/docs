---
description: "Learn more about: IGCHost2::SetGCStartupLimitsEx Method"
title: "IGCHost2::SetGCStartupLimitsEx Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCHost2.SetGCStartupLimitsEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IGCHost2::SetGCStartupLimitsEx"
helpviewer_keywords: 
  - "IGCHost2::SetGCStartupLimitsEx method [.NET Framework hosting]"
  - "SetGCStartupLimitsEx method, IGCHost2 interface [.NET Framework hosting]"
ms.assetid: bba941c2-1c57-46d3-bbf5-5fb92700c490
topic_type: 
  - "apiref"
---
# IGCHost2::SetGCStartupLimitsEx Method

Sets the segment size and the maximum size for generation 0.  
  
## Syntax  
  
```cpp  
HRESULT SetGCStartupLimitsEx (  
    [in] SIZE_T SegmentSize,  
    [in] SIZE_T MaxGen0Size  
);  
```  
  
## Parameters  

 `SegmentSize`  
 [in] The size of the segment used by the garbage collection system.  
  
 `MaxGen0Size`  
 [in] The maximum size for generation 0.  
  
## Remarks  

 The values that `SetGCStartupLimitsEx` sets can be specified only before the host is started. These values cannot be changed later.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [IGCHost2 Interface](igchost2-interface.md)
