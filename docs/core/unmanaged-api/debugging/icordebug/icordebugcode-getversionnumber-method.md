---
description: "Learn more about: ICorDebugCode::GetVersionNumber Method"
title: "ICorDebugCode::GetVersionNumber Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.GetVersionNumber"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::GetVersionNumber"
helpviewer_keywords:
  - "GetVersionNumber method, ICorDebugCode interface [.NET debugging]"
  - "ICorDebugCode::GetVersionNumber method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::GetVersionNumber Method

Gets the one-based number that identifies the version of the code that this "ICorDebugCode" represents.

## Syntax

```cpp
HRESULT GetVersionNumber (
    [out] ULONG32    *nVersion
);
```

## Parameters

 `nVersion`
 [out] A pointer to the version number of the code.

## Remarks

The version number is incremented each time an edit-and-continue (EnC) operation is performed on the code.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
