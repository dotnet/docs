---
description: "Learn more about: COR_PRF_MISC Enumeration"
title: "COR_PRF_MISC Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_MISC"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_MISC"
helpviewer_keywords: 
  - "COR_PRF_MISC enumeration [.NET Framework profiling]"
ms.assetid: 619bb5de-e309-48b6-a3af-32d935a0ff46
topic_type: 
  - "apiref"
---
# COR_PRF_MISC Enumeration

Contains constant values that specify special identifiers.  
  
## Syntax  
  
```cpp  
typedef enum {  
    PROFILER_PARENT_UNKNOWN = 0xFFFFFFFD,  
    PROFILER_GLOBAL_CLASS   = 0xFFFFFFFE,  
    PROFILER_GLOBAL_MODULE  = 0xFFFFFFFF  
} COR_PRF_MISC;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`PROFILER_PARENT_UNKNOWN`|The default identifier used by [ICorProfilerInfo::GetModuleInfo](icorprofilerinfo-getmoduleinfo-method.md) for a module that has not yet been attached to an assembly.|  
|`PROFILER_GLOBAL_CLASS`|The default class identifier for global constants that do not belong to a class.|  
|`PROFILER_GLOBAL_MODULE`|The default module identifier for global objects that do not belong to a module.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
