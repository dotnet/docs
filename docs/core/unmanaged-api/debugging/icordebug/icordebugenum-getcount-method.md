---
description: "Learn more about: ICorDebugEnum::GetCount Method"
title: "ICorDebugEnum::GetCount Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEnum.GetCount"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEnum::GetCount"
helpviewer_keywords:
  - "ICorDebugEnum::GetCount method [.NET debugging]"
  - "GetCount method, ICorDebugEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEnum::GetCount Method

Gets the number of items in the enumeration.

## Syntax

```cpp
HRESULT GetCount (
    [out] ULONG *pcelt
);
```

## Parameters

 `pcelt`
 [out] A pointer to the number of items in the enumeration.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
