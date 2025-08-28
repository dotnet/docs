---
description: "Learn more about: ICorDebugManagedCallback2::CreateConnection Method"
title: "ICorDebugManagedCallback2::CreateConnection Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback2.CreateConnection"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback2::CreateConnection"
helpviewer_keywords:
  - "CreateConnection method [.NET debugging]"
  - "ICorDebugManagedCallback2::CreateConnection method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback2::CreateConnection Method

Notifies the debugger that a new connection has been created.

## Syntax

```cpp
HRESULT CreateConnection (
    [in] ICorDebugProcess     *pProcess,
    [in] CONNID               dwConnectionId,
    [in] WCHAR                *pConnName
);
```

## Parameters

 `pProcess`
 [in] A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created

 `dwConnectionId`
 [in] The ID of the new connection.

 `pConnName`
 [in] A pointer to the name of the new connection.

## Remarks

 A `CreateConnection` callback will be fired in either of the following cases:

- When a debugger attaches to a process that contains connections. In this case, the runtime will generate and dispatch a `CreateConnection` event and a [ICorDebugManagedCallback2::ChangeConnection](icordebugmanagedcallback2-changeconnection-method.md) event for each connection in the process.

- When a host calls [ICLRDebugManager::BeginConnection](../../../../framework/unmanaged-api/hosting/iclrdebugmanager-beginconnection-method.md) in the [Hosting API](../../../../framework/unmanaged-api/hosting/index.md).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
