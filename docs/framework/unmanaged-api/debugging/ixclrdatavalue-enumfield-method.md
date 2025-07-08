---
description: "Learn more about: IXCLRDataValue::EnumField Method"
title: "IXCLRDataValue::EnumField Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataValue::EnumField Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::EnumField Method"
helpviewer.keywords:
  - "IXCLRDataValue::EnumField Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::EnumField Method

Enumerates the fields of the value.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumField(
    [in, out] CLRDATA_ENUM *handle,
    [out] IXCLRDataValue **field,
    [in] ULONG32 nameBufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(nameBufLen)] WCHAR nameBuf[],
    [out] mdFieldDef *token
);
```

## Parameters

`handle`\
[in] A handle for enumerating the fields of the value.

`field`\
[out] The enumerated field.

`nameBufLen`\
[in] The length in characters of the provided buffer `nameBuf`

`nameLen`\
[out] The number of characters in the name of the field written to `nameBuf`

`nameBuf`\
[out] The name of the field

`token`\
[out] The metadata token for the field.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 15th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataValue::StartEnumFields Method](ixclrdatavalue-startenumfields-method.md)
- [IXCLRDataValue::EndEnumFields Method](ixclrdatavalue-endenumfields-method.md)
