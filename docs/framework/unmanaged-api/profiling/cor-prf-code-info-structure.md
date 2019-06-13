---
title: "COR_PRF_CODE_INFO Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_CODE_INFO"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_CODE_INFO"
helpviewer_keywords: 
  - "COR_PRF_CODE_INFO structure [.NET Framework profiling]"
ms.assetid: cf30e27c-1f7e-43a2-ba1e-01e4137301db
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# COR_PRF_CODE_INFO Structure
Represents one contiguous block of native code stored in memory.  
  
## Syntax  
  
```  
typedef struct _COR_PRF_CODE_INFO {  
    UINT_PTR startAddress;  
    SIZE_T size;  
} COR_PRF_CODE_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`startAddress`|The starting address of the contiguous block of code.|  
|`size`|The size of the block.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Structures](../../../../docs/framework/unmanaged-api/profiling/profiling-structures.md)
