---
description: "Learn more about: ICorDebugManagedCallback::ExitAppDomain Method"
title: "ICorDebugManagedCallback::ExitAppDomain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.ExitAppDomain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::ExitAppDomain"
helpviewer_keywords:
  - "ICorDebugManagedCallback::ExitAppDomain method [.NET debugging]"
  - "ExitAppDomain method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::ExitAppDomain Method

Notifies the debugger that an application domain has exited.

## Syntax

```cpp
HRESULT ExitAppDomain (
    [in] ICorDebugProcess   *pProcess,
    [in] ICorDebugAppDomain *pAppDomain
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process that contains the given application domain.

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that has exited.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
