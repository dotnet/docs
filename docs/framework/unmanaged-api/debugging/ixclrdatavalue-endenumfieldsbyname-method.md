---
description: "Learn more about: IXCLRDataValue::EndEnumFieldsByName Method"
title: "IXCLRDataValue::EndEnumFieldsByName Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::EndEnumFieldsByName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::EndEnumFieldsByName Method"
helpviewer.keywords:
  - "IXCLRDataValue::EndEnumFieldsByName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::EndEnumFieldsByName Method

Releases the resources used by internal iterators used during field enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumFieldsByName(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the fields of the value by name.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 19th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [CLRDataByNameFlag Enumeration](clrdatabynameflag-enumeration.md)
- [CLRDataFieldFlag Enumeration](clrdatafieldflag-enumeration.md)
- [IXCLRDataValue::StartEnumFieldsByName Method](ixclrdatavalue-startenumfieldsbyname-method.md)
- [IXCLRDataValue::EnumFieldByName Method](ixclrdatavalue-enumfieldbyname-method.md)
