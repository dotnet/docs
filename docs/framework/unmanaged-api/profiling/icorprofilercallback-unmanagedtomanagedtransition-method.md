---
title: "ICorProfilerCallback::UnmanagedToManagedTransition Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorProfilerCallback.UnmanagedToManagedTransition"
apilocation: 
  - "mscorwks.dll"
apitype: "COM"
f1_keywords: 
  - "ICorProfilerCallback::UnmanagedToManagedTransition"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorProfilerCallback::UnmanagedToManagedTransition method [.NET Framework profiling]"
  - "UnmanagedToManagedTransition method [.NET Framework profiling]"
ms.assetid: ade2cc01-9b81-4e09-a5f9-b3b9dda27e96
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICorProfilerCallback::UnmanagedToManagedTransition Method
Notifies the profiler that a transition from unmanaged code to managed code has occurred.  
  
## Syntax  
  
```  
HRESULT UnmanagedToManagedTransition(  
    [in] FunctionID functionId,  
    [in] COR_PRF_TRANSITION_REASON reason);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function that is being called.  
  
 `reason`  
 [in] A value of the [COR_PRF_TRANSITION_REASON](../../../../docs/framework/unmanaged-api/profiling/cor-prf-transition-reason-enumeration.md) enumeration that indicates whether the transition occurred because of a call into managed code from unmanaged code, or because of a return from an unmanaged function called by a managed one.  
  
## Remarks  
 If the value of `reason` is COR_PRF_TRANSITION_RETURN and `functionId` is not null, the function ID is that of the unmanaged function, and will never have been compiled using the just-in-time (JIT) compiler. Unmanaged functions have some basic information associated with them, such as a name and some metadata.  
  
 If the value of `reason` is COR_PRF_TRANSITION_CALL, it may be possible that the called function (that is, the managed function) has not yet been JIT-compiled.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)   
 [ManagedToUnmanagedTransition Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-managedtounmanagedtransition-method.md)   
 [Using Explicit PInvoke in C++ (DllImport Attribute)](http://msdn.microsoft.com/library/18e5218c-6916-48a1-a127-f66e22ef15fc)   
 [Using C++ Interop (Implicit PInvoke)](http://msdn.microsoft.com/library/5f710bf1-88ae-4c4e-8326-b3f0b7c4c68a)