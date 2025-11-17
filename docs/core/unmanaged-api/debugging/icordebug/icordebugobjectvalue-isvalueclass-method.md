---
description: "Learn more about: ICorDebugObjectValue::IsValueClass Method"
title: "ICorDebugObjectValue::IsValueClass Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugObjectValue.IsValueClass"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugObjectValue::IsValueClass"
helpviewer_keywords:
  - "ICorDebugObjectValue::IsValueClass method [.NET debugging]"
  - "IsValueClass method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugObjectValue::IsValueClass Method

Gets a value that indicates whether this object value is a value type.

## Syntax

```cpp
HRESULT IsValueClass (
    [out] BOOL               *pbIsValueClass
);
```

## Parameters

 `pbIsValueClass`
 [out] A pointer to a Boolean value that is `true` if the object value, represented by this "ICorDebugObjectValue", is a value type rather than a reference type; otherwise, `pbIsValueClass` is `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
