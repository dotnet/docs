---
description: "Learn more about: ICorDebugManagedCallback::CreateAppDomain Method"
title: "ICorDebugManagedCallback::CreateAppDomain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.CreateAppDomain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::CreateAppDomain"
helpviewer_keywords:
  - "CreateAppDomain method [.NET debugging]"
  - "ICorDebugManagedCallback::CreateAppDomain method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::CreateAppDomain Method

Notifies the debugger that an application domain has been created.

## Syntax

```cpp
HRESULT CreateAppDomain (
    [in] ICorDebugProcess   *pProcess,
    [in] ICorDebugAppDomain *pAppDomain
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process in which the application domain was created.

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that has been created.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
