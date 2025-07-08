---
description: "Learn more about: IXCLRDataFrame::GetLocalVariableByIndex Method"
title: "IXCLRDataFrame::GetLocalVariableByIndex Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame::GetLocalVariableByIndex Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame::GetLocalVariableByIndex Method"
helpviewer.keywords:
  - "IXCLRDataFrame::GetLocalVariableByIndex Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame::GetLocalVariableByIndex Method

Gets a local variable by (0-based) index.  The name parameter is filled in if name information is available.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetLocalVariableByIndex(
    [in] ULONG32 index,
    [out] IXCLRDataValue **localVariable,
    [in] ULONG32 bufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(bufLen)] WCHAR name[]
);
```

## Parameters

`index`\
[out] The 0-based index of the local variable to retrieve.

`localVariable`\
[out] The local variable at the specified `index`.

`bufLen`\
[in] The length in characters of the `name` buffer.

`nameLen`\
[out] The number of characters in the local variable name written to the `name` buffer.

`name`\
[out] The name of the local variable.

## Remarks

The provided method is part of the `IXCLRDataFrame` interface and corresponds to the 10th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataFrame::GetNumLocalVariables Method](ixclrdataframe-getnumlocalvariables-method.md)
