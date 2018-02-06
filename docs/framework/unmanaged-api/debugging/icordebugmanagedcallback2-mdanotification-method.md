---
title: "ICorDebugManagedCallback2::MDANotification Method"
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
  - "ICorDebugManagedCallback2.MDANotification"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::MDANotification"
helpviewer_keywords: 
  - "MDANotification method [.NET Framework debugging]"
  - "ICorDebugManagedCallback2::MDANotification method [.NET Framework debugging]"
ms.assetid: 93f79627-bd31-4f4f-b95d-46a032a52fe4
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback2::MDANotification Method
Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.  
  
## Syntax  
  
```  
HRESULT MDANotification(  
    [in] ICorDebugController  *pController,  
    [in] ICorDebugThread      *pThread,  
    [in] ICorDebugMDA         *pMDA  
);  
```  
  
#### Parameters  
 `pController`  
 [in] A pointer to an ICorDebugController interface that exposes the process or application domain in which the MDA occurred.  
  
 A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread interface that exposes the managed thread on which the debug event occurred.  
  
 If the MDA occurred on an unmanaged thread, the value of `pThread` will be null.  
  
 You must get the operating system (OS) thread ID from the MDA object itself.  
  
 `pMDA`  
 [in] A pointer to an [ICorDebugMDA](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md) interface that exposes the MDA information.  
  
## Remarks  
 An MDA is a heuristic warning and does not require any explicit debugger action except for calling [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md) to resume execution of the application that is being debugged.  
  
 The common language runtime (CLR) can determine which MDAs are fired and which data is in any given MDA at any point. Therefore, debuggers should not build any functionality requiring specific MDA patterns.  
  
 MDAs may be queued and fired shortly after the MDA is encountered. This could happen if the runtime needs to wait until it reaches a safe point for firing the MDA, instead of firing the MDA when it encounters it. It also means that the runtime may fire a number of MDAs in a single set of queued callbacks (similar to an "attach" event operation).  
  
 A debugger should release the reference to an `ICorDebugMDA` instance immediately after returning from the `MDANotification` callback, to allow the CLR to recycle the memory consumed by an MDA. Releasing the instance may improve performance if many MDAs are firing.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [ICorDebugManagedCallback2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md)  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
