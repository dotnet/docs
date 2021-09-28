---
description: "Learn more about: ICorProfilerInfo5::SetEventMask2 Method"
title: "ICorProfilerInfo5::SetEventMask2 Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "IcorProfilerInfo5.SetEventMask2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 05dbbe2b-049c-4a60-be69-2ad7a949405e
topic_type: 
  - "apiref"
---
# ICorProfilerInfo5::SetEventMask2 Method

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Sets a value that specifies the types of events for which the profiler wants to receive event notifications from the common language runtime (CLR). It provides more functionality than the [ICorProfilerInfo::SetEventMask](icorprofilerinfo-seteventmask-method.md) method.  
  
## Syntax  
  
```cpp
HRESULT SetEventMask2(        [in] DWORD dwEventsLow,        [in] DWORD dwEventsHigh  
);  
```  
  
## Parameters  

 `dwEventsLow`  
 [in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration.  
  
 `dwEventsHigh`  
 [in] A 4-byte value that specifies the categories of events.  Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_HIGH_MONITOR](cor-prf-high-monitor-enumeration.md) enumeration.  
  
## Remarks  

 The `SetEventMask2` method is used to set the callbacks to which the profiler subscribes. Typically, you call the [GetEventMask2](icorprofilerinfo5-geteventmask2-method.md) method to determine which bits are set, perform a logical OR of its `pdwEventsLow` and `pdwEventsHigh` values and any new bits you want to set, and then call the `SetEventMask2` method.  
  
 This method is the recommended alternative to the [SetEventMask](icorprofilerinfo-seteventmask-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [ICorProfilerInfo5 Interface](icorprofilerinfo5-interface.md)
- [GetEventMask2 Method](icorprofilerinfo5-geteventmask2-method.md)
