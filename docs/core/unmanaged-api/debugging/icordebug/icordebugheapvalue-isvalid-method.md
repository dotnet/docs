---
description: "Learn more about: ICorDebugHeapValue::IsValid Method"
title: "ICorDebugHeapValue::IsValid Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHeapValue.IsValid"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapValue::IsValid"
helpviewer_keywords:
  - "IsValid method [.NET debugging]"
  - "ICorDebugHeapValue::IsValid method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapValue::IsValid Method

**Deprecated** Gets a value that indicates whether the object represented by this ICorDebugHeapValue is valid.

## Syntax

```cpp
HRESULT IsValid (
    [out] BOOL    *pbValid
);
```

## Parameters

 `pbValid`
 [out] A pointer to a Boolean value that indicates whether this value on the heap is valid.

## Remarks

The value is invalid if it has been reclaimed by the garbage collector.

This method has been deprecated. All values are valid until [ICorDebugController::Continue](icordebugcontroller-continue-method.md) is called, at which time the values are invalidated.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
