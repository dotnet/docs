---
description: "Learn more about: COR_PRF_EVENT_DATA structure"
title: "COR_PRF_EVENT_DATA structure"
ms.date: "03/19/2021"
api_name: 
  - "COR_PRF_EVENT_DATA"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# COR_PRF_EVENT_DATA structure

Describes the event data for an EventPipe event being written.
  
## Syntax  
  
```cpp  
typedef struct
{
    UINT64 ptr;
    UINT32 size;
    UINT32 reserved;
} COR_PRF_EVENT_DATA;
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ptr`|A pointer to the data.|  
|`size`|The size of the data pointed to by `ptr`.|  
|`reserved`|An reserved implementation specific field.|  
  
## Remarks  

 The `COR_PRF_EVENT_DATA` structure is used by the [ICorProfilerInfo12::EventPipeWriteEvent](icorprofilerinfo12-eventpipewriteevent-method.md) method to provide the data payload for the event being written.
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
- [ICorProfilerInfo12::EventPipeWriteEvent](icorprofilerinfo12-eventpipewriteevent-method.md)
