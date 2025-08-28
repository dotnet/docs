---
description: "Learn more about: ICorDebugProcess5::GetTypeID Method"
title: "ICorDebugProcess5::GetTypeID Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugProcess5.GetTypeID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::GetTypeID"
helpviewer_keywords:
  - "ICorDebugProcess5::GetTypeID method [.NET debugging]"
  - "GetTypeID method, ICorDebugProcess5 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::GetTypeID Method

Converts an object address to a [COR_TYPEID](cor-typeid-structure.md) identifier.

## Syntax

```cpp
HRESULT GetTypeID(
    [in] CORDB_ADDRESS obj,
    [out] COR_TYPEID *pId
);
```

## Parameters

 `obj`
 [in] The object address.

 `pId`
 A pointer to the [COR_TYPEID](cor-typeid-structure.md) value that identifies the object.

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
