---
description: "Learn more about: ICorDebugHandleValue::Dispose Method"
title: "ICorDebugHandleValue::Dispose Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHandleValue.Dispose"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHandleValue::Dispose"
helpviewer_keywords:
  - "ICorDebugHandleValue::Dispose method [.NET debugging]"
  - "Dispose method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHandleValue::Dispose Method

Releases the handle referenced by this ICorDebugHandleValue object without explicitly releasing the interface pointer.

## Syntax

```cpp
HRESULT Dispose ();
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
