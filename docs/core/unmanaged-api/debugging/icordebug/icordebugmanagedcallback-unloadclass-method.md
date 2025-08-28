---
description: "Learn more about: ICorDebugManagedCallback::UnloadClass Method"
title: "ICorDebugManagedCallback::UnloadClass Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.UnloadClass"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::UnloadClass"
helpviewer_keywords:
  - "ICorDebugManagedCallback::UnloadClass method [.NET debugging]"
  - "UnloadClass method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::UnloadClass Method

Notifies the debugger that a class is being unloaded.

## Syntax

```cpp
HRESULT UnloadClass (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugClass      *c
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the class.

 `c`
 [in] A pointer to an ICorDebugClass object that represents the class.

## Remarks

 The class should not be referenced after this call.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [LoadClass Method](icordebugmanagedcallback-loadclass-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
