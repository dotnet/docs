---
description: "Learn more about: IXCLRDataTypeDefinition::GetName Method"
title: "IXCLRDataTypeDefinition::GetName Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition::GetName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition::GetName Method"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition::GetName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition::GetName Method

Gets the fully qualified name for this type definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetName(
    [in] ULONG32 flags,
    [in] ULONG32 bufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(bufLen)] WCHAR nameBuf[]
);
```

## Parameters

`flags`\
[in] Reserved.  Must be 0.

`bufLen`\
[in] The length in characters of the `nameBuf` buffer.

`nameLen`\
[out] The number of characters in the fully qualified name written to the `nameBuf` buffer.

`nameBuf`\
[out] The fully qualified name of the type definition.

## Remarks

The provided method is part of the `IXCLRDataTypeDefinition` interface and corresponds to the 15th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeDefinition Interface](ixclrdatatypedefinition-interface.md)
