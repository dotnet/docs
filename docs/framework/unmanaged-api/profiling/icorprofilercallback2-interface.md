---
title: "ICorProfilerCallback2 Interface"
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
  - "ICorProfilerCallback2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback2"
helpviewer_keywords: 
  - "ICorProfilerCallback2 interface [.NET Framework profiling]"
ms.assetid: 4a261dba-450d-4f1f-8d98-865b58bfc992
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback2 Interface
Provides methods that are used by the common language runtime (CLR) to notify a code profiler when the events to which the profiler has subscribed occur. The `ICorProfilerCallback2` interface is an extension of the [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) interface. That is, it provides new callbacks introduced in the .NET Framework version 2.0.  
  
> [!NOTE]
>  Each method implementation must return an HRESULT having a value of S_OK on success or E_FAIL on failure. Currently, the CLR ignores the HRESULT that is returned by each callback except [ICorProfilerCallback::ObjectReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-objectreferences-method.md).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[FinalizeableObjectQueued Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-finalizeableobjectqueued-method.md)|Notifies the code profiler that an object with a finalizer has been queued to the finalizer thread for execution of its `Finalize` method.|  
|[GarbageCollectionFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-garbagecollectionfinished-method.md)|Notifies the profiler that a garbage collection has completed and all garbage collection callbacks have been issued for it.|  
|[GarbageCollectionStarted Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-garbagecollectionstarted-method.md)|Notifies the code profiler that a garbage collection has started.|  
|[HandleCreated Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-handlecreated-method.md)|Notifies the code profiler that a garbage collection handle has been created.|  
|[HandleDestroyed Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-handledestroyed-method.md)|Notifies the code profiler that a garbage collection handle has been destroyed.|  
|[RootReferences2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md)|Notifies the profiler about root references after a garbage collection has occurred. This method is an extension of the [ICorProfilerCallback::RootReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-rootreferences-method.md) method.|  
|[SurvivingReferences Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-survivingreferences-method.md)|Notifies the profiler about object references that have survived a garbage collection.|  
|[ThreadNameChanged Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-threadnamechanged-method.md)|Notifies the code profiler that the name of a thread has changed.|  
  
## Remarks  
 The CLR calls a method in the `ICorProfilerCallback` (or `ICorProfilerCallback2`) interface to notify the profiler when an event, to which the profiler had subscribed, occurs. This is the primary callback interface through which the CLR communicates with the code profiler.  
  
 A code profiler must implement the methods of the `ICorProfilerCallback` interface. For the .NET Framework 2.0 and later versions, the profiler must also implement the `ICorProfilerCallback2` methods. Each method implementation must return an HRESULT having a value of S_OK on success or E_FAIL on failure. Currently, the CLR ignores the HRESULT that is returned by each callback except [ICorProfilerCallback::ObjectReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-objectreferences-method.md).  
  
 A code profiler must register in the Microsoft Windows registry, its COM object that implements the `ICorProfilerCallback` and `ICorProfilerCallback2` interfaces. A code profiler subscribes to the events for which it wants to receive notification by calling [ICorProfilerInfo::SetEventMask](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-seteventmask-method.md). This is usually done in the profiler's implementation of [ICorProfilerCallback::Initialize](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-initialize-method.md). The profiler is then able to receive notification from the runtime when an event is about to occur or has just occurred in an executing runtime process.  
  
> [!NOTE]
>  The profiler registers a single COM object. If the profiler is targeting .NET Framework version 1.0 or 1.1, that COM object need only implement the methods of `ICorProfilerCallback`. If it is targeting .NET Framework version 2.0 and later, the COM object must also implement the methods of `ICorProfilerCallback2`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 [ICorProfilerCallback3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback3-interface.md)  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)
