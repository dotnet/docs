---
description: "Learn more about: ICorProfilerCallback::ManagedToUnmanagedTransition Method"
title: "ICorProfilerCallback::ManagedToUnmanagedTransition Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.ManagedToUnmanagedTransition"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::ManagedToUnmanagedTransition"
helpviewer_keywords: 
  - "ManagedToUnmanagedTransition method [.NET Framework profiling]"
  - "ICorProfilerCallback::ManagedToUnmanagedTransition method [.NET Framework profiling]"
ms.assetid: ef3cd619-912d-40c5-a449-03ba02a39ee7
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::ManagedToUnmanagedTransition Method

Notifies the profiler that a transition from managed code to unmanaged code has occurred.  
  
## Syntax  
  
```cpp  
HRESULT ManagedToUnmanagedTransition(  
    [in] FunctionID functionId,  
    [in] COR_PRF_TRANSITION_REASON reason);  
```  
  
## Parameters  

 `functionId`  
 [in] The ID of the function that is being called.  
  
 `reason`  
 [in] A value of the [COR_PRF_TRANSITION_REASON](cor-prf-transition-reason-enumeration.md) enumeration that indicates whether the transition occurred because of a call into unmanaged code from managed code, or because of a return from a managed function called by an unmanaged one.  
  
## Remarks  

 If the value of `reason` is COR_PRF_TRANSITION_CALL, the function ID is that of the unmanaged function, which will never have been compiled using the just-in-time compiler. Unmanaged functions have basic information associated with them, such as a name and some metadata. If the unmanaged function was called by using implicit platform invoke (PInvoke), the runtime cannot determine the destination of the call and the value of `functionId` will be null. For more information on implicit PInvoke, see [Using C++ Interop (Implicit PInvoke)](/cpp/dotnet/using-cpp-interop-implicit-pinvoke).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
- [UnmanagedToManagedTransition Method](icorprofilercallback-unmanagedtomanagedtransition-method.md)
- [Using Explicit PInvoke in C++ (DllImport Attribute)](/cpp/dotnet/using-explicit-pinvoke-in-cpp-dllimport-attribute)
