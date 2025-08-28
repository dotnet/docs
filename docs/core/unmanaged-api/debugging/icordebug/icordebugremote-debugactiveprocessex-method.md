---
description: "Learn more about: ICorDebugRemote::DebugActiveProcessEx Method"
title: "ICorDebugRemote::DebugActiveProcessEx Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRemote.DebugActiveProcessEx"
api_location:
  - "CorDebug.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRemoteTarget::DebugActiveProcessEx"
helpviewer_keywords:
  - "ICorDebugRemote::DebugActiveProcessEx method [.NET debugging]"
  - "DebugActiveProcessEx method, ICorDebugRemote interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRemote::DebugActiveProcessEx Method

Launches a process on a remote machine under the debugger.

## Syntax

```cpp
HRESULT DebugActiveProcessEx (
    [in]  ICorDebugRemoteTarget *   pRemoteTarget,
    [in]  DWORD                     dwProcessId,
    [in]  BOOL                      fWin32Attach,
    [out] ICorDebugProcess **       ppProcess
);
```

## Parameters

 `pRemoteTarget`
 [in] Pointer to an [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md). This parameter is used to determine the machine on which the process is running.

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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** 4.5, 4, 3.5 SP1

## See also

- [ICorDebugRemote Interface](icordebugremote-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

