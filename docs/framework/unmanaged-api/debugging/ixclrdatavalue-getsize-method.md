---
description: "Learn more about: IXCLRDataValue::GetSize Method"
title: "IXCLRDataValue::GetSize Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataValue::GetSize Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetSize Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetSize Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetSize Method

Gets the size in bytes of the value.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetSize(
    [out] ULONG64 *size
);
```

## Parameters

`size`\
[out] The size in bytes of the value.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 6th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
