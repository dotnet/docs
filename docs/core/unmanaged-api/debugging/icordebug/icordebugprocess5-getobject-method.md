---
description: "Learn more about: ICorDebugProcess5::GetObject Method"
title: "ICorDebugProcess5::GetObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.GetObject"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::GetObject"
helpviewer_keywords:
  - "GetObject method, ICorDebugProcess5 interface [.NET debugging]"
  - "ICorDebugProcess5::GetObject method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::GetObject Method

Converts an object address to an "ICorDebugObjectValue" object.

## Syntax

```cpp
HRESULT GetObject(
    [in] CORDB_ADDRESS addr,
    [out] ICorDebugObjectValue **ppObject
);
```

## Parameters

 `addr`
 [in] The object address.

 `ppObject`
 [out] A pointer to the address of an  "ICorDebugObjectValue" object.

## Remarks

 If `addr` does not point to a valid managed object, the `GetObject` method returns `E_FAIL`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
