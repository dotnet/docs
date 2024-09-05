---
description: "Learn more about: IXCLRDataValue::GetNumFields2 Method"
title: "IXCLRDataValue::GetNumFields2 Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataValue::GetNumFields2 Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetNumFields2 Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetNumFields2 Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetNumFields2 Method

Gets the number of arguments corresponding to the stack frame method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetNumFields2(
    [in] ULONG32 flags,
    [in] IXCLRDataTypeInstance *fromType,
    [out] ULONG32 *numFields
);
```

## Parameters

`flags`\
[in] A set of flags defining what fields to count.  Such is one or more of the `CLRDataFieldFlag` enumeration.

`fromType`\
[in] If provided, only fields defined in the given type will be counted.

`numFields`\
[out] The count of fields in the value as described by `flags` and `fromType`.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 13th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdataframe-interface.md)
- [CLRDataFieldFlag Enumeration](clrdatafieldflag-enumeration.md)
