---
title: "ICorDebugRemote::DebugActiveProcessEx Method"
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
  - "ICorDebugRemote.DebugActiveProcessEx"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRemoteTarget::DebugActiveProcessEx"
helpviewer_keywords: 
  - "ICorDebugRemote::DebugActiveProcessEx method [.NET Framework debugging]"
  - "DebugActiveProcessEx method, ICorDebugRemote interface [.NET Framework debugging]"
ms.assetid: b0df5c5d-9a2e-47bf-894c-6f8a9fe24a1f
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRemote::DebugActiveProcessEx Method
Launches a process on a remote machine under the debugger.  
  
## Syntax  
  
```  
HRESULT DebugActiveProcessEx (  
    [in]  ICorDebugRemoteTarget *   pRemoteTarget,  
    [in]  DWORD                     dwProcessId,  
    [in]  BOOL                      fWin32Attach,  
    [out] ICorDebugProcess **       ppProcess  
);  
```  
  
#### Parameters  
 `pRemoteTarget`  
 [in] Pointer to an [ICorDebugRemoteTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremotetarget-interface.md). This parameter is used to determine the machine on which the process is running.  
  
 `id`  
 [in] The ID of the process to which the debugger is to be attached.  
  
 `win32Attach`  
 [in] `true` if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, `false`.  
  
 `ppProcess`  
 [out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.  
  
## Return Value  
 S_OK  
 Successfully attached to the process on the remote machine.  
  
 E_FAIL (or other E_ return codes)  
 Unable to attach to the process on the remote machine.  
  
## Remarks  
 Mixed-mode debugging is not supported in Silverlight.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 4.5, 4, 3.5 SP1  
  
## See Also  
 [ICorDebugRemote Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremote-interface.md)  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)  
    
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
