---
title: "ICorProfilerCallback2::RootReferences2 Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorProfilerCallback2.RootReferences2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::RootReferences2"
helpviewer_keywords: 
  - "RootReferences2 method [.NET Framework profiling]"
  - "ICorProfilerCallback2::RootReferences2 method [.NET Framework profiling]"
ms.assetid: 55a2f907-d216-42eb-8f2f-e5d59c2eebd6
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback2::RootReferences2 Method
Notifies the profiler about root references after a garbage collection has occurred. This method is an extension of the [ICorProfilerCallback::RootReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-rootreferences-method.md) method.  
  
## Syntax  
  
```  
HRESULT RootReferences2(  
    [in] ULONG  cRootRefs,  
    [in, size_is(cRootRefs)] ObjectID rootRefIds[],  
    [in, size_is(cRootRefs)] COR_PRF_GC_ROOT_KIND rootKinds[],  
    [in, size_is(cRootRefs)] COR_PRF_GC_ROOT_FLAGS rootFlags[],  
    [in, size_is(cRootRefs)] UINT_PTR rootIds[]);  
```  
  
#### Parameters  
 `cRootRefs`  
 [in] The number of elements in the `rootRefIds`, `rootKinds`, `rootFlags`, and `rootIds` arrays.  
  
 `rootRefIds`  
 [in] An array of object IDs, each of which references either a static object or an object on the stack. Elements in the `rootKinds` array provide information to classify corresponding elements in the `rootRefIds` array.  
  
 `rootKinds`  
 [in] An array of [COR_PRF_GC_ROOT_KIND](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-root-kind-enumeration.md) values that indicate the type of the garbage collection root.  
  
 `rootFlags`  
 [in] An array of [COR_PRF_GC_ROOT_FLAGS](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-root-flags-enumeration.md) values that describe the properties of a garbage collection root.  
  
 `rootIds`  
 [in] An array of UINT_PTR values that point to an integer that contains additional information about the garbage collection root, depending on the value of the `rootKinds` parameter.  
  
 If the type of the root is a stack, the root ID is for the function that contains the variable. If that root ID is 0, the function is an unnamed function that is internal to the CLR. If the type of the root is a handle, the root ID is for the garbage collection handle. For the other root types, the ID is an opaque value and should be ignored.  
  
## Remarks  
 The `rootRefIds`, `rootKinds`, `rootFlags`, and `rootIds` arrays are parallel arrays. That is, `rootRefIds[i]`, `rootKinds[i]`, `rootFlags[i]`, and `rootIds[i]` all concern the same root.  
  
 Both `RootReferences` and `RootReferences2` are called to notify the profiler. Profilers will normally implement one method or the other, but not both, because the information passed in `RootReferences2` is a superset of that passed in `RootReferences`.  
  
 It is possible for entries in `rootRefIds` to be zero, which implies that the corresponding root reference is null and does not refer to an object on the managed heap.  
  
 The object IDs returned by `RootReferences2` are not valid during the callback itself, because the garbage collection might be in the middle of moving objects from old addresses to new addresses. Therefore, profilers should not attempt to inspect objects during a `RootReferences2` call. When [ICorProfilerCallback2::GarbageCollectionFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-garbagecollectionfinished-method.md) is called, all objects have been moved to their new locations and can be safely inspected.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)
