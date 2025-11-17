---
description: "Learn more about: ICorDebugModule::GetClassFromToken Method"
title: "ICorDebugModule::GetClassFromToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetClassFromToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetClassFromToken"
helpviewer_keywords:
  - "GetClassFromToken method, ICorDebugModule interface [.NET debugging]"
  - "ICorDebugModule::GetClassFromToken method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetClassFromToken Method

Gets the class specified by the metadata token.

## Syntax

```cpp
HRESULT GetClassFromToken(
    [in]  mdTypeDef        typeDef,
    [out] ICorDebugClass **ppClass
);
```

## Parameters

 `typedef`
 [in] An `mdTypeDef` metadata token that references the metadata of a class.

 `ppClass`
 [out] A pointer to the address of an ICorDebugClass object that represents the class.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
