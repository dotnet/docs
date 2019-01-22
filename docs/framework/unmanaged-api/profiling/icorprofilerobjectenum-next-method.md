---
title: "ICorProfilerObjectEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerObjectEnum.Next"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerObjectEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorProfilerObjectEnum interface [.NET Framework profiling]"
  - "ICorProfilerObjectEnum::Next method [.NET Framework profiling]"
ms.assetid: b420433c-5ebe-4986-bba1-97902e6db819
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerObjectEnum::Next Method
Gets the specified number of contiguous objects from a sequential collection of objects, starting at the enumerator's current position in the sequence.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in] ULONG                    celt,  
    [out, size_is(celt), length_is(*pceltFetched)]    
        ObjectID                  objects[],  
    [out] ULONG                   *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of objects to be retrieved.  
  
 `objects`  
 [out] An array of `ObjectID` values, each of which represents a retrieved object.  
  
 `pceltFetched`  
 [out] A pointer to the number of elements actually returned in the `objects` array.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
- [ICorProfilerObjectEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md)
