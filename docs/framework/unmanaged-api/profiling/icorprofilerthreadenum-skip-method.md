---
description: "Learn more about: ICorProfilerThreadEnum::Skip Method"
title: "ICorProfilerThreadEnum::Skip Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerThreadEnum.Skip"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerThreadEnum::Skip"
helpviewer_keywords: 
  - "Skip method, ICorProfilerThreadEnum interface [.NET Framework profiling]"
  - "ICorProfilerThreadEnum::Skip method [.NET Framework profiling]"
ms.assetid: acb8b029-4a96-4ed7-ae3c-310204e5ceea
topic_type: 
  - "apiref"
---
# ICorProfilerThreadEnum::Skip Method

Advances the enumerator's cursor from its current position to skip the specified number of elements.  
  
## Syntax  
  
```cpp  
HRESULT Skip (    [in] ULONG celt  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of elements to be skipped.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`celt` elements were skipped.|  
|S_FALSE|Fewer than `celt` elements were skipped, which indicates that there are no more elements.|  
  
## Remarks  

 The new position of this enumerator's cursor is (current position) + `celt`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerThreadEnum Interface](icorprofilerthreadenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
