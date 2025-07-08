---
description: "Learn more about: IXCLRDataValue::StartEnumFieldsByName Method"
title: "IXCLRDataValue::StartEnumFieldsByName Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::StartEnumFieldsByName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::StartEnumFieldsByName Method"
helpviewer.keywords:
  - "IXCLRDataValue::StartEnumFieldsByName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::StartEnumFieldsByName Method

Provides a handle to enumerate the fields of the value by name.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumFieldsByName(
    [in] LPCWSTR name,
    [in] ULONG32 nameFlags,
    [in] ULONG32 fieldFlags,
    [in] IXCLRDataTypeInstance *fromType,
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`name`\
[in] The name for which to enumerate matching fields

`nameFlags`\
[in] A set of flags defining how to match `name` against field names.  This is one of the behaviors defined in the `CLRDataByNameFlag` enumeration.

`fieldFlags`\
[in] A set of flags defining which fields to enumerate.  This is one or more of the flags defined in the `CLRDataFieldFlag` enumeration.

`fromType`\
[in] If provided, only fields defined in this type are enumerated.

`handle`\
[out] A handle for enumerating the fields by name as specified by the other arguments to this method.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 17th slot of the virtual method table.

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
- [IXCLRDataValue::EnumFieldByName Method](ixclrdatavalue-enumfieldbyname-method.md)
- [IXCLRDataValue::EndEnumFieldsByName Method](ixclrdatavalue-endenumfieldsbyname-method.md)
