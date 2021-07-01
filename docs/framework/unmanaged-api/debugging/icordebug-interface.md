---
description: "Learn more about: ICorDebug Interface"
title: "ICorDebug Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebug"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug"
helpviewer_keywords: 
  - "ICorDebug interface [.NET Framework debugging]"
ms.assetid: 33f431d7-ab1a-494d-8af2-20ab15aba194
topic_type: 
  - "apiref"
---
# ICorDebug Interface

Provides methods that allow developers to debug applications in the common language runtime (CLR) environment.  
  
> [!NOTE]
> Mixed-mode (managed and native code) debugging is not supported on non-x86 platforms (such as IA64 and AMD64).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CanLaunchOrAttach Method](icordebug-canlaunchorattach-method.md)|Determines whether launching a new process or attaching to the given process is possible within the context of the current machine and runtime configuration.|  
|[CreateProcess Method](icordebug-createprocess-method.md)|Launches a process and its primary thread under the control of the debugger.|  
|[DebugActiveProcess Method](icordebug-debugactiveprocess-method.md)|Attaches the debugger to an existing process.|  
|[EnumerateProcesses Method](icordebug-enumerateprocesses-method.md)|Gets an enumerator for the processes that are being debugged.|  
|[GetProcess Method](icordebug-getprocess-method.md)|Returns the "ICorDebugProcess" object with the given process ID.|  
|[Initialize Method](icordebug-initialize-method.md)|Initializes the `ICorDebug` object.|  
|[SetManagedHandler Method](icordebug-setmanagedhandler-method.md)|Specifies the event handler object for managed events.|  
|[SetUnmanagedHandler Method](icordebug-setunmanagedhandler-method.md)|Specifies the event handler object for unmanaged events.|  
|[Terminate Method](icordebug-terminate-method.md)|Terminates the `ICorDebug` object.|  
  
## Remarks  

 `ICorDebug` represents an event processing loop for a debugger process. The debugger must wait for the [ICorDebugManagedCallback::ExitProcess](icordebugmanagedcallback-exitprocess-method.md) callback from all processes being debugged before releasing this interface.  
  
 The `ICorDebug` object is the initial object to control all further managed debugging. In the .NET Framework versions 1.0 and 1.1, this object was a `CoClass` object created from COM. In the .NET Framework version 2.0, this object is no longer a `CoClass` object. It must be created by the [CreateDebuggingInterfaceFromVersion](../hosting/createdebugginginterfacefromversion-function.md) function, which is more version-aware. This new creation function enables clients to get a specific implementation of `ICorDebug`, which also emulates a specific version of the debugging API.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
