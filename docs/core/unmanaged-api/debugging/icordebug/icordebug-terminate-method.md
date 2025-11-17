---
description: "Learn more about: ICorDebug::Terminate Method"
title: "ICorDebug::Terminate Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebug.Terminate"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebug::Terminate"
helpviewer_keywords:
  - "Terminate method, ICorDebug interface [.NET debugging]"
  - "ICorDebug::Terminate method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebug::Terminate Method

Terminates the `ICorDebug` object.

> [!NOTE]
> `Terminate` should not be called until an [ICorDebugManagedCallback::ExitProcess](icordebugmanagedcallback-exitprocess-method.md) callback has been received for all processes being debugged.

## Syntax

```cpp
HRESULT Terminate ();
```

## Remarks

 `Terminate` must be called when the `ICorDebug` object is no longer needed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
