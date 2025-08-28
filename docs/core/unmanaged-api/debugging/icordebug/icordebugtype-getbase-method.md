---
description: "Learn more about: ICorDebugType::GetBase Method"
title: "ICorDebugType::GetBase Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugType.GetBase"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugType::GetBase"
helpviewer_keywords:
  - "ICorDebugType::GetBase method [.NET debugging]"
  - "GetBase method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugType::GetBase Method

Gets an interface pointer to an ICorDebugType that represents the base type, if one exists, of the type represented by this `ICorDebugType`.

## Syntax

```cpp
HRESULT GetBase (
    [out] ICorDebugType   **pBase
);
```

## Parameters

 `pBase`
 [out] A pointer to the address of an `ICorDebugType` object that represents the base type.

## Remarks

 Looking up the base type for a type is useful to implement common debugger functionality, such as printing out all the fields of an object or its parent classes.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
