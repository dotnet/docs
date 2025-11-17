---
description: "Learn more about: ICorDebugCode::GetAddress Method"
title: "ICorDebugCode::GetAddress Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.GetAddress"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::GetAddress"
helpviewer_keywords:
  - "GetAddress method, ICorDebugCode interface [.NET debugging]"
  - "ICorDebugCode::GetAddress method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::GetAddress Method

Gets the relative virtual address (RVA) of the code segment that this "ICorDebugCode" interface represents.

## Syntax

```cpp
HRESULT GetAddress (
    [out] CORDB_ADDRESS *pStart
);
```

## Parameters

 `pStart`
 [out] A pointer to the RVA of the code segment.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
