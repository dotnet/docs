---
description: "Learn more about: CreateProcessForLaunch Function"
title: "CreateProcessForLaunch Function"
ms.date: "03/21/2022"
api_name: 
  - "CreateProcessForLaunch"
api_location: 
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
f1_keywords: 
  - "CreateProcessForLaunch"
helpviewer_keywords: 
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
  - "CreateProcessForLaunch function"
ms.assetid: 3d2fe9bd-75ef-4364-84a6-da1e1994ac1a
topic_type: 
  - "apiref"
---
# CreateProcessForLaunch Function

A subset of the Windows CreateProcess that can be supported cross-platform.
  
## Syntax  
  
```cpp  
HRESULT CreateProcessForLaunch (
    [in] LPWSTR lpCommandLine,
    [in] BOOL bSuspendProcess,
    [in] LPVOID lpEnvironment,
    [in] LPCWSTR lpCurrentDirectory,
    [out] PDWORD pProcessId,
    [out] HANDLE *pResumeHandle
);
```

## Parameters  

 `lpCommandLine`\
 [in] The command line to be executed.
  
 `bSuspendProcess`\
 [in] If this parameter is TRUE, suspend the process for launch.
  
 `lpEnvironment`\
 [in, optional] A pointer to the environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.
  
 `lpCurrentDirectory`\
 [in, optional] The full path to the current directory for the process. If this parameter is NULL, the new process will have the same current drive and directory as the calling process.
  
 `pProcessId`\
 [out] The id to identify the process created.

 `pResumeHandle`\
 [out] The handle to use with ResumeProcess to resume the process if bSuspendProcess is TRUE.
  
## Return Value  

 S_OK
 The process was successfully created.
  
 E_FAIL (or other E_ return codes)
 The launch failed.

## Remarks

See the Win32 CreateProcess API for more details.

## Requirements  

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib
  
 **.NET Versions:** [!INCLUDE[net_core_21](../../../../includes/net-core-21-md.md)]
