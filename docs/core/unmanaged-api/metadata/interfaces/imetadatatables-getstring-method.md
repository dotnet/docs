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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
