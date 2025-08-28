---
description: "Learn more about: ICorDebugProcess5::GetArrayLayout Method"
title: "ICorDebugProcess5::GetArrayLayout Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.GetArrayLayout"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::GetArrayLayout"
helpviewer_keywords:
  - "ICorDebugProcess5::GetArrayLayout method [.NET debugging]"
  - "GetArrayLayout method, ICorDebugProcess5 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::GetArrayLayout Method

Provides information about the layout of array types.

## Syntax

```cpp
HRESULT GetArrayLayout(    [in] COR_TYPEID id,     [out] COR_ARRAY_LAYOUT *pLayout);
```

## Parameters

 `id`
 [in] A [COR_TYPEID](cor-typeid-structure.md) token that specifies the array whose layout is desired.

 `pLayout`
 [out] A pointer to a [COR_ARRAY_LAYOUT](cor-array-layout-structure.md) structure that contains information about the layout of the array in memory.

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
