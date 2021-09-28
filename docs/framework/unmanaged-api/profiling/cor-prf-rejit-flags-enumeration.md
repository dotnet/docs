---
description: "Learn more about: COR_PRF_REJIT_FLAGS Enumeration"
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
topic_type: 
  - "apiref"
author: "davmason"
ms.author: "davmason"
---
# COR_PRF_REJIT_FLAGS Enumeration

Contains values that indicate how the [ICorProfilerInfo10::RequestReJITWithInliners](icorprofilerinfo10-requestrejitwithinliners-method.md) API should behave.  
  
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

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_core_30](../../../../includes/net-core-30-md.md)]
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
