---
title: "COR_PRF_GC_REASON Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_GC_REASON"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_GC_REASON"
helpviewer_keywords: 
  - "COR_PRF_GC_REASON enumeration [.NET Framework profiling]"
ms.assetid: 72822b95-a7fb-485e-9d55-1cb016d9a458
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# COR_PRF_GC_REASON Enumeration
Indicates the reason that garbage collection is occurring.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_GC_INDUCED = 1,  
    COR_PRF_GC_OTHER = 0  
} COR_PRF_GC_REASON;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_GC_INDUCED`|The garbage collection was induced by a <xref:System.GC.Collect%2A> method.|  
|`COR_PRF_GC_OTHER`|The reason is unspecified.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
