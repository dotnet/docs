---
description: "Learn more about: ICorProfilerCallback2::GarbageCollectionStarted Method"
title: "ICorProfilerCallback2::GarbageCollectionStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback2.GarbageCollectionStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::GarbageCollectionStarted"
helpviewer_keywords: 
  - "GarbageCollectionStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback2::GarbageCollectionStarted method [.NET Framework profiling]"
ms.assetid: 44eef087-f21f-4fe2-b481-f8a0ee022e7d
topic_type: 
  - "apiref"
---
# ICorProfilerCallback2::GarbageCollectionStarted Method

Notifies the code profiler that garbage collection has started.  
  
## Syntax  
  
```cpp  
HRESULT GarbageCollectionStarted(  
    [in] int cGenerations,  
    [in, size_is(cGenerations), length_is(cGenerations)] BOOL generationCollected[],  
    [in] COR_PRF_GC_REASON reason);  
```  
  
## Parameters  

 `cGenerations`  
 [in] The total number of entries in the `generationCollected` array.  
  
 `generationCollected`  
 [in] An array of Boolean values, which are `true` if the generation that corresponds to the array index is being collected by this garbage collection; otherwise, `false`.  
  
 The array is indexed by a value of the [COR_PRF_GC_GENERATION](cor-prf-gc-generation-enumeration.md) enumeration, which indicates the generation.  
  
 `reason`  
 [in] A value of the [COR_PRF_GC_REASON](cor-prf-gc-reason-enumeration.md) enumeration that indicates the reason the garbage collection was induced.  
  
## Remarks  

 All callbacks that pertain to this garbage collection will occur between the `GarbageCollectionStarted` callback and the corresponding [ICorProfilerCallback2::GarbageCollectionFinished](icorprofilercallback2-garbagecollectionfinished-method.md) callback. These callbacks need not occur on the same thread.  
  
 It is safe for the profiler to inspect objects in their original locations during the `GarbageCollectionStarted` callback. The garbage collector will begin moving objects after the return from `GarbageCollectionStarted`. After the profiler has returned from this callback, the profiler should consider all object IDs to be invalid until it receives a `ICorProfilerCallback2::GarbageCollectionFinished` callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
