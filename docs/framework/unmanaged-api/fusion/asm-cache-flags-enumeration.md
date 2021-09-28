---
description: "Learn more about: ASM_CACHE_FLAGS Enumeration"
title: "ASM_CACHE_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ASM_CACHE_FLAGS"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ASM_CACHE_FLAGS"
helpviewer_keywords: 
  - "ASM_CACHE_FLAGS enumeration [.NET Framework fusion]"
ms.assetid: 82e9a7da-321b-48b8-b239-52eaffda6be8
topic_type: 
  - "apiref"
---
# ASM_CACHE_FLAGS Enumeration

Indicates the source of an assembly that is represented by [IAssemblyCacheItem](iassemblycacheitem-interface.md) in the global assembly cache.  
  
## Syntax  
  
```cpp  
typedef enum {  
    ASM_CACHE_ZAP       = 0x01,  
    ASM_CACHE_GAC       = 0x02,  
    ASM_CACHE_DOWNLOAD  = 0x04,  
    ASM_CACHE_ROOT      = 0x08,  
    ASM_CACHE_ROOT_EX   = 0x80  
} ASM_CACHE_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ASM_CACHE_ZAP`|Enumerates the cache of precompiled assemblies by using Ngen.exe.|  
|`ASM_CACHE_GAC`|Enumerates the global assembly cache.|  
|`ASM_CACHE_DOWNLOAD`|Enumerates the assemblies that have been downloaded on demand or that have been shadow-copied.|  
|`ASM_CACHE_ROOT`|Indicates that the [GetCachePath](getcachepath-function.md) function should return the path to the global assembly cache for the common language runtime (CLR) version 2.0. Meaningful only in the context of a call to [GetCachePath](getcachepath-function.md).|  
|`ASM_CACHE_ROOT_EX`|Indicates that the [GetCachePath](getcachepath-function.md) function should return the path to the global assembly cache for CLR version 4. Meaningful only in the context of a call to [GetCachePath](getcachepath-function.md).|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [GetCachePath Function](getcachepath-function.md)
- [IAssemblyCacheItem Interface](iassemblycacheitem-interface.md)
- [Fusion Enumerations](fusion-enumerations.md)
