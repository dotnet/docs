---
description: "Learn more about: IXCLRDataValue::EndEnumFields Method"
title: "IXCLRDataValue::EndEnumFields Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::EndEnumFields Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::EndEnumFields Method"
helpviewer.keywords:
  - "IXCLRDataValue::EndEnumFields Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::EndEnumFields Method

Releases the resources used by internal iterators used during instance enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumFields(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the fields of the value.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 16th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataValue::StartEnumFields Method](ixclrdatavalue-startenumfields-method.md)
- [IXCLRDataValue::EnumField Method](ixclrdatavalue-enumfield-method.md)
