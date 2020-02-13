---
title: "ICorProfilerCallback::RootReferences Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RootReferences"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RootReferences"
helpviewer_keywords: 
  - "RootReferences method [.NET Framework profiling]"
  - "ICorProfilerCallback::RootReferences method [.NET Framework profiling]"
ms.assetid: dbdf853b-d1a4-4828-8ef7-53d121d8e6ae
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RootReferences Method
Notifies the profiler with information about root references after garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT RootReferences(  
    [in] ULONG    cRootRefs,  
    [in, size_is(cRootRefs)] ObjectID rootRefIds[] );  
```  
  
## Parameters  
 `cRootRefs`  
 [in] The number of references in the `rootRefIds` array.  
  
 `rootRefIds`  
 [in] An array of object IDs that reference either a static object or an object on the stack.  
  
## Remarks  
 Both `RootReferences` and [ICorProfilerCallback2::RootReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md) are called to notify the profiler. Profilers will normally implement one or the other, but not both, because the information passed in `RootReferences2` is a superset of that passed in `RootReferences`.  
  
 It is possible for the `rootRefIds` array to contain a null object. For example, all object references declared on the stack are treated as roots by the garbage collector and will always be reported.  
  
 The object IDs returned by `RootReferences` are not valid during the callback itself, because the garbage collection might be in the middle of moving objects from old addresses to new addresses. Therefore, profilers must not attempt to inspect objects during a `RootReferences` call. When [ICorProfilerCallback2::GarbageCollectionFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-garbagecollectionfinished-method.md) is called, all objects have been moved to their new locations and can be safely inspected.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
