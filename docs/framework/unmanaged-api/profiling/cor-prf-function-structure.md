---
description: "Learn more about: COR_PRF_FUNCTION Structure"
title: "COR_PRF_FUNCTION Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_FUNCTION"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_FUNCTION"
helpviewer_keywords: 
  - "COR_PRF_FUNCTION structure [.NET Framework profiling]"
ms.assetid: 8bb5acf5-cf4b-4ccb-93f1-46db1f3f8bf3
topic_type: 
  - "apiref"
---
# COR_PRF_FUNCTION Structure

Provides a unique representation of a function by combining its ID with the ID of its recompiled version.  
  
## Syntax  
  
```cpp  
typedef struct _COR_PRF_FUNCTION {    FunctionID functionId;    ReJITID    reJitId;} COR_PRF_FUNCTION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`functionId`|The ID of the function.|  
|`reJitId`|The ID of the recompiled function. A value of 0 (zero) represents the original version of the function.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Profiling Structures](profiling-structures.md)
