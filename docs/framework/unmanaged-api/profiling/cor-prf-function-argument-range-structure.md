---
title: "COR_PRF_FUNCTION_ARGUMENT_RANGE Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_FUNCTION_ARGUMENT_RANGE"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_FUNCTION_ARGUMENT_RANGE"
helpviewer_keywords: 
  - "COR_PRF_FUNCTION_ARGUMENT_RANGE structure [.NET Framework profiling'"
ms.assetid: 9f469eac-ac66-419b-8668-fe705bc1a51f
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# COR_PRF_FUNCTION_ARGUMENT_RANGE Structure
Represents a block of function arguments stored contiguously in left-to-right order in memory.  
  
## Syntax  
  
```  
typedef struct _COR_PRF_FUNCTION_ARGUMENT_RANGE {  
    UINT_PTR startAddress;  
    ULONG length;  
} COR_PRF_FUNCTION_ARGUMENT_RANGE;  
```  
  
## Members  
  
|Members|Description|  
|-------------|-----------------|  
|`startAddress`|The starting address of the block.|  
|`length`|The length of the contiguous block.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [Profiling Structures](../../../../docs/framework/unmanaged-api/profiling/profiling-structures.md)
