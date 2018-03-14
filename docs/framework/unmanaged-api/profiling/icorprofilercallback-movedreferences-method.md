---
title: "ICorProfilerCallback::MovedReferences Method"
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
  - "ICorProfilerCallback.MovedReferences"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::MovedReferences"
helpviewer_keywords: 
  - "MovedReferences method [.NET Framework profiling]"
  - "ICorProfilerCallback::MovedReferences method [.NET Framework profiling]"
ms.assetid: 996c71ae-0676-4616-a085-84ebf507649d
topic_type: 
  - "apiref"
caps.latest.revision: 26
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::MovedReferences Method
Called to report the new layout of objects in the heap as a result of a compacting garbage collection.  
  
## Syntax  
  
```  
HRESULT MovedReferences(  
    [in]  ULONG  cMovedObjectIDRanges,  
    [in, size_is(cMovedObjectIDRanges)] ObjectID oldObjectIDRangeStart[] ,  
    [in, size_is(cMovedObjectIDRanges)] ObjectID newObjectIDRangeStart[] ,  
    [in, size_is(cMovedObjectIDRanges)] ULONG    cObjectIDRangeLength[] );  
```  
  
#### Parameters  
 `cMovedObjectIDRanges`  
 [in] The number of blocks of contiguous objects that moved as the result of the compacting garbage collection. That is, the value of `cMovedObjectIDRanges` is the total size of the `oldObjectIDRangeStart`, `newObjectIDRangeStart`, and `cObjectIDRangeLength` arrays.  
  
 The next three arguments of `MovedReferences` are parallel arrays. In other words, `oldObjectIDRangeStart[i]`, `newObjectIDRangeStart[i]`, and `cObjectIDRangeLength[i]` all concern a single block of contiguous objects.  
  
 `oldObjectIDRangeStart`  
 [in] An array of `ObjectID` values, each of which is the old (pre-garbage collection) starting address of a block of contiguous, live objects in memory.  
  
 `newObjectIDRangeStart`  
 [in] An array of `ObjectID` values, each of which is the new (post-garbage collection) starting address of a block of contiguous, live objects in memory.  
  
 `cObjectIDRangeLength`  
 [in] An array of integers, each of which is the size of a block of contiguous objects in memory.  
  
 A size is specified for each block that is referenced in the `oldObjectIDRangeStart` and `newObjectIDRangeStart` arrays.  
  
## Remarks  
  
> [!IMPORTANT]
>  This method reports sizes as `MAX_ULONG` for objects that are greater than 4 GB on 64-bit platforms. To get the size of objects that are larger than 4 GB, use the [ICorProfilerCallback4::MovedReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-movedreferences2-method.md) method instead.  
  
 A compacting garbage collector reclaims the memory occupied by dead objects and compacts that freed space. As a result, live objects might be moved within the heap, and `ObjectID` values distributed by previous notifications might change.  
  
 Assume that an existing `ObjectID` value (`oldObjectID`) lies within the following range:  
  
 `oldObjectIDRangeStart[i]` <= `oldObjectID` < `oldObjectIDRangeStart[i]` + `cObjectIDRangeLength[i]`  
  
 In this case, the offset from the start of the range to the start of the object is as follows:  
  
 `oldObjectID` - `oldObjectRangeStart[i]`  
  
 For any value of `i` that is in the following range:  
  
 0 <= `i` < `cMovedObjectIDRanges`  
  
 you can calculate the new `ObjectID` as follows:  
  
 `newObjectID` = `newObjectIDRangeStart[i]` + (`oldObjectID` – `oldObjectIDRangeStart[i]`)  
  
 None of the `ObjectID` values passed by `MovedReferences` are valid during the callback itself, because the garbage collection might be in the middle of moving objects from old locations to new locations. Therefore, profilers should not attempt to inspect objects during a `MovedReferences` call. A [ICorProfilerCallback2::GarbageCollectionFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-garbagecollectionfinished-method.md) callback indicates that all objects have been moved to their new locations and inspection can be performed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [MovedReferences2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-movedreferences2-method.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
