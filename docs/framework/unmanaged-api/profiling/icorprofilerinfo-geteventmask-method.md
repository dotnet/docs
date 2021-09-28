---
description: "Learn more about: ICorProfilerInfo::GetEventMask Method"
title: "ICorProfilerInfo::GetEventMask Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetEventMask"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetEventMask"
helpviewer_keywords: 
  - "GetEventMask method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetEventMask method [.NET Framework profiling]"
ms.assetid: ec34cc13-45a3-4695-abc3-b3347d4e6fc2
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetEventMask Method

Gets the current event categories for which the profiler wants to receive event notifications from the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT GetEventMask(  
    [out] DWORD *pdwEvents);  
```  
  
## Parameters  

 `pdwEvents`  
 [out] A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event. The bits are described in the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration.  
  
## Remarks  
  
> [!NOTE]
> You should call the [GetEventMask2](icorprofilerinfo5-geteventmask2-method.md) method instead of this method. Although the `SetEventMask` method continues to be supported, [GetEventMask2](icorprofilerinfo5-geteventmask2-method.md) provides additional functionality.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [GetEventMask2 Method](icorprofilerinfo5-geteventmask2-method.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
