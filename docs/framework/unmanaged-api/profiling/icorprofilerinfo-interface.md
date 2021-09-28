---
description: "Learn more about: ICorProfilerInfo Interface"
title: "ICorProfilerInfo Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo"
helpviewer_keywords: 
  - "ICorProfilerInfo interface [.NET Framework profiling]"
ms.assetid: eb4e4ce0-06e7-4469-bbc4-edc2eb5da4b1
topic_type: 
  - "apiref"
---
# ICorProfilerInfo Interface

Provides methods for use by code profilers to communicate with the common language runtime (CLR) to control event monitoring and request information.  
  
> [!NOTE]
> Each method in the `ICorProfilerInfo` interface returns an HRESULT to indicate success or failure. See CorError.h for a list of possible return codes.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginInprocDebugging Method](icorprofilerinfo-begininprocdebugging-method.md)|Initializes in-process debugging support. This method is obsolete in the .NET Framework version 2.0.|  
|[EndInprocDebugging Method](icorprofilerinfo-endinprocdebugging-method.md)|Shuts down an in-process debugging session. This method is obsolete in the .NET Framework version 2.0.|  
|[ForceGC Method](icorprofilerinfo-forcegc-method.md)|Forces garbage collection to occur within the runtime.|  
|[GetAppDomainInfo Method](icorprofilerinfo-getappdomaininfo-method.md)|Gets information about the specified application domain.|  
|[GetAssemblyInfo Method](icorprofilerinfo-getassemblyinfo-method.md)|Gets information about the specified assembly.|  
|[GetClassFromObject Method](icorprofilerinfo-getclassfromobject-method.md)|Gets the `ClassID` of an<br /><br /> object, given its `ObjectID`.|  
|[GetClassFromToken Method](icorprofilerinfo-getclassfromtoken-method.md)|Gets the ID of the class, given the metadata token. This method is obsolete in the .NET Framework version 2.0. Use the [ICorProfilerInfo2::GetClassFromTokenAndTypeArgs](icorprofilerinfo2-getclassfromtokenandtypeargs-method.md) method instead.|  
|[GetClassIDInfo Method](icorprofilerinfo-getclassidinfo-method.md)|Gets the parent module and the metadata token for the specified class.|  
|[GetCodeInfo Method](icorprofilerinfo-getcodeinfo-method.md)|Gets the extent of native code associated with the specified function ID. This method is obsolete. Use the [ICorProfilerInfo2::GetCodeInfo2](icorprofilerinfo2-getcodeinfo2-method.md) method instead.|  
|[GetCurrentThreadID Method](icorprofilerinfo-getcurrentthreadid-method.md)|Gets the ID of the current thread, if it is a managed thread.|  
|[GetEventMask Method](icorprofilerinfo-geteventmask-method.md)|Gets the current event categories for which the profiler wants to receive event notifications from the CLR.|  
|[GetFunctionFromIP Method](icorprofilerinfo-getfunctionfromip-method.md)|Maps a managed code instruction pointer to a `FunctionID`.|  
|[GetFunctionFromToken Method](icorprofilerinfo-getfunctionfromtoken-method.md)|Gets the ID of a function. This method is obsolete in the .NET Framework version 2.0. Use the [ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs](icorprofilerinfo2-getfunctionfromtokenandtypeargs-method.md) method instead.|  
|[GetFunctionInfo Method](icorprofilerinfo-getfunctioninfo-method.md)|Gets the parent class and metadata token for the specified function.|  
|[GetHandleFromThread Method](icorprofilerinfo-gethandlefromthread-method.md)|Maps the ID of a thread to a Win32 thread handle.|  
|[GetILFunctionBody Method](icorprofilerinfo-getilfunctionbody-method.md)|Gets a pointer to the body of a method in Microsoft intermediate language (MSIL) code, starting at its header.|  
|[GetILFunctionBodyAllocator Method](icorprofilerinfo-getilfunctionbodyallocator-method.md)|Gets an interface that provides a method to allocate memory to be used for swapping out the body of a method in MSIL code.|  
|[GetILToNativeMapping Method](icorprofilerinfo-getiltonativemapping-method.md)|Gets a map from MSIL offsets to native offsets for the code contained in the specified function.|  
|[GetInprocInspectionInterface Method](icorprofilerinfo-getinprocinspectioninterface-method.md)|Gets an object that can be queried for an ICorDebugProcess interface. This method is obsolete in the .NET Framework version 2.0.|  
|[GetInprocInspectionIThisThread Method](icorprofilerinfo-getinprocinspectionithisthread-method.md)|Gets an object that can be queried for the ICorDebugThread interface. This method is obsolete in the .NET Framework version 2.0.|  
|[GetModuleInfo Method](icorprofilerinfo-getmoduleinfo-method.md)|Given a module ID, returns the file name of the module and the ID of the module's parent assembly.|  
|[GetModuleMetaData Method](icorprofilerinfo-getmodulemetadata-method.md)|Gets a metadata interface instance that maps to the specified module.|  
|[GetObjectSize Method](icorprofilerinfo-getobjectsize-method.md)|Gets the size of a specified object.|  
|[GetThreadContext Method](icorprofilerinfo-getthreadcontext-method.md)|Gets the context identity currently associated with the specified thread.|  
|[GetThreadInfo Method](icorprofilerinfo-getthreadinfo-method.md)|Gets the current Win32 thread identity for the specified thread.|  
|[GetTokenAndMetadataFromFunction Method](icorprofilerinfo-gettokenandmetadatafromfunction-method.md)|Gets the metadata token and an instance of the metadata interface that can be used against the token for the specified function.|  
|[IsArrayClass Method](icorprofilerinfo-isarrayclass-method.md)|Determines whether the specified class is an array class.|  
|[SetEnterLeaveFunctionHooks Method](icorprofilerinfo-setenterleavefunctionhooks-method.md)|Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.|  
|[SetEventMask Method](icorprofilerinfo-seteventmask-method.md)|Sets a value that specifies the types of events for which the profiler wants to receive notification from the CLR.|  
|[SetFunctionIDMapper Method](icorprofilerinfo-setfunctionidmapper-method.md)|Specifies the profiler-implemented function that will be called to map `FunctionID` values to alternative values, which are passed to the profiler's function entry/exit hooks.|  
|[SetFunctionReJIT Method](icorprofilerinfo-setfunctionrejit-method.md)|Not implemented. Do not use.|  
|[SetILFunctionBody Method](icorprofilerinfo-setilfunctionbody-method.md)|Replaces the body of the specified function in the specified module.|  
|[SetILInstrumentedCodeMap Method](icorprofilerinfo-setilinstrumentedcodemap-method.md)|Specifies how the offsets of a specified function's original MSIL map to the new offsets of the function's profiler-modified MSIL.|  
  
## Remarks  

 A profiler calls a method in the `ICorProfilerInfo` interface to communicate with the CLR to control event monitoring and request information.  
  
 The methods of the `ICorProfilerInfo` interface are implemented by the CLR using the free-threaded model. Each method returns an HRESULT to indicate success or failure. See CorError.h for a list of possible return codes.  
  
 The CLR passes, via the profiler's implementation of [ICorProfilerCallback::Initialize](icorprofilercallback-initialize-method.md), an `ICorProfilerInfo` interface to each code profiler during initialization. A code profiler can then call methods of the `ICorProfilerInfo` interface to get information about managed code being executed under the control of the CLR.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
