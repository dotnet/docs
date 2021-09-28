---
description: "Learn more about: ICorProfilerInfo5::GetEventMask2 Method"
title: "ICorProfilerInfo5::GetEventMask2 Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo5.GetEventMask2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: f854b68f-009c-4ffb-89cd-ca874d1c0fb7
topic_type: 
  - "apiref"
---
# ICorProfilerInfo5::GetEventMask2 Method

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Gets the current event categories for which the profiler wants to receive notifications from the common language runtime (CLR).  It provides functionality not provided by the [ICorProfilerInfo::GetEventMask](icorprofilerinfo-geteventmask-method.md) method.  
  
## Syntax  
  
```cpp
HRESULT GetEventMask2(  
        [out] DWORD* pdwEventsLow,  
        [out] DWORD* pdwEventsHigh  
);  
```  
  
## Parameters  

 `pdwEventsLow`  
 [out] A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration.  
  
 `pdwEventsHigh`  
 [out] A pointer to a 4-byte value that specifies the categories of events.  Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_HIGH_MONITOR](cor-prf-high-monitor-enumeration.md) enumeration.  
  
## Remarks  

 The `GetEventMask2` method is used to determine which callbacks the profiler has subscribed to. Typically, you perform a logical OR of the `pdwEventsLow` and `pdwEventsHigh` values and any new bits you want to set, and then call the [SetEventMask2](icorprofilerinfo5-seteventmask2-method.md) method.  
  
 This method is the recommended alternative to the [GetEventMask](icorprofilerinfo-geteventmask-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [ICorProfilerInfo5 Interface](icorprofilerinfo5-interface.md)
- [SetEventMask2 Method](icorprofilerinfo5-seteventmask2-method.md)
