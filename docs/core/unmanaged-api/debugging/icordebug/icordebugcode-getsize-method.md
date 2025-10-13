---
description: "Learn more about: ICorDebugCode::GetSize Method"
title: "ICorDebugCode::GetSize Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.GetSize"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::GetSize"
helpviewer_keywords:
  - "GetSize method, ICorDebugCode interface [.NET debugging]"
  - "ICorDebugCode::GetSize method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::GetSize Method

Gets the size, in bytes, of the binary code represented by this "ICorDebugCode".

## Syntax

```cpp
HRESULT GetSize (
    [out] ULONG32    *pcBytes
);
```

## Parameters

`pcBytes`
[out] A pointer to the size, in bytes, of the binary code that this `ICorDebugCode` object represents.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 1.0
