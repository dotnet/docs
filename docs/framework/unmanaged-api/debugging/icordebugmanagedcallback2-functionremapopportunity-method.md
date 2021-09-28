---
description: "Learn more about: ICorDebugManagedCallback2::FunctionRemapOpportunity Method"
title: "ICorDebugManagedCallback2::FunctionRemapOpportunity Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback2.FunctionRemapOpportunity"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::FunctionRemapOpportunity"
helpviewer_keywords: 
  - "FunctionRemapOpportunity method [.NET Framework debugging]"
  - "ICorDebugManagedCallback2::FunctionRemapOpportunity method [.NET Framework debugging]"
ms.assetid: 0d6471bc-ad9b-4b1d-a307-c10443918863
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback2::FunctionRemapOpportunity Method

Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.  
  
## Syntax  
  
```cpp  
HRESULT FunctionRemapOpportunity (  
    [in] ICorDebugAppDomain   *pAppDomain,  
    [in] ICorDebugThread      *pThread,  
    [in] ICorDebugFunction    *pOldFunction,  
    [in] ICorDebugFunction    *pNewFunction,  
    [in] ULONG32              oldILOffset  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the edited function.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread on which the remap breakpoint was encountered.  
  
 `pOldFunction`  
 [in] A pointer to an ICorDebugFunction object that represents the version of the function that is currently running on the thread.  
  
 `pNewFunction`  
 [in] A pointer to an ICorDebugFunction object that represents the latest version of the function.  
  
 `oldILOffset`  
 [in] The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.  
  
## Remarks  

 This callback gives the debugger an opportunity to remap the instruction pointer to its proper place in the new version of the specified function by calling the [ICorDebugILFrame2::RemapFunction](icordebugilframe2-remapfunction-method.md) method. If the debugger does not call `RemapFunction` before calling the [ICorDebugController::Continue](icordebugcontroller-continue-method.md) method, the runtime will continue to execute the old code and will fire another `FunctionRemapOpportunity` callback at the next sequence point.  
  
 This callback will be invoked for every frame that is executing an older version of the given function until the debugger returns S_OK.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
