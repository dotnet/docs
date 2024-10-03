---
description: "Learn more about: IXCLRDataFrame::GetArgumentByIndex Method"
title: "IXCLRDataFrame::GetArgumentByIndex Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame::GetArgumentByIndex Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame::GetArgumentByIndex Method"
helpviewer.keywords:
  - "IXCLRDataFrame::GetArgumentByIndex Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame::GetArgumentByIndex Method

Gets an argument by its (0-based) index.  The name parameter is filled in if name information is available.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetArgumentByIndex(
    [in] ULONG32 index,
    [out] IXCLRDataValue **arg,
    [in] ULONG32 bufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(bufLen)] WCHAR name[]
);
```

## Parameters

`index`\
[in] The 0-based index of the argument to retrieve.

`arg`\
[out] The argument at the specified `index`.

`bufLen`\
[in] The length in characters of the `name` buffer.

`nameLen`\
[out] The number of characters in the argument name written to the `name` buffer.

`name`\
[out] The name of the argument.

## Remarks

The provided method is part of the `IXCLRDataFrame` interface and corresponds to the 8th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataFrame::GetNumArguments Method](ixclrdataframe-getnumarguments-method.md)
