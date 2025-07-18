---
description: "Learn more about: IMetaDataTables::GetString Method"
title: "IMetaDataTables::GetString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetString"
helpviewer_keywords:
  - "IMetaDataTables::GetString method [.NET Framework metadata]"
  - "GetString method, IMetaDataTables interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetString Method

Gets the string at the specified index from the table column in the current reference scope.

## Syntax

```cpp
HRESULT GetString (
    [in]  ULONG       ixString,
    [out] const char  **ppString
);
```

## Parameters

 `ixString`
 [in] The index at which to start to search for the next value.

 `ppString`
 [out] A pointer to a pointer to the returned string value.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
