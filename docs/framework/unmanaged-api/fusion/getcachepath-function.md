---
title: "GetCachePath Function"
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
  - "GetCachePath"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetCachePath"
helpviewer_keywords: 
  - "GetCachePath function [.NET Framework fusion]"
ms.assetid: d977ad29-6619-42e1-b0be-bc25ea950e80
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetCachePath Function
Gets the path to the cached assembly, using the specified flags.  
  
## Syntax  
  
```  
HRESULT GetCachePath (  
    [in]      ASM_CACHE_FLAGS  dwCacheFlags,  
    [in]      LPWSTR           pwzCachePath,  
    [in, out] PDWORD           pcchPath  
 );  
```  
  
#### Parameters  
 `dwCacheFlags`  
 [in] An [ASM_CACHE_FLAGS](../../../../docs/framework/unmanaged-api/fusion/asm-cache-flags-enumeration.md) value that indicates the source of the cached assembly.  
  
 `pwzCachePath`  
 [out] The returned pointer to the path.  
  
 `pcchPath`  
 [in, out] The requested maximum length of `pwzCachePath`, and upon return, the actual length of `pwzCachePath`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ASM_CACHE_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/fusion/asm-cache-flags-enumeration.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
