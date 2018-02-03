---
title: "ICorDebug::CreateProcess Method"
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
  - "ICorDebug.CreateProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::CreateProcess"
helpviewer_keywords: 
  - "ICorDebug::CreateProcess method [.NET Framework debugging]"
  - "CreateProcess method, ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: b6128694-11ed-46e7-bd4e-49ea1914c46a
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebug::CreateProcess Method
Launches a process and its primary thread under the control of the debugger.  
  
## Syntax  
  
```  
HRESULT CreateProcess (  
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
    [out] ICorDebugProcess            **ppProcess  
);  
```  
  
#### Parameters  
 `lpApplicationName`  
 [in] Pointer to a null-terminated string that specifies the module to be executed by the launched process. The module is executed in the security context of the calling process.  
  
 `lpCommandLine`  
 [in] Pointer to a null-terminated string that specifies the command line to be executed by the launched process. The application name (for example, "SomeApp.exe") must be the first argument.  
  
 `lpProcessAttributes`  
 [in] Pointer to a Win32 `SECURITY_ATTRIBUTES` structure that specifies the security descriptor for the process. If `lpProcessAttributes` is null, the process gets a default security descriptor.  
  
 `lpThreadAttributes`  
 [in] Pointer to a Win32 `SECURITY_ATTRIBUTES` structure that specifies the security descriptor for the primary thread of the process. If `lpThreadAttributes` is null, the thread gets a default security descriptor.  
  
 `bInheritHandles`  
 [in] Set to `true` to indicate that each inheritable handle in the calling process is inherited by the launched process, or `false` to indicate that the handles are not inherited. The inherited handles have the same value and access rights as the original handles.  
  
 `dwCreationFlags`  
 [in] A bitwise combination of the [Win32 Process Creation Flags](http://go.microsoft.com/fwlink/?linkid=69981) that control the priority class and the behavior of the launched process.  
  
 `lpEnvironment`  
 [in] Pointer to an environment block for the new process.  
  
 `lpCurrentDirectory`  
 [in] Pointer to a null-terminated string that specifies the full path to the current directory for the process. If this parameter is null, the new process will have the same current drive and directory as the calling process.  
  
 `lpStartupInfo`  
 [in] Pointer to a Win32 `STARTUPINFOW` structure that specifies the window station, desktop, standard handles, and appearance of the main window for the launched process.  
  
 `lpProcessInformation`  
 [in] Pointer to a Win32 `PROCESS_INFORMATION` structure that specifies the identification information about the process to be launched.  
  
 `debuggingFlags`  
 [in] A value of the CorDebugCreateProcessFlags enumeration that specifies the debugging options.  
  
 `ppProcess`  
 [out] A pointer to the address of a ICorDebugProcess object that represents the process.  
  
## Remarks  
 The parameters of this method are the same as those of the Win32 `CreateProcess` method.  
  
 To enable unmanaged mixed-mode debugging, set `dwCreationFlags` to DEBUG_PROCESS &#124; DEBUG_ONLY_THIS_PROCESS. If you want to use only managed debugging, do not set these flags.  
  
 If the debugger and the process to be debugged (the attached process) share a single console, and if interop debugging is used, it is possible for the attached process to hold console locks and stop at a debug event. The debugger will then block any attempt to use the console. To avoid this problem, set the CREATE_NEW_CONSOLE flag in the `dwCreationFlags` parameter.  
  
 Interop debugging is not supported on Win9x and non-x86 platforms such as IA-64-based and AMD64-based platforms.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
