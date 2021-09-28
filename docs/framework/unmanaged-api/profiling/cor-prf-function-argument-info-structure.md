---
description: "Learn more about: COR_PRF_FUNCTION_ARGUMENT_INFO Structure"
title: "COR_PRF_FUNCTION_ARGUMENT_INFO Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_FUNCTION_ARGUMENT_INFO"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_FUNCTION_ARGUMENT_INFO"
helpviewer_keywords: 
  - "COR_PRF_FUNCTION_ARGUMENT_INFO structure [.NET Framework profiling]"
ms.assetid: 07cf3bab-e193-4991-8205-3f41cf2d67b3
topic_type: 
  - "apiref"
---
# COR_PRF_FUNCTION_ARGUMENT_INFO Structure

Represents a function's arguments, in left-to-right order.  
  
## Syntax  
  
```cpp  
typedef struct _COR_PRF_FUNCTION_ARGUMENT_INFO {  
    ULONG numRanges;  
    ULONG totalArgumentSize;  
    COR_PRF_FUNCTION_ARGUMENT_RANGE ranges[1];  
} COR_PRF_FUNCTION_ARGUMENT_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`numRanges`|The number of blocks of arguments. That is, this value is the number of [COR_PRF_FUNCTION_ARGUMENT_RANGE](cor-prf-function-argument-range-structure.md) structures in the `ranges` array.|  
|`totalArgumentSize`|The total size of all arguments. In other words, this value is the sum of the argument lengths.|  
|`ranges`|An array of `COR_PRF_FUNCTION_ARGUMENT_RANGE` structures, each of which represents one block of function arguments.|  
  
## Remarks  

 A function may have many arguments. Those arguments might not be stored contiguously in memory. You might have a block of three arguments in one place, a block of two arguments in another place, and a final block of one argument in a different place. These arguments are all for the same function; they're just stored in different places.  
  
 The `COR_PRF_FUNCTION_ARGUMENT_INFO` structure represents all the arguments of a single function. It uses an array to reference all the blocks of function arguments. So, for a single function, you have a single `COR_PRF_FUNCTION_ARGUMENT_INFO` structure, which references multiple `COR_PRF_FUNCTION_ARGUMENT_RANGE` structures, each of which points to one or more function arguments.  
  
 Arguments that are stored in registers are spilled into memory to build the structures.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Structures](profiling-structures.md)
