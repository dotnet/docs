---
description: "Learn more about: ICorDebugManagedCallback::CreateProcess Method"
title: "ICorDebugManagedCallback::CreateProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.CreateProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::CreateProcess"
helpviewer_keywords:
  - "ICorDebugManagedCallback::CreateProcess method [.NET debugging]"
  - "CreateProcess method, ICorDebugManagedCallback interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::CreateProcess Method

Notifies the debugger when a process has been attached or started for the first time.

## Syntax

```cpp
HRESULT CreateProcess (
    [in] ICorDebugProcess *pProcess
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process that has been attached or started.

## Remarks

 This method is not called until the common language runtime is initialized. Most of the [ICorDebug](icordebug-interface.md) methods will return CORDBG_E_NOTREADY before the `CreateProcess` callback.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
