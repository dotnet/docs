---
description: "Learn more about: ICorProfilerInfo2 Interface"
title: "ICorProfilerInfo2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2"
helpviewer_keywords: 
  - "ICorProfilerInfo2 interface [.NET Framework profiling]"
ms.assetid: 91bd49b6-4d12-494f-a8f1-2f251e8c65e3
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2 Interface

Provides methods that code profilers use to communicate with the common language runtime (CLR) to control event monitoring and request information. The `ICorProfilerInfo2` interface is an extension of the [ICorProfilerInfo](icorprofilerinfo-interface.md) interface. That is, it provides new methods supported in the .NET Framework version 2.0 and later versions.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DoStackSnapshot Method](icorprofilerinfo2-dostacksnapshot-method.md)|Walks the stack of the specified thread to report managed call frames to the profiler.|  
|[EnumModuleFrozenObjects Method](icorprofilerinfo2-enummodulefrozenobjects-method.md)|Gets an enumerator that allows iteration over the frozen objects in the specified module.|  
|[GetAppDomainStaticAddress Method](icorprofilerinfo2-getappdomainstaticaddress-method.md)|Gets the address of the specified application domain-static field that is in the scope of the specified application domain.|  
|[GetArrayObjectInfo Method](icorprofilerinfo2-getarrayobjectinfo-method.md)|Gets detailed information about an array object.|  
|[GetBoxClassLayout Method](icorprofilerinfo2-getboxclasslayout-method.md)|Gets information about the class layout for a specified value type that is boxed.|  
|[GetClassFromTokenAndTypeArgs Method](icorprofilerinfo2-getclassfromtokenandtypeargs-method.md)|Gets the `ClassID` of a type by using the specified metadata token and the `ClassID` values of any type arguments.|  
|[GetClassIDInfo2 Method](icorprofilerinfo2-getclassidinfo2-method.md)|Gets the parent module of the specified generic class, the metadata token for the class, the `ClassID` of its parent class, and the `ClassID` for each type argument, if present, of the class.|  
|[GetClassLayout Method](icorprofilerinfo2-getclasslayout-method.md)|Gets information about the layout, in memory, of the fields defined by the specified class. That is, this method gets the offsets of the class's fields.|  
|[GetCodeInfo2 Method](icorprofilerinfo2-getcodeinfo2-method.md)|Gets the extents of native code associated with the specified `FunctionID`.|  
|[GetContextStaticAddress Method](icorprofilerinfo2-getcontextstaticaddress-method.md)|Gets the address of the specified context-static field that is in the scope of the specified context.|  
|[GetFunctionFromTokenAndTypeArgs Method](icorprofilerinfo2-getfunctionfromtokenandtypeargs-method.md)|Gets the `FunctionID` of a function by using the specified metadata token, containing class, and `ClassID` values of any type arguments.|  
|[GetFunctionInfo2 Method](icorprofilerinfo2-getfunctioninfo2-method.md)|Gets the parent class, the metadata token, and the `ClassID` of each type argument, if present, of a function.|  
|[GetGenerationBounds Method](icorprofilerinfo2-getgenerationbounds-method.md)|Gets the memory regions (the segments of the heap) that make up the generations of the garbage-collected heap.|  
|[GetNotifiedExceptionClauseInfo Method](icorprofilerinfo2-getnotifiedexceptionclauseinfo-method.md)|Gets the native address and frame information for the exception clause (`catch`/`finally`/`filter`) that is about to be run or has just been run.|  
|[GetObjectGeneration Method](icorprofilerinfo2-getobjectgeneration-method.md)|Gets the segment of the heap that contains the specified object.|  
|[GetRVAStaticAddress Method](icorprofilerinfo2-getrvastaticaddress-method.md)|Gets the address of the specified relative virtual address (RVA)-static field.|  
|[GetStaticFieldInfo Method](icorprofilerinfo2-getstaticfieldinfo-method.md)|Gets the scope in which the specified field is static.|  
|[GetStringLayout Method](icorprofilerinfo2-getstringlayout-method.md)|Gets information about the layout of a string object.|  
|[GetThreadAppDomain Method](icorprofilerinfo2-getthreadappdomain-method.md)|Gets the ID of the application domain in which the specified thread is currently executing code.|  
|[GetThreadStaticAddress Method](icorprofilerinfo2-getthreadstaticaddress-method.md)|Gets the address of the specified thread-static field that is in the scope of the specified thread.|  
|[SetEnterLeaveFunctionHooks2 Method](icorprofilerinfo2-setenterleavefunctionhooks2-method.md)|Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.|  
  
## Remarks  

 A profiler calls a method in the `ICorProfilerInfo2` interface to communicate with the CLR to control event monitoring and request information.  
  
 The methods of the `ICorProfilerInfo2` interface are implemented by the CLR using the free-threaded model. Each method returns an HRESULT to indicate success or failure. For a list of possible return codes, see the CorError.h file.  
  
 The CLR passes an `ICorProfilerInfo2` interface to each code profiler during initialization, using the profiler's implementation of [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md). A code profiler can then call methods of the `ICorProfilerInfo2` interface to get information about managed code being executed under the control of the CLR.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
