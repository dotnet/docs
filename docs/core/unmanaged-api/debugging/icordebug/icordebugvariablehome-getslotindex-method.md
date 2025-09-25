---
description: "Learn more about: ICorDebugVariableHome::GetSlotIndex Method"
title: "ICorDebugVariableHome::GetSlotIndex Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetSlotIndex"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetSlotIndex"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetSlotIndex method [.NET debugging]"
  - "GetSlotIndex method, ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome::GetSlotIndex Method

Gets the managed slot-index of a local variable.

## Syntax

```cpp
HRESULT GetSlotIndex(
    [out] ULONG32 *pSlotIndex
);
```

## Parameters

 `pSlotIndex`
 [out] A pointer to the slot-index of a local variable.

## Return Value

The method returns the following values.

|Value|Description|
|-----------|-----------------|
|`S_OK`|The method call returned a slot-index value in `pSlotIndex`.|
|`E_FAIL`|The current [ICorDebugVariableHome](icordebugvariablehome-interface.md) instance represents a function argument.|

## Remarks

The slot-index can be used to retrieve the metadata for this local variable.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
