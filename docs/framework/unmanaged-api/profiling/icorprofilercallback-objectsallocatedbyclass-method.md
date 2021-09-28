---
description: "Learn more about: ICorProfilerCallback::ObjectsAllocatedByClass Method"
title: "ICorProfilerCallback::ObjectsAllocatedByClass Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ObjectsAllocatedByClass"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ObjectsAllocatedByClass"
helpviewer_keywords: 
  - "ObjectsAllocatedByClass method [.NET Framework profiling]"
  - "ICorProfilerCallback::ObjectsAllocatedByClass method [.NET Framework profiling]"
ms.assetid: 91d688f3-a80e-419d-9755-ff94bc04188a
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ObjectsAllocatedByClass Method

Notifies the profiler about the number of instances of each specified class that have been created since the most recent garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT ObjectsAllocatedByClass(  
    [in] ULONG   cClassCount,  
    [in, size_is(cClassCount)] ClassID classIds[] ,  
    [in, size_is(cClassCount)] ULONG   cObjects[] );  
```  
  
## Parameters  

 `cClassCount`  
 [in] The size of the `classIds` and `cObjects` arrays.  
  
 `classIds`  
 [in] An array of class IDs, where each ID specifies a class with one or more instances.  
  
 `cObjects`  
 [in] An array of integers, where each integer specifies the number of instances for the corresponding class in the `classIds` array.  
  
## Remarks  

 The `classIds` and `cObjects` arrays are parallel arrays. For example, `classIds[i]` and `cObjects[i]` reference the same class. If no instance of a class has been created since the previous garbage collection, the class is omitted. The `ObjectsAllocatedByClass` callback will not report objects allocated in the large object heap.  
  
 The numbers reported by `ObjectsAllocatedByClass` are only estimates. For exact counts, use [ICorProfilerCallback::ObjectAllocated](icorprofilercallback-objectallocated-method.md).  
  
 The `classIds` array may contain one or more null entries if the corresponding `cObjects` array has types that are unloading.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
