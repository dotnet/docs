---
description: "Learn more about: ICorProfilerModuleEnum::Skip Method"
title: "ICorProfilerModuleEnum::Skip Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerModuleEnum.Skip Method"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerModuleEnum::Skip"
helpviewer_keywords: 
  - "Skip method, ICorProfilerModuleEnum interface [.NET Framework profiling]"
  - "ICorProfilerModuleEnum::Skip method [.NET Framework profiling]"
ms.assetid: 8dc29c6a-e2ba-41d8-a1e0-0fdd21421e0b
topic_type: 
  - "apiref"
---
# ICorProfilerModuleEnum::Skip Method

Advances the enumerator's cursor from its current position so that the specified number of elements are skipped.  
  
## Syntax  
  
```cpp  
HRESULT Skip([in] ULONG celt);  
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
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerModuleEnum Interface](icorprofilermoduleenum-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
