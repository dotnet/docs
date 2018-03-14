---
title: "ICorProfilerCallback4::SurvivingReferences2 Method"
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
  - "ICorProfilerCallback4.SurvivingReferences2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback4::SurvivingReferences2"
helpviewer_keywords: 
  - "ICorProfilerCallback4::SurvivingReferences2 method [.NET Framework profiling]"
  - "SurvivingReferences2 method, ICorProfilerCallback4 interface [.NET Framework profiling]"
ms.assetid: 02b51888-5d89-4e50-a915-45b7e329aad9
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback4::SurvivingReferences2 Method
Reports the layout of objects in the heap as a result of a non-compacting garbage collection. This method is called if the profiler has implemented the [ICorProfilerCallback4](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md) interface. This callback replaces the [ICorProfilerCallback2::SurvivingReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-survivingreferences-method.md) method, because it can report larger ranges of objects whose lengths exceed what can be expressed in a ULONG.  
  
## Syntax  
  
```  
HRESULT SurvivingReferences2(  
    [in] ULONG  cSurvivingObjectIDRanges,  
    [in, size_is(cSurvivingObjectIDRanges)] ObjectID  
                objectIDRangeStart[] ,  
    [in, size_is(cSurvivingObjectIDRanges)] SIZE_T  
                cObjectIDRangeLength[] );  
```  
  
#### Parameters  
 `cSurvivingObjectIDRanges`  
 [in] The number of blocks of contiguous objects that survived as the result of the non-compacting garbage collection. That is, the value of `cSurvivingObjectIDRanges` is the size of the `objectIDRangeStart` and `cObjectIDRangeLength` arrays, which store an `ObjectID` and a length, respectively, for each block of objects.  
  
 The next two arguments of `SurvivingReferences2` are parallel arrays. In other words, `objectIDRangeStart` and `cObjectIDRangeLength` concern the same block of contiguous objects.  
  
 `objectIDRangeStart`  
 [in] An array of `ObjectID` values, each of which is the starting address of a block of contiguous, live objects in memory.  
  
 `cObjectIDRangeLength`  
 [in] An array of integers, each of which is the size of a surviving block of contiguous objects in memory.  
  
 A size is specified for each block that is referenced in the `objectIDRangeStart` array.  
  
## Remarks  
 The elements of the `objectIDRangeStart` and `cObjectIDRangeLength` arrays should be interpreted as follows to determine whether an object survived the garbage collection. Assume that an `ObjectID` value (`ObjectID`) lies within the following range:  
  
 `ObjectIDRangeStart[i]` <= `ObjectID` < `ObjectIDRangeStart[i]` + `cObjectIDRangeLength[i]`  
  
 For any value of `i` that is in the following range, the object has survived the garbage collection:  
  
 0 <= `i` < `cSurvivingObjectIDRanges`  
  
 A non-compacting garbage collection reclaims the memory occupied by "dead" objects, but does not compact that freed space. As a result, memory is returned to the heap, but no "live" objects are moved.  
  
 The common language runtime (CLR) calls `SurvivingReferences2` for non-compacting garbage collections. For compacting garbage collections, [MovedReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-movedreferences2-method.md) is called instead. A single garbage collection can be compacting for one generation and non-compacting for another. For a garbage collection on any particular generation, the profiler will receive either a `SurvivingReferences2` callback or a [MovedReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-movedreferences2-method.md) callback, but not both.  
  
 Multiple `SurvivingReferences2` callbacks might be received during a particular garbage collection, because of limited internal buffering, multiple callbacks during server garbage collection, and other reasons. In the case of multiple callbacks during a garbage collection, the information is cumulative; all references that are reported in any `SurvivingReferences2` callback survive the garbage collection.  
  
 If the profiler implements both the [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) and the [ICorProfilerCallback4](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md) interfaces, the `SurvivingReferences2` method is called before the [ICorProfilerCallback2::SurvivingReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-survivingreferences-method.md) method, but only if `SurvivingReferences2` returns successfully. Profilers can return an HRESULT that indicates failure from the `SurvivingReferences2` method to avoid calling the second method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)
