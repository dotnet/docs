---
description: "Learn more about: IXCLRDataValue::GetBytes Method"
title: "IXCLRDataValue::GetBytes Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataValue::GetBytes Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetBytes Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetBytes Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetBytes Method

Copy between an object and a buffer.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetBytes(
    [in] ULONG32 bufLen,
    [out] ULONG32 *dataSize,
    [out, size_is(bufLen)] BYTE buffer[]
);
```

## Parameters

`bufLen`\
[in] The length in bytes of the buffer `buffer`.

`dataSize`\
[out] The number of bytes of data written to the buffer `buffer`.

`buffer`\
[out] The data bytes of the object.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
