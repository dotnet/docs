---
description: "Learn more about: COR_PRF_EVENTPIPE_PARAM_DESC structure"
title: "COR_PRF_EVENTPIPE_PARAM_DESC structure"
ms.date: "03/19/2021"
api_name: 
  - "COR_PRF_EVENTPIPE_PARAM_DESC"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# COR_PRF_EVENTPIPE_PARAM_DESC structure

Describes the parameter name and type for an EventPipe event.
  
## Syntax  
  
```cpp  
typedef struct
{
    UINT32       type;
    UINT32       elementType;
    const WCHAR *name;
} COR_PRF_EVENTPIPE_PARAM_DESC;
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`type`|The type of the parameter.|  
|`elementType`|The element type if this parameter is an array type.|  
|`name`|A wide character string containing the name of the parameter.|  
  
## Remarks  

 The `COR_PRF_EVENTPIPE_PARAM_DESC` structure is used by the [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md) method to define the parameter types of the event being defined.
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
- [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md)
