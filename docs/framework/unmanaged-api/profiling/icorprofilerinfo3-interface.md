---
title: "ICorProfilerInfo3 Interface"
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
  - "ICorProfilerInfo3"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3"
helpviewer_keywords: 
  - "ICorProfilerInfo3 interface [.NET Framework profiling]"
ms.assetid: 044a262f-0fa7-485d-b0c1-64cdc359c654
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo3 Interface
Provides methods that code profilers use to communicate with the common language runtime (CLR) to control event monitoring and to request information. The `ICorProfilerInfo3` interface is an extension of the [ICorProfilerInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md) interface. It provides new methods supported in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)] and later versions.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumJITedFunctions Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-enumjitedfunctions-method.md)|Returns an enumerator for all previously JIT-compiled functions.|  
|[EnumModules Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-enummodules-method.md)|Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.|  
|[GetAppDomainsContainingModule Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getappdomainscontainingmodule-method.md)|Gets the identifiers of the application domains in which the given module has been loaded.|  
|[GetFunctionEnter3Info Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getfunctionenter3info-method.md)|Provides the stack frame and argument information of the function that is being reported to the profiler by the [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionenter3withinfo-function.md) function; can be called only during the `FunctionEnter3WithInfo` callback.|  
|[GetFunctionLeave3Info Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getfunctionleave3info-method.md)|Provides the stack frame and return value of the function that is being reported to the profiler by the [FunctionLeave3WithInfo function](../../../../docs/framework/unmanaged-api/profiling/functionleave3withinfo-function.md) function; can be called only during the `FunctionLeave3WithInfo` callback.|  
|[GetFunctionTailcall3Info Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getfunctiontailcall3info-method.md)|Provides the stack frame of the function that is being reported to the profiler by the [FunctionTailcall3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3withinfo-function.md) function; can be called only during the `FunctionTailcall3WithInfo` callback.|  
|[GetModuleInfo2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getmoduleinfo2-method.md)|Given a module ID, returns the file name of the module, the ID of the module's parent assembly, and a bitmask that describes the properties of the module.|  
|[GetRuntimeInformation Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getruntimeinformation-method.md)|Provides version information about the runtime that is being profiled.|  
|[GetStringLayout2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getstringlayout2-method.md)|Gets information about the layout of a string object.|  
|[GetThreadStaticAddress2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-getthreadstaticaddress2-method.md)|Gets the address of the specified thread-static field that is in the scope of the specified thread and application domain.|  
|[RequestProfilerDetach Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-requestprofilerdetach-method.md)|Instructs the runtime to detach the profiler.|  
|[SetEnterLeaveFunctionHooks3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setenterleavefunctionhooks3-method.md)|Specifies the profiler-implemented functions that will be called on the [FunctionEnter3](../../../../docs/framework/unmanaged-api/profiling/functionenter3-function.md), [FunctionLeave3](../../../../docs/framework/unmanaged-api/profiling/functionleave3-function.md), and [FunctionTailcall3](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3-function.md) functions.|  
|[SetEnterLeaveFunctionHooks3WithInfo Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setenterleavefunctionhooks3withinfo-method.md)|Specifies the profiler-implemented functions that will be called on the [FunctionEnter3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionenter3withinfo-function.md), [FunctionLeave3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functionleave3withinfo-function.md), and [FunctionTailcall3WithInfo](../../../../docs/framework/unmanaged-api/profiling/functiontailcall3withinfo-function.md) hooks of managed functions.|  
|[SetFunctionIDMapper2 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-setfunctionidmapper2-method.md)|Specifies the profiler-implemented function that will be called to map `FunctionID` values to alternative values, which are passed to the profiler's function entry/exit hooks. This method extends [ICorProfilerInfo::SetFunctionIDMapper](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setfunctionidmapper-method.md) with a parameter that profilers may use to disambiguate among runtimes.|  
  
## Remarks  
 The CLR implements the methods of the `ICorProfilerInfo3` interface by using the free-threaded model. Each method returns an HRESULT to indicate success or failure. For a list of possible return codes, see the CorError.h file.  
  
 The CLR passes an `ICorProfilerInfo3` interface to each code profiler during initialization, using the profiler's implementation of the [ICorProfilerCallback::Initialize](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-initialize-method.md) or [ICorProfilerCallback3::InitializeForAttach](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback3-initializeforattach-method.md) method. A code profiler can then call the `ICorProfilerInfo3` methods to get information about managed code that is being executed under the control of the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
