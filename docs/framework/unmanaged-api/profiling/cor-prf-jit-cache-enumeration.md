---
description: "Learn more about: COR_PRF_JIT_CACHE Enumeration"
title: "COR_PRF_JIT_CACHE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_JIT_CACHE"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_JIT_CACHE"
helpviewer_keywords: 
  - "COR_PRF_JIT_CACHE enumeration [.NET Framework profiling]"
ms.assetid: e7b8f6b4-95bc-4ba5-b9eb-f5590a7326a4
topic_type: 
  - "apiref"
---
# COR_PRF_JIT_CACHE Enumeration

Indicates the result of a cached function search.  
  
> [!NOTE]
> `COR_PRF_CACHED_FUNCTION_FOUND` has a value of zero, so `COR_PRF_JIT_CACHE` cannot be used as a Boolean surrogate.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_CACHED_FUNCTION_FOUND,  
    COR_PRF_CACHED_FUNCTION_NOT_FOUND  
} COR_PRF_JIT_CACHE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_FUNCTION_FOUND`|The search found the function.|  
|`COR_PRF_FUNCTION_NOT_FOUND`|The search did not find the function.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
