---
description: "Learn more about: ICorDebugManagedCallback2::DestroyConnection Method"
title: "ICorDebugManagedCallback2::DestroyConnection Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback2.DestroyConnection"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback2::DestroyConnection"
helpviewer_keywords:
  - "DestroyConnection method [.NET debugging]"
  - "ICorDebugManagedCallback2::DestroyConnection method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback2::DestroyConnection Method

Notifies the debugger that the specified connection has been terminated.

## Syntax

```cpp
HRESULT DestroyConnection (
    [in] ICorDebugProcess     *pProcess,
    [in] CONNID               dwConnectionId
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process containing the connection that was destroyed.

 `dwConnectionId`
 [in] The ID of the connection that was destroyed.

## Remarks

 A `DestroyConnection` callback will be fired when a host calls [ICLRDebugManager::EndConnection](../hosting/iclrdebugmanager-endconnection-method.md) in the [Hosting API](../hosting/index.md).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
