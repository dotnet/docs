---
description: "Learn more about: ICorDebugProcess5::GetTypeFields Method"
title: "ICorDebugProcess5::GetTypeFields Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.GetTypeFields"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::GetTypeFields"
helpviewer_keywords:
  - "GetTypeFields method, ICorDebugProcess5 interface [.NET debugging]"
  - "ICorDebugProcess5::GetTypeFields method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::GetTypeFields Method

Provides information about the fields that belong to a type.

## Syntax

```cpp
HRESULT GetTypeFields(
    [in] COR_TYPEID id,
    [in] ULONG32 celt,
    [out] COR_FIELD fields[],
    [out] ULONG32 *pceltNeeded
);
```

## Parameters

 `id`
 [in] The identifier of the type whose field information is retrieved.

 `celt`
 [in] The number of [COR_FIELD](cor-field-structure.md) objects whose field information is to be retrieved.

 `fields`
 [out] An array of [COR_FIELD](cor-field-structure.md) objects that provide information about the fields that belong to the type.

 `pceltNeeded`
 [out] A pointer to the number of [COR_FIELD](cor-field-structure.md) objects included in `fields`.

## Remarks

The `celt` parameter, which specifies the number of fields whose field information the method uses to populate `fields`, should correspond to the value of the `COR_TYPE_LAYOUT::numFields` field.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
