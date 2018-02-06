---
title: "Profiling Interfaces"
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
  - "unmanaged interfaces [.NET Framework], profiling"
  - "profiling interfaces [.NET Framework]"
  - "interfaces [.NET Framework profiling]"
ms.assetid: d9303db8-e881-4217-91b7-8c7573c8ef9e
caps.latest.revision: 31
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Profiling Interfaces
This section describes the unmanaged interfaces that enable you to profile a program that is being executed by the common language runtime (CLR).  
  
## In This Section  
 [ICLRProfiling Interface](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-interface.md)  
 Provides the [AttachProfiler](../../../../docs/framework/unmanaged-api/profiling/iclrprofiling-attachprofiler-method.md) method, which enables a profiler to attach to a running process.  
  
 [ICorProfilerAssemblyReferenceProvider Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md)  
 Enables the profiler to inform the CLR of assembly references that the profiler will add in the [ICorProfilerCallback::ModuleLoadFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleloadfinished-method.md) callback.  
  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)  
 Provides methods that are used by the CLR to notify a code profiler when the events to which the profiler has subscribed occur.  
  
 [ICorProfilerCallback2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)  
 Extends the `ICorProfilerCallback` interface with callbacks supported in the .NET Framework 2.0 and later versions.  
  
 [ICorProfilerCallback3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback3-interface.md)  
 Provides callback methods that the CLR uses to communicate attach and detach state information to the profiler.  
  
 [ICorProfilerCallback4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback4-interface.md)  
 Provides callback methods that the CLR uses to communicate information to the profiler.  
  
 [ICorProfilerCallback5 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback5-interface.md)  
 Provides a method that identifies the transitive closure of objects referenced by garbage collection roots.  
  
 [ICorProfilerCallback6 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-interface.md)  
 Provides a callback method that the CLR uses to notify a profiler that an assembly is loading.  
  
 [ICorProfilerCallback7 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback7-interface.md)  
 Provides a callback method that the common language runtime uses to notify the profiler that the symbol stream associated with an in-memory module is updated.  
  
 [ICorProfilerFunctionControl Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctioncontrol-interface.md)  
 Provides methods that allow a code profiler to communicate with the CLR to control how the JIT compiler should generate code when recompiling a specific method.  
  
 [ICorProfilerFunctionEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerfunctionenum-interface.md)  
 Provides methods to sequentially iterate through a collection of functions in the CLR.  
  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 Provides methods for use by code profilers to communicate with the CLR to control event monitoring and request information.  
  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)  
 Extends the `ICorProfilerInfo` interface with methods supported in the .NET Framework 2.0 and later versions.  
  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 Extends the `ICorProfilerInfo2` interface with methods supported in the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] and later versions.  
  
 [ICorProfilerInfo4 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-interface.md)  
 Provides methods that code profilers use to communicate with the CLR to control event monitoring and to request information.  
  
 [ICorProfilerInfo5 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo5-interface.md)  
 Provides methods for use by code profilers to communicate with the CLR to control event monitoring.  
  
 [ICorProfilerInfo6 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo6-interface.md)  
 Provides an enumerator to all the methods that belong to a given NGen module and that are inlined in the body of a given method.  
  
 [ICorProfilerInfo7 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo7-interface.md)  
 Provides a method to apply newly defined metadata to a module and that provides access to an in-memory symbol stream.  
  
 [ICorProfilerModuleEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilermoduleenum-interface.md)  
 Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.  
  
 [ICorProfilerObjectEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerobjectenum-interface.md)  
 Provides methods to sequentially iterate through a collection of frozen objects that are generated by [Ngen.exe (Native Image Generator)](../../../../docs/framework/tools/ngen-exe-native-image-generator.md).  
  
 [ICorProfilerThreadEnum Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerthreadenum-interface.md)  
 Provides methods to sequentially iterate through a collection of threads in the CLR.  
  
 [IMethodMalloc Interface](../../../../docs/framework/unmanaged-api/profiling/imethodmalloc-interface.md)  
 Provides the [Alloc](../../../../docs/framework/unmanaged-api/profiling/imethodmalloc-alloc-method.md) method to allocate memory for a new Microsoft intermediate language (MSIL) function body.  
  
## Related Sections  
 [Profiling Overview](../../../../docs/framework/unmanaged-api/profiling/profiling-overview.md)  
  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)  
  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)  
  
 [Profiling Structures](../../../../docs/framework/unmanaged-api/profiling/profiling-structures.md)
