---
description: "Learn more about: ICorDebugEnum::Skip Method"
title: "ICorDebugEnum::Skip Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEnum.Skip"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEnum::Skip"
helpviewer_keywords:
  - "ICorDebugEnum::Skip method [.NET debugging]"
  - "Skip method, ICorDebugEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEnum::Skip Method

Moves the cursor forward in the enumeration by the specified number of items.

## Syntax

```cpp
HRESULT Skip (
    [in] ULONG celt
);
```

## Parameters

 `celt`
 [in] The number of items by which to move the cursor forward.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugEnum Interface](icordebugenum-interface1.md)
