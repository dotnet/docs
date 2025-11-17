---
description: "Learn more about: ICorDebugFunction::GetClass Method"
title: "ICorDebugFunction::GetClass Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetClass"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetClass"
helpviewer_keywords:
  - "GetClass method, ICorDebugFunction interface [.NET debugging]"
  - "ICorDebugFunction::GetClass method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetClass Method

Gets an ICorDebugClass object that represents the class this function is a member of.

## Syntax

```cpp
HRESULT GetClass (
    [out] ICorDebugClass **ppClass
);
```

## Parameters

 `ppClass`
 [out] A pointer to the address of the `ICorDebugClass` object that represents the class, or null, if this function is not a member of a class.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
