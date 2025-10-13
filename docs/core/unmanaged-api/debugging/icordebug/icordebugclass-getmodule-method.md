---
description: "Learn more about: ICorDebugClass::GetModule Method"
title: "ICorDebugClass::GetModule Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugClass.GetModule"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugClass::GetModule"
helpviewer_keywords:
  - "GetModule method, ICorDebugClass interface [.NET debugging]"
  - "ICorDebugClass::GetModule method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugClass::GetModule Method

Gets the module that defines this class.

## Syntax

```cpp
HRESULT GetModule (
    [out] ICorDebugModule    **pModule
);
```

## Parameters

 `pModule`
 [out] A pointer to the address of an ICorDebugModule object that represents the module in which this class is defined.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
