---
description: "Learn more about: ICorDebugEval Interface"
title: "ICorDebugEval Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval"
helpviewer_keywords: 
  - "ICorDebugEval interface [.NET Framework debugging]"
ms.assetid: 3a5c9815-832d-47e1-b7f7-bbba135d7cf1
topic_type: 
  - "apiref"
---
# ICorDebugEval Interface

Provides methods to enable the debugger to execute code within the context of the code being debugged.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Abort Method](icordebugeval-abort-method.md)|Aborts the computation this `ICorDebugEval` object is currently performing.|  
|[CallFunction Method](icordebugeval-callfunction-method.md)|Sets up a call to the specified function. (Obsolete in the .NET Framework version 2.0; use [ICorDebugEval2::CallParameterizedFunction](icordebugeval2-callparameterizedfunction-method.md) instead.)|  
|[CreateValue Method](icordebugeval-createvalue-method.md)|Gets an interface pointer to an "ICorDebugValue" object of the specified type, with an initial value of zero or null. (Obsolete in the .NET Framework 2.0; use [ICorDebugEval2::CreateValueForType](icordebugeval2-createvaluefortype-method.md) instead.)|  
|[GetResult Method](icordebugeval-getresult-method.md)|Gets an interface pointer to an `ICorDebugValue` that contains the results of the evaluation.|  
|[GetThread Method](icordebugeval-getthread-method.md)|Gets an interface pointer to the "ICorDebugThread" where this evaluation is executing or will execute.|  
|[IsActive Method](icordebugeval-isactive-method.md)|Gets a value that indicates whether this `ICorDebugEval` object is currently executing.|  
|[NewArray Method](icordebugeval-newarray-method.md)|Allocates a new array of the specified element type and dimensions. (Obsolete in the .NET Framework 2.0; use [ICorDebugEval2::NewParameterizedArray](icordebugeval2-newparameterizedarray-method.md) instead.)|  
|[NewObject Method](icordebugeval-newobject-method.md)|Allocates a new object instance and calls the specified constructor method. (Obsolete in the .NET Framework 2.0; use [ICorDebugEval2::NewParameterizedObject](icordebugeval2-newparameterizedobject-method.md) instead.)|  
|[NewObjectNoConstructor Method](icordebugeval-newobjectnoconstructor-method.md)|Allocates a new object instance of the specified type, without attempting to call a constructor method. (Obsolete in the .NET Framework 2.0; use [ICorDebugEval2::NewParameterizedObjectNoConstructor](icordebugeval2-newparameterizedobjectnoconstructor-method.md) instead.)|  
|[NewString Method](icordebugeval-newstring-method.md)|Allocates a new string object with the specified contents.|  
  
## Remarks  

 An `ICorDebugEval` object is created in the context of a specific thread that is used to perform the evaluations. All objects and types used in a given evaluation must reside within the same application domain. That application domain need not be the same as the current application domain of the thread. Evaluations can be nested.  
  
 The evaluation's operations do not complete until the debugger calls [ICorDebugController::Continue](icordebugcontroller-continue-method.md), and then receives an [ICorDebugManagedCallback::EvalComplete](icordebugmanagedcallback-evalcomplete-method.md) callback. If you need to use the evaluation functionality without allowing other threads to run, suspend the threads by using either [ICorDebugController::SetAllThreadsDebugState](icordebugcontroller-setallthreadsdebugstate-method.md) or [ICorDebugController::Stop](icordebugcontroller-stop-method.md) before calling [ICorDebugController::Continue](icordebugcontroller-continue-method.md).  
  
 Because user code is running when the evaluation is in progress, any debug events can occur, including class loads and breakpoints. The debugger will receive callbacks, as normal, for these events. The state of the evaluation will be seen as part of the inspection of the normal program state. The stack chain will be a `CHAIN_FUNC_EVAL` chain (see the "CorDebugStepReason" enumeration and the [ICorDebugChain::GetReason](icordebugchain-getreason-method.md) method). The full debugger API will continue to operate as normal.  
  
 If a deadlocked or infinite looping situation arises, the user code may never complete. In such a case, you must call [ICorDebugEval::Abort](icordebugeval-abort-method.md) before resuming the program.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
