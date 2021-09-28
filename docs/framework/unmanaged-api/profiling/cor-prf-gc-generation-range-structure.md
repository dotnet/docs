---
description: "Learn more about: COR_PRF_GC_GENERATION_RANGE Structure"
title: "COR_PRF_GC_GENERATION_RANGE Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_GC_GENERATION_RANGE"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_GC_GENERATION_RANGE"
helpviewer_keywords: 
  - "COR_PRF_GC_GENERATION_RANGE structure [.NET Framework profiling]"
ms.assetid: e7e07273-8d10-4a68-807e-59634e3f8c5e
topic_type: 
  - "apiref"
---
# COR_PRF_GC_GENERATION_RANGE Structure

Describes a range (that is, block) of memory that is undergoing garbage collection.  
  
## Syntax  
  
```cpp  
typedef struct COR_PRF_GC_GENERATION_RANGE {  
    COR_PRF_GC_GENERATION generation;  
    ObjectID rangeStart;  
    UINT_PTR rangeLength;  
    UINT_PTR rangeLengthReserved;  
} COR_PRF_GC_GENERATION_RANGE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`generation`|A value of the [COR_PRF_GC_GENERATION](cor-prf-gc-generation-enumeration.md) enumeration that specifies the generation to which the block of memory belongs.|  
|`rangeStart`|The ID of an object that specifies the starting location of the block of memory.|  
|`rangeLength`|A pointer to an integer that specifies the size of the used portion of the memory block (that is, the amount of memory used within the block).|  
|`rangeLengthReserved`|A pointer to an integer that specifies the size of the memory block (that is, the amount of memory reserved for the block).|  
  
## Remarks  

 The `rangeLength` value is guaranteed to be accurate only if [ICorProfilerInfo2::GetGenerationBounds](icorprofilerinfo2-getgenerationbounds-method.md) or [ICorProfilerInfo2::GetObjectGeneration](icorprofilerinfo2-getobjectgeneration-method.md), both of which use the `COR_PRF_GC_GENERATION_RANGE` structure, is called from the [ICorProfilerCallback2::GarbageCollectionStarted](icorprofilercallback2-garbagecollectionstarted-method.md) or the [ICorProfilerCallback2::GarbageCollectionFinished](icorprofilercallback2-garbagecollectionfinished-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Structures](profiling-structures.md)
