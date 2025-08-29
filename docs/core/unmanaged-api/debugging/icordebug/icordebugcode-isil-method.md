---
description: "Learn more about: ICorDebugCode::IsIL Method"
title: "ICorDebugCode::IsIL Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.IsIL"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::IsIL"
helpviewer_keywords:
  - "ICorDebugCode::IsIL method [.NET debugging]"
  - "IsIL method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::IsIL Method

Gets a value that indicates whether this "ICorDebugCode" represents code that was compiled in common intermediate language (CIL).

## Syntax

```cpp
HRESULT IsIL (
    [out] BOOL       *pbIL
);
```

## Parameters

`pbIL`
[out] `true` if this `ICorDebugCode` represents code that was compiled in CIL; otherwise, `false`.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 1.0
