---
title: "COR_PRF_REJIT_FLAGS Enumeration"
ms.date: "08/06/2019"
api_name: 
  - "COR_PRF_REJIT_FLAGS Enumeration"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_REJIT_FLAGS"
helpviewer_keywords: 
  - "COR_PRF_REJIT_FLAGS enumeration [.NET Framework profiling]"
ms.assetid: 35449514-333f-4918-9c60-7aa198d655d2
topic_type: 
  - "apiref"
author: "davmason"
ms.author: "davmason"
---
# COR_PRF_REJIT_FLAGS Enumeration
Contains values that indicate the version of the common language runtime (CLR): desktop or CoreCLR, which is used in Silverlight.  
  
## Syntax  
  
```cpp  
typedef enum  
{      
    COR_PRF_REJIT_BLOCK_INLINING = 0x1,
    COR_PRF_REJIT_INLINING_CALLBACKS    = 0x2
} COR_PRF_REJIT_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_REJIT_BLOCK_INLINING`| ReJITted methods will be blocked from being inlined in other methods. |  
|`COR_PRF_REJIT_INLINING_CALLBACKS`| Receive `GetFunctionParameters` callbacks for any methods that inline the methods requested to be ReJITted. |  

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
