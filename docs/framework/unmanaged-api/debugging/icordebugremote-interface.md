---
description: "Learn more about: ICorDebugRemote Interface"
title: "ICorDebugRemote Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRemote"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRemote"
helpviewer_keywords: 
  - "ICorDebugRemote interface [.NET Framework debugging]"
ms.assetid: 53d073c6-fa02-40d2-82e1-b9452bb6abaa
topic_type: 
  - "apiref"
---
# ICorDebugRemote Interface

Provides the ability to launch or attach a managed debugger to a remote target process.  
  
## Syntax  
  
```cpp  
interface ICorDebugRemote : IUnknown  
{  
    HRESULT CreateProcessEx  
      (  
      [in] ICorDebugRemoteTarget *     pRemoteTarget,  
      [in] LPCWSTR                     lpApplicationName,  
      [in] LPWSTR                      lpCommandLine,  
      [in] LPSECURITY_ATTRIBUTES       lpProcessAttributes,  
      [in] LPSECURITY_ATTRIBUTES       lpThreadAttributes,  
      [in] BOOL                        bInheritHandles,  
      [in] DWORD                       dwCreationFlags,  
      [in] PVOID                       lpEnvironment,  
      [in] LPCWSTR                     lpCurrentDirectory,  
      [in] LPSTARTUPINFOW              lpStartupInfo,  
      [in] LPPROCESS_INFORMATION       lpProcessInformation,  
      [in] CorDebugCreateProcessFlags  debuggingFlags,  
      [out] ICorDebugProcess **        ppProcess  
      );  
  
    HRESULT DebugActiveProcessEx  
      (  
      [in] ICorDebugRemoteTarget *   pRemoteTarget,  
      [in] DWORD                     dwProcessId,  
      [in] BOOL                      fWin32Attach,  
      [out] ICorDebugProcess **      ppProcess  
      );  
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICorDebugRemote::CreateProcessEx Method](icordebugremote-createprocessex-method.md)|Creates a process on a remote machine for managed debugging.|  
|[ICorDebugRemote::DebugActiveProcessEx Method](icordebugremote-debugactiveprocessex-method.md)|Launches a process on a remote machine under the debugger.|  
  
## Remarks  

 Currently, this functionality is supported only for debugging a Silverlight-based application target that is running on a remote Macintosh machine.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 4.5, 4, 3.5 SP1  
  
## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

- [Debugging Interfaces](debugging-interfaces.md)
