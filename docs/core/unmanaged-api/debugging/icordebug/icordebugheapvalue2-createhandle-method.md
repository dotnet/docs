---
description: "Learn more about: ICorDebugHeapValue2::CreateHandle Method"
title: "ICorDebugHeapValue2::CreateHandle Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugHeapValue2.CreateHandle"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugHeapValue2::CreateHandle"
helpviewer_keywords:
  - "CreateHandle method [.NET debugging]"
  - "ICorDebugHeapValue2::CreateHandle method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugHeapValue2::CreateHandle Method

Creates a handle of the specified type for the heap value represented by this ICorDebugHeapValue2 object.

## Syntax

```cpp
HRESULT CreateHandle (
    [in] CorDebugHandleType      type,
    [out] ICorDebugHandleValue   **ppHandle
);
```

## Parameters

 `type`
 [in] A value of the CorDebugHandleType enumeration that specifies the type of handle to be created.

 `ppHandle`
 [out] A pointer to the address of an ICorDebugHandleValue object that represents the new handle for this heap value.

## Remarks

The handle will be created in the application domain that is associated with the heap value, and will become invalid if the application domain gets unloaded.

Multiple calls to this function for the same heap value will create multiple handles. Because handles affect the performance of the garbage collector, the debugger should limit itself to a relatively small number of handles (about 256) that are active at a time.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
