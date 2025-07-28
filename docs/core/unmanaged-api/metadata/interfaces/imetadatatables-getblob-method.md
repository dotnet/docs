---
description: "Learn more about: IMetaDataTables::GetBlob Method"
title: "IMetaDataTables::GetBlob Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetBlob"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetBlob"
  - "IMetaDataTables::GetBlob method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetBlob Method

Gets a pointer to the binary large object (BLOB) at the specified column index.

## Syntax

```cpp
HRESULT GetBlob (
    [in]  ULONG          ixBlob,
    [out] ULONG          *pcbData,
    [out] const void     **ppData
);
```

## Parameters

 `ixBlob`
 [in] The memory address from which to get `ppData`.

 `pcbData`
 [out] A pointer to the size, in bytes, of `ppData`.

 `ppData`
 [out] A pointer to a pointer to the binary data retrieved.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
