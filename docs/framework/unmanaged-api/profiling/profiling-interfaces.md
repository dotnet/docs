---
description: "Learn more about: Profiling Interfaces"
title: "Profiling Interfaces"
ms.date: "08/06/2021"
helpviewer_keywords: 
  - "unmanaged interfaces [.NET Framework], profiling"
  - "profiling interfaces [.NET Framework]"
  - "interfaces [.NET Framework profiling]"
ms.assetid: d9303db8-e881-4217-91b7-8c7573c8ef9e
---
# Profiling Interfaces

This section describes the unmanaged interfaces that enable you to profile a program that is being executed by the common language runtime (CLR).  
  
## In This Section  

[ICLRProfiling Interface](iclrprofiling-interface.md)  
Provides the [AttachProfiler](iclrprofiling-attachprofiler-method.md) method, which enables a profiler to attach to a running process.  

[ICorProfilerAssemblyReferenceProvider Interface](icorprofilerassemblyreferenceprovider-interface.md)  
Enables the profiler to inform the CLR of assembly references that the profiler will add in the [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) callback.  

[ICorProfilerCallback Interface](icorprofilercallback-interface.md)  
Provides methods that are used by the CLR to notify a code profiler when the events to which the profiler has subscribed occur.  

[ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)  
Extends the `ICorProfilerCallback` interface with callbacks supported in the .NET Framework 2.0 and later versions.  

[ICorProfilerCallback3 Interface](icorprofilercallback3-interface.md)  
Provides callback methods that the CLR uses to communicate attach and detach state information to the profiler.  

[ICorProfilerCallback4 Interface](icorprofilercallback4-interface.md)  
Provides callback methods that the CLR uses to communicate information to the profiler.  

[ICorProfilerCallback5 Interface](icorprofilercallback5-interface.md)  
Provides a method that identifies the transitive closure of objects referenced by garbage collection roots.  

[ICorProfilerCallback6 Interface](icorprofilercallback6-interface.md)  
Provides a callback method that the CLR uses to notify a profiler that an assembly is loading.  

[ICorProfilerCallback7 Interface](icorprofilercallback7-interface.md)  
Provides a callback method that the common language runtime uses to notify the profiler that the symbol stream associated with an in-memory module is updated.  

[ICorProfilerCallback8 Interface](icorprofilercallback8-interface.md)  
Provides callback methods that the common language runtime uses to notify the profiler that JIT compilation of a dynamic method has started and finished.

[ICorProfilerCallback9 Interface](icorprofilercallback9-interface.md)  
Provides a callback method that the common language runtime uses to notify the profiler that a dynamic method is garbage collected and subsequently unloaded.

[ICorProfilerCallback10 Interface](icorprofilercallback10-interface.md)  
Provides callback methods to notify the profiler that EventPipe events have been delivered to the profiler's currently active session.

[ICorProfilerFunctionControl Interface](icorprofilerfunctioncontrol-interface.md)  
Provides methods that allow a code profiler to communicate with the CLR to control how the JIT compiler should generate code when recompiling a specific method.  

[ICorProfilerFunctionEnum Interface](icorprofilerfunctionenum-interface.md)  
Provides methods to sequentially iterate through a collection of functions in the CLR.  

[ICorProfilerInfo Interface](icorprofilerinfo-interface.md)  
Provides methods for use by code profilers to communicate with the CLR to control event monitoring and request information.  

[ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)  
Extends the `ICorProfilerInfo` interface with methods supported in the .NET Framework 2.0 and later versions.  

[ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)  
Extends the `ICorProfilerInfo2` interface with methods supported in the .NET Framework 4 and later versions.  

[ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)  
Provides methods that code profilers use to communicate with the CLR to control event monitoring and to request information.  

[ICorProfilerInfo5 Interface](icorprofilerinfo5-interface.md)  
Provides methods for use by code profilers to communicate with the CLR to control event monitoring.  

[ICorProfilerInfo6 Interface](icorprofilerinfo6-interface.md)  
Provides an enumerator to all the methods that belong to a given NGen module and that are inlined in the body of a given method.  

[ICorProfilerInfo7 Interface](icorprofilerinfo7-interface.md)  
Provides a method to apply newly defined metadata to a module and that provides access to an in-memory symbol stream.

[ICorProfilerInfo8 Interface](icorprofilerinfo8-interface.md)  
Provides methods to query information about dynamic methods.

[ICorProfilerInfo9 Interface](icorprofilerinfo9-interface.md)  
Provides methods to query information about functions with multiple native code versions.

[ICorProfilerInfo10 Interface](icorprofilerinfo10-interface.md)  
Provides methods to modify function IL, query information from the runtime, and suspend and resume the runtime.

[ICorProfilerInfo11 Interface](icorprofilerinfo11-interface.md)  
Provides methods to get and set environment variables in the process.

[ICorProfilerInf12 Interface](icorprofilerinfo12-interface.md)  
Provides methods to create EventPipe sessions, events, and providers.

[ICorProfilerModuleEnum Interface](icorprofilermoduleenum-interface.md)  
Provides methods to sequentially iterate through a collection of modules loaded by the application or the profiler.  

[ICorProfilerObjectEnum Interface](icorprofilerobjectenum-interface.md)  
Provides methods to sequentially iterate through a collection of frozen objects that are generated by [Ngen.exe (Native Image Generator)](../../tools/ngen-exe-native-image-generator.md).  

[ICorProfilerThreadEnum Interface](icorprofilerthreadenum-interface.md)  
Provides methods to sequentially iterate through a collection of threads in the CLR.  

[IMethodMalloc Interface](imethodmalloc-interface.md)  
Provides the [Alloc](imethodmalloc-alloc-method.md) method to allocate memory for a new Microsoft intermediate language (MSIL) function body.  

## Related Sections  

 [Profiling Overview](profiling-overview.md)  
  
 [Profiling Global Static Functions](profiling-global-static-functions.md)  
  
 [Profiling Enumerations](profiling-enumerations.md)  
  
 [Profiling Structures](profiling-structures.md)
