---
description: "Learn more about: IXCLRDataValue::GetArrayElement Method"
title: "IXCLRDataValue::GetArrayElement Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::GetArrayElement Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetArrayElement Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetArrayElement Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetArrayElement Method

Gets a value corresponding to a given element in an array.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetArrayElement(
    [in] ULONG32 numInd,
    [in, size_is(numInd)] LONG32 indicies[],
    [out] IXCLRDataValue **value
);
```

## Parameters

`numInd`\
[in] The number of indicies required to access the array element and contained in the `indicies` array.

`indicies`\
[in] The indicies required to access the array element.

`value`\
[out] The value of the given element in the array.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 25th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataValue::GetArrayProperties Method](ixclrdatavalue-getarrayproperties-method.md)
