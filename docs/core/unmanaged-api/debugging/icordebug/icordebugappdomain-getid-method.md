---
description: "Learn more about: ICorDebugAppDomain::GetId Method"
title: "ICorDebugAppDomain::GetId Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.GetId"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::GetId"
helpviewer_keywords:
  - "GetId method, ICorDebugAppDomain interface [.NET debugging]"
  - "ICorDebugAppDomain::GetId method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::GetId Method

Gets the unique identifier of the application domain.

## Syntax

```cpp
HRESULT GetID (
    [out] ULONG32   *pId
);
```

## Parameters

 `pId`
 [out] The unique identifier of the application domain.

## Remarks

The identifier for the application domain is unique within the containing process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
