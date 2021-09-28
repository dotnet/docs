---
description: "Learn more about: ICorProfilerInfo::SetEventMask Method"
title: "ICorProfilerInfo::SetEventMask Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.SetEventMask"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::SetEventMask"
helpviewer_keywords: 
  - "ICorProfilerInfo::SetEventMask method [.NET Framework profiling]"
  - "SetEventMask method [.NET Framework profiling]"
ms.assetid: 44bc0f56-32fa-491e-a62d-52fc96d48125
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::SetEventMask Method

Sets a value that specifies the types of events for which the profiler wants to receive notification from the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT SetEventMask(  
    [in] DWORD dwEvents);  
```  
  
## Parameters  

 `dwEvents`  
 [in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration.  
  
## Remarks  
  
> [!NOTE]
> You should call the [SetEventMask2](icorprofilerinfo5-seteventmask2-method.md) method instead of this method. Although the `SetEventMask` method continues to be supported, [SetEventMask2](icorprofilerinfo5-seteventmask2-method.md) provides additional functionality.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [SetEventMask2 Method](icorprofilerinfo5-seteventmask2-method.md)
