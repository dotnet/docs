---
description: "Learn more about: ICorDebugManagedCallback::UnloadModule Method"
title: "ICorDebugManagedCallback::UnloadModule Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.UnloadModule"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::UnloadModule"
helpviewer_keywords:
  - "ICorDebugManagedCallback::UnloadModule method [.NET debugging]"
  - "UnloadModule method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::UnloadModule Method

Notifies the debugger that a common language runtime module (DLL) has been unloaded.

## Syntax

```cpp
HRESULT UnloadModule (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugModule     *pModule
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contained the module.

 `pModule`
 [in] A pointer to an ICorDebugModule object that represents the module.

## Remarks

The module should not be used after this call.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [LoadModule Method](icordebugmanagedcallback-loadmodule-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
