---
description: "Learn more about: ICorDebugEnum::Clone Method"
title: "ICorDebugEnum::Clone Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEnum.Clone"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEnum::Clone"
helpviewer_keywords:
  - "Clone method, ICorDebugEnum interface [.NET debugging]"
  - "ICorDebugEnum::Clone method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEnum::Clone Method

Creates a copy of this ICorDebugEnum object.

## Syntax

```cpp
HRESULT Clone (
    [out] ICorDebugEnum **ppEnum
);
```

## Parameters

 `ppEnum`
 [out] A pointer to the address of an `ICorDebugEnum` object that is a copy of this `ICorDebugEnum` object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
