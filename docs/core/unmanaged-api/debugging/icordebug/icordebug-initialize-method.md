---
description: "Learn more about: ICorDebug::Initialize Method"
title: "ICorDebug::Initialize Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebug.Initialize"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebug::Initialize"
helpviewer_keywords:
  - "Initialize method, ICorDebug interface [.NET debugging]"
  - "ICorDebug::Initialize method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebug::Initialize Method

Initializes the `ICorDebug` object.

## Syntax

```cpp
HRESULT Initialize ();
```

## Remarks

The debugger must call `Initialize` at creation time to initialize the debugging services. This method must be called before any other method on `ICorDebug` is called.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
