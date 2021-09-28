---
description: "Learn more about: ICorProfilerInfo2::GetObjectGeneration Method"
title: "ICorProfilerInfo2::GetObjectGeneration Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetObjectGeneration"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetObjectGeneration"
helpviewer_keywords: 
  - "GetObjectGeneration method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetObjectGeneration method [.NET Framework profiling]"
ms.assetid: b0d25f76-0bd5-4aa6-96cf-bfec0e1de28b
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetObjectGeneration Method

Gets the segment of the heap that contains the specified object.  
  
## Syntax  
  
```cpp  
HRESULT GetObjectGeneration(  
    [in] ObjectID objectId,  
    [out] COR_PRF_GC_GENERATION_RANGE *range);  
```  
  
## Parameters  

 `objectId`  
 [in] The ID of the object.  
  
 `range`  
 [out] A pointer to a [COR_PRF_GC_GENERATION_RANGE](cor-prf-gc-generation-range-structure.md) structure, which describes a range (that is, a block) of memory within the generation that is undergoing garbage collection. This range contains the specified object.  
  
## Remarks  

 The `GetObjectGeneration` method may be called from any profiler callback, provided that garbage collection is not in progress. That is, it may be called from any callback except those that occur between [ICorProfilerCallback2::GarbageCollectionStarted](icorprofilercallback2-garbagecollectionstarted-method.md) and [ICorProfilerCallback2::GarbageCollectionFinished](icorprofilercallback2-garbagecollectionfinished-method.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
