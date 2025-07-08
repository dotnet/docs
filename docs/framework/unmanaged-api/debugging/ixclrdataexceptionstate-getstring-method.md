---
description: "Learn more about: IXCLRDataExceptionState::GetString Method"
title: "IXCLRDataExceptionState::GetString Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState::GetString Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState::GetString Method"
helpviewer.keywords:
  - "IXCLRDataExceptionState::GetString Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState::GetString Method

Gets the standard element type of this type definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetString(
    [in] ULONG32 bufLen,
    [out] ULONG32 *strLen,
    [out, size_is(bufLen)] WCHAR str[]
);
```

## Parameters

`bufLen`\
[in] The length in characters of the `str` buffer.

`strLen`\
[out] The number of characters in the exception string written to the `str` buffer.

`str`\
[out] The exception string.

## Remarks

The provided method is part of the `IXCLRDataExceptionState` interface and corresponds to the 9th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
