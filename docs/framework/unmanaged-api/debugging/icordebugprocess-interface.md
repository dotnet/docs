---
title: "ICorDebugProcess Interface1"
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
  - "ICorDebugProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess"
helpviewer_keywords: 
  - "ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: be86f4b5-418a-4c5c-a67c-97148c65ed8c
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess Interface1
Represents a process that is executing managed code. This interface is a subclass of ICorDebugController.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ClearCurrentException Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-clearcurrentexception-method.md)|Clears the current unmanaged exception on the given thread.|  
|[EnableLogMessages Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-enablelogmessages-method.md)|Enables and disables the sending of log messages to the debugger.|  
|[EnumerateAppDomains Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-enumerateappdomains-method.md)|Enumerates all of the application domains in the process.|  
|[EnumerateObjects Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-enumerateobjects-method.md)|Not implemented.|  
|[GetHandle Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-gethandle-method.md)|Gets a handle to the process.|  
|[GetHelperThreadID Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-gethelperthreadid-method.md)|Gets the operating system (OS) thread ID for the debugger's internal helper thread.|  
|[GetID Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getid-method.md)|Gets the operating system (OS) ID of the process.|  
|[GetObject Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getobject-method.md)|Not implemented.|  
|[GetThread Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getthread-method.md)|Gets the ICorDebugThread instance that has the specified OS thread ID.|  
|[GetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-getthreadcontext-method.md)|Gets the context for the given thread.|  
|[IsOSSuspended Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-isossuspended-method.md)|Determines whether the thread has been suspended as a result of the debugger stopping the process.|  
|[IsTransitionStub Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-istransitionstub-method.md)|Determines whether an address is inside a stub that will cause a transition to managed code.|  
|[ModifyLogSwitch Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-modifylogswitch-method.md)|Sets the severity level of the specified log switch.|  
|[ReadMemory Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-readmemory-method.md)|Reads memory from the process.|  
|[SetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-setthreadcontext-method.md)|Sets the context for the given thread.|  
|[ThreadForFiberCookie Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-threadforfibercookie-method.md)|Deprecated.|  
|[WriteMemory Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-writememory-method.md)|Writes data to an area of memory in the process.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
