---
description: "Learn more about: Profiling Enumerations"
title: "Profiling Enumerations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "profiling enumerations [.NET Framework]"
  - "enumerations [.NET Framework profiling]"
  - "unmanaged enumerations [.NET Framework], profiling"
ms.assetid: 8d5f9570-9853-4ce8-8101-df235d5b258e
---
# Profiling Enumerations

This section describes the unmanaged enumerations that the profiling API uses.  
  
## In This Section  

 [COR_PRF_CLAUSE_TYPE Enumeration](cor-prf-clause-type-enumeration.md)  
 Indicates the type of exception clause that the code has just entered or left.  
  
 [COR_PRF_CODEGEN_FLAGS Enumeration](cor-prf-codegen-flags-enumeration.md)  
 Defines the code generation flags that can be set with the [ICorProfilerFunctionControl::SetCodegenFlags](icorprofilerfunctioncontrol-setcodegenflags-method.md) method.  
  
 [COR_PRF_FINALIZER_FLAGS Enumeration](cor-prf-finalizer-flags-enumeration.md)  
 Describes the finalizer for an object.  
  
 [COR_PRF_GC_GENERATION Enumeration](cor-prf-gc-generation-enumeration.md)  
 Identifies a garbage collection generation.  
  
 [COR_PRF_GC_REASON Enumeration](cor-prf-gc-reason-enumeration.md)  
 Indicates the reason that garbage collection is occurring.  
  
 [COR_PRF_GC_ROOT_FLAGS Enumeration](cor-prf-gc-root-flags-enumeration.md)  
 Indicates properties of a garbage collector root.  
  
 [COR_PRF_GC_ROOT_KIND Enumeration](cor-prf-gc-root-kind-enumeration.md)  
 Indicates the kind of garbage collector root that is exposed by the [ICorProfilerCallback2::RootReferences2](icorprofilercallback2-rootreferences2-method.md) callback.  
  
 [COR_PRF_HIGH_MONITOR Enumeration](cor-prf-high-monitor-enumeration.md)  
 Provides flags in addition to those found in the [COR_PRF_MONITOR](cor-prf-monitor-enumeration.md) enumeration that the profiler can specify to the [ICorProfilerInfo5::SetEventMask2](icorprofilerinfo5-seteventmask2-method.md) method when it is loading.  
  
 [COR_PRF_JIT_CACHE Enumeration](cor-prf-jit-cache-enumeration.md)  
 Indicates the result of a cached function search.  
  
 [COR_PRF_MISC Enumeration](cor-prf-misc-enumeration.md)  
 Contains constant values that specify special identifiers.  
  
 [COR_PRF_MODULE_FLAGS Enumeration](cor-prf-module-flags-enumeration.md)  
 Specifies the properties of a module.  
  
 [COR_PRF_MONITOR Enumeration](cor-prf-monitor-enumeration.md)  
 Contains values that are used to specify behavior, capabilities, or events to which the profiler wishes to subscribe.  

[COR_PRF_REJIT_FLAGS Enumeration](cor-prf-rejit-flags-enumeration.md)\
Contains values that indicate how the [ICorProfilerInfo10::RequestReJITWithInliners](icorprofilerinfo10-requestrejitwithinliners-method.md) API should behave.
  
 [COR_PRF_RUNTIME_TYPE Enumeration](cor-prf-runtime-type-enumeration.md)  
 Contains values that indicate the version of the common language runtime.  
  
 [COR_PRF_SNAPSHOT_INFO Enumeration](cor-prf-snapshot-info-enumeration.md)  
 Specifies how much data to pass back with a stack snapshot in each call to the profiler's `StackSnapshotCallback` function.  
  
 [COR_PRF_STATIC_TYPE Enumeration](cor-prf-static-type-enumeration.md)  
 Indicates whether a field is static and, if so, the static quality that applies to the field.  
  
 [COR_PRF_SUSPEND_REASON Enumeration](cor-prf-suspend-reason-enumeration.md)  
 Indicates the reason that the runtime was suspended.  
  
 [COR_PRF_TRANSITION_REASON Enumeration](cor-prf-transition-reason-enumeration.md)  
 Indicates the reason for a transition from managed to unmanaged code, or vice versa.  

 [COR_PRF_EVENTPIPE_PARAM_TYPE](cor-prf-eventpipe-param-type-enumeration.md)
 Indicates the type of an EventPipe parameter.

 [COR_PRF_EVENTPIPE_LEVEL](cor-prf-eventpipe-level-enumeration.md)
 Indivates the level of an EventPipe event.
  
## Related Sections  

 [Profiling Overview](profiling-overview.md)  
  
 [Profiling Interfaces](profiling-interfaces.md)  
  
 [Profiling Global Static Functions](profiling-global-static-functions.md)  
  
 [Profiling Structures](profiling-structures.md)
