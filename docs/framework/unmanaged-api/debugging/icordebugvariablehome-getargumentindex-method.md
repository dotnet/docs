---
description: "Learn more about: ICorDebugVariableHome::GetArgumentIndex Method"
title: "ICorDebugVariableHome::GetArgumentIndex Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetArgumentIndex"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetArgumentIndex"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetArgumentIndex method [.NET Framework debugging]"
  - "GetArgumentIndex method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: e86fcc72-388d-4009-ab21-8f9c3323e9a3
topic_type:
  - "apiref"
---

# ICorDebugVariableHome::GetArgumentIndex Method

Gets the index of a function argument.

## Syntax

```cpp
HRESULT GetArgumentIndex(
    [out] ULONG32* pArgumentIndex
);
```

## Parameters

`pArgumentIndex`\
[out] A pointer to the argument index.

## Return Value

The method returns the following values.

|Value|Description|
|-----------|-----------------|
|`S_OK`|The method call returned a valid argument index.|
|`E_FAIL`|The current [ICorDebugVariableHome](icordebugvariablehome-interface.md) instance represents a local variable.|

## Remarks

The argument index can be used to retrieve metadata for this argument.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
