---
title: "ICorProfilerCallback5::ConditionalWeakTableElementReferences Method"
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
  - "ICorProfilerCallback5.ConditionalWeakTableReferences"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CondiitonalWeakTableElementReferences"
helpviewer_keywords: 
  - "ConditionalWeakTableElementReferences method, ICorProfilerCallback5 interface [.NET Framework profiling]"
  - "ICorProfilerCallback5::ConditionalWeakTableElementReferences method [.NET Framework profiling]"
ms.assetid: 532c7a02-a9de-4cea-bb2b-7f470da594de
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback5::ConditionalWeakTableElementReferences Method
Identifies the transitive closure of objects referenced by those roots through both direct member field references and through `ConditionalWeakTable` dependencies.  
  
## Syntax  
  
```  
HRESULT ConditionalWeakTableElementReferences(     [in]                     ULONG    cRootRefs,     [in, size_is(cRootRefs)] ObjectID keyRefIds[],     [in, size_is(cRootRefs)] ObjectID valueRefIds[],     [in, size_is(cRootRefs)] GCHandleID rootIds[]);};  
```  
  
#### Parameters  
 `cRootRefs`  
 [in] The number of elements in the `keyRefIds`, `valueRefIds`, and `rootIds` arrays.  
  
 `keyRefIds`  
 [in] An array of object IDs, each of which contains the `ObjectID` for the primary element in the dependent handle pair.  
  
 `valueRefIds`  
 [in] An array of object IDs, each of which contains the `ObjectID` for the secondary element in the dependent handle pair. (`keyRefIds[i]` keeps `valueRefIds[i]` alive.)  
  
 `rootIds`  
 [in] An array of `GCHandleID` values that point to an integer that contains additional information about the garbage collection root.  
  
 None of the `ObjectID` values returned by the `ConditionalWeakTableElementReferences` method are valid during the callback itself, because the garbage collector may be in the process of moving objects from old to new locations. Therefore, profilers should not attempt to inspect objects during a `ConditionalWeakTableElementReferences` call. At `GarbageCollectionFinished`, all objects have been moved to their new locations, and inspection may be done.  
  
## Example  
 The following code example demonstrates how to implement [ICorProfilerCallback5](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-interface.md) and use this method.  
  
```  
HRESULT Callback5Impl::ConditionalWeakTableElementReferences(  
    ULONG      cRootRefs,  
    ObjectID   keyRefIds[],  
    ObjectID   valueRefIds[],  
    GCHandleID rootIds[])  
{  
    printf("Callback5Impl::ConditionalWeakTableElementReferences called\n");  
    for (unsigned int i = 0; i < cRootRefs; ++i)  
    {  
        // Save dependency to XML for later retrieval  
        PersistDependencyToXml(rootIds[i], keyRefIds[i], valueRefIds[i]);  
        // or store dependency to an internal map  
        m_cwt_deps->add_dep(rootIds[i], keyRefIds[i], valueRefIds[i]);  
        // or add arc to object graph  
        m_obj_graph->add_arc(keyRefIds[i], valueRefIds[i], rootIds[i]);  
    }  
    return S_OK;  
}  
```  
  
## Remarks  
 A profiler for the [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)] or later versions implements the [ICorProfilerCallback5](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-interface.md) interface and records the dependencies specified by the `ConditionalWeakTableElementReferences` method. `ICorProfilerCallback5` provides the complete set of dependencies among live objects represented by `ConditionalWeakTable` entries. These dependencies and the member field references specified by the [ICorProfilerCallback::ObjectReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-objectreferences-method.md) method enable a managed profiler to generate the full object graph of live objects.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback5 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-interface.md)
