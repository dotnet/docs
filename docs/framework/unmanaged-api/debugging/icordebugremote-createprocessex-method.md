---
title: "ICorDebugRemote::CreateProcessEx Method"
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
  - "ICorDebugRemote.CreateProcessEx"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRemoteTarget::CreateProcessEx"
helpviewer_keywords: 
  - "CreateProcessEx method, ICorDebugRemote interface [.NET Framework debugging]"
  - "ICorDebugRemote::CreateProcessEx method [.NET Framework debugging]"
ms.assetid: 41af93c7-e448-4251-8d4d-413d38c635f2
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRemote::CreateProcessEx Method
Launches a process on a remote machine under the debugger.  
  
## Syntax  
  
```  
HRESULT CreateProcessEx (  
    [in]  ICorDebugRemoteTarget*      pRemoteTarget,  
    [in]  LPCWSTR                     lpApplicationName,  
    [in]  LPWSTR                      lpCommandLine,  
    [in]  LPSECURITY_ATTRIBUTES       lpProcessAttributes,  
    [in]  LPSECURITY_ATTRIBUTES       lpThreadAttributes,  
    [in]  BOOL                        bInheritHandles,  
    [in]  DWORD                       dwCreationFlags,  
    [in]  PVOID                       lpEnvironment,  
    [in]  LPCWSTR                     lpCurrentDirectory,  
    [in]  LPSTARTUPINFOW              lpStartupInfo,  
    [in]  LPPROCESS_INFORMATION       lpProcessInformation,  
    [in]  CorDebugCreateProcessFlags  debuggingFlags,  
    [out] ICorDebugProcess**          ppProcess  
);  
```  
  
#### Parameters  
 `pRemoteTarget`  
 [in] Pointer to an [ICorDebugRemoteTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremotetarget-interface.md). Used to determine the remote machine on which the process will be launched.  
  
 `lpApplicationName`  
 [in] Pointer to a null-terminated string that specifies the module to be executed by the launched process. The module is executed in the security context of the calling process.  
  
 `lpCommandLine`  
 [in] Pointer to a null-terminated string that specifies the command line to be executed by the launched process.  
  
 `lpProcessAttributes`  
 [in] Unused for remote debugging.  
  
 `lpThreadAttributes`  
 [in] Unused for remote debugging.  
  
 `bInheritHandles`  
 [in] Unused for remote debugging.  
  
 `dwCreationFlags`  
 [in] Unused for remote debugging.  
  
 `lpEnvironment`  
 [in] Pointer to an environment block for the new process.  
  
 `lpCurrentDirectory`  
 [in] Pointer to a null-terminated string that specifies the full path to the current directory for the process. If this parameter is null, the new process will have the same current drive and directory as the calling process.  
  
 `lpStartupInfo`  
 [in] Unused for remote debugging.  
  
 `lpProcessInformation`  
 [in] Unused for remote debugging.  
  
 `debuggingFlags`  
 [in] Unused for remote debugging.  
  
 `ppProcess`  
 [out] A pointer to the address of a"ICorDebugProcess Interface" object that represents the process.  
  
## Return Value  
 S_OK  
 Successfully launched the process on the remote machine and returned an "ICorDebugProcess Interface" for debugging.  
  
 E_FAIL (or other E_ return codes)  
 Unable to launch the process on the remote machine and return an "ICorDebugProcess Interface" for debugging.  
  
## Remarks  
 Mixed-mode debugging is not supported in Silverlight.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 4.5, 4, 3.5 SP1  
  
## See Also  
 [ICorDebugRemote Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremote-interface.md)  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)  
    
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
