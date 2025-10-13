---
description: "Learn more about: ICorDebugReferenceValue::IsNull Method"
title: "ICorDebugReferenceValue::IsNull Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugReferenceValue.IsNull"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugReferenceValue::IsNull"
helpviewer_keywords:
  - "IsNull method, ICorDebugReferenceValue interface [.NET debugging]"
  - "ICorDebugReferenceValue::IsNull method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugReferenceValue::IsNull Method

Gets a value that indicates whether this ICorDebugReferenceValue is a null value, in which case the `ICorDebugReferenceValue` does not point to an object.

## Syntax

```cpp
HRESULT IsNull (
    [out] BOOL   *pbNull
);
```

## Parameters

 `pbNull`
 [out] A pointer to a Boolean value that is `true` if this `ICorDebugReferenceValue` object is null; otherwise, `pbNull` is `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
