---
description: "Learn more about: COR_PRF_EVENTPIPE_LEVEL Enumeration"
title: "COR_PRF_EVENTPIPE_LEVEL Enumeration"
ms.date: "03/19/2021"
api_name: 
  - "COR_PRF_EVENTPIPE_LEVEL"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# COR_PRF_EVENTPIPE_LEVEL Enumeration

Describes the level of an EventPipe event.
  
## Syntax  
  
```cpp  
typedef enum
{
    COR_PRF_EVENTPIPE_LOGALWAYS = 0,
    COR_PRF_EVENTPIPE_CRITICAL = 1,
    COR_PRF_EVENTPIPE_ERROR = 2,
    COR_PRF_EVENTPIPE_WARNING = 3,
    COR_PRF_EVENTPIPE_INFORMATIONAL = 4,
    COR_PRF_EVENTPIPE_VERBOSE = 5
} COR_PRF_EVENTPIPE_LEVEL;
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_EVENTPIPE_LOGALWAYS`|The event is always logged.|
|`COR_PRF_EVENTPIPE_CRITICAL`|The event represents a critical message.|
|`COR_PRF_EVENTPIPE_ERROR`|The event represents an error message.|
|`COR_PRF_EVENTPIPE_WARNING`|The event represents a warning message.|
|`COR_PRF_EVENTPIPE_INFORMATIONAL`|The event represents an informational message.|
|`COR_PRF_EVENTPIPE_VERBOSE`|The event represents a verbose message.|
  
## Remarks  

 The `COR_PRF_EVENTPIPE_LEVEL` enumeration is used by the [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md) method to indicate the level of the event being defined.
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
- [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md)
