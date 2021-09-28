---
description: "Learn more about: ICorProfilerCallback::UnmanagedToManagedTransition Method"
title: "ICorProfilerCallback::UnmanagedToManagedTransition Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.UnmanagedToManagedTransition"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::UnmanagedToManagedTransition"
helpviewer_keywords: 
  - "ICorProfilerCallback::UnmanagedToManagedTransition method [.NET Framework profiling]"
  - "UnmanagedToManagedTransition method [.NET Framework profiling]"
ms.assetid: ade2cc01-9b81-4e09-a5f9-b3b9dda27e96
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::UnmanagedToManagedTransition Method

Notifies the profiler that a transition from unmanaged code to managed code has occurred.  
  
## Syntax  
  
```cpp  
HRESULT UnmanagedToManagedTransition(  
    [in] FunctionID functionId,  
    [in] COR_PRF_TRANSITION_REASON reason);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function that is being called.  
  
 `reason`  
 [in] A value of the [COR_PRF_TRANSITION_REASON](cor-prf-transition-reason-enumeration.md) enumeration that indicates whether the transition occurred because of a call into managed code from unmanaged code, or because of a return from an unmanaged function called by a managed one.  
  
## Remarks  

 If the value of `reason` is COR_PRF_TRANSITION_RETURN and `functionId` is not null, the function ID is that of the unmanaged function, and will never have been compiled using the just-in-time (JIT) compiler. Unmanaged functions have some basic information associated with them, such as a name and some metadata.  
  
 If the value of `reason` is COR_PRF_TRANSITION_CALL, it may be possible that the called function (that is, the managed function) has not yet been JIT-compiled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [ManagedToUnmanagedTransition Method](icorprofilercallback-managedtounmanagedtransition-method.md)
- [Using Explicit PInvoke in C++ (DllImport Attribute)](/cpp/dotnet/using-explicit-pinvoke-in-cpp-dllimport-attribute)
- [Using C++ Interop (Implicit PInvoke)](/cpp/dotnet/using-cpp-interop-implicit-pinvoke)
