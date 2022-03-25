---
description: "Learn more about: RegisterForRuntimeStartup3 Function"
title: "RegisterForRuntimeStartup3 Function"
ms.date: "03/21/2022"
f1_keywords: 
  - "RegisterForRuntimeStartup3"
api_location: 
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
helpviewer_keywords: 
  - "RegisterForRuntimeStartup3 function"
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
ms.assetid: 35c7a18f-133a-4584-bd25-bb338568b0c6
---
# RegisterForRuntimeStartup3 Function for .NET Core

Executes the callback when the .NET Core runtime starts in the specified process.
  
## Syntax  
  
```cpp  
HRESULT RegisterForRuntimeStartup3 (  
    [in] DWORD dwProcessId,
    [in] LPCWSTR lpApplicationGroupId,
    [in] ICLRDebuggingLibraryProvider3* pLibraryProvider,
    [in] PSTARTUP_CALLBACK pfnCallback,
    [in] PVOID parameter,
    [out] PVOID *ppUnregisterToken)
);  
```  
  
## Parameters  

 `dwProcessId`\
 [in] The process id of the target process.
  
 `lpApplicationGroupId`\
 [in] A string representing the application group ID of a sandboxed process running in Mac. Pass NULL if the process is not running in a sandbox and other platforms.

 `pLibraryProvider`\
 [in] A callback interface instance for locating DBI and DAC. See [ICLRDebuggingLibraryProvider3](iclrdebugginglibraryprovider3-interface.md) interface.  

 `pfnCallback`\
 [in] A callback that is invoked when the runtime starts. See [PSTARTUP_CALLBACK](pstartup_callback-function-pointer.md) function pointer.

 `parameter`\
 [in] data pointer passed to pfnCallback.

 `ppUnregisterToken`\
 [out] pointer to return the [UnregisterForRuntimeStartup](unregisterforruntimestartup-function.md) token.
  
## Return Value

 `S_OK`\
 The startup callback was successfully registered.
  
 `E_INVALIDARG`\
 Either `pfnCallback` or `ppUnregisterToken` is null.  
  
 `E_FAIL` (or other `E_` return codes)\
 Callback registration failed.

## Remarks

The callback is passed the proper ICorDebug instance for the version of the runtime or an error if something fails. This API works for launch and attach (and even the attach scenario if the runtime hasn't been loaded yet) equally on both xplat and Windows. The callback is always called on a separate thread. This API returns immediately.  The callback is invoked when the coreclr runtime module is loaded during early initialization. The runtime is blocked during initialization until the callback returns.  If the runtime is already loaded in the process (as in the normal attach case), the callback is executed and the runtime is not blocked.  The callback is always invoked on a separate thread and this API returns immediately.  Only the first coreclr module instance found in the target process is currently supported.

This is the only register function that works for single-file applications.

## Requirements

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib
  
 **.NET Versions:** [!INCLUDE[net_core_60](../../../../includes/net-core-60-md.md)]
