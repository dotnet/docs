---
description: "Learn more about: ICorDebugClass::GetToken Method"
title: "ICorDebugClass::GetToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugClass.GetToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugClass::GetToken"
helpviewer_keywords:
  - "GetToken method, ICorDebugClass interface [.NET debugging]"
  - "ICorDebugClass::GetToken method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugClass::GetToken Method

Gets the `TypeDef` metadata token that references the definition of this class.

## Syntax

```cpp
HRESULT GetToken (
    [out] mdTypeDef          *pTypeDef
);
```

## Parameters

 `pTypeDef`
 [out] A pointer to an `mdTypeDef` token that references the definition of this class.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Interfaces](../metadata/metadata-interfaces.md)
