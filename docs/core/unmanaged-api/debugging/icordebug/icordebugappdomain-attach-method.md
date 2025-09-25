---
description: "Learn more about: ICorDebugAppDomain::Attach Method"
title: "ICorDebugAppDomain::Attach Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.Attach"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::Attach"
helpviewer_keywords:
  - "ICorDebugAppDomain::Attach method [.NET debugging]"
  - "Attach method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::Attach Method

Attaches the debugger to the application domain.

## Syntax

```cpp
HRESULT Attach ();
```

## Remarks

The debugger must be attached to the application domain to receive events and to enable debugging of the application domain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
