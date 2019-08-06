---
title: "ICorProfilerInfo10::GetLOHObjectSizeThreshold"
ms.date: "08/06/2019"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo10.GetLOHObjectSizeThreshold"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: d859f9cf-ff97-465e-8b45-2e1d32890916
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo10::GetLOHObjectSizeThreshold Method
  
 Gets the value of the configured LOH Threshold.   
  
## Syntax  
  
```cpp
HRESULT GetLOHObjectSizeThreshold( [out] DWORD *pThreshold );
```  
  
#### Parameters  
 `pThreshold`
 [out] The large object heap threshold in bytes.
  
## Remarks  
 Objects larger than the Large Object Heap threshold will be allocated on the Large object heap.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_core_22](../../../../includes/net-core-30-md.md)]
  
## See also
- [ICorProfilerInfo10 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo10-interface.md)

