---
description: "Learn more about: IMetaDataTables::GetUserString Method"
title: "IMetaDataTables::GetUserString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetUserString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetUserString"
  - "GetUserString method, IMetaDataTables interface [.NET metadata]"
topic_type:
  - "apiref"
---

# IMetaDataTables::GetUserString Method

Gets the hard-coded string at the specified index in the string column in the current scope.

## Syntax

```cpp
HRESULT GetUserString (
    [in]  ULONG       ixUserString,
    [out] ULONG       *pcbData,
    [out] const void  **ppData
);
```

## Parameters

`ixUserString`\
[in] The index value from which the hard-coded string will be retrieved.

`pcbData`\
[out] A pointer to the size of `ppData`.

`ppData`\
[out] A pointer to a pointer to the returned string.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** Cor.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
