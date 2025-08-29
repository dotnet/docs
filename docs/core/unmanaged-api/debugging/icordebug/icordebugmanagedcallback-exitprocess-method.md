---
description: "Learn more about: ICorDebugManagedCallback::ExitProcess Method"
title: "ICorDebugManagedCallback::ExitProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.ExitProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::ExitProcess"
helpviewer_keywords:
  - "ExitProcess method, ICorDebugManagedCallback interface [.NET debugging]"
  - "ICorDebugManagedCallback::ExitProcess method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::ExitProcess Method

Notifies the debugger that a process has exited.

## Syntax

```cpp
HRESULT ExitProcess (
    [in] ICorDebugProcess *pProcess
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process.

## Remarks

You cannot continue from an `ExitProcess` event. This event may fire asynchronously to other events while the process appears to be stopped. This can occur if the process terminates while stopped, usually due to some external force.

If the common language runtime (CLR) is already dispatching a managed callback, this event will be delayed until after that callback has returned.

The `ExitProcess` event is the only exit/unload event that is guaranteed to get called on shutdown.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
