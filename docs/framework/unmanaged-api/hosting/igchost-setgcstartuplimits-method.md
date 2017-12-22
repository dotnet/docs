---
title: "IGCHost::SetGCStartupLimits Method"
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
  - "IGCHost.SetGCStartupLimits"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetGCStartupLimits"
helpviewer_keywords: 
  - "SetGCStartupLimits method, IGCHost interface [.NET Framework hosting]"
  - "IGCHost::SetGCStartupLimits method [.NET Framework hosting]"
ms.assetid: cae53926-82ac-4d1d-b297-0bde0bd1bebb
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCHost::SetGCStartupLimits Method
Sets the segment size and the maximum size for generation 0.  
  
> [!IMPORTANT]
>  Starting with the [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)], you can set segment size and maximum generation 0 size to values greater than `DWORD` by using the [IGCHost2::SetGCStartupLimitsEx](../../../../docs/framework/unmanaged-api/hosting/igchost2-setgcstartuplimitsex-method.md) method.  
  
## Syntax  
  
```  
HRESULT SetGCStartupLimits (  
    [in] DWORD SegmentSize,  
    [in] DWORD MaxGen0Size  
);  
```  
  
#### Parameters  
 `SegmentSize`  
 [in] The size of the segment used by the garbage collection system.  
  
 `MaxGen0Size`  
 [in] The maximum size for generation 0.  
  
## Remarks  
 The `SetGCStartupLimits` method may be called only once. These values cannot be changed later.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** GCHost.idl, GCHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCHost Interface](../../../../docs/framework/unmanaged-api/hosting/igchost-interface.md)
