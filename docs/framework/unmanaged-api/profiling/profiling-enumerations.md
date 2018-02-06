---
title: "Profiling Enumerations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "profiling enumerations [.NET Framework]"
  - "enumerations [.NET Framework profiling]"
  - "unmanaged enumerations [.NET Framework], profiling"
ms.assetid: 8d5f9570-9853-4ce8-8101-df235d5b258e
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Profiling Enumerations
This section describes the unmanaged enumerations that the profiling API uses.  
  
## In This Section  
 [COR_PRF_CLAUSE_TYPE Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-clause-type-enumeration.md)  
 Indicates the type of exception clause that the code has just entered or left.  
  
 [COR_PRF_CODEGEN_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-codegen-flags-enumeration.md)  
 Defines the code generation flags that can be set with the [ICorProfilerFunctionControl::SetCodegenFlags](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctioncontrol-setcodegenflags-method.md) method.  
  
 [COR_PRF_FINALIZER_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-finalizer-flags-enumeration.md)  
 Describes the finalizer for an object.  
  
 [COR_PRF_GC_GENERATION Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-generation-enumeration.md)  
 Identifies a garbage collection generation.  
  
 [COR_PRF_GC_REASON Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-reason-enumeration.md)  
 Indicates the reason that garbage collection is occurring.  
  
 [COR_PRF_GC_ROOT_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-root-flags-enumeration.md)  
 Indicates properties of a garbage collector root.  
  
 [COR_PRF_GC_ROOT_KIND Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-root-kind-enumeration.md)  
 Indicates the kind of garbage collector root that is exposed by the [ICorProfilerCallback2::RootReferences2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-rootreferences2-method.md) callback.  
  
 [COR_PRF_HIGH_MONITOR Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-high-monitor-enumeration.md)  
 Provides flags in addition to those found in the [COR_PRF_MONITOR](../../../../docs/framework/unmanaged-api/profiling/cor-prf-monitor-enumeration.md) enumeration that the profiler can specify to the [ICorProfilerInfo5::SetEventMask2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo5-seteventmask2-method.md) method when it is loading.  
  
 [COR_PRF_JIT_CACHE Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-jit-cache-enumeration.md)  
 Indicates the result of a cached function search.  
  
 [COR_PRF_MISC Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-misc-enumeration.md)  
 Contains constant values that specify special identifiers.  
  
 [COR_PRF_MODULE_FLAGS Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-module-flags-enumeration.md)  
 Specifies the properties of a module.  
  
 [COR_PRF_MONITOR Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-monitor-enumeration.md)  
 Contains values that are used to specify behavior, capabilities, or events to which the profiler wishes to subscribe.  
  
 [COR_PRF_RUNTIME_TYPE Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-runtime-type-enumeration.md)  
 Contains values that indicate the version of the common language runtime.  
  
 [COR_PRF_SNAPSHOT_INFO Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-snapshot-info-enumeration.md)  
 Specifies how much data to pass back with a stack snapshot in each call to the profiler's `StackSnapshotCallback` function.  
  
 [COR_PRF_STATIC_TYPE Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-static-type-enumeration.md)  
 Indicates whether a field is static and, if so, the static quality that applies to the field.  
  
 [COR_PRF_SUSPEND_REASON Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-suspend-reason-enumeration.md)  
 Indicates the reason that the runtime was suspended.  
  
 [COR_PRF_TRANSITION_REASON Enumeration](../../../../docs/framework/unmanaged-api/profiling/cor-prf-transition-reason-enumeration.md)  
 Indicates the reason for a transition from managed to unmanaged code, or vice versa.  
  
## Related Sections  
 [Profiling Overview](../../../../docs/framework/unmanaged-api/profiling/profiling-overview.md)  
  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)  
  
 [Profiling Structures](../../../../docs/framework/unmanaged-api/profiling/profiling-structures.md)
