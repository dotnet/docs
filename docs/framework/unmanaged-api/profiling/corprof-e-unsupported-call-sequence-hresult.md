---
description: "Learn more about: CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT"
title: "CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT"
ms.date: "03/30/2017"
f1_keywords: 
  - "CORPROF_E_UNSUPPORTED_CALL_SEQUENCE"
helpviewer_keywords: 
  - "CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT [.NET Framework profiling]"
ms.assetid: f2fc441f-d62e-4f72-a011-354ea13c8c59
---
# CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT

The CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT was introduced in .NET Framework version 2.0. .NET Framework 4 returns this HRESULT in two scenarios:  
  
- When a hijacking profiler forcibly resets a thread's register context at an arbitrary time so that the thread tries to access structures that are in an inconsistent state.  
  
- When a profiler tries to call an informational method that triggers garbage collection from a callback method that forbids garbage collection.  
  
These two scenarios are discussed in the following sections.  
  
## Hijacking Profilers  

  (This scenario is primarily an issue with hijacking profilers, although there are cases where non-hijacking profilers can see this HRESULT.)  
  
 In this scenario, a hijacking profiler forcibly resets a thread's register context at an arbitrary time so that the thread can enter profiler code or reenter the common language runtime (CLR) through an [ICorProfilerInfo](icorprofilerinfo-interface.md) method.  
  
 Many of the IDs that the profiling API provides point to data structures in the CLR. Many `ICorProfilerInfo` calls merely read information from these data structures and pass them back. However, the CLR might change things in those structures as it runs, and it might use locks to do so. Suppose the CLR was already holding (or attempting to acquire) a lock at the time the profiler hijacked the thread. If the thread reenters the CLR and tries to take more locks or inspect structures that were in the process of being modified, these structures might be in an inconsistent state. Deadlocks and access violations can easily occur in such situations.  
  
 In general, when a non-hijacking profiler executes code inside an [ICorProfilerCallback](icorprofilercallback-interface.md) method and calls into an `ICorProfilerInfo` method with valid parameters, it should not deadlock or receive an access violation. For example, profiler code that runs inside the [ICorProfilerCallback::ClassLoadFinished](icorprofilercallback-classloadfinished-method.md) method may ask for information about the class by calling the [ICorProfilerInfo2::GetClassIDInfo2](icorprofilerinfo2-getclassidinfo2-method.md) method. The code might receive an CORPROF_E_DATAINCOMPLETE HRESULT to indicate that information is unavailable. However, it will not deadlock or receive an access violation. These calls into `ICorProfilerInfo` are considered synchronous, because they are made from an `ICorProfilerCallback` method.  
  
 However, a managed thread that executes code that is not within an `ICorProfilerCallback` method is considered to be making an asynchronous call. In .NET Framework version 1, it was difficult to determine what might happen in an asynchronous call. The call could deadlock, crash, or give an invalid answer. .NET Framework version 2.0 introduced some simple checks to help you avoid this problem. In .NET Framework 2.0, if you call an unsafe `ICorProfilerInfo` function asynchronously, it fails with an CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT.  
  
 In general, asynchronous calls are not safe. However, the following methods are safe and specifically support asynchronous calls:  
  
- [GetEventMask](icorprofilerinfo-geteventmask-method.md)  
  
- [SetEventMask](icorprofilerinfo-seteventmask-method.md)  
  
- [GetCurrentThreadID](icorprofilerinfo-getcurrentthreadid-method.md)  
  
- [GetThreadContext](icorprofilerinfo-getthreadcontext-method.md)  
  
- [GetThreadAppDomain](icorprofilerinfo2-getthreadappdomain-method.md)  
  
- [GetFunctionFromIP](icorprofilerinfo-getfunctionfromip-method.md)  
  
- [GetFunctionInfo](icorprofilerinfo-getfunctioninfo-method.md)  
  
- [GetFunctionInfo2](icorprofilerinfo2-getfunctioninfo2-method.md)  
  
- [GetCodeInfo](icorprofilerinfo-getcodeinfo-method.md)  
  
- [GetCodeInfo2](icorprofilerinfo2-getcodeinfo2-method.md)  
  
- [GetModuleInfo](icorprofilerinfo-getmoduleinfo-method.md)  
  
- [GetClassIDInfo](icorprofilerinfo-getclassidinfo-method.md)  
  
- [GetClassIDInfo2](icorprofilerinfo2-getclassidinfo2-method.md)  
  
- [IsArrayClass](icorprofilerinfo-isarrayclass-method.md)  
  
- [SetFunctionIDMapper](icorprofilerinfo-setfunctionidmapper-method.md)  
  
- [DoStackSnapshot](icorprofilerinfo2-dostacksnapshot-method.md)  
  
 For more information, see the entry [Why we have CORPROF_E_UNSUPPORTED_CALL_SEQUENCE](/archive/blogs/davbr/why-we-have-corprof_e_unsupported_call_sequence) in the CLR Profiling API blog.  
  
## Triggering Garbage Collections  

 This scenario involves a profiler that is running inside a callback method (for example, one of the `ICorProfilerCallback` methods) that forbids garbage collection. If the profiler tries to call an informational method (for example, a method on the `ICorProfilerInfo` interface) that might trigger a garbage collection, the informational method fails with a CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT.  
  
 The following table displays the callback methods that forbid garbage collections, and informational methods that may trigger garbage collections. If the profiler executes inside one of the listed callback methods and calls one of the listed informational methods, that informational method fails with a CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT.  
  
|Callback methods that forbid garbage collections|Informational methods that trigger garbage collections|  
|------------------------------------------------------|------------------------------------------------------------|  
|[ThreadAssignedToOSThread](icorprofilercallback-threadassignedtoosthread-method.md)<br /><br /> [ExceptionUnwindFunctionEnter](icorprofilercallback-exceptionunwindfunctionenter-method.md)<br /><br /> [ExceptionUnwindFunctionLeave](icorprofilercallback-exceptionunwindfunctionleave-method.md)<br /><br /> [ExceptionUnwindFinallyEnter](icorprofilercallback-exceptionunwindfinallyenter-method.md)<br /><br /> [ExceptionUnwindFinallyLeave](icorprofilercallback-exceptionunwindfinallyleave-method.md)<br /><br /> [ExceptionCatcherEnter](icorprofilercallback-exceptioncatcherenter-method.md)<br /><br /> [RuntimeSuspendStarted](icorprofilercallback-runtimesuspendstarted-method.md)<br /><br /> [RuntimeSuspendFinished](icorprofilercallback-runtimesuspendfinished-method.md)<br /><br /> [RuntimeSuspendAborted](icorprofilercallback-runtimesuspendaborted-method.md)<br /><br /> [RuntimeThreadSuspended](icorprofilercallback-runtimethreadsuspended-method.md)<br /><br /> [RuntimeThreadResumed](icorprofilercallback-runtimethreadresumed-method.md)<br /><br /> [MovedReferences](icorprofilercallback-movedreferences-method.md)<br /><br /> [ObjectReferences](icorprofilercallback-objectreferences-method.md)<br /><br /> [ObjectsAllocatedByClass](icorprofilercallback-objectsallocatedbyclass-method.md)<br /><br /> [RootReferences2](icorprofilercallback-rootreferences-method.md)<br /><br /> [HandleCreated](icorprofilercallback2-handlecreated-method.md)<br /><br /> [HandleDestroyed](icorprofilercallback2-handledestroyed-method.md)<br /><br /> [GarbageCollectionStarted](icorprofilercallback2-garbagecollectionstarted-method.md)<br /><br /> [GarbageCollectionFinished](icorprofilercallback2-garbagecollectionfinished-method.md)|[GetILFunctionBodyAllocator](icorprofilerinfo-getilfunctionbodyallocator-method.md)<br /><br /> [SetILFunctionBody](icorprofilerinfo-setilfunctionbody-method.md)<br /><br /> [SetILInstrumentedCodeMap](icorprofilerinfo-setilinstrumentedcodemap-method.md)<br /><br /> [ForceGC](icorprofilerinfo-forcegc-method.md)<br /><br /> [GetClassFromToken](icorprofilerinfo-getclassfromtoken-method.md)<br /><br /> [GetClassFromTokenAndTypeArgs](icorprofilerinfo2-getclassfromtokenandtypeargs-method.md)<br /><br /> [GetFunctionFromTokenAndTypeArgs](icorprofilerinfo2-getfunctionfromtokenandtypeargs-method.md)<br /><br /> [GetAppDomainInfo](icorprofilerinfo-getappdomaininfo-method.md)<br /><br /> [EnumModules](icorprofilerinfo3-enummodules-method.md)<br /><br /> [RequestProfilerDetach](icorprofilerinfo3-requestprofilerdetach-method.md)<br /><br /> [GetAppDomainsContainingModule](icorprofilerinfo3-getappdomainscontainingmodule-method.md)|  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ICorProfilerCallback2 Interface](icorprofilercallback2-interface.md)
- [ICorProfilerCallback3 Interface](icorprofilercallback3-interface.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
