---
title: "ICorProfilerCallback2::SurvivingReferences Method"
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
  - "ICorProfilerCallback2.SurvivingReferences"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2::SurvivingReferences"
helpviewer_keywords: 
  - "ICorProfilerCallback2::SurvivingReferences method [.NET Framework profiling]"
  - "SurvivingReferences method [.NET Framework profiling]"
ms.assetid: f165200e-3a91-47f7-88fc-13ff10c8babc
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback2::SurvivingReferences Method
Reports the layout of objects in the heap as a result of a non-compacting garbage collection.  
  
## Syntax  
  
```  
HRESULT SurvivingReferences(  
    [in] ULONG  cSurvivingObjectIDRanges,  
    [in, size_is(cSurvivingObjectIDRanges)] ObjectID  
                objectIDRangeStart[] ,  
    [in, size_is(cSurvivingObjectIDRanges)] ULONG  
                cObjectIDRangeLength[] );  
```  
  
#### Parameters  
 `cSurvivingObjectIDRanges`  
 [in] The number of blocks of contiguous objects that survived as the result of the non-compacting garbage collection. That is, the value of `cSurvivingObjectIDRanges` is the size of the `objectIDRangeStart` and `cObjectIDRangeLength` arrays, which store an `ObjectID` and a length, respectively, for each block of objects.  
  
 The next two arguments of `SurvivingReferences` are parallel arrays. In other words, `objectIDRangeStart` and `cObjectIDRangeLength` concern the same block of contiguous objects.  
  
 `objectIDRangeStart`  
 [in] An array of `ObjectID` values, each of which is the starting address of a block of contiguous, live objects in memory.  
  
 `cObjectIDRangeLength`  
 [in] An array of integers, each of which is the size of a surviving block of contiguous objects in memory.  
  
 A size is specified for each block that is referenced in the `objectIDRangeStart` array.  
  
## Remarks  
  
> [!IMPORTANT]
>  This method reports sizes as `MAX_ULONG` for objects that are greater than 4 GB on 64-bit platforms. For objects that are larger than 4 GB, use the [ICorProfilerCallback4::SurvivingReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-survivingreferences2-method.md) method instead.  
  
 The elements of the `objectIDRangeStart` and `cObjectIDRangeLength` arrays should be interpreted as follows to determine whether an object survived the garbage collection. Assume that an `ObjectID` value (`ObjectID`) lies within the following range:  
  
 `ObjectIDRangeStart[i]` <= `ObjectID` < `ObjectIDRangeStart[i]` + `cObjectIDRangeLength[i]`  
  
 For any value of `i` that is in the following range, the object has survived the garbage collection:  
  
 0 <= `i` < `cSurvivingObjectIDRanges`  
  
 A non-compacting garbage collection reclaims the memory occupied by "dead" objects, but does not compact that freed space. As a result, memory is returned to the heap, but no "live" objects are moved.  
  
 The common language runtime (CLR) calls `SurvivingReferences` for non-compacting garbage collections. For compacting garbage collections, [ICorProfilerCallback::MovedReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-movedreferences-method.md) is called instead. A single garbage collection can be compacting for one generation and non-compacting for another. For a garbage collection on any particular generation, the profiler will receive either a `SurvivingReferences` callback or a `MovedReferences` callback, but not both.  
  
 Multiple `SurvivingReferences` callbacks might be received during a particular garbage collection, due to limited internal buffering, multiple threads reporting in the case of server garbage collection, and other reasons. In the case of multiple callbacks during a garbage collection, the information is cumulative — all references that are reported in any `SurvivingReferences` callback survive the garbage collection.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)  
 [SurvivingReferences2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-survivingreferences2-method.md)
