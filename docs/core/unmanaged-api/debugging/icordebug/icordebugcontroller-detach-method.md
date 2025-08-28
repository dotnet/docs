---
description: "Learn more about: ICorDebugController::Detach Method"
title: "ICorDebugController::Detach Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugController.Detach"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugController::Detach"
helpviewer_keywords:
  - "Detach method, ICorDebugController interface [.NET debugging]"
  - "ICorDebugController::Detach method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugController::Detach Method

Detaches the debugger from the process or application domain.

## Syntax

```cpp
HRESULT Detach ();
```

## Remarks

 The process or application domain continues execution normally, but the "ICorDebugProcess" or "ICorDebugAppDomain" object is no longer valid and no further callbacks will occur.

 In .NET Framework version 2.0, if unmanaged debugging is enabled, this method will fail due to operating system limitations.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
